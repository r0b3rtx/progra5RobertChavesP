using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cliente
    {

        //atributos simples
        public int IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }

        //En este caso hay un atributo compuesto que une la clase Cliente con
        //la clase Empresa. Esto debido a la lectura de la relacion
        //que existe desde el diagrama entidad-relacion.

        //Atributos Complejos
        public Empresa MiEmpresa { get; set; }

        //Cuando tratamos atributos complejos, estos normalmente se definen como
        //cualquier propiedad, pero esa prop no esta instanciada
        //por lo tanto, se debe instanciar en el constructor de la clase

        public Cliente()
        {
            //este es el constructor de la clase.
            MiEmpresa = new Empresa();
        }



        //funciones y metodos
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

        public Cliente ConsultarPorID()
        {
            Cliente R = new Cliente();

            //TODO: en este caso el retorno es del mismo tipo de la clase
            // por lo tanto hay que llenar los atributos con los datos
            //que entrega un SP Select

            return R;
        }

        public Cliente ConsultarPorCedula()
        {
            Cliente R = new Cliente();

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
