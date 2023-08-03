using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class ProgramaCursoDAL
    {
        #region Global Variables 
        private string BookName = "bProgramaCurso";
        private string TableName = "dbENC77";
        #endregion
        #region Properties
        public string ConnectionString
        {
            get;set;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Busca un registro con el Id que se proporciona
        /// </summary>
        /// <param name="Id">Identificador del elemento a buscar</param>
        /// <returns>
        /// Regresa un entidad con los datos del registro que encontró
        /// </returns>
        public Entity.ProgramaCursoInfo GetEntityObject(int Id)
        {

            string SqlStatement = $"SELECT NUM_DOC,programa_id, curso_id,  FROM {TableName} where {Entity.ProgramaCursoInfo.FieldName.Id}= {Id}";
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SqlStatement, ConnectionString);
            return GetEntityObject(dt.Rows[0]);
        }


        /// <summary>
        /// Regresa un objeto entidad con los datos recibidos del DataRow
        /// </summary>
        /// <param name="dr">La fila de tabla table donde se toma los datos para formar un objeto</param>
        /// <returns>
        /// Un objeto con los datos del row
        /// </returns>
    
        public Entity.ProgramaCursoInfo GetEntityObject(DataRow dr) 
        {
            ProgramaCursoInfo ProgramaCursoInfo = new ProgramaCursoInfo();
            ProgramaCursoInfo.Id = Convert.ToInt32(dr[Entity.ProgramaCursoInfo.FieldName.Id]);   
            ProgramaCursoInfo.Curso = Convert.ToInt32(dr[Entity.ProgramaCursoInfo.FieldName.curso]);
            ProgramaCursoInfo.Programa = Convert.ToInt32(dr[Entity.ProgramaCursoInfo.FieldName.programa]);
            return ProgramaCursoInfo;   
        }


        /// <summary>
        ///Agrega un nuevo registro a la tabla
        /// </summary>
        /// <param name="ProgramCursoInfo">El objeto con los datos para la inserción</param>
        /// <returns>
        /// Id del elemento insertado
        /// </returns>
        public int Insert(ProgramaCursoInfo ProgramCursoInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"declare @Id");
            sb.AppendLine($"select @Id = fol_act from dbconf_bloq where des_bloq = {BookName}");
            sb.AppendLine($"INSERT INTO {TableName}(NUM_DOC,");
            sb.Append($"{ProgramaCursoInfo.FieldName.curso},");
            sb.Append($"{ProgramaCursoInfo.FieldName.programa}");
            sb.AppendLine(")");
            sb.AppendLine("values(@Id,");
            sb.Append($"{ProgramCursoInfo.Curso},");
            sb.Append($"{ProgramCursoInfo.Programa}");
            sb.Append(")");
            sb.AppendLine($"update dbconf_bloq set fol_act = fol_act + 1 where des_bloq = '{BookName}'");
            sb.AppendLine("SELECT SCOPE_IDENTITY()");


            Object Id = Utilerias.SQLHelper.ExecuteScalar(sb.ToString(), ConnectionString);
            if (Id == null) return 0;
            return Convert.ToInt32(Id);
        }


        /// <summary>
        ///Actualiza un registro de la tabla
        /// </summary>
        /// <param name="ProgramaCursoInfo">Objeto con los datos del registro para la actualización</param>
        /// <returns>
        /// Devuelve el Id del registro que actualizó
        /// </returns>
        public int Update(ProgramaCursoInfo ProgramaCursoInfo)
        {
            StringBuilder   sb = new StringBuilder();
            sb.AppendLine($"UPDATE {TableName} SET(");
            sb.Append($"{ProgramaCursoInfo.FieldName.curso} = {ProgramaCursoInfo.Curso}");
            sb.Append($"{ProgramaCursoInfo.FieldName.programa} = {ProgramaCursoInfo.Programa}");
            sb.Append($"Where {ProgramaCursoInfo.FieldName.Id} = {ProgramaCursoInfo.Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);
            return ProgramaCursoInfo.Id;
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
           sb.Append($"where {ProgramaCursoInfo.FieldName.Id} = {Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(),ConnectionString);
        }

        /// <summary>
        /// Definicion de método que permite filtrar 
        /// </summary>
        /// <param name="CursoProgramaInfo">
        /// Objeto con los datos para filtrar los datos de la tabla 
        /// </param>
        /// <returns>
        /// Una lista de elementos de acuerdo al filtro aplicado
        /// </returns>
        public List<ProgramaCursoInfo> FindBy(ProgramaCursoInfo CursoProgramaInfo)
        {

            string Filter = string.Empty;
            Entity.ProgramaCursoInfo nCursoPrograma = new ProgramaCursoInfo();

            if (CursoProgramaInfo.Programa != nCursoPrograma.Programa)
                Filter += $" and {Entity.ProgramaCursoInfo.FieldName.programa} = {CursoProgramaInfo.Programa}";
            if (CursoProgramaInfo.Curso != nCursoPrograma.Curso)
                Filter += $" and {Entity.ProgramaCursoInfo.FieldName.curso} = {CursoProgramaInfo.Curso}";
            if (CursoProgramaInfo.Id != nCursoPrograma.Id)
                Filter += $" and {Entity.ProgramaCursoInfo.FieldName.Id} = {CursoProgramaInfo.Id}";

            //Definición de setencia sql con filtro dinámico
            string SQLStatement = $"SELECT * FROM {TableName} where {Entity.ProgramaCursoInfo.FieldName.Id} > 0" + Filter;
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SQLStatement,ConnectionString); 

            if(dt == null || dt.Rows.Count == 0) return null;

            //Creamos una lista para guardar cada registro de cursos que viene en el datatable
            List<ProgramaCursoInfo> ListCursosProgramas = new List<ProgramaCursoInfo> ();
            foreach(DataRow dr in dt.Rows)  
                 ListCursosProgramas.Add(GetEntityObject(dr));
            

            return ListCursosProgramas;

        }
        #endregion

    }
}
