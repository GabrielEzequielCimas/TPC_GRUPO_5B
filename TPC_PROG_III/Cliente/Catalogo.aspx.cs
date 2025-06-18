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
    public partial class Catalogo : Page
    {
        public Filtro Filtro { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LibroNegocio negocio = new LibroNegocio();
                var libros = negocio.Listar();
                rptLibros.DataSource = libros;
                rptLibros.DataBind();
            }
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