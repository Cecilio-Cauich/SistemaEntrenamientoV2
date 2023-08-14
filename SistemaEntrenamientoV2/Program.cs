using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaEntrenamientoV2.Forms;

namespace SistemaEntrenamientoV2
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            try

            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                LoadMainConfiguration();        //  load initial configuration...
                Application.Run(new Login());
                 

            }

            catch (Exception ex)

            {

                MessageBox.Show(string.Format("Main: {0}", ex.Message));

            }
        }

        static void LoadMainConfiguration()

        {

            try

            {

                // Read the connection string configuration...

                if (SOLTUM.Framework.Global.ProjectConnection != null || string.IsNullOrEmpty(SOLTUM.Framework.Global.ProjectConnection.DataConnectionString))
                {

                    SOLTUM.Framework.Global.ProjectConnection = new SOLTUM.Framework.Utilities.ProjectConnection();
                    SOLTUM.Framework.Global.SateliteProductName = Properties.Resources.ProgramName;
                    SOLTUM.Framework.Global.ProjectConnection.Read("SOLTUM", @"C:\Proyectos_2023\tallerPuntoNet\SistemaEntrenamientoV2\SistemaEntrenamientoV2\bin\Debug");

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show(string.Format("{0} ::: {1}", ex.TargetSite.Name, ex.Message));

            }

        }
    }
}
