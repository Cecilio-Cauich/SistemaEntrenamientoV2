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
    public partial class NuevoCurso : Form
    {
        CLS_CrudCursoBAL objCursoBAL = new CLS_CrudCursoBAL();
        public NuevoCurso()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int IdGuardado;
            CLS_CrudCursoInfo objCursoInfo = new CLS_CrudCursoInfo();
            objCursoInfo.titulo = txtTitulo.Text;
            objCursoInfo.descripcion = txtDescripcion.Text;
            objCursoInfo.duracion = (Int32.Parse(txtDuracion.Text));
            objCursoInfo.nivel = txtNivel.Text;
            IdGuardado = objCursoBAL.Save(objCursoInfo);
            objCursoBAL.Refrescar();
            MessageBox.Show("Id Elemento Guarado "+IdGuardado.ToString());
            this.Close();
        }

        private void NuevoCurso_Load(object sender, EventArgs e)
        {

        }
    }
}
