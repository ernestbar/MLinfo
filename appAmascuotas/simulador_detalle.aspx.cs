using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;


namespace appAmascuotas
{
    public partial class simulador_detalle : System.Web.UI.Page
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
                        lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                        lblUsuario.Text = Session["usuario"].ToString();
                        lblCodCliente.Text = Session["COD_CLIENTE"].ToString();
                        odsClienteDetalle.DataBind();
                        Repeater2.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_simulador_detalle_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                    string directorio2 = Server.MapPath("~/Logs");
                    StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                    writer5.WriteLine(ex.ToString());
                    writer5.Close();
                    lblAviso.Text = "Las variables de session caducaron.";
                }


            }
        }
        protected void btnPlanPago_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Session["COD_CLIENTE"] = lblCodCliente.Text;
                Session["COD_SIMULADOR"] = id;
               // Response.Redirect("ReportePlanPago.aspx");
                ReportViewer rv = new ReportViewer();
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["amaszonasConn"].ConnectionString);


                //DataSetReportes dsRdlc = new DataSetReportes();

                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adp = new SqlDataAdapter();
                cmd.Connection = cnx;
                cmd.CommandText = "PR_GET_DATOS_PLANPAGO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                cmd.Parameters.AddWithValue("PV_COD_SIMULADOR", id);
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
                cmd2.Parameters.AddWithValue("PV_COD_SIMULADOR", id);
                cnx.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                cnx.Close();

                rv.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt2));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
                rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/simulador_rpt.rdlc");
                rv.LocalReport.EnableHyperlinks = true;
                ////////////////////////DESCARGA DIRECTAMENTE A PDF EL PREPORTE/////////////////////////////////
                string reportType = "PDF";
                string mimeType;
                string encoding;
                string fileNameExtension;
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                //Render
                renderedBytes = rv.LocalReport.Render(
                reportType,
                //deviceInfo,
                null,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
                string nombre_reporte = "~/PDF/reporte" + Session.SessionID + ".pdf";

                string nombre_reporte2 = "PDF/reporte" + Session.SessionID + ".pdf";
                String filePath = MapPath(nombre_reporte);
                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(renderedBytes, 0, renderedBytes.Length);
                fs.Close();

                Response.Write("<script> window.open('" + nombre_reporte2 + "','_blank'); </script>");
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_detalle_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Las variables de session caducaron.";
            }

            //lblCodSimulador.Text = id;
            //MultiView1.ActiveViewIndex = 3;
            //odsPlanPago.DataBind();
            //Repeater3.DataBind();
            //Response.Redirect("expPlanPAgo.aspx");
        }
        protected void btnVolverDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("simulador_wiz.aspx?RME="+lblCodMenuRol.Text);
        }
    }
}