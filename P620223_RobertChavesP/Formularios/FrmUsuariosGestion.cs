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

            ActivarAgregar();
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
                            LimpiarTodo();

                            LlenarListaUsuarios();
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

        private bool validarCamposRequridos(bool OmitirContrasenia = false)
        {
            bool R = false;

            if (!string.IsNullOrEmpty(txtCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(txtCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(txtNombreUsuario.Text.Trim()) &&
                !string.IsNullOrEmpty(txtEmail.Text.Trim()) &&
                cBoxEmpresa.SelectedIndex > -1 &&
                cBoxRolUsuario.SelectedIndex > -1)
            {

                if (OmitirContrasenia)
                {
                    R = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtContrasenia.Text.Trim()))
                    {
                       R = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe digitar la contrasenia", "Error de validacion", MessageBoxButtons.OK);
                        txtContrasenia.Focus();
                        return false;
                    }
                }

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

                /*
                if (!OmitirContrasenia && string.IsNullOrEmpty(txtContrasenia.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la contrasenia", "Error de validacion", MessageBoxButtons.OK);
                    txtContrasenia.Focus();
                    return false;
                }
                */

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
            LimpiarTodo();
        }

        private void LimpiarTodo()
        {
            LimpiarFormulario();
            DgvLista.ClearSelection();
            MiUsuarioLocal = new Logica.Models.Usuario();
            ActivarAgregar();
        }

        private void ActivarAgregar()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void ActivarModificarEliminar()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
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

        //tarea
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Validaciones.validarFormatoCorreo(txtEmail.Text);
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            Validaciones.validarFormatoContrasenia(txtContrasenia.Text);
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cuando se selecciona un item de la lista se deben 
            //mostrar los datos en los campos del formulario
            //en este estado se puede cambiar la info y actualizar o 
            //eliminar un usuario

            if (DgvLista.SelectedRows.Count == 1)
            {
                LimpiarFormulario();

                DataGridViewRow MiFila = DgvLista.SelectedRows[0];

                int IdUsuario = Convert.ToInt32(MiFila.Cells["CIDUsuario"].Value);

                MiUsuarioLocal = new Logica.Models.Usuario();

                MiUsuarioLocal.IDUsuario = IdUsuario;

                //una vez tenemos el valor de id del  usuario, se llama al la funcion
                //de consultar por id, que entrega como retorno un objeto de tipo
                //usuario.
                //en este caso voy a reutilizar el objeto de usuario local para
                //cargar datos por medio de la funcion

                
                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorIDD();
                

                if(MiUsuarioLocal != null && MiUsuarioLocal.IDUsuario > 0)
                {
                    //una vez me aseguro  que le objeto tiene datos
                    //entonces se representan en pantalla

                    txtCodigo.Text = MiUsuarioLocal.IDUsuario.ToString();
                    txtNombre.Text = MiUsuarioLocal.Nombre;
                    txtCedula.Text = MiUsuarioLocal.Cedula;
                    txtNombreUsuario.Text = MiUsuarioLocal.NombreUsuario;
                    txtEmail.Text = MiUsuarioLocal.Email;

                    cBoxRolUsuario.SelectedValue = MiUsuarioLocal.MiRol.IDUsuario;
                    cBoxEmpresa.SelectedValue = MiUsuarioLocal.MiEmpresa.IDEmpresa;

                    cbVerActivo.Checked = MiUsuarioLocal.Activo;

                    ActivarModificarEliminar();
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //se deben validar los  datos minimos

            if (validarCamposRequridos(true))
            {
                MiUsuarioLocal.Nombre = txtNombre.Text.Trim();
                MiUsuarioLocal.Cedula = txtCedula.Text.Trim();
                MiUsuarioLocal.NombreUsuario = txtNombreUsuario.Text.Trim();
                MiUsuarioLocal.Email = txtEmail.Text.Trim();
                MiUsuarioLocal.Contrasenia = txtContrasenia.Text.Trim();

                MiUsuarioLocal.MiRol.IDUsuario = Convert.ToInt32(cBoxRolUsuario.SelectedValue);
                MiUsuarioLocal.MiEmpresa.IDEmpresa = Convert.ToInt32(cBoxEmpresa.SelectedValue);

                if (MiUsuarioLocal.ConsultarPorID(MiUsuarioLocal.IDUsuario))
                {

                    DialogResult Respuesta = MessageBox.Show("Seguro de modificar al usuario?", "???", 
                                                MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question);

                    if(Respuesta == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Modificar())
                        {
                            MessageBox.Show("Usuario modificado correctamente!", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarTodo();
                            LlenarListaUsuarios();
                        }
                    }

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (validarCamposRequridos(true))
            {

                if (MiUsuarioLocal.ConsultarPorID(MiUsuarioLocal.IDUsuario))
                {

                    if (cbVerActivos.Checked)
                    {
                        DialogResult Respuesta = MessageBox.Show("Seguro de eliminar al usuario?", "???",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

                        if (Respuesta == DialogResult.Yes)
                        {
                            if (MiUsuarioLocal.Eliminar())
                            {
                                MessageBox.Show("Usuario eliminado correctamente!", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LimpiarTodo();
                                LlenarListaUsuarios();
                            }
                        }
                    }
                    else
                    {
                        DialogResult Respuesta = MessageBox.Show("Seguro de activar al usuario?", "???",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

                        if (Respuesta == DialogResult.Yes)
                        {
                            if (MiUsuarioLocal.Activar())
                            {
                                MessageBox.Show("Usuario activado correctamente!", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LimpiarTodo();
                                LlenarListaUsuarios();
                            }
                        }
                    }

                    

                }
            }
        }

        private void cbVerActivos_CheckedChanged(object sender, EventArgs e)
        {

            LlenarListaUsuarios();

            if (cbVerActivos.Checked)
            {
                btnEliminar.Text = "Eliminar";
            }
            else
            {
                btnEliminar.Text = "Activar";
            }

        }
    }
}
