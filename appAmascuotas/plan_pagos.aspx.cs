using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class plan_pagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblCodSimulador.Text = "33";//Session["COD_SIMULADOR"].ToString();

            }
        }
        protected void btnVolverDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("simulador.aspx");
        }
    }
}