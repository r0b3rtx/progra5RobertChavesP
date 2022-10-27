using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Proveedor
    {
        // atributos
        public int IDProveedor { get; set; }

        public string Nombre { get; set; }

        public string Cedula { get; set; }

        public string Direccion { get; set; }

        public string Notas { get; set; }

        public bool Activo { get; set; }

        //las funciones y metodos (operaciones)
        public bool Agregar()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //INSERT correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool Modificar()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool Eliminar()
        {
            //en las eliminaciones logicas, lo que haremos sera cambiar el valor del
            //campo Activo a 0 (false)
            //todo sale bien

            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //SELECT correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool ConsultarPorCedula()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //SELECT correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public DataTable Listar(bool VerActivos = true)
        {
            DataTable R = new DataTable();

            //TODO: Usar SP con parametro para ver proveedores elimiandos o activos
            

            return R;
        }
    }
}
