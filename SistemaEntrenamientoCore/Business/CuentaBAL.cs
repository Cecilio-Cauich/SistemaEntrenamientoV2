using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class CuentaBAL: SOLTUM.Framework.Business.BookBaseBAL<Entity.CuentaInfo, Entity.CuentaInfo.FieldName, Data.CuentaDAL>
    {

        #region Constructor
        public CuentaBAL(): base() 
        {
            Version = "1.0.0.0";
        }
        #endregion

        #region Methods

        /// <summary>
        /// Busca una cuenta a partir de un identificador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public CuentaInfo GetCuenta(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id de la cuenta a buscar");
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>() 
            { 
                new SOLTUM.Framework.Data.Attributes.Condition(Entity.CuentaInfo.FieldName.Id, "=", Id.ToString())

            }).FirstOrDefault();
        }

        /// <summary>
        /// Regresa todoas las cuentas sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<CuentaInfo> GetCuentas()
        {
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()).ToList();
        }


        #endregion
    }
}
