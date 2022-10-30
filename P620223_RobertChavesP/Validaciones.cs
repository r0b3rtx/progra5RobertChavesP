using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//librerias importadas para la tarea
//validaciones correo contrasenia

// uso de regex fuente----https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-7.0
using System.Text.RegularExpressions;

namespace P620223_RobertChavesP
{
    public static class Validaciones
    {

        private static char g_Gen_DecimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString());

        public static bool CaracteresTexto(System.Windows.Forms.KeyPressEventArgs c, bool Mayusculas = false, bool Minisculas = false)
        {
            bool ret = false;

            if (Mayusculas)
            { c.KeyChar = char.ToUpper(c.KeyChar); }

            if (Minisculas)
            { c.KeyChar = char.ToLower(c.KeyChar); }

            if (!(char.IsLetterOrDigit(c.KeyChar)) & !(char.IsPunctuation(c.KeyChar)) & !(c.KeyChar == Convert.ToChar(Keys.Back)) & !(c.KeyChar == Convert.ToChar(Keys.Space)) & !(c.KeyChar == Convert.ToChar(Keys.Enter)))
                ret = true;
            else
                ret = false;
            return
            ret;

        }

        public static bool CaracteresNumeros(System.Windows.Forms.KeyPressEventArgs c, bool SoloEnteros = true)
        {
            //En el caso que presione enter acepta el valor y devuelve True
            int Asc = (int)Keys.Enter;

            if (c.KeyChar == Asc)
            {
                return true;
            }
            if (SoloEnteros == false)
            {
                if (c.KeyChar.ToString() == (".") | c.KeyChar.ToString() == (","))
                {
                    c.KeyChar = g_Gen_DecimalSeparator;
                    return false;
                }
            }

            if (!(char.IsDigit(c.KeyChar)) & !(c.KeyChar == Convert.ToChar(Keys.Back)) & !(c.KeyChar == Convert.ToChar(Keys.Enter)))
            { return true; }
            else
            { return false; }

        }

        public static string DateFormat(DateTime pDate, bool ISO_Format = false)
        {
            string s = string.Empty;

            try
            {
                if (ISO_Format)
                {
                    string yyyy;
                    string mm;
                    string dd;
                    int i_mm = pDate.Month;
                    int i_dd = pDate.Day;

                    if (i_mm < 10)
                    {
                        mm = "0" + i_mm.ToString();
                    }
                    else
                    {
                        mm = i_mm.ToString();
                    }

                    if (i_dd < 10)
                    {
                        dd = "0" + i_dd.ToString();
                    }
                    else
                    {
                        dd = i_dd.ToString();
                    }

                    yyyy = pDate.Year.ToString();

                    s = yyyy + mm + dd;
                }
                else
                {
                    s = string.Format("{0:dd/MMMM/yyyy}", pDate.Date);
                }
            }
            catch (Exception e)
            {
                s = e.ToString();
            }

            return s;
        }


        public static string FormatoHora(DateTime pDate)
        {
            string h;

            h = pDate.ToLongTimeString();

            return h;
        }

        //tarea
        //validar correo
        public static bool validarFormatoCorreo(string email){
            bool R = false;

            string patronCorreoRequerido = @"[a-zA-Z0-9\._-]{2,25}.[@].[a-z]{2,12}.(com|org|net|co\.in|ac\.cr|ch)$";

            Regex validarEmail = new Regex(patronCorreoRequerido);

            R = validarEmail.IsMatch(email);

            if (!R)
            {
                MessageBox.Show("Error el correo no cuenta con las caracteristicas correctas", "Error de validacion", MessageBoxButtons.OK);
            }

            return R;
        }

        //validar contrasenia
        public static bool validarFormatoContrasenia(string contrasenia){
            bool R = false;

            if (contrasenia.Length > 7){
                string patronContraseniaRequerido = @"[a-z A-Z 0-9][/ * ! : ; > % $ & } ) ( { # @ < - + = _ ~]";

                Regex validarContrasenia = new Regex(patronContraseniaRequerido);

                R = validarContrasenia.IsMatch(contrasenia);
            }

            if (!R)
            {
                MessageBox.Show("Error la contrasenia se forma de 8 caracteres, mayusculas, minusculas, numeros y caracteres especiales", "Error de validacion", MessageBoxButtons.OK);
            }

            return R;
        }

    }
}
