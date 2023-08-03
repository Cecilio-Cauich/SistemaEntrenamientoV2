using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class RolBAL
    {
        #region Variables Globales...
        private RolDAL RolDAL;
        #endregion

        #region Constructor
        public RolBAL()
        {
            RolDAL = new RolDAL();
        }
        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return RolDAL.ConnectionString; }
            set { RolDAL.ConnectionString = value; }
        }
        #endregion

        #region Methods
        public RolInfo GetRol(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del Rol a buscar");
            return RolDAL.GetEntityObject(Id);
        }


        /// <summary>
        /// Definición de método que regresa todos los roles sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<RolInfo> GetRoles()
        {
            return RolDAL.FindBy(new RolInfo());

        }


        /// <summary>
        /// Definicion de método que filtra los roles de acuerdo al parámetro filtro que se proporcione al método
        /// </summary>
        /// <param name="Rol">Objeto que tiene el filtro a aplicar</param>
        /// <returns>
        /// Una lista de objtos con los datos de cada registro encontrado de acuerdo al filtro
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<RolInfo> FindBy(RolInfo Rol)
        {
            if (Rol == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar el filtro");
            return RolDAL.FindBy(Rol);

        }


        /// <summary>
        /// Definición de método para el boton de guardar
        /// </summary>
        /// <param name="Rol">Objeto que tiene los datos del Rol que se va a guardar</param>
        /// <returns>
        /// Devuelve el Id del registro sobre el cual se realizó la operación de guardado o actualización
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int Save(RolInfo Rol)
        {
            if (Rol == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar la acción de guardar");
            if (Rol.Id == 0)
                return RolDAL.Insert(Rol);
            else
                return RolDAL.Update(Rol);

        }

        /// <summary>
        /// Definición de método para borrar un rol
        /// </summary>
        /// <param name="Id">Idenfiticador del rol a eliminar</param>
        /// <returns>
        /// Si se borra el elemento sin problema devuelve true 
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Boolean Delete(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del Rol a Eliminar");
            RolDAL.Delete(Id);
            return true;
        }

        #endregion
    }
}
