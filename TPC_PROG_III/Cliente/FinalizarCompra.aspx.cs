using Dominio;
using Negocio;
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
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    txtNombre.Text = usuario.Cliente.Nombre;
                    txtApellido.Text = usuario.Cliente.Apellido;
                    txtEmail.Text = usuario.Cliente.Email;
                    txtDocumento.Text = usuario.Cliente.Documento.ToString();
                }
            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (!chkTerminos.Checked)
            {
                lblMensaje.Text = "Debe aceptar los términos y condiciones.";
                return;
            }

            Dominio.Carrito carrito = Session["carrito"] as Dominio.Carrito;

            if (carrito == null || carrito.Items == null || carrito.Items.Count == 0)
            {
                lblMensaje.Text = "El carrito está vacío.";
                return;
            }

            int documento;
            if (!int.TryParse(txtDocumento.Text, out documento))
            {
                lblMensaje.Text = "El documento debe ser un número válido.";
                return;
            }

            // Guardar en BD: Crea una nueva Venta y sus Detalles
            VentaNegocio negocio = new VentaNegocio();
            bool exito = negocio.RegistrarVenta(txtNombre.Text, txtApellido.Text, txtEmail.Text, 
                                                documento, txtDireccion.Text, 
                                                ddlMetodoPago.SelectedValue, carrito.Items);

            if (exito)
            {
                Session["carrito"] = null;
                Response.Redirect("ConfirmacionCompra.aspx");
            }
            else
            {
                lblMensaje.Text = "Hubo un error al registrar la compra.";
            }
        }

    }
}