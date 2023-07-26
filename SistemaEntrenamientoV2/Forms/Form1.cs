using SistemaEntrenamientoV2.Clases.BusinessLogic;
using SistemaEntrenamientoV2.Clases.EntityLayer;
using SistemaEntrenamientoV2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEntrenamientoV2
{
    public partial class Form1 : Form
    {
        ///<summary>
        ///Variables globales
        ///</summary>
        ///<remarks>
        ///
        ///</remarks>

        CLS_CrudCursoBAL objCursoBAL = new CLS_CrudCursoBAL();


        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = objCursoBAL.Refrescar();
            loadOption();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoCurso objNc = new NuevoCurso();
            objNc.ShowDialog();
            dataGridView1.DataSource = objCursoBAL.Refrescar();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? IdActual = GetId();
            objCursoBAL.deleteCourse((int)IdActual);
            MessageBox.Show("Id Elemento: " + IdActual + " Eliminado");
            dataGridView1.DataSource = objCursoBAL.Refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? IdActual = GetId();
            if(IdActual != null)
            {
                EditarCurso objEC = new EditarCurso(IdActual);
                objEC.ShowDialog();
                dataGridView1.DataSource = objCursoBAL.Refrescar();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<CLS_CrudCursoInfo> cursoFiltrados = new List<CLS_CrudCursoInfo>();
            string valorSeleccionado = comboBox1.SelectedItem.ToString();
            cursoFiltrados = objCursoBAL.FindWithFilter(valorSeleccionado);
            dataGridView1.DataSource = cursoFiltrados;
        }


        #region HELPER
        ///<summary>
        ///Obtiene el Id de elemento seleccionado en el Grid
        ///</summary>
        ///<return>
        ///D
        ///</return>
        private int? GetId()
        {
            try
            {
                return int.Parse(
                          dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
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
            List<string> opciones = new List<string>();
            opciones = objCursoBAL.ListaDeOpciones();
            for (int i = 0; i < opciones.Count; i++)
            {
                comboBox1.Items.Add(opciones[i].ToString());
            }
            comboBox1.SelectedIndex = 0;

        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =  objCursoBAL.Refrescar();

        }
    }
}
