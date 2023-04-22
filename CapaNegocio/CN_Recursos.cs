using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Recursos
    {

        public static string GenerarClave (){

            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);


        }

        //encriptacio del TEXTO en SHA256

        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            //usar la referencia del "sytem.security.cryptography"
            using(SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach(byte b in result)
       
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
