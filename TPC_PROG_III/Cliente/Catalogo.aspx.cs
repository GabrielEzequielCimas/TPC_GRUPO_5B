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
        protected void rptArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                string codigoVoucher = Request.QueryString["codigo"];
                string idArticulo = e.CommandArgument.ToString();
                Response.Redirect($"CargaDatos.aspx?codigo={codigoVoucher}&idArticulo={idArticulo}");
            }
        }
        protected void rptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Libro libro = (Libro)e.Item.DataItem;
            var rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");// No puedo acceder directo al repeater pq esta dentro del repeater principal
            if (libro.Imagenes != null && libro.Imagenes.Count > 0)
            {
                // acá cargo las imagenes en el repeater
                rptImagenes.DataSource = libro.Imagenes;
                rptImagenes.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LibroNegocio negocio = new LibroNegocio();
                var libros = negocio.Listar();
                rptArticulos.DataSource = libros;
                rptArticulos.DataBind();
            }
        }
    }
}