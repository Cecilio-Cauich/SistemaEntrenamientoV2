using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public  class CuentaInfo
    {
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            public const string Nombres = "nombres";
            public const string Apellidos = "apellidos";
            public const string Email = "email";
            public const string Genero = "genero";
            public const string Fecha_Nacimiento = "fecha_nacimiento";
            public const string Usuario_Id = "usuario_id";
        }
        #endregion

        #region Properties
        public int Id { get; set; }  
        public string Nombres { get; set; }
        public string Apellidos { get; set;}
        public string Email { get; set;}
        public string Genero { get; set;}
        public DateTime  Fecha_Nacimiento { get; set;} 
        public int Usuario_Id { get; set;}   
        #endregion
    }
}
