using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class UsuarioBAL
    {
        #region Variables Globales...
        private UsuarioDAL UsuarioDAL;
        #endregion

        #region Constructor
        public UsuarioBAL()
        {
            UsuarioDAL = new UsuarioDAL();
        }
        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return UsuarioDAL.ConnectionString; }
            set { UsuarioDAL.ConnectionString = value; }
        }
        #endregion

        #region Methods
        public UsuarioInfo GetUsuario(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del usuario a buscar");
            return UsuarioDAL.GetEntityObject(Id);
        }


        /// <summary>
        /// Definición de método que regresa todos los usuarios sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<UsuarioInfo> GetUsuarios()
        {
            return UsuarioDAL.FindBy(new UsuarioInfo());
        }


        /// <summary>
        /// Definicion de método que filtra los usuarios de acuerdo al parámetro filtro que se proporcione al método
        /// </summary>
        /// <param name="Usuario">Objeto que tiene el filtro a aplicar</param>
        /// <returns>
        /// Una lista de objtos con los datos de cada registro encontrado de acuerdo al filtro
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<UsuarioInfo> FindBy(UsuarioInfo Usuario)
        {
            if (Usuario == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar el filtro");
            return UsuarioDAL.FindBy(Usuario);

        }


        /// <summary>
        /// Definición de método para el boton de guardar
        /// </summary>
        /// <param name="Usuario">Objeto que tiene los datos del usuario que se va a guardar</param>
        /// <returns>
        /// Devuelve el Id del registro sobre el cual se realizó la operación de guardado o actualización
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int Save(UsuarioInfo Usuario)
        {
            if (Usuario == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar la acción de guardar");
            if (Usuario.Id == 0)
                return UsuarioDAL.Insert(Usuario);
            else
                return UsuarioDAL.Update(Usuario);

        }

        /// <summary>
        /// Definición de método para borrar un usuario
        /// </summary>
        /// <param name="Id">Idenfiticador del usuario a eliminar</param>
        /// <returns>
        /// Si se borra el elemento sin problema devuelve true 
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Boolean Delete(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del Usuario a Eliminar");
            UsuarioDAL.Delete(Id);
            return true;
        }

        #endregion
    }
}
