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
    public partial class UpdateDatosCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];

                txtNombre.Text = usuario.Cliente.Nombre;
                txtApellido.Text = usuario.Cliente.Apellido;
                txtDocumento.Text = usuario.Cliente.Documento.ToString();
            }
        }

      
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                usuario.Cliente.Nombre = txtNombre.Text;
                usuario.Cliente.Apellido = txtApellido.Text;
                if (int.TryParse(txtDocumento.Text, out int doc))
                    usuario.Cliente.Documento = doc;

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                clienteNegocio.Modificar(usuario.Cliente);

                lblMensaje.Text = "Datos actualizados correctamente.";
            }
        }

    }
}