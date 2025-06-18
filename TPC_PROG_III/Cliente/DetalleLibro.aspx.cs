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
    public partial class DetalleLibro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    LibroNegocio negocio = new LibroNegocio();
                    Libro libro = negocio.Listar().Find(l => l.Id == id);

                    if (libro != null)
                    {
                        lblTitulo.Text = libro.Titulo;
                        imgLibro.ImageUrl = libro.Imagen.Url;
                        lblDescripcion.Text = libro.Descripcion;
                        lblGenero.Text = libro.Genero.DescripcionGenero;
                        //lblAutor.Text = libro.Autor.Nombre;
                    }
                    else
                    {
                        lblTitulo.Text = "Libro no encontrado.";
                    }
                }
                else
                {
                    lblTitulo.Text = "ID inválido.";
                }
            }
        }
    }
}