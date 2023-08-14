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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //Obtención de datos de la interfaz
            string user = txtUsuario.Text;
            string pass = txtContrasenia.Text;


            SOLTUM.Framework.Business.UserBAL userBAL = new SOLTUM.Framework.Business.UserBAL() { ConnectionString = SOLTUM.Framework.Global.ProjectConnection.CredentialsConnectionString };

            if (userBAL.UserExists(user.ToUpper(), pass.ToUpper()))
            {
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
 
        }
    }
}
