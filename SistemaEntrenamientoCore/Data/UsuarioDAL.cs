using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class UsuarioDAL: SOLTUM.Framework.Data.BookBaseDAL<Entity.UsuarioInfo, Entity.UsuarioInfo.FieldName>
    {
        #region Constructor
        public UsuarioDAL(): base()
        {
            BookName = "bUsuario";
        }
        #endregion


    }
}
