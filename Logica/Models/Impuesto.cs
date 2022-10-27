using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Impuesto
    {

        //primero atributos simples
        public int IDImpuesto { get; set; }

        public string CodImpuesto { get; set; }

        public string NombreImpuesto { get; set; }

        public decimal TasaImpuesto { get; set; }

        //Funciones y metodos
        public DataTable Listar()
        {
            DataTable R = new DataTable();

            //TODO: darle funcionalidad

            return R;
        }

    }
}
