using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III
{
    public partial class AdminGeneros : Page
    {
        protected bool VerificarSeleccion()
        {
            if (dgvGenero.SelectedIndex == -1)
            {
                return true;
            }
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Usuario/IniciarSesion.aspx");
                return;
            }

            Usuario usuario = (Usuario)Session["Usuario"];

            // Validar si es ADMIN
            if (usuario.TipoUsuario != TipoUsuario.ADMIN)
            {
                Response.Redirect("/Cliente/Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                GeneroNegocio Negocio = new GeneroNegocio();
                dgvGenero.DataSource = Negocio.ListarGenero();
                dgvGenero.DataBind();
            }
        }
        protected void dgvGenero_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkSelect = (LinkButton)e.Row.FindControl("lnkSelect");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackEventReference(lnkSelect, "");
                e.Row.Attributes["style"] = "cursor:pointer;";
            }
        }

        protected void dgvGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dgvGenero.SelectedRow;
            string id = selectedRow.Cells[0].Text;
            string descripcion = selectedRow.Cells[1].Text;
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            GeneroNegocio Negocio = new GeneroNegocio();
            dgvGenero.DataSource = Negocio.ListarGenero(filtro);
            dgvGenero.DataBind();

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvGenero.SelectedRow;
            GeneroNegocio Negocio = new GeneroNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            Negocio.Modificar(id, txtModificar.Text.Trim());
            dgvGenero.DataSource = Negocio.ListarGenero();
            dgvGenero.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            GeneroNegocio Negocio = new GeneroNegocio();
            if (Negocio.Existe(txtAgregar.Text.Trim()) == false)
            {
                Negocio.Agregar(txtAgregar.Text.Trim());
                dgvGenero.DataSource = Negocio.ListarGenero();
                dgvGenero.DataBind();
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvGenero.SelectedRow;
            GeneroNegocio Negocio = new GeneroNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            Negocio.Desactivar(id);
            dgvGenero.DataSource = Negocio.ListarGenero();
            dgvGenero.DataBind();
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvGenero.SelectedRow;
            GeneroNegocio Negocio = new GeneroNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            Negocio.Activar(id);
            dgvGenero.DataSource = Negocio.ListarGenero();
            dgvGenero.DataBind();
        }
    }
}