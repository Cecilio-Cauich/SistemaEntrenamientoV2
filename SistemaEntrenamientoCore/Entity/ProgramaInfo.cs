using SOLTUM.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public class ProgramaInfo: IEntity
    {
        #region Database FieldNames
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            [Field(Titulo, "Titulo", FieldAttribute.eFieldType.Texto, Length =50)]
            public const string Titulo = "titulo";
            [Field(Descripcion, "Descripcion", FieldAttribute.eFieldType.Texto, Length = 100)]
            public const string Descripcion = "descripcion";
        }
        #endregion

        #region Properties
        public int Id { get; set; }  
        public string Titulo { get; set; }
        public string Descripcion { get; set; } 
        #endregion

    }
}
