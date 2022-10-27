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
    public partial class FrmPrincipalMDI : Form
    {
        public FrmPrincipalMDI()
        {
            InitializeComponent();
        }

        private void FrmPrincipalMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            //al cerrar el formulario principal se deberia terminar la aplicacion
            //en el caso que lo que queramos es volver a mostrar el form de login
            //deberiamos agregar un objeto global para dicho formulario
            //
            Application.Exit();
        }

        private void FrmPrincipalMDI_Load(object sender, EventArgs e)
        {

        }

        private void mANTENIMIENTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pROCESOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gALERIADEREPORTESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GESTIONA usuarios globales

            // querer usuario se muestre solo una ves verificar si esta
            //visible o no y en caso de no se REINSTANCIA y muestra de nuevo
            
            // el simbolo ! niega una condicion logica
            if (!Globales.MiFormMantUsuarios.Visible)
            {
                Globales.MiFormMantUsuarios = new FrmUsuariosGestion();
                Globales.MiFormMantUsuarios.Show();
            }

        }
    }
}
