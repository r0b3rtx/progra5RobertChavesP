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
    public partial class FrmInventarioBuscar : Form
    {

        public DataTable DtLista { get; set; }
        public Logica.Models.Inventario MyLocalItem { get; set; }

        #region PropiedadesDeTotalizacion

        public decimal SubTotal1 { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal SubTotal2 { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal Total { get; set; }
        public decimal PrecioUnitario { get; set;}
        public decimal TasaImpuesto { get; set;}
        public decimal PorcentajeDescuento { get; set;}
        public decimal Cantidad { get; set;}

        #endregion

        public FrmInventarioBuscar()
        {
            InitializeComponent();

            DtLista = new DataTable();
            MyLocalItem = new Logica.Models.Inventario();   
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmInventarioBuscar_Load(object sender, EventArgs e)
        {
            CargarItems();
        }

        private void CargarItems()
        {
            DtLista = MyLocalItem.Listar();

            DgvLista.DataSource = DtLista;

            DgvLista.ClearSelection();
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Limpiar();

            if (DgvLista.SelectedRows.Count == 1)
            {
                DataGridViewRow fila = DgvLista.SelectedRows[0];

                decimal Precio = Convert.ToDecimal(fila.Cells["CPrecioVenta"].Value);
                decimal IVA = Convert.ToDecimal(fila.Cells["CTasaImpuesto"].Value);

                txtIva.Text = IVA.ToString();
                txtPrecioUnitario.Text = Precio.ToString();

                Calcular();
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescuento.Text.Trim()))
            {
                txtDescuento.Text = "0";
                txtDescuento.SelectAll();
            }
        }

        private void NudCantidad_Leave(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (ValidarDescuento())
            {
                Calcular();
            }
        }

        private void Calcular()
        {
            //Este metodo calcula los valores de  subtotal, descuento,  impuesto y total para la linea
            //Subtotal,  descuento, impuesto y total para la linea
            //en este caso, particular se debe validar que le descuento
            //no supere el  100%
            if (ValidarDescuento())
            {

                //TODO: limpiar prorpiedades de totalizacion
             
                Cantidad = Convert.ToDecimal(NudCantidad.Value);
                PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text.Trim());


                PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text.Trim());
                TasaImpuesto = Convert.ToDecimal(txtIva.Text.Trim());

                //1. Calculo del subtotales
                SubTotal1 = Cantidad * PrecioUnitario;

                if (PorcentajeDescuento > 0)
                {
                    TotalDescuento = (SubTotal1 * PorcentajeDescuento) / 100;
                }

                SubTotal2 = SubTotal1 - TotalDescuento;

                if (TasaImpuesto > 0)
                {
                    TotalImpuesto = (SubTotal2 * TasaImpuesto) / 100;
                }

                Total = SubTotal2 + TotalImpuesto;

                txtTotal.Text = string.Format("{0:N2}", Total);


            }

        }

        private void Limpiar()
        {
            SubTotal1 = 0;
            TotalDescuento = 0;
            SubTotal2 = 0;
            TotalImpuesto = 0;
            Total = 0;
            PrecioUnitario = 0;
            TasaImpuesto = 0;
            PorcentajeDescuento = 0;
            Cantidad = 0;

            NudCantidad.Value = 1;
            txtPrecioUnitario.Text = "0";
            txtDescuento.Text = "0";
            txtIva.Text = "0";
            txtTotal.Text = "0";
        }

        private bool ValidarDescuento()
        {
            bool R = false;

            try
            {


                if (!string.IsNullOrEmpty(txtDescuento.Text.Trim()) &&
                    Convert.ToDecimal(txtDescuento.Text.Trim()) >= 0 &&
                    Convert.ToDecimal(txtDescuento.Text.Trim()) <= 100)
                {
                    R = true;
                }
                else
                {
                    if(Convert.ToDecimal(txtDescuento.Text.Trim()) > 100)
                    {
                        MessageBox.Show("Los decuentos no se pueden  ser mayor a 100");
                        return false;
                    }
                    if (Convert.ToDecimal(txtDescuento.Text.Trim()) < 0)
                    {
                        MessageBox.Show("Los decuentos no se pueden  ser menor a 0");
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                txtDescuento.Text = "0";
                txtDescuento.SelectAll();
            }


            return R;
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, false);
            Calcular();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if(DgvLista.SelectedRows.Count == 1 &&
                !string.IsNullOrEmpty(txtTotal.Text.Trim()) &&
                Convert.ToDecimal(txtTotal.Text.Trim()) > 0)
            {
                DataGridViewRow r = DgvLista.SelectedRows[0];

                //estos 2 valores de leen directamente  de la seleccion del DGVLISTA
                //los demas ya los teniamos calculados en la props locales de totalizacion

                int IdItem = Convert.ToInt32(r.Cells["CIDInventario"].Value);
                string NombreItem = Convert.ToString(r.Cells["CNombreItem"].Value);

                DataRow NuevaFilaEnFacturacion = Globales.MiFormFacturacion.DtListaItems.NewRow();

                NuevaFilaEnFacturacion["IDInventario"] = IdItem;
                NuevaFilaEnFacturacion["NombreItem"] = NombreItem;
                NuevaFilaEnFacturacion["PrecioVenta"] = PrecioUnitario;

                NuevaFilaEnFacturacion["Cantidad"] = Cantidad;
                NuevaFilaEnFacturacion["TasaImpuesto"] = TasaImpuesto;
                NuevaFilaEnFacturacion["PorcentajeDescuento"] = PorcentajeDescuento;
                NuevaFilaEnFacturacion["SubTotal"] = SubTotal1;
                NuevaFilaEnFacturacion["SubTotal2"] = SubTotal2;
                NuevaFilaEnFacturacion["ImpuestosTotal"] = TotalImpuesto;
                NuevaFilaEnFacturacion["TotalLinea"] = Total;
                NuevaFilaEnFacturacion["DescuentoTotal"] = TotalDescuento;

                Globales.MiFormFacturacion.DtListaItems.Rows.Add(NuevaFilaEnFacturacion);

                this.DialogResult = DialogResult.OK;
            }
        }

        private void NudCantidad_ValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }
    }
}
