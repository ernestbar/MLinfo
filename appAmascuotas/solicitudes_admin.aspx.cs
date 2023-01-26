using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using ICSharpCode.SharpZipLib.BZip2;
namespace appAmascuotas
{
    public partial class solicitudes_admin : System.Web.UI.Page
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
                        lblCodSolicitud.Text = Session["COD_SOLICITUD"].ToString();
                        lblUsuario.Text = Session["usuario"].ToString();
                        if(Session["COD_SOLICITUD_DETALLE"]==null)
                            lblCodSolicitudDetalle.Text = "0";
                        else
                            lblCodSolicitudDetalle.Text = Session["COD_SOLICITUD_DETALLE"].ToString();
                        MultiView1.ActiveViewIndex = 0;
                        if (Request.QueryString["inicialcounter"] == "SI")
                        {
                            aprobar_inicial();
                            //lblJsonWS.Text = Session["json_ws"].ToString();
                            //lblXmlWS.Text = Session["xml_ws"].ToString();

                        }
                        if (Request.QueryString["garante"] == "SI")
                        {
                           
                            aprobar_garante();

                        }
                    }
                }
                catch (Exception ex)
                {
                    string nombre_archivo = "error_solicitudes_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                    string directorio2 = Server.MapPath("~/Logs");
                    StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                    writer5.WriteLine(ex.ToString());
                    writer5.Close();
                    lblAviso.Text = "Las variables de session caducaron.";
                }

                //var plazo=dominio.VerificarPlazo(1);


            }
        }

        public  void aprobar_inicial()
        {
            try
            {
                lblCodSolicitudDetalle.Text = Session["COD_SOLICITUD_DETALLE"].ToString();
                lblTipoAccion.Text = "APR";
                MultiView1.ActiveViewIndex = 1;
                odsFormularioDinamico.DataBind();
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }
        public void aprobar_garante()
        {
            try
            {
                lblCodSolicitudDetalle.Text = Session["COD_SOLICITUD_DETALLE"].ToString();
                lblTipoAccion.Text = "APR";
                MultiView1.ActiveViewIndex = 1;
                odsFormularioDinamico.DataBind();
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }
        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {

                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodSolicitudDetalle.Text = id;
                if (obj.Text == "Datos del Garante")
                {
                    Session["COD_SOLICITUD_DETALLE"] = id;
                    Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
                    Session["COD_CLIENTE"]= lblCodCliente.Text;
                    if (lblTipoCliente.Text == "J")
                    {
                        Response.Redirect("editar_seccion_j.aspx?opcion=GAR");
                    }
                    else
                    {
                        Response.Redirect("editar_seccion.aspx?opcion=GAR");
                    }
                }
                else
                {
                    lblTipoAccion.Text = "APR";
                    MultiView1.ActiveViewIndex = 1;
                    odsFormularioDinamico.DataBind();
                    Repeater2.DataBind();
                    //generar_datos_sw();
                }
                
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

            
            //DataTable dt = new DataTable();
            //dt = Clases.solicitudes.GET_DAD_SOLICITUDES_DETALLE("SDE-7", "APR", "gzalles", "");
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string dato = dr["denominacion"].ToString();

            //}

            //foreach (RepeaterItem item in Repeater2.Items)
            //{
            //    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            //    {
            //        int control1 = 0;
            //        var label1 = (Label)item.FindControl("lblTitulo");
            //        if (label1.Text == "CODIGO RESERVA")
            //        {
            //            control1 = 1;
            //        }

            //        if (control1 == 1)
            //        {

            //            var texto1 = (TextBox)item.FindControl("TextBox1");
            //            texto1.MaxLength = 6;
            //            texto1.TextMode = TextBoxMode.SingleLine;
            //        }
            //    }
            //}

        }
        public void generar_datos_sw()
        {
            ///////////////////////////DATOS GENERALES DEL CLIENTE//////////////////////////'
            DataTable dt = new DataTable();
            dt = Clases.clientes.PR_GET_CLIENTE(lblCodCliente.Text);
            string txtPrimerNombre = "";
            string txtSegundoNombre = "";
            string txtTercerNombre = "";
            string txtApellidoPaterno = "";
            string txtApellidoMaterno = "";
            string txtCi = "";
            string ddlExpedido = "";
            string txtApellidoMarital = "";
            string txtExt = "";
            string txtRazonSocial = "";
            string txtTipoDocumento = "";
            string genero = "";
            string tipo_cliente = "";
            DateTime FECHA_AUX=DateTime.Now;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["tipo_cliente"].ToString().Trim() == "02")
                    {
                        tipo_cliente = "N";
                        if (String.IsNullOrEmpty(dr["nombre"].ToString())) { txtPrimerNombre = ""; } else { txtPrimerNombre = dr["nombre"].ToString(); }
                        if (String.IsNullOrEmpty(dr["tipo_documento"].ToString())) { txtTipoDocumento = ""; } else { txtTipoDocumento = dr["tipo_documento"].ToString(); }

                        if (String.IsNullOrEmpty(dr["segundo_nombre"].ToString())) { txtSegundoNombre = ""; } else { txtSegundoNombre = dr["segundo_nombre"].ToString(); }

                        if (String.IsNullOrEmpty(dr["tercer_nombre"].ToString())) { txtTercerNombre = ""; } else { txtTercerNombre = dr["tercer_nombre"].ToString(); }


                        if (String.IsNullOrEmpty(dr["apellido_paterno"].ToString())) { txtApellidoPaterno = ""; } else { txtApellidoPaterno = dr["apellido_paterno"].ToString(); }

                        if (String.IsNullOrEmpty(dr["apellido_materno"].ToString())) { txtApellidoMaterno = ""; } else { txtApellidoMaterno = dr["apellido_materno"].ToString(); }

                        if (String.IsNullOrEmpty(dr["apellido_marital"].ToString())) { txtApellidoMarital = ""; } else { txtApellidoMarital = dr["apellido_marital"].ToString(); }

                        if (String.IsNullOrEmpty(dr["numero_documento"].ToString())) { txtCi = ""; } else { txtCi = dr["numero_documento"].ToString(); }
                        if (String.IsNullOrEmpty(dr["sexo"].ToString())) { genero = ""; } else { genero = dr["sexo"].ToString(); }

                        if (String.IsNullOrEmpty(dr["expedido"].ToString())) { ddlExpedido = ""; } else { ddlExpedido = dr["expedido"].ToString(); }
                        if (String.IsNullOrEmpty(dr["ext"].ToString())) { txtExt = ""; } else { txtExt = dr["ext"].ToString(); }
                        if (String.IsNullOrEmpty(dr["FECHA_FUNNAC"].ToString())) { }
                        else
                        {
                            FECHA_AUX = DateTime.Parse(dr["FECHA_FUNNAC"].ToString());
                        }
                    }
                    else
                    {
                        tipo_cliente = "J";
                        genero = "";
                        if (String.IsNullOrEmpty(dr["razon_social"].ToString())) { txtRazonSocial = ""; } else { txtRazonSocial = dr["razon_social"].ToString(); }
                        if (String.IsNullOrEmpty(dr["tipo_documento"].ToString())) { txtTipoDocumento = ""; } else { txtTipoDocumento = dr["tipo_documento"].ToString(); }
                    }

                }
                string complemento = "";
                string nombre1 = "";
                string nombre2 = "";
                string paterno = "";
                string materno = "";
                string casada = "";
                string razon_social = "";
                string tipo_documento = "";
                string extension = "";

                if (txtExt == "")
                    complemento = "<Complemento/>";
                else
                    complemento = "<Complemento>" + txtExt + "</Complemento>";

                if (txtPrimerNombre == "")
                    nombre1 = "<Nombre1/>";
                else
                    nombre1 = "<Nombre1>" + txtPrimerNombre + "</Nombre1>";

                if (txtSegundoNombre == "")
                    nombre2 = "<Nombre2/>";
                else
                    nombre2 = "<Nombre2>" + txtSegundoNombre + "</Nombre2>";

                if (txtApellidoPaterno == "")
                    paterno = "<Ap_paterno/>";
                else
                    paterno = "<Ap_paterno>" + txtApellidoPaterno + "</Ap_paterno>";

                if (txtApellidoMaterno == "")
                    materno = "<Ap_materno/>";
                else
                    materno = "<Ap_materno>" + txtApellidoMaterno + "</Ap_materno>";

                if (txtApellidoMarital == "")
                    casada = "<Ap_casada/>";
                else
                    casada = "<Ap_casada>" + txtApellidoMarital + "</Ap_casada>";

                if (txtRazonSocial == "")
                    razon_social = "<Razon_social/>";
                else
                    razon_social = "<Razon_social>" + txtRazonSocial + "</Razon_social>";

                if (txtTipoDocumento == "")
                    tipo_documento = "<Tipo_documento/>";
                else
                    tipo_documento = "<Tipo_documento>" + txtTipoDocumento.Replace("D","") + "</Tipo_documento>";

                if (ddlExpedido == "")
                    extension = "<Extension/>";
                else
                    extension = "<Extension>" + ddlExpedido + "</Extension>";

                string xml_aux = @"<CONSULTAS><CONSULTA><Cod_documento>" + txtCi + "</Cod_documento>" +
                            complemento +
                            tipo_documento +
                            extension +
                            nombre1 +
                            nombre2 +
                            paterno +
                            materno +
                            casada +
                            razon_social +
                            "<Nombre_comercial/>" +
                            "</CONSULTA>" +
                            "</CONSULTAS>";

                lblXmlWS.Text = xml_aux;
                
                Clases.Datos_motor_decision dtMotor = new Clases.Datos_motor_decision
                {
                    clienteACTIVIDAD = "",
                    clienteAlturaMoraActual = 0,
                    clienteBarrio = "",
                    clienteCalificacion_ASFI = "",
                    clienteCategoriaBHV = 0,
                    clienteDeclaracionesPatrimoniales = "",
                    clienteDepartamento = "",
                    clienteDeudaEnMora = 0,
                    clienteDeudaEntidadSolicitante = 0,
                    clienteDireccion = "",
                    clienteDocumentoIdentidadcliente = "",
                    clienteDocumentoIdentidadclienteComp = "",
                    clienteDocumentoIdentidadclienteExt = "",
                    clienteESTADO_CIVIL = "",
                    clienteFECHA_NACIMIENTO = FECHA_AUX.Day.ToString() + "/" + FECHA_AUX.Month.ToString() + "/" + FECHA_AUX.Year.ToString(),
                    clienteFECHA_VENCIMIENTO = "31/01/3000",
                    clienteFecRelDep = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(),
                    clienteFechaAutonomo = "",
                    clienteFechaUltimaMora = "31/08/2020",
                    clienteFlagclienteRecurrente = 0,
                    clienteGENERO = genero,
                    clienteGastosDeclarados = 0,
                    clienteID_Departamento = 0,
                    clienteID_Localidad = 0,
                    clienteID_PAIS = 0,
                    clienteIngresosDeclarados = 0,
                    clienteListasNegras = "",
                    clienteLocalidad = "",
                    clienteManzana = "",
                    clienteMoraMaxU12M = 0,
                    clienteNacionalidadcliente = "",
                    clienteNivelEducativo = "",
                    clienteNombreCompleto = "",
                    clienteNumeroDocumento = 0,
                    clienteNumeroIDcliente = 0,
                    clienteNumeroIdentificacionTributaria = 0,
                    clienteNumeroProductosVigentes = 0,
                    clienteNumero_Calle = "",
                    clienteOperacionesActivas = 0,
                    clienteOperacionesCanceladas = 0,
                    clienteOtrosIngresos = 0,
                    clientePersonasACarg = 0,
                    clienteRAZON_SOCIAL = "",
                    clienteRUBRO = "",
                    clienteRelDep = 0,
                    clienteScoreBHV = 0,
                    clienteSectorEconomico = "",
                    clienteSumatoriaCuotaVigente = 0,
                    clienteSumatoriaDeudaCastigada = 0,
                    clienteSumatoriaDeudaContingente = 0,
                    clienteSumatoriaDeudaVencida = 0,
                    clienteSumatoriaDeudaVigente = 0,
                    clienteTIPO_SERVICIO = "",
                    clienteTIPO_SOCIEDAD = "",
                    clienteTipoDocumentoIdentidad = "",
                    clienteTipoEmpleo = "",
                    clienteTipodePersona = tipo_cliente,
                    clienteTrabajos = "",
                    clienteUV = "",
                    clienteZona = "",
                    clienteclienteDesde = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString()
                };
                
                string json = JsonConvert.SerializeObject(dtMotor);
                lblJsonWS.Text =json;
                lblXmlWS.Text = xml_aux;
                Session["json_ws"] = json;
                Session["xml_ws"] = xml_aux;

                testInfoCenter.ServicioIntegracionBICSoapClient obj = new testInfoCenter.ServicioIntegracionBICSoapClient();
                string resultado = obj.consultar_persona_motor("ULATM", "Pr53baL4T4m154*", xml_aux, json, "2", "N", "RES_EJE_MT", 0);
                MemoryStream var_memoria = null;
                string reporte;
                int tamanio;
                BZip2InputStream var_input = default;
                byte[] bytes_descompresos;
                reporte = resultado;
                var_memoria = new MemoryStream(Convert.FromBase64String(reporte));
                var reader = new BinaryReader(var_memoria, Encoding.ASCII);
                tamanio = reader.ReadInt32();
                var_input = new BZip2InputStream(var_memoria);
                bytes_descompresos = new byte[tamanio];
                var_input.Read(bytes_descompresos, 0, bytes_descompresos.Length);
                var_input.Close();
                var_memoria.Close();
                reporte = Encoding.ASCII.GetString(bytes_descompresos);
            }

        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            lblCodSolicitudDetalle.Text = id;
            MultiView1.ActiveViewIndex = 2;
            odsSolicitudesAdcionales.DataBind();
            Repeater3.DataBind();
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
                    Response.Redirect("solicitudes_gerencial.aspx?RME=" + lblCodMenuRol.Text);
                else
                    Response.Redirect("solicitudes.aspx?RME=" + lblCodMenuRol.Text);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                string dato_final1 = "";
                string datos_iniciales = "NO";
                int contador = Repeater2.Items.Count - 1;
                for (int i = contador; i >= 0; i--)
                {
                    if (Repeater2.Items[i].ItemType == ListItemType.Item || Repeater2.Items[i].ItemType == ListItemType.AlternatingItem)
                    {
                        var label1 = (Label)Repeater2.Items[i].FindControl("lblTitulo");
                        if (label1.Text != "")
                        {
                            if (label1.Text.ToUpper() == "CODIGO RESERVA")
                                dato_final1 = "SI";
                            else
                                dato_final1 = "NO";
                        }




                    }

                }
                if (dato_final1 == "SI")
                {
                    int contador2 = Repeater2.Items.Count - 1;
                    string codigo_reserva = "";
                    for (int i = contador2; i >= 0; i--)
                    {
                        if (Repeater2.Items[i].ItemType == ListItemType.Item || Repeater2.Items[i].ItemType == ListItemType.AlternatingItem)
                        {
                            var texto = (TextBox)Repeater2.Items[i].FindControl("TextBox1");
                            if (texto.Text != "")
                            {

                                codigo_reserva = texto.Text;

                            }

                        }

                    }
                    var request = (HttpWebRequest)WebRequest.Create("https://reservas2.amaszonas.com/servicioAmascotas/datosReserva.php");

                    var postData = "Usuario=048640668dbfd7f0686cd70a895cd9fa";
                    postData += "&Clave=ee2ec3cc66427bb422894495068222a8";
                    postData += "&id_reserva=" + codigo_reserva;
                    var data = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    string respuestaJson = responseString.ToString();
                    // lblResultado.Text = responseString.ToString();
                    Clases.Reservas reserva = new Clases.Reservas();
                    reserva = JsonConvert.DeserializeObject<Clases.Reservas>(respuestaJson);
                    if (reserva.pnr == null)
                    {
                        lblAviso.Text = "El servicio web no delvolvio datos consuelte con el administrador o revise el codigo de reserva.";
                    }
                    else
                    {
                        lblAviso.Text = "";
                        string cadena = "";
                        /////////////////codigo para guardar los datos devueltos por el servicio web//////////////////////////
                        for (int x = 0; x < reserva.ticket.Count; x++)
                        {
                            if (x == 0)
                            {
                                cadena = reserva.ticket[0].ToString();
                            }
                            else
                            {
                                cadena = cadena + "|" + reserva.ticket[x].ToString();
                            }
                        }

                        ////////////////////////////////////////////////////////////////////////////////////
                        Clases.Tickets tic = new Clases.Tickets("I", lblCodSolicitud.Text, reserva.pnr, reserva.tipo, reserva.itinerario, cadena, lblUsuario.Text);
                        lblAviso.Text = tic.ABM();
                        if (lblAviso.Text == "TICKET REGISTRADO CORRECTAMENTE")
                        {
                            string dato_final = "";
                            string[] datos1 = { "" };
                            int contador4 = Repeater2.Items.Count - 1;
                            for (int i = contador4; i >= 0; i--)
                            {
                                if (Repeater2.Items[i].ItemType == ListItemType.Item || Repeater2.Items[i].ItemType == ListItemType.AlternatingItem)
                                {
                                    var fileupload = (FileUpload)Repeater2.Items[i].FindControl("FileUpload1");
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

                                    var texto = (TextBox)Repeater2.Items[i].FindControl("TextBox1");
                                    if (texto.Text != "")
                                    {

                                        Clases.solicitudes_detalle obj_c2 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, texto.ToolTip, texto.Text, lblUsuario.Text);
                                        datos1 = obj_c2.ABM().Split('|');

                                    }

                                    var label1 = (Label)Repeater2.Items[i].FindControl("lblTitulo");
                                    if (label1.Text != "")
                                    {
                                        if (label1.Text.ToUpper() == "CODIGO RESERVA")
                                        {
                                            dato_final = "SI";
                                            codigo_reserva = texto.Text;
                                        }

                                        else
                                            dato_final = "NO";
                                    }


                                    var dropdownlist = (DropDownList)Repeater2.Items[i].FindControl("DropDownList1");
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
                            if (dato_final == "SI")
                            {
                                Session["COD_CLIENTE"] = lblCodCliente.Text;
                                Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
                                Session["usuario"] = lblUsuario.Text;
                                Response.Redirect("imprimir_documentos.aspx");
                            }
                            MultiView1.ActiveViewIndex = 0;

                        }
                    }

                    
                }
                else
                {

                    
                    string dato_final = "";
                    string[] datos1 = { "" };
                    int contador3 = Repeater2.Items.Count - 1;
                    string codigo_reserva = "";
                    for (int i = contador3; i >= 0; i--)
                    {
                        if (Repeater2.Items[i].ItemType == ListItemType.Item || Repeater2.Items[i].ItemType == ListItemType.AlternatingItem)
                        {
                            var fileupload = (FileUpload)Repeater2.Items[i].FindControl("FileUpload1");
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

                            var texto = (TextBox)Repeater2.Items[i].FindControl("TextBox1");
                            if (texto.Text != "")
                            {

                                Clases.solicitudes_detalle obj_c2 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, texto.ToolTip, texto.Text, lblUsuario.Text);
                                datos1 = obj_c2.ABM().Split('|');

                            }
                           
                            var label1 = (Label)Repeater2.Items[i].FindControl("lblTitulo");
                            if (label1.Text != "")
                            {
                                if (label1.Text.ToUpper() == "CODIGO RESERVA")
                                {
                                    dato_final = "SI";
                                    codigo_reserva = texto.Text;
                                }
                                else
                                    dato_final = "NO";
                               
                                if (label1.Text.ToUpper() == "RESPALDO DE INGRESOS")
                                {
                                    datos_iniciales = "SI";
                                    codigo_reserva = texto.Text;
                                }
                                else
                                    datos_iniciales = "NO";
                            }


                            var dropdownlist = (DropDownList)Repeater2.Items[i].FindControl("DropDownList1");
                            if (dropdownlist.Items.Count > 0)
                            {
                                string combito = dropdownlist.SelectedValue;
                                Clases.solicitudes_detalle obj_c2 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, dropdownlist.ToolTip, combito, lblUsuario.Text);
                                datos1 = obj_c2.ABM().Split('|');
                            }


                        }

                    }

                    lblCodSolicitudDetalle.Text = datos1[3];///trae el ultimo cod solicitud detalle
                    string email = datos1[0];
                    string cuerpo = datos1[1];
                    if (email != "")
                    {


                        Clases.enviar_correo objC = new Clases.enviar_correo();
                        string resp_email = objC.enviar(email, "Confirmacion de requisitos", cuerpo, "");


                    }

                    if (datos_iniciales == "SI")
                    {
                        //string usuario_actual = lblUsuario.Text;
                        //if (llamar_SW_infocenter() == "OK")
                        //{
                        //    lblUsuario.Text = "dtorrico";
                        //    lblTipoAccion.Text = "APR";
                        //    MultiView1.ActiveViewIndex = 1;
                        //    odsFormularioDinamico.DataBind();
                        //    Repeater2.DataBind();
                        //    datos_iniciales = "NO";
                        //    MultiView1.ActiveViewIndex = 1;
                        //    aprobar_adm_cartera();
                        //    MultiView1.ActiveViewIndex = 0;
                        //}
                        MultiView1.ActiveViewIndex = 0;

                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 0;
                    }
                    


                    Repeater1.DataBind();
                    if (dato_final == "SI")
                    {
                        Session["COD_CLIENTE"] = lblCodCliente.Text;
                        Session["COD_SOLICITUD"] = lblCodSolicitud.Text;
                        Session["usuario"] = lblUsuario.Text;
                        Response.Redirect("imprimir_documentos.aspx");
                        MultiView1.ActiveViewIndex = 0;
                    }
                   
                   
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        public void aprobar_adm_cartera()
        {
            string[] datos1 = { "" };
            int contador3 = Repeater2.Items.Count - 1;
            for (int i = contador3; i >= 0; i--)
            {
                if (Repeater2.Items[i].ItemType == ListItemType.Item || Repeater2.Items[i].ItemType == ListItemType.AlternatingItem)
                {
                    var fileupload = (FileUpload)Repeater2.Items[i].FindControl("FileUpload1");
                    if (fileupload.HasFile)
                    {
                        string archivo = fileupload.FileName;
                        string Ruta = Server.MapPath("~/uploads/" + lblCodSolicitudDetalle.Text + "/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);


                        }

                        fileupload.PostedFile.SaveAs(Ruta + archivo);
                        Clases.solicitudes_detalle obj_c1 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, fileupload.ToolTip, fileupload.FileName, "dtorrico");
                        datos1 = obj_c1.ABM().Split('|');
                    }

                    var texto = (TextBox)Repeater2.Items[i].FindControl("TextBox1");
                    if (texto.Text != "")
                    {

                        Clases.solicitudes_detalle obj_c2 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, texto.ToolTip, texto.Text, "dtorrico");
                        datos1 = obj_c2.ABM().Split('|');

                    }


                    var dropdownlist = (DropDownList)Repeater2.Items[i].FindControl("DropDownList1");
                    if (dropdownlist.Items.Count > 0)
                    {
                        string combito = "SI"; //dropdownlist.SelectedValue;
                        Clases.solicitudes_detalle obj_c2 = new Clases.solicitudes_detalle("I", lblCodSolicitudDetalle.Text, dropdownlist.ToolTip, combito, "dtorrico");
                        datos1 = obj_c2.ABM().Split('|');
                    }


                }

            }
        }
        public string llamar_SW_infocenter()
        {
            string resultado = "OK";

            return resultado;
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
                string nombre_archivo = "error_solicitudes_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }


        static int control1 = 0;
        static int control2 = 0;
        static int control3 = 0;
        static int control4 = 0;
        static int control5 = 0;
        static int control6 = 0;
        static int control7 = 0;
        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label label1 = e.Item.FindControl("lblTitulo") as Label;


            if (label1.ToolTip == "")
            {
              
            }
            else
            {
                TextBox texto1 = e.Item.FindControl("TextBox1") as TextBox;
                int ancho = int.Parse(label1.ToolTip);
                if (ancho > 200)
                {
                    string aux = ancho.ToString() + "px";
                    texto1.MaxLength = ancho;
                    texto1.TextMode = TextBoxMode.MultiLine;
                    //texto1.Height = Unit.Parse(aux);

                }
                else
                {
                    string aux = ancho.ToString() + "px";
                    texto1.MaxLength = ancho;
                    texto1.TextMode = TextBoxMode.SingleLine;
                    texto1.Height = Unit.Parse("35px");

                }

            }

            //if (label1.Text == "CODIGO RESERVA")
            //{ control1 = 1; }
            //else
            //{ control1 = 0; }
            //if (control1 == 1)
            //{
            //    TextBox texto1 = e.Item.FindControl("TextBox1") as TextBox;
            //    texto1.MaxLength = 6;
            //    texto1.TextMode = TextBoxMode.SingleLine;
            //    texto1.Height = Unit.Parse("35px");
            //}

            //if (label1.Text == "Nombre Completo Cliente")
            //{ control3 = 1; }
            //else
            //{ control3 = 0; }
            //if (control3 == 1)
            //{
            //    TextBox texto1 = e.Item.FindControl("TextBox1") as TextBox;
            //    texto1.MaxLength = 200;
            //    texto1.TextMode = TextBoxMode.SingleLine;
            //    texto1.Height = Unit.Parse("35px");
            //}

            //if (label1.Text == "Monto Financiamiento")
            //{ control4 = 1; }
            //else
            //{ control4 = 0; }
            //if (control4 == 1)
            //{
            //    TextBox texto1 = e.Item.FindControl("TextBox1") as TextBox;
            //    texto1.MaxLength = 200;
            //    texto1.TextMode = TextBoxMode.SingleLine;
            //    texto1.Height = Unit.Parse("35px");
            //}

            //if (label1.Text == "Cantidad Boleta")
            //{ control5 = 1; }
            //else
            //{ control5 = 0; }
            //if (control5 == 1)
            //{
            //    TextBox texto1 = e.Item.FindControl("TextBox1") as TextBox;
            //    texto1.MaxLength = 200;
            //    texto1.TextMode = TextBoxMode.SingleLine;
            //    texto1.Height = Unit.Parse("35px");
            //}

            //if (label1.Text == "Destino/Ruta")
            //{ control6 = 1; }
            //else
            //{ control6 = 0; }
            //if (control6 == 1)
            //{
            //    TextBox texto1 = e.Item.FindControl("TextBox1") as TextBox;
            //    texto1.MaxLength = 200;
            //    texto1.TextMode = TextBoxMode.SingleLine;
            //    texto1.Height = Unit.Parse("35px");
            //}

            //if (label1.Text == "Destino/Ruta")
            //{ control6 = 1; }
            //else
            //{ control6 = 0; }
            //if (control6 == 1)
            //{
            //    TextBox texto1 = e.Item.FindControl("TextBox1") as TextBox;
            //    texto1.MaxLength = 200;
            //    texto1.TextMode = TextBoxMode.SingleLine;
            //    texto1.Height = Unit.Parse("50px");
            //}
        }

        
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label label1 = e.Item.FindControl("lblDetalle") as Label;
            Button boton1 = e.Item.FindControl("btnAprobar") as Button;

            if (label1.Text == "APROBADO")
            {
                boton1.Text = "Finalizar";

            }
            if (label1.Text == "EN SOLICITUD CON GARANTE")
            {
                boton1.Text = "Datos del Garante";

            }
            if (label1.Text == "APROBADO CON GARANTE")
            {
                boton1.Text = "Finalizar";

            }
            
        }

        protected void btnPlanPagos_Click(object sender, EventArgs e)
        {
            Repeater4.DataBind();
            Repeater5.DataBind();
            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnGarante_Click(object sender, EventArgs e)
        {

        }
    }
}