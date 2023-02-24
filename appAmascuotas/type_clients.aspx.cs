using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class type_clients : System.Web.UI.Page
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



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIdTypeCliente.Text=="")
                {
                    Clases.Client_types obj = new Clases.Client_types("I",txtClientTypeCode.Text,txtDescripcion.Text, decimal.Parse(txtHourlyDate.Text.Replace(".", ",")), decimal.Parse(txtTravelFee.Text.Replace(".", ","))
                        , decimal.Parse(txtRemind1.Text.Replace(".", ",")), decimal.Parse(txtRemind2.Text.Replace(".", ",")), decimal.Parse(txtRemind3.Text.Replace(".", ",")), decimal.Parse(txtRateLate.Text.Replace(".", ",")), lblUsuario.Text);
                    lblAviso.Text = obj.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Client_types obj = new Clases.Client_types("U", lblIdTypeCliente.Text, txtDescripcion.Text, decimal.Parse(txtHourlyDate.Text.Replace(".", ",")), decimal.Parse(txtTravelFee.Text.Replace(".", ","))
                        , decimal.Parse(txtRemind1.Text.Replace(".", ",")), decimal.Parse(txtRemind2.Text.Replace(".", ",")), decimal.Parse(txtRemind3.Text.Replace(".", ",")), decimal.Parse(txtRateLate.Text.Replace(".", ",")), lblUsuario.Text);
                    lblAviso.Text = obj.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_type_clients_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
            lblIdTypeCliente.Text = "";
            txtClientTypeCode.Enabled = true;
            MultiView1.ActiveViewIndex = 1;

        }
        public void limpiar()
        {
            txtClientTypeCode.Text = "";
            txtDescripcion.Text = "";
            txtHourlyDate.Text = "0";
            txtRateLate.Text = "0";
            txtRemind1.Text = "0";
            txtRemind2.Text = "0";
            txtRemind3.Text = "0";
            txtTravelFee.Text = "0";
            txtClientTypeCode.Focus();
            lblAviso.Text = "";
            lblIdTypeCliente.Text = "";
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblIdTypeCliente.Text = id;
                Clases.Client_types obj_m = new Clases.Client_types(id);
                txtClientTypeCode.Text = id;
                txtClientTypeCode.Enabled = false;
                txtDescripcion.Text = obj_m.PV_DESCRIPTION;
                txtHourlyDate.Text = obj_m.PD_HOURLY_RATE.ToString().Replace(",", ".");
                txtRateLate.Text = obj_m.PD_RATE_LATE_PAYMENT.ToString().Replace(",", ".");
                txtRemind1.Text = obj_m.PD_REMINDER_FEE_FIRST.ToString().Replace(",", ".");
                txtRemind2.Text = obj_m.PD_REMINDER_FEE_SECOND.ToString().Replace(",", ".");
                txtRemind3.Text = obj_m.PD_REMINDER_FEE_THIRD.ToString().Replace(",", ".");
                txtTravelFee.Text = obj_m.PD_TRAVEL_FEE.ToString().Replace(",", ".");
                txtDescripcion.Focus();
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_type_clients_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblIdTypeCliente.Text = datos[0];
                if (datos[1] == "ACTIVE")
                {
                    Clases.Client_types obj_m = new Clases.Client_types("D", lblIdTypeCliente.Text, "",0,0,0,0,0,0, lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                }
                else
                {
                    Clases.Client_types obj_m = new Clases.Client_types("A", lblIdTypeCliente.Text, "", 0, 0, 0, 0, 0, 0, lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                }

                Repeater1.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_type_clients_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                Button bEdit = (Button)e.Item.FindControl("btnEditar");
                Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                Button bHistory = (Button)e.Item.FindControl("btnHistory");
                bEdit.Visible = false;
                bEliminar.Visible = false;
                bHistory.Visible = false;
                DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDIT")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "DELETE")
                            bEliminar.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "HISTORICAL")
                            bHistory.Visible = true;
                    }

                }


            }
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            lblIdTypeCliente.Text = id;
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnVolverUser_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 0;
        }
    }
}