using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAutores_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAutores.aspx");
        }
        protected void btnEditoriales_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminEditoriales.aspx");
        }
        protected void btnGeneros_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminGeneros.aspx");
        }
        protected void btnLibros_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLibros.aspx");
        }
    }
}