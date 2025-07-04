using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using accesoDatos;
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
            // Cargar autores seleccionados
            foreach (ListItem item in chkAutores.Items)
                item.Selected = false;

            foreach (Autor autor in Seleccionado.Autores)
            {
                ListItem item = chkAutores.Items.FindByValue(autor.Id.ToString());
                if (item != null)
                    item.Selected = true;
            }
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

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvLibro.SelectedRow;
            LibroNegocio negocio = new LibroNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            negocio.Desactivar(id);
            dgvLibro.DataSource = negocio.Listar();
            dgvLibro.DataBind();
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            if (VerificarSeleccion()) return;
            GridViewRow fila = dgvLibro.SelectedRow;
            LibroNegocio negocio = new LibroNegocio();
            int id = Convert.ToInt32(fila.Cells[0].Text);
            negocio.Activar(id);
            dgvLibro.DataSource = negocio.Listar();
            dgvLibro.DataBind();
        }
        protected Libro CargarObjeto()
        {
            Libro Generado = new Libro();
            Generado.Codigo = txtCodigo.Text;
            Generado.Titulo = txtTitulo.Text;
            Generado.Descripcion = txtDescripcion.Text;

            decimal.TryParse(txtPrecio.Text, out decimal precio);
            Generado.Precio = precio;

            int.TryParse(txtStock.Text, out int stock);
            Generado.Stock = stock;

            int.TryParse(txtPaginas.Text, out int paginas);
            Generado.Paginas = paginas;

            Generado.Imagen = txtUrl.Text;

            Generado.Editorial = new Editorial();
            Generado.Editorial.Id = int.Parse(ddlEditoriales.SelectedValue);

            Generado.Genero = new Genero();
            Generado.Genero.Id = int.Parse(ddlGeneros.SelectedValue);
            Generado.Genero.IdSubgenero = int.Parse(ddlSubGeneros.SelectedValue);

            List<Autor> autoresSeleccionados = new List<Autor>();

            foreach (ListItem item in chkAutores.Items)
            {
                if (item.Selected)
                {
                    Autor autor = new Autor();
                    autor.Id = int.Parse(item.Value);
                    autoresSeleccionados.Add(autor);
                }
            }
            Generado.Autores = autoresSeleccionados;
            return Generado;
        }
        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
        private bool ValidarCampos(bool modificar)
        {
            int id = 0;
            if (modificar == true)
            {
                GridViewRow fila = dgvLibro.SelectedRow;
                if (dgvLibro.SelectedIndex != -1)
                {
                    id = Convert.ToInt32(fila.Cells[0].Text);
                }
            }
            LibroNegocio negocio = new LibroNegocio();
            int respuesta = 0;
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MostrarError("El campo Código es obligatorio.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MostrarError("El campo Título es obligatorio.");
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                MostrarError("El precio debe ser un número válido.");
                return false;
            }
            if (!int.TryParse(txtStock.Text, out _))
            {
                MostrarError("El stock debe ser un número entero.");
                return false;
            }
            if (!int.TryParse(txtPaginas.Text, out _))
            {
                MostrarError("Las páginas deben ser un número entero.");
                return false;
            }
            if (ddlEditoriales.SelectedIndex == 0)
            {
                MostrarError("Debe seleccionar una editorial.");
                return false;
            }
            if (ddlGeneros.SelectedIndex == 0 || ddlSubGeneros.SelectedIndex == 0)
            {
                MostrarError("Debe seleccionar un género y subgénero.");
                return false;
            }
            if (!chkAutores.Items.Cast<ListItem>().Any(item => item.Selected))
            {
                MostrarError("Debe seleccionar al menos un autor.");
                return false;
            }
            string codigo = txtCodigo.Text;
            string titulo = txtTitulo.Text;
            int idEditorial = int.Parse(ddlEditoriales.SelectedValue);
            respuesta = negocio.Validar(id, codigo, titulo, idEditorial);
            if (respuesta == 1 || respuesta == 2)
            {
                if (respuesta == 1) MostrarError("El codigo ya existe.");
                if (respuesta == 2) MostrarError("El titulo ya existe para esa editorial");
                return false;
            }
            // Si pasa todas las validaciones
            return true;
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!ValidarCampos(true))
                return;
            LibroNegocio negocio = new LibroNegocio();
            Libro modificado = CargarObjeto();
            modificado.Id = Convert.ToInt32(dgvLibro.SelectedRow.Cells[0].Text);
            negocio.Modificar(modificado);
            dgvLibro.DataSource = negocio.Listar();
            dgvLibro.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!ValidarCampos(false))
                return;
            LibroNegocio negocio = new LibroNegocio();
            Libro nuevo = CargarObjeto();
            negocio.Agregar(nuevo);
            dgvLibro.DataSource = negocio.Listar();
            dgvLibro.DataBind();
        }
        

    }
}