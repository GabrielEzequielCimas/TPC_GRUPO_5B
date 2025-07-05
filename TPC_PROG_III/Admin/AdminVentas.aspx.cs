using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_PROG_III
{
    public partial class AdminVentas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validar usuario logueado
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/usuario/IniciarSesion.aspx");
                    return;
                }

                Usuario usuario = (Usuario)Session["Usuario"];
                if (usuario.TipoUsuario != TipoUsuario.ADMIN)
                {
                    Response.Redirect("/Cliente/Default.aspx");
                    return;
                }

                CargarVentas();
            }
        }

        private void CargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            dgvVentas.DataSource = negocio.ListarVentas();
            dgvVentas.DataBind();
        }

        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idVenta = Convert.ToInt32(dgvVentas.SelectedRow.Cells[0].Text);
            CargarDetalle(idVenta);
        }

        private void CargarDetalle(int idVenta)
        {
            VentaNegocio negocio = new VentaNegocio();
            dgvDetalle.DataSource = negocio.ListarDetalleVenta(idVenta);
            dgvDetalle.DataBind();
        }
    }
}
