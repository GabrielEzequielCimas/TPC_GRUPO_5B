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
            if (e.CommandName == "Eliminar")
            {
                int idLibro = Convert.ToInt32(e.CommandArgument);
                Dominio.Carrito carrito = Session["carrito"] as Dominio.Carrito;
                if (carrito != null)
                {
                    var item = carrito.Items.FirstOrDefault(i => i.Libro.Id == idLibro);
                    if (item != null)
                    {
                        carrito.Items.Remove(item);
                        Session["carrito"] = carrito;
                    }
                }
                // Recargar la página
                Response.Redirect(Request.RawUrl);
            }
        }

    }
}