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
    public partial class reportePlanPagos : System.Web.UI.Page
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
                        DataTable dt_plampago = new DataTable();
                        DataTable dt_cabecera = new DataTable();
                        DataTable dt_solicitud = new DataTable();

                        dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
                        dt_cabecera = Clases.solicitudes.PR_GET_DATOS_PLANPAGO_CABECERA_SOLI(lblCodSolicitud.Text);
                        dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(lblCodSolicitud.Text);
                        dt_plampago = Clases.solicitudes.PR_GET_DATOS_PLANPAGO_SOLICITUD(lblCodSolicitud.Text);

                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSCliente", dt_cliente));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSCabecera", dt_cabecera));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSPlanPlago", dt_plampago));
                        ReportParameter p_persona = new ReportParameter();
                        p_persona.Name = "persona";
                        if (lblTipoCliente.Text == "N")
                        {
                            p_persona.Values.Add("Natural");
                            rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/plan_pagos.rdlc");
                        }
                        else
                        {
                            p_persona.Values.Add("Juridica");
                            rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/plan_pagos_juridica.rdlc");
                        }
                        p_persona.Visible = true;
                        rv.LocalReport.EnableHyperlinks = true;
                        ReportParameter p_fecha = new ReportParameter();
                        p_fecha.Name = "fecha";
                        p_fecha.Values.Add(Convert.ToString(DateTime.Now.ToShortDateString()));
                        p_fecha.Visible = true;

                        ReportParameter[] rp = { p_fecha, p_persona };
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
                    string nombre_archivo = "error_ReportePlanPagos_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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