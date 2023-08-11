using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class ProgramaCursoBAL: SOLTUM.Framework.Business.BookBaseBAL<Entity.ProgramaCursoInfo, Entity.ProgramaCursoInfo.FieldName, Data.ProgramaCursoDAL>
    {
  

        #region Constructor
        public ProgramaCursoBAL(): base()
        {
            Version = "1.0.0.0";
        }
        #endregion


        #region Methods

        /// <summary>
        /// Busca una relacion de programa curso a partir de un identificador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ProgramaCursoInfo GetProgramaCurso(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del programacurso a buscar");
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()
            {
                new SOLTUM.Framework.Data.Attributes.Condition(Entity.CuentaInfo.FieldName.Id,"=",Id.ToString())
            }).FirstOrDefault();
        }


        /// <summary>
        /// Definición de método que regresa todos los programascursos sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<ProgramaCursoInfo> GetProgramasCursos()
        {
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()).ToList();
            
        }

        #endregion
    }
}
