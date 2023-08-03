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
        private CursoBAL CursoBAL;
        string ConnectioString = "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=DbSOLT1129_e;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";
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
            refresh();
            loadOption();
    
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoCurso ventanaNuevoCurso = new NuevoCurso();
            ventanaNuevoCurso.ShowDialog();
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if(Id != null) 
            {
                EditarCurso ventanaEditarCurso = new EditarCurso(Id);
                ventanaEditarCurso.ShowDialog();
                refresh();

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
                refresh();  
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string valorSeleccionado = comboBox1.SelectedItem.ToString();
            refresh(valorSeleccionado);
        }


        #region Helpers
        /// <summary>
        /// Definición de método que permite obtener de todos los datos de la tabla curso en dado caso
        /// que reciba un filtro entra en una condición para manejar y poder apicar el filtro
        /// nos sirve para refresacar el grid
        /// </summary>
        private void refresh(string filtro = default)
        {
            if(filtro != null)
            {
              
                try
                {
                    Cursor = Cursors.WaitCursor;
                    CursoBAL = new SistemaEntrenamientoCore.Business.CursoBAL() { ConnectionString = ConnectioString };
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
                    CursoBAL = new SistemaEntrenamientoCore.Business.CursoBAL() { ConnectionString = ConnectioString };
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
            try
            {
                Cursor = Cursors.WaitCursor;
                ProgramaBAL = new SistemaEntrenamientoCore.Business.ProgramaBAL() { ConnectionString = ConnectioString };
               
                List<string> opciones = new List<string>();
                List<ProgramaInfo> programas = new List<ProgramaInfo>();

                programas = ProgramaBAL.GetProgramas();

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
            refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
