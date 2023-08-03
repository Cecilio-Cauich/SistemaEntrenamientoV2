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
    public class CursoBAL
    {
        #region Variables Globales...
        private CursoDAL CursoDAL;
        #endregion

        #region Constructor
        public CursoBAL()
        {
            CursoDAL = new CursoDAL(); 
        }
        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return CursoDAL.ConnectionString; }
            set { CursoDAL.ConnectionString = value; }
        }
        #endregion

        #region Methods
        public CursoInfo GetCurso(int Id)
        {
            if(Id == 0) throw new ArgumentNullException("No recibimos el Id del curso a buscar");
            return CursoDAL.GetEntityObject(Id);
        }

        /// <summary>
        /// Definición de método que regresa todos los cursos sin apicar filtro alguno
        /// </summary>
        /// <returns></returns>
        public List<CursoInfo> GetCursos()
        {
            return CursoDAL.FindBy(new CursoInfo());
        }

        /// <summary>
        /// Definición de método que busca cursos por nivel 
        /// </summary>
        /// <param name="Nivel">Es el filtro con el que va a trabajar el método</param>
        /// <returns>
        /// Rgresas una lista de objetos con datos de cada registro 
        /// </returns>
        public List<CursoInfo> GetCursosPorPrograma(string Nivel)
        {
            if (Nivel == null) throw new ArgumentNullException("No recibimos el nivel para filtrar");
            return CursoDAL.FindByCP(Nivel);

        }
        /// <summary>
        /// Definicion de método que filtra los curso de acuerdo al parámetro filtro que se proporcione al método
        /// </summary>
        /// <param name="Curso">Objeto que tiene el filtro a aplicar</param>
        /// <returns>
        /// Una lista de objtos con los datos de cada registro encontrado de acuerdo al filtro
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<CursoInfo> FindBy(CursoInfo Curso)
        {
            if (Curso == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar el filtro");
            return CursoDAL.FindBy(Curso);

        }

        /// <summary>
        /// Definición de método para el boton de guardar
        /// </summary>
        /// <param name="Curso">Objeto con los datso para guardar</param>
        /// <returns>
        /// Devuelve el Id del registro sobre el cual se realizó la operación
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int Save(CursoInfo Curso)
        {
            if (Curso == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar la acción de guardar");
           if (Curso.Id == 0)
                return CursoDAL.Insert(Curso);
           else
                return CursoDAL.Update(Curso);
            
        }

        /// <summary>
        /// Definición de método para borrar un curso
        /// </summary>
        /// <param name="Id">Idenficador del Curso a eliminar</param>
        /// <returns>
        /// Si se borra el elemento sin problema devuelve true 
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Boolean Delete(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del curso a Eliminar");
            CursoDAL.Delete(Id);
            return true;
        }

        #endregion


    }
}
