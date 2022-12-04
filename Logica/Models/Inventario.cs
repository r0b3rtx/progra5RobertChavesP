using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Inventario
    {

        public int IDInventario { get; set; }

        public string NombreItem { get; set; }

        public string CodigoBarras { get; set; }

        public decimal Costo { get; set; }

        public decimal PrecioVenta { get; set; }

        public decimal CantidadEnStock { get; set; }

        public bool Activo { get; set; }

        // atributos compuestos

        public Empresa MiEmpresa { get; set; }

        public Categoria MiCategoria { get; set; }

        public Impuesto MiImpuesto { get; set; }

        //como la relacion contra los proveedores (por medio de la tabla
        //de muchos a muchos) termina en *, quiere decir qu podrian haber
        //varios proveedores que ofrecen un item, y por lo tanto el atributo 
        //es multivaluado, se debe usar List<>

        public List<InventarioProveedor> ListadoProveedores { get; set; }

        public Inventario()
        {
            MiEmpresa = new Empresa();
            MiCategoria = new Categoria();
            MiImpuesto = new Impuesto();
            ListadoProveedores = new List<InventarioProveedor>();
            Activo = true;
        }


        // funciones y metodos
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
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public Inventario ConsultarPorID()
        {
            //en las eliminaciones logicas, lo que haremos sera cambiar el valor del
            //campo Activo a 0 (false)

            Inventario R = new Inventario();

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool ConsultarPorCodigoBarras(int IDEmpresa)
        {
            //en las eliminaciones logicas, lo que haremos sera cambiar el valor del
            //campo Activo a 0 (false)

            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public DataTable Listar(bool VerActivos = true)
        {
            DataTable R = new DataTable();

            Conexion MyCnn = new Conexion();

            R = MyCnn.EjecutarSelect("SPInventarioListar");

            return R;
        }

        public DataTable ListarProveedores()
        {
            DataTable R = new DataTable();


            return R;
        }

        public bool AgregarProveedor()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //INSERT correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool EliminarProveedor()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool ModificarPrecioProveedor()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

    }
}
