using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_PROG_III
{
    public partial class AdminLibros : Page
    {
        protected bool VerificarSeleccion()
        {
            if (dgvLibro.SelectedIndex == -1)
            {
                return true;
            }
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LibroNegocio Negocio = new LibroNegocio();
                dgvLibro.DataSource = Negocio.Listar();
                dgvLibro.DataBind();
            }
        }
        protected void dgvLibro_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkSelect = (LinkButton)e.Row.FindControl("lnkSelect");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackEventReference(lnkSelect, "");
                e.Row.Attributes["style"] = "cursor:pointer;";
            }
        }

        protected void dgvLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dgvLibro.SelectedRow;
            string id = selectedRow.Cells[0].Text;
            string descripcion = selectedRow.Cells[1].Text;
        }

        //protected void btnDesactivar_Click(object sender, EventArgs e)
        //{
        //    if (VerificarSeleccion()) return;
        //    GridViewRow fila = dgvLibro.SelectedRow;
        //    LibroNegocio Negocio = new LibroNegocio();
        //    int id = Convert.ToInt32(fila.Cells[0].Text);
        //    Negocio.Desactivar(id);
        //    dgvLibro.DataSource = Negocio.ListarLibro();
        //    dgvLibro.DataBind();
        //}

        //protected void btnActivar_Click(object sender, EventArgs e)
        //{
        //    if (VerificarSeleccion()) return;
        //    GridViewRow fila = dgvLibro.SelectedRow;
        //    LibroNegocio Negocio = new LibroNegocio();
        //    int id = Convert.ToInt32(fila.Cells[0].Text);
        //    Negocio.Activar(id);
        //    dgvLibro.DataSource = Negocio.ListarLibro();
        //    dgvLibro.DataBind();
        //}
    }
}