using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        public Cliente ConsultarPorID(int pIdCliente)
        {
            Cliente R = new Cliente();

            //TODO: en este caso el retorno es del mismo tipo de la clase
            // por lo tanto hay que llenar los atributos con los datos
            //que entrega un SP Select

            Conexion MiCnn = new Conexion();

            MiCnn.ListaParametros.Add(new SqlParameter("@ID", this.IDCliente));

            DataTable DataCliente = new DataTable();

            DataCliente = MiCnn.EjecutarSelect("SPClienteConsultarPorID");

            //una vez tenemos un datable con la data procedemos a llenar 
            //propiedades del objeto de reterno
            //IDCliente, Cedula, Nombre, CorreoElectronico,
            //Telefono, Direccion, Activo, IDEmpresa
            if (DataCliente != null && DataCliente.Rows.Count > 0)
            {
                DataRow Fila = DataCliente.Rows[0];

                R.IDCliente = Convert.ToInt32(Fila["IDUsuario"]);
                R.Nombre = Convert.ToString(Fila["Nombre"]);
                R.Cedula = Convert.ToString(Fila["Cedula"]);
                R.CorreoElectronico = Convert.ToString(Fila["CorreoElectronico"]);
                R.Telefono = Convert.ToString(Fila["Telefono"]);
                R.Direccion = Convert.ToString(Fila["Direccion"]);
                R.Activo = Convert.ToBoolean(Fila["Activo"]);
                R.MiEmpresa.IDEmpresa = Convert.ToInt32(Fila["IDEmpresa"]);
            }

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

        public DataTable Listar(bool VerActivos = true, string Filtro = "")
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            MiCnn.ListaParametros.Add(new SqlParameter("@FiltroBusqueda", Filtro));

            R = MiCnn.EjecutarSelect("SPClienteListar");

            return R;
        }

    }
}
