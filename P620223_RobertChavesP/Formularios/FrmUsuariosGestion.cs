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
    public partial class FrmUsuariosGestion : Form
    {

        private Logica.Models.Usuario MiUsuarioLocal { get; set; }

        public DataTable ListaUsuarios { get; set; }

        public FrmUsuariosGestion()
        {
            InitializeComponent();

            MiUsuarioLocal = new Logica.Models.Usuario();

            ListaUsuarios = new DataTable();

        }

        private void FrmUsuariosGestion_Load(object sender, EventArgs e)
        {
            //establecer como padre el formulario principal, de forma que se anide dentro del mismo
            MdiParent = Globales.MiFormPrincipal;

            CargarRolesDeUsuario();
            CargarEmpresas();

            LlenarListaUsuarios();
        }

        private void LlenarListaUsuarios()
        {

            ListaUsuarios = new DataTable();

            ListaUsuarios = MiUsuarioLocal.Listar(cbVerActivos.Checked, txtBuscar.Text.Trim());

            DgvLista.DataSource = ListaUsuarios;
        }

        private void CargarRolesDeUsuario()
        {

            //paso 1 y 1.1 de secuencia usuario rol listar
            Logica.Models.UsuarioRol MiRolUsuario = new Logica.Models.UsuarioRol();

            //paso 2 y 2.5
            DataTable dt = new DataTable();
            dt = MiRolUsuario.Listar();

            //paso 3
            if (dt != null && dt.Rows.Count > 0)
            {
                cBoxRolUsuario.ValueMember = "IDUsuarioRol";
                cBoxRolUsuario.DisplayMember = "Rol";
                cBoxRolUsuario.DataSource = dt;
                cBoxRolUsuario.SelectedIndex = -1;

            }

        }



        private void CargarEmpresas()
        {

            Logica.Models.Empresa MiEmpresa = new Logica.Models.Empresa();

            DataTable dt = new DataTable();
            dt = MiEmpresa.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                cBoxEmpresa.ValueMember = "ID";
                cBoxEmpresa.DisplayMember = "D";
                cBoxEmpresa.DataSource = dt;
                cBoxEmpresa.SelectedIndex = -1;

            }

        }



        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // lo primero que debemos hacer es validar que los datos minimos necesarios
            //  estan completos
            //  luego, se procede a realizar las 3 validaciones que se indican por medio
            //  de los include (uses) en el diagrama de casos de uso expandido
            // si las 3 validaciones son NEGATIVAS se tiene permiso para agregar el usuario

            if (validarCamposRequridos())
            {
                //los campos estan completos
                bool consultaPorCedula;
                bool consultaPorNombreUsuario;
                bool consultaPorEmail;

                //tarea validar email y contrasenia
                bool validarEmail, validarContrasenia;

                //se crea una nueva instancia del usuario local y se agregan los valores
                //de los atributos
                MiUsuarioLocal = new Logica.Models.Usuario();

                MiUsuarioLocal.Nombre = txtNombre.Text.Trim();
                MiUsuarioLocal.Cedula = txtCedula.Text.Trim();
                MiUsuarioLocal.NombreUsuario = txtNombreUsuario.Text.Trim();
                MiUsuarioLocal.Email = txtEmail.Text.Trim();
                MiUsuarioLocal.Contrasenia = txtContrasenia.Text.Trim();

                MiUsuarioLocal.MiEmpresa.IDEmpresa = Convert.ToInt32(cBoxEmpresa.SelectedValue);
                MiUsuarioLocal.MiRol.IDUsuario = Convert.ToInt32(cBoxRolUsuario.SelectedValue);

                consultaPorCedula = MiUsuarioLocal.ConsultarPorCedula();
                consultaPorNombreUsuario = MiUsuarioLocal.ConsultarPorNombreUsuario();
                consultaPorEmail = MiUsuarioLocal.ConsultarPorEmail();

                // tarea
                // el correo si cumple requirimientos retorna con un BOOLEANO TRUE
                validarEmail= Validaciones.validarFormatoCorreo(MiUsuarioLocal.Email);

                // la contrasenia si cumple requerimientos retorna con un BOOLEANO TRUE
                validarContrasenia = Validaciones.validarFormatoContrasenia(MiUsuarioLocal.Contrasenia);


                if (!consultaPorCedula && !consultaPorNombreUsuario && !consultaPorEmail && validarEmail && validarContrasenia)
                {
                    string sms = string.Format("Esta seguro de agregar al usuario: {0}?", MiUsuarioLocal.Nombre);

                    DialogResult respuesta = MessageBox.Show(sms, "???", MessageBoxButtons.YesNo);

                    if  (respuesta == DialogResult.Yes)
                    {

                        //si las 3 validaciones son negativas, agregamos el usuario
                        bool Ok = MiUsuarioLocal.Agregar();

                        if (Ok)
                        {
                            MessageBox.Show("Usuario agregado correctamente", ":)", MessageBoxButtons.OK);
                            LimpiarFormulario();
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar el usuario", ":(", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    if (consultaPorCedula)
                    {
                        MessageBox.Show("Error ya existe un usuario con cedula digitada", "Error de validacion", MessageBoxButtons.OK);
                    }

                    if (consultaPorNombreUsuario)
                    {
                        MessageBox.Show("Error ya existe un usuario nombre usuario digitado", "Error de validacion", MessageBoxButtons.OK);
                    }

                    if (consultaPorEmail)
                    {
                        MessageBox.Show("Error ya existe un usuario con el email digitado", "Error de validacion", MessageBoxButtons.OK);
                    }

                    if (!validarEmail)
                    {
                        MessageBox.Show("Error en el correo", "Error de validacion", MessageBoxButtons.OK);

                    }

                    if (!validarContrasenia)
                    {
                        MessageBox.Show("Error en la contrasenia", "Error de validacion", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private bool validarCamposRequridos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(txtCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(txtCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(txtNombreUsuario.Text.Trim()) &&
                !string.IsNullOrEmpty(txtEmail.Text.Trim()) &&
                !string.IsNullOrEmpty(txtContrasenia.Text.Trim()) &&
                cBoxEmpresa.SelectedIndex > -1 &&
                cBoxRolUsuario.SelectedIndex > -1)
            {
                R = true;
            }
            else
            {
                // se le informa al usuario que validacion esta fallando
                // estas validaciones en negativo 

                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el nombre", "Error de validacion", MessageBoxButtons.OK);
                    txtNombre.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtCedula .Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la cedula", "Error de validacion", MessageBoxButtons.OK);
                    txtCedula.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtNombreUsuario.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la nombre de usuario", "Error de validacion", MessageBoxButtons.OK);
                    txtNombreUsuario.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el correo", "Error de validacion", MessageBoxButtons.OK);
                    txtEmail.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtContrasenia.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la contrasenia", "Error de validacion", MessageBoxButtons.OK);
                    txtContrasenia.Focus();
                    return false;
                }

                //validaciones de combobox

                if(cBoxEmpresa.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una empresa", "Error de validacion", MessageBoxButtons.OK);
                    cBoxEmpresa.Focus();
                    return false;
                }

                if (cBoxRolUsuario.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un rol de usuario", "Error de validacion", MessageBoxButtons.OK);
                    cBoxRolUsuario.Focus();
                    return false;
                }
            }
            return R;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtNombreUsuario.Clear();
            txtEmail.Clear();
            txtContrasenia.Clear();
            cBoxRolUsuario.SelectedIndex = -1;
            cBoxEmpresa.SelectedIndex = -1; 
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, true);
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, false, true);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text.Trim()) &&
                txtBuscar.Text.Count() > 2)
            {
                LlenarListaUsuarios();
            }
            else if (string.IsNullOrEmpty(txtBuscar.Text.Trim()))
                {
                    LlenarListaUsuarios();
                }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Validaciones.validarFormatoCorreo(txtEmail.Text);
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            Validaciones.validarFormatoContrasenia(txtContrasenia.Text);
        }
    }
}
