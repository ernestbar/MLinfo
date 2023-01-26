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
    public partial class solicitudes : System.Web.UI.Page
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
                        lblCodCliente.Text = Session["COD_CLIENTE"].ToString();
                        lblTipoCliente.Text = Session["TIPO_CLIENTE"].ToString();
                        odsSolicitudCliente.DataBind();
                        Repeater1.DataBind();
                        MultiView1.ActiveViewIndex = 0;
                        lblUsuario.Text = Session["usuario"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_juridica_wiz_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                    string directorio2 = Server.MapPath("~/Logs");
                    StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                    writer5.WriteLine(ex.ToString());
                    writer5.Close();
                    lblAviso.Text = "Las variables de session caducaron.";
                }


            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                lblPorcentaje.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodSolicitud.Text = id;

                Clases.solicitudes obj_s = new Clases.solicitudes(id);
                if (obj_s.PV_ESTADO == "PEN")
                {
                    MultiView1.ActiveViewIndex = 1;
                    ddlRuta1.DataBind();
                    ddlRuta2.DataBind();
                    ddlRuta1.SelectedValue = obj_s.PV_RUTA_ORIGEN;
                    ddlRuta2.SelectedValue = obj_s.PV_RUTA_DESTINO;
                    rblTipoRuta.SelectedValue = obj_s.PV_TIPO_RUTA;
                    txtCantPasajes.Text = obj_s.PI_CANT_PASAJES.ToString();
                    txtCuotaInicial.Text = obj_s.PD_CUOTA_INICIAL.ToString();
                    txtMontoFinanciar.Text = obj_s.PD_MONTO_FINANCIADO.ToString();
                    txtMontoTotal.Text = (obj_s.PD_MONTO_FINANCIADO + obj_s.PD_CUOTA_INICIAL).ToString();
                    txtObservacopmes.Text = obj_s.PV_OBSERVACION;
                    txtPlazoMeses.Text = obj_s.PI_PLAZO_MES.ToString();
                }
                else
                {
                    lblAviso.Text = "El estado del registro no es PENDIENTE no se puede editar.";
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            lblCodSolicitud.Text = id;
            MultiView1.ActiveViewIndex = 2;
            

        }

        protected void btnVolverDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTipoCliente.Text == "N")
                    Response.Redirect("natural_wiz.aspx?RME="+ lblCodMenuRol.Text);
                else
                    Response.Redirect("juridica_wiz.aspx?RME=" + lblCodMenuRol.Text);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.solicitudes obk_sol = new Clases.solicitudes("U", lblCodSolicitud.Text, ddlRuta1.SelectedValue, ddlRuta2.SelectedValue, rblTipoRuta.SelectedValue,
                             int.Parse(txtCantPasajes.Text), decimal.Parse(txtMontoTotal.Text), decimal.Parse(txtCuotaInicial.Text), decimal.Parse(txtMontoFinanciar.Text),
                             int.Parse(txtPlazoMeses.Text), txtObservacopmes.Text,
                             lblCodCliente.Text, "", "admin");
                obk_sol.ABM();
                Repeater1.DataBind();
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }

        protected void ddlRuta1_DataBound(object sender, EventArgs e)
        {
            ddlRuta1.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlRuta2_DataBound(object sender, EventArgs e)
        {
            ddlRuta2.Items.Insert(0, "SELECCIONAR");
        }

        protected void txtCuotaInicial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal porcentaje = 0;
                if (txtMontoTotal.Text == "")
                {
                    lblPorcentaje.Text = "Debe colocar el monto a financiar.";
                }
                else
                {
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
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            try
            {
                Clases.solicitudes obj_d = new Clases.solicitudes("D", lblCodSolicitud.Text, "", "", "", 0, 0, 0, 0, 0, "", "", txtMotivo1.Text, "admin");
                obj_d.ABM();
                Repeater1.DataBind();
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnVolverEdit_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnVolverEliminar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodSolicitud.Text = id;
                Clases.solicitudes obj_d = new Clases.solicitudes("S", lblCodSolicitud.Text, "", "", "", 0, 0, 0, 0, 0, "", "", "", lblUsuario.Text);
                string resultado = obj_d.ABM();
                Repeater1.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

            //MultiView1.ActiveViewIndex = 2;
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodSolicitud.Text = id;
                Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
                Response.Redirect("solicitudes_admin.aspx?RME=" + lblCodMenuRol.Text);
            }
            catch
            { lblAviso.Text = "Las variables de session caducaron."; }
            
        }

        protected void btnFormulario_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Session["COD_SOLICITUD"] = id;
                if (lblTipoCliente.Text == "J")
                { Response.Redirect("reporteFormJuridica.aspx?reimprimir=SI"); }
                else
                { Response.Redirect("reporteFormNatural.aspx?reimprimir=SI"); }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnDocumentos_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Session["COD_SOLICITUD"] = id;
                Response.Redirect("imprimir_documentos.aspx");
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }
    }
}