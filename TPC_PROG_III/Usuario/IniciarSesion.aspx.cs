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
    public partial class IniciarSesion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Por favor complete usuario y contraseña');</script>");
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.Loguear(email, password);

            if (usuario != null)
            {
                Session["usuario"] = usuario;

                // Redireccionar segun el tipo de usuario
                if (usuario.TipoUsuario == TipoUsuario.ADMIN)
                    Response.Redirect("/admin/InicioAdmin.aspx");
                else
                    Response.Redirect("/cliente/Default.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }
        }
    }
}