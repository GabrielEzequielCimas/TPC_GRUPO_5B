﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_PROG_III.Cliente
{
    public partial class ConfirmacionCompra : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSeguirComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cliente/Catalogo.aspx");
        }
    }
}
