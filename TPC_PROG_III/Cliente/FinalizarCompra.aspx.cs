using Dominio;
using Negocio;
using System;
//using MercadoPago;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III.Cliente
{
    public partial class FinalizarCompra : Page
    {
        public void EnviarFactura(Dominio.Cliente cliente, Dominio.Carrito carrito, string direccion, string metodoPago)
        {
            EmailService email = new EmailService();
            string htmlFactura = $@"
            <html>
            <body style='font-family: Arial;'>
                <h2>Factura</h2>
                <p><strong>Cliente:</strong> {cliente.Nombre} {cliente.Apellido}</p>
                <p><strong>Email:</strong> {cliente.Email}</p>
                <p><strong>Documento:</strong> {cliente.Documento}</p>
                <p><strong>Dirección:</strong> {direccion}</p>
                <p><strong>Método de Pago:</strong> {metodoPago}</p>
                <br />
                <table border='1' cellpadding='5' cellspacing='0'>
                    <tr><th>Producto</th><th>Cantidad</th><th>Precio Unitario</th><th>Subtotal</th></tr>";

            foreach (ItemCarrito item in carrito.Items)
            {
                htmlFactura += $"<tr><td>{item.Libro.Titulo}</td><td>{item.Cantidad}</td><td>${item.Libro.Precio:N2}</td><td>${item.Precio:N2}</td></tr>";
            }

            htmlFactura += $@"
                </table>
                <br />
                <h3>Total: ${carrito.Subtotal:N2}</h3>
            </body>
            </html>";

            email.armarCorreoHtml(cliente.Email, "Factura de compra - Librería Online", htmlFactura);

            //email.IsBodyHtml = true;
            email.enviarEmail();
        }
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
            if (documento <= 0 || txtDocumento.Text.Length < 8)
            {
                lblMensaje.Text = "El documento debe tener al menos 8 dígitos y ser positivo.";
                return;
            }

            if (string.IsNullOrEmpty(ddlMetodoPago.SelectedValue))
            {
                lblMensaje.Text = "Debe seleccionar un método de pago.";
                return;
            }

            // Guardar en BD: Crea una nueva Venta y sus Detalles
            VentaNegocio negocio = new VentaNegocio();
            bool exito = negocio.RegistrarVenta(txtNombre.Text, txtApellido.Text, txtEmail.Text,
                                                documento, txtDireccion.Text,
                                                ddlMetodoPago.SelectedValue, carrito.Items);
            if (exito) Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            if (exito)
            {
                if (ddlMetodoPago.SelectedValue == "Mercado Pago")
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    int finUrl = url.LastIndexOf("/");
                    url = url.Remove(finUrl + 1);

                    //MercadoPagoNegocio mp = new MercadoPagoNegocio(url);
                    //string urlMP = mp.PagarMercadoPago(carrito);
                    //Response.Redirect(urlMP);
                }
                else
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    EnviarFactura(usuario.Cliente,carrito,txtDireccion.Text, ddlMetodoPago.SelectedValue);
                    Session["carrito"] = null;
                    Response.Redirect("ConfirmacionCompra.aspx");
                }
            }
            else
            {
                lblMensaje.Text = "Hubo un error al registrar la compra.";
            }
        }

    }
}