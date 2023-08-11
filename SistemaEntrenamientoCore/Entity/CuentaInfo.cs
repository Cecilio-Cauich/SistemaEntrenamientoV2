using SOLTUM.Framework.Core;
using SOLTUM.Framework.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public  class CuentaInfo: IEntity
    {
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            [Field(Nombres, "Nombres", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Nombres = "nombres";
            [Field(Apellidos, "Apellidos", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Apellidos = "apellidos";
            [Field(Email, "Email", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Email = "email";
            [Field(Genero, "Genero", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Genero = "genero";
            [Field(Fecha_Nacimiento, "Fecha de nacimiento", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Fecha_Nacimiento = "fecha_nacimient";
            [Field(Usuario_Id, "Id de usuario", FieldAttribute.eFieldType.Numero)]
            public const string Usuario_Id = "usuario_id";
        }
        #endregion

        #region Properties
        public int Id { get; set; }  
        public string Nombres { get; set; }
        public string Apellidos { get; set;}
        public string Email { get; set;}
        public string Genero { get; set;}
        public string Fecha_Nacimiento { get; set;} 
        public int Usuario_Id { get; set;}   
        #endregion
    }
}
