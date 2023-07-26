using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoV2.Clases.EntityLayer
{
    public class CLS_CrudCursoInfo
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
            public string curso_id = "curso_id";
            public string titulo = "titulo";
            public string descripcion = "descripcion";
            public string duracion = "duracion";
            public string nivel = "nivel";
        }
        #endregion

        ///<summary>
        ///Propiedades de las campos declaradas anteriormente para poder acceder a ellos.
        ///</summary>
        ///<remarks>
        ///
        ///</remarks>
        #region properties
        public int curso_id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int duracion { get; set; }
        public string nivel { get; set; }
        #endregion



    }
}
