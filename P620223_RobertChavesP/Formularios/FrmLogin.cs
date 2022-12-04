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
            
            if(!string.IsNullOrEmpty(txtNombreUsuario.Text.Trim()) &&
                !string.IsNullOrEmpty(txtContrasenia.Text.Trim()))
            {
                string u = txtNombreUsuario.Text.Trim();
                string p = txtContrasenia.Text.Trim();

                int IdLoginOK = Globales.MiUsuarioGlobal.ValidarLogin(u, p);

                if (IdLoginOK > 0)
                {
                    //Globales.MiUsuarioGlobal.IDUsuario = IdLoginOK;

                    //Globales.MiUsuarioGlobal = Globales.MiUsuarioGlobal.ConsultarPorIDD();

                    Globales.MiFormPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contrasenia icorrectas", "Error validacion", MessageBoxButtons.OK);
                    txtContrasenia.Focus();
                    txtContrasenia.SelectAll();
                }
            }
            

            //Globales.MiFormPrincipal.Show();
            //this.Hide();

        }

        //metodo ingreso directo
        private void button1_Click(object sender, EventArgs e)
        {
            Globales.MiUsuarioGlobal.IDUsuario = 1;

            Globales.MiUsuarioGlobal = Globales.MiUsuarioGlobal.ConsultarPorIDD();

            Globales.MiFormPrincipal.Show();
            this.Hide();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Shift  & e.KeyCode == Keys.A)
            {
                btnIngresoDirecto.Visible = true;
            }
        }

      
    }
}
