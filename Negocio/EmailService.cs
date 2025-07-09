using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        public string GenerarCodigo()
        {
            Random rnd = new Random();
            int codigo = rnd.Next(100000, 999999); 
            return codigo.ToString();
        }
        public EmailService()
        {
            server = new SmtpClient("live.smtp.mailtrap.io", 587);
            server.Credentials = new NetworkCredential("api", "99415a8b7f002d456b416b59070a2b6a");
            server.EnableSsl = true;
        }
        public void ValidarCorreo(string correoDestino, string codigo)
        {
            string asunto = "Código de verificación";
            string cuerpo = $"<p>Tu código de verificación es: <b>{codigo}</b></p>";

            MailMessage email = new MailMessage();
            email.From = new MailAddress("noreply@libreriaonline.website");
            email.To.Add(correoDestino);
            email.Subject = asunto;
            email.Body = cuerpo;
            email.IsBodyHtml = true;

            SmtpClient server = new SmtpClient("live.smtp.mailtrap.io", 587);
            server.Credentials = new NetworkCredential("api", "99415a8b7f002d456b416b59070a2b6a");
            server.EnableSsl = true;

            server.Send(email);
        }
        public void armarCorreo(string emaildestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noreply@libreriaonline.website");
            email.To.Add(emaildestino);
            email.Subject = asunto;
            email.Body = cuerpo;
        }
        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
