using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica.Models
{
    public class Categoria
    {
        //primero describimos las propiedades simple
        public int IDCategoria { get; set; }
        public string NombreCategoria { get; set; }

        //las funciones y metodos (operaciones)
        public DataTable Listar()
        {
            DataTable R = new DataTable();

            //TODO: hay que programar la llamada al SP que retorna datos

            return R;
        }
    }
}
