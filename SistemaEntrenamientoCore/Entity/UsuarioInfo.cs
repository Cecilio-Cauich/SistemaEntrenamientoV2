using SOLTUM.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public class UsuarioInfo : IEntity
    {
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            [Field(Usuario,"Nombre de usuario", FieldAttribute.eFieldType.Texto, Length = 50 )]
            public const string Usuario = "nombre_usuario";
            [Field(Contrasenia, "Contraseña", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Contrasenia = "contrasea";
            [Field(Rol, "Id de rol", FieldAttribute.eFieldType.Texto, Length =50)]
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
