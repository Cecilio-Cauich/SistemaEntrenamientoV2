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
    public class ProgramaBALTests
    {
        #region GetPrograma Tests...

        [TestMethod]
        ///Probamos que el método GetPrograma retorna un objeto de tipo Programa
        public void GetPrograma_ShouldGetProgram()
        {
            //Arrange
            int IdToSearch = 4;
            ProgramaBAL programaBAL = new () { ConnectionString = getConnectionString() };
            //Act
            ProgramaInfo Actual = programaBAL.GetPrograma(IdToSearch);
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(ProgramaInfo), "No es un programa");
        }


        [TestMethod]
        ///Probamos que el método GetPrograma, pasandole un Id, retorna el registro de que debe
        ///Lo verficamos con el titulo de la cuenta que se retorna comparandolo el titulo de una cuenta
        ///creada que tiene la prueba
        public void GetPrograma_ShouldGetCountWithId()
        {

            //Arrange
            int IdToSearch = 8;
            ProgramaInfo Expected = getExampleProgram();
            ProgramaBAL ProgramaBAL = new() { ConnectionString = getConnectionString() };
            //Act
            ProgramaInfo Actual = ProgramaBAL.GetPrograma(IdToSearch);
            //Assert
            Assert.AreEqual(Expected.Titulo, Actual.Titulo, "No es el programa esperado");

        }

        #endregion

        #region Save Tests...

        [TestMethod]
        ///Probamos que devuelva un dato tipo Int y que sea diferente de cero, si es igual a cero
        ///es porque no se guardó el registro
        public void Save_ShouldSaveANewProgram()
        {
            //Arrange
            ProgramaBAL programaBAL = new ProgramaBAL() { ConnectionString = getConnectionString() };
            //Act
            int Actual = programaBAL.Save(getExampleProgramForInsertSave());
            //Assert
            Assert.AreNotEqual(Actual, 0, "Registro no guardado");
        }


        [TestMethod]
        ///Probamos que devuelva un Id igual al del programa que mandamos a actualizar 
        public void Save_ShouldSaveTheProgramUpdate()
        {
            //Arrange
            ProgramaInfo programExample = getExampleProgramForUpdateSave();
            int Expected = programExample.Id;
            ProgramaBAL programaBAL = new () { ConnectionString = getConnectionString() };
            //Act
            int Actual = programaBAL.Save(programExample);
            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        #endregion

        #region FindBy Tests

        [TestMethod]
        ///Probamos que retorne una lista de programas de acuerdo al filtro 
        public void FindBy_ShouldFilterAccountByTitle()
        {
            //Arrange
            List<ProgramaInfo> Actual;
            ProgramaBAL programaBAL = new () { ConnectionString = getConnectionString() };
            //Act
            Actual = programaBAL.FindBy(getExampleProgramForFindBy());
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(List<ProgramaInfo>), "No es una lista de programas");
        }

        #endregion

        #region Data

        /// <summary>
        /// Nos devuelve un programa con datos definidos para prueba
        /// Se usa para el método GetPrograma_ShouldGetProgramWithId
        /// </summary>
        /// <returns></returns>
        private ProgramaInfo getExampleProgram()
        {
            return new ProgramaInfo()
            {
                Id = 8,
                Titulo = "Desarrollo con Java",
                Descripcion = "En este programa aprenderás sobre java",
            };

        }

        /// <summary>
        /// Nos devuelve un programa con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere insertar un nuevo
        /// elemento en la tabla programa
        /// </summary>
        /// <returns></returns>
        private ProgramaInfo getExampleProgramForInsertSave()
        {
            return new ProgramaInfo()
            {
                Titulo = "Programa Demo",
                Descripcion = "Este programa tiene la finalidad de",

            };

        }

        /// <summary>
        /// Nos devuelve un programa con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere actualizar un nuevo
        /// elemento en la tabla programa
        /// </summary>
        /// <returns></returns>
        private ProgramaInfo getExampleProgramForUpdateSave()
        {
            return new ProgramaInfo()
            {
                Id = 9,
                Titulo = "Programa Demo Actualizado",
                Descripcion = "Este programa tiene la finalidad de",
            };

        }
        /// <summary>
        /// Nos devuelve un programa con una propiedad nada más, esta propiedad se usará para filtrar las cuentas
        /// Se usa en el método FindBy_ShouldFilterProgramaByTitle
        /// </summary>
        /// <returns></returns>
        private ProgramaInfo getExampleProgramForFindBy()
        {
            return new ProgramaInfo() { Titulo = "Desarrollo con Java" };
        }

        /// <summary>
        /// Aquí se define la cadena de conexión para la based e datos
        /// </summary>
        /// <returns></returns>
        private string getConnectionString()
        {
            return "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=DbSOLT1129_e;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";

        }

        #endregion
    }
}
