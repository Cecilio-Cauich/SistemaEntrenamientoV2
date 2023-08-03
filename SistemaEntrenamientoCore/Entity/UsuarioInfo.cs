using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public class UsuarioInfo
    {
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            public const string Usuario = "nombre_usuario";
            public const string Contrasenia = "contrasea";
            public const string Rol = "rol_id";
        }
        #endregion

        #region Properties
        public int Id { get; set; }  
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public int  Rol { get; set; }  

        #endregion
    }
}
