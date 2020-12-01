using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace DA.SS
{
    /// <summary>
    /// Clase DigitoVerificador
    /// </summary>
    public static class DigitoVerificador
    {
 
        /// <summary>
        /// Crear un hash en formato MD5 de la cadena suministrada
        /// </summary>
        /// <param name="cadena">Cadena a partir de la que se creará el hash.</param>
        /// <returns></returns>
        public static string CrearHash(string cadena)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();

            byte[] data = Encoding.ASCII.GetBytes(cadena);
            data = provider.ComputeHash(data);

            string md5 = string.Empty;

            for (int i = 0; i < data.Length; i++)
                md5 += data[i].ToString("x2").ToLower();

            return md5;
        }

        public static string CalcularDvhDeFila(DataTable tabla, int row)
        {
            //Declaro un objeto string, para concatenar todos los campos de la tabla, excepto el ultimo que es el DVH
            string cadenaDeCampos = null;

            for (int columna = 0; columna <= tabla.Columns.Count - 2; columna++)
            {
                //Concateno las columnas
                cadenaDeCampos = cadenaDeCampos + tabla.Rows[row][columna];
            }

            //Calculo el DVH 
            string cadenaDvh = CrearHash(cadenaDeCampos);
            return cadenaDvh;
        }
    }
}
