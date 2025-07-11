using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_PROG_III
{
    public partial class UpdateDirecciones : System.Web.UI.Page
    {
        private DireccionNegocio direccionNegocio = new DireccionNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idDireccion))
                {
                    hfIdDireccion.Value = idDireccion.ToString();
                    CargarProvincias();

                    Direccion direccion = direccionNegocio.ListarPorCliente(((Usuario)Session["Usuario"]).Cliente.Id)
                        .Find(d => d.IdDireccion == idDireccion);

                    if (direccion != null)
                    {
                        ddlProvincias.SelectedValue = direccion.Provincia;
                        CargarLocalidades(direccion.IdProvincia);
                        ddlLocalidades.SelectedValue = direccion.IdLocalidad.ToString();
                    }
                }
            }
        }

        private void CargarProvincias()
        {
            ddlProvincias.DataSource = direccionNegocio.ListarProvincias();
            ddlProvincias.DataBind();
        }

        private void CargarLocalidades(int provincia)
        {
            ddlLocalidades.DataSource = direccionNegocio.ListarLocalidadesPorProvincia(provincia);
            ddlLocalidades.DataTextField = "Nombre";
            ddlLocalidades.DataValueField = "Id";
            ddlLocalidades.DataBind();
        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvincias.SelectedValue);
            CargarLocalidades(idProvincia);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Direccion direccion = new Direccion
                {
                    IdDireccion = int.Parse(hfIdDireccion.Value),
                    IdCliente = ((Usuario)Session["Usuario"]).Cliente.Id,
                    IdProvincia = int.Parse(ddlProvincias.SelectedValue),
                    IdLocalidad = int.Parse(ddlLocalidades.SelectedValue)
                };

                direccionNegocio.ActualizarDireccion(direccion);
                lblMensaje.Text = "Dirección actualizada correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar la dirección.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}