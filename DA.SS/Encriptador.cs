using System;
using System.Security.Cryptography;

namespace DA.SS
{
    /// <summary>
    /// Clase para Encriptar
    /// </summary>
    public static class Encriptador
    {
        #region Atributos Privados

        /// <summary>
        /// The salt byte size
        /// </summary>
        private const int SaltByteSize = 24;
        /// <summary>
        /// The hash byte size
        /// </summary>
        private const int HashByteSize = 20; // to match the size of the PBKDF2-HMAC-SHA-1 hash 
        /// <summary>
        /// The PBKDF2 iterations
        /// </summary>
        private const int Pbkdf2Iterations = 1000;
        /// <summary>
        /// The iteration index
        /// </summary>
        private const int IterationIndex = 0;
        /// <summary>
        /// The salt index
        /// </summary>
        private const int SaltIndex = 1;
        /// <summary>
        /// The PBKDF2 index
        /// </summary>
        private const int Pbkdf2Index = 2;

        #endregion

        /// <summary>
        /// Encripta la cadena pasada por parametro.
        /// </summary>
        /// <param name="cadena">Cadena a encriptar.</param>
        /// <returns></returns>
        public static string EncriptarCadena(string cadena)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);

            var hash = GetPbkdf2Bytes(cadena, salt, Pbkdf2Iterations, HashByteSize);
            return Pbkdf2Iterations + ":" +
                   Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Vallida si la cadena sumistrada es igual a la cadena encriptada.
        /// </summary>
        /// <param name="cadena">Cadena a comparar.</param>
        /// <param name="cadenaEncriptada">Cadena encriptada.</param>
        /// <returns></returns>
        public static bool ValidarCadena(string cadena, string cadenaEncriptada)
        {
            char[] delimiter = { ':' };
            var split = cadenaEncriptada.Split(delimiter);
            var iterations = Int32.Parse(split[IterationIndex]);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[Pbkdf2Index]);

            var testHash = GetPbkdf2Bytes(cadena, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Slows the equals.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        /// <summary>
        /// Gets the PBKDF2 bytes.
        /// </summary>
        /// <param name="password">The cadena.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        /// <param name="outputBytes">The output bytes.</param>
        /// <returns></returns>
        private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

    }
}
