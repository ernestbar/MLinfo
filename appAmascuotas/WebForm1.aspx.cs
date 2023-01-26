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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["amaszonasConn"].ConnectionString);
            

            //DataSetReportes dsRdlc = new DataSetReportes();

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = cnx;
            cmd.CommandText = "PR_GET_DATOS_PLANPAGO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            cmd.Parameters.AddWithValue("PV_COD_SIMULADOR", 33);
            cnx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cnx.Close();

            rv.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/simulador_rpt.rdlc");
            rv.LocalReport.EnableHyperlinks = true;
            //adp.SelectCommand = cmd;

            //adp.Fill(dsRdlc, "ciudad");
            //adp.Dispose();
            //cnx.Close();
        }
    }
}