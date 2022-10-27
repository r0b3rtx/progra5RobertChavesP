using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P620223_RobertChavesP.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVerPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // cierre de la app
            Application.Exit();
        }

        private void btnVerPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = false; 

        }

        private void btnVerPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //TODO: se debe validar  el ingreso  del usuario

            // si la validacion es correcta permite el ingreso al sistema
            //y muestra el formulario  principal
            Globales.MiFormPrincipal.Show();
            this.Hide();

        }
    }
}
