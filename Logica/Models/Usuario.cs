using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Logica.Models
{
    public class Usuario
    {

        //atributos simples
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string CodigoRecuperacion { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        // atributos compuestos
        public Empresa MiEmpresa { get; set; }
        public UsuarioRol MiRol { get; set; }


        public Usuario()
        {
            MiEmpresa = new Empresa();
            MiRol = new UsuarioRol();
            Activo = true;
        }

        // metodos
        //funciones y metodos
        public bool Agregar()
        {
            bool R = false;

            Conexion MiConn = new Conexion();

            // lista parametros para el INSERT
            MiConn.ListaParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiConn.ListaParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiConn.ListaParametros.Add(new SqlParameter("@NombreUsuario", this.NombreUsuario));

            //TODO: se debe encriptar la contrasenia que se va a almacenar en la tabla usuario
            MiConn.ListaParametros.Add(new SqlParameter("@Contrasenia", this.Contrasenia));
            MiConn.ListaParametros.Add(new SqlParameter("@Email", this.Email));

            //parametros  para los FKs, normalmente son de objetos compuestos de la clase
            MiConn.ListaParametros.Add(new SqlParameter("@IDRol", this.MiRol.IDUsuario));
            MiConn.ListaParametros.Add(new SqlParameter("@IDEmpresa", this.MiEmpresa.IDEmpresa));

            int Resultado = MiConn.EjecutarUpdateDeleteInsert("SPUsuarioAgregar");
            if (Resultado > 0) {
                R = true;
            }

            return R;
        }

        public bool Modificar()
        {
            bool R = false;

            Conexion MiConn = new Conexion();

            // lista parametros para el INSERT
            MiConn.ListaParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiConn.ListaParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiConn.ListaParametros.Add(new SqlParameter("@NombreUsuario", this.NombreUsuario));

            //TODO: se debe encriptar la contrasenia que se va a almacenar en la tabla usuario
            MiConn.ListaParametros.Add(new SqlParameter("@Contrasenia", this.Contrasenia));
            MiConn.ListaParametros.Add(new SqlParameter("@Email", this.Email));

            //parametros  para los FKs, normalmente son de objetos compuestos de la clase
            MiConn.ListaParametros.Add(new SqlParameter("@IDRol", this.MiRol.IDUsuario));
            MiConn.ListaParametros.Add(new SqlParameter("@IDEmpresa", this.MiEmpresa.IDEmpresa));

            MiConn.ListaParametros.Add(new SqlParameter("@ID", this.IDUsuario));

            int Resultado = MiConn.EjecutarUpdateDeleteInsert("SPUsuarioModificar");

            if (Resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public bool Eliminar()
        {
            bool R = false;

            Conexion MiConn = new Conexion();

            MiConn.ListaParametros.Add(new SqlParameter("@ID", this.IDUsuario));

            int Resultado = MiConn.EjecutarUpdateDeleteInsert("SPUsuarioEliminar");

            if (Resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public bool Activar()
        {
            bool R = false;

            Conexion MiConn = new Conexion();

            MiConn.ListaParametros.Add(new SqlParameter("@ID", this.IDUsuario));

            int Resultado = MiConn.EjecutarUpdateDeleteInsert("SPUsuarioActivar");

            if (Resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorID(int pIDUsuario)
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaParametros.Add(new SqlParameter("@ID", pIDUsuario));

            DataTable DataUsuario = new DataTable();

            DataUsuario = MiCnn.EjecutarSelect("SPUsuarioConsultarPorID");

            if(DataUsuario != null && DataUsuario.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        
        public Usuario ConsultarPorIDD()
        {
            Usuario R = new Usuario();

            //TODO: en este caso el retorno es del mismo tipo de la clase
            // por lo tanto hay que llenar los atributos con los datos
            //que entrega un SP Select

            Conexion MiCnn = new Conexion();

            MiCnn.ListaParametros.Add(new SqlParameter("@ID", this.IDUsuario));

            DataTable DataUsuario = new DataTable();

            DataUsuario = MiCnn.EjecutarSelect("SPUsuarioConsultarPorID");

            //una vez tenemos un datable con la data procedemos a llenar 
            //propiedades del objeto de reterno

            if(DataUsuario != null && DataUsuario.Rows.Count > 0)
            {
                DataRow Fila = DataUsuario.Rows[0];

                R.IDUsuario = Convert.ToInt32(Fila["IDUsuario"]);
                R.Nombre = Convert.ToString(Fila["Nombre"]);
                R.Cedula = Convert.ToString(Fila["Cedula"]);
                R.NombreUsuario = Convert.ToString(Fila["NombreUsuario"]);
                R.Email = Convert.ToString(Fila["Email"]);
                R.Contrasenia = string.Empty;
                R.MiRol.IDUsuario = Convert.ToInt32(Fila["IDUsuarioRol"]);
                R.MiEmpresa.IDEmpresa = Convert.ToInt32(Fila["IDEmpresa"]);
                R.Activo = Convert.ToBoolean(Fila["Activo"]);
            }

            return R;
        }
        


        public bool ConsultarPorCedula()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            //como en este caso debemos evaluar por la cedula, hay que pasar 1 parametro al SP
            //de consulta
            MiCnn.ListaParametros.Add(new SqlParameter("@Cedula", this.Cedula));

            DataTable Consulta = MiCnn.EjecutarSelect("SPUsuarioConsultarPorCedula");

            if (Consulta != null && Consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorNombreUsuario()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaParametros.Add(new SqlParameter("@NombreUsuario", this.NombreUsuario));

            DataTable Consulta = MiCnn.EjecutarSelect("SPUsuarioConsultarPorNombreUsuario");

            if (Consulta != null && Consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorEmail()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaParametros.Add(new SqlParameter("@Email", this.Email));

            DataTable Consulta = MiCnn.EjecutarSelect("SPUsuarioConsultarPorEmail");

            if (Consulta != null && Consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }


        public DataTable Listar(bool VerActivos = true, string FiltroBusqueda = "")
        {
            DataTable R = new DataTable();

            //TODO: Usar SP con parametro para ver proveedores elimiandos o activos
            Conexion MiCnn = new Conexion();

            MiCnn.ListaParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            MiCnn.ListaParametros.Add(new SqlParameter("@FiltroBusqueda", FiltroBusqueda));

            R = MiCnn.EjecutarSelect("SPUsuarioListar");

            return R;
        }

       

        public bool ValidarLogin(string NombreUsuario, string Contrasenia)
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool EnviarCodigoRecuperacion(string Email)
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

        public bool ResetearContrasenia()
        {
            bool R = false;

            //TODO: ejecutar un SP que contenga la instruccion
            //UPDATE correspondiente y retornar TRUE si
            //todo sale bien

            return R;
        }

    }
}
