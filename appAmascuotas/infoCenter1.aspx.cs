using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.BZip2;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Data;

namespace appAmascuotas
{
    public partial class infoCenter1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static string Serialize(object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                //Clases.XML_infocred datosXML = new Clases.XML_infocred
                //{
                //    Cod_documento = "3887972",
                //    Complemento = "",
                //    Tipo_documento = "CI",
                //    Extension = "SC",
                //    Nombre1 = "MERCY",
                //    Nombre2 = "",
                //    Ap_paterno = "ROJAS",
                //    Ap_materno = "SANDOVAL",
                //    Ap_casada = "",
                //    Razon_social = "",
                //    Nombre_comercial = ""
                //};

                //string XML1=Serialize(datosXML);
                string XML1 = @" <CONSULTAS>
                            <CONSULTA>
                            <Cod_documento>10133266</Cod_documento>
                            <Complemento>1B</Complemento>
                            <Tipo_documento>CI</Tipo_documento>
                            <Extension>SC</Extension>
                            <Nombre1>ERIK</Nombre1>
                            <Nombre2>EDUARDO</Nombre2>
                            <Ap_paterno>MORALES</Ap_paterno>
                            <Ap_materno>CARVAJAL</Ap_materno>
                            <Ap_casada/>
                            <Razon_social/>
                            <Nombre_comercial/>
                            </CONSULTA>
                            </CONSULTAS>";

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
                    clienteFECHA_NACIMIENTO = "10/08/1974",
                    clienteFECHA_VENCIMIENTO = "26/12/2021",
                    clienteFecRelDep = "14/02/2017",
                    clienteFechaAutonomo = "",
                    clienteFechaUltimaMora = "31/08/2020",
                    clienteFlagclienteRecurrente = 0,
                    clienteGENERO = "M",
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
                    clienteTipodePersona = "",
                    clienteTrabajos = "",
                    clienteUV = "",
                    clienteZona = "",
                    clienteclienteDesde = "26/07/2019"
                };

                //string motor = "{\"clienteACTIVIDAD\": \"\",\"clienteAlturaMoraActual\": 0,\"clienteBarrio\": \"\",\"clienteCalificacion_ASFI\": \"\",\"clienteCategoriaBHV\": 0, \"clienteDeclaracionesPatrimoniales\": \"\"," +
                //"\"clienteDepartamento\": \"\",\"clienteDeudaEnMora\": 0,\"clienteDeudaEntidadSolicitante\": 0,\"clienteDireccion\": \"\",\"clienteDocumentoIdentidadcliente\": \"\",\"clienteDocumentoIdentidadclienteComp\": \"\"," +
                //                "\"clienteDocumentoIdentidadclienteExt\": \"\",\"clienteESTADO_CIVIL\": \"\",\"clienteFECHA_NACIMIENTO\": \"26/07/1985\",\"clienteFECHA_VENCIMIENTO\": \"26/07/2019\",\"clienteFecRelDep\": \"14/02/2017\"," +
                //                "\"clienteFechaAutonomo\": \"\",\"clienteFechaUltimaMora\": \"31/08/2020\",\"clienteFlagclienteRecurrente\": 0,\"clienteGENERO\": \"F\",\"clienteGastosDeclarados\": 0,\"clienteID_Departamento\": 0," +
                //                "\"clienteID_Localidad\": 0,\"clienteID_PAIS\": 0,\"clienteIngresosDeclarados\": 0,\"clienteListasNegras\": \"\",\"clienteLocalidad\": \"\",\"clienteManzana\": \"\",\"clienteMoraMaxU12M\": 0," +
                //                "\"clienteNacionalidadcliente\": \"\",\"clienteNivelEducativo\": \"\",\"clienteNombreCompleto\": \"\",\"clienteNumeroDocumento\": 0,\"clienteNumeroIDcliente\": 0,\"clienteNumeroIdentificacionTributaria\": 0," +
                //                "\"clienteNumeroProductosVigentes\": 0,\"clienteNumero_Calle\": \"\",\"clienteOperacionesActivas\": 0,\"clienteOperacionesCanceladas\": 0,\"clienteOtrosIngresos\": 0,\"clientePersonasACarg\": 0," +
                //                "\"clienteRAZON_SOCIAL\": \"\",\"clienteRUBRO\": \"\",\"clienteRelDep\": 0,\"clienteScoreBHV\": 0,\"clienteSectorEconomico\": \"\",\"clienteSumatoriaCuotaVigente\": 0,\"clienteSumatoriaDeudaCastigada\": 0," +
                //                "\"clienteSumatoriaDeudaContingente\": 0,\"clienteSumatoriaDeudaVencida\": 0,\"clienteSumatoriaDeudaVigente\": 0,\"clienteTIPO_SERVICIO\": \"\",\"clienteTIPO_SOCIEDAD\": \"\",\"clienteTipoDocumentoIdentidad\": \"\"," +
                //                "\"clienteTipoEmpleo\": \"\",\"clienteTipodePersona\": \"\",\"clienteTrabajos\": \"\",\"clienteUV\": \"\",\"clienteZona\": \"\",\"clienteclienteDesde\": \"26/07/2021\"}";

                //string json = JsonConvert.SerializeObject(dtMotor);

                //testInfoCenter.ServicioIntegracionBICSoapClient obj = new testInfoCenter.ServicioIntegracionBICSoapClient();

                //string resultado = obj.consultar_persona_motor("ULATM", "Pr53baL4T4m154*", XML1, json, "2", "N", "RES_EJE_MT", 0);
                //MemoryStream var_memoria = null;
                //string reporte;
                //int tamanio;
                //BZip2InputStream var_input = default;
                //byte[] bytes_descompresos;
                //reporte = resultado;
                //var_memoria = new MemoryStream(Convert.FromBase64String(reporte));
                //var reader = new BinaryReader(var_memoria, Encoding.ASCII);
                //tamanio = reader.ReadInt32();
                //var_input = new BZip2InputStream(var_memoria);
                //bytes_descompresos = new byte[tamanio];
                //var_input.Read(bytes_descompresos, 0, bytes_descompresos.Length);
                //var_input.Close();
                //var_memoria.Close();
                //reporte = Encoding.ASCII.GetString(bytes_descompresos);


                //var stringReader = new StringReader(reporte);
                //var dsSet = new DataSet();
                //dsSet.ReadXml(stringReader);
                //GridView1.DataSource= dsSet.Tables[20];
                //GridView1.DataBind();
                //DataTable dt = new DataTable();
                //dt = dsSet.Tables[2];
                //foreach (DataRow dr in dt.Rows)
                //{

                //    string dato = dr["RESULTADO"].ToString();
                //}

                ///////////////////////////////////
                string xmlFile = Server.MapPath("~/Datos1.xml");
                DataSet dataSet = new DataSet();
                var dsSet1 = new DataSet();
                dsSet1.ReadXml(xmlFile, XmlReadMode.InferSchema);
                DataTable dt1 = new DataTable();
                dt1 = dsSet1.Tables[2];
                string dato = "";
                foreach (DataRow dr1 in dt1.Rows)
                {

                    dato = dr1["Reporte_PDF"].ToString();
                    //string dato1 = dr1["RESULTADO"].ToString();
                }

                DataTable dt2 = new DataTable();
                dt2 = dsSet1.Tables[16];
                string dato1 = "";
                foreach (DataRow dr1 in dt1.Rows)
                {

                    dato1 = dr1["Reporte_PDF"].ToString();
                }

                string archivo=DecodificarArchivo(dato);
                Response.Write("<script>window.open('"+ archivo.Replace("~/","") +"','_blank');</script>");
                //Response.Redirect(archivo);
                //Response.ContentType = "Application/pdf";
                //Response.ContentEncoding = System.Text.Encoding.UTF8;
                //Response.AppendHeader("NombreCabecera", "MensajeCabecera");
                //Response.TransmitFile(archivo);
                //Response.End();
                //byte[] pdf = StringToByteArray(dato);
                //Response.Clear();
                //MemoryStream ms = new MemoryStream(pdf);
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=labtest.pdf");
                //Response.Buffer = true;
                //ms.WriteTo(Response.OutputStream);
                //Response.End();

            }
            catch(Exception ex)
            {
                if( ex.ToString().Contains("Exception ex"))
                {
                    lblAviso.Text = "El tiempo de espera se agoto vuelva a inentarlo.";
                }
            }
            

        }

        public string DecodificarArchivo(string sBase64)
        {
            // Declaramos fs para tener crear un nuevo archivo temporal en la maquina cliente.
            // y memStream para almacenar en memoria la cadena recibida.
            string archivoNombre="~/PDF/infoCenter1.pdf";
            string sImagenTemporal = Server.MapPath(archivoNombre); //@"c:\test.pdf";  //Nombre del archivo y su extencion
            FileStream fs = new FileStream(sImagenTemporal, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            byte[] bytes;
            try
            {
                bytes = Convert.FromBase64String(sBase64);
                bw.Write(bytes);
                return archivoNombre;
               
            }
            catch
            {
                //MessageBox.Show("Ocurrió un error al leer la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return archivoNombre = "";
            }
            finally
            {

                fs.Close();
               
                bytes = null;
                bw = null;
                sBase64 = null;
            }
        }
        public static byte[] StringToByteArray(String cadena)
        {
            Int32 caracteres = cadena.Length;
            byte[] array_datos = new byte[caracteres / 2];
            for (int i = 0; i < caracteres; i += 2)
                array_datos[i / 2] = Convert.ToByte(cadena.Substring(i, 2), 16);
            return array_datos;
        }
    }
}