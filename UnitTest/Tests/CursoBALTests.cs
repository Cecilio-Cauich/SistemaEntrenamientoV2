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
    public class CursoBALTests
    {
        #region GetCurso Tests...

        [TestMethod]
        ///Probamos que el método GetCurso retorna un objeto de tipo Curso
        public void GetCurso_ShouldGetCourse()
        {
            //Arrange
            int IdToSearch = 2;
            CursoBAL cursoBAL = new () { ConnectionString = getConnectionString() };
            //Act
            CursoInfo Actual = cursoBAL.GetCurso(IdToSearch);
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(CursoInfo),"No es un curso");
        }


        [TestMethod]
        ///Probamos que el método GetCurso, pasandole un Id, retorna el registro de que debe
        ///Lo verficamos con el titulo del curso que se retorna comparandolo un el titulo de un curso  
        ///que tenemso creado para hacer la pruea
        public void GetCuenta_ShouldGetCourseWithId()
        {

            //Arrange
            int IdToSearch = 1;
            CursoInfo Expected = getExampleCourse();
            CursoBAL cursoBAL = new () { ConnectionString = getConnectionString() };
            //Act
            CursoInfo Actual = cursoBAL.GetCurso(IdToSearch);
            //Assert
            Assert.AreEqual(Expected.Titulo, Actual.Titulo, "No es el curso esperado");

        }

        #endregion


        #region Save Tests...

        [TestMethod]
        ///Probamos que devuelva un dato tipo Int y que sea diferente de cero, si es igual a cero
        ///es porque no se guardó el registro
        public void Save_ShouldSaveANewCourse()
        {
            //Arrange
            CursoBAL cursoBAL = new () { ConnectionString = getConnectionString() };
            //Act
            int Actual = cursoBAL.Save(getExampleCourseForInsertSave());
            //Assert
            Assert.AreNotEqual(Actual,0, "Registro no guardado");
        }


        [TestMethod]
        ///Probamos que devuelva un Id igual al del curso mandamos a actualizar 
        public void Save_ShouldSaveTheCourseUpdate()
        {
            //Arrange
            CursoInfo courseExample = getExampleCourseForUpdateSave();
            int Expected = courseExample.Id;
            CursoBAL cursoBAL = new () { ConnectionString = getConnectionString() };
            //Act
            int Actual = cursoBAL.Save(courseExample);
            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        #endregion

        #region FindBy Tests

        [TestMethod]
        ///Probamos que retorne una lista de cursos de acuerdo al filtro
        public void FindBy_ShouldFilterCourseByLevel()
        {
            //Arrange
            List<CursoInfo> Actual;
            CursoBAL cursoBAL = new () { ConnectionString = getConnectionString() };
            //Act
            Actual = cursoBAL.FindBy(getExampleCourseForFindBy());
            //Assert
            Assert.IsInstanceOfType(Actual, typeof(List<CursoInfo>), "No es una lista de cursos");
        }

        #endregion


        #region Data

        /// <summary>
        /// Nos devuelve un curso con datos definidos para prueba
        /// Se usa para el método GetCurso_ShouldGetCourseWithId
        /// </summary>
        /// <returns></returns>
        private CursoInfo getExampleCourse()
        {
            return new CursoInfo()
            {
                Id = 1,
                Titulo = "Programación orientada a objetos",
                Descripcion = "Conocer conceptos de la programación orientada a objetos",
                Nivel = "Básico",
                Duracion = 16
            };
            
        }

        /// <summary>
        /// Nos devuelve una cuenta con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere insertar un nuevo
        /// elemento en la tabla curso
        /// </summary>
        /// <returns></returns>
        private CursoInfo getExampleCourseForInsertSave()
        {
            return new CursoInfo()
            {
                Titulo = "Curso Demo",
                Descripcion = "Conocer conceptos básico sobre la programación con Demo",
                Nivel = "Básico",
                Duracion = 8
            };
        }

        /// <summary>
        /// Nos devuelve una cuenta con datos definidos para prueba
        /// Esta hecho para ser usado en el método save cuando se quiere actualizar un nuevo
        /// elemento en la tabla curso
        /// </summary>
        /// <returns></returns>
        private CursoInfo getExampleCourseForUpdateSave()
        {
            return new CursoInfo()
            {
                Id = 9,
                Titulo = "Curso Demo Actualizado",
                Descripcion = "Conocer conceptos básico sobre la programación con Demo",
                Nivel = "Básico",
                Duracion = 10
            };
        }
        /// <summary>
        /// Nos devuelve un curso con una propiedad nada más, esta propiedad se usará para filtrar los cursos
        /// Se usa en el método FindBy_ShouldFilterCourseByLevel
        /// </summary>
        /// <returns></returns>
        private CursoInfo getExampleCourseForFindBy()
        {
            return new CursoInfo() { Nivel = "Básico" };
            
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
