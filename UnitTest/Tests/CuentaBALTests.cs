using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEntrenamientoCore.Business;
using SistemaEntrenamientoCore.Entity;

namespace UnitTest.Tests
{
    [TestClass]
    public class CuentaBALTests
    {
        #region GetCuenta Tests...

        [TestMethod]
        ///Probamos que el método GetCuenta retorna un objeto de tipo Cuenta
        public void GetCuenta_ShouldGetCount()
        {
            //Arrange
            int IdToSearch = 1;
            CuentaBAL cuentaBAL = new () { ConnectionString = getConnectionString() };
            //Act
            CuentaInfo Actual = cuentaBAL.GetCuenta(IdToSearch);
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(CuentaInfo),"No es una cuenta");
        }


        [TestMethod]
        ///Probamos que el método GetCuenta, pasandole un Id, retorna el registro de que debe
        ///Lo verficamos con el email de la cuenta que se retorna comparandolo con el email de una cuenta 
        ///creada para hacer la prueba
        public void GetCuenta_ShouldGetCountWithId() {

            //Arrange
            int IdToSearch = 2;
            CuentaInfo Expected = getExampleAccount();
            CuentaBAL cuentaBAL = new () { ConnectionString = getConnectionString() };
            //Act
            CuentaInfo Actual = cuentaBAL.GetCuenta(IdToSearch);
            //Assert
            Assert.AreEqual(Expected.Email, Actual.Email,"No es la cuenta esperada");

        }

        #endregion

        #region Save Tests...

        [TestMethod]
        ///Probamos que devuelva un dato tipo Int y que sea diferente de cero, si es igual a cero
        ///es porque no se guardó el registro
        public void Save_ShouldSaveANewCount()
        {
            //Arrange
            CuentaBAL cuentaBAL = new () { ConnectionString = getConnectionString() };
            //Act
            int Actual = cuentaBAL.Save(getExampleAccountForInsertSave());
            //Assert
            Assert.AreNotEqual(Actual, 0, "Registro no guardado");
        }


        [TestMethod]
        ///Probamos que devuelva un Id igual al de la cuenta que que mandamos a actualizar 
        public void Save_ShouldSaveTheAccountUpdate()
        {
            //Arrange
            CuentaInfo accountExample = getExampleAccountForUpdateSave();
            int Expected = accountExample.Id;
            CuentaBAL cuentaBAL = new () { ConnectionString = getConnectionString() };
            //Act
            int Actual = cuentaBAL.Save(accountExample);
            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        #endregion

        #region FindBy Tests

        [TestMethod]
        ///Probamos que retorne una lista de cuentas de acuerdo al filtro 
        public void FindBy_ShouldFilterAccountByGender()
        {
            //Arrange
            List<CuentaInfo> Actual;
            CuentaBAL cuentaBAL = new () { ConnectionString = getConnectionString() };
            //Act
            //Actual = cuentaBAL.FindBy(getExampleAccountForFindBy());
            //Assert
            //Assert.IsInstanceOfType(Actual, typeof(List<CuentaInfo>), "No es una lista de cuentas");
        }

        #endregion

        #region Data

        /// <summary>
        /// Nos devuelve una cuenta con datos definidos para prueba
        /// Se puede usar para el método GetCuenta_ShouldGetCountWithId
        /// </summary>
        /// <returns></returns>
        private CuentaInfo getExampleAccount()
        {
            return new CuentaInfo()
            {
                Id = 1,
                Nombres = "Alberto",
                Apellidos = "Lopez Lopes",
                Email = "albertolopez@gmail.com",
                Genero = "Masculino",
                Fecha_Nacimiento = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            };
           
        }

        /// <summary>
        /// Nos devuelve una cuenta con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere insertar un nuevo
        /// elemento en la tabla cuenta
        /// </summary>
        /// <returns></returns>
        private CuentaInfo getExampleAccountForInsertSave()
        {
            return new CuentaInfo()
            {
                Nombres = "Margarita",
                Apellidos = "Sanchez Badoli",
                Email = "margaritabadoli@gmail.com",
                Genero = "Femenino",
                Fecha_Nacimiento = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            };
            
        }

        /// <summary>
        /// Nos devuelve una cuenta con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere actualizar un nuevo
        /// elemento en la tabla cuenta
        /// </summary>
        /// <returns></returns>
        private CuentaInfo getExampleAccountForUpdateSave()
        {
            return new CuentaInfo()
            {
                Id = 1,
                Nombres = "Alberto",
                Apellidos = "Lopez Lopez",
                Email = "albertolopez@gmail.com",
                Genero = "Masculino",
                Fecha_Nacimiento = DateTime.Now.ToString("yyyy-MM-dd HH:mm") 
            };
            
        }
        /// <summary>
        /// Nos devuelve una cuenta con una propiedad nada más, esta propiedad se usará para filtrar las cuentas
        /// Se usa en el método FindBy_ShouldFilterAccountByGender
        /// </summary>
        /// <returns></returns>
        private CuentaInfo getExampleAccountForFindBy()
        {
            return new CuentaInfo() { Genero = "Masculino" };
        }

        /// <summary>
        /// Aquí se define la cadena de conexión para la base de datos
        /// </summary>
        /// <returns></returns>
        private string getConnectionString()
        {
            return  "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=DbSOLT1129_e;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";

        }

        #endregion

    }
}
