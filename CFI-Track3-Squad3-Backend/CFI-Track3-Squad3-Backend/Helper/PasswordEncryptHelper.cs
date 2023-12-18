// Clase de utilidad para encriptación de contraseñas

using System.Security.Cryptography;
using System.Text;

namespace CFI_Track3_Squad3_Backend.Helper
{
    public static class PasswordEncryptHelper
    {
        /// <summary>
        /// Encripta la contraseña utilizando SHA-256 con un salt generado a partir del correo electrónico.
        /// </summary>
        /// <param name="password">Contraseña a encriptar.</param>
        /// <param name="email">Correo electrónico asociado a la contraseña.</param>
        /// <returns>Contraseña encriptada.</returns>
        public static string EncryptPassword(string password, string email)
        {
            var salt = CreateSalt(email);
            string saltAndPwd = string.Concat(password, salt);
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            var stream = Array.Empty<byte>();
            var sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(saltAndPwd));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Crea un salt a partir del correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico para generar el salt.</param>
        /// <returns>Salt generado.</returns>
        private static string CreateSalt(string email)
        {
            var salt = email;
            byte[] saltBytes;
            string saltStr;
            saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
            long XORED = 0x00;

            foreach (int x in saltBytes)
            {
                XORED = XORED ^ x;
            }

            Random rand = new Random(Convert.ToInt32(XORED));
            saltStr = rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();

            return saltStr;
        }
    }
}
