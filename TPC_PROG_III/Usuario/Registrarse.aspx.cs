using accesoDatos;
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III
{
    public partial class Registrarse : Page {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool ValidarMail(string nombre, string email, string password, string confirmar)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmar))
            {
                Response.Write("<script>alert('Todos los campos son obligatorios');</script>");
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                Response.Write("<script>alert('El correo electrónico no es válido');</script>");
                return false;
            }

            if (password.Length < 6)
            {
                Response.Write("<script>alert('La contraseña debe tener al menos 6 caracteres');</script>");
                return false;
            }

            if (password != confirmar)
            {
                Response.Write("<script>alert('Las contraseñas no coinciden');</script>");
                return false;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            if (negocio.ExisteUsuario(email))
            {
                Response.Write("<script>alert('Este email ya está registrado');</script>");
                return false;
            }
            return true;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmar = txtConfirmar.Text.Trim();
            if (!ValidarMail(nombre, email, password, confirmar)) return;
            
            Usuario nuevo = new Usuario(email, password, TipoUsuario.CLIENTE);

            nuevo.Cliente = new Dominio.Cliente
            {
                Nombre = nombre,
                Apellido = "",
                Documento = null,
                Email = email,
                Direccion = null
            };
            //-------------------------verificar con mail
            EmailService emailService = new EmailService();
            string codigo = emailService.GenerarCodigo();

            // guardar codigo y mail
            Session["codigoVerificacion"] = codigo;
            Session["emailPendiente"] = email;

            // Envio el correo
            emailService.ValidarCorreo(email, codigo);

            // Redirigir a una página para ingresar el código
            Response.Redirect("/Cliente/VerificarCode.aspx");
            ///------------------------------
            UsuarioNegocio negocio = new UsuarioNegocio();
            //negocio.Registrar(nuevo);
            //Response.Redirect("/usuario/IniciarSesion.aspx");
        }
    }
}