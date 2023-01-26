using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace appAmascuotas.Clases
{
    public class solicitudes
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_COD_SOLICITUD = "";
        private string _PV_RUTA_ORIGEN = "";
        private string _PV_RUTA_DESTINO = "";
        private string _PV_TIPO_RUTA = "";
        private int _PI_CANT_PASAJES =0;
        private decimal _PD_VALOR_PASAJE = 0;
        private decimal _PD_CUOTA_INICIAL = 0;
        private decimal _PD_MONTO_FINANCIADO = 0;
        private int _PI_PLAZO_MES = 0;
        private string _PV_OBSERVACION = "";
        private string _PV_COD_CLIENTE = "";
        private string _PV_MOTIVO = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADO = "";
        private string _PV_COD_SOLICITUD_DETALLE = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_COD_SOLICITUD { get { return _PV_COD_SOLICITUD; } set { _PV_COD_SOLICITUD = value; } }
        public string PV_RUTA_ORIGEN { get { return _PV_RUTA_ORIGEN; } set { _PV_RUTA_ORIGEN = value; } }
        public string PV_RUTA_DESTINO { get { return _PV_RUTA_DESTINO; } set { _PV_RUTA_DESTINO = value; } }
        public string PV_TIPO_RUTA { get { return _PV_TIPO_RUTA; } set { _PV_TIPO_RUTA = value; } }
        public int PI_CANT_PASAJES { get { return _PI_CANT_PASAJES; } set { _PI_CANT_PASAJES = value; } }
        public decimal PD_VALOR_PASAJE { get { return _PD_VALOR_PASAJE; } set { _PD_VALOR_PASAJE = value; } }
        public decimal PD_CUOTA_INICIAL { get { return _PD_CUOTA_INICIAL; } set { _PD_CUOTA_INICIAL = value; } }
        public decimal PD_MONTO_FINANCIADO { get { return _PD_MONTO_FINANCIADO; } set { _PD_MONTO_FINANCIADO = value; } }

        public int PI_PLAZO_MES { get { return _PI_PLAZO_MES; } set { _PI_PLAZO_MES = value; } }
        public string PV_OBSERVACION { get { return _PV_OBSERVACION; } set { _PV_OBSERVACION = value; } }
        public string PV_COD_CLIENTE { get { return _PV_COD_CLIENTE; } set { _PV_COD_CLIENTE = value; } }
        public string PV_MOTIVO { get { return _PV_MOTIVO; } set { _PV_MOTIVO = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADO { get { return _PV_ESTADO; } set { _PV_ESTADO = value; } }
        public string PV_COD_SOLICITUD_DETALLE { get { return _PV_COD_SOLICITUD_DETALLE; } set { _PV_COD_SOLICITUD_DETALLE = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public solicitudes(string pV_COD_SOLICITUD)
        {
            _PV_COD_SOLICITUD = pV_COD_SOLICITUD;
            RecuperarDatos();
        }
        public solicitudes(string pV_TIPO_OPERACION, string pV_COD_SOLICITUD, string pV_RUTA_ORIGEN,
            string pV_RUTA_DESTINO, string pV_TIPO_RUTA, int pI_CANT_PASAJES, decimal pD_VALOR_PASAJE,
            decimal pD_CUOTA_INICIAL, decimal pD_MONTO_FINANCIADO,
         int pI_PLAZO_MES, string pV_OBSERVACION, string pV_COD_CLIENTE, string pV_MOTIVO,  string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_COD_SOLICITUD = pV_COD_SOLICITUD;
            _PV_RUTA_ORIGEN = pV_RUTA_ORIGEN;
            _PV_RUTA_DESTINO = pV_RUTA_DESTINO;
            _PV_TIPO_RUTA = pV_TIPO_RUTA;
            _PI_CANT_PASAJES = pI_CANT_PASAJES;
            _PD_VALOR_PASAJE = pD_VALOR_PASAJE;
            _PD_CUOTA_INICIAL = pD_CUOTA_INICIAL;
            _PD_MONTO_FINANCIADO = pD_MONTO_FINANCIADO;
            _PI_PLAZO_MES = pI_PLAZO_MES;
            _PV_OBSERVACION = pV_OBSERVACION;
            _PV_COD_CLIENTE = pV_COD_CLIENTE;
            _PV_MOTIVO = pV_MOTIVO;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista_solcitiudes_cliente(string pV_COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_SOLICITUDES");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, pV_COD_CLIENTE);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable GET_SOLICITUDES_IND(string pV_COD_SOLICITUD)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_SOLICITUDES_IND");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, pV_COD_SOLICITUD);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_PAISDEPTO(string pV_COD_SOLICITUD)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_PAISDEPTO");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, pV_COD_SOLICITUD);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable GET_NUMEROS_COMPROBANTES(string pV_COD_SOLICITUD)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_NUMEROS_COMPROBANTES");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, pV_COD_SOLICITUD);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable GET_SOLICITUDES_FLUJO(string pV_ESTADO,string pV_USUARIO)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_SOLICITUDES_FLUJO");
            db1.AddInParameter(cmd, "PV_ESTADO", DbType.String, null);
            db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, pV_USUARIO);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_DATOS_PLANPAGO_CABECERA_SOLI(string pV_COD_SOLICITUD)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_PLANPAGO_CABECERA_SOLI");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, pV_COD_SOLICITUD);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_DATOS_PLANPAGO_SOLICITUD(string pV_COD_SOLICITUD)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_PLANPAGO_SOLICITUD");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, pV_COD_SOLICITUD);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable GET_REPRESENTANTE_LEGAL(string pV_COD_SOLICITUD)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_REPRESENTANTE_LEGAL");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, pV_COD_SOLICITUD);
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
                DbCommand cmd = db1.GetStoredProcCommand("GET_SOLICITUDES_IND");
                db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, _PV_COD_SOLICITUD);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    _PV_RUTA_ORIGEN = dr["RUTA_ORIGEN"].ToString();
                    _PV_RUTA_DESTINO = dr["RUTA_DESTINO"].ToString();
                    _PV_TIPO_RUTA = dr["TIPO_RUTA"].ToString();
                    _PI_CANT_PASAJES = int.Parse(dr["CANT_PASAJES"].ToString());
                    _PD_VALOR_PASAJE = decimal.Parse(dr["VALOR_PASAJE"].ToString());
                    _PD_CUOTA_INICIAL = decimal.Parse( dr["CUOTA_INICIAL"].ToString());
                    _PD_MONTO_FINANCIADO = decimal.Parse( dr["MONTO_FINANCIADO"].ToString());
                    _PI_PLAZO_MES = int.Parse( dr["PLAZO_MES"].ToString());
                    _PV_OBSERVACION = dr["OBSERVACION"].ToString();
                    _PV_ESTADO = dr["ESTADO"].ToString();
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
        //    if (_PV_COD_CLIENTE == "") { _PV_COD_CLIENTE = null; };
        //    if (_PV_MOTIVO == "") { _PV_MOTIVO = null; };
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
        //    _PV_COD_SOLICITUD = pV_COD_SOLICITUD;
        //    _PV_RUTA_ORIGEN = pV_RUTA_ORIGEN;
        //    _PV_RUTA_DESTINO = pV_RUTA_DESTINO;
        //    _PV_TIPO_RUTA = pV_TIPO_RUTA;
        //    _PI_CANT_PASAJES = pI_CANT_PASAJES;
        //    _PD_VALOR_PASAJE = pD_VALOR_PASAJE;
        //    _PD_CUOTA_INICIAL = pD_CUOTA_INICIAL;
        //    _PD_MONTO_FINANCIADO = pD_MONTO_FINANCIADO;
        //    _PI_PLAZO_MES = pI_PLAZO_MES;
        //    _PV_OBSERVACION = pV_OBSERVACION;
        //    _PV_COD_CLIENTE = pV_COD_CLIENTE;
        //    _PV_MOTIVO = pV_MOTIVO;
        //    _PV_USUARIO = pV_USUARIO;
        public string ABM()
        {
            string resultado = "";
            try
            {
                //verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_ABM_SOLICITUD");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, _PV_COD_SOLICITUD);
                db1.AddInParameter(cmd, "PV_RUTA_ORIGEN", DbType.String, _PV_RUTA_ORIGEN);
                db1.AddInParameter(cmd, "PV_RUTA_DESTINO", DbType.String, _PV_RUTA_DESTINO);
                db1.AddInParameter(cmd, "PV_TIPO_RUTA", DbType.String, _PV_TIPO_RUTA);
                db1.AddInParameter(cmd, "PI_CANT_PASAJES", DbType.Int32, _PI_CANT_PASAJES);
                db1.AddInParameter(cmd, "PD_VALOR_PASAJE", DbType.Decimal, _PD_VALOR_PASAJE); 
                db1.AddInParameter(cmd, "PD_CUOTA_INICIAL", DbType.Decimal,  _PD_CUOTA_INICIAL); 
                db1.AddInParameter(cmd, "PD_MONTO_FINANCIADO", DbType.Decimal,  _PD_MONTO_FINANCIADO); 
                db1.AddInParameter(cmd, "PI_PLAZO_MES", DbType.Int32,  _PI_PLAZO_MES); 
                db1.AddInParameter(cmd, "PV_OBSERVACION", DbType.String,  _PV_OBSERVACION); 
                db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String,  _PV_COD_CLIENTE);
                db1.AddInParameter(cmd, "PV_MOTIVO", DbType.String, _PV_MOTIVO);

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                
                db1.AddOutParameter(cmd, "PV_COD_SOLICITUDOUT", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_COD_SOLICITUDDETOUT", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
               
                db1.ExecuteNonQuery(cmd);
                if (string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_COD_SOLICITUDOUT").ToString()))
                    PV_COD_SOLICITUD = "";
                else
                    PV_COD_SOLICITUD = (string)db1.GetParameterValue(cmd, "PV_COD_SOLICITUDOUT");

                if (string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_COD_SOLICITUDDETOUT").ToString()))
                    PV_COD_SOLICITUD_DETALLE = "";
                else
                    PV_COD_SOLICITUD_DETALLE = (string)db1.GetParameterValue(cmd, "PV_COD_SOLICITUDDETOUT");
                //PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");
                //PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (string.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                resultado = PV_COD_SOLICITUD + "|" + PV_DESCRIPCIONPR + "|" + PV_COD_SOLICITUD_DETALLE; //+ "|" + PV_ERROR + "|" + PV_ESTADOPR 
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