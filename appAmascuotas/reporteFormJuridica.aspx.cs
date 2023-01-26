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
    public partial class reporteFormJuridica : System.Web.UI.Page
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
                        if (Request.QueryString["reimprimir"] == "SI")
                        {
                            btnVolver.Text = "Volver";
                        }
                        else { btnVolver.Text = "Continuar"; }
                        lblUsuario.Text = Session["usuario"].ToString();
                        lblCodSolicitud.Text = Session["COD_SOLICITUD"].ToString();
                        lblCodCliente.Text = Session["COD_CLIENTE"].ToString();
                        DataTable dt_cliente = new DataTable();
                        DataTable dt_conyugue = new DataTable();
                        DataTable dt_domicilio = new DataTable();
                        DataTable dt_datos_laborales = new DataTable();
                        DataTable dt_referencias = new DataTable();
                        DataTable dt_balance = new DataTable();
                        DataTable dt_ingresos = new DataTable();
                        DataTable dt_egresos = new DataTable();
                        DataTable dt_represetnates_legales = new DataTable();
                        DataTable dt_solicitud = new DataTable();
                        DataTable dt_garante = new DataTable();
                        DataTable dt_paisdepto = new DataTable();

                        dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
                        dt_conyugue = Clases.clientes.PR_GET_CONYUGUE(lblCodCliente.Text);
                        dt_domicilio = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                        dt_datos_laborales = Clases.clientes.PR_GET_DATOS_LABORALES(lblCodCliente.Text);
                        dt_referencias = Clases.clientes.PR_GET_REFERENCIAS(lblCodCliente.Text);
                        dt_balance = Clases.clientes.PR_GET_BALANCE(lblCodCliente.Text);
                        dt_ingresos = Clases.clientes.PR_GET_INGRESOS(lblCodCliente.Text);
                        dt_egresos = Clases.clientes.PR_GET_EGRESOS(lblCodCliente.Text);
                        dt_represetnates_legales = Clases.clientes.PR_GET_REPRESENTANTE_LEGAL(lblCodCliente.Text);
                        dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(lblCodSolicitud.Text);
                        dt_garante = Clases.clientes.PR_GET_GARANTE(lblCodCliente.Text,lblCodSolicitud.Text);
                        dt_paisdepto = Clases.solicitudes.PR_GET_PAISDEPTO(lblCodSolicitud.Text);
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSCliente", dt_cliente));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSConyugue", dt_conyugue));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSDireccion", dt_domicilio));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSDatosLaborales", dt_datos_laborales));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSReferencias", dt_referencias));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSBalance", dt_balance));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSIngresos", dt_ingresos));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSEgresos", dt_egresos));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSRepresentatesLegales", dt_represetnates_legales));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSGarante", dt_garante));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSPaisDepto", dt_paisdepto));
                        rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/formulario_juridica.rdlc");
                        rv.LocalReport.EnableHyperlinks = true;
                        ReportParameter p_dia = new ReportParameter();
                        p_dia.Name = "fecha_dia";
                        p_dia.Values.Add(Convert.ToString(DateTime.Now.Day));
                        p_dia.Visible = true;
                        ReportParameter p_mes = new ReportParameter();
                        p_mes.Name = "fecha_mes";
                        string mes_aux = "";
                        if (DateTime.Now.Month == 1)
                            mes_aux = "enero";
                        if (DateTime.Now.Month == 2)
                            mes_aux = "febrero";
                        if (DateTime.Now.Month == 3)
                            mes_aux = "marzo";
                        if (DateTime.Now.Month == 4)
                            mes_aux = "abril";
                        if (DateTime.Now.Month == 5)
                            mes_aux = "mayo";
                        if (DateTime.Now.Month == 6)
                            mes_aux = "junio";
                        if (DateTime.Now.Month == 7)
                            mes_aux = "julio";
                        if (DateTime.Now.Month == 8)
                            mes_aux = "agosto";
                        if (DateTime.Now.Month == 9)
                            mes_aux = "septiembre";
                        if (DateTime.Now.Month == 10)
                            mes_aux = "octubre";
                        if (DateTime.Now.Month == 11)
                            mes_aux = "nomviembre";
                        if (DateTime.Now.Month == 12)
                            mes_aux = "diciembre";

                        p_mes.Values.Add(mes_aux);
                        p_mes.Visible = true;
                        ReportParameter p_anio = new ReportParameter();
                        p_anio.Name = "fecha_anio";
                        p_anio.Values.Add(Convert.ToString(DateTime.Now.Year).Remove(0, 2));
                        p_anio.Visible = true;

                        ReportParameter[] rp = { p_dia, p_mes, p_anio };
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

                        if (Request.QueryString["reimprimir"] == "SI")
                        {
                            Session["usuario"] = lblUsuario.Text;
                            Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
                            Session["COD_CLIENTE"] = lblCodCliente.Text;
                            Session["TIPO_CLIENTE"] = "N";
                            Response.Redirect("solicitudes.aspx",true);
                        }
                        else
                        {
                            Clases.solicitudes obj_d = new Clases.solicitudes("S", lblCodSolicitud.Text, "", "", "", 0, 0, 0, 0, 0, "", "", "", lblUsuario.Text);
                            string resultado = obj_d.ABM();
                            string[] res_aux = resultado.Split('|');
                            lblCodSolicitudDetalle.Text = res_aux[2];
                            // string[] res_aux = resultado.Split('|');
                            Session["COD_SOLICITUD_DETALLE"] = res_aux[2];
                            Session["usuario"] = lblUsuario.Text;
                            Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
                            Session["COD_CLIENTE"] = lblCodCliente.Text;
                            Session["TIPO_CLIENTE"] = "N";
                            Response.Redirect("solicitudes_admin.aspx?inicialcounter=SI", false);

                        }

                       

                    }
                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_formJuridica_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
            try
            {
                if (btnVolver.Text == "Volver")
                {
                    Session["usuario"] = lblUsuario.Text;
                    Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
                    Session["COD_CLIENTE"] = lblCodCliente.Text;
                    Session["TIPO_CLIENTE"] = "J";
                    Session["COD_SOLICITUD_DETALLE"] = lblCodSolicitudDetalle.Text;
                    Response.Redirect("solicitudes.aspx");
                }
                else
                {
                    Session["usuario"] = lblUsuario.Text;
                    Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
                    Session["COD_CLIENTE"] = lblCodCliente.Text;
                    Session["TIPO_CLIENTE"] = "J";
                    Session["COD_SOLICITUD_DETALLE"] = lblCodSolicitudDetalle.Text;
                    Response.Redirect("solicitudes_admin.aspx?inicialcounter=SI");
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_formJuridica_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }
    }
}