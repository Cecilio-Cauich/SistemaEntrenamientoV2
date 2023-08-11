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
    public class CursoDAL: SOLTUM.Framework.Data.BookBaseDAL<Entity.CursoInfo, Entity.CursoInfo>
    {
        #region Global Variables...
       // public const string BookName = "bCurso";
        public const string TableName = "dbENC76";

        #endregion

        #region Properties
        public new string ConnectionString
        {
            get; set;
        }
        #endregion


        #region Constructor...
        public CursoDAL() : base()
        {
            BookName = "bCurso";
        }
        #endregion


        #region Methods

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
            DataTable dt = SOLTUM.Framework.Utilities.SQLHelper.ExecuteDataTable(SqlStatement, ConnectionString);

            if (dt == null || dt.Rows.Count == 0) return null;

            //Creamos una lista para guardar cada registro de cursos que viene en el datatable
            List<Entity.CursoInfo> ListCursos = new List<Entity.CursoInfo>();
            foreach (DataRow dr in dt.Rows)
                ListCursos.Add(GetEntityObject(dr));

            return ListCursos;

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
        #endregion
    }
}