using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class expPlanPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["COD_SIMULADOR"] != null)
                    { lblCodSimulador.Text = Session["COD_SIMULADOR"].ToString(); }
                }
                catch
                { lblAviso.Text = "Las variables de session caducaron."; }
                
                
            }
        }

        protected void btnVolverSimuldores_Click(object sender, EventArgs e)
        {
            Response.Redirect("simulador.aspx");
        }
    }
}