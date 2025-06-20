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

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmar = txtConfirmar.Text.Trim();

            if (password != confirmar)
            {
                Response.Write("<script>alert('Las contraseñas no coinciden');</script>");
                return;
            }

            UsuarioNegocio negocio = new UsuarioNegocio();

            if (negocio.ExisteUsuario(email))
            {
                Response.Write("<script>alert('Este email ya está registrado');</script>");
                return;
            }

            Usuario nuevo = new Usuario(email, password, TipoUsuario.CLIENTE); 
            negocio.Registrar(nuevo);

            Response.Redirect("/usuario/IniciarSesion.aspx");
        }
    }
}