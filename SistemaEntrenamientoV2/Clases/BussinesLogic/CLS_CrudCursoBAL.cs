using SistemaEntrenamientoV2.Clases.DataAccess;
using SistemaEntrenamientoV2.Clases.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEntrenamientoV2.Clases.BusinessLogic
{
    public class CLS_CrudCursoBAL
    {

        ///<summary>
        ///Objeto que se usa para acceder a la capa de datos
        ///</summary>
        ///<remarks>
        ///
        ///</remarks>
        CLS_CrudCursoDAL objCursoDAL = new CLS_CrudCursoDAL();

        ///<summary>
        ///Buscar un curso con el Id que se le proporciona como parámetro
        ///</summary>
        ///<return>
        ///Devuelve un objeto con los datos del registro que encontró.
        ///</return>
        public CLS_CrudCursoInfo GetEntityObject(int Id)
        {
            CLS_CrudCursoInfo oCurso = new CLS_CrudCursoInfo();
            oCurso = objCursoDAL.GetEntityObject(Id);
            return oCurso;

        }

        ///<summary>
        ///IGuarada o actualiza un registro de cursos
        ///</summary>
        ///<return>
        ///Devuelve el Id del objeto que guaradó o en caso del objeto que se actualizó
        ///</return>
        public int Save(CLS_CrudCursoInfo objCurso)
        {
            int IdGuardado;
            int Id = objCurso.curso_id;
            if(Id != 0)
            {
                IdGuardado = objCursoDAL.Update(objCurso);
                return IdGuardado;
            }
            else
            {
                IdGuardado = objCursoDAL.Insert(objCurso);
                return IdGuardado;
            }


        }

        ///<summary>
        ///Eliminar un registro de la tabla cursos en la base de datos
        ///</summary>
        ///<return>
        ///
        ///</return>
        public void deleteCourse(int Id)
        {
            objCursoDAL.Delete(Id);
        }


        ///<summary>
        ///Busca registros de acuerdo al filtro que se le pase como parámetro
        ///</summary>
        ///<return>
        ///Devuelve una lista de objetos con los datos de cada registro de cursos
        ///</return>
        public List<CLS_CrudCursoInfo> FindWithFilter(string filtro)
        {
            List<CLS_CrudCursoInfo> cursosFiltrados = new List<CLS_CrudCursoInfo> ();
            cursosFiltrados = objCursoDAL.FindBy(filtro);
            return cursosFiltrados;
        }
        ///<summary>
        ///Obtiene todos los registros disponibles de cursos
        ///</summary>
        ///<return>
        ///Retorna una lista de objetos con los datos de cada registro de cursos
        ///</return>
        public List<CLS_CrudCursoInfo> Refrescar()
        {
            List<CLS_CrudCursoInfo> listCursos = new List<CLS_CrudCursoInfo>();
            listCursos = objCursoDAL.GetAll();
            return listCursos;
        }



        #region Helpers
        ///<summary>
        ///Obtiene los titulos de los programas
        ///</summary>
        ///<return>
        ///Devuelve una lista de titulos de programa
        ///</return>
        public List<string> ListaDeOpciones()
        {
            return objCursoDAL.getProgramsTitle();
        }
        #endregion

    }
}
