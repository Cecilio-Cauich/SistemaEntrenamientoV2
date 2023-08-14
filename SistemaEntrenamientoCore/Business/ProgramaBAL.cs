using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Business
{
    public class ProgramaBAL: SOLTUM.Framework.Business.BookBaseBAL<Entity.ProgramaInfo, Entity.ProgramaInfo.FieldName, Data.ProgramaDAL>
    {

        #region Constructor
        public ProgramaBAL(): base()
        {

            Version = "1.0.0.0";
        }
        #endregion

        #region Methods

        /// <summary>
        /// Busca un program a partir de un identificador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ProgramaInfo GetPrograma(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No recibimos el Id del programa a buscar");
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()
            {
                new SOLTUM.Framework.Data.Attributes.Condition(Entity.CuentaInfo.FieldName.Id,"=",Id.ToString())
            }).FirstOrDefault();
        }

        /// <summary>
        /// Definición de método que regresa todos los programas sin apicar filtro alguno
        /// </summary>
        /// <returns>
        /// Una lista de objetos entidad
        /// </returns>
        public List<ProgramaInfo> GetProgramas()
        {
            return DataAccessLayer.GetEntityObjects(new List<SOLTUM.Framework.Data.Attributes.Condition>()).ToList();
        }

        #endregion


    }
}
