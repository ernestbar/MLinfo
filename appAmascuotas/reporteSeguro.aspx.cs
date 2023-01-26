using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class reporteSeguro : System.Web.UI.Page
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
                        lblTipoCliente.Text = Session["TIPO_CLIENTE"].ToString();
                        lblUsuario.Text = Session["usuario"].ToString();
                        lblCodSolicitud.Text = Session["COD_SOLICITUD"].ToString();
                        lblCodCliente.Text = Session["COD_CLIENTE"].ToString();
                        DataTable dt_cliente = new DataTable();
                        DataTable dt_numeros = new DataTable();

                        DataTable dt_solicitud = new DataTable();

                        string nombre = "";
                        dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
                        foreach (DataRow dr in dt_cliente.Rows)
                        {
                            if (lblTipoCliente.Text == "J")
                                nombre = dr["RAZON_SOCIAL"].ToString();
                            else
                                nombre = dr["NOMBRE"].ToString() + " " + dr["SEGUNDO_NOMBRE"].ToString() + " " + dr["TERCER_NOMBRE"].ToString() + " " + dr["APELLIDO_PATERNO"].ToString() + " " + dr["APELLIDO_MATERNO"].ToString() + " " + dr["APELLIDO_MARITAL"].ToString();
                        }
                        ReportParameter p_fecha = new ReportParameter();
                        p_fecha.Name = "fecha";
                        p_fecha.Values.Add(DateTime.Now.ToShortDateString());
                        p_fecha.Visible = true;
                        ReportParameter p_poliza = new ReportParameter();
                        p_poliza.Name = "poliza";
                        p_poliza.Values.Add(lblCodCliente.Text);
                        p_poliza.Visible = true;
                        ReportParameter p_nombre = new ReportParameter();
                        p_nombre.Name = "nombre_cliente";
                        p_nombre.Values.Add(nombre);
                        p_nombre.Visible = true;

                        ReportParameter[] rp = { p_fecha, p_poliza, p_nombre };
                        rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/seguro.rdlc");
                        rv.LocalReport.SetParameters(rp);

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

                        String filePath = MapPath(nombre_reporte);
                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        fs.Write(renderedBytes, 0, renderedBytes.Length);
                        fs.Close();

                        Response.Clear();
                        Response.AppendHeader("content-disposition", "attachment; filename=Reporte.pdf");

                        Response.ContentType = "application/pdf";
                        Response.WriteFile(filePath);
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_reporteSeguro_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
            Session["usuario"] = lblUsuario.Text;
            Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
            Session["COD_CLIENTE"] = lblCodCliente.Text;
            Session["TIPO_CLIENTE"] = lblTipoCliente.Text;
            Response.Redirect("imprimir_documentos.aspx");
        }
    }
}