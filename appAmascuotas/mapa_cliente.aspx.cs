using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;

namespace appAmascuotas
{
    public partial class mapa_cliente : System.Web.UI.Page
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
                    string lat = Session["lat"].ToString();
                    string lon = Session["lon"].ToString();
                    if (lat != "")
                        inciar_mapa3(lat, lon);
                }
            }
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
    }
}