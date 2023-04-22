﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;
using System.IO;

namespace CapaNegocio
{
    public class CN_Recursos
    {

        public static string GenerarClave (){ //retorna una clave aleatoria de 6 digitos

            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);

            return clave;
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

        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("clentebanks0@gmail.com");
                mail.Subject = correo;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;


                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("clentebanks0@gmail.com", "voyscwfkjpqydfqy"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                };

                smtp.Send(mail);
                resultado = true;

            }
            catch (Exception ex)
            {

                resultado = false;
            }

            return resultado;
        }

    }
}
