using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class UsuarioBAL: SOLTUM.Framework.Business.BookBaseBAL<Entity.UsuarioInfo, Entity.UsuarioInfo.FieldName, Data.UsuarioDAL>
    {

        #region Constructor
        public UsuarioBAL(): base()
        {
            Version  = "1.0.0.0";
        }
        #endregion

        #region Methods
        public UsuarioInfo GetUsuario(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del usuario a buscar");
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()
            {
                new SOLTUM.Framework.Data.Attributes.Condition(Entity.CuentaInfo.FieldName.Id, "=", Id.ToString())

            }).FirstOrDefault();
        }


        /// <summary>
        /// Definición de método que regresa todos los usuarios sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<UsuarioInfo> GetUsuarios()
        {
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()).ToList();
        }

        #endregion
    }
}
