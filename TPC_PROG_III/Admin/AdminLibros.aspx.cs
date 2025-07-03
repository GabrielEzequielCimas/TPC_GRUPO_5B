using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
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
                //DGV
                LibroNegocio Negocio = new LibroNegocio();
                EditorialNegocio Editorial = new EditorialNegocio();
                GeneroNegocio Genero = new GeneroNegocio();
                AutorNegocio Autor = new AutorNegocio();
                dgvLibro.DataSource = Negocio.Listar();
                dgvLibro.DataBind();
                //DDL Editorial
                ddlEditoriales.DataSource = Editorial.ListarEditorial();
                ddlEditoriales.DataTextField = "Descripcion";       
                ddlEditoriales.DataValueField = "Id"; 
                ddlEditoriales.DataBind();
                ddlEditoriales.Items.Insert(0, new ListItem("Seleccionar Editorial", ""));
                //DDL Genero
                ddlGeneros.DataSource = Genero.ListarGenero();
                ddlGeneros.DataTextField = "DescripcionGenero";
                ddlGeneros.DataValueField = "Id";
                ddlGeneros.DataBind();
                ddlGeneros.Items.Insert(0, new ListItem("Seleccionar Genero", ""));
                //DDL SubGenero
                ddlSubGeneros.DataSource = Genero.ListarSubGenero();
                ddlSubGeneros.DataTextField = "DescripcionSubGenero";
                ddlSubGeneros.DataValueField = "IdSubGenero";
                ddlSubGeneros.DataBind();
                ddlSubGeneros.Items.Insert(0, new ListItem("Seleccionar SubGenero", ""));
                //DDL Autores
                chkAutores.DataSource = Autor.ListarAutor();
                chkAutores.DataTextField = "Nombre";
                chkAutores.DataValueField = "Id";
                chkAutores.DataBind();
                //ddlCheckList.DataSource = Autor.ListarAutor();
                //ddlCheckList.DataTextField = "Nombre";
                //ddlCheckList.DataValueField = "Id";
                //ddlCheckList.DataBind();
                //ddlCheckList.Items.Insert(0, new ListItem("Seleccionar Autores", ""));
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
            Libro Seleccionado = new Libro();
            LibroNegocio Negocio = new LibroNegocio();
            GridViewRow selectedRow = dgvLibro.SelectedRow;
            string id = selectedRow.Cells[0].Text;
            string descripcion = selectedRow.Cells[1].Text;
            var filtrado = Negocio.Listar().Where(l => l.Id.ToString() == id).ToList();
            Seleccionado = filtrado[0];
            txtCodigo.Text = Seleccionado.Codigo;
            txtTitulo.Text = Seleccionado.Titulo;
            txtStock.Text = Seleccionado.Stock.ToString();
            txtPrecio.Text = Seleccionado.Precio.ToString();
            txtPaginas.Text = Seleccionado.Paginas.ToString();
            txtUrl.Text = Seleccionado.Imagen.ToString();
            txtDescripcion.Text = Seleccionado.Descripcion;
            ddlEditoriales.SelectedValue = Seleccionado.Editorial.Id.ToString();
            ddlGeneros.SelectedValue = Seleccionado.Genero.Id.ToString();
            ddlSubGeneros.SelectedValue = Seleccionado.Genero.IdSubgenero.ToString();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            LibroNegocio Negocio = new LibroNegocio();
            dgvLibro.DataSource = Negocio.Listar(filtro);
            dgvLibro.DataBind();
        }

        protected void ddlGeneros_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorSeleccionado = ddlGeneros.SelectedValue;
            if (!int.TryParse(valorSeleccionado, out int idSeleccionado))
                return;
            GeneroNegocio Genero = new GeneroNegocio();
            List <Genero> Lista = Genero.ListarSubGenero();
            var filtrado = Lista.Where(l => l.Id == idSeleccionado).ToList();
            ddlSubGeneros.DataSource = filtrado;
            ddlSubGeneros.DataTextField = "DescripcionSubGenero";
            ddlSubGeneros.DataValueField = "IdSubGenero";
            ddlSubGeneros.DataBind();
            ddlSubGeneros.Items.Insert(0, new ListItem("Seleccionar SubGenero", ""));
        }

        protected void ddlSubGeneros_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorSeleccionado = ddlSubGeneros.SelectedValue;
            if (!int.TryParse(valorSeleccionado, out int idSeleccionado))
                return;
            GeneroNegocio Genero = new GeneroNegocio();
            List<Genero> Lista = Genero.ListarSubGenero();
            var filtrado = Lista.Where(l => l.IdSubgenero == idSeleccionado).ToList();
            int id = filtrado[0].Id;
            ddlGeneros.SelectedValue = id.ToString();
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