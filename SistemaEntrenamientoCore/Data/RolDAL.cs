using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class RolDAL: SOLTUM.Framework.Data.BookBaseDAL<Entity.RolInfo, Entity.RolInfo.FieldName>
    {

        #region Constructor
        public RolDAL(): base()
        {
            BookName = "bRol";
        }
        #endregion

    }

}

