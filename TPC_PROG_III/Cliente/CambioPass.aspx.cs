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
    public partial class CambioPass : System.Web.UI.Page
    {
        protected bool ValidarPass(string password,string confirmar)
        {
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
            return true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            if (ValidarPass(txtPassword.Text, txtConfirmar.Text))
            {
                var mail = Session["emailPendiente"].ToString();
                negocio.ActualizarPass(mail,txtPassword.Text);
                Response.Write("<script>alert('Se cambio de contraseña correctamente');</script>");
                Response.Redirect("/admin/InicioAdmin.aspx");
            }
        }
    }
}