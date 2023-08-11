using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class ProgramaDAL: SOLTUM.Framework.Data.BookBaseDAL<Entity.ProgramaInfo, Entity.ProgramaInfo.FieldName>
    {
        #region Constructor...
        public ProgramaDAL() : base()
        {
            BookName = "bPrograma";
        }
        #endregion
    }
}
