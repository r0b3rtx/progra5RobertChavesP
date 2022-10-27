using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P620223_RobertChavesP
{
    public static class Globales
    {
        //los objetos que definamos en la clase
        //seran accesibles desde la totalidad
        //de la aplicacion ademas esta clase
        //al ser STATIC  se auto instancia


        //el siguiente formulario principal
        //se puede invocar desde cualquier lugar
        //login en esta caso

        //se puede invocar desde cualquier lugar (login en nuestro caso)
        public static Form MiFormPrincipal = new Formularios.FrmPrincipalMDI();

        public static Formularios.FrmUsuariosGestion MiFormMantUsuarios = new Formularios.FrmUsuariosGestion();
        


    }
}
