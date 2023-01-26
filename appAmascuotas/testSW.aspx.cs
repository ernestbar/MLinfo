using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class testSW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //NameValueCollection _params = new NameValueCollection();

            //_params.Add("Request[title]", "");
            //_params.Add("Request[Usuario]", "048640668dbfd7f0686cd70a895cd9fa");
            //_params.Add("Request[Clave]", "ee2ec3cc66427bb422894495068222a8");
            //_params.Add("Request[id_reserva]", "46LQJH");


            //string sPostURL = "https://reservas2.amaszonas.com/servicioAmascotas/datosReserva.php";

            //var wbClient = new System.Net.WebClient();

            //wbClient.Headers.Add("Content-Type", "application/form-data");


            //var response = wbClient.UploadValues(sPostURL, "Post", _params);
            //DBApi obj = new DBApi();

            //Datos11 datos1 = new Datos11
            //{
            //    Usuario = "048640668dbfd7f0686cd70a895cd9fa",
            //    Clave = "ee2ec3cc66427bb422894495068222a8",
            //    id_reserva = "46LQJH"
            //};
            //string json = JsonConvert.SerializeObject(datos1);
            //dynamic respuesta = obj.Post("https://reservas2.amaszonas.com/servicioAmascotas/datosReserva.php", json, null);

            //string respuestaJson = respuesta.ToString();

            var request = (HttpWebRequest)WebRequest.Create("https://reservas2.amaszonas.com/servicioAmascotas/datosReserva.php");

            var postData = "Usuario=048640668dbfd7f0686cd70a895cd9fa";
            postData += "&Clave=ee2ec3cc66427bb422894495068222a8";
            postData += "&id_reserva="+txtCodigoReserva.Text;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            string respuestaJson = responseString.ToString();
            lblResultado.Text = responseString.ToString();
            Clases.Reservas reserva = new Clases.Reservas();

            reserva = JsonConvert.DeserializeObject<Clases.Reservas>(respuestaJson);
        }

     
    }

    public class Datos11
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string id_reserva { get; set; }
    }
}