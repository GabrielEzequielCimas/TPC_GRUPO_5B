using System;
using System.Linq;
using System.Web.UI;
using Dominio;
using Negocio;

namespace TPC_PROG_III
{
    public partial class DetalleLibro : Page
    {
        private int LibroId
        {
            get
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                    return id;
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLibro();
            }
        }

        private void CargarLibro()
        {
            if (LibroId <= 0)
            {
                lblTitulo.Text = "ID inválido.";
                return;
            }

            LibroNegocio negocio = new LibroNegocio();
            Libro libro = negocio.ObtenerPorId(LibroId);

            if (libro != null)
            {
                lblTitulo.Text = libro.Titulo;
                imgLibro.ImageUrl = libro.Imagen;
                lblDescripcion.Text = libro.Descripcion;
                lblGenero.Text = libro.Genero.DescripcionGenero;
                lblSubGenero.Text = libro.Genero.DescripcionSubGenero;
                lblAutor.Text = "Autor/es: " + string.Join(", ", libro.Autores.Select(a => a.Nombre));
            }
            else
            {
                lblTitulo.Text = "Libro no encontrado.";
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (LibroId <= 0)
                return;

            LibroNegocio negocio = new LibroNegocio();
            Libro libro = negocio.ObtenerPorId(LibroId);
            if (libro == null)
                return;

            Dominio.Carrito carrito = Session["carrito"] as Dominio.Carrito;
            if (carrito == null)
            {
                carrito = new Dominio.Carrito();
                carrito.Items = new System.Collections.Generic.List<ItemCarrito>();
            }

            ItemCarrito existente = carrito.Items.FirstOrDefault(i => i.Libro.Id == libro.Id);
            if (existente != null)
            {
                existente.Cantidad++;
            }
            else
            {
                ItemCarrito nuevo = new ItemCarrito
                {
                    Libro = libro,
                    Cantidad = 1
                };
                carrito.Items.Add(nuevo);
            }

            Session["carrito"] = carrito;

            // Redirigir al carrito
            Response.Redirect("~/Cliente/Carrito.aspx");
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            if (LibroId <= 0)
                return;

            LibroNegocio negocio = new LibroNegocio();
            Libro libro = negocio.ObtenerPorId(LibroId);
            if (libro == null)
                return; 

            // Recupera carrito de sesion o crea uno nuevo
            Dominio.Carrito carrito = Session["carrito"] as Dominio.Carrito;
            if (carrito == null)
            {
                carrito = new Dominio.Carrito();
                carrito.Items = new System.Collections.Generic.List<ItemCarrito>();
            }

            // Verifica si ya esta en el carrito
            ItemCarrito existente = carrito.Items.FirstOrDefault(i => i.Libro.Id == libro.Id);
            if (existente != null)
            {
                existente.Cantidad++;
            }
            else
            {
                carrito.Items.Add(new ItemCarrito
                {
                    Libro = libro,
                    Cantidad = 1
                });
            }

            Session["carrito"] = carrito;

            Response.Redirect("~/Cliente/FinalizarCompra.aspx");
        }
    }
}
