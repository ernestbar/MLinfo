using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace appAmascuotas
{
    public class simular
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_COD_CLIENTE = "";
        private string _PV_COD_SIMULADOR = "";
        private decimal _PD_PRESTAMO_BS = 0;
        private decimal _PD_APORTE_PROPIO = 0;
        private int _PV_PLAZO = 0;
        private string _PV_TIPO_CLIENTE = "";
        private string _PV_NOMBRE = "";
        private string _PV_SEGUNDO_NOMBRE = "";
        private string _PV_TERCER_NOMBRE = "";
        private string _PV_APELLIDO_PATERNO = "";
        private string _PV_APELLIDO_MATERNO = "";
        private string _PV_RAZON_SOCIAL = "";
        private string _PV_NUMERO_DOCUMENTO = "";
        private string _PV_EXT = "";
        private string _PV_EXPEDIDO = "";
        private string _PV_TELEFONO_FIJO = "";
        private string _PV_TELEFONO_CELULAR = "";
        private string _PV_EMAIL = "";
        private string _PV_PAGINA_WEB = "";
        private string _PV_NOMBRE_CONTACTO = "";
        private string _PV_CELULAR_CONTACTO = "";
        private string _PV_USUARIO = "";
        private decimal _PD_AMORTIZACION = 0;
        private decimal _PD_SEGURO = 0;
        private decimal _PD_TRE = 0;
        private decimal _PD_TASA_INTERES = 0;
        private decimal _PD_SPREED = 0;
        private decimal _PD_DESGRAVAMEN = 0;
        private decimal _PD_PRIMAANUAL = 0;
        private int _PV_PLAZOAL = 0;
        private decimal _PD_TOTALPASAJE = 0;
        private decimal _PD_SALDOINCIAL = 0;
        private int _PV_TASAPORC = 0;
        private decimal _PD_TOTALPRESTAMO = 0;
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_COD_CLIENTE { get { return _PV_COD_CLIENTE; } set { _PV_COD_CLIENTE = value; } }
        public string PV_COD_SIMULADOR { get { return _PV_COD_SIMULADOR; } set { _PV_COD_SIMULADOR = value; } }
        public decimal PD_PRESTAMO_BS { get { return _PD_PRESTAMO_BS; } set { _PD_PRESTAMO_BS = value; } }
        public decimal PD_APORTE_PROPIO { get { return _PD_APORTE_PROPIO; } set { _PD_APORTE_PROPIO = value; } }
        public int PV_PLAZO { get { return _PV_PLAZO; } set { _PV_PLAZO = value; } }
        public string PV_TIPO_CLIENTE { get { return _PV_TIPO_CLIENTE; } set { _PV_TIPO_CLIENTE = value; } }
        public string PV_NOMBRE { get { return _PV_NOMBRE; } set { _PV_NOMBRE = value; } }
        public string PV_SEGUNDO_NOMBRE { get { return _PV_SEGUNDO_NOMBRE; } set { _PV_SEGUNDO_NOMBRE = value; } }
        public string PV_TERCER_NOMBRE { get { return _PV_TERCER_NOMBRE; } set { _PV_TERCER_NOMBRE = value; } }

        public string PV_APELLIDO_PATERNO { get { return _PV_APELLIDO_PATERNO; } set { _PV_APELLIDO_PATERNO = value; } }
        public string PV_APELLIDO_MATERNO { get { return _PV_APELLIDO_MATERNO; } set { _PV_APELLIDO_MATERNO = value; } }
        public string PV_RAZON_SOCIAL { get { return _PV_RAZON_SOCIAL; } set { _PV_RAZON_SOCIAL = value; } }
        public string PV_NUMERO_DOCUMENTO { get { return _PV_NUMERO_DOCUMENTO; } set { _PV_NUMERO_DOCUMENTO = value; } }
        public string PV_EXPEDIDO { get { return _PV_EXPEDIDO; } set { _PV_EXPEDIDO = value; } }
        public string PV_EXT{ get { return _PV_EXT; } set { _PV_EXT = value; } }
        public string PV_PAGINA_WEB { get { return _PV_PAGINA_WEB; } set { _PV_PAGINA_WEB = value; } }
        public string PV_NOMBRE_CONTACTO { get { return _PV_NOMBRE_CONTACTO; } set { _PV_NOMBRE_CONTACTO = value; } }
        public string PV_CELULAR_CONTACTO { get { return _PV_CELULAR_CONTACTO; } set { _PV_CELULAR_CONTACTO = value; } }
        public string PV_TELEFONO_FIJO { get { return _PV_TELEFONO_FIJO; } set { _PV_TELEFONO_FIJO = value; } }
        public string PV_TELEFONO_CELULAR { get { return _PV_TELEFONO_CELULAR; } set { _PV_TELEFONO_CELULAR = value; } }
        public string PV_EMAIL { get { return _PV_EMAIL; } set { _PV_EMAIL = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public decimal PD_AMORTIZACION { get { return _PD_AMORTIZACION; } set { _PD_AMORTIZACION = value; } }
        public decimal PD_SEGURO { get { return _PD_SEGURO; } set { _PD_SEGURO = value; } }
        public decimal PD_TRE { get { return _PD_TRE; } set { _PD_TRE = value; } }
        public decimal PD_TASA_INTERES { get { return _PD_TASA_INTERES; } set { _PD_TASA_INTERES = value; } }
        public decimal PD_SPREED { get { return _PD_SPREED; } set { _PD_SPREED = value; } }
        public decimal PD_DESGRAVAMEN { get { return _PD_DESGRAVAMEN; } set { _PD_DESGRAVAMEN = value; } }
        public decimal PD_PRIMAANUAL { get { return _PD_PRIMAANUAL; } set { _PD_PRIMAANUAL = value; } }
        public int PV_PLAZOAL { get { return _PV_PLAZOAL; } set { _PV_PLAZOAL = value; } }
        public decimal PD_TOTALPASAJE { get { return _PD_TOTALPASAJE; } set { _PD_TOTALPASAJE = value; } }
        public decimal PD_SALDOINCIAL { get { return _PD_SALDOINCIAL; } set { _PD_SALDOINCIAL = value; } }
        public int PV_TASAPORC { get { return _PV_TASAPORC; } set { _PV_TASAPORC = value; } }
        public decimal PD_TOTALPRESTAMO { get { return _PD_TOTALPRESTAMO; } set { _PD_TOTALPRESTAMO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        //public Simulador(string Cod_sumulador)
        //{

        //    RecuperarDatos();
        //}
        public simular(string pV_COD_CLIENTE, decimal pD_PRESTAMO_BS, int pV_PLAZO, string pV_TIPO_CLIENTE, string pV_NOMBRE,
         string pV_APELLIDO_PATERNO, string pV_APELLIDO_MATERNO, string pV_RAZON_SOCIAL, string pV_NUMERO_DOCUMENTO, string pV_EXPEDIDO,
         string pV_TELEFONO_FIJO, string pV_TELEFONO_CELULAR, string pV_EMAIL, string pV_USUARIO,
         decimal pD_APORTE_PROPIO,string pV_SEGUNDO_NOMBRE,string pV_TERCER_NOMBRE,string pV_EXT,
         string pV_PAGINA_WEB,string pV_NOMBRE_CONTACTO,string pV_CELULAR_CONTACTO)
        {
            _PV_COD_CLIENTE = pV_COD_CLIENTE;
            _PD_PRESTAMO_BS = pD_PRESTAMO_BS;
            _PV_PLAZO = pV_PLAZO;
            _PV_TIPO_CLIENTE = pV_TIPO_CLIENTE;
            _PV_NOMBRE = pV_NOMBRE;
            _PV_APELLIDO_PATERNO = pV_APELLIDO_PATERNO;
            _PV_APELLIDO_MATERNO = pV_APELLIDO_MATERNO;
            _PV_RAZON_SOCIAL = pV_RAZON_SOCIAL;
            _PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
            _PV_EXPEDIDO = pV_EXPEDIDO;
            _PV_TELEFONO_FIJO = pV_TELEFONO_FIJO;
            _PV_TELEFONO_CELULAR = pV_TELEFONO_CELULAR;
            _PV_EMAIL = pV_EMAIL;
            _PV_USUARIO = pV_USUARIO;
            _PD_APORTE_PROPIO = pD_APORTE_PROPIO;
            _PV_SEGUNDO_NOMBRE = pV_SEGUNDO_NOMBRE;
            _PV_TERCER_NOMBRE = pV_TERCER_NOMBRE;
            _PV_EXT = pV_EXT;
            _PV_PAGINA_WEB = pV_PAGINA_WEB;
            _PV_NOMBRE_CONTACTO = pV_NOMBRE_CONTACTO;
            _PV_CELULAR_CONTACTO = pV_CELULAR_CONTACTO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista_clientes_sim()
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CLIENTESSIMULADOR");
            
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista_clientes_detalle(string PV_COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_SIMULADORDETALLE");
            db1.AddInParameter(cmd, "pv_cod_cliente", DbType.String, PV_COD_CLIENTE);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista_plan_pago(string PV_COD_SIMULADOR)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_PLANPAGO");
            db1.AddInParameter(cmd, "PV_COD_SIMULADOR", DbType.String, PV_COD_SIMULADOR);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable Datos_cliente_simuldor(string PV_COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_SIMULADOR");
            db1.AddInParameter(cmd, "pv_cod_cliente", DbType.String, PV_COD_CLIENTE);
            db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, null);
            db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, null);
            db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, null);
            db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, null);
            db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, null);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Datos_cliente_simuldor_x_DOC(string pV_NUMERO_DOCUMENTO)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_SIMULADOR");
            db1.AddInParameter(cmd, "pv_cod_cliente", DbType.String, null);
            db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, null);
            db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, null);
            db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, null);
            db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, null);
            db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, pV_NUMERO_DOCUMENTO);
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
        //private void RecuperarDatos()
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("lista_cliente_individual");
        //        db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
        //        db1.AddOutParameter(cmd, "razon_social", DbType.String, 500);
        //        db1.AddOutParameter(cmd, "nit", DbType.String, 100);
        //        db1.AddOutParameter(cmd, "paterno", DbType.String, 200);
        //        db1.AddOutParameter(cmd, "materno", DbType.String, 200);
        //        db1.AddOutParameter(cmd, "nombre", DbType.String, 200);
        //        db1.AddOutParameter(cmd, "activo", DbType.Boolean, 1);
        //        db1.AddOutParameter(cmd, "id_tipocliente", DbType.Int32, 32);
        //        db1.AddOutParameter(cmd, "id_tiponegocio", DbType.Int32, 32);
        //        db1.AddOutParameter(cmd, "fecha_ini", DbType.DateTime, 30);
        //        db1.AddOutParameter(cmd, "abierto", DbType.Boolean, 1);
        //        db1.AddOutParameter(cmd, "agenda", DbType.Boolean, 1);
        //        db1.AddOutParameter(cmd, "ruta_imagen", DbType.String, 500);
        //        db1.ExecuteNonQuery(cmd);

        //        _razon_social = (string)db1.GetParameterValue(cmd, "razon_social");
        //        _nit = (string)db1.GetParameterValue(cmd, "nit");
        //        _paterno = (string)db1.GetParameterValue(cmd, "paterno");
        //        _materno = (string)db1.GetParameterValue(cmd, "materno");
        //        _nombre = (string)db1.GetParameterValue(cmd, "nombre");
        //        _activo = (Boolean)db1.GetParameterValue(cmd, "activo");
        //        _id_tipocliente = (int)db1.GetParameterValue(cmd, "id_tipocliente");
        //        _id_tiponegocio = (int)db1.GetParameterValue(cmd, "id_tiponegocio");
        //        _fecha_ini = (DateTime)db1.GetParameterValue(cmd, "fecha_ini");
        //        _abierto = (Boolean)db1.GetParameterValue(cmd, "abierto");
        //        _agenda = (Boolean)db1.GetParameterValue(cmd, "agenda");
        //        _ruta_imagen = (string)db1.GetParameterValue(cmd, "ruta_imagen");
        //    }
        //    catch { }
        //}
        public void verificar_vacios()
        {
            if (_PV_COD_CLIENTE == "") { _PV_COD_CLIENTE = null; };
            if (_PV_TIPO_CLIENTE == "")  { _PV_TIPO_CLIENTE = null; };
            if (_PV_NOMBRE == "")  { _PV_NOMBRE = null; };
            if (_PV_SEGUNDO_NOMBRE == "")  { _PV_SEGUNDO_NOMBRE = null; };
            if (_PV_TERCER_NOMBRE == "")  { _PV_TERCER_NOMBRE = null; };
            if (_PV_APELLIDO_PATERNO == "")  { _PV_APELLIDO_PATERNO = null; };
            if (_PV_APELLIDO_MATERNO == "")  { _PV_APELLIDO_MATERNO = null; };
            if (_PV_RAZON_SOCIAL == "")  { _PV_RAZON_SOCIAL = null; };
            if (_PV_NUMERO_DOCUMENTO == "")  { _PV_NUMERO_DOCUMENTO = null; };
            if (_PV_EXT == "")  { _PV_EXT = null; };
            if (_PV_EXPEDIDO == "")  { _PV_EXPEDIDO = null; };
            if (_PV_TELEFONO_FIJO == "")  { _PV_TELEFONO_FIJO = null; };
            if (_PV_TELEFONO_CELULAR == "")  { _PV_TELEFONO_CELULAR = null; };
            if (_PV_EMAIL == "")  { _PV_EMAIL = null; };
            if (_PV_PAGINA_WEB == "")  { _PV_PAGINA_WEB = null; };
            if (_PV_NOMBRE_CONTACTO == "")  { _PV_NOMBRE_CONTACTO = null; };
            if (_PV_CELULAR_CONTACTO == "")  { _PV_CELULAR_CONTACTO = null; };
            if (_PV_USUARIO == "")  { _PV_USUARIO = null; };
            if (_PV_ERROR == "")  { _PV_ERROR = null; };

        }


        public string ABM()
        {
            string resultado = "";
            try
            {
                verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_ABM_SIMULADOR");
                if (_PV_COD_CLIENTE == "") { db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, _PV_COD_CLIENTE); }
                //db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, null);
                db1.AddInParameter(cmd, "PD_PRESTAMO_BS", DbType.Decimal, _PD_PRESTAMO_BS);
                db1.AddInParameter(cmd, "PD_APORTE_PROPIO", DbType.Decimal, _PD_APORTE_PROPIO);//new
                db1.AddInParameter(cmd, "PV_PLAZO", DbType.Int32, _PV_PLAZO);
                db1.AddInParameter(cmd, "PV_TIPO_CLIENTE", DbType.String, _PV_TIPO_CLIENTE);
                if (_PV_TIPO_CLIENTE == "01") { db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, _PV_NOMBRE); }
                
                if (_PV_TIPO_CLIENTE == "01"){ db1.AddInParameter(cmd, "PV_SEGUNDO_NOMBRE", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_SEGUNDO_NOMBRE", DbType.String, _PV_SEGUNDO_NOMBRE); }
                
                if (_PV_TIPO_CLIENTE == "01") { db1.AddInParameter(cmd, "PV_TERCER_NOMBRE", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_TERCER_NOMBRE", DbType.String, _PV_TERCER_NOMBRE); }
                
                if (_PV_TIPO_CLIENTE == "01") { db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, _PV_APELLIDO_PATERNO); }
                
                if (_PV_TIPO_CLIENTE == "01") { db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, _PV_APELLIDO_MATERNO); }
                
                if (_PV_TIPO_CLIENTE == "02") { db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, _PV_RAZON_SOCIAL); }
                
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, _PV_NUMERO_DOCUMENTO);
                
                if (_PV_TIPO_CLIENTE == "01") { db1.AddInParameter(cmd, "PV_EXT", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_EXT", DbType.String, _PV_EXT); }
                
                db1.AddInParameter(cmd, "PV_EXPEDIDO", DbType.String, _PV_EXPEDIDO);
                
                if (_PV_TIPO_CLIENTE == "02") {
                    if (_PV_TELEFONO_FIJO == "") { db1.AddInParameter(cmd, "PV_TELEFONO_FIJO", DbType.String, null); } else { db1.AddInParameter(cmd, "PV_TELEFONO_FIJO", DbType.String, _PV_TELEFONO_FIJO); } }
                else { db1.AddInParameter(cmd, "PV_TELEFONO_FIJO", DbType.String, null); }
                
                if (_PV_TIPO_CLIENTE == "02") { db1.AddInParameter(cmd, "PV_TELEFONO_CELULAR", DbType.String, _PV_TELEFONO_CELULAR); }
                else { db1.AddInParameter(cmd, "PV_TELEFONO_CELULAR", DbType.String, null); }
               
                if (_PV_TIPO_CLIENTE == "02") { db1.AddInParameter(cmd, "PV_EMAIL", DbType.String, _PV_EMAIL); }
                else { db1.AddInParameter(cmd, "PV_EMAIL", DbType.String, null); }
                
                if (_PV_TIPO_CLIENTE == "02") { db1.AddInParameter(cmd, "PV_PAGINA_WEB", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_PAGINA_WEB", DbType.String, _PV_PAGINA_WEB); }
                
                if (_PV_TIPO_CLIENTE == "02") { db1.AddInParameter(cmd, "PV_NOMBRE_CONTACTO", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_NOMBRE_CONTACTO", DbType.String, _PV_NOMBRE_CONTACTO); }
                
                if (_PV_TIPO_CLIENTE == "02") { db1.AddInParameter(cmd, "PV_CELULAR_CONTACTO", DbType.String, null); }
                else { db1.AddInParameter(cmd, "PV_CELULAR_CONTACTO", DbType.String, _PV_CELULAR_CONTACTO); }
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PD_AMORTIZACION", DbType.Decimal, 30);
                db1.AddOutParameter(cmd, "PD_SEGURO", DbType.Decimal, 30);
                db1.AddOutParameter(cmd, "PD_TRE", DbType.Decimal, 30);
                db1.AddOutParameter(cmd, "PD_TASA_INTERES", DbType.Decimal, 45);
                db1.AddOutParameter(cmd, "PD_SPREED", DbType.Decimal, 45);
                db1.AddOutParameter(cmd, "PD_DESGRAVAMEN", DbType.Decimal, 45);//new
                db1.AddOutParameter(cmd, "PD_PRIMAANUAL", DbType.Decimal, 45);//new
                db1.AddOutParameter(cmd, "PV_PLAZOSAL", DbType.Int32, 45);//new
                db1.AddOutParameter(cmd, "PD_TOTALPASAJE", DbType.Decimal, 45);//new
                db1.AddOutParameter(cmd, "PD_SALDOINICIAL", DbType.Decimal, 45);//new
                db1.AddOutParameter(cmd, "PV_TASAPORC", DbType.Int32, 45);//new
                db1.AddOutParameter(cmd, "PD_TOTALPRESTAMO", DbType.Decimal, 45);//new
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_COD_SIMULADOR", DbType.String, 45);
                db1.ExecuteNonQuery(cmd);
                PV_COD_SIMULADOR = (string)db1.GetParameterValue(cmd, "PV_COD_SIMULADOR");
                PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                resultado = PV_COD_SIMULADOR + "|" + PV_DESCRIPCIONPR;
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