using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace appAmascuotas
{
    public partial class editar_seccion : System.Web.UI.Page
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
                        if (Request.QueryString["opcion"] == "GAR")
                        {
                            if (Session["COD_SOLICITUD"] == null)
                            { lblCodSolicitud.Text = ""; }
                            else
                            {
                                lblCodSolicitudDetalle.Text = Session["COD_SOLICITUD_DETALLE"].ToString();
                                lblCodSolicitud.Text = Session["COD_SOLICITUD"].ToString();
                                MultiView2.ActiveViewIndex = 6;
                                Panel_opciones.Visible = true;
                            }

                        }
                        else
                        { MultiView2.ActiveViewIndex = 0; }
                        lblUsuario.Text = Session["usuario"].ToString();
                        //string s;
                        //s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        //lblAviso.Text = s;
                        string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                        cargar_calendarios();
                        //inciar_mapa("-17.8".Replace(".", decSep).Replace(",", decSep), "-63.1667".Replace(".", decSep).Replace(",", decSep));
                        lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                        llenar_Seccion();
                        rblDetalleVivienda.DataBind();
                        rblRelLaboral.DataBind();
                        rblSexo.DataBind();
                        rblSexoCon.DataBind();
                        rblSituacionLaboral.DataBind();
                        rblTipoVivienda.DataBind();
                        ddlEstCivil.DataBind();
                        ddlExpedido.DataBind();
                        ddlExpedidoCon.DataBind();
                        ddlLugarNacimiento.DataBind();
                        ddlLugarNacimientoCon.DataBind();
                        ddlNivelEdu.DataBind();
                        ddlNivelEduCon.DataBind();
                        ddlSeccion.DataBind();
                        ddlTipoAcntiguedadCli.DataBind();
                        ddlTipoAntiguedadCon.DataBind();

                        lblCodCliente.Text = Session["COD_CLIENTE"].ToString();
                        ///////////////////////////DATOS GENERALES DEL CLIENTE//////////////////////////'
                        DataTable dt = new DataTable();
                        dt = simular.Datos_cliente_simuldor(lblCodCliente.Text);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["tipo_cliente"].ToString().Trim() == "02")
                                {
                                    if (String.IsNullOrEmpty(dr["nombre"].ToString())) { txtPrimerNombre.Text = ""; } else { txtPrimerNombre.Text = dr["nombre"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["segundo_nombre"].ToString())) { txtSegundoNombre.Text = ""; } else { txtSegundoNombre.Text = dr["segundo_nombre"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["tercer_nombre"].ToString())) { txtTercerNombre.Text = ""; } else { txtTercerNombre.Text = dr["tercer_nombre"].ToString(); }


                                    if (String.IsNullOrEmpty(dr["apellido_paterno"].ToString())) { txtApellidoPaterno.Text = ""; } else { txtApellidoPaterno.Text = dr["apellido_paterno"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["apellido_materno"].ToString())) { txtApellidoMaterno.Text = ""; } else { txtApellidoMaterno.Text = dr["apellido_materno"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["email"].ToString())) { txtEmail.Text = ""; } else { txtEmail.Text = dr["email"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["numero_documento"].ToString())) { txtCi.Text = ""; } else { txtCi.Text = dr["numero_documento"].ToString(); }

                                    if (String.IsNullOrEmpty(dr["telefono_celular"].ToString())) { txtCelular.Text = ""; } else { txtCelular.Text = dr["telefono_celular"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["expedido"].ToString())) { } else { ddlExpedido.SelectedValue = dr["expedido"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["estado_civil"].ToString())) { } else { ddlEstCivil.SelectedValue = dr["ESTADO_CIVIL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["ext"].ToString())) { txtExt.Text = ""; } else { txtExt.Text = dr["ext"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["sexo"].ToString())) { } else { rblSexo.SelectedValue = dr["sexo"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["lug_nac"].ToString())) { } else { ddlLugarNacimiento.SelectedValue = dr["lug_nac"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["FECHA_FUNNAC"].ToString())) { }
                                    else
                                    {
                                        DateTime FECHA_AUX = DateTime.Parse(dr["FECHA_FUNNAC"].ToString());
                                        ddlNacDia.SelectedValue = FECHA_AUX.Day.ToString();
                                        ddlNacMes.SelectedValue = FECHA_AUX.Month.ToString();
                                        ddlNacAño.SelectedValue = FECHA_AUX.Year.ToString();

                                    }
                                    if (String.IsNullOrEmpty(dr["nivel_educacion"].ToString())) { } else { ddlNivelEdu.SelectedValue = dr["nivel_educacion"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["nacionalidad"].ToString())) { txtNacionalidad.Text = ""; } else { txtNacionalidad.Text = dr["nacionalidad"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["edad"].ToString())) { txtEdad.Text = ""; } else { txtEdad.Text = dr["edad"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["profesion"].ToString())) { txtProfesion.Text = ""; } else { txtProfesion.Text = dr["profesion"].ToString(); }
                                    if (String.IsNullOrEmpty(dr["nro_dependientes"].ToString())) { txtNroDependientes.Text = ""; } else { txtNroDependientes.Text = dr["nro_dependientes"].ToString(); }


                                }

                            }

                        }
                        ///////////////////////////DATOS GENERALES DEL CONYUGUE//////////////////////////
                        DataTable dt1 = new DataTable();
                        ddlExpedidoCon.DataBind();
                        ddlLugarNacimientoCon.DataBind();
                        rblSexoCon.DataBind();
                        ddlNivelEduCon.DataBind();
                        ddlTipoAntiguedadCon.DataBind();
                        dt1 = Clases.clientes.PR_GET_CONYUGUE(lblCodCliente.Text);
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in dt1.Rows)
                            {
                                if (dr1["tipo_cliente"].ToString().Trim() == "02")
                                {
                                    if (String.IsNullOrEmpty(dr1["conyugue"].ToString())) { lblCodConyugue.Text = ""; } else { lblCodConyugue.Text = dr1["conyugue"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["nombre"].ToString())) { txtPrimerNombreCon.Text = ""; } else { txtPrimerNombreCon.Text = dr1["nombre"].ToString(); }

                                    if (String.IsNullOrEmpty(dr1["segundo_nombre"].ToString())) { txtSegundoNombreCon.Text = ""; } else { txtSegundoNombreCon.Text = dr1["segundo_nombre"].ToString(); }

                                    if (String.IsNullOrEmpty(dr1["tercer_nombre"].ToString())) { txtTercerNombreCon.Text = ""; } else { txtTercerNombreCon.Text = dr1["tercer_nombre"].ToString(); }


                                    if (String.IsNullOrEmpty(dr1["apellido_paterno"].ToString())) { txtApellidoPaternoCon.Text = ""; } else { txtApellidoPaternoCon.Text = dr1["apellido_paterno"].ToString(); }

                                    if (String.IsNullOrEmpty(dr1["apellido_materno"].ToString())) { txtApellidoMaternoCon.Text = ""; } else { txtApellidoMaternoCon.Text = dr1["apellido_materno"].ToString(); }

                                    if (String.IsNullOrEmpty(dr1["email"].ToString())) { txtEmailCon.Text = ""; } else { txtEmailCon.Text = dr1["email"].ToString(); }

                                    if (String.IsNullOrEmpty(dr1["numero_documento"].ToString())) { txtCiCon.Text = ""; } else { txtCiCon.Text = dr1["numero_documento"].ToString(); }

                                    if (String.IsNullOrEmpty(dr1["telefono_celular"].ToString())) { txtCelularCon.Text = ""; } else { txtCelularCon.Text = dr1["telefono_celular"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["expedido"].ToString())) { } else { ddlExpedidoCon.SelectedValue = dr1["expedido"].ToString(); }

                                    if (String.IsNullOrEmpty(dr1["ext"].ToString())) { txtExtCon.Text = ""; } else { txtExtCon.Text = dr1["ext"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["sexo"].ToString())) { } else { rblSexoCon.SelectedValue = dr1["sexo"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["lug_nac"].ToString())) { } else { ddlLugarNacimientoCon.SelectedValue = dr1["lug_nac"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["FECHA_FUNNAC"].ToString())) { }
                                    else
                                    {
                                        DateTime FECHA_AUX = DateTime.Parse(dr1["FECHA_FUNNAC"].ToString());
                                        ddlNacDiaCon.SelectedValue = FECHA_AUX.Day.ToString();
                                        ddlNacMesCon.SelectedValue = FECHA_AUX.Month.ToString();
                                        ddlNacAñoCon.SelectedValue = FECHA_AUX.Year.ToString();

                                    }
                                    if (String.IsNullOrEmpty(dr1["nivel_educacion"].ToString())) { } else { ddlNivelEduCon.SelectedValue = dr1["nivel_educacion"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["nacionalidad"].ToString())) { txtNacionalidadCon.Text = ""; } else { txtNacionalidadCon.Text = dr1["nacionalidad"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["edad"].ToString())) { txtEdadCon.Text = ""; } else { txtEdadCon.Text = dr1["edad"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["profesion"].ToString())) { txtProfesionCon.Text = ""; } else { txtProfesionCon.Text = dr1["profesion"].ToString(); }
                                    //if (String.IsNullOrEmpty(dr1["nro_dependientes"].ToString())) { txtNroDependientesCon.Text = ""; } else { txtNroDependientesCon.Text = dr1["nro_dependientes"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["cargo"].ToString())) { txtCargoCon.Text = ""; } else { txtCargoCon.Text = dr1["cargo"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["antiguedad"].ToString())) { txtAntiguedadCon.Text = ""; } else { txtAntiguedadCon.Text = dr1["antiguedad"].ToString().Replace(',', '.'); }
                                    if (String.IsNullOrEmpty(dr1["tipo_antiguedad"].ToString())) { ddlTipoAntiguedadCon.DataBind(); } else { ddlTipoAntiguedadCon.SelectedValue = dr1["tipo_antiguedad"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["empresa_laboral"].ToString())) { txtEmpresaCon.Text = ""; } else { txtEmpresaCon.Text = dr1["empresa_laboral"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["direccion_empresa"].ToString())) { txtDireccionEmpresaCon.Text = ""; } else { txtDireccionEmpresaCon.Text = dr1["direccion_empresa"].ToString(); }
                                    if (String.IsNullOrEmpty(dr1["telefono_fijo"].ToString())) { txtTelfOficinaCon.Text = ""; } else { txtTelfOficinaCon.Text = dr1["telefono_fijo"].ToString(); }

                                }

                            }

                        }


                        ////////////////////////////DATOS DOMICILIO//////////////////////
                        rblTipoVivienda.DataBind();
                        rblDetalleVivienda.DataBind();
                        DataTable dt2 = new DataTable();
                        dt2 = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow dr2 in dt2.Rows)
                            {

                                if (String.IsNullOrEmpty(dr2["COD_DIRECCION"].ToString())) { lblCodDireccion.Text = ""; } else { lblCodDireccion.Text = dr2["COD_DIRECCION"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["TIPO_VIVIENDA"].ToString())) { } else { rblTipoVivienda.SelectedValue = dr2["TIPO_VIVIENDA"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["DETALLE"].ToString())) { } else { rblDetalleVivienda.SelectedValue = dr2["DETALLE"].ToString(); }
                                if (String.IsNullOrEmpty(dr2["OTRA_DET"].ToString())) { txtDetViviendaOtros.Text = ""; } else { txtDetViviendaOtros.Text = dr2["OTRA_DET"].ToString(); }
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
                        ////////////////////////////DATOS LABORALES//////////////////////
                        DataTable dt3 = new DataTable();
                        dt3 = Clases.clientes.PR_GET_DATOS_LABORALES(lblCodCliente.Text);
                        rblSituacionLaboral.DataBind();
                        rblRelLaboral.DataBind();
                        ddlTipoAcntiguedadCli.DataBind();
                        if (dt3.Rows.Count > 0)
                        {
                            foreach (DataRow dr3 in dt3.Rows)
                            {

                                if (String.IsNullOrEmpty(dr3["COD_DATO_LABORAL"].ToString())) { lblCodDatoLaboral.Text = ""; } else { lblCodDatoLaboral.Text = dr3["COD_DATO_LABORAL"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["SITUACION_LABORAL"].ToString())) { } else { rblSituacionLaboral.SelectedValue = dr3["SITUACION_LABORAL"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["RELACION_LABORAL"].ToString())) { } else { rblRelLaboral.SelectedValue = dr3["RELACION_LABORAL"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["ANTIGUEDAD"].ToString())) { txtAntiguedad.Text = ""; } else { txtAntiguedad.Text = dr3["ANTIGUEDAD"].ToString().Replace(',', '.'); }
                                if (String.IsNullOrEmpty(dr3["tipo_antiguedad"].ToString())) { ddlTipoAcntiguedadCli.DataBind(); } else { ddlTipoAcntiguedadCli.SelectedValue = dr3["tipo_antiguedad"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["CARGO"].ToString())) { txtCargoOcupa.Text = ""; } else { txtCargoOcupa.Text = dr3["CARGO"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["EMPRESA"].ToString())) { txtEmpresaTrabaja.Text = ""; } else { txtEmpresaTrabaja.Text = dr3["EMPRESA"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["DIRECCION"].ToString())) { txtDirEmpresa.Text = ""; } else { txtDirEmpresa.Text = dr3["DIRECCION"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["TELEFONO"].ToString())) { txtTelf.Text = ""; } else { txtTelf.Text = dr3["TELEFONO"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["EMAIL"].ToString())) { txtEmail2.Text = ""; } else { txtEmail2.Text = dr3["EMAIL"].ToString(); }
                                if (String.IsNullOrEmpty(dr3["INGRESO_BS"].ToString())) { txtIngresoPromedio.Text = ""; } else { txtIngresoPromedio.Text = dr3["INGRESO_BS"].ToString().Replace(',', '.'); }
                            }
                        }
                        ////////////////////////////DATOS REFERENCIAS EMPRESA//////////////////////
                        DataTable dt4 = new DataTable();
                        dt4 = Clases.clientes.PR_GET_REFERENCIAS(lblCodCliente.Text);
                        int count_ref = 0;
                        if (dt4.Rows.Count > 0)
                        {
                            foreach (DataRow dr4 in dt4.Rows)
                            {
                                if (count_ref == 0)
                                {
                                    if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef1.Text = ""; } else { lblCodRef1.Text = dr4["COD_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre1.Text = ""; } else { txtRefNombre1.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo1.Text = ""; } else { txtRefTrabajo1.Text = dr4["OCUPACION"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto1.Text = ""; } else { txtRefTelfContacto1.Text = dr4["TELEFONO"].ToString(); }
                                }
                                if (count_ref == 1)
                                {
                                    if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef2.Text = ""; } else { lblCodRef2.Text = dr4["COD_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre2.Text = ""; } else { txtRefNombre2.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo2.Text = ""; } else { txtRefTrabajo2.Text = dr4["OCUPACION"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto2.Text = ""; } else { txtRefTelfContacto2.Text = dr4["TELEFONO"].ToString(); }
                                }
                                if (count_ref == 2)
                                {
                                    if (String.IsNullOrEmpty(dr4["COD_REFERENCIA"].ToString())) { lblCodRef3.Text = ""; } else { lblCodRef3.Text = dr4["COD_REFERENCIA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["NOMBRE_COMPLETO"].ToString())) { txtRefNombre3.Text = ""; } else { txtRefNombre3.Text = dr4["NOMBRE_COMPLETO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["OCUPACION"].ToString())) { txtRefTrabajo3.Text = ""; } else { txtRefTrabajo3.Text = dr4["OCUPACION"].ToString(); }
                                    if (String.IsNullOrEmpty(dr4["TELEFONO"].ToString())) { txtRefTelfContacto3.Text = ""; } else { txtRefTelfContacto3.Text = dr4["TELEFONO"].ToString(); }
                                }
                                count_ref++;
                            }

                        }
                        ////////////////////////////DATOS BALANCE//////////////////////
                        DataTable dt5 = new DataTable();
                        dt5 = Clases.clientes.PR_GET_BALANCE(lblCodCliente.Text);

                        if (dt5.Rows.Count > 0)
                        {
                            foreach (DataRow dr5 in dt5.Rows)
                            {

                                if (String.IsNullOrEmpty(dr5["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr5["COD_BALANCE"].ToString(); }
                                if (String.IsNullOrEmpty(dr5["TOTAL_ACTIVOS_SUS"].ToString())) { txtTotActSus.Text = "02"; } else { txtTotActSus.Text = decimal.Parse(dr5["TOTAL_ACTIVOS_SUS"].ToString()).ToString().Replace(',', '.'); }
                                if (String.IsNullOrEmpty(dr5["TOTAL_PASIVOS"].ToString())) { txtTotPasSus.Text = ""; } else { txtTotPasSus.Text = dr5["TOTAL_PASIVOS"].ToString().Replace(',', '.'); }
                                if (String.IsNullOrEmpty(dr5["PATRIMONIO_SUS"].ToString())) { txtPatNetoSus.Text = ""; } else { txtPatNetoSus.Text = dr5["PATRIMONIO_SUS"].ToString().Replace(',', '.'); }

                            }

                        }
                        ////////////////////////////DATOS INGRESOS//////////////////////
                        DataTable dt6 = new DataTable();
                        dt6 = Clases.clientes.PR_GET_INGRESOS(lblCodCliente.Text);

                        if (dt6.Rows.Count > 0)
                        {
                            foreach (DataRow dr6 in dt6.Rows)
                            {

                                //if (String.IsNullOrEmpty(dr6["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr6["COD_BALANCE"].ToString(); }
                                if (String.IsNullOrEmpty(dr6["INGRESOS"].ToString())) { }
                                else
                                {
                                    if (dr6["INGRESOS"].ToString() == "Sueldos")
                                    {
                                        txtFlujoSueldo.Text = dr6["BS"].ToString().Replace(',', '.');
                                    }
                                    if (dr6["INGRESOS"].ToString() == "Honorarios")
                                    {
                                        txtFlujoHonorarios.Text = dr6["BS"].ToString().Replace(',', '.');
                                    }
                                    if (dr6["INGRESOS"].ToString() == "Rentas")
                                    {
                                        txtFlujoRentas.Text = dr6["BS"].ToString().Replace(',', '.');
                                    }
                                    if (dr6["INGRESOS"].ToString() == "Utilidades")
                                    {
                                        txtFlujoUtil.Text = dr6["BS"].ToString().Replace(',', '.');
                                    }
                                    if (dr6["INGRESOS"].ToString() == "Otros")
                                    {
                                        txtFlujoOtros.Text = dr6["BS"].ToString().Replace(',', '.');
                                    }

                                }


                            }

                        }
                        ////////////////////////////DATOS EGRESOS//////////////////////
                        DataTable dt7 = new DataTable();
                        dt7 = Clases.clientes.PR_GET_EGRESOS(lblCodCliente.Text);

                        if (dt7.Rows.Count > 0)
                        {
                            foreach (DataRow dr7 in dt7.Rows)
                            {

                                //if (String.IsNullOrEmpty(dr7["COD_BALANCE"].ToString())) { lblCodBalance.Text = ""; } else { lblCodBalance.Text = dr7["COD_BALANCE"].ToString(); }
                                if (String.IsNullOrEmpty(dr7["EGRESOS"].ToString())) { }
                                else
                                {
                                    if (dr7["EGRESOS"].ToString() == "Alquielres")
                                    {
                                        txtFluEgAlq.Text = dr7["BS"].ToString().Replace(',', '.');
                                    }
                                    if (dr7["EGRESOS"].ToString() == "Alimentacion y servicios")
                                    {
                                        txtFluEgAlimentos.Text = dr7["BS"].ToString().Replace(',', '.');
                                    }
                                    if (dr7["EGRESOS"].ToString() == "Educacion")
                                    {
                                        txtFluEgEducacion.Text = dr7["BS"].ToString().Replace(',', '.');
                                    }
                                    if (dr7["EGRESOS"].ToString() == "Pago de creditos")
                                    {
                                        txtFluEgCred.Text = dr7["BS"].ToString().Replace(',', '.');
                                    }
                                    if (dr7["EGRESOS"].ToString() == "Otros")
                                    {
                                        txtFluEgOtros.Text = dr7["BS"].ToString().Replace(',', '.');
                                    }

                                }


                            }

                        }
                        ///////////////////////////DATOS GENERALES DEL GARANTE//////////////////////////
                        DataTable dt8 = new DataTable();
                        ddlExpedidoGar.DataBind();
                        ddlLugarNacimientoGar.DataBind();
                        rblSexoGar.DataBind();
                        ddlNivelEduGar.DataBind();
                        ddlTipoAntiguedadGar.DataBind();
                        dt8 = Clases.clientes.PR_GET_GARANTE(lblCodCliente.Text, lblCodSolicitud.Text);
                        if (dt8.Rows.Count > 0)
                        {
                            foreach (DataRow dr8 in dt8.Rows)
                            {
                                if (dr8["tipo_cliente"].ToString().Trim() == "02")
                                {
                                    if (String.IsNullOrEmpty(dr8["COD_GARANTE"].ToString())) { lblCodConyugue.Text = ""; } else { lblCodConyugue.Text = dr8["conyugue"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["nombre"].ToString())) { txtPrimerNombreGar.Text = ""; } else { txtPrimerNombreGar.Text = dr8["nombre"].ToString(); }

                                    if (String.IsNullOrEmpty(dr8["segundo_nombre"].ToString())) { txtSegundoNombreGar.Text = ""; } else { txtSegundoNombreGar.Text = dr8["segundo_nombre"].ToString(); }

                                    if (String.IsNullOrEmpty(dr8["tercer_nombre"].ToString())) { txtTercerNombreGar.Text = ""; } else { txtTercerNombreGar.Text = dr8["tercer_nombre"].ToString(); }


                                    if (String.IsNullOrEmpty(dr8["apellido_paterno"].ToString())) { txtPaternoGar.Text = ""; } else { txtPaternoGar.Text = dr8["apellido_paterno"].ToString(); }

                                    if (String.IsNullOrEmpty(dr8["apellido_materno"].ToString())) { txtMaternoGar.Text = ""; } else { txtMaternoGar.Text = dr8["apellido_materno"].ToString(); }

                                    if (String.IsNullOrEmpty(dr8["email"].ToString())) { txtEmailPerGar.Text = ""; } else { txtEmailPerGar.Text = dr8["email"].ToString(); }

                                    if (String.IsNullOrEmpty(dr8["numero_documento"].ToString())) { txtCiGar.Text = ""; } else { txtCiGar.Text = dr8["numero_documento"].ToString(); }

                                    if (String.IsNullOrEmpty(dr8["telefono_celular"].ToString())) { txtCelGar.Text = ""; } else { txtCelGar.Text = dr8["telefono_celular"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["expedido"].ToString())) { } else { ddlExpedidoGar.SelectedValue = dr8["expedido"].ToString(); }

                                    if (String.IsNullOrEmpty(dr8["ext"].ToString())) { txtComplementoGar.Text = ""; } else { txtComplementoGar.Text = dr8["ext"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["sexo"].ToString())) { } else { rblSexoGar.SelectedValue = dr8["sexo"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["lug_nac"].ToString())) { } else { ddlLugarNacimientoGar.SelectedValue = dr8["lug_nac"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["FECHA_FUNNAC"].ToString())) { }
                                    else
                                    {
                                        DateTime FECHA_AUX = DateTime.Parse(dr8["FECHA_FUNNAC"].ToString());
                                        ddlNacDiaGar.SelectedValue = FECHA_AUX.Day.ToString();
                                        ddlNacMesGar.SelectedValue = FECHA_AUX.Month.ToString();
                                        ddlNacAñoGar.SelectedValue = FECHA_AUX.Year.ToString();

                                    }
                                    if (String.IsNullOrEmpty(dr8["nivel_educacion"].ToString())) { } else { ddlNivelEduGar.SelectedValue = dr8["nivel_educacion"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["nacionalidad"].ToString())) { txtNalGar.Text = ""; } else { txtNalGar.Text = dr8["nacionalidad"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["edad"].ToString())) { txtEdadGar.Text = ""; } else { txtEdadGar.Text = dr8["edad"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["profesion"].ToString())) { txtProfesionGar.Text = ""; } else { txtProfesionGar.Text = dr8["profesion"].ToString(); }
                                    //if (String.IsNullOrEmpty(dr8["nro_dependientes"].ToString())) { txtNroDependientesGar.Text = ""; } else { txtNroDependientesGar.Text = dr8["nro_dependientes"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["telefono_fijo"].ToString())) { txtTelfLabGar.Text = ""; } else { txtTelfLabGar.Text = dr8["telefono_fijo"].ToString(); }


                                    if (String.IsNullOrEmpty(dr8["COD_DATO_LABORAL"].ToString())) { lblCodDatoLaboralGar.Text = ""; } else { lblCodDatoLaboralGar.Text = dr8["COD_DATO_LABORAL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["SITUACION_LABORAL"].ToString())) { } else { rblSituacionLaboralGar.SelectedValue = dr8["SITUACION_LABORAL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["RELACION_LABORAL"].ToString())) { } else { rblRelacionLaboralGar.SelectedValue = dr8["RELACION_LABORAL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["ANTIGUEDAD"].ToString())) { txtAntiguedadGar.Text = ""; } else { txtAntiguedadGar.Text = dr8["ANTIGUEDAD"].ToString().Replace(',', '.'); }
                                    if (String.IsNullOrEmpty(dr8["tipo_antiguedad"].ToString())) { ddlTipoAntiguedadGar.DataBind(); } else { ddlTipoAntiguedadGar.SelectedValue = dr8["tipo_antiguedad"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["CARGO"].ToString())) { txtCargoGar.Text = ""; } else { txtCargoGar.Text = dr8["CARGO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["EMPRESA"].ToString())) { txtEmpresaGar.Text = ""; } else { txtEmpresaGar.Text = dr8["EMPRESA"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["DIRECCION"].ToString())) { txtDirEmpresaGar.Text = ""; } else { txtDirEmpresaGar.Text = dr8["DIRECCION"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["TELEFONO"].ToString())) { txtTelfLabGar.Text = ""; } else { txtTelfLabGar.Text = dr8["TELEFONO"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["EMAIL"].ToString())) { txtEmpresaGar.Text = ""; } else { txtEmpresaGar.Text = dr8["EMAIL"].ToString(); }
                                    if (String.IsNullOrEmpty(dr8["INGRESO_BS"].ToString())) { txtIngresoPromGar.Text = ""; } else { txtIngresoPromGar.Text = dr8["INGRESO_BS"].ToString().Replace(',', '.'); }

                                }

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
        public void llenar_Seccion()
        {
            ddlSeccion.Items.Clear();
            ddlSeccion.Items.Insert(0, "SELECCIONAR");
            ddlSeccion.Items.Insert(1, "Datos generales");
            ddlSeccion.Items.Insert(2, "Datos conyugue");
            ddlSeccion.Items.Insert(3, "Datos domicilio");
            ddlSeccion.Items.Insert(4, "Datos laborales y referencias");
            ddlSeccion.Items.Insert(5, "Balance y flujo ingresos");
            //ddlSeccion.Items.Insert(6, "Datos garante");

        }
        public void cargar_calendarios()
        {
            ddlNacDia.Items.Clear();
            ddlNacDiaCon.Items.Clear();
            ddlNacDiaGar.Items.Clear();
            ddlNacMes.Items.Clear();
            ddlNacMesCon.Items.Clear();
            ddlNacMesGar.Items.Clear();
            ddlNacAño.Items.Clear();
            ddlNacAñoCon.Items.Clear();
            ddlNacAñoGar.Items.Clear();


            int d = 1;
            for (d = 1; d <= 31; d++)
            {
                ListItem dia = new ListItem();
                dia.Text = d.ToString();
                dia.Value = d.ToString();

                ListItem dia2 = new ListItem();
                dia2.Text = d.ToString();
                dia2.Value = d.ToString();

                ListItem dia3 = new ListItem();
                dia3.Text = d.ToString();
                dia3.Value = d.ToString();
                // ddlGarDia.Items.Add(dia);
                ddlNacDia.Items.Add(dia);
                ddlNacDiaCon.Items.Add(dia2);
                ddlNacDiaGar.Items.Add(dia3);
            }
            int m = 1;
            for (m = 1; m <= 12; m++)
            {
                ListItem mes = new ListItem();
                ListItem mes2 = new ListItem();
                ListItem mes3 = new ListItem();
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
                //////
                if (m == 1)
                {
                    mes2.Text = "ENERO";
                    mes2.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes2.Text = "FEBRERO";
                    mes2.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes2.Text = "MARZO";
                    mes2.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes2.Text = "ABRIL";
                    mes2.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes2.Text = "MAYO";
                    mes2.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes2.Text = "JUNIO";
                    mes2.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes2.Text = "JULIO";
                    mes2.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes2.Text = "AGOSTO";
                    mes2.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes2.Text = "SEPTIEMBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes2.Text = "OCTUBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes2.Text = "NOVIEMBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes2.Text = "DICIEMBRE";
                    mes2.Value = m.ToString();
                }
                /////
                if (m == 1)
                {
                    mes3.Text = "ENERO";
                    mes3.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes3.Text = "FEBRERO";
                    mes3.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes3.Text = "MARZO";
                    mes3.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes3.Text = "ABRIL";
                    mes3.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes3.Text = "MAYO";
                    mes3.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes3.Text = "JUNIO";
                    mes3.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes3.Text = "JULIO";
                    mes3.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes3.Text = "AGOSTO";
                    mes3.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes3.Text = "SEPTIEMBRE";
                    mes3.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes3.Text = "OCTUBRE";
                    mes3.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes3.Text = "NOVIEMBRE";
                    mes3.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes3.Text = "DICIEMBRE";
                    mes3.Value = m.ToString();
                }

                //ddlGarMes.Items.Add(mes);
                ddlNacMesCon.Items.Add(mes);
                ddlNacMes.Items.Add(mes2);
                ddlNacMesGar.Items.Add(mes3);
            }
            int a = 1900;
            for (a = 1900; a <= DateTime.Now.Year; a++)
            {
                ListItem anio = new ListItem();
                anio.Text = a.ToString();
                anio.Value = a.ToString();
                ListItem anio2 = new ListItem();
                anio2.Text = a.ToString();
                anio2.Value = a.ToString();
                ListItem anio3 = new ListItem();
                anio3.Text = a.ToString();
                anio3.Value = a.ToString();
                // ddlGarAño.Items.Add(anio);
                ddlNacAñoCon.Items.Add(anio);
                ddlNacAño.Items.Add(anio2);
                ddlNacAñoGar.Items.Add(anio3); 
            }
            ddlNacDia.Items.Insert(0, "DIA");
            ddlNacMes.Items.Insert(0, "MES");
            ddlNacAño.Items.Insert(0, "AÑO");

            ddlNacDiaGar.Items.Insert(0, "DIA");
            ddlNacMesGar.Items.Insert(0, "MES");
            ddlNacAñoGar.Items.Insert(0, "AÑO");

            ddlNacDiaCon.Items.Insert(0, "DIA");
            ddlNacMesCon.Items.Insert(0, "MES");
            ddlNacAñoCon.Items.Insert(0, "AÑO");

        }
        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeccion.SelectedIndex > 0)
            { Panel_opciones.Visible = true; }
            else { Panel_opciones.Visible = false; }
            MultiView2.ActiveViewIndex = ddlSeccion.SelectedIndex;
            if (ddlSeccion.SelectedIndex == 1)
            {
                if (ddlEstCivil.SelectedValue == "CAS")
                { btnGuardar.Text = "Datos conyugue"; }
                else
                { btnGuardar.Text = "Guardar"; }
                
            }
            else
            {
                btnGuardar.Text = "Guardar";
            }
        }

        //protected void ddlRuta1_DataBound(object sender, EventArgs e)
        //{
        //    ListItem miitem = new ListItem();
        //    miitem.Text = "SELECCIONAR";
        //    miitem.Value = "SELECCIONAR";
        //    ddlRuta1.Items.Insert(0, miitem);

        //}

        //protected void ddlRuta2_DataBound(object sender, EventArgs e)
        //{
        //    ListItem miitem = new ListItem();
        //    miitem.Text = "SELECCIONAR";
        //    miitem.Value = "SELECCIONAR";
        //    ddlRuta2.Items.Insert(0, miitem);
        //}

        //protected void txtCuotaInicial_TextChanged(object sender, EventArgs e)
        //{


        //    decimal porcentaje = 0;
        //    porcentaje = (decimal.Parse(txtCuotaInicial.Text) / decimal.Parse(txtMontoTotal.Text)) * 100;
        //    if (porcentaje >= 20 & porcentaje < 100)
        //    {
        //        lblPorcentaje.ForeColor = System.Drawing.Color.Blue;
        //        lblPorcentaje.Text = Math.Round(porcentaje, 2).ToString() + "%";
        //        txtPlazoMeses.Focus();
        //        txtMontoFinanciar.Text = (decimal.Parse(txtMontoTotal.Text) - decimal.Parse(txtCuotaInicial.Text)).ToString();
        //    }
        //    else
        //    {
        //        lblPorcentaje.ForeColor = System.Drawing.Color.Red;
        //        if (porcentaje >= 100)
        //        { lblPorcentaje.Text = "Cuota inicial es mayor o igual al 100%"; }
        //        else
        //        { lblPorcentaje.Text = "Cuota inicial menor a 20%"; }
        //        txtMontoFinanciar.Text = "";
        //        txtCuotaInicial.Focus();
        //    }
        //}
        protected void ddlExpedidoCon_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlExpedidoCon.Items.Insert(0, miitem);
        }

        protected void ddlNivelEdu_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlNivelEdu.Items.Insert(0, miitem);
        }

        protected void rblDetalleVivienda_DataBound(object sender, EventArgs e)
        {

        }
        protected void ddlLugarNacimiento_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlLugarNacimiento.Items.Insert(0, miitem);
        }
        protected void ddlLugarNacimientoCon_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlLugarNacimientoCon.Items.Insert(0, miitem);
        }

        protected void ddlNivelEduCon_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlNivelEduCon.Items.Insert(0, miitem);
        }


        protected void ddlEstCivil_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlEstCivil.Items.Insert(0, miitem);

        }

        protected void ddlExpedido_DataBound(object sender, EventArgs e)
        {
            ListItem miitem = new ListItem();
            miitem.Text = "SELECCIONAR";
            miitem.Value = "SELECCIONAR";
            ddlExpedido.Items.Insert(0, miitem);
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
        protected void rblDetalleVivienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (rblDetalleVivienda.SelectedItem.Text.ToUpper() == "OTRO")
                txtDetViviendaOtros.Enabled = true;
            else
            {
                txtDetViviendaOtros.Text = "";
                txtDetViviendaOtros.Enabled = false;
            }

        }

        protected void rblSituacionLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblSituacionLaboral.SelectedItem.Text.ToUpper() == "INDEPENDIENTE" || rblSituacionLaboral.SelectedItem.Text.ToUpper() == "JUBILADO/RENTISTA")
            {
                txtOtros.Enabled = true;
                rblRelLaboral.Enabled = false;
                rblRelLaboral.SelectedIndex = -1;
                RequiredFieldValidator51.Visible = false;
            }
            else
            {
                txtOtros.Enabled = false;
                txtOtros.Text = "";
                rblRelLaboral.Enabled = true;
                rblRelLaboral.SelectedIndex = 1;
                RequiredFieldValidator51.Enabled = true;
            }
        }
        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFluEgAlq.Text == "") { txtFluEgAlq.Text = "0"; }
                if (txtFluEgAlimentos.Text == "") { txtFluEgAlimentos.Text = "0"; }
                if (txtFluEgEducacion.Text == "") { txtFluEgEducacion.Text = "0"; }
                if (txtFluEgCred.Text == "") { txtFluEgCred.Text = "0"; }
                if (txtFluEgOtros.Text == "") { txtFluEgOtros.Text = "0"; }

                if (txtFlujoSueldo.Text == "") { txtFlujoSueldo.Text = "0"; }
                if (txtFlujoHonorarios.Text == "") { txtFlujoHonorarios.Text = "0"; }
                if (txtFlujoRentas.Text == "") { txtFlujoRentas.Text = "0"; }
                if (txtFlujoUtil.Text == "") { txtFlujoUtil.Text = "0"; }
                if (txtFlujoOtros.Text == "") { txtFlujoOtros.Text = "0"; }

                decimal ingreso_total = decimal.Parse(txtFlujoSueldo.Text) + decimal.Parse(txtFlujoRentas.Text) + decimal.Parse(txtFlujoHonorarios.Text) + decimal.Parse(txtFlujoUtil.Text) + decimal.Parse(txtFlujoOtros.Text);
                decimal egreso_total = decimal.Parse(txtFluEgAlq.Text) + decimal.Parse(txtFluEgAlimentos.Text) + decimal.Parse(txtFluEgEducacion.Text) + decimal.Parse(txtFluEgCred.Text) + decimal.Parse(txtFluEgOtros.Text);
                decimal patrimonio = ingreso_total - egreso_total;
                if (patrimonio < 0)
                {
                    txtFlujoTotal.ForeColor = System.Drawing.Color.Red;
                    txtFluEgTotal.Text = egreso_total.ToString();
                    txtFlujoTotal.Text = ingreso_total.ToString();
                    lblPatrimonioBs.Text = "Los egresos superan a los ingresos.";
                    txtPatrimonioBs.Text = patrimonio.ToString();
                    txtPatrimonioBs.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtFlujoTotal.ForeColor = System.Drawing.Color.Blue;
                    txtFluEgTotal.Text = egreso_total.ToString();
                    txtFlujoTotal.Text = ingreso_total.ToString();
                    lblPatrimonioBs.Text = "";
                    txtPatrimonioBs.Text = patrimonio.ToString();
                    txtPatrimonioBs.ForeColor = System.Drawing.Color.Blue;
                }
            }
            catch
            {
                lblAviso.Text = "Hubo un error en el proceso.";
            }

            
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
            Session["COD_SOLICITUD_DETALLE"] = lblCodSolicitudDetalle.Text;
            Session["COD_CLIENTE"] = lblCodCliente.Text;
            Session["TIPO_CLIENTE"] = "N";
            Response.Redirect("solicitudes_admin.aspx?garante=SI", false);

        }

        protected void btnVolverGrilla_Click(object sender, EventArgs e)
        {
            Response.Redirect("natural_wiz.aspx?RME=" + lblCodMenuRol.Text);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Panel_opciones.Visible = false;
            MultiView2.ActiveViewIndex = 0;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnGuardar.Text == "Datos conyugue")
                { 
                    MultiView2.ActiveViewIndex = 2; 
                    btnGuardar.Text = "Guardar"; 
                }
                else
                {
                    
                        //byte[] data;
                        //WebClient webClient = new WebClient();
                        //if (hfImageUrl.Value == null || hfImageUrl.Value == "")
                        //{ data = null; }
                        //else
                        //{ data = webClient.DownloadData(hfImageUrl.Value); }

                        string egresos = "";
                        string ingresos = "";
                        if (txtFluEgAlq.Text == "") { txtFluEgAlq.Text = "0"; }
                        if (txtFluEgAlimentos.Text == "") { txtFluEgAlimentos.Text = "0"; }
                        if (txtFluEgEducacion.Text == "") { txtFluEgEducacion.Text = "0"; }
                        if (txtFluEgCred.Text == "") { txtFluEgCred.Text = "0"; }
                        if (txtFluEgOtros.Text == "") { txtFluEgOtros.Text = "0"; }

                        egresos = "Alquielres," + txtFluEgAlq.Text + "|Alimentacion y servicios," + txtFluEgAlimentos.Text + "|Educacion," + txtFluEgEducacion.Text + "|Pago de creditos," + txtFluEgCred.Text + "|Otros," + txtFluEgOtros.Text;

                        if (txtFlujoSueldo.Text == "") { txtFlujoSueldo.Text = "0"; }
                        if (txtFlujoHonorarios.Text == "") { txtFlujoHonorarios.Text = "0"; }
                        if (txtFlujoRentas.Text == "") { txtFlujoRentas.Text = "0"; }
                        if (txtFlujoUtil.Text == "") { txtFlujoUtil.Text = "0"; }
                        if (txtFlujoOtros.Text == "") { txtFlujoOtros.Text = "0"; }
                        string s;
                        string fecha = "01/01/3000";
                        s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                        ingresos = "Sueldos," + txtFlujoSueldo.Text + "|Honorarios," + txtFlujoHonorarios.Text + "|Rentas," + txtFlujoRentas.Text + "|Utilidades," + txtFlujoUtil.Text + "|Otros," + txtFlujoOtros.Text;
                        //DateTime fecha_nac = DateTime.Parse(ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue);
                        DateTime fecha_nac = DateTime.Parse("01/01/3000");
                        DateTime fecha_nac_con = DateTime.Parse("01/01/3000");
                        DateTime fecha_nac_gar = DateTime.Parse("01/01/3000");

                        if (ddlNacDia.SelectedItem.Text != "DIA")
                        {
                            if (ddlNacMes.SelectedItem.Text != "MES")
                            {
                                if (ddlNacAño.SelectedItem.Text != "AÑO")
                                {

                                    if (s.ToUpper() == "DD/MM/YYYY")
                                    { fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                                    if (s.ToUpper() == "D/M/YYYY")
                                    { fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                                    if (s.ToUpper() == "MM/DD/YYYY")
                                    { fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                                    if (s.ToUpper() == "M/D/YYYY")
                                    { fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                                    fecha_nac = DateTime.Parse(fecha);
                                }
                            }
                        }

                        if (ddlNacDiaCon.SelectedItem.Text != "DIA")
                        {
                            if (ddlNacMesCon.SelectedItem.Text != "MES")
                            {
                                if (ddlNacAñoCon.SelectedItem.Text != "AÑO")
                                {

                                    if (s.ToUpper() == "DD/MM/YYYY")
                                    { fecha = ddlNacDiaCon.SelectedValue + "/" + ddlNacMesCon.SelectedValue + "/" + ddlNacAñoCon.SelectedValue; }

                                    if (s.ToUpper() == "D/M/YYYY")
                                    { fecha = ddlNacDiaCon.SelectedValue + "/" + ddlNacMesCon.SelectedValue + "/" + ddlNacAñoCon.SelectedValue; }
                                    if (s.ToUpper() == "MM/DD/YYYY")
                                    { fecha = ddlNacMesCon.SelectedValue + "/" + ddlNacDiaCon.SelectedValue + "/" + ddlNacAñoCon.SelectedValue; }
                                    if (s.ToUpper() == "M/D/YYYY")
                                    { fecha = ddlNacMesCon.SelectedValue + "/" + ddlNacDiaCon.SelectedValue + "/" + ddlNacAñoCon.SelectedValue; }
                                    fecha_nac_con = DateTime.Parse(fecha);
                                }
                            }
                        }

                        if (ddlNacDiaGar.SelectedItem.Text != "DIA")
                        {
                            if (ddlNacMesGar.SelectedItem.Text != "MES")
                            {
                                if (ddlNacAñoGar.SelectedItem.Text != "AÑO")
                                {

                                    if (s.ToUpper() == "DD/MM/YYYY")
                                    { fecha = ddlNacDiaGar.SelectedValue + "/" + ddlNacMesGar.SelectedValue + "/" + ddlNacAñoGar.SelectedValue; }
                                    if (s.ToUpper() == "D/M/YYYY")
                                    { fecha = ddlNacDiaGar.SelectedValue + "/" + ddlNacMesGar.SelectedValue + "/" + ddlNacAñoGar.SelectedValue; }
                                    if (s.ToUpper() == "MM/DD/YYYY")
                                    { fecha = ddlNacMesGar.SelectedValue + "/" + ddlNacDiaGar.SelectedValue + "/" + ddlNacAñoGar.SelectedValue; }
                                    if (s.ToUpper() == "M/D/YYYY")
                                    { fecha = ddlNacMesGar.SelectedValue + "/" + ddlNacDiaGar.SelectedValue + "/" + ddlNacAñoGar.SelectedValue; }
                                    fecha_nac_gar = DateTime.Parse(fecha);
                                }
                            }
                        }

                        if (txtEdad.Text == "")
                            txtEdad.Text = "0";

                        if (txtEdadCon.Text == "")
                            txtEdadCon.Text = "0";

                        if (txtEdadGar.Text == "")
                            txtEdadGar.Text = "0";

                        if (txtNroDependientes.Text == "")
                            txtNroDependientes.Text = "0";


                        //if (txtNroDependientesCon.Text == "")
                        //    txtNroDependientesCon.Text = "0";

                        if (txtAntiguedad.Text == "")
                            txtAntiguedad.Text = "0";
                        if (txtAntiguedadCon.Text == "")
                            txtAntiguedadCon.Text = "0";
                        if (txtAntiguedadGar.Text == "")
                            txtAntiguedadGar.Text = "0";
                        string relLboral = "";
                        string relLboralGar = "";

                        decimal antiguedad1 = decimal.Parse(txtAntiguedad.Text);

                        if (rblRelLaboral.SelectedIndex == -1)
                        {
                            relLboral = txtOtros.Text;
                        }
                        else
                        {
                            relLboral = rblRelLaboral.SelectedValue;
                        }

                        if (rblRelacionLaboralGar.SelectedIndex == -1)
                        {
                            relLboralGar = txtOtros.Text;
                        }
                        else
                        {
                            relLboralGar = rblRelLaboral.SelectedValue;
                        }

                        Clases.clientes obj = new Clases.clientes("I", "02", lblCodCliente.Text,
                            txtPrimerNombre.Text, txtSegundoNombre.Text, txtTercerNombre.Text,
                            txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtApellidoCasada.Text,
                            rblSexo.SelectedValue, ddlLugarNacimiento.SelectedValue, txtNacionalidad.Text,
                            txtNacionalidad.Text, int.Parse(txtEdad.Text), ddlNivelEdu.SelectedValue,
                            ddlEstCivil.SelectedValue, fecha_nac, txtCi.Text,
                            txtExt.Text, ddlExpedido.SelectedValue, txtProfesion.Text,
                            int.Parse(txtNroDependientes.Text), txtCelular.Text, txtEmail.Text,
                            "", "", "",
                            "", "", "",
                            "", lblCodConyugue.Text, txtPrimerNombreCon.Text,
                            txtSegundoNombreCon.Text, txtTercerNombreCon.Text, txtApellidoPaternoCon.Text,
                            txtApellidoMaternoCon.Text, txtApellidoCasadaCon.Text, rblSexoCon.SelectedValue,
                            ddlLugarNacimientoCon.SelectedValue, txtNacionalidadCon.Text, txtNacionalidadCon.Text,
                            int.Parse(txtEdadCon.Text), ddlNivelEduCon.SelectedValue, "CAS",
                            fecha_nac_con, txtCiCon.Text, txtExtCon.Text,
                            ddlExpedidoCon.SelectedValue, txtCelularCon.Text, txtEmpresaCon.Text,
                            txtProfesionCon.Text, txtCargoCon.Text, decimal.Parse(txtAntiguedadCon.Text), ddlTipoAntiguedadCon.SelectedValue,
                            txtDireccionEmpresaCon.Text, txtTelfOficinaCon.Text, txtEmailCon.Text,
                            lblCodDireccion.Text, rblTipoVivienda.SelectedValue, rblDetalleVivienda.SelectedValue,
                            txtBarrio.Text, txtCondominio.Text, txtUrbanizacion.Text,
                            txtCiudad.Text, txtAvenida.Text, txtCalle.Text,
                            txtPasilloCarretera.Text, txtNro.Text, txtEdif.Text,
                            txtPiso.Text, txtNroDepto.Text, txtTelf.Text,
                            txtReferencia.Text, "", "", null,
                            lblCodDatoLaboral.Text, rblSituacionLaboral.SelectedValue, relLboral,
                            decimal.Parse(txtAntiguedad.Text), ddlTipoAcntiguedadCli.SelectedValue, txtCargoOcupa.Text, txtEmpresaTrabaja.Text,
                            txtDirEmpresa.Text, txtTelf.Text, txtEmail2.Text,
                            decimal.Parse(txtIngresoPromedio.Text), lblCodRef1.Text, "01",
                            txtRefNombre1.Text, txtRefTrabajo1.Text, txtRefTelfContacto1.Text,
                            lblCodRef2.Text, "01", txtRefNombre2.Text,
                            txtRefTrabajo2.Text, txtRefTelfContacto2.Text, lblCodRef3.Text,
                            "02", txtRefNombre3.Text, txtRefTrabajo3.Text,
                            txtRefTelfContacto3.Text, lblCodBalance.Text, decimal.Parse(txtTotActSus.Text),
                            decimal.Parse(txtTotPasSus.Text), ingresos, egresos,
                            lblCodGarante.Text, txtPrimerNombreGar.Text, txtSegundoNombreGar.Text,
                            txtTercerNombreGar.Text, txtPaternoGar.Text, txtMaternoGar.Text,
                            txtCasadaGar.Text, rblSexoGar.SelectedValue, ddlLugarNacimientoGar.SelectedValue,
                            txtNalGar.Text, txtNalGar.Text, int.Parse(txtEdadGar.Text),
                            ddlNivelEduGar.SelectedValue, ddlEstadoCivilGar.Text, fecha_nac_gar,
                           txtCiGar.Text, txtComplementoGar.Text, ddlExpedidoGar.SelectedValue,
                            txtProfesionGar.Text, 0, txtCelGar.Text,
                            txtEmailPerGar.Text, lblCodDatoLaboralGar.Text, rblSituacionLaboralGar.SelectedValue,
                            relLboralGar, decimal.Parse(txtAntiguedadGar.Text), ddlTipoAntiguedadGar.SelectedValue, txtCargoGar.Text,
                            txtEmpresaGar.Text, txtDirEmpresaGar.Text, txtTelfLabGar.Text,
                            txtEmailLabGar.Text, decimal.Parse(txtIngresoPromGar.Text), "",
                            "", "", "",
                           "", "", "",
                           "", "", "",
                           "", "", "",
                           "", "", "",
                           "", "", "",
                           "", "", "",
                           "", "", "",
                           "", "", "",
                           lblUsuario.Text, lblCodSolicitud.Text);
                        string[] resultado = obj.ABM().Split('|');
                        lblAviso.Text = resultado[0];
                        Session["COD_CLIENTE"] = resultado[1];
                        MultiView2.ActiveViewIndex = 0;
                        llenar_Seccion();
                        Panel_opciones.Visible = false;
                    

                    if (Request.QueryString["opcion"] == "GAR")
                    {
                       
                        //Response.Redirect("reporteFormNatural.aspx?garante=SI",true);

                        DataTable dt_cliente = new DataTable();
                        DataTable dt_conyugue = new DataTable();
                        DataTable dt_domicilio = new DataTable();
                        DataTable dt_datos_laborales = new DataTable();
                        DataTable dt_referencias = new DataTable();
                        DataTable dt_balance = new DataTable();
                        DataTable dt_ingresos = new DataTable();
                        DataTable dt_egresos = new DataTable();
                        DataTable dt_solicitud = new DataTable();
                        DataTable dt_garante = new DataTable();
                        DataTable dt_ingresosegresos = new DataTable();
                        DataTable dt_paisdepto = new DataTable();

                        dt_cliente = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
                        dt_conyugue = Clases.clientes.PR_GET_CONYUGUE(lblCodCliente.Text);
                        dt_domicilio = Clases.clientes.PR_GET_DIRECCION(lblCodCliente.Text);
                        dt_datos_laborales = Clases.clientes.PR_GET_DATOS_LABORALES(lblCodCliente.Text);
                        dt_referencias = Clases.clientes.PR_GET_REFERENCIAS(lblCodCliente.Text);
                        dt_balance = Clases.clientes.PR_GET_BALANCE(lblCodCliente.Text);
                        dt_ingresos = Clases.clientes.PR_GET_INGRESOS(lblCodCliente.Text);
                        dt_egresos = Clases.clientes.PR_GET_EGRESOS(lblCodCliente.Text);
                        dt_solicitud = Clases.solicitudes.GET_SOLICITUDES_IND(lblCodSolicitud.Text);
                        dt_garante = Clases.clientes.PR_GET_GARANTE(lblCodCliente.Text, lblCodSolicitud.Text);
                        dt_ingresosegresos = Clases.clientes.PR_GET_INGRESOSEGRESOS(lblCodCliente.Text);
                        dt_paisdepto = Clases.solicitudes.PR_GET_PAISDEPTO(lblCodSolicitud.Text);

                        ReportViewer rv = new ReportViewer();
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSCliente", dt_cliente));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSConyugue", dt_conyugue));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSDireccion", dt_domicilio));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSDatosLaborales", dt_datos_laborales));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSReferencias", dt_referencias));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSBalance", dt_balance));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSIngresos", dt_ingresos));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSEgresos", dt_egresos));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSSolicitud", dt_solicitud));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSGarante", dt_garante));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSIngresosEgresos", dt_ingresosegresos));
                        rv.LocalReport.DataSources.Add(new ReportDataSource("DSPaisDepto", dt_paisdepto));
                        rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/formulario_natural.rdlc");
                        rv.LocalReport.EnableHyperlinks = true;
                        ReportParameter p_dia = new ReportParameter();
                        p_dia.Name = "fecha_dia";
                        p_dia.Values.Add(Convert.ToString(DateTime.Now.Day));
                        p_dia.Visible = true;
                        ReportParameter p_mes = new ReportParameter();
                        p_mes.Name = "fecha_mes";
                        string mes_aux = "";
                        if (DateTime.Now.Month == 1)
                            mes_aux = "enero";
                        if (DateTime.Now.Month == 2)
                            mes_aux = "febrero";
                        if (DateTime.Now.Month == 3)
                            mes_aux = "marzo";
                        if (DateTime.Now.Month == 4)
                            mes_aux = "abril";
                        if (DateTime.Now.Month == 5)
                            mes_aux = "mayo";
                        if (DateTime.Now.Month == 6)
                            mes_aux = "junio";
                        if (DateTime.Now.Month == 7)
                            mes_aux = "julio";
                        if (DateTime.Now.Month == 8)
                            mes_aux = "agosto";
                        if (DateTime.Now.Month == 9)
                            mes_aux = "septiembre";
                        if (DateTime.Now.Month == 10)
                            mes_aux = "octubre";
                        if (DateTime.Now.Month == 11)
                            mes_aux = "nomviembre";
                        if (DateTime.Now.Month == 12)
                            mes_aux = "diciembre";

                        p_mes.Values.Add(mes_aux);
                        p_mes.Visible = true;
                        ReportParameter p_anio = new ReportParameter();
                        p_anio.Name = "fecha_anio";
                        p_anio.Values.Add(Convert.ToString(DateTime.Now.Year).Remove(0, 2));
                        p_anio.Visible = true;

                        ReportParameter[] rp = { p_dia, p_mes, p_anio };
                        rv.LocalReport.SetParameters(rp);
                        ////////////////////////DESCARGA DIRECTAMENTE A PDF EL PREPORTE/////////////////////////////////
                        string reportType = "PDF";
                        string mimeType;
                        string encoding;
                        string fileNameExtension;
                        Warning[] warnings;
                        string[] streams;
                        byte[] renderedBytes;

                        //Render
                        renderedBytes = rv.LocalReport.Render(
                        reportType,
                        //deviceInfo,
                        null,
                        out mimeType,
                        out encoding,
                        out fileNameExtension,
                        out streams,
                        out warnings);
                        string nombre_reporte = "~/PDF/reporte" + Session.SessionID + ".pdf";
                        string nombre_reporte2 = "PDF/reporte" + Session.SessionID + ".pdf";
                        String filePath = MapPath(nombre_reporte);
                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        fs.Write(renderedBytes, 0, renderedBytes.Length);
                        fs.Close();

                        Response.Write("<script> window.open('" + nombre_reporte2 + "','_blank'); </script>");
                        MultiView2.ActiveViewIndex = 7;

                    }
                }

                    
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

        protected void ddlEstCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstCivil.SelectedValue == "CAS")
            { btnGuardar.Text = "Datos conyugue"; }
            else
            { btnGuardar.Text = "Guardar"; }
        }

        protected void ddlLugarNacimientoGar_DataBound(object sender, EventArgs e)
        {
            ddlLugarNacimientoGar.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlNivelEduGar_DataBound(object sender, EventArgs e)
        {
            ddlNivelEduGar.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlEstadoCivilGar_DataBound(object sender, EventArgs e)
        {
            ddlEstadoCivilGar.Items.Insert(0, "SELECCIONAR");
        }

        protected void rblSituacionLaboralGar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblSituacionLaboralGar.SelectedItem.Text.ToUpper() == "INDEPENDIENTE" || rblSituacionLaboralGar.SelectedItem.Text.ToUpper() == "JUBILADO/RENTISTA")
            {
                txtOtrosRelLabGar.Enabled = true;
                rblRelacionLaboralGar.Enabled = false;
                rblRelacionLaboralGar.SelectedIndex = -1;
                RequiredFieldValidator76.Visible = false;
            }
            else
            {
                txtOtrosRelLabGar.Enabled = false;
                txtOtrosRelLabGar.Text = "";
                rblRelacionLaboralGar.Enabled = true;
                rblRelacionLaboralGar.SelectedIndex = 1;
                RequiredFieldValidator76.Visible = true;
            }
        }

        //protected void lbtnTraerDatosGar_Click(object sender, EventArgs e)
        //{
        //    string customerName = Request.Form[txtCi.UniqueID];
        //    string customerId = Request.Form[hfCustomerId.UniqueID];
        //    if (customerId != "")
        //    {
        //    }
    }
}