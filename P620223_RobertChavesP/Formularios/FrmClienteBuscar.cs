using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P620223_RobertChavesP.Formularios
{
    public partial class FrmClienteBuscar : Form
    {

        //objetos locales

        DataTable DtLista { get; set; }

        Logica.Models.Cliente MiClienteLocal { get; set; }

        public FrmClienteBuscar()
        {
            InitializeComponent();

            DtLista = new DataTable();

            MiClienteLocal = new Logica.Models.Cliente();   
        }

        private void FrmClienteBuscar_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            DtLista = new DataTable();
            DtLista = MiClienteLocal.Listar(true, txtBuscar.Text.Trim());

            DgvLista.DataSource = DtLista;


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscar.Text.Count() > 2 || string.IsNullOrEmpty(txtBuscar.Text.Trim()))
            {
                LlenarLista();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (DgvLista.SelectedRows.Count == 1)
            {

                DataGridViewRow FilaSeleccionada = DgvLista.SelectedRows[0];


                int IdCliente = Convert.ToInt32(FilaSeleccionada.Cells["CIDCliente"].Value);

                Globales.MiFormFacturacion.txtClienteID.Text = Convert.ToString(IdCliente);

                this.DialogResult = DialogResult.OK;


            }
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (DgvLista.SelectedRows.Count == 1)
            {

                DataGridViewRow fila = DgvLista.SelectedRows[0];

                decimal Precio = Convert.ToDecimal(fila.Cells["CPrecioVenta"].Value);
                decimal IVA = Convert.ToDecimal(fila.Cells["CTasaImpuesto"].Value);

                txtIVA.Text = IVA.ToString();
                txtPrecioUnitario
            }
            */
        }
    }
}
