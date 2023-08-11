using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class ProgramaCursoDAL: SOLTUM.Framework.Data.BookBaseDAL<Entity.ProgramaCursoInfo, Entity.ProgramaCursoInfo>  
    {
        #region Construcor...
        public ProgramaCursoDAL(): base()
        {
            BookName = "bProgramaCurso";
        }
        #endregion

    }
}
