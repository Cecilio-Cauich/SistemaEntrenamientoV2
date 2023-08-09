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
    public class UsuarioBALTests
    {
        #region GetUsuario Tests...

        [TestMethod]
        ///Probamos que el método GetUsuario retorna un objeto de tipo Usuario
        public void GetUsuario_ShouldGetUsuario()
        {
            //Arrange
            int IdToSearch = 1;
            UsuarioBAL usuarioBAL = new() { ConnectionString = getConnectionString() };
            //Act
            UsuarioInfo Actual = usuarioBAL.GetUsuario(IdToSearch);
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(UsuarioInfo), "No es un usuario");
        }


        [TestMethod]
        ///Probamos que el método GetUsuario, pasandole un Id, retorna el registro que debe
        ///Lo verficamos con el nombre del Usuario que se retorna comparandolo con un el nombre de un Usuario 
        ///creado para la prueba
        public void GetUsuario_ShouldGetUsuarioWithId()
        {

            //Arrange
            int IdToSearch = 2;
            UsuarioInfo Expected = getExampleUsuario();
            UsuarioBAL usuarioBAL = new() { ConnectionString = getConnectionString() };
            //Act
            UsuarioInfo Actual = usuarioBAL.GetUsuario(IdToSearch);
            //Assert
            Assert.AreEqual(Expected.Usuario, Actual.Usuario, "No es la el Usuario esperado");

        }

        #endregion

        #region Save Tests...

        [TestMethod]
        ///Probamos que devuelva un dato tipo Int y que sea diferente de cero, si es igual a cero
        ///es porque no se guardó el registro
        public void Save_ShouldSaveANewUsuario()
        {
            //Arrange
            UsuarioBAL usuarioBAL = new() { ConnectionString = getConnectionString() };
            //Act
            int Actual = usuarioBAL.Save(getExampleUsuarioForInsertSave());
            //Assert
            Assert.AreNotEqual(Actual,0, "Registro no guardado");
        }


        [TestMethod]
        ///Probamos que devuelva un Id igual al del Usuario que  mandamos a actualizar 
        public void Save_ShouldSaveTheUsuarioUpdate()
        {
            //Arrange
            UsuarioInfo usuarioExample = getExampleUsuarioForUpdateSave();
            int Expected = usuarioExample.Id;
            UsuarioBAL usuarioBAL = new() { ConnectionString = getConnectionString() };
            //Act
            int Actual = usuarioBAL.Save(usuarioExample);
            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        #endregion

        #region FindBy Tests

        [TestMethod]
        ///Probamos que retorne una lista de relación de Usuarios de acuerdo al filtro 
        public void FindBy_ShouldFilterUsuarioByRol()
        {
            //Arrange
            List<UsuarioInfo> Actual;
            UsuarioBAL usuarioBAL = new() { ConnectionString = getConnectionString() };
            //Act
            Actual = usuarioBAL.FindBy(getExampleUsuarioForFindBy());
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(List<UsuarioInfo>), "No es una lista de Usuarios");
        }

        #endregion

        #region Data

        /// <summary>
        /// Nos devuelve un Usuario con datos definidos para prueba
        /// Se usa para el método GetUsuario_ShouldGetUsuarioWithId
        /// </summary>
        /// <returns></returns>
        private UsuarioInfo getExampleUsuario()
        {
            return new UsuarioInfo()
            {
                Id = 2,
                Usuario = "lilian.aguilar",
                Contrasenia = "123456",
                Rol = 2
            };

        }

        /// <summary>
        /// Nos devuelve un Usuario con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere insertar un nuevo
        /// elemento en la tabla Usuario
        /// </summary>
        /// <returns></returns>
        private UsuarioInfo getExampleUsuarioForInsertSave()
        {
            return new UsuarioInfo()
            {
                Usuario = "Usuario Demo",
                Contrasenia = "demo",
                Rol = 2
                
            };

        }

        /// <summary>
        /// Nos devuelve un usuario con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere actualizar un nuevo
        /// elemento en la tabla Usuario
        /// </summary>
        /// <returns></returns>
        private UsuarioInfo getExampleUsuarioForUpdateSave()
        {
            return new UsuarioInfo()
            {
                Id = 6, //Si quiere modificar un registro recien creado primero consulte el día en la bdd para colocarlo aquí
                Usuario = "Nuevo Usuario actualizado"
            };

        }
        /// <summary>
        /// Nos devuelve uu Usuario con una propiedad nada más, esta propiedad se usará para filtrar las cuentas
        /// Se usa en el método FindBy_ShouldFilterUsuarioByRol
        /// </summary>
        /// <returns></returns>
        private UsuarioInfo getExampleUsuarioForFindBy()
        {
            return new UsuarioInfo() { Rol = 2 };
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
