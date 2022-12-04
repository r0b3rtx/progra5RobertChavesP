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
    public partial class FrmFacturacion : Form
    {

        //objetos locales
        public Logica.Models.Factura MiFacturaLocal { get; set; }

        public DataTable DtListaItems { get; set; }

        public FrmFacturacion()
        {
            InitializeComponent();

            MiFacturaLocal = new Logica.Models.Factura();

            DtListaItems = new DataTable();
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.MiFormPrincipal;

            LlenarComboTiposFactura();

            Limpiar();
        }

        private void Limpiar()
        {
            txtClienteID.Clear();
            LblClienteNombre.Text = string.Empty;
            txtNotas.Clear();
            cboxFacturaTipo.SelectedIndex = -1;

            txtSubTotal.Text = "0";
            txtDescuentos.Text = "0";
            txtImpuestos.Text = "0";
            txtTotal.Text = "0";

            DtListaItems = MiFacturaLocal.CargarEsquemaListaDetalle();

            DgvLista.DataSource = DtListaItems;
        }

        private void LlenarComboTiposFactura()
        {
            DataTable dt = new DataTable();

            dt = MiFacturaLocal.MiTipoFactura.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                cboxFacturaTipo.ValueMember = "ID";
                cboxFacturaTipo.DisplayMember = "D";
                cboxFacturaTipo.DataSource = dt;
                cboxFacturaTipo.SelectedIndex = -1;
            }
        }

        private void btnClienteBuscar_Click(object sender, EventArgs e)
        {
            //se crea una nueva instacia del form de busqueda de clientes
            //y se espera una respuesta del mismo.

            Form FormBusquedaCliente = new FrmClienteBuscar();

            DialogResult resp = FormBusquedaCliente.ShowDialog();

            if (resp == DialogResult.OK)
            {
                //cargar la info del usuario en la composicion de MiFacturaLocal
                //y ademas mostrar el nombre del usuario en el label

                if (!string.IsNullOrEmpty(txtClienteID.Text.Trim()) )
                {

                    int IdCliente = Convert.ToInt32(txtClienteID.Text.Trim());

                    //se incluyen  los datos en la composicion del cliente

                    MiFacturaLocal.MiCliente = MiFacturaLocal.MiCliente.ConsultarPorID(IdCliente);

                    LblClienteNombre.Text = MiFacturaLocal.MiCliente.Nombre;

                }
            }


        }

        private void MnuAgregarItem_Click(object sender, EventArgs e)
        {
            Form FormBuscarItem = new FrmInventarioBuscar();

            DialogResult resp = FormBuscarItem.ShowDialog();

            if (resp == DialogResult.OK)
            {
                //TODO: totalizar

                DgvLista.DataSource = DtListaItems;
                DgvLista.ClearSelection();

                Totalizar();
            }
        }


        private void Totalizar()
        {
            decimal SubTotal = 0;
            decimal Descuentos = 0;
            decimal Impuestos = 0;
            decimal Total = 0;

            if(DtListaItems.Rows.Count > 0)
            {
                foreach (DataRow item in DtListaItems.Rows)
                {
                    SubTotal += Convert.ToDecimal(item["SubTotal"]);
                    Descuentos += Convert.ToDecimal(item["DescuentoTotal"]);
                    Impuestos += Convert.ToDecimal(item["ImpuestosTotal"]);
                    Total += Convert.ToDecimal(item["TotalLinea"]);
                }
            }

            txtSubTotal.Text = string.Format("{0:N2}", SubTotal);
            txtDescuentos.Text = string.Format("{0:N2}", Descuentos);
            txtImpuestos.Text = string.Format("{0:N2}", Impuestos);
            txtTotal.Text = string.Format("{0:N2}", Total);
        }

        //btn Crear factura
        private void button1_Click(object sender, EventArgs e)
        {
            //validar requerimientos minimos
            if (ValidarFactura())
            {
                //cuando tenemos una estructura de encabezado-detalle
                //como la factura, primero debemos agregar el encabezado
                //en su tabla respectiva y obtener el ID que se genera
                //en el PK.
                //luego usando ese ID se recorre la lista del detalle
                //y se hace el INSERT en la tabla de detalle con el FK = ID

                MiFacturaLocal.MiTipoFactura.IDFacturaTipo = Convert.ToInt32(cboxFacturaTipo.SelectedValue);
                MiFacturaLocal.MiCliente.IDCliente = Convert.ToInt32(txtClienteID.Text.Trim());
                //como el nombre del clientes o el nombre del tipo de factura no son necesarios para hacer el insert
                ///se pueden omitir en este punto.

                MiFacturaLocal.MiUsuario.IDUsuario = Globales.MiUsuarioGlobal.IDUsuario;

                MiFacturaLocal.Notas = txtNotas.Text.Trim();

                CargarDetalleFactura();

                if(MiFacturaLocal.Agregar() > 0)
                {
                    MessageBox.Show("Factura procesada correctamente", ":)", MessageBoxButtons.OK);

                    //TODO: Presentar graficamente un reporte de la factura en formato POS (punto de venta)

                    Limpiar();
                }
            }
        }

        private void CargarDetalleFactura()
        {

            foreach (DataRow item in DtListaItems.Rows)
            {

                Logica.Models.FacturaInventario detalle = new Logica.Models.FacturaInventario();

                detalle.MiInventario.IDInventario = Convert.ToInt32(item["IDInventario"]); ;
                detalle.Costo = 0; //TODO: deberiamos  agregar el valor de costo, se puede  hacer por medio de una funcion
                detalle.PrecioVenta = Convert.ToDecimal(item["PrecioVenta"]);
                detalle.Cantidad = Convert.ToDecimal(item["Cantidad"]);
                detalle.PorcentajeImpuesto = Convert.ToDecimal(item["TasaImpuesto"]);
                detalle.PorcentajeDescuento = Convert.ToDecimal(item["PorcentajeDescuento"]);
                detalle.Subtotal = Convert.ToDecimal(item["SubTotal"]);
                detalle.DescuentoTotal = Convert.ToDecimal(item["DescuentoTotal"]);
                detalle.SubTotal2 = Convert.ToDecimal(item["SubTotal2"]);
                detalle.ImpuestoTotal = Convert.ToDecimal(item["ImpuestosTotal"]);
                detalle.TotalLinea = Convert.ToDecimal(item["TotalLinea"]);

                //una vez llenamos los datos del detalle se agrega a la factura local.

                MiFacturaLocal.Detalle.Add(detalle);
            }

        }

        private bool ValidarFactura()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(LblClienteNombre.Text.Trim()) &&
                cboxFacturaTipo.SelectedIndex > -1 &&
                DtListaItems.Rows.Count > 0)
            {
                R = true;
            }
            //TODO: validar casos contrarios con el else

            return R;
        }



    }
}
