using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public class RolInfo
    {
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            public const string Nombre = "nombre";
        }
        #endregion

        #region Properties
        public int Id { get; set; }  
        public string Nombre { get; set;}
        #endregion 
    }
}
