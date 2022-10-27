using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class UsuarioRol
    {

        public int IDUsuario { get; set; }

        public string Rol { get; set; }

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            //paso 2.1 y 2.2 de Seq Usuario Rol Listar

            Conexion MiCnn = new Conexion();

            //paso 2.3 y 2.4
            //No es  necesario explicar los  pasos dentro  de EjecutarSelect
            //Ya que como se va usar tantas veces no se veria bien explicar
            //
            R = MiCnn.EjecutarSelect("SPUsuarioRolListar");

            return R;
        }

    }
}
