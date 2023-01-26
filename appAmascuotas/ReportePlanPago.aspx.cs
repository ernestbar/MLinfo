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
using System.IO;
using System.Text;

namespace appAmascuotas
{
    public partial class ReportePlanPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["usuario"] == null)
                    { Response.Redirect("login.aspx"); }
                    else
                    {
                        lblUsuario.Text = Session["usuario"].ToString();
                        lblCodSimulador.Text = Session["COD_SIMULADOR"].ToString();
                        lblCodCliente.Text = Session["COD_CLIENTE"].ToString();
                        SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["amaszonasConn"].ConnectionString);


                        //DataSetReportes dsRdlc = new DataSetReportes();

                        SqlCommand cmd = new SqlCommand();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        cmd.Connection = cnx;
                        cmd.CommandText = "PR_GET_DATOS_PLANPAGO";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                        cmd.Parameters.AddWithValue("PV_COD_SIMULADOR", lblCodSimulador.Text);
                        cnx.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        cnx.Close();

                        SqlCommand cmd2 = new SqlCommand();
                        SqlDataAdapter adp2 = new SqlDataAdapter();
                        cmd2.Connection = cnx;
                        cmd2.CommandText = "PR_GET_DATOS_PLANPAGO_CABECERA";
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                        cmd2.Parameters.AddWithValue("PV_COD_SIMULADOR", lblCodSimulador.Text);
                        cnx.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        DataTable dt2 = new DataTable();
                        dt2.Load(dr2);
                        cnx.Close();

                        rv.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt2));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
                        rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/simulador_rpt.rdlc");
                        rv.LocalReport.EnableHyperlinks = true;
                    }

                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_reportePlanPagos_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                    string directorio2 = Server.MapPath("~/Logs");
                    StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                    writer5.WriteLine(ex.ToString());
                    writer5.Close();
                    lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
                }



            }
        }

      

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (lblCodCliente.Text == "")
            { Response.Redirect("simulador_wiz.aspx"); }
            else
            {
                Session["COD_CLIENTE"] = lblCodCliente.Text;
                Response.Redirect("simulador_detalle.aspx");
            }
            
        }
    }
}