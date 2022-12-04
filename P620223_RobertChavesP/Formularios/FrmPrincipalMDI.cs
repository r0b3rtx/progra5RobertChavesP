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
            //mostrar el usuario que esta logueado en el  sistema.
            string InfoUsuario = string.Format("{0}({1})", Globales.MiUsuarioGlobal.Nombre,
                Globales.MiUsuarioGlobal.MiRol.Rol);

            LblUsuarioLogueando.Text = InfoUsuario;

            //se debe filtar las opciones de acceso a menus segun el rol que
            //tenga el usuario

            switch (Globales.MiUsuarioGlobal.MiRol.IDUsuario)
            {

                case 1:
                    //no hace falta ocultar opciones ya que es admin
                    break;

                case 2:
                    //seria tipo bodeguero
                    MnuProcesos.Visible = false;
                    MnuUsuariosGestion.Visible = false;
                    MnuImpuestosGestion.Visible = false;
                    MnuClientesGestion.Visible = false;

                    MnuListaClientes.Visible = false;
                    MnuFacturasReimpresion.Visible = false;
                    MnuVentasCliente.Visible = false;
                    MnuVentasRangoFechas.Visible = false;
                    MnuVentasUsuario.Visible = false;
                    break;

                case 3:
                    //seria tipo facturador
                    MnuUsuariosGestion.Visible = false;
                    MnuImpuestosGestion.Visible = false;
                    MnuInventarioGetion.Visible = false;
                    MnuCategoriaGestion.Visible = false;
                    MnuProveedoresGestion.Visible = false;

                    MnuListaProveedores.Visible = false;
                    break;
            }

            TmrFechaHora.Enabled = true;

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

        private void TmrFechaHora_Tick(object sender, EventArgs e)
        {
            //Asignar al label de fecha y hora el valor en formato extendido de la fech
            // y ademas la hora

            string fecha = DateTime.Now.Date.ToLongDateString();
            string hora = DateTime.Now.ToLongTimeString();

            LblFechaYHora.Text = fecha + "/" + hora;

        }

        private void MnuFacturacion_Click(object sender, EventArgs e)
        {
            if (!Globales.MiFormFacturacion.Visible)
            {
                Globales.MiFormFacturacion = new FrmFacturacion();

                Globales.MiFormFacturacion.Show();
            }
        }
    }
}
