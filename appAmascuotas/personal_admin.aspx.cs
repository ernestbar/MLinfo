using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class personal_admin : System.Web.UI.Page
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
                    btnNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["DESCRIPCION"].ToString().ToUpper() == "NEW")
                                btnNuevo.Visible = true;
                        }

                    }
                    MultiView1.ActiveViewIndex = 0;

                }

            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                Button bEdit = (Button)e.Item.FindControl("btnEditar");
                Button bUsuarios = (Button)e.Item.FindControl("btnUsuarios");
                bEdit.Visible = false;
                bUsuarios.Visible = false;
                bEliminar.Visible = false;
                DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDIT")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "USERS")
                            bUsuarios.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "DELETE")
                            bEliminar.Visible = true;
                    }

                }


            }
        }
        public void limpiar_controles()
        {
            lblAviso.Text = "";
            lblCodPersonal.Text = "";
            txtEmail.Text = "";
            txtNombres.Text = "";
            txtNumeroDocumento.Text = "";
            lblFechaDesde.Text = "";
            lblFechaHasta.Text = "";
            ddlExpedido.DataBind();
            ddlTipoDocumento.DataBind();
            ddlCargo.DataBind();
            ddlSupervisor.DataBind();

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            txtEmail.Enabled = true;
            MultiView1.ActiveViewIndex = 1;

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 1;
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodPersonal.Text = id;
                Clases.Usuarios cli = new Clases.Usuarios("",lblCodPersonal.Text);
                txtCelular.Text = cli.PN_CELULAR.ToString();
                txtEmail.Text = cli.PV_EMAIL;
                txtNombres.Text = cli.PV_NOMBRE_COMPLETO;
                txtNumeroDocumento.Text = cli.PV_NUMERO_DOCUMENTO;
                txtFijo.Text = cli.PN_FIJO.ToString();
                txtInterno.Text = cli.PN_INTERNO.ToString();
                ddlExpedido.DataBind();
                ddlExpedido.SelectedValue = cli.PV_EXPEDIDO.ToString();
                ddlCargo.DataBind();
                ddlCargo.SelectedValue = cli.PV_COD_CARGO;
                ddlSucursal.DataBind();
                ddlSucursal.SelectedValue = cli.PV_COD_SUCURSAL;
                ddlTipoDocumento.DataBind();
                ddlTipoDocumento.SelectedValue = cli.PV_TIPO_DOCUMENTO;
                txtEmail.Enabled = false;
                DataTable dt = new DataTable();
                dt = Clases.Usuarios.PR_PAR_GET_USUARIOS(lblCodPersonal.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblCodUsuarioI.Text = dr["usuario"].ToString();
                        txtDescripcion.Text = dr["descripcion"].ToString();
                        lblFechaDesde.Text = dr["fecha_desde"].ToString();
                        lblFechaHasta.Text = dr["fecha_hasta"].ToString();
                        ddlRol.SelectedValue = dr["rol"].ToString();
                        if (dr["fecha_desde"].ToString() == "")
                        {
                            DateTime fecha1 = DateTime.Now;
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
                        else
                        {
                            DateTime fecha1 = DateTime.Parse(dr["fecha_desde"].ToString());
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
                        if (dr["fecha_hasta"].ToString() != "")
                        {
                            DateTime fecha2 = DateTime.Parse(dr["fecha_hasta"].ToString());
                            string dia = "";
                            string mes = "";
                            if (fecha2.Day.ToString().Length == 1)
                                dia = "0" + fecha2.Day.ToString();
                            else
                                dia = fecha2.Day.ToString();

                            if (fecha2.Month.ToString().Length == 1)
                                mes = "0" + fecha2.Month.ToString();
                            else
                                mes = fecha2.Month.ToString();
                            hfFechaRetorno.Value = fecha2.Year.ToString() + "-" + mes + "-" + dia;
                            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta2", "setearFechaRetorno();", true);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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

                string[] dat = id.Split('|');
                if (dat[1] == "ACTIVE")
                {
                    Clases.Usuarios cli = new Clases.Usuarios("D", dat[0], "","","","","","","",0,0,0,"","","","","",DateTime.Now,DateTime.Now,"", lblUsuario.Text);
                    lblAviso.Text = cli.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", ""); ;
                }
                else
                {
                    Clases.Usuarios cli = new Clases.Usuarios("A", dat[0], "", "", "", "", "", "", "", 0, 0, 0, "", "", "", "", "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                    lblAviso.Text = cli.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", ""); ;
                }
                
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }


        }

        protected void ddlExpedido_DataBound(object sender, EventArgs e)
        {
            ddlExpedido.Items.Insert(0, "SELECT");
        }

        

        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipoDocumento.Items.Insert(0, "SELECT");
        }
        public bool IsDate(object inValue)
        {
            bool bValid;
            try
            {
                DateTime myDT = DateTime.Parse(inValue.ToString());
                bValid = true;
            }
            catch (Exception e)
            {
                bValid = false;
            }

            return bValid;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //string s;
                //string fecha = "";
                //s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                string fecha_retorno = "01/01/3000";
                if (hfFechaRetorno.Value != "")
                    fecha_retorno = hfFechaRetorno.Value;
                string fecha_salida = "01/01/3000";
                if (hfFechaSalida.Value != "")
                    fecha_salida = hfFechaSalida.Value;
                string interno= "";
                string fijo= "";

                if (txtInterno.Text == "")
                    interno = "0";
                if (txtFijo.Text == "")
                    fijo = "0";
                string[] datos_cargo = ddlCargo.SelectedValue.Split('&');
                string aux = "";
                if (lblCodPersonal.Text == "")
                {
                    Clases.Usuarios per = new Clases.Usuarios("I","",ddlSupervisor.SelectedValue,ddlSucursal.SelectedValue, txtNombres.Text,
                        ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text, ddlExpedido.SelectedValue,
                        ddlCargo.SelectedValue,int.Parse(txtCelular.Text),int.Parse(fijo),int.Parse(interno),
                        txtEmail.Text,txtEmail.Text,"","", txtDescripcion.Text, DateTime.Parse(fecha_salida), DateTime.Parse(fecha_retorno), ddlRol.SelectedValue,lblUsuario.Text);
                    string[] datos = per.ABM().Split('|');
                    aux = datos[2];
                    Clases.enviar_correo objC = new Clases.enviar_correo();
                    string resultado2 = objC.enviar(txtEmail.Text, "Register user " + txtEmail.Text, " Welcome dear user:" + txtEmail.Text + "<br/><br/>"+datos[2]+"<br/><br/>" + " <br/><br/> You must login in the following link: <br/><br/>" + "https://200.105.209.42:5560" + "<br/><br/>Regards.", "");
                    lblAviso.Text = aux + " - We send you an email with your temporary password to enter.";
                }
                else
                {
                    Clases.Usuarios per = new Clases.Usuarios("U", lblCodPersonal.Text, ddlSupervisor.SelectedValue, ddlSucursal.SelectedValue, txtNombres.Text,
                        ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text, ddlExpedido.SelectedValue,
                        ddlCargo.SelectedValue, int.Parse(txtCelular.Text), int.Parse(fijo), int.Parse(interno),
                        txtEmail.Text, txtEmail.Text, "", "", txtDescripcion.Text, DateTime.Parse(fecha_salida), DateTime.Parse(fecha_retorno), ddlRol.SelectedValue, lblUsuario.Text);
                    aux = per.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    lblAviso.Text = aux;
                }
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }

        protected void btnVolverAlta_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 0;
            limpiar_controles();
        }

       
      

       
        protected void ddlCargo_DataBound(object sender, EventArgs e)
        {
            ddlCargo.Items.Insert(0, "SELECT");
        }

        

        
        protected void ddlSupervisor_DataBound(object sender, EventArgs e)
        {
            ddlSupervisor.Items.Insert(0, "SELECT");
        }

        protected void ddlSucursal_DataBound(object sender, EventArgs e)
        {
            ddlSucursal.Items.Insert(0, "SELECT");
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodPersonal.Text = id;
                MultiView1.ActiveViewIndex = 2;
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }

        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Clases.Usuarios per = new Clases.Usuarios("R", "","", "", "","", "", "","", 0, 0, 0,
                        "", id, "", "", "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                string[] datos = per.ABM().Split('|');
                Clases.enviar_correo objC = new Clases.enviar_correo();
                string resultado2 = objC.enviar(id, "Reset password from user " + id, " Dear user:" + "<br/><br/>" + datos[2] + "<br/><br/>" + " <br/><br/> Now login with the link: <br/><br/>" + "https://200.105.209.42:5560" + "<br/><br/> Regards.", "");
                if (resultado2 == "OK")
                    lblAviso.Text = "We send an email with your temporary password.";
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }

        protected void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodUsuarioI.Text = id;
                MultiView1.ActiveViewIndex = 3;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }

       
        protected void btnGuardar2_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.Usuarios per = new Clases.Usuarios("C", "", "", "", "", "", "", "", "", 0, 0, 0,
                       "", lblCodUsuarioI.Text, txtPassword.Text, txtPasswordAnterior.Text, "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                lblAviso.Text = per.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                MultiView1.ActiveViewIndex = 2;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
            
        }

        protected void btnCancelar2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPasswordAnterior.Text = "";
            lblCodUsuarioI.Text = "";
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bRestear = (Button)e.Item.FindControl("btnResetear");
                Button bCambiarPassword = (Button)e.Item.FindControl("btnCambiarPassword");
                bRestear.Visible = false;
                bCambiarPassword.Visible = false;
                DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "RESET")
                            bRestear.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "CHANGE")
                            bCambiarPassword.Visible = true;
                        
                    }

                }


            }
        }

        protected void ddlRol_DataBound(object sender, EventArgs e)
        {
            ddlRol.Items.Insert(0, "SELECT");
        }

        protected void btnVolverUser_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 0;
        }
    }
}