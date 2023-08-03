using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class RolDAL
    {
        #region Global Variables 
        private string BookName = "bRol";
        private string TableName = "dbENC75";
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
        public Entity.RolInfo GetEntityObject(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No se recibió el Id");

            string SqlStatement = $"SELECT nombre FROM {TableName} where {Entity.RolInfo.FieldName.Id}= {Id}";
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SqlStatement, ConnectionString);
            return GetEntityObject(dt.Rows[0]);
        }

        /// <summary>
        /// Regresa un objeto entidad con los datos recibidos del  DataRow
        /// </summary>
        /// <param name="dr">La fila de tabla table donde se toma los datos para formar un objeto</param>
        /// <returns>
        /// Un objeto con los datos del row
        /// </returns>
        public Entity.RolInfo GetEntityObject(DataRow dr)
        {
            RolInfo RolInfo = new RolInfo();
            RolInfo.Id = Convert.ToInt32(dr[Entity.RolInfo.FieldName.Id]);
            RolInfo.Nombre = (dr[Entity.RolInfo.FieldName.Nombre].ToString());
            return RolInfo;
        }


        ///<summary>
        ///Agrega un nuevo registro a la tabla
        ///</summary>
        /// <param name="RolInfo">El objeto con los datos para la inserción</param>
        ///<return>
        ///Devuelve el I
        public int Insert(RolInfo RolInfo)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"declare @Id");
            sb.AppendLine($"select @Id = fol_act from dbconf_bloq where des_bloq = {BookName}");
            sb.AppendLine($"INSERT INTO {TableName}(NUM_DOC,");
            sb.Append($"{RolInfo.FieldName.Nombre},");
            sb.AppendLine(")");
            sb.AppendLine("values(@Id,");
            sb.Append($"{RolInfo.Nombre},");
            sb.Append(")");
            sb.AppendLine($"update dbconf_bloq set fol_act = fol_act + 1 where des_bloq = '{BookName}'");
            sb.AppendLine("SELECT SCOPE_IDENTITY()");


            Object Id = Utilerias.SQLHelper.ExecuteScalar(sb.ToString(), ConnectionString);
            if (Id == null) return 0;
            return Convert.ToInt32(Id);
        }


        ///<summary>
        ///Actualiza un registro de la tabla
        ///<summary>
        /// <param name="RolInfo">Objeto con los datos del registro para la actualización</param>
        ///<return>
        ///Devuelve el Id del registro que actualizó
        ///</return>
        public int Update(RolInfo RolInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"UPDATE {TableName} SET(");
            sb.Append($"{RolInfo.FieldName.Nombre} = {RolInfo.Nombre}");
            sb.Append($"Where {RolInfo.FieldName.Id} = {RolInfo.Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);
            return RolInfo.Id;
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
            sb.Append($"where {RolInfo.FieldName.Id} = {Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);
        }

        ///<summary>
        ///Busca los registro que cumplan con cierto filtro
        ///</summary>
        /// <param name="RolInfo">
        /// Objeto con los datos para filtrar los datos de la tabla
        /// </param>
        ///<return>
        ///Devuelve una lista de objetos que cumplan con el filtro
        ///</return>
        public List<RolInfo> FindBy(RolInfo RolInfo)
        {
            string Filter = string.Empty;
            Entity.RolInfo nRol = new Entity.RolInfo();

            if (string.Compare(RolInfo.Nombre, nRol.Nombre, true) != 0)
                Filter += $" and {Entity.RolInfo.FieldName.Nombre} = {RolInfo.Nombre}";
            if (RolInfo.Id != nRol.Id)
                Filter += $" and {Entity.RolInfo.FieldName.Id} = {RolInfo.Id}";

            //Definición de setencia sql con filtro dinámico
            string SQLStatement = $"SELECT * FROM {TableName} where {Entity.RolInfo.FieldName.Id} > 0" + Filter;
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SQLStatement, ConnectionString);

            if (dt == null || dt.Rows.Count == 0) return null;

            //Creamos una lista para guardar cada registro de cursos que viene en el datatable
            List<RolInfo> ListRoles = new List<RolInfo>();
            foreach (DataRow dr in dt.Rows)
                ListRoles.Add(GetEntityObject(dr));


            return ListRoles;
        }
        #endregion

    }

}

