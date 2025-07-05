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
    public partial class AdminAutores : Page
    {
        protected bool VerificarSeleccion()
        {
            if (dgvAutor.SelectedIndex == -1)
            {
                MostrarError("Seleccione un autor");
                return true;
            }
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/usuario/IniciarSesion.aspx");
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
                AutorNegocio Negocio = new AutorNegocio();
                dgvAutor.DataSource = Negocio.ListarAutor();
                dgvAutor.DataBind();
            }
        }
        protected void dgvAutor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkSelect = (LinkButton)e.Row.FindControl("lnkSelect");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackEventReference(lnkSelect, "");
                e.Row.Attributes["style"] = "cursor:pointer;";
            }
        }

        protected void dgvAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dgvAutor.SelectedRow;
            string id = selectedRow.Cells[0].Text;
            string descripcion = selectedRow.Cells[1].Text;
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            AutorNegocio Negocio = new AutorNegocio();
            dgvAutor.DataSource = Negocio.ListarAutor(filtro);
            dgvAutor.DataBind();

        }
        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvAutor.SelectedRow;
            AutorNegocio Negocio = new AutorNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            if (txtModificar.Text.Trim() == "")
            {
                MostrarError("Debe ingresar un Autor");
                return;
            }
            if (Negocio.Validar(id, txtModificar.Text.Trim()) == false)
            {
                MostrarError("El Autor ingresado ya existe");
                return;
            }
            Negocio.Modificar(id, txtModificar.Text.Trim());
            dgvAutor.DataSource = Negocio.ListarAutor();
            dgvAutor.DataBind();
        }
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AutorNegocio Negocio = new AutorNegocio();
            if (txtAgregar.Text.Trim() == "")
            {
                MostrarError("Debe ingresar un Autor");
                return;
            }
            if (Negocio.Validar(0, txtAgregar.Text.Trim()) == false)
            {
                MostrarError("El Autor ingresado ya existe");
                return;
            }
            Negocio.Agregar(txtAgregar.Text.Trim());
            dgvAutor.DataSource = Negocio.ListarAutor();
            dgvAutor.DataBind();
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvAutor.SelectedRow;
            AutorNegocio Negocio = new AutorNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            Negocio.Desactivar(id);
            dgvAutor.DataSource = Negocio.ListarAutor();
            dgvAutor.DataBind();
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvAutor.SelectedRow;
            AutorNegocio Negocio = new AutorNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            Negocio.Activar(id);
            dgvAutor.DataSource = Negocio.ListarAutor();
            dgvAutor.DataBind();
        }
    }
}