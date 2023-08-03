using SistemaEntrenamientoCore.Business;
using SistemaEntrenamientoCore.Entity;
using SistemaEntrenamientoCore.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class CursoDAL
    {
        #region Global Variables...
        public const string BookName = "bCurso";
        public const string TableName = "dbENC76";

        #endregion

        #region Properties
        public string ConnectionString
        {
            get; set;
        }
        #endregion


        #region Methods...
        ///<summary>
        /// Busca un registro con el Id que se proporciona
        ///</summary>
        /// <param name="Id">Identificador del elemento a buscar</param>
        ///<return>
        ///Devuelve una entidad con los datos del registro que encontró.
        ///</return>
        public Entity.CursoInfo GetEntityObject(int Id)
        {
            string SqlStatement = $"select NUM_DOC,titulo,descripcion,duracion,nivel from {TableName} where {Entity.CursoInfo.FieldName.Id} = {Id}";
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SqlStatement, ConnectionString);
            if (dt == null || dt.Rows.Count == 0) throw new Exception($"No se encontraron registros con el id {Id}");
            return GetEntityObject(dt.Rows[0]);
        }


        /// <summary>
        /// Regresa un objeto con los datos recibidos en el DataRow
        /// </summary>
        /// <param name="dr">La fila de tabla table donde se toma los datos para formar un objeto</param>
        /// <returns>
        /// Un objeto con los datos del row
        /// </returns>
        private Entity.CursoInfo GetEntityObject(DataRow dr)
        {

            Entity.CursoInfo CursoInfo = new Entity.CursoInfo();
            CursoInfo.Id = Convert.ToInt32(dr[Entity.CursoInfo.FieldName.Id]);
            CursoInfo.Titulo = dr[Entity.CursoInfo.FieldName.Titulo].ToString();
            CursoInfo.Descripcion = dr[Entity.CursoInfo.FieldName.Descripcion].ToString();
            CursoInfo.Duracion = Convert.ToInt32(dr[Entity.CursoInfo.FieldName.Duracion]);
            CursoInfo.Nivel = dr[Entity.CursoInfo.FieldName.Nivel].ToString();

            return CursoInfo;
        }

        ///<summary>
        ///Agrega un nuevo registro a la tabla
        ///</summary>
        /// <param name="CursoInfo">El objeto con los datos para la inserción</param>
        ///<return>
        ///Devuelve el Id del registro guardado
        ///</return>
        public int Insert(Entity.CursoInfo CursoInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("declare @Id int");
            sb.AppendLine($"select @Id = fol_act from dbconf_bloq where des_bloq = '{BookName}'");
            sb.AppendLine($"insert into {TableName}(NUM_DOC,");
            sb.Append($"{Entity.CursoInfo.FieldName.Titulo}");
            sb.Append($",{Entity.CursoInfo.FieldName.Descripcion}");
            sb.Append($",{Entity.CursoInfo.FieldName.Nivel}");
            sb.Append($",{Entity.CursoInfo.FieldName.Duracion}");
            sb.AppendLine(")");
            sb.AppendLine("values(@Id");
            sb.Append($",'{CursoInfo.Titulo}'");
            sb.Append($",'{CursoInfo.Descripcion}'");
            sb.Append($",'{CursoInfo.Nivel}'");
            sb.Append($",{CursoInfo.Duracion}");
            sb.AppendLine(")");
            sb.AppendLine($"update dbconf_bloq set fol_act = fol_act + 1 where des_bloq = '{BookName}'");
            sb.AppendLine("SELECT SCOPE_IDENTITY()");

            object Id = Utilerias.SQLHelper.ExecuteScalar(sb.ToString(), ConnectionString);
            if (Id == null) return 0;
            return Convert.ToInt32(Id);
        }


        ///<summary>
        ///Actualiza un registro de la tabla
        ///<summary>
        /// <param name="CursoInfo">Objeto con los datos del registro para la actualización</param>
        ///<return>
        ///Devuelve el Id del registro que actualizó
        ///</return>
        public int Update(Entity.CursoInfo CursoInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"update {TableName} set");
            sb.Append($"{Entity.CursoInfo.FieldName.Titulo} = '{CursoInfo.Titulo}'");
            sb.Append($",{Entity.CursoInfo.FieldName.Descripcion} = '{CursoInfo.Descripcion}'");
            sb.Append($",{Entity.CursoInfo.FieldName.Nivel} = '{CursoInfo.Nivel}'");
            sb.Append($",{Entity.CursoInfo.FieldName.Duracion} = {CursoInfo.Duracion}");
            sb.Append($"where {Entity.CursoInfo.FieldName.Id} = {CursoInfo.Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);
            return CursoInfo.Id;
        }


        ///<summary>
        ///Elimina un registro de la tabLa.
        ///</summary>
        ///<return>
        ///</return>
        public void Delete(int Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"update {TableName} SET NUM_DOC = NUM_DOC * (-1)");
            sb.Append($" where {Entity.CursoInfo.FieldName.Id} ={Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);

        }

        ///<summary>
        ///Busca los registro que cumplan con cierto filtro
        ///</summary>
        /// <param name="CursoInfo">
        /// Objeto con los datos para filtrar los datos de la tabla
        /// </param>
        ///<return>
        ///Devuelve una lista de objetos que cumplan con el filtro
        ///</return>
        public List<CursoInfo> FindBy(Entity.CursoInfo CursoInfo)
        {
            string Filter = string.Empty;
            Entity.CursoInfo nCurso = new Entity.CursoInfo();

            //Se generó un nuevo objeto para comparar y detectar las variaciones
            if (string.Compare(CursoInfo.Titulo, nCurso.Titulo, true) != 0)
                Filter += $" and {Entity.CursoInfo.FieldName.Titulo} = '{CursoInfo.Titulo}'";
            if (string.Compare(CursoInfo.Descripcion, nCurso.Descripcion, true) != 0)
                Filter += $" and {Entity.CursoInfo.FieldName.Descripcion} = '{CursoInfo.Descripcion}'";
            if (CursoInfo.Id != nCurso.Id)
                Filter += $" and {Entity.CursoInfo.FieldName.Duracion} = {CursoInfo.Duracion}";
            if (string.Compare(CursoInfo.Nivel, nCurso.Nivel, true) != 0)
                Filter += $" and {CursoInfo.FieldName.Nivel} = '{CursoInfo.Nivel}'";

            //Definición de setencia sql con filtro dinámico
            string sql = $"select * from {TableName} where {Entity.CursoInfo.FieldName.Id} > 0 " + Filter;
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(sql, ConnectionString);

            if (dt == null || dt.Rows.Count == 0) return null;

            //Creamos una lista para guardar cada registro de cursos que viene en el datatable
            List<Entity.CursoInfo> ListCursos = new List<Entity.CursoInfo>();
            foreach (DataRow dr in dt.Rows)
                ListCursos.Add(GetEntityObject(dr));

            return ListCursos;

        } 
        /// <summary>
        /// Este métod permite ir a buscar cursos filtrando por el programa al que pertenece el curso
        /// Por lo tanto hace uso de 3 tablas que se creó en RAD
        /// </summary>
        /// <param name="filtro">Es el filtro o mejor dicho el nombre del programa con el que se va a filtrar
        /// los cursos
        /// </param>
        /// <returns>
        /// Una lista de entidades
        /// </returns>
        public List<CursoInfo> FindByCP(string filtro)
        {
            //Definición de setencia sql con filtro dinámico
            string SqlStatement = $"SELECT * FROM dbENC76 \r\ninner join dbENC77 \r\non dbENC76.curso_id = dbENC77.programa_curso_\r\ninner join dbENC72 on dbENC72.programa_id = dbENC77.programa_id  \r\nwhere  dbENC72.programa_id> 0 and lower(dbENC72.titulo) = lower('{filtro}')";
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SqlStatement, ConnectionString);

            if (dt == null || dt.Rows.Count == 0) return null;

            //Creamos una lista para guardar cada registro de cursos que viene en el datatable
            List<Entity.CursoInfo> ListCursos = new List<Entity.CursoInfo>();
            foreach (DataRow dr in dt.Rows)
                ListCursos.Add(GetEntityObject(dr));

            return ListCursos;

        }
        #endregion

    }
}