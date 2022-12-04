using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Factura : FacturaBase
    {

        // atributos simples
        public int IDFactura { get; set; }

        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public string Notas { get; set; }

        // atributos compuestos

        public Cliente MiCliente { get; set; }

        public Usuario MiUsuarioo { get; set; }

        public FacturaTipo MiTipoFactura { get; set; }

        public List<FacturaInventario> Detalle { get; set; }    

        public Factura()
        {
            MiCliente = new Cliente();
            MiUsuarioo = new Usuario();
            MiTipoFactura = new FacturaTipo();
            Detalle = new List<FacturaInventario>();

            Fecha = DateTime.Now;
        }


       
        // funciones y metodos
        public int Agregar()
        {
            int R = 0;

            Conexion MiCnn = new Conexion();

            //parametros para el encabezado
            MiCnn.ListaParametros.Add(new SqlParameter("@IDCliente", this.MiCliente.IDCliente));
            MiCnn.ListaParametros.Add(new SqlParameter("@IDUsuario", this.MiUsuario.IDUsuario));
            MiCnn.ListaParametros.Add(new SqlParameter("@IDTipoFactura", this.MiTipoFactura.IDFacturaTipo));
            MiCnn.ListaParametros.Add(new SqlParameter("@Notas", this.Notas));

            object retorno = MiCnn.EjecutarConRetornoEscalar("SPFacturaAgregar");

            if(retorno != null)
            {
                this.IDFactura = Convert.ToInt32(retorno.ToString());

                //ahora tenemos lo necesario para agregar los detalles
                int Acumulador = 0;

                foreach (FacturaInventario item in this.Detalle)
                {
                    Conexion MiCnnDetalle = new Conexion();

                    //2 Foreign keys
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@IDFactura", this.IDFactura));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@IDInventario", item.MiInventario.IDInventario));

                    //resto de columnas
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@Costo", item.Costo));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@PrecioVenta", item.PrecioVenta));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@PorcentajeImpuesto", item.PorcentajeImpuesto));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@PorcentajeDescuento", item.PorcentajeDescuento));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@SubTotal", item.Subtotal));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@DescuentoTotal", item.DescuentoTotal));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@SubTotal2", item.SubTotal2));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@ImpuestoTotal", item.ImpuestoTotal));
                    MiCnnDetalle.ListaParametros.Add(new SqlParameter("@TotalLinea", item.TotalLinea));

                    MiCnnDetalle.EjecutarUpdateDeleteInsert("SPFacturaAgregarDetalle");

                    Acumulador += 1;
                }

                R = Acumulador;

            }

            return R;
        }

        // funciones y metodos
        public bool Imprimir()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //INSERT correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public DataTable ListarPorFechas(DateTime FechaInicial, DateTime FechaFinal)
        {
            DataTable R = new DataTable();


            return R;
        }

        public DataTable CargarEsquemaListaDetalle()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            R = MiCnn.EjecutarSelect("SPFacturaDetalleEsquema", true);

            R.PrimaryKey = null;



            return R;
        }
    }
}
