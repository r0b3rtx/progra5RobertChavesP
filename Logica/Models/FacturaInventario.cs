using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class FacturaInventario
    {

        public decimal Costo { get; set; }

        public decimal PrecioVenta { get; set; }

        public decimal Cantidad { get; set; }

        public decimal PorcentajeImpuesto { get; set; }

        public decimal PorcentajeDescuento { get; set; }

        public decimal Subtotal { get; set; } // suma de cantidad * precio venta

        public decimal DescuentoTotal { get; set; }

        public decimal SubTotal2 { get; set; } //subtotal - descuento total

        public decimal ImpuestoTotal { get; set; }

        public decimal TotalLinea { get; set; } //subtotal2 + impuesto total

        //atributos compuestos
        public Inventario MiInventario { get; set; }

        public FacturaInventario()
        {
            MiInventario = new Inventario();
        }

        // Crear funiciones para la mate de totalizaciones para no tener
        //que usar en la clase principal

        public decimal TotalizarLinea()
        {
            //decimal R = 0;

            //totalizar subtotal
            Subtotal = Cantidad * PrecioVenta;

            //monto del descuento
            DescuentoTotal = (Subtotal * PorcentajeDescuento) / 100;

            //subtotal2
            SubTotal2 = Subtotal - DescuentoTotal;

            //monto del impuesto
            ImpuestoTotal = (SubTotal2 * PorcentajeImpuesto) / 100;

            //total final
            TotalLinea = SubTotal2 + ImpuestoTotal;

            return TotalLinea;
        }

    }
}
