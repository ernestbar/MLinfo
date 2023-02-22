using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;
using System.Data;
using System.IO;
using System.Text;

namespace appAmascuotas
{
    public partial class sucursal_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    btnNuevoCliente.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["DESCRIPCION"].ToString().ToUpper() == "NEW")
                                btnNuevoCliente.Visible = true;
                        }
                    }
                    MultiView1.ActiveViewIndex = 0;
                    limpiar_controles();
                }
            }
        }
        public void limpiar_controles()
        {
            lblAviso.Text = "";
            lblCodSucursal.Text = "";
            txtCodigo.Text = "";
            txtCodigo.Enabled = true;
            txtNombreSucursal.Text = "";
            txtDireccion.Text = "";
            txtLongitud.Text = "";
            txtLatitud.Text = "";
            txtCiudad.Text = "";
            txtVillage.Text = "";
            txtPostalCode.Text = "";
            ddlPais.DataBind();
            ddlCiudad.DataBind();
        }
        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            ListItem itemd = new ListItem();
            itemd.Text = "SWITZERLAND";
            itemd.Value = "SWI";
            ddlPais.SelectedIndex=ddlPais.Items.IndexOf(itemd);
            MultiView1.ActiveViewIndex = 1;
        }
        
        protected void ddlPais_DataBound(object sender, EventArgs e)
        {
            ddlPais.Items.Insert(0, "SELECT");
        }
        protected void ddlCiudad_DataBound(object sender, EventArgs e)
        {
            ddlCiudad.Items.Insert(0, "SELECT");
        }
        
        
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodSucursal.Text = id;
                txtCodigo.Text = id;
                txtCodigo.Enabled = false;
                Clases.Sucursales cli = new Clases.Sucursales(lblCodSucursal.Text);
                txtNombreSucursal.Text = cli.PV_NOMBRE_SUCURSAL;
                txtDireccion.Text = cli.PV_DIRECCION;
                txtLatitud.Text = cli.PV_LATITUD;
                txtLongitud.Text = cli.PV_LOGITUD;
                if(cli.PV_LATITUD!="")
                    inciar_mapa(cli.PV_LATITUD, cli.PV_LOGITUD);
                ddlPais.DataBind();
                ddlPais.SelectedValue = cli.PB_ID_PAIS.ToString();
                ddlCiudad.DataBind();
                //ddlCiudad.SelectedValue = cli.PB_ID_CIUDAD.ToString();
                txtCiudad.Text = cli.PB_ID_CIUDAD;
                txtVillage.Text = cli.PB_VILLAGE_NAME;
                txtPostalCode.Text = cli.PB_POSTALE_CODE;
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sucurasles_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (lblCodSucursal.Text == "")
                {
                    Clases.Sucursales cli = new Clases.Sucursales("I",txtCodigo.Text, txtNombreSucursal.Text,txtDireccion.Text,ddlPais.SelectedValue,txtCiudad.Text, txtLatitud.Text, txtLongitud.Text, lblUsuario.Text,txtVillage.Text,txtPostalCode.Text);
                    lblAviso.Text = cli.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;

                }
                else
                {

                    Clases.Sucursales cli = new Clases.Sucursales("U", lblCodSucursal.Text, txtNombreSucursal.Text, txtDireccion.Text, ddlPais.SelectedValue, txtCiudad.Text, txtLatitud.Text, txtLongitud.Text, lblUsuario.Text, txtVillage.Text, txtPostalCode.Text);
                    lblAviso.Text = cli.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                }
                Repeater1.DataBind();
                
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sucurasles_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }

        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                if (datos[1] == "ACTIVE")
                {
                    Clases.Sucursales mcc = new Clases.Sucursales("D", datos[0],"","","","","","", lblUsuario.Text,"","");
                    lblAviso.Text = mcc.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Sucursales mcc = new Clases.Sucursales("A", datos[0], "", "", "", "", "", "", lblUsuario.Text,"","");
                    lblAviso.Text = mcc.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    Repeater1.DataBind();
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_sucurasles_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }



        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

       
        static string lat, lng, zom;
        private void inciar_mapa(string lat, string lng)
        {
            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            Gmap2.resetMarkers();

            //GLatLng ubicacion1 = new GLatLng(double.Parse(lat.Replace(".", decSep)), double.Parse(lng.Replace(".", decSep)));
            GLatLng ubicacion1 = new GLatLng(double.Parse(lat), double.Parse(lng));
            Gmap2.setCenter(ubicacion1, 17);
            //Gmap2.Height = 300;
            //Gmap2.Width = 480;
            txtLatitud.Text = lat;
            txtLongitud.Text = lng;
            Gmap2.Add(new GControl(GControl.preBuilt.LargeMapControl));
            //Gmap2.addControl(new GControl(GControl.preBuilt.LargeMapControl));
            Gmap2.Add(new GControl(GControl.preBuilt.MapTypeControl));
            //Gmap2.addControl(new GControl(GControl.preBuilt.MapTypeControl));
            Gmap2.enableHookMouseWheelToZoom = true;
            //Gmap2.enableScrollWheelZoom = true;
            GMarker mark1 = new GMarker(ubicacion1);
            Gmap2.Add(mark1);
            //Gmap2.addGMarker(mark1);
            Gmap2.mapType = GMapType.GTypes.Satellite;
        }

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string[] datos = ddlCiudad.SelectedValue.Split('|');
            txtCiudad.Text = datos[0];
            txtVillage.Text = datos[1];
            txtPostalCode.Text = datos[2];

            txtCiudad.Enabled = false;
            txtVillage.Enabled = false;
            txtPostalCode.Enabled = false;

            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
           
            string lat = datos[3];
            string lon = datos[4];
            inciar_mapa(lat.Replace(".", decSep), lon.Replace(".", decSep));
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                Button bEdit = (Button)e.Item.FindControl("btnEditar");
                bEdit.Visible = false;
                bEliminar.Visible = false;
                DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDIT")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "DELETE")
                            bEliminar.Visible = true;
                    }

                }

            }
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgNew_Click(object sender, ImageClickEventArgs e)
        {
            txtCiudad.Text = "";
            txtCiudad.Enabled = true;
            txtVillage.Text = "";
            txtVillage.Enabled = true;
            txtPostalCode.Text = "";
            txtPostalCode.Enabled = true;
            txtCiudad.Focus();
        }

        protected void btnVerUbi_Click(object sender, EventArgs e)
        {
            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            if (hfLongitud.Value == "")
            { inciar_mapa("-16.5".Replace(".", decSep).Replace(",", decSep), "-68.15".Replace(".", decSep).Replace(",", decSep)); }
            else
            { inciar_mapa(hfLatitud.Value.Replace(".", decSep).Replace(",", decSep), hfLongitud.Value.Replace(".", decSep).Replace(",", decSep)); }
        }
        protected string Gmap2_Click(object s, GAjaxServerEventArgs e)
        {
            Gmap2.resetMarkers();
            lat = e.point.lat.ToString();
            lng = e.point.lng.ToString();

            zom = e.zoom.ToString();
            GLatLng ubicacion1 = new GLatLng(e.point.lat, e.point.lng);
            txtLatitud.Text = lat;
            txtLongitud.Text = lng;
            Gmap2.setCenter(ubicacion1, e.zoom);
            //Gmap2.Height = 300;
            //Gmap2.Width = 480;
            Gmap2.Add(new GControl(GControl.preBuilt.LargeMapControl));
            //Gmap2.addControl(new GControl(GControl.preBuilt.LargeMapControl));
            Gmap2.Add(new GControl(GControl.preBuilt.MapTypeControl));
            //Gmap2.addControl(new GControl(GControl.preBuilt.MapTypeControl));
            Gmap2.enableHookMouseWheelToZoom = true;
            //Gmap2.enableScrollWheelZoom = true;
            GMarker mark1 = new GMarker(ubicacion1);
            Gmap2.Add(mark1);
            //Gmap2.addGMarker(mark);
            Gmap2.mapType = GMapType.GTypes.Satellite;
            return Gmap2.ToString();
        }
    }
}