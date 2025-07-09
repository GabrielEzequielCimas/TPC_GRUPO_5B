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

        public EmailService()
        {
            server = new SmtpClient("live.smtp.mailtrap.io", 587);
            server.Credentials = new NetworkCredential("api", "99415a8b7f002d456b416b59070a2b6a");
            server.EnableSsl = true;
        }
        public void armarCorreo(string emaildestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noreply@libreriaonline.website");
            email.To.Add(emaildestino);
            email.Subject = asunto;
            email.Body = cuerpo;
            //email.Body = "<hi1>Envio</h1>";
        }
        public void enviarEmail()
        {
            //var from = "noreply@libreriaonline.website";
            //var to = "gabrielezequiel545@gmail.com";
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //noreply.libreriaonline@gmail.com
        //7D5AWEWVLY4CNW2ZQXJ9L5XGP
    }
}
