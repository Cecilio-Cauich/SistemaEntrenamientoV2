using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public class CursoInfo
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
            public const string Titulo = "titulo";
            public const string Descripcion = "descripcion";
            public const string Nivel = "nivel";
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
