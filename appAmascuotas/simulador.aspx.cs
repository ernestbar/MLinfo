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
    public partial class simulador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void rblTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTipoCliente.SelectedValue == "01")
            { 
                Panel_juridica.Visible = true;
                Panel_natural.Visible = false;
            }
            else
            {
                Panel_juridica.Visible = false;
                Panel_natural.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_cliente = "";
                decimal monto = decimal.Parse(txtMonto.Text);
                int meses = int.Parse(txtMeses.Text);
                string tipo_cliente = rblTipoCliente.Text;
                string nombre = "";
                string paterno = "";
                string materno = "";
                string razon_social = "";
                string nro_documento = "";
                string tel_fijo = "";
                string tel_cel = "";
                string email = "";
                string expedido = "";


                if (tipo_cliente == "01")
                {
                    razon_social = txtRazonSocial.Text;
                    nro_documento = txtNit.Text;
                    //tel_fijo = txtTelJ.Text;
                    tel_cel = txtCelJ.Text;
                    email = txtEmailJ.Text;
                    expedido = ddlExpedidoJ.SelectedValue;
                }
                else
                {
                    nombre = txtNombre.Text;
                    paterno = txtPaterno.Text;
                    materno = txtMaterno.Text;
                    nro_documento = txtCi.Text;
                    tel_fijo = txtTel.Text;
                    tel_cel = txtCel.Text;
                    email = txtEmail.Text;
                    expedido = ddlexpedido.SelectedValue;
                }
                if (lblCodCliente.Text == "")
                {
                    //simular obj = new simular(null, decimal.Parse(txtMonto.Text), int.Parse(txtMeses.Text), rblTipoCliente.SelectedValue, nombre, paterno, materno, razon_social,
                    //   nro_documento, expedido, tel_fijo, tel_cel, email, "admin");//remplazar el 1 por el codigo del usuario
                    //lblAviso.Text = obj.ABM();
                }
                else
                {
                    //simular obj = new simular(lblCodCliente.Text, decimal.Parse(txtMonto.Text), int.Parse(txtMeses.Text), rblTipoCliente.SelectedValue, nombre, paterno, materno, razon_social,
                    //    nro_documento, expedido, tel_fijo, tel_cel, email, "admin");//remplazar el 1 por el codigo del usuario
                    //lblAviso.Text = obj.ABM();
                }


                MultiView1.ActiveViewIndex = 0;
                odsClientesSim.DataBind();
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Session["COD_CLIENTE"] = id;
                Response.Redirect("simulador_detalle.aspx");
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

            //MultiView1.ActiveViewIndex = 2;
            //lblCodCliente.Text = id;
            //odsClienteDetalle.DataBind();
            //Repeater2.DataBind();

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

      

        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                MultiView1.ActiveViewIndex = 1;
                lblCodCliente.Text = id;
                DataTable dt = new DataTable();
                dt = simular.Datos_cliente_simuldor(id);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["tipo_cliente"].ToString().Trim() == "02")
                        {
                            Panel_natural.Visible = true; Panel_juridica.Visible = false;
                            if (dr["nombre"] != null) { txtNombre.Text = dr["nombre"].ToString(); }
                            else { txtNombre.Text = ""; }
                            if (dr["apellido_paterno"] != null) { txtPaterno.Text = dr["apellido_paterno"].ToString(); }
                            else { txtPaterno.Text = ""; }
                            if (dr["apellido_materno"] != null) { txtMaterno.Text = dr["apellido_materno"].ToString(); }
                            else { txtMaterno.Text = ""; }
                            if (dr["email"] != null) { txtEmail.Text = dr["email"].ToString(); }
                            else { txtEmail.Text = ""; }
                            if (dr["numero_documento"] != null) { txtCi.Text = dr["numero_documento"].ToString(); }
                            else { txtCi.Text = ""; }
                            if (dr["telefono_fijo"] != null) { txtTel.Text = dr["telefono_fijo"].ToString(); }
                            else { txtTel.Text = ""; }
                            if (dr["telefono_celular"] != null) { txtCel.Text = dr["telefono_celular"].ToString(); }
                            else { txtCel.Text = ""; }
                            if (dr["expedido"] != null) { ddlexpedido.SelectedValue = dr["expedido"].ToString(); }


                        }
                        else
                        {
                            Panel_natural.Visible = false; Panel_juridica.Visible = true;
                            if (dr["razon_social"] != null) { txtRazonSocial.Text = dr["razon_social"].ToString(); }
                            else { txtRazonSocial.Text = ""; }
                            if (dr["numero_documento"] != null) { txtNit.Text = dr["numero_documento"].ToString(); }
                            else { txtNit.Text = ""; }
                            if (dr["email"] != null) { txtEmailJ.Text = dr["email"].ToString(); }
                            else { txtEmailJ.Text = ""; }
                            //if (dr["telefono_fijo"] != null) { txtTelJ.Text = dr["telefono_fijo"].ToString(); }
                            //else { txtTelJ.Text = ""; }
                            if (dr["telefono_celular"] != null) { txtCelJ.Text = dr["telefono_celular"].ToString(); }
                            else { txtCelJ.Text = ""; }
                            if (dr["expedido"] != null) { if (dr["expedido"] != "") { ddlExpedidoJ.SelectedValue = dr["expedido"].ToString(); } }
                        }
                        rblTipoCliente.SelectedValue = dr["tipo_cliente"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_simulador_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }

        

        protected void btnNuevaSimulacion_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
                    
            lblCodCliente.Text = "";
        }

        

        protected void btnVolverSimuldores_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

       
    }
}