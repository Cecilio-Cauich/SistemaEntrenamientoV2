using SistemaEntrenamientoV2.Clases.BusinessLogic;
using SistemaEntrenamientoV2.Clases.EntityLayer;
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
        private int? Id;
        CLS_CrudCursoBAL oCursoBAL = new CLS_CrudCursoBAL();

        public EditarCurso(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
            {
                CargarDatos();
            }
        }

        private void EditarCurso_Load(object sender, EventArgs e)
        {

        }
        #region Helpers
        private void CargarDatos()
        {
            CLS_CrudCursoInfo oCurso;
            oCurso = oCursoBAL.GetEntityObject((int)Id);
            txtTitulo.Text = oCurso.titulo;
            txtDescripcion.Text = oCurso.descripcion;
            txtDuracion.Text = oCurso.duracion.ToString();
            txtNivel.Text = oCurso.nivel;    

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            int IdGuardado;
            CLS_CrudCursoInfo oCurso = new CLS_CrudCursoInfo();
            oCurso.titulo = txtTitulo.Text;
            oCurso.descripcion = txtDescripcion.Text;
            oCurso.duracion = Int32.Parse(txtDuracion.Text);
            oCurso.nivel = txtNivel.Text;
            oCurso.curso_id =(int)Id;
            IdGuardado = oCursoBAL.Save(oCurso);
            MessageBox.Show("Id elemento editado "+IdGuardado.ToString());
            this.Close();
        }
    }
}
