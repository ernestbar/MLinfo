using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using System.Web.Script.Serialization;

namespace appAmascuotas
{
    public partial class vuelos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargar_calendarios();
                MultiView1.ActiveViewIndex = 0;

            }
        }

        public static string Base64Encode(string textToEncode)
        {
            byte[] textAsBytes = Encoding.UTF8.GetBytes(textToEncode);
            return Convert.ToBase64String(textAsBytes);
        }
        public void cargar_calendarios()
        {
            int d = 1;
            for (d = 1; d <= 31; d++)
            {
                ListItem dia = new ListItem();
                dia.Text = d.ToString();
                dia.Value = d.ToString();
                // ddlGarDia.Items.Add(dia);
                ddlDia.Items.Add(dia);
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
                ddlMes.Items.Add(mes);
            }
            int a = 2020;
            for (a = 2020; a <= DateTime.Now.Year; a++)
            {
                ListItem anio = new ListItem();
                anio.Text = a.ToString();
                anio.Value = a.ToString();
                // ddlGarAño.Items.Add(anio);
                ddlAño.Items.Add(anio);
            }
            ddlDia.Items.Insert(0, "DIA");
            ddlMes.Items.Insert(0, "MES");
            ddlAño.Items.Insert(0, "AÑO");


        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            DBApi obj = new DBApi();
            string fecha_vuelo1 = ddlAño.SelectedValue;
            if (ddlMes.SelectedValue.Length == 1)
                fecha_vuelo1 = fecha_vuelo1 + "-0" + ddlMes.SelectedValue;
            else
                fecha_vuelo1 = fecha_vuelo1 + "-" + ddlMes.SelectedValue;
            if (ddlDia.SelectedValue.Length == 1)
                fecha_vuelo1 = fecha_vuelo1 + "-0" + ddlDia.SelectedValue;
            else
                fecha_vuelo1 = fecha_vuelo1 + "-" + ddlDia.SelectedValue;

            Datos datos = new Datos
            {
                adultos = txtAdultos.Text,
                infante = txtInfante.Text,
                menor = 0,
                origen = "LPB",
                destino = "SRE",
                fecha_vuelo = fecha_vuelo1,
                tipo_busqueda = rblTipoRuta.SelectedValue
            };

            //string json = "{\"adultos\":\"" + txtAdultos.Text + "\",\"infante\":\"" + txtInfante.Text + "\",\"menor\":0,\"origen\":\"LPB\",\"destino\":\"SRE\",\"fecha_vuelo\":\"" + fecha_vuelo + "\",\"tipo_busqueda\":\"" + rblTipoRuta.SelectedValue + "\"}";
            string json = JsonConvert.SerializeObject(datos);
            dynamic respuesta = obj.Post("https://reservas2.amaszonas.com/servicio_a1z8/GetDisponibilidad.php", json, "Basic MDQ4NjQwNjY4ZGJmZDdmMDY4NmNkNzBhODk1Y2Q5ZmE6ZWUyZWMzY2M2NjQyN2JiNDIyODk0NDk1MDY4MjIyYTg=");

   

            string respuestaJson = respuesta.ToString();
            Test xxx = new Test();

            //IEnumerable<Test> result = JsonConvert.DeserializeObject<IEnumerable<Test>>(respuestaJson);
            xxx = JsonConvert.DeserializeObject<Test>(respuestaJson);

            //JavaScriptSerializer oJS = new JavaScriptSerializer();
            //Test oRootObject = new Test();
            //oRootObject = oJS.Deserialize<Test>(respuestaJson);

            // string error = Test1.error;
            //int i= 0;
            //foreach (var dat in Test1.datos)
            //{
            //    string jsonDatos = dat.MONTO_TOTAL;

            //}

            //List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);
            //string aux = respuesta.ToString();
            //List<Test> test1 = JsonConvert.DeserializeObject<List<Test>>(aux);
            //Test prueba = respuesta.Par;
        }
        
    }
}

public class Test
{
    public string error { get; set; }
    //public IList<string> datos { get; set; }
    public List<Disponibles> datos { get; set; }



}
public class Disponibles
{
    public int estado { get; set; }
    public string MONTO_TOTAL { get; set; }
    public string clase { get; set; }
    public string moneda { get; set; }
    //public IList<Segmentos1> SEGMENTOS { get; set; }
    public List<Segmentos1> SEGMENTOS { get; set; }
    public class Segmentos1
    {
        public string hora_partida { get; set; }
        public string hora_llegada { get; set; }
        public string fecha_partida { get; set; }
        public string fecha_llegada { get; set; }
        public string escalas { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string numero_vuelo { get; set; }
        public string duracion { get; set; }
        public string aeronave { get; set; }
        public string carrier { get; set; }

    }
}
public class Datos
{
    public string adultos { get; set; }
    public string infante { get; set; }

    public int menor { get; set; }

    public string origen { get; set; }
    public string destino { get; set; }

    public string fecha_vuelo { get; set; }

    public string tipo_busqueda { get; set; }

}