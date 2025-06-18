using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_PROG_III.Cliente
{
    public partial class Catalogo : Page
    {
        public Filtro Filtro { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarLibros();
                cargarFiltros();
            }
        }

        private void cargarLibros()
        {
            LibroNegocio negocio = new LibroNegocio();
            var libros = negocio.Listar();

            Session["Libros"] = libros;
            rptLibros.DataSource = libros;
            rptLibros.DataBind();
        }

        private void cargarFiltros()
        {
            var libros = Session["Libros"] as List<Libro>;

            // Autores
            ddlAutor.DataSource = libros
                                    .Where(l => l.Autores != null) 
                                    .SelectMany(l => l.Autores)
                                    .Where(a => a != null)
                                    .Select(a => a.Nombre)
                                    .Where(nombre => !string.IsNullOrEmpty(nombre))
                                    .Distinct()
                                    .ToList();
            ddlAutor.DataBind();
            ddlAutor.Items.Insert(0, new ListItem("Filtrar por autor", ""));

            // Generos
            ddlGenero.DataSource = libros.Select(l => l.Genero.DescripcionGenero).Distinct().ToList();
            ddlGenero.DataBind();
            ddlGenero.Items.Insert(0, new ListItem("Filtrar por género", ""));
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            var libros = Session["Libros"] as List<Libro>;
            var filtrados = libros;

            // Por nombre
            if (!string.IsNullOrWhiteSpace(txtBusqueda.Text))
                filtrados = filtrados.Where(l => l.Titulo.ToLower().Contains(txtBusqueda.Text.ToLower())).ToList();

            // Por autor 
            if (!string.IsNullOrEmpty(ddlAutor.SelectedValue))
                filtrados = filtrados.Where(l => l.Autores.Any(a => a.Nombre == ddlAutor.SelectedValue)).ToList();

            // Por genero
            if (!string.IsNullOrEmpty(ddlGenero.SelectedValue))
                filtrados = filtrados.Where(l => l.Genero.DescripcionGenero == ddlGenero.SelectedValue).ToList();

            // Ordenamiento
            if (ddlOrdenPrecio.SelectedValue == "asc")
                filtrados = filtrados.OrderBy(l => l.Precio).ToList();
            else if (ddlOrdenPrecio.SelectedValue == "desc")
                filtrados = filtrados.OrderByDescending(l => l.Precio).ToList();

            rptLibros.DataSource = filtrados;
            rptLibros.DataBind();
        }   

        protected void rptLibros_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                int idLibro = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetalleLibro.aspx?id=" + idLibro);
            }
        }
    }

}