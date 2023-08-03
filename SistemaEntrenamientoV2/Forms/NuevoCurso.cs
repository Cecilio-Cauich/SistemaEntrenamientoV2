
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
using System.Xml;

namespace SistemaEntrenamientoV2.Forms
{
    public partial class NuevoCurso : Form
    {
        #region Global Variables...
        private SistemaEntrenamientoCore.Business.CursoBAL CursoBAL;
       

        string ConnectioString = "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=DbSOLT1129_e;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";
    
        #endregion

        public NuevoCurso()
        {
            InitializeComponent();
        }

        //Para guardar un nuevo curso
        private void button1_Click(object sender, EventArgs e)
        {
            
            int IdGuardado;        
          
            try
            {
                Cursor = Cursors.WaitCursor;
                CursoBAL = new SistemaEntrenamientoCore.Business.CursoBAL() { ConnectionString = ConnectioString };
                
                //Llamamos el método para guardar el curso y la vez el método para obtener los valores a guardar
                IdGuardado = CursoBAL.Save(ObtenerDatos());
                MessageBox.Show(IdGuardado.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                this.Close();
            }
       
        }

        private void NuevoCurso_Load(object sender, EventArgs e)
        {

        }
        #region Helpers
        /// <summary>
        /// Método que nos permite obtener los valores de textbox siempre que lo necesitemos
        /// </summary>
        /// <returns>Un objeto de tipo CursoInfo</returns>
        private CursoInfo ObtenerDatos()
        {
            CursoInfo CursoInfo = new CursoInfo();
            CursoInfo.Titulo = txtTitulo.Text;
            CursoInfo.Descripcion = txtDescripcion.Text;
            CursoInfo.Nivel = txtNivel.Text;
            CursoInfo.Duracion = (Int32.Parse(txtDuracion.Text));

            return CursoInfo;

        }
        #endregion

    }
}
