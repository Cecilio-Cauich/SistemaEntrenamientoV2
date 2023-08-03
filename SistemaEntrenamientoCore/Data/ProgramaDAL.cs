using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class ProgramaDAL
    {
        #region Global Variables
        public const string BookName = "bPrograma";
        public const string TableName = "dbENC72";
        #endregion

        #region Properties
        public string ConnectionString
        {
            get; set;   
        }
        #endregion

        #region Methods
        ///<summary>
        /// Busca un registro con el Id que se proporciona
        ///</summary>
        /// <param name="Id">Identificador del elemento a buscar</param>
        ///<return>
        ///Devuelve una entidad con los datos del registro que encontró.
        ///</return>
        public Entity.ProgramaInfo GetEntityObject(int Id)
        {

            string SqlStatement = $"SELECT NUM_DOC,titulo,descripcion from {TableName} where {ProgramaInfo.FieldName.Id} = {Id}";
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SqlStatement,ConnectionString);
            return GetEntityObject(dt.Rows[0]);

        }


        /// <summary>
        /// Regresa un objeto entidad con los datos recibidos del DataRow
        /// </summary>
        /// <param name="dr">La fila de tabla table donde se toma los datos para formar un objeto</param>
        /// <returns>
        /// Un objeto con los datos del row
        /// </returns>
        public Entity.ProgramaInfo GetEntityObject(DataRow dr)
        {
            ProgramaInfo ProgramaInfo = new ProgramaInfo();

            ProgramaInfo.Id = Convert.ToInt32(dr[Entity.ProgramaInfo.FieldName.Id]);
            ProgramaInfo.Titulo = (dr[Entity.ProgramaInfo.FieldName.Titulo].ToString());
            ProgramaInfo.Descripcion = (dr[Entity.ProgramaInfo.FieldName.Descripcion].ToString()); 

            return ProgramaInfo;

        }


        ///<summary>
        ///Agrega un nuevo registro a la tabla
        ///</summary>
        /// <param name="ProgramaInfo">El objeto con los datos para la inserción</param>
        ///<return>
        ///Devuelve el Id del registro guardado
        ///</return>
        public int Insert(ProgramaInfo ProgramaInfo)
        {
            StringBuilder  sb = new StringBuilder();
            sb.AppendLine("declare @Id int");
            sb.AppendLine($"select @Id = fol_act from dbconf_bloq where des_bloq = {BookName}");
            sb.AppendLine($"insert into {TableName}(NUM_DOC,");
            sb.Append($"{Entity.ProgramaInfo.FieldName.Titulo}");
            sb.Append($"{Entity.ProgramaInfo.FieldName.Descripcion}");
            sb.AppendLine(")");
            sb.AppendLine("values(@Id,");
            sb.Append($"'{ProgramaInfo.Titulo}',");
            sb.Append($"'{ProgramaInfo.Descripcion}'");
            sb.Append(")");
            sb.AppendLine($"update dbconf_bloq set fol_act = fol_act + 1 where des_bloq = '{BookName}'");
            sb.AppendLine("SELECT SCOPE_IDENTITY()");

            object Id = Utilerias.SQLHelper.ExecuteScalar(sb.ToString(), ConnectionString);
            if (Id == null) return 0;
            return Convert.ToInt32(Id);
        }

        ///<summary>
        ///Actualiza un registro de la tabla
        ///<summary>
        /// <param name="ProgramaInfo">Objeto con los datos del registro para la actualización</param>
        ///<return>
        ///Devuelve el Id del registro que actualizó
        ///</return>
        public int Update(ProgramaInfo ProgramaInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"update {TableName} set");
            sb.Append($"{ProgramaInfo.FieldName.Titulo} = '{ProgramaInfo.Titulo}'");
            sb.Append($"{ProgramaInfo.FieldName.Descripcion} = '{ProgramaInfo.Descripcion}'");
            sb.AppendLine($"where {ProgramaInfo.FieldName.Id} = {ProgramaInfo.Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(),ConnectionString);  
            return ProgramaInfo.Id;

        }

        ///<summary>
        ///Elimina un registro de la tabLa.
        ///</summary>
        ///<return>
        ///</return>
        public void Delete(int Id)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"UPDATE {TableName} SET NUM_DOC = NUM_DOC * (-1)");
            sb.Append($" where {ProgramaInfo.FieldName.Id} = {Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(),ConnectionString);    
        }


        ///<summary>
        ///Busca los registro que cumplan con cierto filtro
        ///</summary>
        /// <param name="ProgramaInfo">
        /// Objeto con los datos para filtrar los datos de la tabla
        /// </param>
        ///<return>
        ///Devuelve una lista de objetos que cumplan con el filtro
        ///</return>
        public List<ProgramaInfo> FindBy(Entity.ProgramaInfo ProgramaInfo)
        {
            
            string Filter = string.Empty;
    
            Entity.ProgramaInfo nPrograma= new Entity.ProgramaInfo();

            if (string.Compare(ProgramaInfo.Titulo, nPrograma.Titulo, true) != 0)
                Filter += $" and {Entity.ProgramaInfo.FieldName.Titulo} =  '{nPrograma.Titulo}'";
            if (string.Compare(ProgramaInfo.Descripcion, nPrograma.Descripcion, true) != 0)
                Filter += $" and {Entity.ProgramaInfo.FieldName.Descripcion} = '{nPrograma.Descripcion}'";
            if (ProgramaInfo.Id != nPrograma.Id)
                Filter += $" and {Entity.ProgramaInfo.FieldName.Id} = {nPrograma.Id}";
            
            //Definición de setencia sql con filtro dinámico
            string SQLStatement = $"SELECT * FROM {TableName} where {ProgramaInfo.FieldName.Id} > 0"+Filter;
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SQLStatement, ConnectionString);

            if (dt == null || dt.Rows.Count == 0) return null;

            //Creamos una lista para guardar cada registro de cursos que viene en el datatable
            List<Entity.ProgramaInfo> ListaProgramas = new List<Entity.ProgramaInfo> ();
            foreach(DataRow dr in dt.Rows) 
               ListaProgramas.Add(GetEntityObject(dr));
               
            return ListaProgramas;
        }


        #endregion

    }
}
