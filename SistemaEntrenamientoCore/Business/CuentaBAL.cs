using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class CuentaBAL
    {
        #region Variables Globales...
        private CuentaDAL CuentaDAL;
        #endregion

        #region Constructor
        public CuentaBAL()
        {
            CuentaDAL = new CuentaDAL();
        }
        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return CuentaDAL.ConnectionString; }
            set { CuentaDAL.ConnectionString = value; }
        }
        #endregion

        #region Methods
        public CuentaInfo GetCuenta(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id de la cuenta a buscar");
            return CuentaDAL.GetEntityObject(Id);
        }

        /// <summary>
        /// Definición de método que regresa todoas las cuentas sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<CuentaInfo> GetCuentas()
        {
            return CuentaDAL.FindBy(new CuentaInfo());
        }

 
        /// <summary>
        /// Definicion de método que filtra los cuentas de acuerdo al parámetro filtro que se proporcione al método
        /// </summary>
        /// <param name="Cuenta">Objeto que tiene el filtro a aplicar</param>
        /// <returns>
        /// Una lista de objtos con los datos de cada registro encontrado de acuerdo al filtro
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<CuentaInfo> FindBy(CuentaInfo Cuenta)
        {
            if (Cuenta == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar el filtro");
            return CuentaDAL.FindBy(Cuenta);

        }

        /// <summary>
        /// Definición de método para el boton de guardar
        /// </summary>
        /// <param name="Cuenta">Objeto que tiene los datos de la cuenta que se va a guardar</param>
        /// <returns>
        /// Devuelve el Id del registro sobre el cual se realizó la operación de guardado o actualización
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int Save(CuentaInfo Cuenta)
        {
            if (Cuenta == null) throw new ArgumentNullException("No recibimos el objeto entidad para realizar la acción de guardar");
            if (Cuenta.Id == 0)
                return CuentaDAL.Insert(Cuenta);
            else
                return CuentaDAL.Update(Cuenta);

        }

        /// <summary>
        /// Definición de método para borrar una cuenta
        /// </summary>
        /// <param name="Id">Idenfiticador de la cuenta a eliminar</param>
        /// <returns>
        /// Si se borra el elemento sin problema devuelve true 
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Boolean Delete(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id de la cuenta a Eliminar");
            CuentaDAL.Delete(Id);
            return true;
        }

        #endregion
    }
}
