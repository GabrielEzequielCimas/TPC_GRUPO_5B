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

            int pagina = 1;
            if (Request.QueryString["pagina"] != null)
                pagina = int.Parse(Request.QueryString["pagina"]);

            int cantidadPorPagina = 100; // Cambiá según cuántos mostrar
            int skip = (pagina - 1) * cantidadPorPagina;

            var libros = negocio.ListarPaginado(skip, cantidadPorPagina);

            if (Session["Usuario"] != null)
            {
                FavoritoNegocio favorito = new FavoritoNegocio();
                Usuario usuario = (Usuario)Session["Usuario"];
                int idCliente = usuario.Cliente.Id;
                var favoritos = favorito.ListarFavoritos(idCliente).Select(f => f.IdLibro).ToList();
                foreach (var libro in libros)
                {
                    libro.Favorito = favoritos.Contains(libro.Id);
                }
            }

            Session["Libros"] = libros;
            rptLibros.DataSource = libros;
            rptLibros.DataBind();

            generarPaginacion(pagina);
        }

        private void generarPaginacion(int paginaActual)
        {
            LibroNegocio negocio = new LibroNegocio();
            int totalLibros = negocio.ContarLibros();
            int cantidadPorPagina = 100;
            int totalPaginas = (int)Math.Ceiling((decimal)totalLibros / cantidadPorPagina);

            // Construir HTML
            string paginacionHtml = "<div class='paginacion'>";
            for (int i = 1; i <= totalPaginas; i++)
            {
                if (i == paginaActual)
                {
                    paginacionHtml += $"<span class='pagina-actual'>{i}</span>";
                }
                else
                {
                    paginacionHtml += $"<a href='Catalogo.aspx?pagina={i}'>{i}</a>";
                }
            }
            paginacionHtml += "</div>";

            litPaginacion.Text = paginacionHtml;
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
            LibroNegocio negocio = new LibroNegocio();

            string titulo = txtBusqueda.Text.Trim();
            string autor = ddlAutor.SelectedValue;
            string genero = ddlGenero.SelectedValue;
            string ordenPrecio = ddlOrdenPrecio.SelectedValue;

            if (autor == "Filtrar por autor") autor = "";
            if (genero == "Filtrar por género") genero = "";

            var filtrados = negocio.ListarFiltrado(titulo, autor, genero, ordenPrecio);

            rptLibros.DataSource = filtrados;
            rptLibros.DataBind();
        }

        protected void rptLibros_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "MarcarFavorito")
            {
                if (Session["Usuario"] != null)
                {
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    int idLibro = Convert.ToInt32(e.CommandArgument);
                    Usuario usuario = (Usuario)Session["Usuario"];
                    //usuarioNegocio.ExisteUsuario
                    string Nombre = usuario.Cliente.Nombre;
                    int IdCliente = usuario.Cliente.Id;
                    negocio.SetearFav(IdCliente, idLibro);
                    cargarLibros();
                }
            }
            if (e.CommandName == "VerDetalle")
            {
                int idLibro = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetalleLibro.aspx?id=" + idLibro);
            }
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");
        }
    }

}