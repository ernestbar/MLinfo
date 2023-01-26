using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;

namespace appAmascuotas
{
    /// <summary>
    /// Descripción breve de Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["amaszonasConn"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select numero_documento, cod_cliente from cli_clientes where tipo_cliente='02' and numero_documento like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}|{1}", sdr["numero_documento"], sdr["cod_cliente"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCustomersName(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["amaszonasConn"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select (rtrim(isnull(APELLIDO_PATERNO,'')) + ' ' + rtrim(isnull(APELLIDO_MATERNO,'')) + ' ' + rtrim(isnull(APELLIDO_MARITAL,'')) + ' ' + rtrim(isnull(NOMBRE,'')) + ' ' + rtrim(isnull(SEGUNDO_NOMBRE,'')) + ' ' + rtrim(isnull(TERCER_NOMBRE,''))) as nombre, cod_cliente from cli_clientes where tipo_cliente='02' and (rtrim(isnull(APELLIDO_PATERNO,'')) + ' ' + rtrim(isnull(APELLIDO_MATERNO,'')) + ' ' + rtrim(isnull(APELLIDO_MARITAL,'')) + ' ' + rtrim(isnull(NOMBRE,'')) + ' ' + rtrim(isnull(SEGUNDO_NOMBRE,'')) + ' ' + rtrim(isnull(TERCER_NOMBRE,''))) like '%' + + @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}|{1}", sdr["nombre"], sdr["cod_cliente"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCustomersJ(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["amaszonasConn"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select numero_documento, cod_cliente from cli_clientes where tipo_cliente='01' and numero_documento like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}|{1}", sdr["numero_documento"], sdr["cod_cliente"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCustomersJName(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["amaszonasConn"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select RAZON_SOCIAL, cod_cliente from cli_clientes where tipo_cliente='01' and RAZON_SOCIAL like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}|{1}", sdr["RAZON_SOCIAL"], sdr["cod_cliente"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }

    }
}
