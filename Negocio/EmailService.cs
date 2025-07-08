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
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("no_reply_LibreriaOnline@outlook.com", "mntfsubesrxtqfre");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.office365.com";
        }
        public void armarCorreo(string emaildestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("no_reply_LibreriaOnline@outlook.com");
            email.To.Add(emaildestino);
            email.Subject = asunto;
            email.Body = cuerpo;
            //email.Body = "<hi1>Envio</h1>";
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
