using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Utilerias
{
    /// <summary>
    /// Definición de clase que permite llamar métodos de SQLCliente
    /// </summary>
    public class SQLHelper
    {


        #region Metthods...
        /// <summary>
        /// Definicón de método para ejecutar una consulta y no devuleve ningun resultado
        /// </summary>
        /// <param name="SQLStatement">La consulta a ejecutar</param>
        /// <param name="ConnectionString">Cadena de conexion para la autenticación a la base de datos</param>
        /// <returns>
        /// No devuleve nada
        /// </returns>
        public static void ExecuteNonQuery(string SQLStatement, string ConnectionString)
        {
            if (string.IsNullOrEmpty(SQLStatement)) throw new Exception("No recibimos la consulta a ejectuar");
            if (string.IsNullOrEmpty(ConnectionString)) throw new Exception("No recibimos la cadena de conexion");

            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQLStatement, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        /// <summary>
        /// Definicion de metodo que ejecuta una consulta y regresa un valor de la consulta
        /// </summary>
        /// <param name="SQLStatement">Consulta para la base de datos</param>
        /// <param name="ConnectionString">Cadena de conexion para la autenticación a la base de datos</param>
        /// <returns>
        /// Un objeto con un valor del resultado de la consulta
        /// </returns>
        public static Object ExecuteScalar(string SQLStatement, string ConnectionString)
        {
           
            if (string.IsNullOrEmpty(SQLStatement)) throw new Exception("No recibimos la consulta a ejectuar");
            if (string.IsNullOrEmpty(ConnectionString)) throw new Exception("No recibimos la cadena de conexion");

            Object result = null;

            try
            {
                //Uso de objeto de SQLCliente
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SQLStatement, connection))
                    {
                        result = command.ExecuteScalar();
                        Console.WriteLine(result);
                    }
                    connection.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// Definición de método que permite ejecutar una consulta SELECT
        /// </summary>
        /// <param name="SQLStatement">El comando selec</param>
        /// <param name="ConnectionString">Dato de autenticación a la base de datos</param>
        /// <returns>
        /// Devuelve un DataTable con los registros del SELECT
        /// </returns>
        public static DataTable ExecuteDataTable(string SQLStatement, string ConnectionString)
        {
            if (string.IsNullOrEmpty(SQLStatement)) throw new ArgumentNullException("No recibimos la consulta a ejecutar");
            if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentNullException("No recibimos la cadena de conexión");

            var dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(SQLStatement, connection);
                    adapter.Fill(dt);
                    connection.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return dt;


        }

        #endregion

    }
}

