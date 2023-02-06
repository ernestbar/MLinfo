using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
namespace appAmascuotas
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    txtUsuario.Focus();
                    lblAviso.Text = "";
                    //string path = Server.MapPath("~/wkhtmltopdf/wkhtmltopdf.exe");
                    //string ruta_Archivo = Server.MapPath("~/Reportes/Seguro");


                    //ProcessStartInfo oProcessStarInfo = new ProcessStartInfo();
                    //oProcessStarInfo.UseShellExecute = false;
                    //oProcessStarInfo.FileName = path;
                    //oProcessStarInfo.Arguments = ruta_Archivo + "\\seguro1.aspx " + ruta_Archivo + "\\mipdf2.pdf";
                    ////oProcessStarInfo.Arguments = ruta_Archivo + "http://hdeleon.net/ "+ ruta_Archivo+ "\\mipdf.pdf";

                    //using (Process oProcess = Process.Start(oProcessStarInfo))
                    //{
                    //    oProcess.WaitForExit();

                    //}

                    //Console.WriteLine("pdf creado");
                    //Console.Read(); }
                }
                catch (Exception ex)
                {
                    string aux = ex.ToString();
                }
                
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string[] datos= Clases.Usuarios.Ingreso_usuario(txtUsuario.Text, txtPassword.Text).Split('|');
            if (datos[0] == "0")
            {
                if (datos[3] == "1")
                {
                    Session["usuario"] = txtUsuario.Text;
                    Response.Redirect("cambio_password.aspx?tmp=1");
                    Session["documento"] = "sin_imagen";
                    lblAviso.Text = "";
                }
                else
                {
                    Session["usuario"] = txtUsuario.Text;
                    Session["documento"] = datos[2];
                    Response.Redirect("dashboard.aspx");
                    lblAviso.Text = "";
                }
                //Clases.enviar_correo objC = new Clases.enviar_correo();
                //string resp_email = objC.enviar("ernesto.barron@gmail.com", "Confirmacion de requisitos", "Pruebas de envio de correo.", "");
            }
            else
            { lblAviso.Text = "User or password wrong!"; txtUsuario.Focus(); }
            
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clases.Usuarios per = new Clases.Usuarios("R", "", "", "", "", "", "", "", "", 0, 0, 0,
                       "", txtUsuario.Text, "", "", "", DateTime.Now, DateTime.Now, "", txtUsuario.Text);
            string[] datos = per.ABM().Split('|');
            lblAviso.Text = datos[2];
            if (datos[1] == "0")
            {
                Clases.enviar_correo objC = new Clases.enviar_correo();
                string resultado2 = objC.enviar(txtUsuario.Text, "Reset password from user " + txtUsuario.Text, " Dear user:" + "<br/><br/>"+ datos[2]  +" <br/><br/>" + " <br/><br/> Now login with the link: <br/><br/>" + "https://200.105.209.42:5560" + "<br/><br/> Regards.", "");
                lblAviso.Text = "We send you an email with your temporary password to enter, thank you very much!!!!";
            }
            else
            {
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
            
        }
    }
}