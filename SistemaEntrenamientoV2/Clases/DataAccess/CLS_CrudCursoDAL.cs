using SistemaEntrenamientoV2.Clases.BusinessLogic;
using SistemaEntrenamientoV2.Clases.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEntrenamientoV2.Clases.DataAccess
{
    public class CLS_CrudCursoDAL
    {
        ///<summary>
        ///Variable que almacena los datos para la autenticación a la base de datos
        ///</summary>
        ///<remarks>
        ///
        ///</remarks>
        private string cadenaConexion = "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=sistemaentrenamientoCC;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";

        ///<summary>
        ///Buscar un registro con el Id que se le proporciona en la tabla Curso de la base de datos.
        ///</summary>
        ///<return>
        ///Devuelve un objeto con los datos del registro que encontró.
        ///</return>
        public CLS_CrudCursoInfo GetEntityObject(int Id)
        {
            string SqlConsulta = "select curso_id,titulo,descripcion,duracion,nivel from curso where curso_id = @id";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando = new SqlCommand(SqlConsulta, conexion);
                comando.Parameters.AddWithValue("id", Id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    CLS_CrudCursoInfo oCurso = new CLS_CrudCursoInfo();
                    oCurso.curso_id = reader.GetInt32(0);
                    oCurso.titulo = reader.GetString(1);
                    oCurso.descripcion = reader.GetString(2);
                    oCurso.duracion = reader.GetInt32(3);
                    oCurso.nivel = reader.GetString(4);

                    reader.Close();
                    conexion.Close();
                    return oCurso;

                }
                catch (Exception ex)
                {
                    throw new Exception("Errr " + ex);
                }
            }


        }

        ///<summary>
        ///Agrega un nuevo registro a la tabla de Curso en la base de datos
        ///</summary>
        ///<return>
        ///Devuelve el Id del registro guardado
        ///</return>
        public int Insert(CLS_CrudCursoInfo objCurso)
        {
            int IdGuardado;
            string SqlConsulta = "INSERTAR_CURSO";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(SqlConsulta, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@titulo", objCurso.titulo);
                comando.Parameters.AddWithValue("@descripcion", objCurso.descripcion);
                comando.Parameters.AddWithValue("@duracion", objCurso.duracion);
                comando.Parameters.AddWithValue("@nivel", objCurso.nivel);

                SqlParameter UltimoGuardado = new SqlParameter("@IdGuardado", 0);
                UltimoGuardado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(UltimoGuardado);

                try
                {
                    conexion.Open();
                    IdGuardado = comando.ExecuteNonQuery();
                    IdGuardado = Int32.Parse(comando.Parameters["@IdGuardado"].Value.ToString());
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error: " + ex.Message);
                }
                return IdGuardado;

            }
        }

        ///<summary>
        ///Actualiza un registro de la tabla Curso en la base de datos.
        ///</summary>
        ///<return>
        ///Devuelve el Id del registro que actualizó
        ///</return>
        public int Update(CLS_CrudCursoInfo objCurso)
        {
            string SQLConsulta = "UPDATE CURSO SET titulo = @titulo, descripcion = @descripcion, duracion = @duracion, nivel = @nivel where curso_id =@curso_id";
            int IdGuardado = objCurso.curso_id;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(SQLConsulta, conexion);
                comando.Parameters.AddWithValue("@curso_id", objCurso.curso_id);
                comando.Parameters.AddWithValue("@titulo", objCurso.titulo);
                comando.Parameters.AddWithValue("@descripcion", objCurso.descripcion);
                comando.Parameters.AddWithValue("@duracion", objCurso.duracion);
                comando.Parameters.AddWithValue("@nivel", objCurso.nivel);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error " + ex);
                }

            }

            return IdGuardado;
        }

        ///<summary>
        ///Elimina un registro de la tabla Curso en base de datos a parti del Id que recibe.
        ///</summary>
        ///<return>
        ///
        ///</return>
        public void Delete(int curso_id)
        {
            string SqlConsulta = "delete from curso where curso_id = @curso_id";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(SqlConsulta, conexion);
                comando.Parameters.AddWithValue("@curso_id", curso_id);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error" + ex);
                }
            }
        }

        ///<summary>
        ///Busca los registro que cumplan con cierto filtro
        ///</summary>
        ///<return>
        ///Devuelve una lista de objetos que cumplan con el filtro
        ///</return>
        public List<CLS_CrudCursoInfo> FindBy(string filtro)
        {
            string SQLConsulta = "SELECT * FROM CURSO\r\ninner join programa_curso\r\non curso.curso_id = programa_curso.programa_curso_id\r\ninner join programa\r\non programa.programa_id = programa_curso.programa_id\r\nwhere lower(programa.titulo) = lower(@filtro);";
            List<CLS_CrudCursoInfo> ListaCursos = new List<CLS_CrudCursoInfo>();


            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(SQLConsulta, conexion);
                comando.Parameters.AddWithValue("@filtro", filtro);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {

                        CLS_CrudCursoInfo oCurso = new CLS_CrudCursoInfo();
                        oCurso.curso_id = reader.GetInt32(0);
                        oCurso.titulo = reader.GetString(1);
                        oCurso.descripcion = reader.GetString(2);
                        oCurso.duracion = reader.GetInt32(3);
                        oCurso.nivel = reader.GetString(4);
                        ListaCursos.Add(oCurso);


                    }

                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex) { throw new Exception("Error " + ex); }

                return ListaCursos;


            }



        }

        ///<summary>
        ///Obtiene todos los registro de la tabla curso
        ///</summary>
        ///<return>
        ///Devuelve una lista con objetos que contiene la información de cada registro de la tabla
        ///</return>
        public List<CLS_CrudCursoInfo> GetAll()
        {
            string SQLConsulta = "Select * from curso";
            List<CLS_CrudCursoInfo> ListaCursos = new List<CLS_CrudCursoInfo>();


            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(SQLConsulta, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {

                        CLS_CrudCursoInfo oCurso = new CLS_CrudCursoInfo();
                        oCurso.curso_id = reader.GetInt32(0);
                        oCurso.titulo = reader.GetString(1);
                        oCurso.descripcion = reader.GetString(2);
                        oCurso.duracion = reader.GetInt32(3);
                        oCurso.nivel = reader.GetString(4);
                        ListaCursos.Add(oCurso);


                    }

                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex) { throw new Exception("Error " + ex); }

                return ListaCursos;


            }

        }
        #region Helpers
        ///<summary>
        ///Obtiene los datos de la tabla de Programa
        ///</summary>
        ///<return>
        ///Devuelve una lista con únicamente el atributo "titulo" de la tabla Programa
        ///</return>
        public List<string> getProgramsTitle()
        {
            string SqlConsulta = "SELECT * from Programa";
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                List<string> opciones = new List<string>(); 
                SqlCommand comando = new SqlCommand(SqlConsulta, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        string str = reader.GetString(1);
                        opciones.Add(str);
                    }

                    return opciones;
                }catch
                (Exception ex)
                { throw new Exception(); }  
            }
        }
        #endregion
    }
}