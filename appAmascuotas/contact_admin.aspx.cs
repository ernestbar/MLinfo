using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;
using System.Data;
using System.IO;
using System.Text;

namespace appAmascuotas
{
    public partial class contact_admin : System.Web.UI.Page
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
                    if (Session["id_cliente"] == null)
                    {
                        if (ddlCliente.SelectedValue == "SELECT")
                        {
                            lblIdCliente.Text = "0";
                        }
                        else
                        {
                            lblIdCliente.Text = ddlCliente.SelectedValue;
                        }
                    }
                    else
                    {
                        lblIdCliente.Text = Session["id_cliente"].ToString();
                        ddlCliente.SelectedValue= Session["id_cliente"].ToString();
                    }
                    
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
                

                if (lblIdContact.Text == "")
                {
                    Clases.Contacts obj = new Clases.Contacts("I", 0,long.Parse(ddlCliente.SelectedValue),  txtName.Text, txtSurname.Text, txtEmail.Text, long.Parse(txtPhone.Text),
                        long.Parse(txtMobile.Text), txtComments.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Contacts obj = new Clases.Contacts("U", long.Parse(lblIdContact.Text), long.Parse(ddlCliente.SelectedValue), txtName.Text, txtSurname.Text, txtEmail.Text, long.Parse(txtPhone.Text),
                        long.Parse(txtMobile.Text), txtComments.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_contacts_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
            lblIdContact.Text = "";
            lblIdCliente.Text = ddlCliente.SelectedValue;
            txtCliente.Text = ddlCliente.SelectedItem.Text;
            MultiView1.ActiveViewIndex = 1;

        }
        public void limpiar()
        {
            lblIdCliente.Text = "";
            lblIdContact.Text = "";
            txtComments.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtSurname.Text = "";
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblIdContact.Text = id;
                Clases.Contacts obj_m = new Clases.Contacts(long.Parse(id));
                lblIdCliente.Text = obj_m.PB_ID_CLIENT.ToString();
                txtComments.Text = obj_m.PV_COMMENTS;
                txtEmail.Text = obj_m.PV_EMAIL;
                txtMobile.Text = obj_m.PB_MOBILE.ToString();
                txtName.Text = obj_m.PV_NAME;
                txtPhone.Text = obj_m.PB_PHONE.ToString();
                txtSurname.Text = obj_m.PV_SURNAMES;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_contacts_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblIdContact.Text = datos[0];
                if (datos[1] == "ACTIVE")
                {
                    Clases.Contacts obj1 = new Clases.Contacts("D", long.Parse(lblIdContact.Text),0, "","","",0,
                         0, "", lblUsuario.Text);
                    lblAviso.Text = obj1.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                }
                else
                {
                    Clases.Contacts obj1 = new Clases.Contacts("A", long.Parse(lblIdContact.Text), 0, "", "", "", 0,
                         0, "", lblUsuario.Text);
                    lblAviso.Text = obj1.ABM().Replace("|", "").Replace("0", "").Replace("null", "").Replace("1", "");
                }

                Repeater1.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_contacts_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                bEdit.Visible = false;
                bEliminar.Visible = false;
                DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDIT")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "DELETE")
                            bEliminar.Visible = true;
                    }

                }


            }
        }

        protected void ddlCliente_DataBound(object sender, EventArgs e)
        {
            ddlCliente.Items.Insert(0, "SELECT");
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCliente.SelectedValue == "SELECT")
            {
                lblIdCliente.Text = "0";
            }
            else
            {
                lblIdCliente.Text = ddlCliente.SelectedValue;
            }
        }
    }
}