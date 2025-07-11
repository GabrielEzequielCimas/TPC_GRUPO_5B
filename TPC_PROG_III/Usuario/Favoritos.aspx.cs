using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_PROG_III.Usuarios
{
    public partial class Favoritos : System.Web.UI.Page
    {
        void Cargar()
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            FavoritoNegocio negocio = new FavoritoNegocio();
            LibroNegocio libroNegocio = new LibroNegocio();

            var idsFavoritos = negocio.ListarFavoritos(usuario.Cliente.Id).Select(f => f.IdLibro).ToList();
            var librosFavoritos = libroNegocio.Listar().Where(l => idsFavoritos.Contains(l.Id)).ToList();

            rptFavoritos.DataSource = librosFavoritos;
            rptFavoritos.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    LibroNegocio libroNegocio = new LibroNegocio();

                    var idsFavoritos = negocio.ListarFavoritos(usuario.Cliente.Id).Select(f => f.IdLibro).ToList();
                    var librosFavoritos = libroNegocio.Listar().Where(l => idsFavoritos.Contains(l.Id)).ToList();

                    rptFavoritos.DataSource = librosFavoritos;
                    rptFavoritos.DataBind();
                }
            }
        }
        protected void rptFavoritos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "QuitarFavorito")
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                int idLibro = Convert.ToInt32(e.CommandArgument);

                FavoritoNegocio negocio = new FavoritoNegocio();
                negocio.SetearFav(usuario.Cliente.Id, idLibro); 

                // Volver a cargar
                Page_Load(null, null);
                Cargar();
            }
            if (e.CommandName == "VerDetalle")
            {
                int idLibro = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetalleLibro.aspx?id=" + idLibro);
            }
        }
    }
}