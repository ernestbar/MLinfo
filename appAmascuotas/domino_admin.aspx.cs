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
    public partial class domino_admin : System.Web.UI.Page
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

        protected void ddlDominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsDominios.DataBind();
            Repeater1.DataBind();
        }

        protected void ddlDominio_DataBound(object sender, EventArgs e)
        {
            ddlDominio.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
               
                lblAviso.Text = "";

                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                lblCodigo.Text = datos[1];
                lblDominio.Text = datos[0];
                Clases.Dominios dom = new Clases.Dominios(lblDominio.Text, lblCodigo.Text);
                txtCodigo.Text = dom.PV_CODIGO;
                txtCodigo.Enabled = false;
                txtDescripcion.Text = dom.PV_DESCRIPCION;
                txtValorCaracter.Text = dom.PV_VALOR_CARACTER;
                string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                txtValorNmerico.Text = dom.PV_VALOR_NUMERICO.ToString().Replace(".",decSep).Replace(",",decSep);
                if (dom.PV_VALOR_DATE == DateTime.Parse("01/01/3000"))
                {

                }
                else
                {
                    DateTime fecha2 = dom.PV_VALOR_DATE;
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
                    hfFechaSalida.Value = fecha2.Year.ToString() + "-" + mes + "-" + dia;
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta2", "setearFechaSalida();", true);
                }
                
                lblNombreDominio.Text = dom.PV_DOMINIO;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_dominios_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                lblCodigo.Text = datos[1];
                lblDominio.Text = datos[0];
                Clases.Dominios dom = new Clases.Dominios("D", lblDominio.Text, lblCodigo.Text, "", "", 0, DateTime.Now, lblUsuario.Text);
                lblAviso.Text = dom.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_dominios_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
            limpiar_controles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string valor_fecha = "01/01/3000";
                if (hfFechaSalida.Value != "")
                    valor_fecha = hfFechaSalida.Value;
                if (lblCodigo.Text == "")
                {
                    Clases.Dominios dom = new Clases.Dominios("I", ddlDominio.SelectedValue, txtCodigo.Text, txtDescripcion.Text, txtValorCaracter.Text, decimal.Parse(txtValorNmerico.Text), DateTime.Parse(valor_fecha), lblUsuario.Text);
                    lblAviso.Text = dom.ABM().Replace("|", "").Replace("0", "").Replace("null", ""); 
                }
                else
                {
                    Clases.Dominios dom = new Clases.Dominios("U", lblDominio.Text, lblCodigo.Text, txtDescripcion.Text, txtValorCaracter.Text, decimal.Parse(txtValorNmerico.Text), DateTime.Parse(valor_fecha), lblUsuario.Text);
                    lblAviso.Text = dom.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
                }
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_dominios_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator..";
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            lblNombreDominio.Text = ddlDominio.SelectedItem.Text;
            lblCodigo.Text = "";
            lblDominio.Text = "";
            MultiView1.ActiveViewIndex = 1;
        }
        public void limpiar_controles()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            lblAviso.Text = "";
            txtValorCaracter.Text = "";
            txtValorNmerico.Text = "";
            txtValorNmerico.Text = "0";
            hfFechaSalida.Value = "";
            txtCodigo.Enabled = true;

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
    }
}