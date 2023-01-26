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
using System.Threading;
using Newtonsoft.Json;

namespace appAmascuotas
{
    public partial class natural_wiz : System.Web.UI.Page
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
                        string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

                        //inciar_mapa("-17.8".Replace(".", decSep).Replace(",", decSep), "-63.1667".Replace(".", decSep).Replace(",", decSep));
                        cargar_calendarios();
                        if (pasos == 0)
                        {
                            btnAnterior.Enabled = false;
                            btnSiguiente.Enabled = true;
                        }

                        //lblUsuario.Text = Session["usuario"].ToString();
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
                catch(Exception ex)
                {
                    string nombre_archivo = "error_natural_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                    string directorio2 = Server.MapPath("~/Logs");
                    StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                    writer5.WriteLine(ex.ToString());
                    writer5.Close();
                    lblAviso.Text = "Las variables de session caducaron."; }
                
                
            }
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
        public void cargar_calendarios()
        {
            ddlNacDia.Items.Clear();
            ddlNacDiaCon.Items.Clear();
            ddlNacMes.Items.Clear();
            ddlNacMesCon.Items.Clear();
            ddlNacAño.Items.Clear();
            ddlNacAñoCon.Items.Clear();


            int d = 1;
            for (d = 1; d <= 31; d++)
            {
                ListItem dia = new ListItem();
                dia.Text = d.ToString();
                dia.Value = d.ToString();

                ListItem dia2 = new ListItem();
                dia2.Text = d.ToString();
                dia2.Value = d.ToString();
                // ddlGarDia.Items.Add(dia);
                ddlNacDia.Items.Add(dia);
                ddlNacDiaCon.Items.Add(dia2);
            }
            int m = 1;
            for (m = 1; m <= 12; m++)
            {
                ListItem mes = new ListItem();
                ListItem mes2 = new ListItem();
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
                //////
                if (m == 1)
                {
                    mes2.Text = "ENERO";
                    mes2.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes2.Text = "FEBRERO";
                    mes2.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes2.Text = "MARZO";
                    mes2.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes2.Text = "ABRIL";
                    mes2.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes2.Text = "MAYO";
                    mes2.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes2.Text = "JUNIO";
                    mes2.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes2.Text = "JULIO";
                    mes2.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes2.Text = "AGOSTO";
                    mes2.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes2.Text = "SEPTIEMBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes2.Text = "OCTUBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes2.Text = "NOVIEMBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes2.Text = "DICIEMBRE";
                    mes2.Value = m.ToString();
                }

                //ddlGarMes.Items.Add(mes);
                ddlNacMesCon.Items.Add(mes);
                ddlNacMes.Items.Add(mes2);
            }
            int a = 1900;
            for (a = 1900; a <= DateTime.Now.Year; a++)
            {
                ListItem anio = new ListItem();
                anio.Text = a.ToString();
                anio.Value = a.ToString();
                ListItem anio2 = new ListItem();
                anio2.Text = a.ToString();
                anio2.Value = a.ToString();
                // ddlGarAño.Items.Add(anio);
                ddlNacAñoCon.Items.Add(anio);
                ddlNacAño.Items.Add(anio2);
            }
            ddlNacDia.Items.Insert(0, "DIA");
            ddlNacMes.Items.Insert(0, "MES");
            ddlNacAño.Items.Insert(0, "AÑO");

            ddlNacDiaCon.Items.Insert(0, "DIA");
            ddlNacMesCon.Items.Insert(0, "MES");
            ddlNacAñoCon.Items.Insert(0, "AÑO");

        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblPorcentaje.Text != "Cuota inicial menor a 20%")
                {
                    if (lblPatrimonioBs.Text != "Los egresos superan a los ingresos.")
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
                    string fecha = "01/01/3000";
                    string s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    if (s.ToUpper() == "DD/MM/YYYY")
                    { fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                    if (s.ToUpper() == "D/M/YYYY")
                    { fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                    if (s.ToUpper() == "MM/DD/YYYY")
                    { fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                    if (s.ToUpper() == "M/D/YYYY")
                    { fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                    DateTime thisDay = DateTime.Today;
                    DateTime birthDay = DateTime.Parse(fecha);
                    TimeSpan age = thisDay - birthDay;
                    double anios = age.TotalDays / 365;
                    if (anios >= 18)
                    {
                        lblClienteEdad.Text = "";
                        if (ddlEstCivil.SelectedValue != "CAS" & ddlEstCivil.SelectedValue != "SELECCIONAR")
                        {
                            string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                            "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                            "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                            "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active';";

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                            pasos = pasos + 1;
                        }
                        else
                        {
                            string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                          "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                          "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active';";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                        }

                        MultiView2.ActiveViewIndex = pasos;
                    }
                    else
                    {
                        string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                        "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                        lblClienteEdad.Text = "Edad menor a 18 años";
                    }


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
                }
                if (pasos == 6)
                {
                    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                    MultiView2.ActiveViewIndex = pasos;
                    btnSiguiente.Enabled = false;
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
                    //    btnSiguiente.Enabled = false;
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
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_natural_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
            
            




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
                if (ddlEstCivil.SelectedValue != "CAS" & ddlEstCivil.SelectedValue != "SELECCIONAR")
                {
                    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                    MultiView2.ActiveViewIndex = pasos;
                    btnAnterior.Enabled = true;
                    pasos = pasos - 1;
                }
                else
                {
                    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                }
                
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
                btnSiguiente.Enabled = true;
                //btnSiguiente.Enabled = false;
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
                decimal porcentaje = 0;
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
            catch (Exception ex)
            {
                string nombre_archivo = "error_natural_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }

        protected void ddlLugarNacimiento_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlLugarNacimiento.Items.Insert(0, miitem);
        }

        

        protected void ddlEstCivil_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlEstCivil.Items.Insert(0, miitem);

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
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                    "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                string customerName = Request.Form[txtCi.UniqueID];
                string customerId = Request.Form[hfCustomerId.UniqueID];
                if (customerId != "")
                {
                    ///////////////////////////DATOS GENERALES DEL CLIENTE//////////////////////////
                    lblCodCliente.Text = customerId;
                    DataTable dt = new DataTable();
                    dt = simular.Datos_cliente_simuldor(customerId);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["tipo_cliente"].ToString().Trim() == "02")
                            {
                                if (String.IsNullOrEmpty(dr["nombre"].ToString())) { txtPrimerNombre.Text = ""; } else { txtPrimerNombre.Text = dr["nombre"].ToString(); }

                                if (String.IsNullOrEmpty(dr["segundo_nombre"].ToString())) { txtSegundoNombre.Text = ""; } else { txtSegundoNombre.Text = dr["segundo_nombre"].ToString(); }

                                if (String.IsNullOrEmpty(dr["tercer_nombre"].ToString())) { txtTercerNombre.Text = ""; } else { txtTercerNombre.Text = dr["tercer_nombre"].ToString(); }


                                if (String.IsNullOrEmpty(dr["apellido_paterno"].ToString())) { txtApellidoPaterno.Text = ""; } else { txtApellidoPaterno.Text = dr["apellido_paterno"].ToString(); }

                                if (String.IsNullOrEmpty(dr["apellido_materno"].ToString())) { txtApellidoMaterno.Text = ""; } else { txtApellidoMaterno.Text = dr["apellido_materno"].ToString(); }

                                if (String.IsNullOrEmpty(dr["email"].ToString())) { txtEmail.Text = ""; } else { txtEmail.Text = dr["email"].ToString(); }

                                if (String.IsNullOrEmpty(dr["numero_documento"].ToString())) { txtCi.Text = ""; } else { txtCi.Text = dr["numero_documento"].ToString(); }

                                if (String.IsNullOrEmpty(dr["telefono_celular"].ToString())) { txtCelular.Text = ""; } else { txtCelular.Text = dr["telefono_celular"].ToString(); }
                                if (String.IsNullOrEmpty(dr["expedido"].ToString())) { } else { ddlExpedido.SelectedValue = dr["expedido"].ToString(); }
                                if (String.IsNullOrEmpty(dr["estado_civil"].ToString())) { } else { ddlEstCivil.SelectedValue = dr["ESTADO_CIVIL"].ToString(); }
                                if (String.IsNullOrEmpty(dr["ext"].ToString())) { txtExt.Text = ""; } else { txtExt.Text = dr["ext"].ToString(); }
                                if (String.IsNullOrEmpty(dr["sexo"].ToString())) { } else { rblSexo.SelectedValue = dr["sexo"].ToString(); }
                                if (String.IsNullOrEmpty(dr["lug_nac"].ToString())) { } else { ddlLugarNacimiento.SelectedValue = dr["lug_nac"].ToString(); }
                                if (String.IsNullOrEmpty(dr["FECHA_FUNNAC"].ToString())) { }
                                else
                                {
                                    DateTime FECHA_AUX = (DateTime)dr["FECHA_FUNNAC"];
                                    ddlNacDia.SelectedValue = FECHA_AUX.Day.ToString();
                                    ddlNacMes.SelectedValue = FECHA_AUX.Month.ToString();
                                    ddlNacAño.SelectedValue = FECHA_AUX.Year.ToString();

                                }
                                if (String.IsNullOrEmpty(dr["nivel_educacion"].ToString())) { } else { ddlNivelEdu.SelectedValue = dr["nivel_educacion"].ToString(); }
                                if (String.IsNullOrEmpty(dr["nacionalidad"].ToString())) { txtNacionalidad.Text = ""; } else { txtNacionalidad.Text = dr["nacionalidad"].ToString(); }
                                if (String.IsNullOrEmpty(dr["edad"].ToString())) { txtEdad.Text = ""; } else { txtEdad.Text = dr["edad"].ToString(); }
                                if (String.IsNullOrEmpty(dr["profesion"].ToString())) { txtProfesion.Text = ""; } else { txtProfesion.Text = dr["profesion"].ToString(); }
                                if (String.IsNullOrEmpty(dr["nro_dependientes"].ToString())) { txtNroDependientes.Text = ""; } else { txtNroDependientes.Text = dr["nro_dependientes"].ToString(); }


                            }

                        }

                    }
                    ///////////////////////////DATOS GENERALES DEL CONYUGUE//////////////////////////
                    DataTable dt1 = new DataTable();
                    ddlExpedidoCon.DataBind();
                    ddlLugarNacimientoCon.DataBind();
                    rblSexoCon.DataBind();
                    ddlNivelEduCon.DataBind();
                    ddlTipoAntiguedadCon.DataBind();
                    dt1 = Clases.clientes.PR_GET_CONYUGUE(customerId);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            if (dr1["tipo_cliente"].ToString().Trim() == "02")
                            {
                                if (String.IsNullOrEmpty(dr1["conyugue"].ToString())) { lblCodConyugue.Text = ""; } else { lblCodConyugue.Text = dr1["conyugue"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["nombre"].ToString())) { txtPrimerNombreCon.Text = ""; } else { txtPrimerNombreCon.Text = dr1["nombre"].ToString(); }

                                if (String.IsNullOrEmpty(dr1["segundo_nombre"].ToString())) { txtSegundoNombreCon.Text = ""; } else { txtSegundoNombreCon.Text = dr1["segundo_nombre"].ToString(); }

                                if (String.IsNullOrEmpty(dr1["tercer_nombre"].ToString())) { txtTercerNombreCon.Text = ""; } else { txtTercerNombreCon.Text = dr1["tercer_nombre"].ToString(); }


                                if (String.IsNullOrEmpty(dr1["apellido_paterno"].ToString())) { txtApellidoPaternoCon.Text = ""; } else { txtApellidoPaternoCon.Text = dr1["apellido_paterno"].ToString(); }

                                if (String.IsNullOrEmpty(dr1["apellido_materno"].ToString())) { txtApellidoMaternoCon.Text = ""; } else { txtApellidoMaternoCon.Text = dr1["apellido_materno"].ToString(); }

                                if (String.IsNullOrEmpty(dr1["email"].ToString())) { txtEmailCon.Text = ""; } else { txtEmailCon.Text = dr1["email"].ToString(); }

                                if (String.IsNullOrEmpty(dr1["numero_documento"].ToString())) { txtCiCon.Text = ""; } else { txtCiCon.Text = dr1["numero_documento"].ToString(); }

                                if (String.IsNullOrEmpty(dr1["telefono_celular"].ToString())) { txtCelularCon.Text = ""; } else { txtCelularCon.Text = dr1["telefono_celular"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["expedido"].ToString())) { } else { ddlExpedidoCon.SelectedValue = dr1["expedido"].ToString(); }

                                if (String.IsNullOrEmpty(dr1["ext"].ToString())) { txtExtCon.Text = ""; } else { txtExtCon.Text = dr1["ext"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["sexo"].ToString())) { } else { rblSexoCon.SelectedValue = dr1["sexo"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["lug_nac"].ToString())) { } else { ddlLugarNacimientoCon.SelectedValue = dr1["lug_nac"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["FECHA_FUNNAC"].ToString())) { }
                                else
                                {
                                    DateTime FECHA_AUX = (DateTime)dr1["FECHA_FUNNAC"];
                                    ddlNacDiaCon.SelectedValue = FECHA_AUX.Day.ToString();
                                    ddlNacMesCon.SelectedValue = FECHA_AUX.Month.ToString();
                                    ddlNacAñoCon.SelectedValue = FECHA_AUX.Year.ToString();

                                }
                                if (String.IsNullOrEmpty(dr1["nivel_educacion"].ToString())) { } else { ddlNivelEduCon.SelectedValue = dr1["nivel_educacion"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["nacionalidad"].ToString())) { txtNacionalidadCon.Text = ""; } else { txtNacionalidadCon.Text = dr1["nacionalidad"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["edad"].ToString())) { txtEdadCon.Text = ""; } else { txtEdadCon.Text = dr1["edad"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["profesion"].ToString())) { txtProfesionCon.Text = ""; } else { txtProfesionCon.Text = dr1["profesion"].ToString(); }
                                //if (String.IsNullOrEmpty(dr1["nro_dependientes"].ToString())) { txtNroDependientesCon.Text = ""; } else { txtNroDependientesCon.Text = dr1["nro_dependientes"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["cargo"].ToString())) { txtCargoCon.Text = ""; } else { txtCargoCon.Text = dr1["cargo"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["antiguedad"].ToString())) { txtAntiguedadCon.Text = ""; } else { txtAntiguedadCon.Text = dr1["antiguedad"].ToString().Replace(',', '.'); }
                                if (String.IsNullOrEmpty(dr1["tipo_antiguedad"].ToString())) { ddlTipoAntiguedadCon.DataBind(); } else { ddlTipoAntiguedadCon.SelectedValue = dr1["tipo_antiguedad"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["empresa_laboral"].ToString())) { txtEmpresaCon.Text = ""; } else { txtEmpresaCon.Text = dr1["empresa_laboral"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["direccion_empresa"].ToString())) { txtDireccionEmpresaCon.Text = ""; } else { txtDireccionEmpresaCon.Text = dr1["direccion_empresa"].ToString(); }
                                if (String.IsNullOrEmpty(dr1["telefono_fijo"].ToString())) { txtTelfOficinaCon.Text = ""; } else { txtTelfOficinaCon.Text = dr1["telefono_fijo"].ToString(); }

                            }

                        }

                    }
                    ////////////////////////////DATOS DOMICILIO//////////////////////
                    rblTipoVivienda.DataBind();
                    rblDetalleVivienda.DataBind();
                    DataTable dt2 = new DataTable();
                    dt2 = Clases.clientes.PR_GET_DIRECCION(customerId);
                    if (dt2.Rows.Count > 0)
                    {
                        foreach (DataRow dr2 in dt2.Rows)
                        {

                            if (String.IsNullOrEmpty(dr2["COD_DIRECCION"].ToString())) { lblCodDireccion.Text = ""; } else { lblCodDireccion.Text = dr2["COD_DIRECCION"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["TIPO_VIVIENDA"].ToString())) { } else { rblTipoVivienda.SelectedValue = dr2["TIPO_VIVIENDA"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["DETALLE"].ToString())) { } else { rblDetalleVivienda.SelectedValue = dr2["DETALLE"].ToString(); }
                            if (String.IsNullOrEmpty(dr2["OTRA_DET"].ToString())) { txtDetViviendaOtros.Text = ""; } else { txtDetViviendaOtros.Text = dr2["OTRA_DET"].ToString(); }
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
                    ////////////////////////////DATOS LABORALES//////////////////////
                    DataTable dt3 = new DataTable();
                    dt3 = Clases.clientes.PR_GET_DATOS_LABORALES(customerId);
                    rblSituacionLaboral.DataBind();
                    rblRelLaboral.DataBind();
                    ddlTipoAcntiguedadCli.DataBind();
                    if (dt3.Rows.Count > 0)
                    {
                        foreach (DataRow dr3 in dt3.Rows)
                        {

                            if (String.IsNullOrEmpty(dr3["COD_DATO_LABORAL"].ToString())) { lblCodDatoLaboral.Text = ""; } else { lblCodDatoLaboral.Text = dr3["COD_DATO_LABORAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["SITUACION_LABORAL"].ToString())) { } else { rblSituacionLaboral.SelectedValue = dr3["SITUACION_LABORAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["RELACION_LABORAL"].ToString())) { } else { rblRelLaboral.SelectedValue = dr3["RELACION_LABORAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["ANTIGUEDAD"].ToString())) { txtAntiguedad.Text = ""; } else { txtAntiguedad.Text = dr3["ANTIGUEDAD"].ToString().Replace(',', '.'); }
                            if (String.IsNullOrEmpty(dr3["tipo_antiguedad"].ToString())) { ddlTipoAcntiguedadCli.DataBind(); } else { ddlTipoAcntiguedadCli.SelectedValue = dr3["tipo_antiguedad"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["CARGO"].ToString())) { txtCargoOcupa.Text = ""; } else { txtCargoOcupa.Text = dr3["CARGO"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["EMPRESA"].ToString())) { txtEmpresaTrabaja.Text = ""; } else { txtEmpresaTrabaja.Text = dr3["EMPRESA"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["DIRECCION"].ToString())) { txtDirEmpresa.Text = ""; } else { txtDirEmpresa.Text = dr3["DIRECCION"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtTelf.Text = ""; } else { txtTelf.Text = dr3["TELEFONO"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["EMAIL"].ToString())) { txtEmail2.Text = ""; } else { txtEmail2.Text = dr3["EMAIL"].ToString(); }
                            if (String.IsNullOrEmpty(dr3["INGRESO_BS"].ToString())) { txtIngresoPromedio.Text = ""; } else { txtIngresoPromedio.Text = dr3["INGRESO_BS"].ToString().Replace(',', '.'); }
                        }
                    }
                    ////////////////////////////DATOS REFERENCIAS EMPRESA//////////////////////
                    DataTable dt4 = new DataTable();
                    dt4 = Clases.clientes.PR_GET_REFERENCIAS(customerId);
                    int count_ref = 0;
                    if (dt4.Rows.Count > 0)
                    {
                        foreach (DataRow dr4 in dt4.Rows)
                        {
                            if (count_ref == 0)
                            {
                                if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef1.Text = ""; } else { lblCodRef1.Text = dr4["COD_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre1.Text = ""; } else { txtRefNombre1.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo1.Text = ""; } else { txtRefTrabajo1.Text = dr4["OCUPACION"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto1.Text = ""; } else { txtRefTelfContacto1.Text = dr4["TELEFONO"].ToString(); }
                            }
                            if (count_ref == 1)
                            {
                                if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef2.Text = ""; } else { lblCodRef2.Text = dr4["COD_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre2.Text = ""; } else { txtRefNombre2.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo2.Text = ""; } else { txtRefTrabajo2.Text = dr4["OCUPACION"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto2.Text = ""; } else { txtRefTelfContacto2.Text = dr4["TELEFONO"].ToString(); }
                            }
                            if (count_ref == 2)
                            {
                                if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef3.Text = ""; } else { lblCodRef3.Text = dr4["COD_REFERENCIA"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre3.Text = ""; } else { txtRefNombre3.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo3.Text = ""; } else { txtRefTrabajo3.Text = dr4["OCUPACION"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto3.Text = ""; } else { txtRefTelfContacto3.Text = dr4["TELEFONO"].ToString(); }
                            }
                            count_ref++;
                        }

                    }
                    ////////////////////////////DATOS BALANCE//////////////////////
                    DataTable dt5 = new DataTable();
                    dt5 = Clases.clientes.PR_GET_BALANCE(customerId);

                    if (dt5.Rows.Count > 0)
                    {
                        foreach (DataRow dr5 in dt5.Rows)
                        {

                            if (String.IsNullOrEmpty(dr5["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr5["COD_BALANCE"].ToString(); }
                            if (String.IsNullOrEmpty(dr5["TOTAL_ACTIVOS_SUS"].ToString())) { txtTotActSus.Text = "02"; } else { txtTotActSus.Text = decimal.Parse(dr5["TOTAL_ACTIVOS_SUS"].ToString()).ToString().Replace(',', '.'); }
                            if (String.IsNullOrEmpty(dr5["TOTAL_PASIVOS"].ToString())) { txtTotPasSus.Text = ""; } else { txtTotPasSus.Text = dr5["TOTAL_PASIVOS"].ToString().Replace(',', '.'); }
                            if (String.IsNullOrEmpty(dr5["PATRIMONIO_SUS"].ToString())) { txtPatNetoSus.Text = ""; } else { txtPatNetoSus.Text = dr5["PATRIMONIO_SUS"].ToString().Replace(',', '.'); }

                        }

                    }
                    ////////////////////////////DATOS INGRESOS//////////////////////
                    DataTable dt6 = new DataTable();
                    dt6 = Clases.clientes.PR_GET_INGRESOS(customerId);

                    if (dt6.Rows.Count > 0)
                    {
                        foreach (DataRow dr6 in dt6.Rows)
                        {

                            //if (String.IsNullOrEmpty(dr6["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr6["COD_BALANCE"].ToString(); }
                            if (String.IsNullOrEmpty(dr6["INGRESOS"].ToString())) { }
                            else
                            {
                                if (dr6["INGRESOS"].ToString() == "Sueldos")
                                {
                                    txtFlujoSueldo.Text = dr6["BS"].ToString().Replace(',', '.');
                                }
                                if (dr6["INGRESOS"].ToString() == "Honorarios")
                                {
                                    txtFlujoHonorarios.Text = dr6["BS"].ToString().Replace(',', '.');
                                }
                                if (dr6["INGRESOS"].ToString() == "Rentas")
                                {
                                    txtFlujoRentas.Text = dr6["BS"].ToString().Replace(',', '.');
                                }
                                if (dr6["INGRESOS"].ToString() == "Utilidades")
                                {
                                    txtFlujoUtil.Text = dr6["BS"].ToString().Replace(',', '.');
                                }
                                if (dr6["INGRESOS"].ToString() == "Otros")
                                {
                                    txtFlujoOtros.Text = dr6["BS"].ToString().Replace(',', '.');
                                }

                            }


                        }

                    }
                    ////////////////////////////DATOS EGRESOS//////////////////////
                    DataTable dt7 = new DataTable();
                    dt7 = Clases.clientes.PR_GET_EGRESOS(customerId);

                    if (dt7.Rows.Count > 0)
                    {
                        foreach (DataRow dr7 in dt7.Rows)
                        {

                            //if (String.IsNullOrEmpty(dr7["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr7["COD_BALANCE"].ToString(); }
                            if (String.IsNullOrEmpty(dr7["EGRESOS"].ToString())) { }
                            else
                            {
                                if (dr7["EGRESOS"].ToString() == "Alquielres")
                                {
                                    txtFluEgAlq.Text = dr7["BS"].ToString().Replace(',', '.');
                                }
                                if (dr7["EGRESOS"].ToString() == "Alimentacion y servicios")
                                {
                                    txtFluEgAlimentos.Text = dr7["BS"].ToString().Replace(',', '.');
                                }
                                if (dr7["EGRESOS"].ToString() == "Educacion")
                                {
                                    txtFluEgEducacion.Text = dr7["BS"].ToString().Replace(',', '.');
                                }
                                if (dr7["EGRESOS"].ToString() == "Pago de creditos")
                                {
                                    txtFluEgCred.Text = dr7["BS"].ToString().Replace(',', '.');
                                }
                                if (dr7["EGRESOS"].ToString() == "Otros")
                                {
                                    txtFluEgOtros.Text = dr7["BS"].ToString().Replace(',', '.');
                                }

                            }


                        }

                    }

                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_natural_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        

        protected void ddlLugarNacimientoCon_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlLugarNacimientoCon.Items.Insert(0, miitem);
        }

        protected void ddlNivelEduCon_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlNivelEduCon.Items.Insert(0, miitem);
        }

        protected void lbtnTraerDatosCon_Click(object sender, EventArgs e)
        {
            try
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                   "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                   "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                string customerName = Request.Form[txtCiCon.UniqueID];
                string customerId = Request.Form[hfCustomerId2.UniqueID];
                lblCodConyugue.Text = "";
                if (customerId != "")
                {
                    ///////////////////////////DATOS GENERALES DEL CLIENTE//////////////////////////
                    lblCodConyugue.Text = customerId;
                    DataTable dt = new DataTable();
                    dt = simular.Datos_cliente_simuldor(customerId);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["tipo_cliente"].ToString().Trim() == "02")
                            {
                                if (String.IsNullOrEmpty(dr["nombre"].ToString())) { txtPrimerNombreCon.Text = ""; } else { txtPrimerNombreCon.Text = dr["nombre"].ToString(); }

                                if (String.IsNullOrEmpty(dr["segundo_nombre"].ToString())) { txtSegundoNombreCon.Text = ""; } else { txtSegundoNombreCon.Text = dr["segundo_nombre"].ToString(); }

                                if (String.IsNullOrEmpty(dr["tercer_nombre"].ToString())) { txtTercerNombreCon.Text = ""; } else { txtTercerNombreCon.Text = dr["tercer_nombre"].ToString(); }


                                if (String.IsNullOrEmpty(dr["apellido_paterno"].ToString())) { txtApellidoPaternoCon.Text = ""; } else { txtApellidoPaternoCon.Text = dr["apellido_paterno"].ToString(); }

                                if (String.IsNullOrEmpty(dr["apellido_materno"].ToString())) { txtApellidoMaternoCon.Text = ""; } else { txtApellidoMaternoCon.Text = dr["apellido_materno"].ToString(); }

                                if (String.IsNullOrEmpty(dr["email"].ToString())) { txtEmailCon.Text = ""; } else { txtEmailCon.Text = dr["email"].ToString(); }

                                if (String.IsNullOrEmpty(dr["numero_documento"].ToString())) { txtCiCon.Text = ""; } else { txtCiCon.Text = dr["numero_documento"].ToString(); }

                                if (String.IsNullOrEmpty(dr["telefono_celular"].ToString())) { txtCelularCon.Text = ""; } else { txtCelularCon.Text = dr["telefono_celular"].ToString(); }
                                if (String.IsNullOrEmpty(dr["expedido"].ToString())) { } else { ddlExpedidoCon.SelectedValue = dr["expedido"].ToString(); }

                                if (String.IsNullOrEmpty(dr["ext"].ToString())) { txtExtCon.Text = ""; } else { txtExtCon.Text = dr["ext"].ToString(); }
                                if (String.IsNullOrEmpty(dr["sexo"].ToString())) { } else { rblSexoCon.SelectedValue = dr["sexo"].ToString(); }
                                if (String.IsNullOrEmpty(dr["lug_nac"].ToString())) { } else { ddlLugarNacimientoCon.SelectedValue = dr["lug_nac"].ToString(); }
                                if (String.IsNullOrEmpty(dr["FECHA_FUNNAC"].ToString())) { }
                                else
                                {
                                    DateTime FECHA_AUX = (DateTime)dr["FECHA_FUNNAC"];
                                    ddlNacDiaCon.SelectedValue = FECHA_AUX.Day.ToString();
                                    ddlNacMesCon.SelectedValue = FECHA_AUX.Month.ToString();
                                    ddlNacAñoCon.SelectedValue = FECHA_AUX.Year.ToString();

                                }
                                if (String.IsNullOrEmpty(dr["nivel_educacion"].ToString())) { } else { ddlNivelEduCon.SelectedValue = dr["nivel_educacion"].ToString(); }
                                if (String.IsNullOrEmpty(dr["nacionalidad"].ToString())) { txtNacionalidadCon.Text = ""; } else { txtNacionalidadCon.Text = dr["nacionalidad"].ToString(); }
                                if (String.IsNullOrEmpty(dr["edad"].ToString())) { txtEdadCon.Text = ""; } else { txtEdadCon.Text = dr["edad"].ToString(); }
                                if (String.IsNullOrEmpty(dr["profesion"].ToString())) { txtProfesionCon.Text = ""; } else { txtProfesionCon.Text = dr["profesion"].ToString(); }
                                //if (String.IsNullOrEmpty(dr["nro_dependientes"].ToString())) { txtNroDependientesCon.Text = ""; } else { txtNroDependientesCon.Text = dr["nro_dependientes"].ToString(); }

                            }

                        }

                    }


                }
            }
            catch
            {
                lblAviso.Text = "Hubo un problema por favor consute a su administrador.";
            }
            
        }

        protected void ddlExpedidoCon_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlExpedidoCon.Items.Insert(0, miitem);
        }

        protected void ddlNivelEdu_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlNivelEdu.Items.Insert(0, miitem);
        }

        protected void rblDetalleVivienda_DataBound(object sender, EventArgs e)
        {

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
            txtFluEgAlq.Text = "";
            txtFluEgAlimentos.Text = "";
            txtFluEgCred.Text = "";
            txtFluEgEducacion.Text = "";
            txtFluEgOtros.Text = "";
            txtFluEgTotal.Text = "";

            txtFlujoHonorarios.Text = "";
            txtFlujoOtros.Text = "";
            txtFlujoRentas.Text = "";
            txtFlujoSueldo.Text = "";
            txtFlujoTotal.Text = "";
            txtFlujoUtil.Text = "";

            txtTotPasSus.Text = "";
            txtTotPasSus.Text = "";

            ddlEstCivil.DataBind();
            ddlExpedido.DataBind();
            ddlExpedidoCon.DataBind();
            ddlLugarNacimiento.DataBind();
            ddlLugarNacimientoCon.DataBind();
            cargar_calendarios();
            ddlNivelEdu.DataBind();
            ddlNivelEduCon.DataBind();
            ddlRuta1.DataBind();
            ddlRuta2.DataBind();
            
            rblDetalleVivienda.DataBind();
            rblRelLaboral.DataBind();
            rblSexo.DataBind();
            rblSexoCon.DataBind();
            rblSituacionLaboral.DataBind();
            rblTipoRuta.DataBind();
            rblTipoVivienda.DataBind();
            rblDetalleVivienda.DataBind();

            


        }


    
    protected void txtTotPasSus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active';";
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
            catch 
            {
                lblAviso.Text = "Hubo un problema por favor consute a su administrador.";
            }
            
        }
        //private Bitmap CaptureControl(Control control)
        //{
            
        //    Size s = control.Size;
        //    Bitmap memoryImage;
        //    using (Graphics myGraphics = this.cre CreateGraphics())
        //    {
        //        memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
        //    }
        //    using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
        //    {
        //        Point screenPoint = PointToScreen(control.Location);
        //        memoryGraphics.CopyFromScreen(screenPoint.X, screenPoint.Y, 0, 0, s);
        //    }
        //    return memoryImage;
        //}

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active'; " +
                      "document.getElementById('p8').className = 'col-md-3 col-sm-4 col-6 active';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                //byte[] data;
                //WebClient webClient = new WebClient();
                //if (hfImageUrl.Value == null || hfImageUrl.Value == "")
                //{ data = null; }
                //else
                //{ data = webClient.DownloadData(hfImageUrl.Value); }

                string egresos = "";
                string ingresos = "";
                if (txtFluEgAlq.Text == "") { txtFluEgAlq.Text = "0"; }
                if (txtFluEgAlimentos.Text == "") { txtFluEgAlimentos.Text = "0"; }
                if (txtFluEgEducacion.Text == "") { txtFluEgEducacion.Text = "0"; }
                if (txtFluEgCred.Text == "") { txtFluEgCred.Text = "0"; }
                if (txtFluEgOtros.Text == "") { txtFluEgOtros.Text = "0"; }

                egresos = "Alquielres," + txtFluEgAlq.Text + "|Alimentacion y servicios," + txtFluEgAlimentos.Text + "|Educacion," + txtFluEgEducacion.Text + "|Pago de creditos," + txtFluEgCred.Text + "|Otros," + txtFluEgOtros.Text;

                if (txtFlujoSueldo.Text == "") { txtFlujoSueldo.Text = "0"; }
                if (txtFlujoHonorarios.Text == "") { txtFlujoHonorarios.Text = "0"; }
                if (txtFlujoRentas.Text == "") { txtFlujoRentas.Text = "0"; }
                if (txtFlujoUtil.Text == "") { txtFlujoUtil.Text = "0"; }
                if (txtFlujoOtros.Text == "") { txtFlujoOtros.Text = "0"; }
                string s;
                string fecha = "01/01/3000";
                s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (s.ToUpper() == "DD/MM/YYYY")
                { fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                if (s.ToUpper() == "D/M/YYYY")
                { fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                if (s.ToUpper() == "MM/DD/YYYY")
                { fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                if (s.ToUpper() == "M/D/YYYY")
                { fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                ingresos = "Sueldos," + txtFlujoSueldo.Text + "|Honorarios," + txtFlujoHonorarios.Text + "|Rentas," + txtFlujoRentas.Text + "|Utilidades," + txtFlujoUtil.Text + "|Otros," + txtFlujoOtros.Text;
                //DateTime fecha_nac = DateTime.Parse(ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue);
                DateTime fecha_nac = DateTime.Parse(fecha);
                DateTime fecha_nac_con = DateTime.Parse("01/01/3000");
                if (ddlNacDiaCon.SelectedItem.Text != "DIA")
                {
                    if (ddlNacMesCon.SelectedItem.Text != "MES")
                        if (ddlNacAñoCon.SelectedItem.Text != "AÑO")
                        {

                            if (s.ToUpper() == "DD/MM/YYYY")
                            { fecha = ddlNacDiaCon.SelectedValue + "/" + ddlNacMesCon.SelectedValue + "/" + ddlNacAñoCon.SelectedValue; }
                            if (s.ToUpper() == "D/M/YYYY")
                            { fecha = ddlNacDiaCon.SelectedValue + "/" + ddlNacMesCon.SelectedValue + "/" + ddlNacAñoCon.SelectedValue; }
                            if (s.ToUpper() == "MM/DD/YYYY")
                            { fecha = ddlNacMesCon.SelectedValue + "/" + ddlNacDiaCon.SelectedValue + "/" + ddlNacAñoCon.SelectedValue; }
                            if (s.ToUpper() == "M/D/YYYY")
                            { fecha = ddlNacMesCon.SelectedValue + "/" + ddlNacDiaCon.SelectedValue + "/" + ddlNacAñoCon.SelectedValue; }
                            fecha_nac_con = DateTime.Parse(fecha);
                        }
                }
                if (txtEdad.Text == "")
                    txtEdad.Text = "0";
                if (txtEdadCon.Text == "")
                    txtEdadCon.Text = "0";
                if (txtNroDependientes.Text == "")
                    txtNroDependientes.Text = "0";
                //if (txtNroDependientesCon.Text == "")
                //    txtNroDependientesCon.Text = "0";
                if (txtAntiguedad.Text == "")
                    txtAntiguedad.Text = "0";
                if (txtAntiguedadCon.Text == "")
                    txtAntiguedadCon.Text = "0";
                string relLboral = "";
                decimal antiguedad1 = decimal.Parse(txtAntiguedad.Text);
                if (rblRelLaboral.SelectedIndex == -1)
                {
                    relLboral = txtOtros.Text;
                }
                else
                {
                    relLboral = rblRelLaboral.SelectedValue;
                }


                string xml_aux= @"<CONSULTAS>
                            <CONSULTA>
                            <Cod_documento>"+txtCi.Text+"</Cod_documento>" +
                            "<Complemento>" + txtExt.Text + "</Complemento>" +
                            "<Tipo_documento>CI</Tipo_documento>" +
                            "<Extension>" + ddlExpedido.SelectedValue + "</Extension>" +
                            "<Nombre1>" + txtPrimerNombre.Text + "</Nombre1>" +
                            "<Nombre2>" + txtSegundoNombre.Text + "</Nombre2>" +
                            "<Ap_paterno>" + txtApellidoPaterno.Text + "</Ap_paterno>" +
                            "<Ap_materno>" + txtApellidoMaterno.Text + "</Ap_materno>" +
                             "<Ap_casada>" + txtApellidoCasada.Text + "</Ap_casada>" +
                            "<Razon_social/>" + 
                            "<Nombre_comercial/>" +
                            "</CONSULTA>" +
                            "</CONSULTAS>";


                Clases.Datos_motor_decision dtMotor = new Clases.Datos_motor_decision
                {
                    clienteACTIVIDAD = "",
                    clienteAlturaMoraActual = 0,
                    clienteBarrio = "",
                    clienteCalificacion_ASFI = "",
                    clienteCategoriaBHV = 0,
                    clienteDeclaracionesPatrimoniales = "",
                    clienteDepartamento = "",
                    clienteDeudaEnMora = 0,
                    clienteDeudaEntidadSolicitante = 0,
                    clienteDireccion = "",
                    clienteDocumentoIdentidadcliente = "",
                    clienteDocumentoIdentidadclienteComp = "",
                    clienteDocumentoIdentidadclienteExt = "",
                    clienteESTADO_CIVIL = "",
                    clienteFECHA_NACIMIENTO = fecha_nac.Day.ToString() + "/" + fecha_nac.Month.ToString()+"/"+ fecha_nac.Year.ToString(),
                    clienteFECHA_VENCIMIENTO = fecha_nac.Day.ToString() + "/" + fecha_nac.Month.ToString() + "/" + (fecha_nac.Year+6).ToString(),
                    clienteFecRelDep = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(),
                    clienteFechaAutonomo = "",
                    clienteFechaUltimaMora = "31/08/2020",
                    clienteFlagclienteRecurrente = 0,
                    clienteGENERO = "F",
                    clienteGastosDeclarados = 0,
                    clienteID_Departamento = 0,
                    clienteID_Localidad = 0,
                    clienteID_PAIS = 0,
                    clienteIngresosDeclarados = 0,
                    clienteListasNegras = "",
                    clienteLocalidad = "",
                    clienteManzana = "",
                    clienteMoraMaxU12M = 0,
                    clienteNacionalidadcliente = "",
                    clienteNivelEducativo = "",
                    clienteNombreCompleto = "",
                    clienteNumeroDocumento = 0,
                    clienteNumeroIDcliente = 0,
                    clienteNumeroIdentificacionTributaria = 0,
                    clienteNumeroProductosVigentes = 0,
                    clienteNumero_Calle = "",
                    clienteOperacionesActivas = 0,
                    clienteOperacionesCanceladas = 0,
                    clienteOtrosIngresos = 0,
                    clientePersonasACarg = 0,
                    clienteRAZON_SOCIAL = "",
                    clienteRUBRO = "",
                    clienteRelDep = 0,
                    clienteScoreBHV = 0,
                    clienteSectorEconomico = "",
                    clienteSumatoriaCuotaVigente = 0,
                    clienteSumatoriaDeudaCastigada = 0,
                    clienteSumatoriaDeudaContingente = 0,
                    clienteSumatoriaDeudaVencida = 0,
                    clienteSumatoriaDeudaVigente = 0,
                    clienteTIPO_SERVICIO = "",
                    clienteTIPO_SOCIEDAD = "",
                    clienteTipoDocumentoIdentidad = "",
                    clienteTipoEmpleo = "",
                    clienteTipodePersona = "",
                    clienteTrabajos = "",
                    clienteUV = "",
                    clienteZona = "",
                    clienteclienteDesde = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString()
                };

                string json = JsonConvert.SerializeObject(dtMotor);
                Session["json_ws"] =json;
                Session["xml_ws"] = xml_aux;

                Clases.clientes obj = new Clases.clientes("I", "02", lblCodCliente.Text,
                    txtPrimerNombre.Text, txtSegundoNombre.Text, txtTercerNombre.Text,
                    txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtApellidoCasada.Text,
                    rblSexo.SelectedValue, ddlLugarNacimiento.SelectedValue, txtNacionalidad.Text,
                    txtNacionalidad.Text, int.Parse(txtEdad.Text), ddlNivelEdu.SelectedValue,
                    ddlEstCivil.SelectedValue, fecha_nac, txtCi.Text,
                    txtExt.Text, ddlExpedido.SelectedValue, txtProfesion.Text,
                    int.Parse(txtNroDependientes.Text), txtCelular.Text, txtEmail.Text,
                    "", "", "",
                    "", "", "",
                    "", lblCodConyugue.Text, txtPrimerNombreCon.Text,
                    txtSegundoNombreCon.Text, txtTercerNombreCon.Text, txtApellidoPaternoCon.Text,
                    txtApellidoMaternoCon.Text, txtApellidoCasadaCon.Text, rblSexoCon.SelectedValue,
                    ddlLugarNacimientoCon.SelectedValue, txtNacionalidadCon.Text, txtNacionalidadCon.Text,
                    int.Parse(txtEdadCon.Text), ddlNivelEduCon.SelectedValue, "CAS",
                    fecha_nac_con, txtCiCon.Text, txtExtCon.Text,
                    ddlExpedidoCon.SelectedValue, txtCelularCon.Text, txtEmpresaCon.Text,
                    txtProfesionCon.Text, txtCargoCon.Text, decimal.Parse(txtAntiguedadCon.Text), ddlTipoAntiguedadCon.SelectedValue,
                    txtDireccionEmpresaCon.Text, txtTelfOficinaCon.Text, txtEmailCon.Text,
                    lblCodDireccion.Text, rblTipoVivienda.SelectedValue, rblDetalleVivienda.SelectedValue,
                    txtBarrio.Text, txtCondominio.Text, txtUrbanizacion.Text,
                    txtCiudad.Text, txtAvenida.Text, txtCalle.Text,
                    txtPasilloCarretera.Text, txtNro.Text, txtEdif.Text,
                    txtPiso.Text, txtNroDepto.Text, txtTelf.Text,
                    txtReferencia.Text, "", "", null,
                    lblCodDatoLaboral.Text, rblSituacionLaboral.SelectedValue, relLboral,
                    decimal.Parse(txtAntiguedad.Text), ddlTipoAcntiguedadCli.SelectedValue, txtCargoOcupa.Text, txtEmpresaTrabaja.Text,
                    txtDirEmpresa.Text, txtTelf.Text, txtEmail2.Text,
                    decimal.Parse(txtIngresoPromedio.Text), lblCodRef1.Text, "01",
                    txtRefNombre1.Text, txtRefTrabajo1.Text, txtRefTelfContacto1.Text,
                    lblCodRef2.Text, "01", txtRefNombre2.Text,
                    txtRefTrabajo2.Text, txtRefTelfContacto2.Text, lblCodRef3.Text,
                    "02", txtRefNombre3.Text, txtRefTrabajo3.Text,
                    txtRefTelfContacto3.Text, lblCodBalance.Text, decimal.Parse(txtTotActSus.Text),
                    decimal.Parse(txtTotPasSus.Text), ingresos, egresos,
                    "", "", "",
                    "", "", "",
                    "", "", "",
                    "", "", 0,
                    "", "", DateTime.Parse("01/01/3000"),
                    "", "", "",
                    "", 0, "",
                    "", "", "",
                    "", 0, "", "",
                    "", "", "",
                    "", 0, "",
                    "", "", "",
                   "", "", "",
                   "", "", "",
                   "", "", "",
                   "", "", "",
                   "", "", "",
                   "", "", "",
                   "", "", "",
                   "", "", "",
                   lblUsuario.Text, null);
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
                string cod_solicitud = resultado2[0];


                //MultiView2.ActiveViewIndex = 0;
                pasos = 0;
                limpiar_controles();
                DataTable dt_cliente = new DataTable();
                DataTable dt_conyugue = new DataTable();
                DataTable dt_domicilio = new DataTable();
                DataTable dt_datos_laborales = new DataTable();
                DataTable dt_referencias = new DataTable();
                DataTable dt_balance = new DataTable();
                DataTable dt_ingresos = new DataTable();
                DataTable dt_egresos = new DataTable();
                DataTable dt_solicitud = new DataTable();
                DataTable dt_garante = new DataTable();
                DataTable dt_ingresosegresos = new DataTable();
                DataTable dt_paisdepto = new DataTable();

                dt_cliente = Clases.clientes.PR_GET_CLIENTE(cod_cliente);
                dt_conyugue = Clases.clientes.PR_GET_CONYUGUE(cod_cliente);
                dt_domicilio = Clases.clientes.PR_GET_DIRECCION(cod_cliente);
                dt_datos_laborales = Clases.clientes.PR_GET_DATOS_LABORALES(cod_cliente);
                dt_referencias = Clases.clientes.PR_GET_REFERENCIAS(cod_cliente);
                dt_balance = Clases.clientes.PR_GET_BALANCE(cod_cliente);
                dt_ingresos = Clases.clientes.PR_GET_INGRESOS(cod_cliente);
                dt_egresos = Clases.clientes.PR_GET_EGRESOS(cod_cliente);
                dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(cod_solicitud);
                dt_garante = Clases.clientes.PR_GET_GARANTE(cod_cliente, cod_solicitud);
                dt_ingresosegresos = Clases.clientes.PR_GET_INGRESOSEGRESOS(cod_cliente);
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
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSGarante", dt_garante));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSIngresosEgresos", dt_ingresosegresos));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSPaisDepto", dt_paisdepto));
                rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/formulario_natural.rdlc");
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
                //Response.Clear();
                //Response.AppendHeader("content-disposition", "attachment; filename=Reporte.pdf");

                //Response.ContentType = "application/pdf";
                //Response.WriteFile(filePath);
                ////Response.Flush();
                ////response.End();
                //HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                //HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                btnGrabar.Visible = false;
                btnContinuar.Visible = true;


            }
           catch (Exception ex)
            {
                string nombre_archivo = "error_natural_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
         

        }
        //private void EndResponse()
        //{
        //    try
        //    {
        //        Context.Response.End();
        //    }
        //    catch (System.Threading.ThreadAbortException err)
        //    {
        //        System.Threading.Thread.ResetAbort();
        //    }
        //    catch (Exception err)
        //    {
        //    }
       // }
        protected void btnVerificar_Click(object sender, EventArgs e)
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
                //string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                //       "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                //       "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                //       "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                //       "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
                //       "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
                //       "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active';";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

                if (txtFluEgAlq.Text == "") { txtFluEgAlq.Text = "0"; }
                if (txtFluEgAlimentos.Text == "") { txtFluEgAlimentos.Text = "0"; }
                if (txtFluEgEducacion.Text == "") { txtFluEgEducacion.Text = "0"; }
                if (txtFluEgCred.Text == "") { txtFluEgCred.Text = "0"; }
                if (txtFluEgOtros.Text == "") { txtFluEgOtros.Text = "0"; }

                if (txtFlujoSueldo.Text == "") { txtFlujoSueldo.Text = "0"; }
                if (txtFlujoHonorarios.Text == "") { txtFlujoHonorarios.Text = "0"; }
                if (txtFlujoRentas.Text == "") { txtFlujoRentas.Text = "0"; }
                if (txtFlujoUtil.Text == "") { txtFlujoUtil.Text = "0"; }
                if (txtFlujoOtros.Text == "") { txtFlujoOtros.Text = "0"; }

                decimal ingreso_total = decimal.Parse(txtFlujoSueldo.Text) + decimal.Parse(txtFlujoRentas.Text) + decimal.Parse(txtFlujoHonorarios.Text) + decimal.Parse(txtFlujoUtil.Text) + decimal.Parse(txtFlujoOtros.Text);
                decimal egreso_total = decimal.Parse(txtFluEgAlq.Text) + decimal.Parse(txtFluEgAlimentos.Text) + decimal.Parse(txtFluEgEducacion.Text) + decimal.Parse(txtFluEgCred.Text) + decimal.Parse(txtFluEgOtros.Text);
                decimal patrimonio = ingreso_total - egreso_total;
                if (patrimonio < 0)
                {
                    txtFlujoTotal.ForeColor = System.Drawing.Color.Red;
                    txtFluEgTotal.Text = egreso_total.ToString();
                    txtFlujoTotal.Text = ingreso_total.ToString();
                    lblPatrimonioBs.Text = "Los egresos superan a los ingresos.";
                    txtPatrimonioBs.Text = patrimonio.ToString();
                    txtPatrimonioBs.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtFlujoTotal.ForeColor = System.Drawing.Color.Blue;
                    txtFluEgTotal.Text = egreso_total.ToString();
                    txtFlujoTotal.Text = ingreso_total.ToString();
                    lblPatrimonioBs.Text = "";
                    txtPatrimonioBs.Text = patrimonio.ToString();
                    txtPatrimonioBs.ForeColor = System.Drawing.Color.Blue;
                }
            }
            catch
            {
                lblAviso.Text = "Hubo un problema por favor consute a su administrador.";
            }
            
        }

        protected void rblDetalleVivienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

            if (rblDetalleVivienda.SelectedItem.Text.ToUpper()=="OTRO")
                txtDetViviendaOtros.Enabled = true;
            else
            {
                txtDetViviendaOtros.Text = "";
                txtDetViviendaOtros.Enabled = false;
            }

        }

        protected void rblSituacionLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

            if (rblSituacionLaboral.SelectedItem.Text.ToUpper() == "INDEPENDIENTE"|| rblSituacionLaboral.SelectedItem.Text.ToUpper() == "JUBILADO/RENTISTA")
            {
                txtOtros.Enabled = true;
                rblRelLaboral.Enabled = false;
                rblRelLaboral.SelectedIndex = -1;
                RequiredFieldValidator51.Visible = false;
            }
            else
            {
                txtOtros.Enabled = false;
                txtOtros.Text = "";
                rblRelLaboral.Enabled = true;
                rblRelLaboral.SelectedIndex = 1;
                RequiredFieldValidator51.Visible = true;
            }
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            Session["COD_CLIENTE"] = id;
            Session["TIPO_CLIENTE"] = "N";
            Response.Redirect("solicitudes.aspx?RME=" + lblCodMenuRol.Text);
        }

        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            try
            {
                btnContinuar.Visible = false;
                btnGrabar.Visible = true;
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                MultiView1.ActiveViewIndex = 1;
                MultiView2.ActiveViewIndex = 0;

                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = true;
                lblAviso.Text = "";
                limpiar_controles();
                lblCodCliente.Text = id;
                ///////////////////////////DATOS GENERALES DEL CLIENTE//////////////////////////'
                DataTable dt = new DataTable();
                dt = simular.Datos_cliente_simuldor(lblCodCliente.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["tipo_cliente"].ToString().Trim() == "02")
                        {
                            if (String.IsNullOrEmpty(dr["nombre"].ToString())) { txtPrimerNombre.Text = ""; } else { txtPrimerNombre.Text = dr["nombre"].ToString(); }

                            if (String.IsNullOrEmpty(dr["segundo_nombre"].ToString())) { txtSegundoNombre.Text = ""; } else { txtSegundoNombre.Text = dr["segundo_nombre"].ToString(); }

                            if (String.IsNullOrEmpty(dr["tercer_nombre"].ToString())) { txtTercerNombre.Text = ""; } else { txtTercerNombre.Text = dr["tercer_nombre"].ToString(); }


                            if (String.IsNullOrEmpty(dr["apellido_paterno"].ToString())) { txtApellidoPaterno.Text = ""; } else { txtApellidoPaterno.Text = dr["apellido_paterno"].ToString(); }

                            if (String.IsNullOrEmpty(dr["apellido_materno"].ToString())) { txtApellidoMaterno.Text = ""; } else { txtApellidoMaterno.Text = dr["apellido_materno"].ToString(); }

                            if (String.IsNullOrEmpty(dr["email"].ToString())) { txtEmail.Text = ""; } else { txtEmail.Text = dr["email"].ToString(); }

                            if (String.IsNullOrEmpty(dr["numero_documento"].ToString())) { txtCi.Text = ""; } else { txtCi.Text = dr["numero_documento"].ToString(); }

                            if (String.IsNullOrEmpty(dr["telefono_celular"].ToString())) { txtCelular.Text = ""; } else { txtCelular.Text = dr["telefono_celular"].ToString(); }
                            if (String.IsNullOrEmpty(dr["expedido"].ToString())) { } else { ddlExpedido.SelectedValue = dr["expedido"].ToString(); }
                            if (String.IsNullOrEmpty(dr["estado_civil"].ToString())) { } else { ddlEstCivil.SelectedValue = dr["ESTADO_CIVIL"].ToString(); }
                            if (String.IsNullOrEmpty(dr["ext"].ToString())) { txtExt.Text = ""; } else { txtExt.Text = dr["ext"].ToString(); }
                            if (String.IsNullOrEmpty(dr["sexo"].ToString())) { } else { rblSexo.SelectedValue = dr["sexo"].ToString(); }
                            if (String.IsNullOrEmpty(dr["lug_nac"].ToString())) { } else { ddlLugarNacimiento.SelectedValue = dr["lug_nac"].ToString(); }
                            if (String.IsNullOrEmpty(dr["FECHA_FUNNAC"].ToString())) { }
                            else
                            {
                                DateTime FECHA_AUX = DateTime.Parse(dr["FECHA_FUNNAC"].ToString()); 
                                ddlNacDia.SelectedValue = FECHA_AUX.Day.ToString();
                                ddlNacMes.SelectedValue = FECHA_AUX.Month.ToString();
                                ddlNacAño.SelectedValue = FECHA_AUX.Year.ToString();

                            }
                            if (String.IsNullOrEmpty(dr["nivel_educacion"].ToString())) { } else { ddlNivelEdu.SelectedValue = dr["nivel_educacion"].ToString(); }
                            if (String.IsNullOrEmpty(dr["nacionalidad"].ToString())) { txtNacionalidad.Text = ""; } else { txtNacionalidad.Text = dr["nacionalidad"].ToString(); }
                            if (String.IsNullOrEmpty(dr["edad"].ToString())) { txtEdad.Text = ""; } else { txtEdad.Text = dr["edad"].ToString(); }
                            if (String.IsNullOrEmpty(dr["profesion"].ToString())) { txtProfesion.Text = ""; } else { txtProfesion.Text = dr["profesion"].ToString(); }
                            if (String.IsNullOrEmpty(dr["nro_dependientes"].ToString())) { txtNroDependientes.Text = ""; } else { txtNroDependientes.Text = dr["nro_dependientes"].ToString(); }


                        }

                    }

                }
                ///////////////////////////DATOS GENERALES DEL CONYUGUE//////////////////////////
                DataTable dt1 = new DataTable();
                ddlExpedidoCon.DataBind();
                ddlLugarNacimientoCon.DataBind();
                rblSexoCon.DataBind();
                ddlNivelEduCon.DataBind();
                ddlTipoAntiguedadCon.DataBind();
                dt1 = Clases.clientes.PR_GET_CONYUGUE(lblCodCliente.Text);
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        if (dr1["tipo_cliente"].ToString().Trim() == "02")
                        {
                            if (String.IsNullOrEmpty(dr1["conyugue"].ToString())) { lblCodConyugue.Text = ""; } else { lblCodConyugue.Text = dr1["conyugue"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["nombre"].ToString())) { txtPrimerNombreCon.Text = ""; } else { txtPrimerNombreCon.Text = dr1["nombre"].ToString(); }

                            if (String.IsNullOrEmpty(dr1["segundo_nombre"].ToString())) { txtSegundoNombreCon.Text = ""; } else { txtSegundoNombreCon.Text = dr1["segundo_nombre"].ToString(); }

                            if (String.IsNullOrEmpty(dr1["tercer_nombre"].ToString())) { txtTercerNombreCon.Text = ""; } else { txtTercerNombreCon.Text = dr1["tercer_nombre"].ToString(); }


                            if (String.IsNullOrEmpty(dr1["apellido_paterno"].ToString())) { txtApellidoPaternoCon.Text = ""; } else { txtApellidoPaternoCon.Text = dr1["apellido_paterno"].ToString(); }

                            if (String.IsNullOrEmpty(dr1["apellido_materno"].ToString())) { txtApellidoMaternoCon.Text = ""; } else { txtApellidoMaternoCon.Text = dr1["apellido_materno"].ToString(); }

                            if (String.IsNullOrEmpty(dr1["email"].ToString())) { txtEmailCon.Text = ""; } else { txtEmailCon.Text = dr1["email"].ToString(); }

                            if (String.IsNullOrEmpty(dr1["numero_documento"].ToString())) { txtCiCon.Text = ""; } else { txtCiCon.Text = dr1["numero_documento"].ToString(); }

                            if (String.IsNullOrEmpty(dr1["telefono_celular"].ToString())) { txtCelularCon.Text = ""; } else { txtCelularCon.Text = dr1["telefono_celular"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["expedido"].ToString())) { } else { ddlExpedidoCon.SelectedValue = dr1["expedido"].ToString(); }

                            if (String.IsNullOrEmpty(dr1["ext"].ToString())) { txtExtCon.Text = ""; } else { txtExtCon.Text = dr1["ext"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["sexo"].ToString())) { } else { rblSexoCon.SelectedValue = dr1["sexo"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["lug_nac"].ToString())) { } else { ddlLugarNacimientoCon.SelectedValue = dr1["lug_nac"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["FECHA_FUNNAC"].ToString())) { }
                            else
                            {
                                DateTime FECHA_AUX = DateTime.Parse(dr1["FECHA_FUNNAC"].ToString());
                                ddlNacDiaCon.SelectedValue = FECHA_AUX.Day.ToString();
                                ddlNacMesCon.SelectedValue = FECHA_AUX.Month.ToString();
                                ddlNacAñoCon.SelectedValue = FECHA_AUX.Year.ToString();

                            }
                            if (String.IsNullOrEmpty(dr1["nivel_educacion"].ToString())) { } else { ddlNivelEduCon.SelectedValue = dr1["nivel_educacion"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["nacionalidad"].ToString())) { txtNacionalidadCon.Text = ""; } else { txtNacionalidadCon.Text = dr1["nacionalidad"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["edad"].ToString())) { txtEdadCon.Text = ""; } else { txtEdadCon.Text = dr1["edad"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["profesion"].ToString())) { txtProfesionCon.Text = ""; } else { txtProfesionCon.Text = dr1["profesion"].ToString(); }
                            //if (String.IsNullOrEmpty(dr1["nro_dependientes"].ToString())) { txtNroDependientesCon.Text = ""; } else { txtNroDependientesCon.Text = dr1["nro_dependientes"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["cargo"].ToString())) { txtCargoCon.Text = ""; } else { txtCargoCon.Text = dr1["cargo"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["antiguedad"].ToString())) { txtAntiguedadCon.Text = ""; } else { txtAntiguedadCon.Text = dr1["antiguedad"].ToString().Replace(',', '.'); }
                            if (String.IsNullOrEmpty(dr1["tipo_antiguedad"].ToString())) { ddlTipoAntiguedadCon.DataBind(); } else { ddlTipoAntiguedadCon.SelectedValue = dr1["tipo_antiguedad"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["empresa_laboral"].ToString())) { txtEmpresaCon.Text = ""; } else { txtEmpresaCon.Text = dr1["empresa_laboral"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["direccion_empresa"].ToString())) { txtDireccionEmpresaCon.Text = ""; } else { txtDireccionEmpresaCon.Text = dr1["direccion_empresa"].ToString(); }
                            if (String.IsNullOrEmpty(dr1["telefono_fijo"].ToString())) { txtTelfOficinaCon.Text = ""; } else { txtTelfOficinaCon.Text = dr1["telefono_fijo"].ToString(); }

                        }

                    }

                }
                ////////////////////////////DATOS DOMICILIO//////////////////////
                rblTipoVivienda.DataBind();
                rblDetalleVivienda.DataBind();
                DataTable dt2 = new DataTable();
                dt2 = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow dr2 in dt2.Rows)
                    {

                        if (String.IsNullOrEmpty(dr2["COD_DIRECCION"].ToString())) { lblCodDireccion.Text = ""; } else { lblCodDireccion.Text = dr2["COD_DIRECCION"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["TIPO_VIVIENDA"].ToString())) { } else { rblTipoVivienda.SelectedValue = dr2["TIPO_VIVIENDA"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["DETALLE"].ToString())) { } else { rblDetalleVivienda.SelectedValue = dr2["DETALLE"].ToString(); }
                        if (String.IsNullOrEmpty(dr2["OTRA_DET"].ToString())) { txtDetViviendaOtros.Text = ""; } else { txtDetViviendaOtros.Text = dr2["OTRA_DET"].ToString(); }
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
                ////////////////////////////DATOS LABORALES//////////////////////
                DataTable dt3 = new DataTable();
                dt3 = Clases.clientes.PR_GET_DATOS_LABORALES(lblCodCliente.Text);
                rblSituacionLaboral.DataBind();
                rblRelLaboral.DataBind();
                ddlTipoAcntiguedadCli.DataBind();
                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow dr3 in dt3.Rows)
                    {

                        if (String.IsNullOrEmpty(dr3["COD_DATO_LABORAL"].ToString())) { lblCodDatoLaboral.Text = ""; } else { lblCodDatoLaboral.Text = dr3["COD_DATO_LABORAL"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["SITUACION_LABORAL"].ToString())) { } else { rblSituacionLaboral.SelectedValue = dr3["SITUACION_LABORAL"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["RELACION_LABORAL"].ToString())) { } else { rblRelLaboral.SelectedValue = dr3["RELACION_LABORAL"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["ANTIGUEDAD"].ToString())) { txtAntiguedad.Text = ""; } else { txtAntiguedad.Text = dr3["ANTIGUEDAD"].ToString().Replace(',', '.'); }
                        if (String.IsNullOrEmpty(dr3["tipo_antiguedad"].ToString())) { ddlTipoAcntiguedadCli.DataBind(); } else { ddlTipoAcntiguedadCli.SelectedValue = dr3["tipo_antiguedad"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["CARGO"].ToString())) { txtCargoOcupa.Text = ""; } else { txtCargoOcupa.Text = dr3["CARGO"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["EMPRESA"].ToString())) { txtEmpresaTrabaja.Text = ""; } else { txtEmpresaTrabaja.Text = dr3["EMPRESA"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["DIRECCION"].ToString())) { txtDirEmpresa.Text = ""; } else { txtDirEmpresa.Text = dr3["DIRECCION"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtTelf.Text = ""; } else { txtTelf.Text = dr3["TELEFONO"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["EMAIL"].ToString())) { txtEmail2.Text = ""; } else { txtEmail2.Text = dr3["EMAIL"].ToString(); }
                        if (String.IsNullOrEmpty(dr3["INGRESO_BS"].ToString())) { txtIngresoPromedio.Text = ""; } else { txtIngresoPromedio.Text = dr3["INGRESO_BS"].ToString().Replace(',', '.'); }
                    }
                }
                ////////////////////////////DATOS REFERENCIAS EMPRESA//////////////////////
                DataTable dt4 = new DataTable();
                dt4 = Clases.clientes.PR_GET_REFERENCIAS(lblCodCliente.Text);
                int count_ref = 0;
                if (dt4.Rows.Count > 0)
                {
                    foreach (DataRow dr4 in dt4.Rows)
                    {
                        if (count_ref == 0)
                        {
                            if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef1.Text = ""; } else { lblCodRef1.Text = dr4["COD_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre1.Text = ""; } else { txtRefNombre1.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo1.Text = ""; } else { txtRefTrabajo1.Text = dr4["OCUPACION"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto1.Text = ""; } else { txtRefTelfContacto1.Text = dr4["TELEFONO"].ToString(); }
                        }
                        if (count_ref == 1)
                        {
                            if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef2.Text = ""; } else { lblCodRef2.Text = dr4["COD_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre2.Text = ""; } else { txtRefNombre2.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo2.Text = ""; } else { txtRefTrabajo2.Text = dr4["OCUPACION"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto2.Text = ""; } else { txtRefTelfContacto2.Text = dr4["TELEFONO"].ToString(); }
                        }
                        if (count_ref == 2)
                        {
                            if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef3.Text = ""; } else { lblCodRef3.Text = dr4["COD_REFERENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre3.Text = ""; } else { txtRefNombre3.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo3.Text = ""; } else { txtRefTrabajo3.Text = dr4["OCUPACION"].ToString(); }
                            if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto3.Text = ""; } else { txtRefTelfContacto3.Text = dr4["TELEFONO"].ToString(); }
                        }
                        count_ref++;
                    }

                }
                ////////////////////////////DATOS BALANCE//////////////////////
                DataTable dt5 = new DataTable();
                dt5 = Clases.clientes.PR_GET_BALANCE(lblCodCliente.Text);

                if (dt5.Rows.Count > 0)
                {
                    foreach (DataRow dr5 in dt5.Rows)
                    {

                        if (String.IsNullOrEmpty(dr5["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr5["COD_BALANCE"].ToString(); }
                        if (String.IsNullOrEmpty(dr5["TOTAL_ACTIVOS_SUS"].ToString())) { txtTotActSus.Text = "02"; } else { txtTotActSus.Text = decimal.Parse(dr5["TOTAL_ACTIVOS_SUS"].ToString()).ToString().Replace(',', '.'); }
                        if (String.IsNullOrEmpty(dr5["TOTAL_PASIVOS"].ToString())) { txtTotPasSus.Text = ""; } else { txtTotPasSus.Text = dr5["TOTAL_PASIVOS"].ToString().Replace(',', '.'); }
                        if (String.IsNullOrEmpty(dr5["PATRIMONIO_SUS"].ToString())) { txtPatNetoSus.Text = ""; } else { txtPatNetoSus.Text = dr5["PATRIMONIO_SUS"].ToString().Replace(',', '.'); }

                    }

                }
                ////////////////////////////DATOS INGRESOS//////////////////////
                DataTable dt6 = new DataTable();
                dt6 = Clases.clientes.PR_GET_INGRESOS(lblCodCliente.Text);

                if (dt6.Rows.Count > 0)
                {
                    foreach (DataRow dr6 in dt6.Rows)
                    {

                        //if (String.IsNullOrEmpty(dr6["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr6["COD_BALANCE"].ToString(); }
                        if (String.IsNullOrEmpty(dr6["INGRESOS"].ToString())) { }
                        else
                        {
                            if (dr6["INGRESOS"].ToString() == "Sueldos")
                            {
                                txtFlujoSueldo.Text = dr6["BS"].ToString().Replace(',', '.');
                            }
                            if (dr6["INGRESOS"].ToString() == "Honorarios")
                            {
                                txtFlujoHonorarios.Text = dr6["BS"].ToString().Replace(',', '.');
                            }
                            if (dr6["INGRESOS"].ToString() == "Rentas")
                            {
                                txtFlujoRentas.Text = dr6["BS"].ToString().Replace(',', '.');
                            }
                            if (dr6["INGRESOS"].ToString() == "Utilidades")
                            {
                                txtFlujoUtil.Text = dr6["BS"].ToString().Replace(',', '.');
                            }
                            if (dr6["INGRESOS"].ToString() == "Otros")
                            {
                                txtFlujoOtros.Text = dr6["BS"].ToString().Replace(',', '.');
                            }

                        }


                    }

                }
                ////////////////////////////DATOS EGRESOS//////////////////////
                DataTable dt7 = new DataTable();
                dt7 = Clases.clientes.PR_GET_EGRESOS(lblCodCliente.Text);

                if (dt7.Rows.Count > 0)
                {
                    foreach (DataRow dr7 in dt7.Rows)
                    {

                        //if (String.IsNullOrEmpty(dr7["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr7["COD_BALANCE"].ToString(); }
                        if (String.IsNullOrEmpty(dr7["EGRESOS"].ToString())) { }
                        else
                        {
                            if (dr7["EGRESOS"].ToString() == "Alquielres")
                            {
                                txtFluEgAlq.Text = dr7["BS"].ToString().Replace(',', '.');
                            }
                            if (dr7["EGRESOS"].ToString() == "Alimentacion y servicios")
                            {
                                txtFluEgAlimentos.Text = dr7["BS"].ToString().Replace(',', '.');
                            }
                            if (dr7["EGRESOS"].ToString() == "Educacion")
                            {
                                txtFluEgEducacion.Text = dr7["BS"].ToString().Replace(',', '.');
                            }
                            if (dr7["EGRESOS"].ToString() == "Pago de creditos")
                            {
                                txtFluEgCred.Text = dr7["BS"].ToString().Replace(',', '.');
                            }
                            if (dr7["EGRESOS"].ToString() == "Otros")
                            {
                                txtFluEgOtros.Text = dr7["BS"].ToString().Replace(',', '.');
                            }

                        }


                    }

                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_natural_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
            Session["TIPO_CLIENTE"] = "N";
            Response.Redirect("editar_seccion.aspx?RME=" + lblCodMenuRol.Text);
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string cod_solicitud = Session["COD_SOLICITUD"].ToString();
            string cod_cliente = Session["COD_CLIENTE"].ToString();
            Clases.solicitudes obj_d = new Clases.solicitudes("S", cod_solicitud, "", "", "", 0, 0, 0, 0, 0, "", "", "", lblUsuario.Text);
            string resultado1 = obj_d.ABM();

            string[] res_aux = resultado1.Split('|');
            Session["COD_SOLICITUD_DETALLE"] = res_aux[2];

            Session["usuario"] = lblUsuario.Text;
            Session["COD_SOLICITUD"] = cod_solicitud;
            Session["COD_CLIENTE"] = cod_cliente;
            Session["TIPO_CLIENTE"] = "N";
            Response.Redirect("solicitudes_admin.aspx?inicialcounter=SI&RME=" + lblCodMenuRol.Text);
            // Response.End();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnContinuar.Visible = false;
            btnGrabar.Visible = true;
            MultiView1.ActiveViewIndex = 1;
            MultiView2.ActiveViewIndex = 0;
            pasos = 0;
            lblCodCliente.Text = "";
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = true;
            lblAviso.Text = "";
            limpiar_controles();

        }
        protected void btnGuardarCorquis_Click(object sender, EventArgs e)
        {
            string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
                "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //btnGuardarCorquis.Text = "Imgen guardada";
            //btnGuardarCorquis.Enabled = false;
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
        //protected string Gmap2_Click(object s, Subgurim.Controles.GAjaxServerEventArgs e)
        //{
        //    string javaScript = "document.getElementById('p1').className = 'col-md-3 col-sm-4 col-6 active'; " +
        //        "document.getElementById('p2').className = 'col-md-3 col-sm-4 col-6 active'; " +
        //        "document.getElementById('p3').className = 'col-md-3 col-sm-4 col-6 active'; " +
        //        "document.getElementById('p4').className = 'col-md-3 col-sm-4 col-6 active'; " +
        //        "document.getElementById('p5').className = 'col-md-3 col-sm-4 col-6 active'; " +
        //        "document.getElementById('p6').className = 'col-md-3 col-sm-4 col-6 active'; " +
        //        "document.getElementById('p7').className = 'col-md-3 col-sm-4 col-6 active';";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        //    Gmap2.resetMarkers();
        //    lat = e.point.lat.ToString();
        //    lng = e.point.lng.ToString();

        //    zom = e.zoom.ToString();
        //    GLatLng ubicacion1 = new GLatLng(e.point.lat, e.point.lng);
        //    txtLat.Text = lat;
        //    txtLon.Text = lng;
        //    Gmap2.setCenter(ubicacion1, e.zoom);
        //    //Gmap2.Height = 300;
        //    //Gmap2.Width = 480;
        //    Gmap2.Add(new GControl(GControl.preBuilt.LargeMapControl));
        //    //Gmap2.addControl(new GControl(GControl.preBuilt.LargeMapControl));
        //    Gmap2.Add(new GControl(GControl.preBuilt.MapTypeControl));
        //    //Gmap2.addControl(new GControl(GControl.preBuilt.MapTypeControl));
        //    Gmap2.enableHookMouseWheelToZoom = true;
        //    //Gmap2.enableScrollWheelZoom = true;
        //    GMarker mark1 = new GMarker(ubicacion1);
        //    Gmap2.Add(mark1);
        //    //Gmap2.addGMarker(mark);
        //    Gmap2.mapType = GMapType.GTypes.Satellite;
        //    return Gmap2.ToString();
        //}
    }
}