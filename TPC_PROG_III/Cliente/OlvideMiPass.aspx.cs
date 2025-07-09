using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_PROG_III.Cliente
{
    public partial class OlvideMiPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected bool ValidarMail(string mail)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            if (!mail.Contains("@") || !mail.Contains("."))
            {
                Response.Write("<script>alert('El correo electrónico no es válido');</script>");
                return false;
            }
            if (!negocio.ExisteUsuario(mail))
            {
                Response.Write("<script>alert('Este email no está registrado');</script>");
                return false;
            }
            return true;
        }
        protected void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            if(ValidarMail(txtEmail.Text) == true)
            {
                EmailService emailService = new EmailService();
                string codigo = emailService.GenerarCodigo();

                // guardar codigo y mail
                Session["codigoVerificacion"] = codigo;
                Session["emailPendiente"] = txtEmail.Text;
                Session["tipoCodigo"] = "Modificacion";

                // Envio el correo
                emailService.ValidarCorreo(txtEmail.Text, codigo);
                Response.Redirect("/cliente/VerificarCode.aspx");
            }
        }
    }
}