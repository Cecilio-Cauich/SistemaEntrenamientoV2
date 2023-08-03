using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class ProgramaBAL
    {
        #region Variables Globales...
        private ProgramaDAL ProgramaDAL;
        #endregion

        #region Constructor
        public ProgramaBAL()
        {
            ProgramaDAL = new ProgramaDAL();
        }
        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return ProgramaDAL.ConnectionString; }
            set {ProgramaDAL.ConnectionString = value; }
        }
        #endregion

        #region Methods
        public ProgramaInfo GetPrograma(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del programa a buscar");
            return ProgramaDAL.GetEntityObject(Id);
        }

        /// <summary>
        /// Definición de método que regresa todos los programas sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<ProgramaInfo> GetProgramas()
        {
            List<ProgramaInfo> Programas = ProgramaDAL.FindBy(new ProgramaInfo()); ///Excepcion Null reference 
            return Programas;
        }


        /// <summary>
        /// Definicion de método que filtra los programas de acuerdo al parámetro filtro que se proporcione al método
        /// </summary>
        /// <param name="Programa">Objeto que tiene el filtro a aplicar</param>
        /// <returns>
        /// Una lista de objtos con los datos de cada registro encontrado de acuerdo al filtro
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<ProgramaInfo> FindBy(ProgramaInfo Programa)
        {
            if (Programa == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar el filtro");
            return ProgramaDAL.FindBy(Programa);

        }

        /// <summary>
        /// Definición de método para el boton de guardar
        /// </summary>
        /// <param name="Programa">Objeto que tiene los datos de la cuenta que se va a guardar</param>
        /// <returns>
        /// Devuelve el Id del registro sobre el cual se realizó la operación de guardado o actualización
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int Save(ProgramaInfo Programa)
        {
            if (Programa == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar la acción de guardar");
            if (Programa.Id == 0)
                return ProgramaDAL.Insert(Programa);
            else
                return ProgramaDAL.Update(Programa);

        }

        /// <summary>
        /// Definición de método para borrar un programa
        /// </summary>
        /// <param name="Id">Idenfiticador del programa a eliminar</param>
        /// <returns>
        /// Si se borra el elemento sin problema devuelve true 
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Boolean Delete(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id de la cuenta a Eliminar");
            ProgramaDAL.Delete(Id);
            return true;
        }

        #endregion


    }
}
