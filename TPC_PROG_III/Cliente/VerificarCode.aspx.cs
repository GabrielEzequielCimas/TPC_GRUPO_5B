using System;
using System.Collections.Generic;
using System.IO;
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
            if (Session["tipoCodigo"] == null) Response.Redirect("/usuario/IniciarSesion.aspx");
        }
        
        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txtCodigo.Text.Trim();
            string codigoCorrecto = Session["codigoVerificacion"]?.ToString();
            if (Session["tipoCodigo"] != null && Session["tipoCodigo"].ToString() == "Alta")
            {
                if (codigoIngresado == codigoCorrecto)
                {
                    Usuario usuario = (Usuario)Session["usuarioPendiente"];
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    negocio.Registrar(usuario);
                    Response.Redirect("/usuario/IniciarSesion.aspx");
                    // Limpiar sesión
                    Session.Remove("usuarioPendiente");
                    Session.Remove("codigoVerificacion");
                    Session.Remove("emailPendiente");
                    Session.Remove("tipoCodigo");
                    Response.Write("<script>alert('Código Validado correctamente');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Código incorrecto');</script>");
                }
            }
            else 
            {
                if (codigoIngresado == codigoCorrecto)
                {
                    Usuario usuario = (Usuario)Session["usuarioPendiente"];
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    //negocio.Registrar(usuario);
                    Response.Write("<script>alert('Código Validado correctamente');</script>");
                    Response.Redirect("/Cliente/CambioPass.aspx");
                    
                }
                else
                {
                    Response.Write("<script>alert('Código incorrecto');</script>");
                }
            }
            

        }
    }
}