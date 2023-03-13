using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class interventions_admin : System.Web.UI.Page
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
                    //lbtNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    //if (dt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        if (dr["DESCRIPCION"].ToString().ToUpper() == "NEW")
                    //            lbtNuevo.Visible = true;
                    //    }

                    //}
                    if (Session["is_billed"].ToString() == "new")
                    {
                        ddlCliente.SelectedValue = Session["id_cliente"].ToString();
                        MultiView1.ActiveViewIndex = 1; 

                    }
                    else
                    {
                        ddlCliente.SelectedValue = Session["id_cliente"].ToString();
                        MultiView1.ActiveViewIndex = 0;
                    }

                }
            }

        }

        protected void ddlCliente_DataBound(object sender, EventArgs e)
        {
            ddlCliente.Items.Insert(0, "SELECT");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Button bEdit = (Button)e.Item.FindControl("btnEditar");
                //Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                //Button bContacts = (Button)e.Item.FindControl("btnContacts");
                //bEdit.Visible = false;
                //bEliminar.Visible = false;
                //bContacts.Visible = false;
                //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDIT")
                //            bEdit.Visible = true;
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "DELETE")
                //            bEliminar.Visible = true;
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "CONTACTS")
                //            bContacts.Visible = true;
                //    }

                //}


            }
        }

        protected void ddlTipoInterventions_DataBound(object sender, EventArgs e)
        {
            ddlTipoInterventions.Items.Insert(0,"SELECT");
        }

        protected void ddlTypeService_DataBound(object sender, EventArgs e)
        {
            ddlTypeService.Items.Insert(0,"SELECT");
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
            string htmlDesc = "";
            htmlDesc = hfDescripcion.Value;
        }
    }
}