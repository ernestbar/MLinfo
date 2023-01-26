using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appAmascuotas.Clases
{
    public class solicitudes_detalle
    {
		//Base de datos
		private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        //@PV_TIPO_OPERACION NVARCHAR(45),
        //@PV_COD_SOLICITUD_DETALLE_DETALLE NVARCHAR(45),
        //@@PV_COD_SOLICITUD_ADICIONAL NVARCHAR(1000),
        //@PV_DETALLE NVARCHAR(1000),
        //@PV_USUARIO NVARCHAR(45),
        //@PV_EMAIL NVARCHAR(3000) OUTPUT,
        //@PV_DETALLE_CORREO NVARCHAR(3000) OUTPUT,
        //@PV_ESTADOPR NVARCHAR(30) OUTPUT,
        //@PV_DESCRIPCIONPR NVARCHAR(250) OUTPUT,
        //@PV_ERROR NVARCHAR(250)
        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_COD_SOLICITUD_DETALLE = "";
        private string _PV_COD_SOLICITUD_ADICIONAL = "";
        private string _PV_DETALLE = "";

        private string _PV_EMAIL = "";
        private string _PV_DETALLE_CORREO = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        private string _PV_COD_SOLICITUD_DETALLEOUT = ""; 
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_COD_SOLICITUD_DETALLE { get { return _PV_COD_SOLICITUD_DETALLE; } set { _PV_COD_SOLICITUD_DETALLE = value; } }
        public string PV_COD_SOLICITUD_ADICIONAL { get { return _PV_COD_SOLICITUD_ADICIONAL; } set { _PV_COD_SOLICITUD_ADICIONAL = value; } }
        public string PV_DETALLE { get { return _PV_DETALLE; } set { _PV_DETALLE = value; } }
        public string PV_EMAIL { get { return _PV_EMAIL; } set { _PV_EMAIL = value; } }
        public string PV_DETALLE_CORREO { get { return _PV_DETALLE_CORREO; } set { _PV_DETALLE_CORREO = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        public string PV_COD_SOLICITUD_DETALLEOUT { get { return _PV_COD_SOLICITUD_DETALLEOUT; } set { _PV_COD_SOLICITUD_DETALLEOUT = value; } }
        #endregion

        #region Constructores
        public solicitudes_detalle(string PV_COD_SOLICITUD_DETALLE)
        {
            _PV_COD_SOLICITUD_DETALLE = PV_COD_SOLICITUD_DETALLE;
            RecuperarDatos();
        }
        public solicitudes_detalle(string pV_TIPO_OPERACION, string pV_COD_SOLICITUD_DETALLE, string pV_COD_SOLICITUD_ADICIONAL,
            string pV_DETALLE, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_COD_SOLICITUD_DETALLE = pV_COD_SOLICITUD_DETALLE;
            _PV_COD_SOLICITUD_ADICIONAL = pV_COD_SOLICITUD_ADICIONAL;
            _PV_DETALLE = pV_DETALLE;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable GET_SOLICITUDES_ADICIONALES(string pV_COD_SOLICITUD_DETALLE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_SOLICITUDES_ADICIONALES");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD_DETALLE", DbType.String, pV_COD_SOLICITUD_DETALLE);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable GET_SOLICITUDES_DETALLE(string pV_COD_SOLICITUD,string pV_USUARIO)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_SOLICITUDES_DETALLE");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, pV_COD_SOLICITUD);
            db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, pV_USUARIO);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable GET_DAD_SOLICITUDES_DETALLE(string pV_COD_SOLICITUD_DETALLE, string pV_TIPO_ACCION, string pV_USUARIO, string pV_MOTIVO)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_DAD_SOLICITUDES_DETALLE");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD_DETALLE", DbType.String, pV_COD_SOLICITUD_DETALLE);
            db1.AddInParameter(cmd, "PV_TIPO_ACCION", DbType.String, pV_TIPO_ACCION);
            db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, pV_USUARIO);
            db1.AddInParameter(cmd, "PV_MOTIVO", DbType.String, pV_MOTIVO);
            db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
            db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
            db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);

            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        //public static List<Cliente> ListaTodos(int Id_usuario)
        //{
        //    List<Cliente> listaObj = new List<Cliente>();
        //    DataTable dtDatos = Lista(Id_usuario);
        //    foreach (DataRow dr in dtDatos.Rows)
        //    {
        //        Cliente obj = new Cliente();
        //        obj.id_cliente = (int)dr["id_cliente"];
        //        obj.razon_social = (string)dr["razon_social"];
        //        obj.nit = (string)dr["nit"];
        //        obj.paterno = (string)dr["paterno"];
        //        obj.materno = (string)dr["materno"];
        //        obj.nombre = (string)dr["nombre"];
        //        obj.activo = (Boolean)dr["activo"];
        //        obj.id_tipocliente = (int)dr["id_tipocliente"];
        //        obj.id_tiponegocio = (int)dr["id_tiponegocio"];
        //        obj.fecha_ini = (DateTime)dr["fecha_ini"];
        //        obj.abierto = (Boolean)dr["abierto"];
        //        obj.agenda = (Boolean)dr["agenda"];
        //        listaObj.Add(obj);
        //    }
        //    return listaObj;
        //}


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("GET_SOLICITUDES_ADICIONALES");
                db1.AddInParameter(cmd, "PV_COD_SOLICITUD_DETALLE", DbType.String, _PV_COD_SOLICITUD_DETALLE);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    //_PV_COD_SOLICITUD_ADICIONAL = dr["RUTA_ORIGEN"].ToString();
                    //_PV_DETALLE = dr["RUTA_DESTINO"].ToString();
                    //_PV_TIPO_RUTA = dr["TIPO_RUTA"].ToString();
                    //_PI_CANT_PASAJES = int.Parse(dr["CANT_PASAJES"].ToString());
                    //_PD_VALOR_PASAJE = decimal.Parse(dr["VALOR_PASAJE"].ToString());
                    //_PD_CUOTA_INICIAL = decimal.Parse(dr["CUOTA_INICIAL"].ToString());
                    //_PD_MONTO_FINANCIADO = decimal.Parse(dr["MONTO_FINANCIADO"].ToString());
                    //_PI_PLAZO_MES = int.Parse(dr["PLAZO_MES"].ToString());
                    //_PV_OBSERVACION = dr["OBSERVACION"].ToString();
                    //_PV_ESTADO = dr["ESTADO"].ToString();
                }
            }
            catch { }
        }
        //public void verificar_vacios()
        //{
        //    if (_PV_TIPO_OPERACION == "") { _PV_TIPO_OPERACION = null; };
        //    if (_PI_CANT_PASAJES == "") { _PI_CANT_PASAJES = null; };
        //    if (_PD_VALOR_PASAJE == "") { _PD_VALOR_PASAJE = null; };
        //    if (_PD_CUOTA_INICIAL == "") { _PD_CUOTA_INICIAL = null; };
        //    if (_PD_MONTO_FINANCIADO == "") { _PD_MONTO_FINANCIADO = null; };
        //    if (_PI_PLAZO_MES == "") { _PI_PLAZO_MES = null; };
        //    if (_PV_OBSERVACION == "") { _PV_OBSERVACION = null; };
        //    if (_PV_EMAIL == "") { _PV_EMAIL = null; };
        //    if (_PV_DETALLE_CORREO == "") { _PV_DETALLE_CORREO = null; };
        //    if (_PV_EXT == "") { _PV_EXT = null; };
        //    if (_PV_EXPEDIDO == "") { _PV_EXPEDIDO = null; };
        //    if (_PV_TELEFONO_FIJO == "") { _PV_TELEFONO_FIJO = null; };
        //    if (_PV_TELEFONO_CELULAR == "") { _PV_TELEFONO_CELULAR = null; };
        //    if (_PV_EMAIL == "") { _PV_EMAIL = null; };
        //    if (_PV_PAGINA_WEB == "") { _PV_PAGINA_WEB = null; };
        //    if (_PD_VALOR_PASAJE_CONTACTO == "") { _PD_VALOR_PASAJE_CONTACTO = null; };
        //    if (_PV_CELULAR_CONTACTO == "") { _PV_CELULAR_CONTACTO = null; };
        //    if (_PV_USUARIO == "") { _PV_USUARIO = null; };
        //    if (_PV_ERROR == "") { _PV_ERROR = null; };

        //}

        //_PV_TIPO_OPERACION = pV_TIPO_OPERACION;
        //    _PV_COD_SOLICITUD_DETALLE = PV_COD_SOLICITUD_DETALLE;
        //    _PV_COD_SOLICITUD_ADICIONAL = PV_COD_SOLICITUD_ADICIONAL;
        //    _PV_DETALLE = PV_DETALLE;
        //    _PV_TIPO_RUTA = pV_TIPO_RUTA;
        //    _PI_CANT_PASAJES = pI_CANT_PASAJES;
        //    _PD_VALOR_PASAJE = pD_VALOR_PASAJE;
        //    _PD_CUOTA_INICIAL = pD_CUOTA_INICIAL;
        //    _PD_MONTO_FINANCIADO = pD_MONTO_FINANCIADO;
        //    _PI_PLAZO_MES = pI_PLAZO_MES;
        //    _PV_OBSERVACION = pV_OBSERVACION;
        //    _PV_EMAIL = PV_EMAIL;
        //    _PV_DETALLE_CORREO = PV_DETALLE_CORREO;
        //    _PV_USUARIO = pV_USUARIO;
        public string ABM()
        {
            string resultado = "";
            try
            {
                //verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_ABM_SOLICITUD_DETALLE");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_COD_SOLICITUD_DETALLE", DbType.String, _PV_COD_SOLICITUD_DETALLE);
                if(_PV_COD_SOLICITUD_ADICIONAL=="")
                    db1.AddInParameter(cmd, "PV_COD_SOLICITUD_ADICIONAL", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_COD_SOLICITUD_ADICIONAL", DbType.String, _PV_COD_SOLICITUD_ADICIONAL);
                db1.AddInParameter(cmd, "PV_DETALLE", DbType.String, _PV_DETALLE);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);

                db1.AddOutParameter(cmd, "PV_COD_SOLICITUD_DETALLEOUT", DbType.String, 200);
                db1.AddOutParameter(cmd, "PV_EMAIL", DbType.String, 200);
                db1.AddOutParameter(cmd, "PV_DETALLE_CORREO", DbType.String, 200);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);

                db1.ExecuteNonQuery(cmd);
                if(string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_EMAIL").ToString()))
                { PV_EMAIL = ""; }
                else
                    PV_EMAIL = (string)db1.GetParameterValue(cmd, "PV_EMAIL");
                if (string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DETALLE_CORREO").ToString()))
                { PV_DETALLE_CORREO = ""; }
                else
                {
                    string aux= (string)db1.GetParameterValue(cmd, "PV_DETALLE_CORREO");
                    string[] datos1 = aux.Split('|');
                    if (datos1[0] == "APROBADO")
                    {
                        PV_DETALLE_CORREO = @"<h1 style=""color: #5e9ca0; text-align: center;"">Solicitud de Confirmacion de <span style=""color: #2b2301;"">" + datos1[1] +
                            @"</span> para Aprobacion en AMASCUOTAS APP</h1><h2 style = ""color: #2e6c80;"" > &nbsp;<img style = ""float: left;"" src = ""https://html-online.com/img/6-table-div-html.png"" alt = ""html table div"" width = ""45"" /> <strong> Ventas a Credito&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span style =""color: #2b2301;"">" +
                            datos1[2] + @"</span></strong></h2>
				        <p>Solicitud de Confirmacion de Venta de Pasajes, con los siguientes datos. <br />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>
				        <h2 style=""color: #2e6c80;"">Informacion:</h2>
				        <p style = ""text-align: center;"" > &nbsp;</p>
                             <table class=""editorDemoTable"" style=""margin-left: auto; margin-right: auto;"">
				        <thead>
				        <tr>
				        <td>Campo</td>
				        <td>Detalle</td>
				        <td>Check</td>
				        </tr>
				        </thead>
				        <tbody>
				        <tr>
				        <td>Solicitud</td>
				        <td><span id = ""demoId"" >" + datos1[3] +
                            @"</span></td>
                        <td><strong style =""font-size: 17px; color: #2b2301;""> x </strong></td>
                        </tr>
                        <tr>
                        <td> Nombre / Razon Social </td>
                        <td><span id =""demoId"">" + datos1[4] +
                             @"</span></td>
                        <td><strong style =""font-size: 17px; color: #2b2301;""> x </strong></td>
                        </tr>
                        <tr>
                        <td>Counter</td>
                        <td><span id =""demoId"">" + datos1[5] +
                            @"</span></td>
				        <td><strong style=""font - size: 17px; color: #2b2301;"">x</strong></td>
				        </tr>
                         <tr>
                        <td> Motivo </td>
                        <td><span id =""demoId"">" + datos1[6] +
                            @"</span></td>
				        <td><strong style=""font - size: 17px; color: #2b2301;"">x</strong></td>
				        </tr>
                        </tbody>
                        </table>
                        <p><strong>&nbsp;</strong></p>
                        <p><strong>Por favor ingresar al Portal AmasCuotas e Ingresar la bandeja de Solicitudes </strong><br /><strong>" + datos1[7] + "</strong></p>";
                    }
                    //    0                   1                         2                            3                   4                   5                   6             7
                    //'APROBADO'+'|'+@VV_RAZONSOCIAL+'|'+CAST(@VD_FECHA AS VARCHAR(45))+'|'+@VV_COD_SOLICITUD+'|'+@VV_RAZONSOCIAL+'|'+@VV_NOMBRECOMPLETO+'|'+@PV_DETALLE+'|'+@VV_URL;
                    //'RECHAZADO'+'|'+@VV_RAZONSOCIAL+'|'+CAST(@VD_FECHA AS VARCHAR(45))+'|'+@VV_COD_SOLICITUD+'|'+@VV_RAZONSOCIAL+'|'+@VV_NOMBRECOMPLETO+'|'+@PV_DETALLE+'|'+@VV_URL;
                    if (datos1[0] == "RECHAZADO")
                    {
                        PV_DETALLE_CORREO = @"<h1 style=""color: #5e9ca0; text-align: center;"">Informe de Rechazo de <span style=""color: #2b2301;"">" + datos1[1] +
                            @"</span> para Aprobacion en AMASCUOTAS APP</h1><h2 style = ""color: #2e6c80;"" > &nbsp;<img style = ""float: left;"" src = ""https://html-online.com/img/6-table-div-html.png"" alt = ""html table div"" width = ""45"" /> <strong> Ventas a Credito&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span style =""color: #2b2301;"">" +
                            datos1[2] + @"</span></strong></h2>
				        <p>Solicitud de Confirmacion de Venta de Pasajes, con los siguientes datos. <br />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>
				        <h2 style=""color: #2e6c80;"">Informacion:</h2>
				        <p style = ""text-align: center;"" > &nbsp;</p>
                             <table class=""editorDemoTable"" style=""margin-left: auto; margin-right: auto;"">
				        <thead>
				        <tr>
				        <td>Campo</td>
				        <td>Detalle</td>
				        <td>Check</td>
				        </tr>
				        </thead>
				        <tbody>
				        <tr>
				        <td>Solicitud</td>
				        <td><span id = ""demoId"" >" + datos1[3] +
                            @"</span></td>
                        <td><strong style =""font-size: 17px; color: #2b2301;""> x </strong></td>
                        </tr>
                        <tr>
                        <td> Nombre / Razon Social </td>
                        <td><span id =""demoId"">" + datos1[4] +
                             @"</span></td>
                        <td><strong style =""font-size: 17px; color: #2b2301;""> x </strong></td>
                        </tr>
                        <tr>
                        <td> Counter</td>
                        <td><span id =""demoId"">" + datos1[5] +
                             @"</span></td>
                        <td><strong style =""font-size: 17px; color: #2b2301;""> x </strong></td>
                        </tr>
                        <tr>
                        <td> Motivo </td>
                        <td><span id =""demoId"">" + datos1[6] +
                            @"</span></td>
				        <td><strong style=""font - size: 17px; color: #2b2301;"">x</strong></td>
				        </tr>
                        </tbody>
                        </table>
                        <p><strong>&nbsp;</strong></p>
                        <p><strong>Por favor ingresar al Portal AmasCuotas e Ingresar la bandeja de Solicitudes </strong><br /><strong>" + datos1[7] + "</strong></p>";
                    }
                    //PV_DETALLE_CORREO = (string)db1.GetParameterValue(cmd, "PV_DETALLE_CORREO");


                }
                  

                if (string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                { PV_ERROR = ""; }
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");
                if (string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                { PV_ESTADOPR = ""; }
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                { PV_DESCRIPCIONPR = ""; }
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_COD_SOLICITUD_DETALLEOUT").ToString()))
                { PV_COD_SOLICITUD_DETALLEOUT = ""; }
                else
                    PV_COD_SOLICITUD_DETALLEOUT = (string)db1.GetParameterValue(cmd, "PV_COD_SOLICITUD_DETALLEOUT");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //    0                   1                         2                            3                   4                   5                   6
                //'APROBADO'+'|'+@VV_RAZONSOCIAL+'|'+CAST(@VD_FECHA AS VARCHAR(45))+'|'+@VV_COD_SOLICITUD+'|'+@VV_RAZONSOCIAL+'|'+@VV_NOMBRECOMPLETO+'|'+@PV_DETALLE+'|'+@VV_URL;
                //'RECHAZADO'+'|'+@VV_RAZONSOCIAL+'|'+CAST(@VD_FECHA AS VARCHAR(45))+'|'+@VV_COD_SOLICITUD+'|'+@VV_RAZONSOCIAL+'|'+@VV_NOMBRECOMPLETO+'|'+@PV_DETALLE+'|'+@VV_URL;
                resultado = PV_EMAIL + "|" + PV_DETALLE_CORREO  + "|" + PV_DESCRIPCIONPR+"|"+ PV_COD_SOLICITUD_DETALLEOUT; //+ "|" + PV_ERROR + "|" + PV_ESTADOPR 
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar";
                return resultado;
            }
        }

        #endregion
    }
}