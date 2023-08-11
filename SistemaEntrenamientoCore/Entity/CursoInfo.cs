using SOLTUM.Framework.Core;
using SOLTUM.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public class CursoInfo : IEntity
    {
        ///<summary>
        ///Campos que se van a utilizar para la base de datos
        ///</summary>
        ///<remarks>
        /// 
        ///</remarks>
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            [Field(Titulo, "Titulo", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Titulo = "titulo";
            [Field(Descripcion, "Descripcion", FieldAttribute.eFieldType.Texto, Length = 250)]
            public const string Descripcion = "descripcion";
            [Field(Nivel, "Nivel", FieldAttribute.eFieldType.Texto, Length = 50)]
            public const string Nivel = "nivel";
            [Field(Duracion, "Duracion", FieldAttribute.eFieldType.Numero)]
            public const string Duracion = "duracion";
  
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public string Nivel { get; set; }
        #endregion



    }
}
