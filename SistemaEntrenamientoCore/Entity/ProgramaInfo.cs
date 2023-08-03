using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public class ProgramaInfo
    {
        #region Database FieldNames
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            public const string Titulo = "Titulo";
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
