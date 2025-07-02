using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III.Cliente
{
    public partial class FinalizarCompra : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["Usuario"] != null)
            //    {
            //        Usuario usuario = (Usuario)Session["Usuario"];
            //        txtNombre.Text = usuario.Nombre;
            //        txtApellido.Text = usuario.Apellido;
            //        txtEmail.Text = usuario.Email;
            //    }
            //}
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Guardar la venta en base de datos
                // Registrar la direccion y el metodo de pago
                // Limpiar el carrito

                // Pagina de Confirmación
                Response.Redirect("Confirmacion.aspx");
            }
        }
    }
}