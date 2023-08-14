using SistemaEntrenamientoCore.Business;
using SistemaEntrenamientoCore.Data;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SistemaEntrenamientoV2.Forms
{
    public partial class Form1 : Form
    {
        #region Global Variabels
        private CursoBAL CursoBAL ;
        //string ConnectionString = "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=DbSOLT1129_e;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";
        //string ConnectionString = SOLTUM.Framework.Global.ProjectConnection.DataConnectionString;
        private ProgramaBAL ProgramaBAL;
        #endregion

        #region Constructors...
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos...
        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
            loadOption();
    
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoCurso ventanaNuevoCurso = new NuevoCurso();
            ventanaNuevoCurso.ShowDialog();
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if(Id != null) 
            {
                EditarCurso ventanaEditarCurso = new EditarCurso(Id);
                ventanaEditarCurso.ShowDialog();
                Refresh();

            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
           

            try
            {
                int? Id = GetId();
                if (Id != null)
                {
                    Cursor = Cursors.WaitCursor;
                    if (CursoBAL.Delete((int)Id))
                    {
                        MessageBox.Show("Elemento eliminado " + Id);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                Refresh();  
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string valorSeleccionado = comboBox1.SelectedItem.ToString();
            Refresh(valorSeleccionado);
        }


        #region Helpers
        /// <summary>
        /// Definición de método que permite obtener de todos los datos de la tabla curso lo que nos permite refresca
        /// el grid cada vez que sea necesario, en dado caso
        /// que reciba un filtro se cumple una condición donde esta el algoritmo manejar y poder apicar el filtro
        /// </summary>
        private void Refresh(string filtro = default)
        {
            string ConnectionString = SOLTUM.Framework.Global.ProjectConnection.DataConnectionString;

            if (filtro != null)
            {

                try
                {
                    Cursor = Cursors.WaitCursor;
                    CursoBAL = new SistemaEntrenamientoCore.Business.CursoBAL() { ConnectionString = ConnectionString };         
                    CursosdataGridView1.DataSource = CursoBAL.GetCursosPorPrograma(filtro);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    CursoBAL = new SistemaEntrenamientoCore.Business.CursoBAL() { ConnectionString = ConnectionString };
                   
                    List<CursoInfo> list = new List<CursoInfo>();
                    CursosdataGridView1.DataSource = CursoBAL.GetCursos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }

            }

        }


        /// <summary>
        /// Definición de método para saber el Id del elemento seleccionado en el grid
        /// </summary>
        /// <returns>El Id del elemento seleccionado</returns>
        private int? GetId()
        {
            try
            {
                return int.Parse(
                          CursosdataGridView1.Rows[CursosdataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                                 );

            }
            catch { }
            {
                return null;
            }

        }


        ///<summary>
        ///Carga las opciones en el combobox
        ///</summary>
        ///<return>
        ///
        ///</return>
        private void loadOption()
        {
            string ConnectionString = SOLTUM.Framework.Global.ProjectConnection.DataConnectionString;

            try
            {
                Cursor = Cursors.WaitCursor;
                ProgramaBAL = new SistemaEntrenamientoCore.Business.ProgramaBAL() { ConnectionString = ConnectionString };
             

                List<string> opciones = new List<string>();
                List<ProgramaInfo> programas = new List<ProgramaInfo>();

                programas = ProgramaBAL.GetProgramas();

                //De la lista de programas extraemos solo los titulos para mostrar en el comboBox
                programas.ForEach(programa => {
                    opciones.Add(programa.Titulo);
                });

                comboBox1.DataSource = opciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }



        }

        #endregion

        private void CursosdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
