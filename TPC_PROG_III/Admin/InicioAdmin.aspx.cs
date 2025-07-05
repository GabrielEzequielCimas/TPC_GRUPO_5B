using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III
{
    public partial class InicioAdmin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/usuario/IniciarSesion.aspx");
                return;
            }

            Usuario usuario = (Usuario)Session["Usuario"];

            // Validar si es ADMIN
            if (usuario.TipoUsuario != TipoUsuario.ADMIN)
            {
                Response.Redirect("/Cliente/Default.aspx");
                return;
            }
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Admin.aspx");
        }
    }
}