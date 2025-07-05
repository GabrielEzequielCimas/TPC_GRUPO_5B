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
    public partial class AdminEditoriales : Page
    {
        protected bool VerificarSeleccion()
        {
            if (dgvEditorial.SelectedIndex == -1)
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
                EditorialNegocio Negocio = new EditorialNegocio();
                dgvEditorial.DataSource = Negocio.ListarEditorial();
                dgvEditorial.DataBind();
            }
        }
        protected void dgvEditorial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkSelect = (LinkButton)e.Row.FindControl("lnkSelect");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackEventReference(lnkSelect, "");
                e.Row.Attributes["style"] = "cursor:pointer;";
            }
        }

        protected void dgvEditorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dgvEditorial.SelectedRow;
            string id = selectedRow.Cells[0].Text;
            string descripcion = selectedRow.Cells[1].Text;
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            EditorialNegocio Negocio = new EditorialNegocio();
            dgvEditorial.DataSource = Negocio.ListarEditorial(filtro);
            dgvEditorial.DataBind();

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvEditorial.SelectedRow;
            EditorialNegocio Negocio = new EditorialNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            Negocio.Modificar(id, txtModificar.Text.Trim());
            dgvEditorial.DataSource = Negocio.ListarEditorial();
            dgvEditorial.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            EditorialNegocio Negocio = new EditorialNegocio();
            if (Negocio.Existe(txtAgregar.Text.Trim()) == false)
            {
                Negocio.Agregar(txtAgregar.Text.Trim());
                dgvEditorial.DataSource = Negocio.ListarEditorial();
                dgvEditorial.DataBind();
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvEditorial.SelectedRow;
            EditorialNegocio Negocio = new EditorialNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            Negocio.Desactivar(id);
            dgvEditorial.DataSource = Negocio.ListarEditorial();
            dgvEditorial.DataBind();
        }
        
        protected void btnActivar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvEditorial.SelectedRow;
            EditorialNegocio Negocio = new EditorialNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            Negocio.Activar(id);
            dgvEditorial.DataSource = Negocio.ListarEditorial();
            dgvEditorial.DataBind();
        }
    }
}