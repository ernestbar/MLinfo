using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;
using Microsoft.Reporting.WebForms;

namespace appAmascuotas
{
    public partial class juridica_wiz : System.Web.UI.Page
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
                        //string s;
                        //s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        //lblAviso.Text = s;
                        string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

                        //inciar_mapa("-17.8".Replace(".", decSep).Replace(",", decSep), "-63.1667".Replace(".", decSep).Replace(",", decSep));
                        txtSociedadOtros.Enabled = false;
                        cargar_calendarios();
                        if (pasos == 0)
                        {
                            btnAnterior.Enabled = false;
                            btnSiguiente.Enabled = true;
                        }


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

        public void cargar_calendarios()
        {
            ddlFunAño.Items.Clear();
            ddlFunDia.Items.Clear();
            ddlFunMes.Items.Clear();
            int d = 1;
            for (d = 1; d <= 31; d++)
            {
                ListItem dia = new ListItem();
                dia.Text = d.ToString();
                dia.Value = d.ToString();
                // ddlGarDia.Items.Add(dia);
                ddlFunDia.Items.Add(dia);
            }
            int m = 1;
            for (m = 1; m <= 12; m++)
            {
                ListItem mes = new ListItem();
                if (m == 1)
                {
                    mes.Text = "ENERO";
                    mes.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes.Text = "FEBRERO";
                    mes.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes.Text = "MARZO";
                    mes.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes.Text = "ABRIL";
                    mes.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes.Text = "MAYO";
                    mes.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes.Text = "JUNIO";
                    mes.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes.Text = "JULIO";
                    mes.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes.Text = "AGOSTO";
                    mes.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes.Text = "SEPTIEMBRE";
                    mes.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes.Text = "OCTUBRE";
                    mes.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes.Text = "NOVIEMBRE";
                    mes.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes.Text = "DICIEMBRE";
                    mes.Value = m.ToString();
                }

                //ddlGarMes.Items.Add(mes);
                ddlFunMes.Items.Add(mes);
            }
            int a = 1900;
            for (a = 1900; a <= DateTime.Now.Year; a++)
            {
                ListItem anio = new ListItem();
                anio.Text = a.ToString();
                anio.Value = a.ToString();
                // ddlGarAño.Items.Add(anio);
                ddlFunAño.Items.Add(anio);
            }
            ddlFunDia.Items.Insert(0, "DIA");
            ddlFunMes.Items.Insert(0, "MES");
            ddlFunAño.Items.Insert(0, "AÑO");


        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (lblPorcentaje.Text != "Cuota inicial menor a 20%")
            {
                if (lblPatNeto.Text != "Los egresos superan a los ingresos.")
                {
                    if (pasos <= 6)
                        pasos = pasos + 1;
                }


            }

            if (pasos == 1)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView2.ActiveViewIndex = pasos;
                btnAnterior.Enabled = true;
            }
            if (pasos == 2)
            {
                
                    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                  "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                  "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
               
                MultiView2.ActiveViewIndex = pasos;
            }
            if (pasos == 3)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView2.ActiveViewIndex = pasos;
            }
            if (pasos == 4)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView2.ActiveViewIndex = pasos;
            }
            if (pasos == 5)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView2.ActiveViewIndex = pasos;
                btnSiguiente.Enabled = false;

            }
            //if (pasos == 6)
            //{
            //    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                
            //    MultiView2.ActiveViewIndex = pasos;
            //    btnSiguiente.Enabled = false;
               

            //}
            //if (pasos == 7)
            //{
            //    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p8').className = 'col-md-3 col-sm-4 col-6 active';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //    MultiView2.ActiveViewIndex = pasos;
            //}
            //if (pasos == 8)
            //{
            //    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p8').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p9').className = 'col-md-3 col-sm-4 col-6 active';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //    MultiView2.ActiveViewIndex = pasos;
            //    btnSiguiente.Enabled = false;
            //}




        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {


            if (pasos >= 1)
            {
               
                    pasos = pasos - 1;
            }


           

            if (pasos == 0)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView2.ActiveViewIndex = pasos;
                btnAnterior.Enabled = false;
               

            }
            if (pasos == 1)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView2.ActiveViewIndex = pasos;
                btnAnterior.Enabled = true;
            }
            if (pasos == 2)
            {

                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
             "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
             "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
               

                MultiView2.ActiveViewIndex = pasos;
            }
            if (pasos == 3)
            {

                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                  "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                  "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                  "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

                MultiView2.ActiveViewIndex = pasos;
            }
            if (pasos == 4)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView2.ActiveViewIndex = pasos;
                btnSiguiente.Enabled = true;
            }
            if (pasos == 5)
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                MultiView2.ActiveViewIndex = pasos;
                btnSiguiente.Enabled = true;


            }
            //if (pasos == 6)
            //{
            //    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //    MultiView2.ActiveViewIndex = pasos;
            //    btnSiguiente.Enabled = true;

            //}
            //if (pasos == 7)
            //{
            //    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p8').className = 'col-md-3 col-sm-4 col-6 active';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //    MultiView2.ActiveViewIndex = pasos;
            //    btnSiguiente.Enabled = true;
            //}
            //if (pasos == 8)
            //{
            //    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p8').className = 'col-md-3 col-sm-4 col-6 active'; " +
            //    "document.getElementById('p9').className = 'col-md-3 col-sm-4 col-6 active';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //    MultiView2.ActiveViewIndex = pasos;
            //    btnSiguiente.Enabled = false;
            //}
        }

        protected void btnCancelarWizard_Click(object sender, EventArgs e)
        {
            MultiView2.ActiveViewIndex = 0;
            MultiView1.ActiveViewIndex = 0;
        }


        protected void ddlRuta1_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlRuta1.Items.Insert(0, miitem);

        }

        protected void ddlRuta2_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlRuta2.Items.Insert(0, miitem);
        }

        protected void txtCuotaInicial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                decimal porcentaje = 0;
                if (txtMontoTotal.Text == "")
                {
                    lblPorcentaje.Text = "Debe colocar el monto a financiar.";
                }
                else
                {
                    porcentaje = (decimal.Parse(txtCuotaInicial.Text) / decimal.Parse(txtMontoTotal.Text)) * 100;
                    if (porcentaje >= 20 & porcentaje < 100)
                    {
                        lblPorcentaje.ForeColor = System.Drawing.Color.Blue;
                        lblPorcentaje.Text = Math.Round(porcentaje, 2).ToString() + "%";
                        txtPlazoMeses.Focus();
                        txtMontoFinanciar.Text = (decimal.Parse(txtMontoTotal.Text) - decimal.Parse(txtCuotaInicial.Text)).ToString();
                    }
                    else
                    {
                        lblPorcentaje.ForeColor = System.Drawing.Color.Red;
                        if (porcentaje >= 100)
                        { lblPorcentaje.Text = "Cuota inicial es mayor o igual al 100%"; }
                        else
                        { lblPorcentaje.Text = "Cuota inicial menor a 20%"; }
                        txtMontoFinanciar.Text = "";
                        txtCuotaInicial.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_juridica_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Hubo un problema por favor consute a su administrador.";
            }


        }

      


       

        protected void ddlExpedido_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlExpedido.Items.Insert(0, miitem);
        }

        protected void lbtnTraerDatos_Click(object sender, EventArgs e)
        {
            try
            {
                string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                        "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                string customerName = Request.Form[txtNit.UniqueID];
                string customerId = Request.Form[hfCustomerId.UniqueID];
                if (customerId != "")
                {
                    lblCodCliente.Text = customerId;
                    ////////////////////DATOS GENERALES//////////////////////
                    DataTable dt = new DataTable();
                    dt = simular.Datos_cliente_simuldor(customerId);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["tipo_cliente"].ToString().Trim() == "01")
                            {
                                if (String.IsNullOrEmpty(dr["razon_social"].ToString())) { txtRazonSocial.Text = ""; } else { txtRazonSocial.Text = dr["razon_social"].ToString(); }

                                if (String.IsNullOrEmpty(dr["numero_documento"].ToString())) { txtNit.Text = ""; } else { txtNit.Text = dr["numero_documento"].ToString(); }

                                if (String.IsNullOrEmpty(dr["FECHA_FUNNAC"].ToString())) { }
                                else
                                {
                                    DateTime FECHA_AUX = (DateTime)dr["FECHA_FUNNAC"];
                                    ddlFunDia.SelectedValue = FECHA_AUX.Day.ToString();
                                    ddlFunMes.SelectedValue = FECHA_AUX.Month.ToString();
                                    ddlFunAño.SelectedValue = FECHA_AUX.Year.ToString();

                                }

                                if (String.IsNullOrEmpty(dr["telefono_fijo"].ToString())) { txtTelefono.Text = ""; } else { txtTelefono.Text = dr["telefono_fijo"].ToString(); }

                                if (String.IsNullOrEmpty(dr["pagina_web"].ToString())) { txtPaginaWeb.Text = ""; } else { txtPaginaWeb.Text = dr["pagina_web"].ToString(); }
                                if (String.IsNullOrEmpty(dr["expedido"].ToString())) { } else { ddlExpedido.SelectedValue = dr["expedido"].ToString(); }
                                if (String.IsNullOrEmpty(dr["SOCIEDAD"].ToString())) { } else { rblClaseSociedad.SelectedValue = dr["SOCIEDAD"].ToString(); }
                                if (String.IsNullOrEmpty(dr["ACTIVIDAD"].ToString())) { txtActividad.Text = ""; } else { txtActividad.Text = dr["ACTIVIDAD"].ToString(); }
                                if (String.IsNullOrEmpty(dr["RUBRO"].ToString())) { txtRubro.Text = ""; } else { txtRubro.Text = dr["RUBRO"].ToString(); }
                                if (String.IsNullOrEmpty(dr["GRUPO_ECO"].ToString())) { txtGrupoEconomico.Text = ""; } else { txtGrupoEconomico.Text = dr["GRUPO_ECO"].ToString(); }

                            }

                        }

                    }
                    ////////////////////////////DATOS REPRESENTATE LEGALES//////////////////////
                    DataTable dt1 = new DataTable();
                    dt1 = Clases.clientes.PR_GET_REPRESENTANTE_LEGAL(customerId);
                    int count_rl = 0;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            if (count_rl == 0)
                            {
                                if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep1.Text = ""; } else { lblCodRep1.Text = dr1["COD_REP_LEGAL"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre1.Text = ""; } else { txtRepNombre1.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder1.Text = ""; } else { txtRepNroPoder1.Text = dr1["NRO_PODER"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail1.Text = ""; } else { txtRepEmail1.Text = dr1["EMAIL"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono1.Text = ""; } else { txtRepTelefono1.Text = dr1["TELEFONO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo1.Text = ""; } else { txtRepCargo1.Text = dr1["CARGO"].ToString(); }
                            }

                            if (count_rl == 1)
                            {
                                if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep2.Text = ""; } else { lblCodRep2.Text = dr1["COD_REP_LEGAL"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre2.Text = ""; } else { txtRepNombre2.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder2.Text = ""; } else { txtRepNroPoder2.Text = dr1["NRO_PODER"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail2.Text = ""; } else { txtRepEmail2.Text = dr1["EMAIL"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono2.Text = ""; } else { txtRepTelefono2.Text = dr1["TELEFONO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi2.Text = ""; } else { txtRepCi2.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo2.Text = ""; } else { txtRepCargo2.Text = dr1["CARGO"].ToString(); }
                            }

                            if (count_rl == 2)
                            {
                                if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep3.Text = ""; } else { lblCodRep3.Text = dr1["COD_REP_LEGAL"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre3.Text = ""; } else { txtRepNombre3.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder3.Text = ""; } else { txtRepNroPoder3.Text = dr1["NRO_PODER"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail3.Text = ""; } else { txtRepEmail3.Text = dr1["EMAIL"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono3.Text = ""; } else { txtRepTelefono3.Text = dr1["TELEFONO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi3.Text = ""; } else { txtRepCi3.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo3.Text = ""; } else { txtRepCargo3.Text = dr1["CARGO"].ToString(); }
                            }

                            if (count_rl == 3)
                            {
                                if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep4.Text = ""; } else { lblCodRep4.Text = dr1["COD_REP_LEGAL"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre4.Text = ""; } else { txtRepNombre4.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder4.Text = ""; } else { txtRepNroPoder4.Text = dr1["NRO_PODER"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail4.Text = ""; } else { txtRepEmail4.Text = dr1["EMAIL"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono4.Text = ""; } else { txtRepTelefono4.Text = dr1["TELEFONO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi4.Text = ""; } else { txtRepCi4.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo4.Text = ""; } else { txtRepCargo4.Text = dr1["CARGO"].ToString(); }
                            }
                            count_rl++;
                        }

                    }
                    ////////////////////////////DATOS DOMICILIO EMPRESA//////////////////////
                    //rblTipoVivienda.DataBind();
                    //rblDetalleVivienda.DataBind();
                    DataTable dt2 = new DataTable();
                    dt2 = Clases.clientes.PR_GET_DIRECCION(customerId);
                    if (dt2.Rows.Count > 0)
                    {
                        foreach (DataRow dr2 in dt2.Rows)
                        {

                            if (String.IsNullOrEmpty(dr2["COD_DIRECCION"].ToString())) { lblCodDir.Text = ""; } else { lblCodDir.Text = dr2["COD_DIRECCION"].ToString(); }
                            //if (String.IsNullOrEmpty(dr2["TIPO_VIVIENDA"].ToString())) { } else { rblTipoVivienda.SelectedValue = dr2["TIPO_VIVIENDA"].ToString(); }
                            //if (String.IsNullOrEmpty(dr2["DETALLE"].ToString())) { } else { rblDetalleVivienda.SelectedValue = dr2["DETALLE"].ToString(); }
                            //if (String.IsNullOrEmpty(dr2["OTRA_DET"].ToString())) { txtDetViviendaOtros.Text = ""; } else { txtDetViviendaOtros.Text = dr2["OTRA_DET"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["BARRIO"].ToString())) { txtBarrio.Text = ""; } else { txtBarrio.Text = dr2["BARRIO"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["CONDOMINIO"].ToString())) { txtCondominio.Text = ""; } else { txtCondominio.Text = dr2["CONDOMINIO"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["URBANIZACION"].ToString())) { txtUrbanizacion.Text = ""; } else { txtUrbanizacion.Text = dr2["URBANIZACION"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["CIUDAD"].ToString())) { txtCiudad.Text = ""; } else { txtCiudad.Text = dr2["CIUDAD"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["AVENIDA"].ToString())) { txtAvenida.Text = ""; } else { txtAvenida.Text = dr2["AVENIDA"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["CALLE"].ToString())) { txtCalle.Text = ""; } else { txtCalle.Text = dr2["CALLE"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["PASIILO_CARRETERA"].ToString())) { txtPasilloCarretera.Text = ""; } else { txtPasilloCarretera.Text = dr2["PASIILO_CARRETERA"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["NRO"].ToString())) { txtNro.Text = ""; } else { txtNro.Text = dr2["NRO"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["EDIFICIO"].ToString())) { txtEdif.Text = ""; } else { txtEdif.Text = dr2["EDIFICIO"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["PISO"].ToString())) { txtPiso.Text = ""; } else { txtPiso.Text = dr2["PISO"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["NRO_DPTO"].ToString())) { txtNroDepto.Text = ""; } else { txtNroDepto.Text = dr2["NRO_DPTO"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["TELEFONO"].ToString())) { txtTelDom.Text = ""; } else { txtTelDom.Text = dr2["TELEFONO"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["REFERENCIA"].ToString())) { txtReferencia.Text = ""; } else { txtReferencia.Text = dr2["REFERENCIA"].ToString(); }
                            //if (String.IsNullOrEmpty(dr2["LATITUD"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr2["LATITUD"].ToString(); }
                            //if (String.IsNullOrEmpty(dr2["LONGITUD"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr2["LONGITUD"].ToString(); }
                        }

                    }
                    ////////////////////////////DATOS REFERENCIAS EMPRESA//////////////////////
                    DataTable dt3 = new DataTable();
                    dt3 = Clases.clientes.PR_GET_REFERENCIAS(customerId);
                    int count_ref = 0;
                    if (dt3.Rows.Count > 0)
                    {
                        foreach (DataRow dr3 in dt3.Rows)
                        {
                            if (count_ref == 0)
                            {
                                if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef1.Text = ""; } else { lblCodRef1.Text = dr3["COD_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef1.Text = "02"; } else { lblTipoRef1.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre1.Text = ""; } else { txtRefNombre1.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo1.Text = ""; } else { txtRefTrabajo1.Text = dr3["OCUPACION"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto1.Text = ""; } else { txtRefTelfContacto1.Text = dr3["TELEFONO"].ToString(); }
                            }
                            if (count_ref == 1)
                            {
                                if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef2.Text = ""; } else { lblCodRef2.Text = dr3["COD_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef2.Text = "02"; } else { lblTipoRef2.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre2.Text = ""; } else { txtRefNombre2.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo2.Text = ""; } else { txtRefTrabajo2.Text = dr3["OCUPACION"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto2.Text = ""; } else { txtRefTelfContacto2.Text = dr3["TELEFONO"].ToString(); }
                            }
                            if (count_ref == 2)
                            {
                                if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef3.Text = ""; } else { lblCodRef3.Text = dr3["COD_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef3.Text = "02"; } else { lblTipoRef3.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre3.Text = ""; } else { txtRefNombre3.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo3.Text = ""; } else { txtRefTrabajo3.Text = dr3["OCUPACION"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto3.Text = ""; } else { txtRefTelfContacto3.Text = dr3["TELEFONO"].ToString(); }
                            }
                            count_ref++;
                        }

                    }
                    ////////////////////////////DATOS BALANCE//////////////////////
                    DataTable dt4 = new DataTable();
                    dt4 = Clases.clientes.PR_GET_BALANCE(customerId);

                    if (dt3.Rows.Count > 0)
                    {
                        foreach (DataRow dr4 in dt4.Rows)
                        {

                            if (String.IsNullOrEmpty(dr4["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr4["COD_BALANCE"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["TOTAL_ACTIVOS_SUS"].ToString())) { txtTotActSus.Text = "02"; } else { txtTotActSus.Text = decimal.Parse(dr4["TOTAL_ACTIVOS_SUS"].ToString()).ToString("G").Replace(".", decSep).Replace(",", decSep); }
                            if (String.IsNullOrEmpty(dr4["TOTAL_PASIVOS"].ToString())) { txtTotPasSus.Text = ""; } else { txtTotPasSus.Text = dr4["TOTAL_PASIVOS"].ToString().Replace(".", decSep).Replace(",", decSep); }
                            if (String.IsNullOrEmpty(dr4["PATRIMONIO_SUS"].ToString())) { txtPatNetoSus.Text = ""; } else { txtPatNetoSus.Text = dr4["PATRIMONIO_SUS"].ToString().Replace(".", decSep).Replace(",", decSep); }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_juridica_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Hubo un problema por favor consute a su administrador.";
            }

        }

        protected void txtTotPasSus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                   "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                   "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                   "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                   "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; ";


                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                if (txtTotActSus.Text == "") { txtTotActSus.Text = "0"; }
                if (txtTotPasSus.Text == "") { txtTotPasSus.Text = "0"; }
                decimal patNeto = 0;
                patNeto = decimal.Parse(txtTotActSus.Text) - decimal.Parse(txtTotPasSus.Text);
                if (patNeto > 0)
                {
                    txtPatNetoSus.Text = patNeto.ToString();
                    lblPatNeto.Text = "";
                }
                else
                {
                    lblPatNeto.Text = "El patrimonio neto no puede ser menor o igual a 0";
                }
            }
            catch(Exception ex)
            {
                string nombre_archivo = "error_juridica_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Hubo un problema por favor consute a su administrador.";
            }
            
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
               "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
               "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
               "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
               "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
               "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                //byte[] data;
                //WebClient webClient = new WebClient();
                //if (hfImageUrl.Value == null || hfImageUrl.Value == "")
                //    data = null;
                //else
                //    data = webClient.DownloadData(hfImageUrl.Value);
                //string faux=DateTime.Today.GetDateTimeFormats()
                DateTime fecha_fun = DateTime.Parse("01/01/3000");
                if (ddlFunDia.SelectedValue != "DIA")
                    if (ddlFunMes.SelectedValue != "MES")
                        if (ddlFunAño.SelectedValue != "AÑo")
                        {
                            string s;
                            string fecha = "";
                            s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            if (s.ToUpper() == "DD/MM/YYYY")
                            { fecha = ddlFunDia.SelectedValue + "/" + ddlFunMes.SelectedValue + "/" + ddlFunAño.SelectedValue; }
                            if (s.ToUpper() == "D/M/YYYY")
                            { fecha = ddlFunDia.SelectedValue + "/" + ddlFunMes.SelectedValue + "/" + ddlFunAño.SelectedValue; }
                            if (s.ToUpper() == "MM/DD/YYYY")
                            { fecha = ddlFunMes.SelectedValue + "/" + ddlFunDia.SelectedValue + "/" + ddlFunAño.SelectedValue; }
                            if (s.ToUpper() == "M/D/YYYY")
                            { fecha = ddlFunMes.SelectedValue + "/" + ddlFunDia.SelectedValue + "/" + ddlFunAño.SelectedValue; }
                            fecha_fun = DateTime.Parse(fecha);
                        }


                Clases.clientes obj = new Clases.clientes("I", "01", lblCodCliente.Text, "", "", "", "", "", "", "", "", "", "", 0, "", "",
                   fecha_fun, txtNit.Text, "", ddlExpedido.SelectedValue, "", 0, "",
                   "", txtRazonSocial.Text, rblClaseSociedad.SelectedValue, txtActividad.Text, txtRubro.Text, txtGrupoEconomico.Text,
                   txtTelefono.Text, txtPaginaWeb.Text, "", "", "", "", "", "", "", "", "", "", "", 0, "", "", DateTime.Parse("01/01/3000"), "", "", "", "", "", "", "", 0, "",
                   "", "", "", lblCodDir.Text, "CAS", "ALQ",
                   txtBarrio.Text, txtCondominio.Text, txtUrbanizacion.Text, txtCiudad.Text, txtAvenida.Text, txtCalle.Text, txtPasilloCarretera.Text,
                   txtNro.Text, txtEdif.Text, txtPiso.Text, txtNroDepto.Text, txtTelefono.Text, txtReferencia.Text, "", "", null, "", "",
                   "", 0, "", "", "", "", "",
                   "", 0, lblCodRef1.Text, "02", txtRefNombre1.Text, txtRefTrabajo1.Text, txtRefTelfContacto1.Text,
                   lblCodRef2.Text, "02", txtRefNombre2.Text, txtRefTrabajo2.Text, txtRefTelfContacto2.Text,
                   lblCodRef3.Text, "02", txtRefNombre3.Text, txtRefTrabajo3.Text, txtRefTelfContacto3.Text,
                   lblCodBalance.Text, decimal.Parse(txtTotActSus.Text), decimal.Parse(txtTotPasSus.Text), "", "",
                   "", "", "", "", "", "", "", "", "",//ok
                   "", "", 0, "", "", DateTime.Parse("01/01/3000"), "", "",//ok
                   "", "", 0, "", "",
                   "", "", "", 0, "", "", "", "", "", "", 0,
                   lblCodRep1.Text, txtRepNombre1.Text, txtRepNroPoder1.Text, txtRepCargo1.Text, txtRepEmail1.Text, txtRepTelefono1.Text, txtRepCi1.Text,
                   lblCodRep2.Text, txtRepNombre2.Text, txtRepNroPoder2.Text, txtRepCargo2.Text, txtRepEmail2.Text, txtRepTelefono2.Text, txtRepCi2.Text,
                   lblCodRep3.Text, txtRepNombre3.Text, txtRepNroPoder3.Text, txtRepCargo3.Text, txtRepEmail3.Text, txtRepTelefono3.Text, txtRepCi3.Text,
                   lblCodRep4.Text, txtRepNombre4.Text, txtRepNroPoder4.Text, txtRepCargo4.Text, txtRepEmail4.Text, txtRepTelefono4.Text, txtRepCi4.Text,
                    lblUsuario.Text,null);
                string[] resultado = obj.ABM().Split('|');
                lblAviso.Text = resultado[0];
                Session["COD_CLIENTE"] = resultado[1];
                string cod_cliente = resultado[1];
                Clases.solicitudes obk_sol = new Clases.solicitudes("I", "", ddlRuta1.SelectedValue, ddlRuta2.SelectedValue, rblTipoRuta.SelectedValue,
                    int.Parse(txtCantPasajes.Text), decimal.Parse(txtMontoTotal.Text), decimal.Parse(txtCuotaInicial.Text), decimal.Parse(txtMontoFinanciar.Text),
                    int.Parse(txtPlazoMeses.Text), txtObservacopmes.Text,
                    resultado[1], "", lblUsuario.Text);
                string[] resultado2 = obk_sol.ABM().Split('|');
                Session["COD_SOLICITUD"] = resultado2[0];
                string cod_solicitud= resultado2[0];

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

                dt_cliente = Clases.clientes.PR_GET_CLIENTE(cod_cliente);
                dt_conyugue = Clases.clientes.PR_GET_CONYUGUE(cod_cliente);
                dt_domicilio = Clases.clientes.PR_GET_DIRECCION(cod_cliente);
                dt_datos_laborales = Clases.clientes.PR_GET_DATOS_LABORALES(cod_cliente);
                dt_referencias = Clases.clientes.PR_GET_REFERENCIAS(cod_cliente);
                dt_balance = Clases.clientes.PR_GET_BALANCE(cod_cliente);
                dt_ingresos = Clases.clientes.PR_GET_INGRESOS(cod_cliente);
                dt_egresos = Clases.clientes.PR_GET_EGRESOS(cod_cliente);
                dt_represetnates_legales = Clases.clientes.PR_GET_REPRESENTANTE_LEGAL(cod_cliente);
                dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(cod_solicitud);
                dt_garante = Clases.clientes.PR_GET_GARANTE(cod_cliente, cod_solicitud);
                dt_paisdepto = Clases.solicitudes.PR_GET_PAISDEPTO(cod_solicitud);

                ReportViewer rv = new ReportViewer();
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

                string nombre_reporte2 = "PDF/reporte" + Session.SessionID + ".pdf";
                String filePath = MapPath(nombre_reporte);
                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(renderedBytes, 0, renderedBytes.Length);
                fs.Close();

                Response.Write("<script> window.open('" + nombre_reporte2 + "','_blank'); </script>");
                btnGrabar.Visible = false;
                btnContinuar.Visible = true;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_juridica_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            Session["usuario"] = lblUsuario.Text;
            Session["COD_CLIENTE"] = id;
            Session["TIPO_CLIENTE"] = "J";
            Response.Redirect("editar_seccion_j.aspx?RME=" + lblCodMenuRol.Text);
        }
        protected void rblClaseSociedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblClaseSociedad.SelectedItem.Text.ToUpper() != "OTROS")
            {
                txtSociedadOtros.Enabled = false;txtSociedadOtros.Text = "";
            }
            else
            { txtSociedadOtros.Enabled = true;txtSociedadOtros.Focus();  }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnContinuar.Visible = false;
            btnGrabar.Visible = true;
            MultiView1.ActiveViewIndex = 1;
            MultiView2.ActiveViewIndex = 0;
            pasos = 0;
            limpiar_controles();
            lblAviso.Text = "";
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = true;
        }
        public void limpiar_controles()
        {
            foreach (Control item in Page.Form.FindControl("ContentPlaceHolder1").Controls)
            {
                if (item is MultiView)
                {
                    foreach (Control item2 in item.Controls)
                    {
                        if (item2 is View)
                        {
                            foreach (Control item3 in item2.Controls)
                            {
                                if (item3 is MultiView)
                                {
                                    foreach (Control item4 in item3.Controls)
                                    {
                                        if (item4 is View)
                                        {
                                            foreach (Control item5 in item4.Controls)
                                            {
                                                if (item5 is TextBox)
                                                {
                                                    ((TextBox)item5).Text = string.Empty;
                                                }

                                                if (item5 is Label)
                                                {
                                                    ((Label)item5).Text = string.Empty;
                                                }

                                            }

                                        }
                                    }


                                }
                            }

                        }
                    }


                }

            }

            //txtTotPasSus.Text = "0";
            //txtTotPasSus.Text = "0";

            ddlExpedido.DataBind();
            cargar_calendarios();
            ddlRuta1.DataBind();
            ddlRuta2.DataBind();
            

            //rblDetalleVivienda.DataBind();
            rblTipoRuta.DataBind();
            //rblTipoVivienda.DataBind();
            rblClaseSociedad.DataBind();
            //rblDetalleVivienda.DataBind();
            



        }
        //private void inciar_mapa(string lat, string lng)
        //{
        //    Gmap2.resetMarkers();

        //    GLatLng ubicacion1 = new GLatLng(double.Parse(lat), double.Parse(lng));
        //    Gmap2.setCenter(ubicacion1, 11);
        //    //Gmap2.Height = 300;
        //    //Gmap2.Width = 480;
        //    //lblLatitud.Text = lat;
        //    //lblLongitud.Text = lng;
        //    Gmap2.Add(new GControl(GControl.preBuilt.LargeMapControl));
        //    //Gmap2.addControl(new GControl(GControl.preBuilt.LargeMapControl));
        //    Gmap2.Add(new GControl(GControl.preBuilt.MapTypeControl));
        //    //Gmap2.addControl(new GControl(GControl.preBuilt.MapTypeControl));
        //    Gmap2.enableHookMouseWheelToZoom = true;
        //    //Gmap2.enableScrollWheelZoom = true;
        //    GMarker mark1 = new GMarker(ubicacion1);
        //    Gmap2.Add(mark1);
        //    //Gmap2.addGMarker(mark1);
        //    Gmap2.mapType = GMapType.GTypes.Satellite;
        //}
        static string lat, lng, zom;

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            Session["COD_CLIENTE"] = id;
            Session["TIPO_CLIENTE"] = "J";
            Response.Redirect("solicitudes.aspx?RME=" + lblCodMenuRol.Text);
        }

        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            try
            {
                btnContinuar.Visible = false;
                btnGrabar.Visible = true;
                limpiar_controles();
                string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                MultiView1.ActiveViewIndex = 1;
                MultiView2.ActiveViewIndex = 0;
                pasos = 0;
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = true;
                lblAviso.Text = "";

                lblCodCliente.Text = id;
                ////////////////////DATOS GENERALES//////////////////////
                DataTable dt = new DataTable();
                dt = simular.Datos_cliente_simuldor(lblCodCliente.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["tipo_cliente"].ToString().Trim() == "01")
                        {
                            if (String.IsNullOrEmpty(dr["razon_social"].ToString())) { txtRazonSocial.Text = ""; } else { txtRazonSocial.Text = dr["razon_social"].ToString(); }

                            if (String.IsNullOrEmpty(dr["numero_documento"].ToString())) { txtNit.Text = ""; } else { txtNit.Text = dr["numero_documento"].ToString(); }

                            if (String.IsNullOrEmpty(dr["FECHA_FUNNAC"].ToString())) { }
                            else
                            {
                                DateTime FECHA_AUX = (DateTime)dr["FECHA_FUNNAC"];
                                ddlFunDia.SelectedValue = FECHA_AUX.Day.ToString();
                                ddlFunMes.SelectedValue = FECHA_AUX.Month.ToString();
                                ddlFunAño.SelectedValue = FECHA_AUX.Year.ToString();

                            }

                            if (String.IsNullOrEmpty(dr["telefono_fijo"].ToString())) { txtTelefono.Text = ""; } else { txtTelefono.Text = dr["telefono_fijo"].ToString(); }

                            if (String.IsNullOrEmpty(dr["pagina_web"].ToString())) { txtPaginaWeb.Text = ""; } else { txtPaginaWeb.Text = dr["pagina_web"].ToString(); }
                            if (String.IsNullOrEmpty(dr["expedido"].ToString())) { } else { ddlExpedido.SelectedValue = dr["expedido"].ToString(); }
                            if (String.IsNullOrEmpty(dr["SOCIEDAD"].ToString())) { } else { rblClaseSociedad.SelectedValue = dr["SOCIEDAD"].ToString(); }
                            if (String.IsNullOrEmpty(dr["ACTIVIDAD"].ToString())) { txtActividad.Text = ""; } else { txtActividad.Text = dr["ACTIVIDAD"].ToString(); }
                            if (String.IsNullOrEmpty(dr["RUBRO"].ToString())) { txtRubro.Text = ""; } else { txtRubro.Text = dr["RUBRO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["GRUPO_ECO"].ToString())) { txtGrupoEconomico.Text = ""; } else { txtGrupoEconomico.Text = dr["GRUPO_ECO"].ToString(); }

                        }

                    }

                }
                ////////////////////////////DATOS REPRESENTATE LEGALES//////////////////////
                DataTable dt1 = new DataTable();
                dt1 = Clases.clientes.PR_GET_REPRESENTANTE_LEGAL(lblCodCliente.Text);
                int count_rl = 0;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        if (count_rl == 0)
                        {
                            if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep1.Text = ""; } else { lblCodRep1.Text = dr1["COD_REP_LEGAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre1.Text = ""; } else { txtRepNombre1.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder1.Text = ""; } else { txtRepNroPoder1.Text = dr1["NRO_PODER"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail1.Text = ""; } else { txtRepEmail1.Text = dr1["EMAIL"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono1.Text = ""; } else { txtRepTelefono1.Text = dr1["TELEFONO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo1.Text = ""; } else { txtRepCargo1.Text = dr1["CARGO"].ToString(); }
                        }

                        if (count_rl == 1)
                        {
                            if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep2.Text = ""; } else { lblCodRep2.Text = dr1["COD_REP_LEGAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre2.Text = ""; } else { txtRepNombre2.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder2.Text = ""; } else { txtRepNroPoder2.Text = dr1["NRO_PODER"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail2.Text = ""; } else { txtRepEmail2.Text = dr1["EMAIL"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono2.Text = ""; } else { txtRepTelefono2.Text = dr1["TELEFONO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi2.Text = ""; } else { txtRepCi2.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo2.Text = ""; } else { txtRepCargo2.Text = dr1["CARGO"].ToString(); }
                        }

                        if (count_rl == 2)
                        {
                            if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep3.Text = ""; } else { lblCodRep3.Text = dr1["COD_REP_LEGAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre3.Text = ""; } else { txtRepNombre3.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder3.Text = ""; } else { txtRepNroPoder3.Text = dr1["NRO_PODER"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail3.Text = ""; } else { txtRepEmail3.Text = dr1["EMAIL"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono3.Text = ""; } else { txtRepTelefono3.Text = dr1["TELEFONO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi3.Text = ""; } else { txtRepCi3.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo3.Text = ""; } else { txtRepCargo3.Text = dr1["CARGO"].ToString(); }
                        }

                        if (count_rl == 3)
                        {
                            if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep4.Text = ""; } else { lblCodRep4.Text = dr1["COD_REP_LEGAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre4.Text = ""; } else { txtRepNombre4.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder4.Text = ""; } else { txtRepNroPoder4.Text = dr1["NRO_PODER"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail4.Text = ""; } else { txtRepEmail4.Text = dr1["EMAIL"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono4.Text = ""; } else { txtRepTelefono4.Text = dr1["TELEFONO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi4.Text = ""; } else { txtRepCi4.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo4.Text = ""; } else { txtRepCargo4.Text = dr1["CARGO"].ToString(); }
                        }
                        count_rl++;
                    }

                }
                ////////////////////////////DATOS DOMICILIO EMPRESA//////////////////////
                //rblTipoVivienda.DataBind();
                //rblDetalleVivienda.DataBind();
                DataTable dt2 = new DataTable();
                dt2 = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow dr2 in dt2.Rows)
                    {

                        if (String.IsNullOrEmpty(dr2["COD_DIRECCION"].ToString())) { lblCodDir.Text = ""; } else { lblCodDir.Text = dr2["COD_DIRECCION"].ToString(); }
                        //if (String.IsNullOrEmpty(dr2["TIPO_VIVIENDA"].ToString())) { } else { rblTipoVivienda.SelectedValue = dr2["TIPO_VIVIENDA"].ToString(); }
                        //if (String.IsNullOrEmpty(dr2["DETALLE"].ToString())) { } else { rblDetalleVivienda.SelectedValue = dr2["DETALLE"].ToString(); }
                        //if (String.IsNullOrEmpty(dr2["OTRA_DET"].ToString())) { txtDetViviendaOtros.Text = ""; } else { txtDetViviendaOtros.Text = dr2["OTRA_DET"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["BARRIO"].ToString())) { txtBarrio.Text = ""; } else { txtBarrio.Text = dr2["BARRIO"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["CONDOMINIO"].ToString())) { txtCondominio.Text = ""; } else { txtCondominio.Text = dr2["CONDOMINIO"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["URBANIZACION"].ToString())) { txtUrbanizacion.Text = ""; } else { txtUrbanizacion.Text = dr2["URBANIZACION"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["CIUDAD"].ToString())) { txtCiudad.Text = ""; } else { txtCiudad.Text = dr2["CIUDAD"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["AVENIDA"].ToString())) { txtAvenida.Text = ""; } else { txtAvenida.Text = dr2["AVENIDA"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["CALLE"].ToString())) { txtCalle.Text = ""; } else { txtCalle.Text = dr2["CALLE"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["PASIILO_CARRETERA"].ToString())) { txtPasilloCarretera.Text = ""; } else { txtPasilloCarretera.Text = dr2["PASIILO_CARRETERA"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["NRO"].ToString())) { txtNro.Text = ""; } else { txtNro.Text = dr2["NRO"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["EDIFICIO"].ToString())) { txtEdif.Text = ""; } else { txtEdif.Text = dr2["EDIFICIO"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["PISO"].ToString())) { txtPiso.Text = ""; } else { txtPiso.Text = dr2["PISO"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["NRO_DPTO"].ToString())) { txtNroDepto.Text = ""; } else { txtNroDepto.Text = dr2["NRO_DPTO"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["TELEFONO"].ToString())) { txtTelDom.Text = ""; } else { txtTelDom.Text = dr2["TELEFONO"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["REFERENCIA"].ToString())) { txtReferencia.Text = ""; } else { txtReferencia.Text = dr2["REFERENCIA"].ToString(); }
                        //if (String.IsNullOrEmpty(dr2["LATITUD"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr2["LATITUD"].ToString(); }
                        //if (String.IsNullOrEmpty(dr2["LONGITUD"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr2["LONGITUD"].ToString(); }
                    }

                }
                ////////////////////////////DATOS REFERENCIAS EMPRESA//////////////////////
                DataTable dt3 = new DataTable();
                dt3 = Clases.clientes.PR_GET_REFERENCIAS(lblCodCliente.Text);
                int count_ref = 0;
                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow dr3 in dt3.Rows)
                    {
                        if (count_ref == 0)
                        {
                            if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef1.Text = ""; } else { lblCodRef1.Text = dr3["COD_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef1.Text = "02"; } else { lblTipoRef1.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre1.Text = ""; } else { txtRefNombre1.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo1.Text = ""; } else { txtRefTrabajo1.Text = dr3["OCUPACION"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto1.Text = ""; } else { txtRefTelfContacto1.Text = dr3["TELEFONO"].ToString(); }
                        }
                        if (count_ref == 1)
                        {
                            if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef2.Text = ""; } else { lblCodRef2.Text = dr3["COD_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef2.Text = "02"; } else { lblTipoRef2.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre2.Text = ""; } else { txtRefNombre2.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo2.Text = ""; } else { txtRefTrabajo2.Text = dr3["OCUPACION"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto2.Text = ""; } else { txtRefTelfContacto2.Text = dr3["TELEFONO"].ToString(); }
                        }
                        if (count_ref == 2)
                        {
                            if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef3.Text = ""; } else { lblCodRef3.Text = dr3["COD_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef3.Text = "02"; } else { lblTipoRef3.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre3.Text = ""; } else { txtRefNombre3.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo3.Text = ""; } else { txtRefTrabajo3.Text = dr3["OCUPACION"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto3.Text = ""; } else { txtRefTelfContacto3.Text = dr3["TELEFONO"].ToString(); }
                        }
                        count_ref++;
                    }

                }
                ////////////////////////////DATOS BALANCE//////////////////////
                DataTable dt4 = new DataTable();
                dt4 = Clases.clientes.PR_GET_BALANCE(lblCodCliente.Text);

                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow dr4 in dt4.Rows)
                    {

                        if (String.IsNullOrEmpty(dr4["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr4["COD_BALANCE"].ToString(); }
                        if (String.IsNullOrEmpty(dr4["TOTAL_ACTIVOS_SUS"].ToString())) { txtTotActSus.Text = "02"; } else { txtTotActSus.Text = decimal.Parse(dr4["TOTAL_ACTIVOS_SUS"].ToString()).ToString("G").Replace(".", decSep).Replace(",", decSep); }
                        if (String.IsNullOrEmpty(dr4["TOTAL_PASIVOS"].ToString())) { txtTotPasSus.Text = ""; } else { txtTotPasSus.Text = dr4["TOTAL_PASIVOS"].ToString().Replace(".", decSep).Replace(",", decSep); }
                        if (String.IsNullOrEmpty(dr4["PATRIMONIO_SUS"].ToString())) { txtPatNetoSus.Text = ""; } else { txtPatNetoSus.Text = dr4["PATRIMONIO_SUS"].ToString().Replace(".", decSep).Replace(",", decSep); }

                    }

                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_juridica_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                Button bEdit = (Button)e.Item.FindControl("btnEditar");
                Button bDetalles = (Button)e.Item.FindControl("btnDetalles");
                bEdit.Visible = false;
                bDetalles.Visible = false;
                bNuevo.Visible = false;
                DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDITAR")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "DETALLES")
                            bDetalles.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                            bNuevo.Visible = true;
                    }

                }


            }
        }
        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string cod_solicitud = Session["COD_SOLICITUD"].ToString();
            string cod_cliente = Session["COD_CLIENTE"].ToString();
            Clases.solicitudes obj_d = new Clases.solicitudes("S", cod_solicitud, "", "", "", 0, 0, 0, 0, 0, "", "", "", lblUsuario.Text);
            string resultado = obj_d.ABM();
            string[] res_aux = resultado.Split('|');
            string cod_sol_detalle = res_aux[2];
            // string[] res_aux = resultado.Split('|');
            Session["COD_SOLICITUD_DETALLE"] = res_aux[2];
            Session["usuario"] = lblUsuario.Text;
            Session["COD_SOLICITUD"] = cod_solicitud;
            Session["COD_CLIENTE"] = cod_cliente;
            Session["TIPO_CLIENTE"] = "J";
            Response.Redirect("solicitudes_admin.aspx?inicialcounter=SI&RME=" + lblCodMenuRol.Text, false);
            // Response.End();
        }
    }
}