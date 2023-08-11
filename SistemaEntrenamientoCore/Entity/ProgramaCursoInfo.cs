using SOLTUM.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Entity
{
    public  class ProgramaCursoInfo: IEntity
    {
        #region Database FieldName
        public class FieldName
        {
            public const string Id = "NUM_DOC";
            [Field(Programa, "Id de programa", FieldAttribute.eFieldType.Numero)]
            public const string Programa = "programa_id";
            [Field(Curso, "Id de curso", FieldAttribute.eFieldType.Numero)]
            public const string Curso = "curso_id";
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public int Programa { get; set;}
        public int Curso { get; set;}
        #endregion
    }
}
