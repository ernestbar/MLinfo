using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;

namespace appAmascuotas.Clases
{
    public class enviar_correo
    {
        public string enviar(string Email, string subjet, string mensaje, string adjunto)
        {
            string resultado = "";
            try
            {
                //var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                //string strHost = smtpSection.Network.Host;
                //int port = smtpSection.Network.Port;
                //string strUserName = smtpSection.Network.UserName;
                //string strFromPass = smtpSection.Network.Password;

                string strHost = "";
                int port = 0;
                string strUserName = "";
                string strFromPass = "";
                string strFromName = "";
                DataTable dt = new DataTable();
                dt = Clases.Dominios.PR_PAR_GET_DOMINIOS("SMTP");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["codigo"].ToString() == "HOST")
                        strHost = dr["descripcion"].ToString();
                    if (dr["codigo"].ToString() == "PORT")
                        port =int.Parse(dr["descripcion"].ToString());
                    if (dr["codigo"].ToString() == "USERNAME")
                        strUserName = dr["descripcion"].ToString();
                    if (dr["codigo"].ToString() == "PASSWORD")
                        strFromPass = dr["descripcion"].ToString();
                    if (dr["codigo"].ToString() == "FROM")
                        strFromName = dr["descripcion"].ToString();
                }
                
                SmtpClient smtp = new SmtpClient(strHost, port);
                NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
                smtp.Credentials = cert;
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage(strFromName, Email);
                msg.Subject = subjet;
                msg.IsBodyHtml = true;
                msg.Body = mensaje;
                smtp.Send(msg);
                resultado = "OK";
                return resultado;
            }
            catch (Exception ex)
            {
                resultado = ex.ToString();
                return resultado;
            }

        }
    }
}