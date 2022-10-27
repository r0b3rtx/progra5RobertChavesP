using System;
using System.Collections.Generic;
using System.Data;
//using System.Diagnostics;
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

        public Usuario MiUsuario { get; set; }

        public FacturaTipo MiTipoFactura { get; set; }

        public List<FacturaInventario> Detalle { get; set; }    

        public Factura()
        {
            MiCliente = new Cliente();
            MiUsuario = new Usuario();
            MiTipoFactura = new FacturaTipo();
            Detalle = new List<FacturaInventario>();

            Fecha = DateTime.Now;
        }


       
        // funciones y metodos
        public int Agregar()
        {
            int R = 0;

            //TODO: ejecutar un SP que contenga la instruccion
            //INSERT correspondiente y retornar TRUE si
            //todo sale bien

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
    }
}
