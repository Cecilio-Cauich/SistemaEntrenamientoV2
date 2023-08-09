using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaEntrenamientoCore.Business;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Tests
{
    [TestClass]
    public class ProgramaCursoBALTests
    {
        #region GetProgramaCurso Tests...

        [TestMethod]
        ///Probamos que el método GetProgramaCurso retorna un objeto de tipo programa curso
        public void GetProgramaCurso_ShouldGetProgramaCurso()
        {
            //Arrange
            int IdToSearch = 1;
            ProgramaCursoBAL programaCursoBAL = new() { ConnectionString = getConnectionString() };
            //Act
            ProgramaCursoInfo Actual = programaCursoBAL.GetProgramaCurso(IdToSearch);
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(ProgramaCursoInfo), "No es uns relación programa curso");
        }


        [TestMethod]
        ///Probamos que el método GetProgramaCurso, pasandole un Id, retorna el registro que debe
        ///Lo verficamos con el programa_id que se retorna comparandolo con el programa_id de 
        ///entidad que tenemos para la prueba
        public void GetProgramaCurso_ShouldGetCountWithId()
        {

            //Arrange
            int IdToSearch = 2;
            ProgramaCursoInfo Expected = getExampleProgramaCurso();
            ProgramaCursoBAL ProgramaCursoBAL = new() { ConnectionString = getConnectionString() };
            //Act
            ProgramaCursoInfo Actual = ProgramaCursoBAL.GetProgramaCurso(IdToSearch);
            //Assert
            Assert.AreEqual(Expected.Programa, Actual.Programa, "No es la relacion programa curso esperado");

        }

        #endregion

        #region Save Tests...

        [TestMethod]
        ///Probamos que devuelva un dato tipo Int y que sea diferente de cero, si es igual a cero
        ///es porque no se guardó el registro
        public void Save_ShouldSaveANewProgramaCurso()
        {
            //Arrange
            ProgramaCursoBAL programaCursoBAL = new() { ConnectionString = getConnectionString() };
            //Act
            int Actual = programaCursoBAL.Save(getExampleProgramaCursoForInsertSave());
            //Assert
            Assert.AreNotEqual(Actual, 0, "Registro no guardado");
        }


        [TestMethod]
        ///Probamos que devuelva un Id igual al del programacurso que  mandamos a actualizar 
        public void Save_ShouldSaveTheProgramaCursoUpdate()
        {
            //Arrange
            ProgramaCursoInfo programacursoExample = getExampleProgramaCursoForUpdateSave();
            int Expected = programacursoExample.Id;
            ProgramaCursoBAL ProgramaCursoBAL = new() { ConnectionString = getConnectionString() };
            //Act
            int Actual = ProgramaCursoBAL.Save(programacursoExample);
            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        #endregion

        #region FindBy Tests

        [TestMethod]
        ///Probamos que retorne una lista de relación de programa curso de acuerdo al filtro 
        public void FindBy_ShouldFilterProgramaCursoByProgramaID()
        {
            //Arrange
            List<ProgramaCursoInfo> Actual;
            ProgramaCursoBAL programaCursoBAL = new() { ConnectionString = getConnectionString() };
            //Act
            Actual = programaCursoBAL.FindBy(getExampleProgramaCursoForFindBy());
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(List<ProgramaCursoInfo>), "No es una lista de realción de programa curso");
        }

        #endregion

        #region Data

        /// <summary>
        /// Nos devuelve una realcion de programa curso con datos definidos para prueba
        /// Se usa para el método GetProgramaCurso_ShouldGetCountWithId
        /// </summary>
        /// <returns></returns>
        private ProgramaCursoInfo getExampleProgramaCurso()
        {
            return new ProgramaCursoInfo()
            {
                Id = 2,
                Programa = 1,
                Curso = 2
            };

        }

        /// <summary>
        /// Nos devuelve una relacion de programa curso con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere insertar un nuevo
        /// elemento en la tabla programa curso
        /// </summary>
        /// <returns></returns>
        private ProgramaCursoInfo getExampleProgramaCursoForInsertSave()
        {
            return new ProgramaCursoInfo()
            {
                Programa = 2,
                Curso = 5
            };

        }

        /// <summary>
        /// Nos devuelve una relación de programa curso con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere actualizar un nuevo
        /// elemento en la tabla programa curso
        /// </summary>
        /// <returns></returns>
        private ProgramaCursoInfo getExampleProgramaCursoForUpdateSave()
        {
            return new ProgramaCursoInfo()
            {
                Id = 1,
                Programa = 1,
                Curso = 4
                //Curso = 1
            };

        }
        /// <summary>
        /// Nos devuelve una relacion de programa curso con una propiedad nada más, esta propiedad se usará para filtrar las cuentas
        /// Se usa en el método FindBy_ShouldFilterProgramaCursoByPrograma
        /// </summary>
        /// <returns></returns>
        private ProgramaCursoInfo getExampleProgramaCursoForFindBy()
        {
            return new ProgramaCursoInfo() { Programa = 1 };
        }

        /// <summary>
        /// Aquí se define la cadena de conexión para la base de datos
        /// </summary>
        /// <returns></returns>
        private string getConnectionString()
        {
            return "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=DbSOLT1129_e;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";

        }

        #endregion
    }
}
