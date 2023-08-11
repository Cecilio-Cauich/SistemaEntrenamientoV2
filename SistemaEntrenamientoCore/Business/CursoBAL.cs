using DocumentFormat.OpenXml.Drawing.Charts;
using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace SistemaEntrenamientoCore.Business
{
    /// <summary>
    /// Definicion de clase que permite exponer métodos de negocios para los cursos
    /// </summary>
    public class CursoBAL: SOLTUM.Framework.Business.BookBaseBAL<Entity.CursoInfo, Entity.CursoInfo.FieldName, Data.CursoDAL>
    {
        #region Variables globales...
        private CursoDAL cursoDAL;
        #endregion
        #region Properties...
        public new string ConnectionString
        {
            get { return cursoDAL.ConnectionString; }
            set { cursoDAL.ConnectionString = value; }
        }
        #endregion

        #region Constructor
        public CursoBAL(): base()
        {

            Version = "1.0.0.0"; 

            cursoDAL = new CursoDAL();  
        }
        #endregion



        #region Methods
        /// <summary>
        /// Busca un curso a partir de un identificador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public CursoInfo GetCurso(int Id)
        {
            if(Id == 0) throw new ArgumentNullException("No recibimos el Id del curso a buscar");
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()
            {
                new SOLTUM.Framework.Data.Attributes.Condition(Entity.CuentaInfo.FieldName.Id,"=",Id.ToString())

            }).FirstOrDefault();
        }

        /// <summary>
        /// Regresa todos los cursos sin apicar filtro alguno
        /// </summary>
        /// <returns></returns>
        public List<CursoInfo> GetCursos()
        {
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()).ToList();   
        }

        /// <summary>
        /// Definición de método que busca cursos por nivel 
        /// </summary>
        /// <param name="Nivel">Es el filtro con el que va a trabajar el método</param>
        /// <returns>
        /// Rgresas una lista de objetos con datos de cada registro 
        /// </returns>
        public List<CursoInfo> GetCursosPorPrograma(string Programa)
        {
            if (Programa == null) throw new ArgumentNullException("No recibimos el programa para filtrar");
            return cursoDAL.FindByCP(Programa);

        }
        #endregion


    }
}
