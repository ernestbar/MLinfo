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
    public partial class reporteContrato : System.Web.UI.Page
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
                        lblGarante.Text = Session["CON_GARANTE"].ToString();
                        if (lblTipoCliente.Text == "J")
                        {
                            if (lblGarante.Text == "S")
                            {
                                //DataTable dt_cliente = new DataTable();
                                //DataTable dt_garante = new DataTable();
                                //DataTable dt_planpago = new DataTable();
                                //DataTable dt_solicitud = new DataTable();
                                //DataTable dt_direccion = new DataTable();
                                //DataTable dt_paisdpto = new DataTable();
                                //DataTable dt_ticketcabecera = new DataTable();
                                //DataTable dt_ticketdetalle = new DataTable();

                                //dt_direccion = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                                //dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
                                //dt_garante = Clases.clientes.PR_GET_GARANTE(lblCodCliente.Text, lblCodSolicitud.Text);
                                //dt_planpago = Clases.solicitudes.PR_GET_DATOS_PLANPAGO_SOLICITUD(lblCodSolicitud.Text);
                                //dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(lblCodSolicitud.Text);
                                //dt_paisdpto = Clases.solicitudes.PR_GET_PAISDEPTO(lblCodSolicitud.Text);
                                //dt_ticketcabecera = Clases.Tickets.GET_TICKETS(lblCodSolicitud.Text);
                                //string cod_sol_ticket = "";
                                //if (dt_ticketcabecera.Rows.Count > 0)
                                //{
                                //    foreach (DataRow dr in dt_ticketcabecera.Rows)
                                //    {
                                //        cod_sol_ticket = dr["COD_SOLICITUD_TICKET"].ToString();
                                //    }
                                //}

                                //dt_ticketdetalle = Clases.Tickets.GET_TICKETS_DETALLE(cod_sol_ticket);
                                //rv.LocalReport.DataSources.Add(new ReportDataSource("DSDireccion", dt_direccion));
                                //rv.LocalReport.DataSources.Add(new ReportDataSource("DSCliente", dt_cliente));
                                //rv.LocalReport.DataSources.Add(new ReportDataSource("DSGarante", dt_garante));
                                //rv.LocalReport.DataSources.Add(new ReportDataSource("DSPlanPagos", dt_planpago));
                                //rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                                //rv.LocalReport.DataSources.Add(new ReportDataSource("DSPaisDpto", dt_paisdpto));
                                //rv.LocalReport.DataSources.Add(new ReportDataSource("DSTicketCabecera", dt_ticketcabecera));
                                //rv.LocalReport.DataSources.Add(new ReportDataSource("DSTicketDetalle", dt_ticketdetalle));
                                //rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/contrato_texto_garante.rdlc");
                                //rv.LocalReport.EnableHyperlinks = true;
                                //ReportParameter p_dia = new ReportParameter();
                                //p_dia.Name = "dia";
                                //p_dia.Values.Add(Convert.ToString(DateTime.Now.Day));
                                //p_dia.Visible = true;
                                //ReportParameter p_mes = new ReportParameter();
                                //p_mes.Name = "mes";
                                //string mes_aux = "";
                                //if (DateTime.Now.Month == 1)
                                //    mes_aux = "enero";
                                //if (DateTime.Now.Month == 2)
                                //    mes_aux = "febrero";
                                //if (DateTime.Now.Month == 3)
                                //    mes_aux = "marzo";
                                //if (DateTime.Now.Month == 4)
                                //    mes_aux = "abril";
                                //if (DateTime.Now.Month == 5)
                                //    mes_aux = "mayo";
                                //if (DateTime.Now.Month == 6)
                                //    mes_aux = "junio";
                                //if (DateTime.Now.Month == 7)
                                //    mes_aux = "julio";
                                //if (DateTime.Now.Month == 8)
                                //    mes_aux = "agosto";
                                //if (DateTime.Now.Month == 9)
                                //    mes_aux = "septiembre";
                                //if (DateTime.Now.Month == 10)
                                //    mes_aux = "octubre";
                                //if (DateTime.Now.Month == 11)
                                //    mes_aux = "nomviembre";
                                //if (DateTime.Now.Month == 12)
                                //    mes_aux = "diciembre";

                                //p_mes.Values.Add(mes_aux);
                                //p_mes.Visible = true;
                                //ReportParameter p_anio = new ReportParameter();
                                //p_anio.Name = "anio";
                                //p_anio.Values.Add(Convert.ToString(DateTime.Now.Year).Remove(0, 2));
                                //p_anio.Visible = true;

                                //ReportParameter p_codcli = new ReportParameter();
                                //p_codcli.Name = "cod_cliente";
                                //p_codcli.Values.Add(lblCodCliente.Text);
                                //p_codcli.Visible = true;

                                //ReportParameter p_fechaven = new ReportParameter();
                                //p_fechaven.Name = "fecha_vencimiento";
                                //p_fechaven.Values.Add(DateTime.Now.ToShortDateString());
                                //p_fechaven.Visible = true;

                                //ReportParameter[] rp = { p_dia, p_mes, p_anio, p_codcli, p_fechaven };
                                //rv.LocalReport.SetParameters(rp);
                                ////Clases.solicitudes obj_d = new Clases.solicitudes("S", lblCodSolicitud.Text, "", "", "", 0, 0, 0, 0, 0, "", "", "", lblUsuario.Text);
                                ////string resultado = obj_d.ABM();
                                ////string[] res_aux = resultado.Split('|');
                                ////Session["COD_SOLICITUD_DETALLE"] = res_aux[2]; 
                            }
                            else
                            {
                                DataTable dt_cliente = new DataTable();

                                DataTable dt_planpago = new DataTable();
                                DataTable dt_solicitud = new DataTable();
                                DataTable dt_direccion = new DataTable();
                                DataTable dt_paisdpto = new DataTable();
                                DataTable dt_ticketcabecera = new DataTable();
                                DataTable dt_ticketdetalle = new DataTable();

                                DataTable dt_replegal = new DataTable();

                                dt_direccion = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                                dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);

                                dt_planpago = Clases.solicitudes.PR_GET_DATOS_PLANPAGO_SOLICITUD(lblCodSolicitud.Text);
                                dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(lblCodSolicitud.Text);
                                dt_paisdpto = Clases.solicitudes.PR_GET_PAISDEPTO(lblCodSolicitud.Text);
                                dt_ticketcabecera = Clases.Tickets.GET_TICKETS(lblCodSolicitud.Text);
                                dt_replegal=Clases.solicitudes.GET_REPRESENTANTE_LEGAL(lblCodSolicitud.Text);
                                string cod_sol_ticket = "";
                                if (dt_ticketcabecera.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt_ticketcabecera.Rows)
                                    {
                                        cod_sol_ticket = dr["COD_SOLICITUD_TICKET"].ToString();
                                    }
                                }

                                dt_ticketdetalle = Clases.Tickets.GET_TICKETS_DETALLE(cod_sol_ticket);
                                string razon_social = "";
                                string nit = "";
                                string matricula = "";
                                string rep_legal = "";
                                string poder = "";
                                string notaria = "";
                                string notario = "";
                                string ci_rep_legal = "";
                                if (dt_cliente.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt_cliente.Rows)
                                    {
                                        razon_social = dr["razon_social"].ToString();
                                        nit = dr["NUMERO_DOCUMENTO"].ToString();
                                    }
                                }
                                if (dt_replegal.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in dt_replegal.Rows)
                                    {
                                        if (dr1["etiqueta"].ToString() == "NOMBRE COMPLETO REPRESENTANTE LEGAL")
                                        {
                                            rep_legal = dr1["valor"].ToString();
                                        }
                                        if (dr1["etiqueta"].ToString() == "NRO PODER REPRESENANTE LEGAL")
                                        {
                                            poder = dr1["valor"].ToString();
                                        }
                                        if (dr1["etiqueta"].ToString() == "NUMERO DOCUMENTO REPRESENANTE LEGAL")
                                        {
                                            ci_rep_legal = dr1["valor"].ToString();
                                        }
                                        if (dr1["etiqueta"].ToString() == "MATRICULA DE COMERCIO")
                                        {
                                            matricula = dr1["valor"].ToString();
                                        }
                                        if (dr1["etiqueta"].ToString() == "NRO DE NOTARIA")
                                        {
                                            notaria = dr1["valor"].ToString();
                                        }
                                        if (dr1["etiqueta"].ToString() == "ABOGADO/NOTARIO")
                                        {
                                            notario = dr1["valor"].ToString();
                                        }
                                    }
                                }

                                string monto = "";
                                string literal = "";
                                if (dt_solicitud.Rows.Count > 0)
                                {
                                    foreach (DataRow dr2 in dt_solicitud.Rows)
                                    {
                                        monto = dr2["MONTO_FINANCIADO"].ToString();
                                        literal = dr2["MONTO_FINANCIADO_LITERAL"].ToString();
                                    }
                                }
                                string parrafo12 = razon_social + " con Matricula de Comercio Nro. " + matricula + " numero de identificación tributaria (NIT) " + nit + " legalmente representado por " + rep_legal + " mayor de edad hábil por derecho, con C.I. " + ci_rep_legal + " según testimonio poder Nro. " + poder + " emitido en notaria de fe pública Nro. " + notaria + " - " + notario + ". En adelante y para efectos del presente contrato denominado EL CLIENTE.";
                                string deudor_pagare = razon_social + " con Matricula de Comercio Nro. " + matricula + " numero de identificación tributaria (NIT) " + nit + " legalmente representado por " + rep_legal + " mayor de edad hábil por derecho, con C.I. " + ci_rep_legal + " según testimonio poder Nro. " + poder;
                                string presente_pagare = "Por el presente PAGARE, " + razon_social + " con Matricula de Comercio Nro. " + matricula + " numero de identificación tributaria (NIT) " + nit + " legalmente representado por " + rep_legal + " mayor de edad hábil por derecho, con C.I. " + ci_rep_legal + " según testimonio poder Nro. " + poder + " debe y pagara incondicionalmente a la orden de la COMPAÑIA DE SERVICIOS DE TRANSPORTE AEREO AMASZONAS S.A., la suma de capital " + monto + ".- (" + literal + " BOLIVIANOS). A la fecha de su vencimiento.";
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSDireccion", dt_direccion));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSCliente", dt_cliente));

                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSPlanPagos", dt_planpago));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSPaisDpto", dt_paisdpto));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSTicketCabecera", dt_ticketcabecera));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSTicketDetalle", dt_ticketdetalle));


                                rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/contrato_texto_juridica.rdlc");
                                rv.LocalReport.EnableHyperlinks = true;
                                ReportParameter p_parrafo12 = new ReportParameter();
                                p_parrafo12.Name = "parrafo12";
                                p_parrafo12.Values.Add(parrafo12);
                                p_parrafo12.Visible = true;
                                ReportParameter p_deudor_pagare = new ReportParameter();
                                p_deudor_pagare.Name = "deudor_pagare";
                                p_deudor_pagare.Values.Add(deudor_pagare);
                                p_deudor_pagare.Visible = true;
                                ReportParameter p_presente_pagare = new ReportParameter();
                                p_presente_pagare.Name = "por_presente_pagare";
                                p_presente_pagare.Values.Add(presente_pagare);
                                p_presente_pagare.Visible = true;
                                ReportParameter p_rep_legal = new ReportParameter();
                                p_rep_legal.Name = "rep_legal";
                                p_rep_legal.Values.Add(rep_legal);
                                p_rep_legal.Visible = true;
                                ReportParameter p_ci_rep_legal = new ReportParameter();
                                p_ci_rep_legal.Name = "ci_rep_legal";
                                p_ci_rep_legal.Values.Add("C.I.: "+ci_rep_legal);
                                p_ci_rep_legal.Visible = true;
                                ReportParameter p_dia = new ReportParameter();
                                p_dia.Name = "dia";
                                p_dia.Values.Add(Convert.ToString(DateTime.Now.Day));
                                p_dia.Visible = true;
                                ReportParameter p_mes = new ReportParameter();
                                p_mes.Name = "mes";
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
                                p_anio.Name = "anio";
                                p_anio.Values.Add(Convert.ToString(DateTime.Now.Year).Remove(0, 2));
                                p_anio.Visible = true;

                                ReportParameter p_codcli = new ReportParameter();
                                p_codcli.Name = "cod_cliente";
                                p_codcli.Values.Add(lblCodCliente.Text);
                                p_codcli.Visible = true;

                                ReportParameter p_fechaven = new ReportParameter();
                                p_fechaven.Name = "fecha_vencimiento";
                                p_fechaven.Values.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                                p_fechaven.Visible = true;

                                ReportParameter[] rp = { p_dia, p_mes, p_anio, p_codcli, p_fechaven,p_parrafo12,p_rep_legal,p_ci_rep_legal,p_deudor_pagare,p_presente_pagare };
                                rv.LocalReport.SetParameters(rp);
                                //rv.LocalReport.Refresh();
                            }
                        }
                        else
                        {
                            if (lblGarante.Text == "S")
                            {
                                DataTable dt_cliente = new DataTable();
                                DataTable dt_garante = new DataTable();
                                DataTable dt_planpago = new DataTable();
                                DataTable dt_solicitud = new DataTable();
                                DataTable dt_direccion = new DataTable();
                                DataTable dt_paisdpto = new DataTable();
                                DataTable dt_ticketcabecera = new DataTable();
                                DataTable dt_ticketdetalle = new DataTable();

                                dt_direccion = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                                dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
                                dt_garante = Clases.clientes.PR_GET_GARANTE(lblCodCliente.Text, lblCodSolicitud.Text);
                                dt_planpago = Clases.solicitudes.PR_GET_DATOS_PLANPAGO_SOLICITUD(lblCodSolicitud.Text);
                                dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(lblCodSolicitud.Text);
                                dt_paisdpto = Clases.solicitudes.PR_GET_PAISDEPTO(lblCodSolicitud.Text);
                                dt_ticketcabecera = Clases.Tickets.GET_TICKETS(lblCodSolicitud.Text);
                                string cod_sol_ticket = "";
                                if (dt_ticketcabecera.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt_ticketcabecera.Rows)
                                    {
                                        cod_sol_ticket = dr["COD_SOLICITUD_TICKET"].ToString();
                                    }
                                }

                                dt_ticketdetalle = Clases.Tickets.GET_TICKETS_DETALLE(cod_sol_ticket);
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSDireccion", dt_direccion));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSCliente", dt_cliente));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSGarante", dt_garante));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSPlanPagos", dt_planpago));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSPaisDpto", dt_paisdpto));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSTicketCabecera", dt_ticketcabecera));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSTicketDetalle", dt_ticketdetalle));
                                rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/contrato_texto_garante.rdlc");
                                rv.LocalReport.EnableHyperlinks = true;
                                ReportParameter p_dia = new ReportParameter();
                                p_dia.Name = "dia";
                                p_dia.Values.Add(Convert.ToString(DateTime.Now.Day));
                                p_dia.Visible = true;
                                ReportParameter p_mes = new ReportParameter();
                                p_mes.Name = "mes";
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

                                string razon_social = "";
                                string nit = "";
                                if (dt_cliente.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt_cliente.Rows)
                                    {
                                        razon_social = dr["razon_social"].ToString();
                                        nit = dr["ci_completo"].ToString();
                                    }
                                }
                                
                                string monto = "";
                                string literal = "";
                                if (dt_solicitud.Rows.Count > 0)
                                {
                                    foreach (DataRow dr2 in dt_solicitud.Rows)
                                    {
                                        monto = dr2["MONTO_FINANCIADO"].ToString();
                                        literal = dr2["MONTO_FINANCIADO_LITERAL"].ToString();
                                    }
                                }
                                string presente_pagare = "Por el presente PAGARE, " + razon_social  + " debe y pagara incondicionalmente a la orden de la COMPAÑIA DE SERVICIOS DE TRANSPORTE AEREO AMASZONAS S.A., la suma de capital " + monto + ".- (" + literal + " BOLIVIANOS). A la fecha de su vencimiento.";

                                p_mes.Values.Add(mes_aux);
                                p_mes.Visible = true;
                                ReportParameter p_anio = new ReportParameter();
                                p_anio.Name = "anio";
                                p_anio.Values.Add(Convert.ToString(DateTime.Now.Year).Remove(0, 2));
                                p_anio.Visible = true;

                                ReportParameter p_codcli = new ReportParameter();
                                p_codcli.Name = "cod_cliente";
                                p_codcli.Values.Add(lblCodCliente.Text);
                                p_codcli.Visible = true;

                                ReportParameter p_fechaven = new ReportParameter();
                                p_fechaven.Name = "fecha_vencimiento";
                                p_fechaven.Values.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                                p_fechaven.Visible = true;

                                ReportParameter p_presente_pagare = new ReportParameter();
                                p_presente_pagare.Name = "por_presente_pagare";
                                p_presente_pagare.Values.Add(presente_pagare);
                                p_presente_pagare.Visible = true;

                                ReportParameter[] rp = { p_dia, p_mes, p_anio, p_codcli, p_fechaven, p_presente_pagare };
                                rv.LocalReport.SetParameters(rp);
                        //Clases.solicitudes obj_d = new Clases.solicitudes("S", lblCodSolicitud.Text, "", "", "", 0, 0, 0, 0, 0, "", "", "", lblUsuario.Text);
                        //string resultado = obj_d.ABM();
                        //string[] res_aux = resultado.Split('|');
                        //Session["COD_SOLICITUD_DETALLE"] = res_aux[2]; 
                            }
                            else
                            {
                                DataTable dt_cliente = new DataTable();
                                
                                DataTable dt_planpago = new DataTable();
                                DataTable dt_solicitud = new DataTable();
                                DataTable dt_direccion = new DataTable();
                                DataTable dt_paisdpto = new DataTable();
                                DataTable dt_ticketcabecera = new DataTable();
                                DataTable dt_ticketdetalle = new DataTable();

                                dt_direccion = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                                dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
                               
                                dt_planpago = Clases.solicitudes.PR_GET_DATOS_PLANPAGO_SOLICITUD(lblCodSolicitud.Text);
                                dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(lblCodSolicitud.Text);
                                dt_paisdpto = Clases.solicitudes.PR_GET_PAISDEPTO(lblCodSolicitud.Text);
                                dt_ticketcabecera = Clases.Tickets.GET_TICKETS(lblCodSolicitud.Text);
                                string cod_sol_ticket = "";
                                if (dt_ticketcabecera.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt_ticketcabecera.Rows)
                                    {
                                        cod_sol_ticket = dr["COD_SOLICITUD_TICKET"].ToString();
                                    }
                                }

                                dt_ticketdetalle = Clases.Tickets.GET_TICKETS_DETALLE(cod_sol_ticket);
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSDireccion", dt_direccion));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSCliente", dt_cliente));
                             
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSPlanPagos", dt_planpago));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSPaisDpto", dt_paisdpto));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSTicketCabecera", dt_ticketcabecera));
                                rv.LocalReport.DataSources.Add(new ReportDataSource("DSTicketDetalle", dt_ticketdetalle));
                              
                                    
                                rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/contrato_texto.rdlc");
                                rv.LocalReport.EnableHyperlinks = true;
                                string razon_social = "";
                                string nit = "";
                                if (dt_cliente.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt_cliente.Rows)
                                    {
                                        razon_social = dr["razon_social"].ToString();
                                        nit = dr["ci_completo"].ToString();
                                    }
                                }

                                string monto = "";
                                string literal = "";
                                if (dt_solicitud.Rows.Count > 0)
                                {
                                    foreach (DataRow dr2 in dt_solicitud.Rows)
                                    {
                                        monto = dr2["MONTO_FINANCIADO"].ToString();
                                        literal = dr2["MONTO_FINANCIADO_LITERAL"].ToString();
                                    }
                                }
                                string presente_pagare = "Por el presente PAGARE, " + razon_social + " debe y pagara incondicionalmente a la orden de la COMPAÑIA DE SERVICIOS DE TRANSPORTE AEREO AMASZONAS S.A., la suma de capital " + monto + ".- (" + literal + " BOLIVIANOS). A la fecha de su vencimiento.";

                                ReportParameter p_dia = new ReportParameter();
                                p_dia.Name = "dia";
                                p_dia.Values.Add(Convert.ToString(DateTime.Now.Day));
                                p_dia.Visible = true;
                                ReportParameter p_mes = new ReportParameter();
                                p_mes.Name = "mes";
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
                                p_anio.Name = "anio";
                                p_anio.Values.Add(Convert.ToString(DateTime.Now.Year).Remove(0, 2));
                                p_anio.Visible = true;

                                ReportParameter p_codcli = new ReportParameter();
                                p_codcli.Name = "cod_cliente";
                                p_codcli.Values.Add(lblCodCliente.Text);
                                p_codcli.Visible = true;

                                ReportParameter p_fechaven = new ReportParameter();
                                p_fechaven.Name = "fecha_vencimiento";
                                p_fechaven.Values.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                                p_fechaven.Visible = true;

                                ReportParameter p_presente_pagare = new ReportParameter();
                                p_presente_pagare.Name = "por_presente_pagare";
                                p_presente_pagare.Values.Add(presente_pagare);
                                p_presente_pagare.Visible = true;

                                ReportParameter[] rp = { p_dia, p_mes, p_anio, p_codcli, p_fechaven, p_presente_pagare };
                                rv.LocalReport.SetParameters(rp);
                            }
                        }
                            
                    }
                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_convocatorias_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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