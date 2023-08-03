
using SistemaEntrenamientoCore.Business;
using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEntrenamientoV2.Forms
{
    public partial class EditarCurso : Form
    {
        #region Global Variables
        private int? Id;
        CursoBAL CursoBAL = new CursoBAL();
        CursoInfo CursoInfo;

        string ConnectioString = "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=DbSOLT1129_e;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";
        #endregion


        public EditarCurso(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
            {
                EditarCursoActual();
            }
        }

        private void EditarCurso_Load(object sender, EventArgs e)
        {

        }
        #region Helpers
        ///<summary>
        ///Carga los datos en los espacios de texto de la intefaz
        ///</summary>
        ///<return>
        ///
        ///</return>
        private void EditarCursoActual()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CursoBAL = new SistemaEntrenamientoCore.Business.CursoBAL() { ConnectionString = ConnectioString };
                CursoInfo = CursoBAL.GetCurso((int)Id);
                
                //Lamamos un método que carga cada dato a su correspondiente textbox
                CargarDatosEnTxtBox(CursoInfo);
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int IdGuardado;
                IdGuardado = CursoBAL.Save(ObtenerDatosDeTxtBox());
                MessageBox.Show("Id elemento editado " + IdGuardado.ToString());
                this.Close();

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


        #region Helpers
        /// <summary>
        /// Su función es colocar en cada txtbox el valor que trae el entity de Curso
        /// </summary>
        /// <param name="Curso"></param>
        private void CargarDatosEnTxtBox(CursoInfo Curso)
        {

            txtTitulo.Text = Curso.Titulo;
            txtDescripcion.Text = Curso.Descripcion;
            txtNivel.Text = Curso.Nivel;
            txtDuracion.Text = Curso.Duracion.ToString();

        }
        /// <summary>
        /// Su función es obtener los datos de los txtbox y formar un entity Curso
        /// </summary>
        /// <returns>
        /// Un entity curso
        /// </returns>
        private CursoInfo ObtenerDatosDeTxtBox()
        {
            CursoInfo Curso = new CursoInfo();

            Curso.Titulo = txtTitulo.Text;
            Curso.Descripcion = txtDescripcion.Text;
            Curso.Nivel = txtNivel.Text;
            Curso.Duracion = Int32.Parse(txtDuracion.Text);
            Curso.Id = (int)Id;

            return Curso;

        }
        #endregion

    }
}
