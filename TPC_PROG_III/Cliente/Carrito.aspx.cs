using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III
{
    public partial class Carrito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                Dominio.Carrito carrito = Session["carrito"] as Dominio.Carrito;
                if (carrito != null && carrito.Items.Count > 0)
                {
                    rptCarrito.DataSource = carrito.Items;
                    rptCarrito.DataBind();

                    lblTotal.Text = "Total: $" + carrito.Subtotal.ToString("N2");
                }
                else
                {
                    lblTotal.Text = "El carrito está vacío.";
                }
            }
        }

        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Dominio.Carrito carrito = Session["carrito"] as Dominio.Carrito;
            if (carrito == null)
                return;

            int idLibro = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {
                var item = carrito.Items.FirstOrDefault(i => i.Libro.Id == idLibro);
                if (item != null)
                    carrito.Items.Remove(item);
            }
            else if (e.CommandName == "Actualizar")
            {
                // Obtener el TextBox con la cantidad
                TextBox txtCantidad = e.Item.FindControl("txtCantidad") as TextBox;
                if (txtCantidad != null)
                {
                    int nuevaCantidad;
                    if (int.TryParse(txtCantidad.Text, out nuevaCantidad) && nuevaCantidad > 0)
                    {
                        var item = carrito.Items.FirstOrDefault(i => i.Libro.Id == idLibro);
                        if (item != null)
                        {
                            item.Cantidad = nuevaCantidad;
                        }
                    }
                }
            }

            // Actualizar el carrito en sesion
            Session["carrito"] = carrito;

            // Recargar la pagina
            Response.Redirect(Request.RawUrl);
        }
        protected void btnVolverCatalogo_Click(object sender, EventArgs e)
        {
                Response.Redirect("~/Cliente/Catalogo.aspx");
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cliente/FinalizarCompra.aspx");
        }
    }
}