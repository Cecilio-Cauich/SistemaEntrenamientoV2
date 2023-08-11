using SOLTUM.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public class RolInfo: IEntity 
    {
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            [Field(Nombre, "Nombre de rol", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Nombre = "nombre";
        }
        #endregion

        #region Properties
        public int Id { get; set; }  
        public string Nombre { get; set;}
        #endregion 
    }
}
