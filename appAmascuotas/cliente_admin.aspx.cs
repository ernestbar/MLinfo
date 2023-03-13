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
    public partial class cliente_admin : System.Web.UI.Page
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
                    lbtNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["DESCRIPCION"].ToString().ToUpper() == "NEW")
                                lbtNuevo.Visible = true;
                        }

                    }
                    MultiView1.ActiveViewIndex = 0;
                    
                }
            }

        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha_salida = DateTime.Parse("01/01/3000").ToString();
                if (hfFechaSalida.Value != "")
                    fecha_salida = hfFechaSalida.Value;
                if (txtVillage.Enabled == true)
                    txtVillage.Text = ddlPais.SelectedItem.Text;
                if (txtBillingVillage.Enabled == true)
                    txtBillingVillage.Text = ddlPais2.SelectedItem.Text;
                long phone = 0;
                long mobile = 0;
                long fax = 0;
                if (txtPhone.Text != "")
                    phone = long.Parse(txtPhone.Text);
                if (txtMobile.Text != "")
                    mobile = long.Parse(txtMobile.Text);
                if (txtFax.Text != "")
                    fax = long.Parse(txtFax.Text);
                if (lblIdCliente.Text == "")
                {
                    Clases.Clientes obj = new Clases.Clientes("I",0,ddlTipoCliente.SelectedValue,txtSociety.Text,txtName.Text,txtSurname.Text,DateTime.Parse(fecha_salida),txtAddres.Text,
                        ddlPais.SelectedValue,txtCiudad.Text,txtVillage.Text,txtPostalCode.Text,txtLongitud.Text,txtLatitud.Text,txtEmail.Text,phone,
                        mobile,fax,ddlTypeComunication.SelectedValue,txtDoorNumber.Text,txtFloor.Text,txtComments.Text,txtBillingAddress.Text,
                        "",txtBillingCity.Text,txtBillingVillage.Text,txtBillingPostaleCode.Text,txtBillingLongitud.Text,txtBillingLatitud.Text,lblUsuario.Text);
                    lblAviso.Text = obj.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Clientes obj = new Clases.Clientes("U",long.Parse(lblIdCliente.Text), ddlTipoCliente.SelectedValue, txtSociety.Text, txtName.Text, txtSurname.Text, DateTime.Parse(fecha_salida), txtAddres.Text,
                        ddlPais.SelectedValue, txtCiudad.Text, txtVillage.Text, txtPostalCode.Text, txtLongitud.Text, txtLatitud.Text, txtEmail.Text, phone,
                        mobile, fax, ddlTypeComunication.SelectedValue, txtDoorNumber.Text, txtFloor.Text, txtComments.Text, txtBillingAddress.Text,
                        "", txtBillingCity.Text, txtBillingVillage.Text, txtBillingPostaleCode.Text, txtBillingLongitud.Text, txtBillingLatitud.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cliente_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }


        }

        protected void btnVolverAlta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpiar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            //ListItem itemd = new ListItem();
            //itemd.Text = "SWITZERLAND";
            //itemd.Value = "SWI";
            //ddlPais.SelectedIndex = ddlPais.Items.IndexOf(itemd);
            //ddlPais2.SelectedIndex = ddlPais2.Items.IndexOf(itemd);
            lblIdCliente.Text = "";
            MultiView1.ActiveViewIndex = 2;

        }
        public void limpiar()
        {
            txtAddres.Text = "";
            txtBillingAddress.Text = ""; ;
            txtBillingCity.Text = "";
            txtBillingLatitud.Text = "";
            txtBillingLongitud.Text = "";
            txtBillingPostaleCode.Text = "";
            txtBillingVillage.Text = "";
            txtCiudad.Text = "";
            txtComments.Text = "";
            txtDoorNumber.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtFloor.Text = "";
            txtLatitud.Text = "";
            txtLongitud.Text = "";
            txtMobile.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtPostalCode.Text = "";
            txtSociety.Text = "";
            txtSurname.Text = "";
            txtVillage.Text = "";
            //ddlBillingCountry.DataBind();
            ddlPais.DataBind();
            ddlTipoCliente.DataBind();
            ddlTypeComunication.DataBind();
           
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblIdCliente.Text = id;
                Clases.Clientes obj_m = new Clases.Clientes(long.Parse(id));
                txtAddres.Text = obj_m.PV_ADDRESS;
                txtBillingAddress.Text = obj_m.PV_ADDRESS;
                txtBillingCity.Text = obj_m.PV_CITY;
                txtBillingLatitud.Text = obj_m.PV_LATITUD_FACT;
                txtBillingLongitud.Text = obj_m.PV_LONGITUD_FACT;
                txtBillingPostaleCode.Text = obj_m.PV_POSTALE_CODE_FACT;
                txtBillingVillage.Text =  obj_m.PV_VILLAGE_NAME_FACT;
                txtCiudad.Text =  obj_m.PV_CITY;
                txtComments.Text =  obj_m.PV_COMMENTS;
                txtDoorNumber.Text =  obj_m.PV_DOOR_NUMBER;
                txtEmail.Text =  obj_m.PV_EMAIL;
                txtFax.Text =  obj_m.PB_FAX.ToString();
                txtFloor.Text =  obj_m.PV_FLOOR;
                txtLatitud.Text =  obj_m.PV_LATITUD;
                txtLongitud.Text =  obj_m.PV_LONGITUD;
                txtMobile.Text =  obj_m.PB_MOBILE.ToString();
                txtName.Text =  obj_m.PV_NAME;
                txtPhone.Text =  obj_m.PB_PHONE.ToString();
                txtPostalCode.Text =  obj_m.PV_POSTALE_CODE;
                txtSociety.Text =  obj_m.PV_SOCIETY;
                txtSurname.Text =  obj_m.PV_SURNAMES;
                txtVillage.Text =  obj_m.PV_VILLAGE_NAME;
                ddlPais2.SelectedValue = obj_m.PV_COUNTRY_FACT;
                ddlPais.SelectedValue = obj_m.PV_COUNTRY;
                ddlTipoCliente.SelectedValue = obj_m.PV_TYPE_CLIENT;
                ddlTypeComunication.SelectedValue = obj_m.PV_TYPE_COMMUNICATION;
                DateTime fecha1 = obj_m.PD_DATE_BIRTH;
                string dia = "";
                string mes = "";
                if (fecha1.Day.ToString().Length == 1)
                    dia = "0" + fecha1.Day.ToString();
                else
                    dia = fecha1.Day.ToString();

                if (fecha1.Month.ToString().Length == 1)
                    mes = "0" + fecha1.Month.ToString();
                else
                    mes = fecha1.Month.ToString();
                hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
                if (obj_m.PV_LATITUD != "")
                    inciar_mapa(obj_m.PV_LATITUD, obj_m.PV_LONGITUD);
                if (obj_m.PV_LATITUD_FACT != "")
                    inciar_mapa1(obj_m.PV_LATITUD_FACT, obj_m.PV_LONGITUD_FACT);
                MultiView1.ActiveViewIndex = 2;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_roles_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblIdCliente.Text = datos[0];
                if (datos[1] == "ACTIVE")
                {
                    Clases.Clientes obj_m = new Clases.Clientes("D",long.Parse(lblIdCliente.Text),"", "", "", "",DateTime.Now, "", "", "", "", "", "", "",
                        "",0,0,0, "", "", "", "", "", "", "", "", "", "", "", lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                }
                else
                {
                    Clases.Clientes obj_m = new Clases.Clientes("A", long.Parse(lblIdCliente.Text), "", "", "", "", DateTime.Now, "", "", "", "", "", "", "",
                        "", 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                }

                Repeater1.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_roles_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Button bEdit = (Button)e.Item.FindControl("btnEditar");
                //Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                //Button bContacts = (Button)e.Item.FindControl("btnContacts");
                //bEdit.Visible = false;
                //bEliminar.Visible = false;
                //bContacts.Visible = false;
                //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDIT")
                //            bEdit.Visible = true;
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "DELETE")
                //            bEliminar.Visible = true;
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "CONTACTS")
                //            bContacts.Visible = true;
                //    }

                //}


            }
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
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
        }
        protected void ddlTipoCliente_DataBound(object sender, EventArgs e)
        {
            ddlTipoCliente.Items.Insert(0, "SELECT");
        }

        protected void ddlCiudad_DataBound(object sender, EventArgs e)
        {
            ddlCiudad.Items.Insert(0, "SELECT");
        }

        protected void ddlTypeComunication_DataBound(object sender, EventArgs e)
        {
            ddlTypeComunication.Items.Insert(0, "SELECT");
        }

        //protected void ddlBillingCountry_DataBound(object sender, EventArgs e)
        //{
        //    ddlBillingCountry.Items.Insert(0, "SELECT");
        //}
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
        private void inciar_mapa3(string lat, string lng)
        {
            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            Gmap3.resetMarkers();

            //GLatLng ubicacion1 = new GLatLng(double.Parse(lat.Replace(".", decSep)), double.Parse(lng.Replace(".", decSep)));
            GLatLng ubicacion1 = new GLatLng(double.Parse(lat), double.Parse(lng));
            Gmap3.setCenter(ubicacion1, 17);
            //Gmap2.Height = 300;
            //Gmap2.Width = 480;


            Gmap3.Add(new GControl(GControl.preBuilt.LargeMapControl));

            //Gmap2.addControl(new GControl(GControl.preBuilt.LargeMapControl));
            Gmap3.Add(new GControl(GControl.preBuilt.MapTypeControl));
            //Gmap2.addControl(new GControl(GControl.preBuilt.MapTypeControl));
            Gmap3.enableHookMouseWheelToZoom = true;
            //Gmap2.enableScrollWheelZoom = true;
            GMarker mark1 = new GMarker(ubicacion1);
            Gmap3.Add(mark1);
            //Gmap2.addGMarker(mark1);
            Gmap3.mapType = GMapType.GTypes.Satellite;

        }
        private void inciar_mapa1(string lat, string lng)
        {
            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            Gmap1.resetMarkers();

            //GLatLng ubicacion1 = new GLatLng(double.Parse(lat.Replace(".", decSep)), double.Parse(lng.Replace(".", decSep)));
            GLatLng ubicacion1 = new GLatLng(double.Parse(lat), double.Parse(lng));
            Gmap1.setCenter(ubicacion1, 17);
            //Gmap2.Height = 300;
            //Gmap2.Width = 480;
            txtBillingLatitud.Text = lat;
            txtBillingLongitud.Text = lng;

            Gmap1.Add(new GControl(GControl.preBuilt.LargeMapControl));

            //Gmap2.addControl(new GControl(GControl.preBuilt.LargeMapControl));
            Gmap1.Add(new GControl(GControl.preBuilt.MapTypeControl));
            //Gmap2.addControl(new GControl(GControl.preBuilt.MapTypeControl));
            Gmap1.enableHookMouseWheelToZoom = true;
            //Gmap2.enableScrollWheelZoom = true;
            GMarker mark1 = new GMarker(ubicacion1);
            Gmap1.Add(mark1);
            //Gmap2.addGMarker(mark1);
            Gmap1.mapType = GMapType.GTypes.Satellite;
        }
        protected void btnVerUbi_Click(object sender, EventArgs e)
        {
            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            if (hfLongitud.Value == "")
            { inciar_mapa("-16.5".Replace(".", decSep).Replace(",", decSep), "-68.15".Replace(".", decSep).Replace(",", decSep)); }
            else
            { inciar_mapa(hfLatitud.Value.Replace(".", decSep).Replace(",", decSep), hfLongitud.Value.Replace(".", decSep).Replace(",", decSep)); }
        }

        

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
            //string javaScript = "document.getElementById('<%=ddlCiudad.ClientID%>').className = 'default-select2 form-control'; ";
            ////    +
            ////   "document.getElementById('p2').className = 'col-md-2 col-sm-4 col-6 nav-item done'; " +
            ////"document.getElementById('p3').className = 'col-md-2 col-sm-4 col-6 nav-item active'; ";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void ddlPais_DataBound(object sender, EventArgs e)
        {
            ddlPais.Items.Insert(0, "SELECT");
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
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
        }

        protected void btnContacts_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            Session["id_cliente"] = id;
            Response.Redirect("contact_admin.aspx?RME=50");
        }

        protected void ibtnNewBilling_Click(object sender, ImageClickEventArgs e)
        {
            txtBillingCity.Text = "";
            txtBillingCity.Enabled = true;
            txtBillingVillage.Text = "";
            txtBillingVillage.Enabled = true;
            txtBillingPostaleCode.Text = "";
            txtBillingPostaleCode.Enabled = true;
            txtBillingCity.Focus();
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
        }

  

        protected void btnBillingVerUbi_Click1(object sender, EventArgs e)
        {
            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            if (hfBillingLongitud.Value == "")
            { inciar_mapa1("-16.5".Replace(".", decSep).Replace(",", decSep), "-68.15".Replace(".", decSep).Replace(",", decSep)); }
            else
            { inciar_mapa1(hfBillingLatitud.Value.Replace(".", decSep).Replace(",", decSep), hfBillingLongitud.Value.Replace(".", decSep).Replace(",", decSep)); }
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
        }

       

        protected void ddlPais2_DataBound(object sender, EventArgs e)
        {
            ddlPais2.Items.Insert(0, "SELECT");
        }

        

        protected void ddlCiudad2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] datos = ddlCiudad2.SelectedValue.Split('|');
            txtBillingCity.Text = datos[0];
            txtBillingVillage.Text = datos[1];
            txtBillingPostaleCode.Text = datos[2];

            txtBillingCity.Enabled = false;
            txtBillingVillage.Enabled = false;
            txtBillingPostaleCode.Enabled = false;

            string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            string lat = datos[3];
            string lon = datos[4];
            inciar_mapa1(lat.Replace(".", decSep), lon.Replace(".", decSep));
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
        }

        protected void ddlCiudad2_DataBound(object sender, EventArgs e)
        {
            ddlCiudad2.Items.Insert(0, "SELECT");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {

                lblAviso.Text = "";
                string id = "";
                LinkButton obj = (LinkButton)sender;
                id = obj.CommandArgument.ToString();
                lblIdCliente.Text = id;
                Clases.Clientes obj_m = new Clases.Clientes(long.Parse(id));
                lblAddressR.Text = obj_m.PV_ADDRESS;
                lblCityR.Text = obj_m.PV_CITY;
                lblEmailR.Text = obj_m.PV_EMAIL;
                lblFaxR.Text = obj_m.PB_FAX.ToString();
                lblCelularR.Text = obj_m.PB_MOBILE.ToString();
                lblClientR.Text = obj_m.PV_NAME + " " + obj_m.PV_SURNAMES;
                lblTelphoneR.Text = obj_m.PB_PHONE.ToString();
                lblPostaleR.Text = obj_m.PV_POSTALE_CODE;
                lblSocietyR.Text = obj_m.PV_SOCIETY;
                lblVillageR.Text = obj_m.PV_VILLAGE_NAME;
                lblBirthDateR.Text = obj_m.PD_DATE_BIRTH.ToShortDateString();
                lblComunicationR.Text = obj_m.PV_TYPE_COMMUNICATION_DESC;
                if(obj_m.PV_LATITUD!="")
                    inciar_mapa3(obj_m.PV_LATITUD,obj_m.PV_LONGITUD);
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_client_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }

        protected void lbtnEditarR_Click(object sender, EventArgs e)
        {
            try
            {

                lblAviso.Text = "";
               
                Clases.Clientes obj_m = new Clases.Clientes(long.Parse(lblIdCliente.Text));
                txtAddres.Text = obj_m.PV_ADDRESS;
                txtBillingAddress.Text = obj_m.PV_ADDRESS;
                txtBillingCity.Text = obj_m.PV_CITY;
                txtBillingLatitud.Text = obj_m.PV_LATITUD_FACT;
                txtBillingLongitud.Text = obj_m.PV_LONGITUD_FACT;
                txtBillingPostaleCode.Text = obj_m.PV_POSTALE_CODE_FACT;
                txtBillingVillage.Text = obj_m.PV_VILLAGE_NAME_FACT;
                txtCiudad.Text = obj_m.PV_CITY;
                txtComments.Text = obj_m.PV_COMMENTS;
                txtDoorNumber.Text = obj_m.PV_DOOR_NUMBER;
                txtEmail.Text = obj_m.PV_EMAIL;
                txtFax.Text = obj_m.PB_FAX.ToString();
                txtFloor.Text = obj_m.PV_FLOOR;
                txtLatitud.Text = obj_m.PV_LATITUD;
                txtLongitud.Text = obj_m.PV_LONGITUD;
                txtMobile.Text = obj_m.PB_MOBILE.ToString();
                txtName.Text = obj_m.PV_NAME;
                txtPhone.Text = obj_m.PB_PHONE.ToString();
                txtPostalCode.Text = obj_m.PV_POSTALE_CODE;
                txtSociety.Text = obj_m.PV_SOCIETY;
                txtSurname.Text = obj_m.PV_SURNAMES;
                txtVillage.Text = obj_m.PV_VILLAGE_NAME;
                //ddlBillingCountry.SelectedValue = obj_m.PV_COUNTRY_FACT;
                if (obj_m.PV_COUNTRY != ""&& obj_m.PV_COUNTRY !="SELECT")
                    ddlPais.SelectedValue = obj_m.PV_COUNTRY;
                if(obj_m.PV_COUNTRY_FACT!="" && obj_m.PV_COUNTRY_FACT != "SELECT")
                    ddlPais2.SelectedValue = obj_m.PV_COUNTRY_FACT;
                if (obj_m.PV_TYPE_CLIENT != "")
                    ddlTipoCliente.SelectedValue = obj_m.PV_TYPE_CLIENT;
                if (obj_m.PV_TYPE_COMMUNICATION != "")
                    ddlTypeComunication.SelectedValue = obj_m.PV_TYPE_COMMUNICATION;

                if (obj_m.PD_DATE_BIRTH != DateTime.Parse("01/01/3000"))
                {
                    DateTime fecha1 = obj_m.PD_DATE_BIRTH;
                    string dia = "";
                    string mes = "";
                    if (fecha1.Day.ToString().Length == 1)
                        dia = "0" + fecha1.Day.ToString();
                    else
                        dia = fecha1.Day.ToString();

                    if (fecha1.Month.ToString().Length == 1)
                        mes = "0" + fecha1.Month.ToString();
                    else
                        mes = fecha1.Month.ToString();
                    hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
                }
                
                if (obj_m.PV_LATITUD != "")
                    inciar_mapa(obj_m.PV_LATITUD, obj_m.PV_LONGITUD);
                if (obj_m.PV_LATITUD_FACT != "")
                    inciar_mapa1(obj_m.PV_LATITUD_FACT, obj_m.PV_LONGITUD_FACT);
                MultiView1.ActiveViewIndex = 2;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_roles_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }

        protected void lbtNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            //ListItem itemd = new ListItem();
            //itemd.Text = "SWITZERLAND";
            //itemd.Value = "SWI";
            //ddlPais.SelectedIndex = ddlPais.Items.IndexOf(itemd);
            //ddlPais2.SelectedIndex = ddlPais2.Items.IndexOf(itemd);
            lblIdCliente.Text = "";
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbtnVoler2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ibtnMapa_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                ImageButton obj = (ImageButton)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                Session["lat"] = datos[0];
                Session["lon"] = datos[1];
                Response.Write("<script>window.open ('mapa_cliente.aspx','_blank');</script>");

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_roles_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }

        protected void LinkButton34_Click(object sender, EventArgs e)
        {
            Session["id_cliente"] = lblIdCliente.Text;
            Response.Redirect("contact_admin.aspx?RME=50");
        }

        protected void lbtnNewIntervention_Click(object sender, EventArgs e)
        {
            Session["id_cliente"] = lblIdCliente.Text;
            Session["is_billed"] = "new";
            Response.Redirect("interventions_admin.aspx?RME=55");
        }

        protected void lbtnListInterventions_Click(object sender, EventArgs e)
        {
            Session["id_cliente"] = lblIdCliente.Text;
            Session["is_billed"] = "null";
            Response.Redirect("interventions_admin.aspx?RME=55");
        }

        protected string Gmap1_Click1(object s, GAjaxServerEventArgs e)
        {
            Gmap1.resetMarkers();
            lat = e.point.lat.ToString();
            lng = e.point.lng.ToString();

            zom = e.zoom.ToString();
            GLatLng ubicacion1 = new GLatLng(e.point.lat, e.point.lng);
            txtBillingLatitud.Text = lat;
            txtBillingLongitud.Text = lng;
            Gmap1.setCenter(ubicacion1, e.zoom);
            //Gmap2.Height = 300;
            //Gmap2.Width = 480;
            Gmap1.Add(new GControl(GControl.preBuilt.LargeMapControl));
            //Gmap2.addControl(new GControl(GControl.preBuilt.LargeMapControl));
            Gmap1.Add(new GControl(GControl.preBuilt.MapTypeControl));
            //Gmap2.addControl(new GControl(GControl.preBuilt.MapTypeControl));
            Gmap1.enableHookMouseWheelToZoom = true;
            //Gmap2.enableScrollWheelZoom = true;
            GMarker mark1 = new GMarker(ubicacion1);
            Gmap1.Add(mark1);
            //Gmap2.addGMarker(mark);
            Gmap1.mapType = GMapType.GTypes.Satellite;
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
            return Gmap1.ToString();
        }

        protected string Gmap2_Click(object s, Subgurim.Controles.GAjaxServerEventArgs e)
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
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
            return Gmap2.ToString();
        }

        
    }
}