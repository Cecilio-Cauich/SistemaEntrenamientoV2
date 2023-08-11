using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class RolBAL: SOLTUM.Framework.Business.BookBaseBAL<Entity.RolInfo, Entity.RolInfo.FieldName, Data.RolDAL>
    {
        public RolBAL(): base()
        {
            Version = "1.0.0.0";
        }

        #region Methods

        /// <summary>
        /// Busca un rol de acuerdo a un identificador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public RolInfo GetRol(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del Rol a buscar");
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()
            {
                new SOLTUM.Framework.Data.Attributes.Condition(Entity.RolInfo.FieldName.Id,"=",Id.ToString())
             }).FirstOrDefault();
    }


        /// <summary>
        /// Definición de método que regresa todos los roles sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<RolInfo> GetRoles()
        {
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()).ToList();

        }

        #endregion
    }
}
