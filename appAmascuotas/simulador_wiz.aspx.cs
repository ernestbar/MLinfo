using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace appAmascuotas
{
    
    public partial class simulador_wiz : System.Web.UI.Page
    {
       
        static int pasos = 0;
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
                        btnAnterior.Enabled = false;
                        btnSiguiente.Enabled = true;
                        string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active';document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6'; document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

                        btnNuevo.Visible = false;
                        lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                        DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                                    btnNuevo.Visible = true;
                            }

                        }
                        MultiView1.ActiveViewIndex = 0;
                        MultiView2.ActiveViewIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_juridica_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                    string directorio2 = Server.MapPath("~/Logs");
                    StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                    writer5.WriteLine(ex.ToString());
                    writer5.Close();
                    lblAviso.Text = "Las variables de session caducaron.";
                }



            }
        }
        protected void rblTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTipoCliente.SelectedValue == "01")
            {
                Panel_juridica.Visible = true;
                Panel_natural.Visible = false;
            }
            else
            {
                Panel_juridica.Visible = false;
                Panel_natural.Visible = true;
            }
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (lblPorcentaje.Text != "Cuota inicial menor a 20%" )
            {
                if (lblPorcentaje.Text != "Cuota inicial es mayor o igual al 100%")
                {
                    if (lblPlazo.Text == "")
                    {
                        pasos = pasos + 1;
                    }
                }
                
            }
                
               
            if (pasos == 1)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active';document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView1.ActiveViewIndex = pasos;
                btnAnterior.Enabled = true;
            }
            if (pasos == 2)
            {
                if (lblPorcentaje.Text != "Cuota inicial menor a 20%")
                {
                    if (dominio.VerificarPlazo(decimal.Parse(txtMeses.Text)) == true)
                    {
                        string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active';document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                        MultiView1.ActiveViewIndex = pasos;
                        btnSiguiente.Enabled = false;
                        lblPlazo.Text = "";
                    }
                    else
                    {
                        pasos = 2;
                        lblPlazo.Text = "El plazo no esta en el rango de parametros.";
                        txtMeses.Focus();
                    }
                    
                }
            }
            

        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            pasos = pasos - 1;
            if (pasos == 1)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active';document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView1.ActiveViewIndex = pasos;
                btnAnterior.Enabled = true;
                btnSiguiente.Enabled = true;
            }
            if (pasos == 0)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active';document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6'; document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView1.ActiveViewIndex = pasos;
                btnSiguiente.Enabled = true;
                btnAnterior.Enabled = false;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_cliente = "";
                decimal monto = decimal.Parse(txtMonto.Text);
                int meses = int.Parse(txtMeses.Text);
                string tipo_cliente = rblTipoCliente.Text;
                string nombre = "";
                string paterno = "";
                string materno = "";
                string razon_social = "";
                string nro_documento = "";
                string tel_fijo = "";
                string tel_cel = "";
                string email = "";
                string expedido = "";


                if (tipo_cliente == "01")
                {
                    razon_social = txtRazonSocial.Text;
                    nro_documento = txtNit.Text;
                    //tel_fijo = txtTelJ.Text;
                    tel_cel = txtCelJ.Text;
                    //email = txtEmailJ.Text;
                    expedido = ddlExpedidoJ.SelectedValue;
                }
                else
                {
                    nombre = txtNombre.Text;
                    paterno = txtPaterno.Text;
                    materno = txtMaterno.Text;
                    nro_documento = txtCi.Text;
                    tel_fijo = txtTel.Text;
                    tel_cel = txtCel.Text;
                    email = txtEmail.Text;
                    expedido = ddlexpedido.SelectedValue;
                }
                string resultados = "";
                if (lblCodCliente.Text == "")
                {
                    simular obj = new simular(lblCodCliente.Text, decimal.Parse(txtMontoTotal.Text), int.Parse(txtMeses.Text), rblTipoCliente.SelectedValue, nombre, paterno, materno, razon_social,
                       nro_documento, expedido, tel_fijo, tel_cel, email, lblUsuario.Text, decimal.Parse(txtAportePropio.Text), txtNombre2.Text, txtNombre3.Text, txtExt.Text,
                       txtPaginaWebJ.Text, txtContactoJ.Text, txtCelJ.Text);//remplazar el 1 por el codigo del usuario
                    resultados = obj.ABM();
                }
                else
                {
                    simular obj = new simular(lblCodCliente.Text, decimal.Parse(txtMontoTotal.Text), int.Parse(txtMeses.Text), rblTipoCliente.SelectedValue, nombre, paterno, materno, razon_social,
                        nro_documento, expedido, tel_fijo, tel_cel, email, lblUsuario.Text, decimal.Parse(txtAportePropio.Text), txtNombre2.Text, txtNombre3.Text, txtExt.Text,
                       txtPaginaWebJ.Text, txtContactoJ.Text, txtCelJ.Text);//remplazar el 1 por el codigo del usuario
                    resultados = obj.ABM();
                }

                btnAnterior.Enabled = false;
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active';document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6'; document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = true;
                
               // MultiView1.ActiveViewIndex = 0;
                reset_datos();
                odsClientesSim.DataBind();
                Repeater1.DataBind();
                pasos = 0;
                string[] resultado = resultados.Split('|');

                if (int.Parse(resultado[0]) > 0)
                {
                    Session["COD_CLIENTE"] = lblCodCliente.Text;
                    Session["COD_SIMULADOR"] = resultado[0];
                    //Response.Redirect("ReportePlanPago.aspx");
                }
                lblAviso.Text = resultado[1];
                ReportViewer rv = new ReportViewer();
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["amaszonasConn"].ConnectionString);


                //DataSetReportes dsRdlc = new DataSetReportes();

                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adp = new SqlDataAdapter();
                cmd.Connection = cnx;
                cmd.CommandText = "PR_GET_DATOS_PLANPAGO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                cmd.Parameters.AddWithValue("PV_COD_SIMULADOR", resultado[0]);
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
                cmd2.Parameters.AddWithValue("PV_COD_SIMULADOR", resultado[0]);
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
                MultiView1.ActiveViewIndex = 0;
                MultiView2.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }
        public void reset_datos()
        {
            lblPlazo.Text = "";
            lblPorcentaje.Text = "";
            lblAviso.Text = "";
            txtAportePropio.Text = "";
            txtCel.Text = "";
            txtCelJ.Text = "";
            txtCi.Text = "";
            txtContactoJ.Text = "";
            txtEmail.Text = "";
            //txtEmailJ.Text = "";
            txtExt.Text = "";
            txtMaterno.Text = "";
            txtMeses.Text = "";
            txtMonto.Text = "";
            txtMontoTotal.Text = "";
            txtNit.Text = "";
            txtNombre2.Text = "";
            txtNombre.Text = "";
            txtNombre3.Text = "";
            txtPaginaWebJ.Text = "";
            txtPaterno.Text = "";
            txtRazonSocial.Text = "";
            txtTel.Text = "";
            rblTipoCliente.SelectedIndex = -1;
            if (ddlexpedido.Items.Count > 0) { ddlexpedido.SelectedIndex = 0; }
            if (ddlExpedidoJ.Items.Count > 0) { ddlExpedidoJ.SelectedIndex = 0; }
            Panel_juridica.Visible = false;
            Panel_natural.Visible = false;
        }
        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Session["COD_CLIENTE"] = id;
                Response.Redirect("simulador_detalle.aspx?RME=" + lblCodMenuRol.Text);
            }
            catch
            { lblAviso.Text = "Las variables de session caducaron."; }
            
            //MultiView1.ActiveViewIndex = 2;
            //lblCodCliente.Text = id;
            //odsClienteDetalle.DataBind();
            //Repeater2.DataBind();

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }



        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                lblPorcentaje.Text = "";
                lblPlazo.Text = "";
                pasos = 0;
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                MultiView2.ActiveViewIndex = 1;
                lblCodCliente.Text = id;
                DataTable dt = new DataTable();
                dt = simular.Datos_cliente_simuldor(id);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["tipo_cliente"].ToString().Trim() == "02")
                        {
                            Panel_natural.Visible = true; Panel_juridica.Visible = false;
                            if (dr["nombre"] != null) { txtNombre.Text = dr["nombre"].ToString(); }
                            else { txtNombre.Text = ""; }
                            if (dr["segundo_nombre"] != null) { txtNombre2.Text = dr["segundo_nombre"].ToString(); }
                            else { txtNombre2.Text = ""; }
                            if (dr["tercer_nombre"] != null) { txtNombre3.Text = dr["tercer_nombre"].ToString(); }
                            else { txtNombre3.Text = ""; }
                            if (dr["ext"] != null) { txtExt.Text = dr["ext"].ToString(); }
                            else { txtExt.Text = ""; }
                            if (dr["apellido_paterno"] != null) { txtPaterno.Text = dr["apellido_paterno"].ToString(); }
                            else { txtPaterno.Text = ""; }
                            if (dr["apellido_materno"] != null) { txtMaterno.Text = dr["apellido_materno"].ToString(); }
                            else { txtMaterno.Text = ""; }
                            if (dr["email"] != null) { txtEmail.Text = dr["email"].ToString(); }
                            else { txtEmail.Text = ""; }
                            if (dr["numero_documento"] != null) { txtCi.Text = dr["numero_documento"].ToString(); }
                            else { txtCi.Text = ""; }
                            if (dr["telefono_fijo"] != null) { txtTel.Text = dr["telefono_fijo"].ToString(); }
                            else { txtTel.Text = ""; }
                            if (dr["telefono_celular"] != null) { txtCel.Text = dr["telefono_celular"].ToString(); }
                            else { txtCel.Text = ""; }
                            if (dr["expedido"] != null) { ddlexpedido.SelectedValue = dr["expedido"].ToString(); }


                        }
                        else
                        {
                            Panel_natural.Visible = false; Panel_juridica.Visible = true;
                            if (dr["razon_social"] != null) { txtRazonSocial.Text = dr["razon_social"].ToString(); }
                            else { txtRazonSocial.Text = ""; }
                            if (dr["numero_documento"] != null) { txtNit.Text = dr["numero_documento"].ToString(); }
                            else { txtNit.Text = ""; }
                            //if (dr["email"] != null) { txtEmailJ.Text = dr["email"].ToString(); }
                            //else { txtEmailJ.Text = ""; }
                            if (dr["nombre_contacto"] != null) { txtContactoJ.Text = dr["nombre_contacto"].ToString(); }
                            else { txtContactoJ.Text = ""; }
                            if (dr["celular_contacto"] != null) { txtCelJ.Text = dr["celular_contacto"].ToString(); }
                            else { txtCelJ.Text = ""; }
                            if (dr["pagina_web"] != null) { txtPaginaWebJ.Text = dr["pagina_web"].ToString(); }
                            else { txtPaginaWebJ.Text = ""; }
                            if (dr["expedido"] != null) { if (dr["expedido"].ToString() != "") { ddlExpedidoJ.SelectedValue = dr["expedido"].ToString(); } }
                        }
                        rblTipoCliente.SelectedValue = dr["tipo_cliente"].ToString();
                        rblTipoCliente.Enabled = false;
                    }

                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }



        protected void btnNuevaSimulacion_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            lblPorcentaje.Text = "";
            lblPlazo.Text = "";
            MultiView2.ActiveViewIndex = 1;
            reset_datos();
            lblCodCliente.Text = "";
            pasos = 0;
            rblTipoCliente.Enabled = true;
        }



        protected void btnVolverSimuldores_Click(object sender, EventArgs e)
        {
            MultiView2.ActiveViewIndex = 2;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView2.ActiveViewIndex = 0;

        }

        protected void ddlexpedido_DataBound(object sender, EventArgs e)
        {
            ListItem item = new ListItem();
            item.Text = "SELECCIONAR";
            item.Value = "SELECCIONAR";
            ddlexpedido.Items.Insert(0, item);
        }

        protected void txtAportePropio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active';document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                txtMonto.Text = (decimal.Parse(txtMontoTotal.Text) - decimal.Parse(txtAportePropio.Text)).ToString();
                decimal porcentaje = 0;
                porcentaje = (decimal.Parse(txtAportePropio.Text) / decimal.Parse(txtMontoTotal.Text)) * 100;
                if (porcentaje >= 20 & porcentaje < 100)
                {
                    lblPorcentaje.ForeColor = System.Drawing.Color.Blue;
                    lblPorcentaje.Text = Math.Round(porcentaje, 2).ToString() + "%";
                    txtMeses.Focus();
                }
                else
                {
                    lblPorcentaje.ForeColor = System.Drawing.Color.Red;
                    if (porcentaje >= 100)
                    { lblPorcentaje.Text = "Cuota inicial es mayor o igual al 100%"; }
                    else
                    { lblPorcentaje.Text = "Cuota inicial menor a 20%"; }

                    txtAportePropio.Focus();
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }

        protected void ddlExpedidoJ_DataBound(object sender, EventArgs e)
        {
            ListItem item = new ListItem();
            item.Text = "SELECCIONAR";
            item.Value = "SELECCIONAR";
            ddlExpedidoJ.Items.Insert(0, item);
        }

        //protected void btnTraerDatos_Click(object sender, EventArgs e)
        //{
        //    string customerName = Request.Form[txtCi.UniqueID];
        //    string customerId = Request.Form[hfCustomerId.UniqueID];
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + customerName + "\\nID: " + customerId + "');", true);
        //}

        protected void lbtnTraerDatos_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = Request.Form[txtCi.UniqueID];
                string customerId = Request.Form[hfCustomerId.UniqueID];
                if (customerId != "")
                {
                    lblCodCliente.Text = customerId;
                    DataTable dt = new DataTable();
                    dt = simular.Datos_cliente_simuldor(customerId);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["tipo_cliente"].ToString().Trim() == "02")
                            {
                                Panel_natural.Visible = true; Panel_juridica.Visible = false;
                                if (dr["nombre"] != null) { txtNombre.Text = dr["nombre"].ToString(); }
                                else { txtNombre.Text = ""; }
                                if (dr["segundo_nombre"] != null) { txtNombre2.Text = dr["segundo_nombre"].ToString(); }
                                else { txtNombre2.Text = ""; }
                                if (dr["tercer_nombre"] != null) { txtNombre3.Text = dr["tercer_nombre"].ToString(); }
                                else { txtNombre3.Text = ""; }
                                if (dr["ext"] != null) { txtExt.Text = dr["ext"].ToString(); }
                                else { txtExt.Text = ""; }
                                if (dr["apellido_paterno"] != null) { txtPaterno.Text = dr["apellido_paterno"].ToString(); }
                                else { txtPaterno.Text = ""; }
                                if (dr["apellido_materno"] != null) { txtMaterno.Text = dr["apellido_materno"].ToString(); }
                                else { txtMaterno.Text = ""; }
                                if (dr["email"] != null) { txtEmail.Text = dr["email"].ToString(); }
                                else { txtEmail.Text = ""; }
                                if (dr["numero_documento"] != null) { txtCi.Text = dr["numero_documento"].ToString(); }
                                else { txtCi.Text = ""; }
                                if (dr["telefono_fijo"] != null) { txtTel.Text = dr["telefono_fijo"].ToString(); }
                                else { txtTel.Text = ""; }
                                if (dr["telefono_celular"] != null) { txtCel.Text = dr["telefono_celular"].ToString(); }
                                else { txtCel.Text = ""; }
                                if (dr["expedido"] != null) { ddlexpedido.SelectedValue = dr["expedido"].ToString(); }
                                rblTipoCliente.Enabled = false;

                            }
                            else
                            {
                                Panel_natural.Visible = false; Panel_juridica.Visible = true;
                                if (dr["razon_social"] != null) { txtRazonSocial.Text = dr["razon_social"].ToString(); }
                                else { txtRazonSocial.Text = ""; }
                                if (dr["numero_documento"] != null) { txtNit.Text = dr["numero_documento"].ToString(); }
                                else { txtNit.Text = ""; }
                                //if (dr["email"] != null) { txtEmailJ.Text = dr["email"].ToString(); }
                                //else { txtEmailJ.Text = ""; }
                                if (dr["NOMBRE_CONTACTO"] != null) { txtContactoJ.Text = dr["NOMBRE_CONTACTO"].ToString(); }
                                else { txtContactoJ.Text = ""; }
                                if (dr["telefono_celular"] != null) { txtCelJ.Text = dr["telefono_celular"].ToString(); }
                                else { txtCelJ.Text = ""; }
                                if (dr["pagina_web"] != null) { txtCelJ.Text = dr["telefono_celular"].ToString(); }
                                else { txtCelJ.Text = ""; }
                                if (dr["expedido"] != null) { if (dr["expedido"].ToString() != "") { ddlExpedidoJ.SelectedValue = dr["expedido"].ToString(); } }
                            }
                            //rblTipoCliente.SelectedValue = dr["tipo_cliente"].ToString();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + customerName + "\\nID: " + customerId + "');", true);
        }

        protected void lbtnTraerDatosJ_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = Request.Form[txtNit.UniqueID];
                string customerId = Request.Form[hfCustomerId2.UniqueID];
                if (customerId != "")
                {
                    lblCodCliente.Text = customerId;
                    DataTable dt = new DataTable();
                    dt = simular.Datos_cliente_simuldor(customerId);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["tipo_cliente"].ToString().Trim() == "02")
                            {
                                Panel_natural.Visible = true; Panel_juridica.Visible = false;
                                if (dr["nombre"] != null) { txtNombre.Text = dr["nombre"].ToString(); }
                                else { txtNombre.Text = ""; }
                                //if (dr["segundo_nombre"] != null) { txtNombre2.Text = dr["segundo_nombre"].ToString(); }
                                //else { txtNombre2.Text = ""; }
                                if (dr["apellido_paterno"] != null) { txtPaterno.Text = dr["apellido_paterno"].ToString(); }
                                else { txtPaterno.Text = ""; }
                                if (dr["apellido_materno"] != null) { txtMaterno.Text = dr["apellido_materno"].ToString(); }
                                else { txtMaterno.Text = ""; }
                                if (dr["email"] != null) { txtEmail.Text = dr["email"].ToString(); }
                                else { txtEmail.Text = ""; }
                                if (dr["numero_documento"] != null) { txtCi.Text = dr["numero_documento"].ToString(); }
                                else { txtCi.Text = ""; }
                                if (dr["nombre_contacto"] != null) { txtContactoJ.Text = dr["nombre_contacto"].ToString(); }
                                else { txtContactoJ.Text = ""; }
                                if (dr["celular_contacto"] != null) { txtCelJ.Text = dr["celular_contacto"].ToString(); }
                                else { txtCelJ.Text = ""; }
                                if (dr["pagina_web"] != null) { txtPaginaWebJ.Text = dr["pagina_web"].ToString(); }
                                else { txtPaginaWebJ.Text = ""; }
                                if (dr["expedido"] != null) { ddlexpedido.SelectedValue = dr["expedido"].ToString(); }


                            }
                            else
                            {
                                Panel_natural.Visible = false; Panel_juridica.Visible = true;
                                if (dr["razon_social"] != null) { txtRazonSocial.Text = dr["razon_social"].ToString(); }
                                else { txtRazonSocial.Text = ""; }
                                if (dr["numero_documento"] != null) { txtNit.Text = dr["numero_documento"].ToString(); }
                                else { txtNit.Text = ""; }
                                //if (dr["email"] != null) { txtEmailJ.Text = dr["email"].ToString(); }
                                //else { txtEmailJ.Text = ""; }
                                //if (dr["telefono_fijo"] != null) { txtTelJ.Text = dr["telefono_fijo"].ToString(); }
                                //else { txtTelJ.Text = ""; }
                                if (dr["nombre_contacto"] != null) { txtContactoJ.Text = dr["nombre_contacto"].ToString(); }
                                else { txtContactoJ.Text = ""; }
                                if (dr["celular_contacto"] != null) { txtCelJ.Text = dr["celular_contacto"].ToString(); }
                                else { txtCelJ.Text = ""; }
                                if (dr["pagina_web"] != null) { txtPaginaWebJ.Text = dr["pagina_web"].ToString(); }
                                else { txtPaginaWebJ.Text = ""; }
                                if (dr["expedido"] != null) { if (dr["expedido"].ToString() != "") { ddlExpedidoJ.SelectedValue = dr["expedido"].ToString(); } }
                                rblTipoCliente.Enabled = false;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bNuevo = (Button)e.Item.FindControl("btnNuevo");
                Button bDetalles = (Button)e.Item.FindControl("btnDetalles");
                bDetalles.Visible = false;
                bNuevo.Visible = false;
                DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                       
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "DETALLES")
                            bDetalles.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                            bNuevo.Visible = true;
                    }

                }


            }
        }
        protected void btnCancelarWizard_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 0;
            MultiView2.ActiveViewIndex = 0;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = false;
            reset_datos();
            pasos = 0;
            rblTipoCliente.Enabled = true;
        }
    }
    
}