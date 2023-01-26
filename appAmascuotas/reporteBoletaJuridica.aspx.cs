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
    public partial class reporteBoletaJuridica : System.Web.UI.Page
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

                        dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
                        dt_numeros = Clases.solicitudes.GET_NUMEROS_COMPROBANTES(lblCodSolicitud.Text);

                        dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(lblCodSolicitud.Text);


                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSCliente", dt_cliente));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSNumeros", dt_numeros));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                        if (lblTipoCliente.Text == "J")
                            rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/boleta_pago_juridica.rdlc");
                        else
                            rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/boleta_pago.rdlc");
                        rv.LocalReport.EnableHyperlinks = true;
                        ReportParameter p_dia = new ReportParameter();
                        p_dia.Name = "dia";
                        p_dia.Values.Add(Convert.ToString(DateTime.Now.Day));
                        p_dia.Visible = true;
                        ReportParameter p_mes = new ReportParameter();
                        p_mes.Name = "mes";
                        p_mes.Values.Add(Convert.ToString(DateTime.Now.Month));
                        p_mes.Visible = true;
                        ReportParameter p_anio = new ReportParameter();
                        p_anio.Name = "anio";
                        p_anio.Values.Add(Convert.ToString(DateTime.Now.Year));
                        p_anio.Visible = true;
                        ReportParameter p_cod_cliente = new ReportParameter();
                        p_cod_cliente.Name = "cod_cliente";
                        p_cod_cliente.Values.Add(lblCodCliente.Text);
                        p_cod_cliente.Visible = true;

                        ReportParameter[] rp = { p_dia, p_mes, p_anio, p_cod_cliente };
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
                    string nombre_archivo = "error_boletaJuridica_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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