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
    public class RolBALTests
    {
        #region GetRol Tests...

        [TestMethod]
        ///Probamos que el método GetRol retorna un objeto de tipo rol
        public void GetRol_ShouldGetRol()
        {
            //Arrange
            int IdToSearch = 1;
            RolBAL rolBAL = new() { ConnectionString = getConnectionString() };
            //Act
            RolInfo Actual = rolBAL.GetRol(IdToSearch);
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(RolInfo), "No es un rol");
        }


        [TestMethod]
        ///Probamos que el método GetRol, pasandole un Id, retorna el registro que debe
        ///Lo verficamos con el nombre del rol que se retorna comparandolo con un el nombre de un rol 
        ///creada para la prueba
        public void GetRol_ShouldGetRolWithId()
        {

            //Arrange
            int IdToSearch = 2;
            RolInfo Expected = getExampleRol();
            RolBAL rolBAL = new() { ConnectionString = getConnectionString() };
            //Act
            RolInfo Actual = rolBAL.GetRol(IdToSearch);
            //Assert
            Assert.AreEqual(Expected.Nombre, Actual.Nombre, "No es la el rol esperado");

        }

        #endregion

        #region Save Tests...

        [TestMethod]
        ///Probamos que devuelva un dato tipo Int y que sea diferente de cero, si es igual a cero
        ///es porque no se guardó el registro
        public void Save_ShouldSaveANewProgramaCurso()
        {
            //Arrange
            RolBAL rolBAL = new() { ConnectionString = getConnectionString() };
            //Act
            int Actual = rolBAL.Save(getExampleRolForInsertSave());
            //Assert
            Assert.AreNotEqual(Actual, 0, "Registro no guardado");
        }


        [TestMethod]
        ///Probamos que devuelva un Id igual al del rol que  mandamos a actualizar 
        public void Save_ShouldSaveTheRolUpdate()
        {
            //Arrange
            RolInfo rolExample = getExampleRolForUpdateSave();
            int Expected = rolExample.Id;
            RolBAL rolBAL = new() { ConnectionString = getConnectionString() };
            //Act
            int Actual = rolBAL.Save(rolExample);
            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        #endregion

        #region FindBy Tests

        [TestMethod]
        ///Probamos que retorne una lista de relación de roles de acuerdo al filtro 
        public void FindBy_ShouldFilterRolByName()
        {
            //Arrange
            List<RolInfo> Actual;
            RolBAL rolBAL = new() { ConnectionString = getConnectionString() };
            //Act
            Actual = rolBAL.FindBy(getExampleRolForFindBy());
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(List<RolInfo>), "No es una lista de roles");
        }

        #endregion

        #region Data

        /// <summary>
        /// Nos devuelve una rol con datos definidos para prueba
        /// Se usa para el método GetRol_ShouldGetRolWithId
        /// </summary>
        /// <returns></returns>
        private RolInfo getExampleRol()
        {
            return new RolInfo()
            {
                Id = 2,
                Nombre = "Instructor"
            };

        }

        /// <summary>
        /// Nos devuelve un rol con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere insertar un nuevo
        /// elemento en la tabla rol
        /// </summary>
        /// <returns></returns>
        private RolInfo getExampleRolForInsertSave()
        {
            return new RolInfo()
            {
                Nombre = "Nuevo rol"
            };

        }

        /// <summary>
        /// Nos devuelve una relacin de programa curso con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere actualizar un nuevo
        /// elemento en la tabla rol
        /// </summary>
        /// <returns></returns>
        private RolInfo getExampleRolForUpdateSave()
        {
            return new RolInfo()
            {
                Id = 6, //Si quiere modificar un registro recien creado primero consulte el día en la bdd para colocarlo aquí
                Nombre = "Nuevo rol actualizado"
            };

        }
        /// <summary>
        /// Nos devuelve uu rol con una propiedad nada más, esta propiedad se usará para filtrar las cuentas
        /// Se usa en el método FindBy_ShouldFilterRolByName
        /// </summary>
        /// <returns></returns>
        private RolInfo getExampleRolForFindBy()
        {
            return new RolInfo() { Nombre = "Instructor" };
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
