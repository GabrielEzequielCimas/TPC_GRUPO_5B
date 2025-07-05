using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III
{
    public partial class MisCompras : Page
    {
        public List<Venta> ListaVentas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Usuario/IniciarSesion.aspx");
                return;
            }

            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario.Cliente == null)
            {
                Response.Write("<script>alert('No se encontró información del cliente.');</script>");
                return;
            }

            if (!IsPostBack)
            {
                CargarCompras(usuario.Cliente.Id);
            }
        }

        private void CargarCompras(int idCliente)
        {
            VentaNegocio negocio = new VentaNegocio();
            ListaVentas = negocio.ListarVentasPorCliente(idCliente);

            rptCompras.DataSource = ListaVentas;
            rptCompras.DataBind();
        }

        protected void rptCompras_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalles")
            {
                int idVenta = Convert.ToInt32(e.CommandArgument);

                if (IdVentaMostrada.HasValue && IdVentaMostrada.Value == idVenta)
                {
                    // Funcion Toggle
                    pnlDetalles.Visible = false;
                    IdVentaMostrada = null;
                }
                else
                {
                    VentaNegocio negocio = new VentaNegocio();
                    var detalles = negocio.ListarDetalleVenta(idVenta);

                    rptDetalles.DataSource = detalles;
                    rptDetalles.DataBind();

                    pnlDetalles.Visible = true;
                    IdVentaMostrada = idVenta;
                }
            }
        }
        private int? IdVentaMostrada
        {
            get { return ViewState["IdVentaMostrada"] != null ? (int?)ViewState["IdVentaMostrada"] : null; }
            set { ViewState["IdVentaMostrada"] = value; }
        }
    }
}
