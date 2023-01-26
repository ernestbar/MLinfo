using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;

namespace appAmascuotas
{
    public partial class rpt_plan_pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["amaszonasConn"].ConnectionString);
                cnx.Open();

                //plan_pago dsRdlc = new plan_pago();

               // SqlCommand cmd = new SqlCommand();
               // SqlDataAdapter adp = new SqlDataAdapter();
               // cmd.Connection = cnx;
               // cmd.CommandText = "PR_GET_DATOS_PLANPAGO";
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
               // cmd.Parameters.AddWithValue("PV_COD_SIMULADOR", 33);
               // adp.SelectCommand = cmd;
               //// adp.Fill(dsRdlc, "plan_pago");
               // adp.Dispose();
               // cnx.Close();

               // // Llamar al reporte
               // rptvwReportes.ProcessingMode = ProcessingMode.Local;
               // rptvwReportes.LocalReport.ReportPath = Server.MapPath("~/simulador_inf.rdlc");
               // rptvwReportes.LocalReport.DataSources.Clear();
               // rptvwReportes.LocalReport.DataSources.Add(new ReportDataSource("plan_pago", dsRdlc.Tables["plan_pago"]));
               // rptvwReportes.SizeToReportContent = true;
            }

        }
    }
}