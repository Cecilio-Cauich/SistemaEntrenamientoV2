using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public  class ProgramaCursoInfo
    {
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            public const string programa = "programa_id";
            public const string curso = "curso_id";
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public int Programa { get; set;}
        public int Curso { get; set;}
        #endregion
    }
}
