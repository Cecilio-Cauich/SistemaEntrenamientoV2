using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class CuentaDAL: SOLTUM.Framework.Data.BookBaseDAL<Entity.CuentaInfo, Entity.CuentaInfo.FieldName>
    {
        #region Constructor...
        public CuentaDAL() : base()
        { 
            BookName = "bCuenta";

        }
        #endregion

    }
}
