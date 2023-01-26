using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class solicitudes_gerencial : System.Web.UI.Page
    {
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
                        lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                        //lblCodCliente.Text = Session["COD_CLIENTE"].ToString();
                        //lblCodSolicitud.Text = Session["COD_SOLICITUD"].ToString();
                        lblUsuario.Text = Session["usuario"].ToString();
                        MultiView1.ActiveViewIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_solicitudes_gerencial_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                    string directorio2 = Server.MapPath("~/Logs");
                    StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                    writer5.WriteLine(ex.ToString());
                    writer5.Close();
                    lblAviso.Text = "Las variables de session caducaron.";
                }

                //var plazo=dominio.VerificarPlazo(1);


            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {

            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            lblCodSolicitudDetalle.Text = id;
            lblTipoAccion.Text = "APR";
            MultiView1.ActiveViewIndex = 1;
            odsFormularioDinamico.DataBind();
            Repeater2.DataBind();
            //DataTable dt = new DataTable();
            //dt = Clases.solicitudes.GET_DAD_SOLICITUDES_DETALLE("SDE-7", "APR", "gzalles", "");
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string dato = dr["denominacion"].ToString();

            //}

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                string[] datos = obj.CommandArgument.ToString().Split('|');
                Session["COD_SOLICITUD_DETALLE"] = datos[1];
                lblCodSolicitudDetalle.Text = datos[1];
                Session["COD_SOLICITUD"] = datos[0];
                Session["COD_CLIENTE"] = datos[2];
                Session["TIPO_CLIENTE"] = datos[3];
                Response.Redirect("solicitudes_admin.aspx?RME=" + lblCodMenuRol.Text,false);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_gerencial_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Las variables de session caducaron.";
            }

        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            lblCodSolicitudDetalle.Text = id;
            lblTipoAccion.Text = "REC";
            MultiView1.ActiveViewIndex = 1;
            odsFormularioDinamico.DataBind();
            Repeater2.DataBind();
        }

        protected void btnVolverDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                Session["COD_CLIENTE"] = lblCodCliente.Text;
                if (Session["TIPO_CLIENTE"].ToString() == "")
                { Response.Redirect("solicitudes_gerencial.aspx?RME=" + lblCodMenuRol.Text); }
                else
                { Response.Redirect("solicitudes.aspx"); }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_gerencial_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Las variables de session caducaron.";
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] datos1 = { "" };
                foreach (RepeaterItem item in Repeater2.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var fileupload = (FileUpload)item.FindControl("FileUpload1");
                        if (fileupload.HasFile)
                        {
                            string archivo = fileupload.FileName;
                            string Ruta = Server.MapPath("~/uploads/" + lblCodSolicitudDetalle.Text + "/");
                            if (!Directory.Exists(Ruta))
                            {
                                Directory.CreateDirectory(Ruta);


                            }

                            fileupload.PostedFile.SaveAs(Ruta + archivo);
                            Clases.solicitudes_detalle obj_c1 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, fileupload.ToolTip, fileupload.FileName, lblUsuario.Text);
                            datos1 = obj_c1.ABM().Split('|');
                        }

                        var texto = (TextBox)item.FindControl("TextBox1");
                        if (texto.Text != "")
                        {
                            Clases.solicitudes_detalle obj_c2 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, texto.ToolTip, texto.Text, lblUsuario.Text);
                            datos1 = obj_c2.ABM().Split('|');
                        }


                        var dropdownlist = (DropDownList)item.FindControl("DropDownList1");
                        if (dropdownlist.Items.Count > 0)
                        {
                            string combito = dropdownlist.SelectedValue;
                            Clases.solicitudes_detalle obj_c2 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, dropdownlist.ToolTip, combito, lblUsuario.Text);
                            datos1 = obj_c2.ABM().Split('|');
                        }


                    }
                }


                string email = datos1[0];
                string cuerpo = datos1[1];
                if (email != "")
                {


                    Clases.enviar_correo objC = new Clases.enviar_correo();
                    string resp_email = objC.enviar(email, "Confirmacion de requisitos", cuerpo, "");
                }

                Repeater1.DataBind();
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_gerencial_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Las variables de session caducaron.";
            }


        }

        protected void btnCancelarForm_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnVolverConsulta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();

                string pageurl = System.Configuration.ConfigurationManager.AppSettings["dominio"].ToString() + "/uploads/" + lblCodSolicitudDetalle.Text + "/" + id;
                //Response.Redirect(pageurl);
                Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_gerencial_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Las variables de session caducaron.";
            }


        }

        protected void Repeater2_DataBinding(object sender, EventArgs e)
        {

        }
    }
}