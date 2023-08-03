using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class ProgramaCursoBAL
    {
        #region Variables Globales...
        private ProgramaCursoDAL ProgramaCursoDAL;
        #endregion

        #region Constructor
        public ProgramaCursoBAL()
        {
            ProgramaCursoDAL = new ProgramaCursoDAL();
        }
        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return ProgramaCursoDAL.ConnectionString; }
            set { ProgramaCursoDAL.ConnectionString = value; }
        }
        #endregion

        #region Methods
        public ProgramaCursoInfo GetProgramaCurso(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del programacurso a buscar");
            return ProgramaCursoDAL.GetEntityObject(Id);
        }


        /// <summary>
        /// Definición de método que regresa todos los programascursos sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<ProgramaCursoInfo> GetProgramasCursos()
        {
            return ProgramaCursoDAL.FindBy(new ProgramaCursoInfo());
            
        }


        /// <summary>
        /// Definicion de método que filtra los programacurso de acuerdo al parámetro filtro que se proporcione al método
        /// </summary>
        /// <param name="ProgramaCurso">Objeto que tiene el filtro a aplicar</param>
        /// <returns>
        /// Una lista de objtos con los datos de cada registro encontrado de acuerdo al filtro
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<ProgramaCursoInfo> FindBy(ProgramaCursoInfo ProgramaCurso)
        {
            if (ProgramaCurso == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar el filtro");
            return ProgramaCursoDAL.FindBy(ProgramaCurso);

        }


        /// <summary>
        /// Definición de método para el boton de guardar
        /// </summary>
        /// <param name="ProgramaCurso">Objeto que tiene los datos del ProgramaCurso que se va a guardar</param>
        /// <returns>
        /// Devuelve el Id del registro sobre el cual se realizó la operación de guardado o actualización
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int Save(ProgramaCursoInfo ProgramaCurso)
        {
            if (ProgramaCurso == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar la acción de guardar");
            if (ProgramaCurso.Id == 0)
                return ProgramaCursoDAL.Insert(ProgramaCurso);
            else
                return ProgramaCursoDAL.Update(ProgramaCurso);

        }

        /// <summary>
        /// Definición de método para borrar un programacurso
        /// </summary>
        /// <param name="Id">Idenfiticador del programacurso a eliminar</param>
        /// <returns>
        /// Si se borra el elemento sin problema devuelve true 
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Boolean Delete(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del programacurso a Eliminar");
            ProgramaCursoDAL.Delete(Id);
            return true;
        }

        #endregion
    }
}
