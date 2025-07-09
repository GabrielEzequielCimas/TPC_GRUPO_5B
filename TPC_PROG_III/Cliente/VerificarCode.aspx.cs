using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_PROG_III.Cliente
{
    public partial class VerificarCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txtCodigo.Text.Trim();
            string codigoCorrecto = Session["codigoVerificacion"]?.ToString();

            if (codigoIngresado == codigoCorrecto)
            {
                Usuario usuario = (Usuario)Session["usuarioPendiente"];
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Registrar(usuario);

                // Limpiar sesión
                Session.Remove("usuarioPendiente");
                Session.Remove("codigoVerificacion");
                Session.Remove("emailPendiente");

                Response.Redirect("/usuario/IniciarSesion.aspx");
            }
            else
            {
                Response.Write("<script>alert('Código incorrecto');</script>");
            }
        }
    }
}