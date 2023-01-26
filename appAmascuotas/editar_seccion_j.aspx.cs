using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class editar_seccion_j : System.Web.UI.Page
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
                        lblUsuario.Text = Session["usuario"].ToString();
                        string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                        lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                        MultiView2.ActiveViewIndex = 0;
                        txtSociedadOtros.Enabled = false;
                        cargar_calendarios();
                        ddlExpedido.DataBind();
                        ddlSeccion.DataBind();
                        rblClaseSociedad.DataBind();
                        llenar_Seccion();
                        lblCodCliente.Text = Session["COD_CLIENTE"].ToString();
                        DataTable dt = new DataTable();
                        dt = simular.Datos_cliente_simuldor(lblCodCliente.Text);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["tipo_cliente"].ToString().Trim() == "01")
                                {
                                    if (String.IsNullOrEmpty(dr["razon_social"].ToString())) { txtRazonSocial.Text = ""; } else { txtRazonSocial.Text = dr["razon_social"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["numero_documento"].ToString())) { txtNit.Text = ""; } else { txtNit.Text = dr["numero_documento"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["FECHA_FUNNAC"].ToString())) { }
                                    else
                                    {
                                        DateTime FECHA_AUX = (DateTime)dr["FECHA_FUNNAC"];
                                        ddlFunDia.SelectedValue = FECHA_AUX.Day.ToString();
                                        ddlFunMes.SelectedValue = FECHA_AUX.Month.ToString();
                                        ddlFunAño.SelectedValue = FECHA_AUX.Year.ToString();

                                    }

                                    if (String.IsNullOrEmpty(dr["telefono_fijo"].ToString())) { txtTelefono.Text = ""; } else { txtTelefono.Text = dr["telefono_fijo"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["pagina_web"].ToString())) { txtPaginaWeb.Text = ""; } else { txtPaginaWeb.Text = dr["pagina_web"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["expedido"].ToString())) { } else { ddlExpedido.SelectedValue = dr["expedido"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["SOCIEDAD"].ToString())) { } else { rblClaseSociedad.SelectedValue = dr["SOCIEDAD"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["ACTIVIDAD"].ToString())) { txtActividad.Text = ""; } else { txtActividad.Text = dr["ACTIVIDAD"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["RUBRO"].ToString())) { txtRubro.Text = ""; } else { txtRubro.Text = dr["RUBRO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["GRUPO_ECO"].ToString())) { txtGrupoEconomico.Text = ""; } else { txtGrupoEconomico.Text = dr["GRUPO_ECO"].ToString(); }

                                }

                            }

                        }
                        ////////////////////////////DATOS REPRESENTATE LEGALES//////////////////////
                        DataTable dt1 = new DataTable();
                        dt1 = Clases.clientes.PR_GET_REPRESENTANTE_LEGAL(lblCodCliente.Text);
                        int count_rl = 0;
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in dt1.Rows)
                            {
                                if (count_rl == 0)
                                {
                                    if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep1.Text = ""; } else { lblCodRep1.Text = dr1["COD_REP_LEGAL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre1.Text = ""; } else { txtRepNombre1.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder1.Text = ""; } else { txtRepNroPoder1.Text = dr1["NRO_PODER"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail1.Text = ""; } else { txtRepEmail1.Text = dr1["EMAIL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono1.Text = ""; } else { txtRepTelefono1.Text = dr1["TELEFONO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo1.Text = ""; } else { txtRepCargo1.Text = dr1["CARGO"].ToString(); }
                                }

                                if (count_rl == 1)
                                {
                                    if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep2.Text = ""; } else { lblCodRep2.Text = dr1["COD_REP_LEGAL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre2.Text = ""; } else { txtRepNombre2.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder2.Text = ""; } else { txtRepNroPoder2.Text = dr1["NRO_PODER"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail2.Text = ""; } else { txtRepEmail2.Text = dr1["EMAIL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono2.Text = ""; } else { txtRepTelefono2.Text = dr1["TELEFONO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi2.Text = ""; } else { txtRepCi2.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo2.Text = ""; } else { txtRepCargo2.Text = dr1["CARGO"].ToString(); }
                                }

                                if (count_rl == 2)
                                {
                                    if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep3.Text = ""; } else { lblCodRep3.Text = dr1["COD_REP_LEGAL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre3.Text = ""; } else { txtRepNombre3.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder3.Text = ""; } else { txtRepNroPoder3.Text = dr1["NRO_PODER"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail3.Text = ""; } else { txtRepEmail3.Text = dr1["EMAIL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono3.Text = ""; } else { txtRepTelefono3.Text = dr1["TELEFONO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi3.Text = ""; } else { txtRepCi3.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo3.Text = ""; } else { txtRepCargo3.Text = dr1["CARGO"].ToString(); }
                                }

                                if (count_rl == 3)
                                {
                                    if (String.IsNullOrEmpty(dr1["COD_REP_LEGAL"].ToString())) { lblCodRep4.Text = ""; } else { lblCodRep4.Text = dr1["COD_REP_LEGAL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NOMBRE_COMPLETO"].ToString())) { txtRepNombre4.Text = ""; } else { txtRepNombre4.Text = dr1["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NRO_PODER"].ToString())) { txtRepNroPoder4.Text = ""; } else { txtRepNroPoder4.Text = dr1["NRO_PODER"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["EMAIL"].ToString())) { txtRepEmail4.Text = ""; } else { txtRepEmail4.Text = dr1["EMAIL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["TELEFONO"].ToString())) { txtRepTelefono4.Text = ""; } else { txtRepTelefono4.Text = dr1["TELEFONO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["NUMERO_DOCUMENTO"].ToString())) { txtRepCi4.Text = ""; } else { txtRepCi4.Text = dr1["NUMERO_DOCUMENTO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["CARGO"].ToString())) { txtRepCargo4.Text = ""; } else { txtRepCargo4.Text = dr1["CARGO"].ToString(); }
                                }
                                count_rl++;
                            }

                        }
                        ////////////////////////////DATOS DOMICILIO EMPRESA//////////////////////
                        //rblTipoVivienda.DataBind();
                        //rblDetalleVivienda.DataBind();
                        DataTable dt2 = new DataTable();
                        dt2 = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow dr2 in dt2.Rows)
                            {

                                if (String.IsNullOrEmpty(dr2["COD_DIRECCION"].ToString())) { lblCodDir.Text = ""; } else { lblCodDir.Text = dr2["COD_DIRECCION"].ToString(); }
                                //if (String.IsNullOrEmpty(dr2["TIPO_VIVIENDA"].ToString())) { } else { rblTipoVivienda.SelectedValue = dr2["TIPO_VIVIENDA"].ToString(); }
                                //if (String.IsNullOrEmpty(dr2["DETALLE"].ToString())) { } else { rblDetalleVivienda.SelectedValue = dr2["DETALLE"].ToString(); }
                                //if (String.IsNullOrEmpty(dr2["OTRA_DET"].ToString())) { txtDetViviendaOtros.Text = ""; } else { txtDetViviendaOtros.Text = dr2["OTRA_DET"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["BARRIO"].ToString())) { txtBarrio.Text = ""; } else { txtBarrio.Text = dr2["BARRIO"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["CONDOMINIO"].ToString())) { txtCondominio.Text = ""; } else { txtCondominio.Text = dr2["CONDOMINIO"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["URBANIZACION"].ToString())) { txtUrbanizacion.Text = ""; } else { txtUrbanizacion.Text = dr2["URBANIZACION"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["CIUDAD"].ToString())) { txtCiudad.Text = ""; } else { txtCiudad.Text = dr2["CIUDAD"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["AVENIDA"].ToString())) { txtAvenida.Text = ""; } else { txtAvenida.Text = dr2["AVENIDA"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["CALLE"].ToString())) { txtCalle.Text = ""; } else { txtCalle.Text = dr2["CALLE"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["PASIILO_CARRETERA"].ToString())) { txtPasilloCarretera.Text = ""; } else { txtPasilloCarretera.Text = dr2["PASIILO_CARRETERA"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["NRO"].ToString())) { txtNro.Text = ""; } else { txtNro.Text = dr2["NRO"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["EDIFICIO"].ToString())) { txtEdif.Text = ""; } else { txtEdif.Text = dr2["EDIFICIO"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["PISO"].ToString())) { txtPiso.Text = ""; } else { txtPiso.Text = dr2["PISO"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["NRO_DPTO"].ToString())) { txtNroDepto.Text = ""; } else { txtNroDepto.Text = dr2["NRO_DPTO"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["TELEFONO"].ToString())) { txtTelDom.Text = ""; } else { txtTelDom.Text = dr2["TELEFONO"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["REFERENCIA"].ToString())) { txtReferencia.Text = ""; } else { txtReferencia.Text = dr2["REFERENCIA"].ToString(); }
                                //if (String.IsNullOrEmpty(dr2["LATITUD"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr2["LATITUD"].ToString(); }
                                //if (String.IsNullOrEmpty(dr2["LONGITUD"].ToString())) { txtRepCi1.Text = ""; } else { txtRepCi1.Text = dr2["LONGITUD"].ToString(); }
                            }

                        }
                        ////////////////////////////DATOS REFERENCIAS EMPRESA//////////////////////
                        DataTable dt3 = new DataTable();
                        dt3 = Clases.clientes.PR_GET_REFERENCIAS(lblCodCliente.Text);
                        int count_ref = 0;
                        if (dt3.Rows.Count > 0)
                        {
                            foreach (DataRow dr3 in dt3.Rows)
                            {
                                if (count_ref == 0)
                                {
                                    if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef1.Text = ""; } else { lblCodRef1.Text = dr3["COD_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef1.Text = "02"; } else { lblTipoRef1.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre1.Text = ""; } else { txtRefNombre1.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo1.Text = ""; } else { txtRefTrabajo1.Text = dr3["OCUPACION"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto1.Text = ""; } else { txtRefTelfContacto1.Text = dr3["TELEFONO"].ToString(); }
                                }
                                if (count_ref == 1)
                                {
                                    if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef2.Text = ""; } else { lblCodRef2.Text = dr3["COD_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef2.Text = "02"; } else { lblTipoRef2.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre2.Text = ""; } else { txtRefNombre2.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo2.Text = ""; } else { txtRefTrabajo2.Text = dr3["OCUPACION"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto2.Text = ""; } else { txtRefTelfContacto2.Text = dr3["TELEFONO"].ToString(); }
                                }
                                if (count_ref == 2)
                                {
                                    if (String.IsNullOrEmpty(dr3["COD_REFERENCIA"].ToString())) { lblCodRef3.Text = ""; } else { lblCodRef3.Text = dr3["COD_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["TIPO_REFERENCIA"].ToString())) { lblTipoRef3.Text = "02"; } else { lblTipoRef3.Text = dr3["TIPO_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["NOMBRE_COMPLETO"].ToString())) { txtRefNombre3.Text = ""; } else { txtRefNombre3.Text = dr3["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["OCUPACION"].ToString())) { txtRefTrabajo3.Text = ""; } else { txtRefTrabajo3.Text = dr3["OCUPACION"].ToString(); }
                                    if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtRefTelfContacto3.Text = ""; } else { txtRefTelfContacto3.Text = dr3["TELEFONO"].ToString(); }
                                }
                                count_ref++;
                            }

                        }
                        ////////////////////////////DATOS BALANCE//////////////////////
                        DataTable dt4 = new DataTable();
                        dt4 = Clases.clientes.PR_GET_BALANCE(lblCodCliente.Text);

                        if (dt3.Rows.Count > 0)
                        {
                            foreach (DataRow dr4 in dt4.Rows)
                            {

                                if (String.IsNullOrEmpty(dr4["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr4["COD_BALANCE"].ToString(); }
                                if (String.IsNullOrEmpty(dr4["TOTAL_ACTIVOS_SUS"].ToString())) { txtTotActSus.Text = "02"; } else { txtTotActSus.Text = decimal.Parse(dr4["TOTAL_ACTIVOS_SUS"].ToString()).ToString("G").Replace(".", decSep).Replace(",", decSep); }
                                if (String.IsNullOrEmpty(dr4["TOTAL_PASIVOS"].ToString())) { txtTotPasSus.Text = ""; } else { txtTotPasSus.Text = dr4["TOTAL_PASIVOS"].ToString().Replace(".", decSep).Replace(",", decSep); }
                                if (String.IsNullOrEmpty(dr4["PATRIMONIO_SUS"].ToString())) { txtPatNetoSus.Text = ""; } else { txtPatNetoSus.Text = dr4["PATRIMONIO_SUS"].ToString().Replace(".", decSep).Replace(",", decSep); }

                            }

                        }
                    }
                }
                catch
                {
                    lblAviso.Text = "Hubo un error en el proceso.";
                }
                
                

            }
        }
        protected void rblClaseSociedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblClaseSociedad.SelectedItem.Text.ToUpper() != "OTROS")
            {
                txtSociedadOtros.Enabled = false; txtSociedadOtros.Text = "";
            }
            else
            { txtSociedadOtros.Enabled = true; txtSociedadOtros.Focus(); }
        }
        protected void txtTotPasSus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTotActSus.Text == "") { txtTotActSus.Text = "0"; }
                if (txtTotPasSus.Text == "") { txtTotPasSus.Text = "0"; }
                decimal patNeto = 0;
                patNeto = decimal.Parse(txtTotActSus.Text) - decimal.Parse(txtTotPasSus.Text);
                if (patNeto > 0)
                {
                    txtPatNetoSus.Text = patNeto.ToString();
                    lblPatNeto.Text = "";
                }
                else
                {
                    lblPatNeto.Text = "El patrimonio neto no puede ser menor o igual a 0";
                }
            }
            catch
            {
                lblAviso.Text = "Hubo un error en el proceso.";
            }
            
        }


        protected void ddlExpedido_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlExpedido.Items.Insert(0, miitem);
        }

        public void cargar_calendarios()
        {
            ddlFunAño.Items.Clear();
            ddlFunDia.Items.Clear();
            ddlFunMes.Items.Clear();
            int d = 1;
            for (d = 1; d <= 31; d++)
            {
                ListItem dia = new ListItem();
                dia.Text = d.ToString();
                dia.Value = d.ToString();
                // ddlGarDia.Items.Add(dia);
                ddlFunDia.Items.Add(dia);
            }
            int m = 1;
            for (m = 1; m <= 12; m++)
            {
                ListItem mes = new ListItem();
                if (m == 1)
                {
                    mes.Text = "ENERO";
                    mes.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes.Text = "FEBRERO";
                    mes.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes.Text = "MARZO";
                    mes.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes.Text = "ABRIL";
                    mes.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes.Text = "MAYO";
                    mes.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes.Text = "JUNIO";
                    mes.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes.Text = "JULIO";
                    mes.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes.Text = "AGOSTO";
                    mes.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes.Text = "SEPTIEMBRE";
                    mes.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes.Text = "OCTUBRE";
                    mes.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes.Text = "NOVIEMBRE";
                    mes.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes.Text = "DICIEMBRE";
                    mes.Value = m.ToString();
                }

                //ddlGarMes.Items.Add(mes);
                ddlFunMes.Items.Add(mes);
            }
            int a = 1900;
            for (a = 1900; a <= DateTime.Now.Year; a++)
            {
                ListItem anio = new ListItem();
                anio.Text = a.ToString();
                anio.Value = a.ToString();
                // ddlGarAño.Items.Add(anio);
                ddlFunAño.Items.Add(anio);
            }
            ddlFunDia.Items.Insert(0, "DIA");
            ddlFunMes.Items.Insert(0, "MES");
            ddlFunAño.Items.Insert(0, "AÑO");


        }
        protected void btnVolverGrilla_Click(object sender, EventArgs e)
        {
            Response.Redirect("juridica_wiz.aspx?RME=" + lblCodMenuRol.Text);
            lblAviso.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Panel_opciones.Visible = false;
            MultiView2.ActiveViewIndex = 0;
            lblAviso.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //byte[] data;
                //WebClient webClient = new WebClient();
                //if (hfImageUrl.Value == null || hfImageUrl.Value == "")
                //{ data = null; }
                //else
                //{ data = webClient.DownloadData(hfImageUrl.Value); }

                DateTime fecha_fun = DateTime.Parse("01/01/3000");
                if (ddlFunDia.SelectedValue != "DIA")
                    if (ddlFunMes.SelectedValue != "MES")
                        if (ddlFunAño.SelectedValue != "AÑo")
                        {
                            string s;
                            string fecha = "";
                            s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            if (s.ToUpper() == "DD/MM/YYYY")
                            { fecha = ddlFunDia.SelectedValue + "/" + ddlFunMes.SelectedValue + "/" + ddlFunAño.SelectedValue; }
                            if (s.ToUpper() == "D/M/YYYY")
                            { fecha = ddlFunDia.SelectedValue + "/" + ddlFunMes.SelectedValue + "/" + ddlFunAño.SelectedValue; }
                            if (s.ToUpper() == "MM/DD/YYYY")
                            { fecha = ddlFunMes.SelectedValue + "/" + ddlFunDia.SelectedValue + "/" + ddlFunAño.SelectedValue; }
                            if (s.ToUpper() == "M/D/YYYY")
                            { fecha = ddlFunMes.SelectedValue + "/" + ddlFunDia.SelectedValue + "/" + ddlFunAño.SelectedValue; }
                            fecha_fun = DateTime.Parse(fecha);
                        }


                Clases.clientes obj = new Clases.clientes("I", "01", lblCodCliente.Text, "", "", "", "", "", "", "", "", "", "", 0, "", "",
                   fecha_fun, txtNit.Text, "", ddlExpedido.SelectedValue, "", 0, "",
                   "", txtRazonSocial.Text, rblClaseSociedad.SelectedValue, txtActividad.Text, txtRubro.Text, txtGrupoEconomico.Text,
                   txtTelefono.Text, txtPaginaWeb.Text, "", "", "", "", "", "", "", "", "", "", "", 0, "", "", DateTime.Parse("01/01/3000"), "", "", "", "", "", "", "", 0, "",
                   "", "", "", lblCodDir.Text, "CAS", "ALQ",
                   txtBarrio.Text, txtCondominio.Text, txtUrbanizacion.Text, txtCiudad.Text, txtAvenida.Text, txtCalle.Text, txtPasilloCarretera.Text,
                   txtNro.Text, txtEdif.Text, txtPiso.Text, txtNroDepto.Text, txtTelefono.Text, txtReferencia.Text, "", "", null, "", "",
                   "", 0, "", "", "", "", "",
                   "", 0, lblCodRef1.Text, "02", txtRefNombre1.Text, txtRefTrabajo1.Text, txtRefTelfContacto1.Text,
                   lblCodRef2.Text, "02", txtRefNombre2.Text, txtRefTrabajo2.Text, txtRefTelfContacto2.Text,
                   lblCodRef3.Text, "02", txtRefNombre3.Text, txtRefTrabajo3.Text, txtRefTelfContacto3.Text,
                   lblCodBalance.Text, decimal.Parse(txtTotActSus.Text), decimal.Parse(txtTotPasSus.Text), "", "",
                   "", "", "", "", "", "", "", "", "",//ok
                   "", "", 0, "", "", DateTime.Parse("01/01/3000"), "", "",//ok
                   "", "", 0, "", "",
                   "", "", "", 0, "", "", "", "", "", "", 0,
                   lblCodRep1.Text, txtRepNombre1.Text, txtRepNroPoder1.Text, txtRepCargo1.Text, txtRepEmail1.Text, txtRepTelefono1.Text, txtRepCi1.Text,
                   lblCodRep2.Text, txtRepNombre2.Text, txtRepNroPoder2.Text, txtRepCargo2.Text, txtRepEmail2.Text, txtRepTelefono2.Text, txtRepCi2.Text,
                   lblCodRep3.Text, txtRepNombre3.Text, txtRepNroPoder3.Text, txtRepCargo3.Text, txtRepEmail3.Text, txtRepTelefono3.Text, txtRepCi3.Text,
                   lblCodRep4.Text, txtRepNombre4.Text, txtRepNroPoder4.Text, txtRepCargo4.Text, txtRepEmail4.Text, txtRepTelefono4.Text, txtRepCi4.Text,
                    lblUsuario.Text,null);
                string[] resultado = obj.ABM().Split('|');
                lblAviso.Text = resultado[0];
                Session["COD_CLIENTE"] = resultado[1];
                MultiView2.ActiveViewIndex = 0;

                //  Clases.solicitudes obk_sol = new Clases.solicitudes("I", "", ddlRuta1.SelectedValue, ddlRuta2.SelectedValue, rblTipoRuta.SelectedValue,
                //int.Parse(txtCantPasajes.Text), decimal.Parse(txtMontoTotal.Text), decimal.Parse(txtCuotaInicial.Text), decimal.Parse(txtMontoFinanciar.Text),
                //int.Parse(txtPlazoMeses.Text), txtObservacopmes.Text,
                //resultado[1], "", "admin");
                //  string[] resultado2 = obk_sol.ABM().Split('|');
                //  Session["COD_SOLICITUD"] = resultado2[0];
                //File.WriteAllBytes(Server.MapPath("~/img_direccion/" + resultado[1] + ".jpg"), data);
                //MultiView1.ActiveViewIndex = 0;
                //MultiView2.ActiveViewIndex = 0;
                //pasos = 0;
                //limpiar_controles();
                //Response.Redirect("reporteFormNatural.aspx");
            }
            catch (Exception ex)
            {
                // lblAviso.Text = ex.ToString();
            }
        }
        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeccion.SelectedIndex > 0)
            { Panel_opciones.Visible = true; }
            else { Panel_opciones.Visible = false; }
            MultiView2.ActiveViewIndex = ddlSeccion.SelectedIndex;
        }
        public void llenar_Seccion()
        {
            ddlSeccion.Items.Clear();
            ddlSeccion.Items.Insert(0, "SELECCIONAR");
            ddlSeccion.Items.Insert(1, "Datos generales");
            ddlSeccion.Items.Insert(2, "Datos representante(s) legal(es)");
            ddlSeccion.Items.Insert(3, "Datos del domicilio y referencias de la empresa");
            ddlSeccion.Items.Insert(4, "Balance de la empresa");

        }
    }
}