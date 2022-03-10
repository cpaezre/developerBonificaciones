using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonificaciones
{
    class Utilidades
    {
        public static String QuitarTildes(String texto)
        {
            //-----------------------------------
            texto = texto.Replace("%40", "@");
            texto = texto.Replace("%3F", "Ñ");
            texto = texto.Replace("%3f", "ñ");
            texto = texto.Replace('Á', 'A');
            texto = texto.Replace('á', 'a');
            texto = texto.Replace('É', 'E');
            texto = texto.Replace('é', 'e');
            texto = texto.Replace('Í', 'I');
            texto = texto.Replace('í', 'i');
            texto = texto.Replace('Ó', 'O');
            texto = texto.Replace('ó', 'o');
            texto = texto.Replace('Ú', 'U');
            texto = texto.Replace('ú', 'u');
            texto = texto.Replace('?', 'ñ');
            texto = texto.Replace('+', ' ');
            texto = texto.Replace("%u00f1", "ñ");
            texto = texto.Replace("%u00d1", "Ñ");
            texto = texto.Replace("%u00e1", "a");
            texto = texto.Replace("%u00c1", "A");
            texto = texto.Replace("%u00e9", "e");
            texto = texto.Replace("%u00c9", "E");
            texto = texto.Replace("%u00ed", "i");
            texto = texto.Replace("%u00cd", "I");
            texto = texto.Replace("%u00f3", "o");
            texto = texto.Replace("%u00d3", "O");
            texto = texto.Replace("%u00fa", "u");
            texto = texto.Replace("%u00da", "U");
            //-----------------------------------           
            return texto;
        }

        public static double ConvertirPorcentaje(double numero)
        {
            int valor = Convert.ToInt32(numero / 100);
            return valor;
        }
    }
}
