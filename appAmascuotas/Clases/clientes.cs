using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appAmascuotas.Clases
{
    public class clientes
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        // JURIDICA
        private string _PV_TIPO_OPERACION = "";
        private string _PV_TIPO_CLIENTE = "";
        private string _PV_COD_CLIENTE = "";
        private string _PV_NOMBRE = "";
        private string _PV_SEGUNDO_NOMBRE = "";
        private string _PV_TERCER_NOMBRE = "";
        private string _PV_APELLIDO_P = "";
        private string _PV_APELLIDO_M = "";
        private string _PV_APELLIDO_MA = "";
        private string _PV_SEXO = "";
        private string _PV_LUG_NAC = "";
        private string _PV_NACIONALIDAD = "";
        private string _PV_PAIS = "";
        private int _PI_EDAD = 0;
        private string _PV_NIVEL_EDUCACION = "";
        private string _PV_ESTADO_CIVIL = "";
        private DateTime _PD_FECHA_FUNNAC = DateTime.Parse("01/01/1900");
        private string _PV_NUMERO_DOCUMENTO = "";
        private string _PV_EXT = "";
        private string _PV_EXPEDIDO = "";
        private string _PV_PROFESION = "";
        private int _PI_NRO_DEPENDIENTES = 0;
        private string _PV_TELEFONO_CELULAR = "";
        private string _PV_EMAIL = "";
        // JURIDICA
        private string _PV_RAZON_SOCIAL = "";
        private string _PV_SOCIEDAD = "";
        private string _PV_ACTIVIDAD = "";
        private string _PV_RUBRO = "";
        private string _PV_GRUPO_ECO = "";
        private string _PV_TELEFONO_FIJO = "";
        private string _PV_PAGINA_WEB = "";
        // CONYUGUE
        private string _PV_COD_CLIENTE_CONYUGUE = "";
        private string _PV_NOMBREC = "";
        private string _PV_SEGUNDO_NOMBREC = "";
        private string _PV_TERCER_NOMBREC = "";
        private string _PV_APELLIDO_PC = "";
        private string _PV_APELLIDO_MC = "";
        private string _PV_APELLIDO_MAC = "";
        private string _PV_SEXOC = "";
        private string _PV_LUG_NACC = "";
        private string _PV_NACIONALIDADC = "";
        private string _PV_PAISC = "";
        private int _PI_EDADC = 0;
        private string _PV_NIVEL_EDUCACIONC = "";
        private string _PV_ESTADO_CIVILC = "";
        private DateTime _PD_FECHA_FUNNACC = DateTime.Parse("01/01/1900");
        private string _PV_NUMERO_DOCUMENTOC = "";
        private string _PV_EXTC = "";
        private string _PV_EXPEDIDOC = "";
        private string _PV_TELEFONO_CELULARC = "";
        private string _PV_EMPRESA_LABORALC = "";
        private string _PV_PROFESIONC = "";
        private string _PV_CARGOC = "";
        private decimal _PI_ANTIGUEDADC = 0;
        private string _PV_TIPOANTIGUEDADC = "";
        private string _PV_DIRECCION_EMPRESAC = "";
        private string _PV_TELEFONO_FIJOC = "";
		private string _PV_EMAILC = "";
        // DIRECCION
        private string _PV_COD_DIRECCION = "";
        private string _PV_TIPO_VIVIENDA = "";
        private string _PV_DETALLE = "";
        private string _PV_BARRIO = "";
        private string _PV_CONDOMINIO = "";
        private string _PV_URBANIZACION = "";
        private string _PV_CIUDAD = "";
        private string _PV_AVENIDA = "";
        private string _PV_CALLE = "";
        private string _PV_PASIILO_CARRETERA = "";
        private string _PV_NRO = "";
        private string _PV_EDIFICIO = "";
        private string _PV_PISO = "";
        private string _PV_NRO_DPTO = "";
        private string _PV_TELEFONO = "";
        private string _PV_REFERENCIA = "";
        private string _PV_LATITUD = "";
        private string _PV_LONGITUD = "";
        private byte[] _PI_IMAGEN;
        // SITUACION LABORAL

        private string _PV_COD_DATO_LABORAL = "";
        private string _PV_SITUACION_LABORAL = "";
        private string _PV_RELACION_LABORAL = "";
        private decimal _PD_ANTIGUEDADSL = 0;
        private string _PV_TIPOANTIGUEDASL = "";
        private string _PV_CARGOSL = "";
        private string _PV_EMPRESASL = "";
        private string _PV_DIRECCIONSL = "";
        private string _PV_TELEFONOSl = "";
        private string _PV_EMAILSL = "";
        private decimal _PD_INGRESO_BSSL = 0;
        // REFERENCIAS
        private string _PV_COD_REFERENCIAREF1 = "";
        private string _PV_TIPO_REFERENCIAREF1 = "";
        private string _PV_NOMBRE_COMPLETOREF1 = "";
        private string _PV_OCUPACIONREF1 = "";
        private string _PV_TELEFONOREF1 = "";

        private string _PV_COD_REFERENCIAREF2 = "";
        private string _PV_TIPO_REFERENCIAREF2 = "";
        private string _PV_NOMBRE_COMPLETOREF2 = "";
        private string _PV_OCUPACIONREF2 = "";
        private string _PV_TELEFONOREF2 = "";

        private string _PV_COD_REFERENCIAREF3 = "";
        private string _PV_TIPO_REFERENCIAREF3 = "";
        private string _PV_NOMBRE_COMPLETOREF3 = "";
        private string _PV_OCUPACIONREF3 = "";
        private string _PV_TELEFONOREF3 = "";
        // BALANCE
        private string _PV_COD_BALANCE = "";
        private decimal _PD_TOTAL_ACTIVOS_SUS = 0;
        private decimal _PD_TOTAL_PASIVOS = 0;
        // INGRESOS EGRESOS
        private string _PV_INGRESOS = "";
        private string _PV_EGRESOS = "";
        // GARANTE
        private string _PV_COD_CLIENTE_GARANTE = "";
        private string _PV_NOMBREG = "";
        private string _PV_SEGUNDO_NOMBREG = "";
        private string _PV_TERCER_NOMBREG = "";
        private string _PV_APELLIDO_PG = "";
        private string _PV_APELLIDO_MG = "";
        private string _PV_APELLIDO_MAG = "";
        private string _PV_SEXOG = "";
        private string _PV_LUG_NACG = "";
        private string _PV_NACIONALIDADG = "";
        private string _PV_PAISG = "";
        private int _PI_EDADG = 0;
        private string _PV_NIVEL_EDUCACIONG = "";
        private string _PV_ESTADO_CIVILG = "";
        private DateTime _PD_FECHA_FUNNACG = DateTime.Parse("01/01/1900");
        private string _PV_NUMERO_DOCUMENTOG = "";
        private string _PV_EXTG = "";
        private string _PV_EXPEDIDOG = "";
        private string _PV_PROFESIONG = "";
        private int _PI_NRO_DEPENDIENTESG = 0;
        private string _PV_TELEFONO_CELULARG = "";
        private string _PV_EMAILG = "";
        // SITUACION LABORAL GARANTE
        private string _PV_COD_DATO_LABORAL_GARANTE = "";
        private string _PV_SITUACION_LABORALG = "";
        private string _PV_RELACION_LABORALG = "";
        private decimal _PD_ANTIGUEDADSLG = 0;
        private string _PV_TIPOANTIGUEDADSLG = "";
        private string _PV_CARGOSLG = "";
        private string _PV_EMPRESASLG = "";
        private string _PV_DIRECCIONSLG = "";
        private string _PV_TELEFONOSlG = "";
        private string _PV_EMAILSLG = "";
        private decimal _PD_INGRESO_BSSLG = 0;
        // REPRESENTANTES LEGALES

        private string _PV_COD_REP_LEGAL1 = "";
        private string _PV_NOMBRE_COMPLETOL1 = "";
        private string _PV_NRO_PODERL1 = "";
        private string _PV_CARGOL1 = "";
        private string _PV_EMAILL1 = "";
        private string _PV_TELEFONOL1 = "";
        private string _PV_NUMERO_DOCUMENTOL1 = "";
        private string _PV_COD_REP_LEGAL2 = "";
        private string _PV_NOMBRE_COMPLETOL2 = "";
        private string _PV_NRO_PODERL2 = "";
        private string _PV_CARGOL2 = "";
        private string _PV_EMAILL2 = "";
        private string _PV_TELEFONOL2 = "";
        private string _PV_NUMERO_DOCUMENTOL2 = "";
        private string _PV_COD_REP_LEGAL3 = "";
        private string _PV_NOMBRE_COMPLETOL3 = "";
        private string _PV_NRO_PODERL3 = "";
        private string _PV_CARGOL3 = "";
        private string _PV_EMAILL3 = "";
        private string _PV_TELEFONOL3 = "";
        private string _PV_NUMERO_DOCUMENTOL3 = "";
        private string _PV_COD_REP_LEGAL4 = "";
        private string _PV_NOMBRE_COMPLETOL4 = "";
        private string _PV_NRO_PODERL4 = "";
        private string _PV_CARGOL4 = "";
        private string _PV_EMAILL4 = "";
        private string _PV_TELEFONOL4 = "";
        private string _PV_NUMERO_DOCUMENTOL4 = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        private string _PV_CODIGO_SOLICITUD = "";
        //Propiedades públicas

        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_TIPO_CLIENTE { get { return _PV_TIPO_CLIENTE; } set { _PV_TIPO_CLIENTE = value; } }
        public string PV_COD_CLIENTE { get { return _PV_COD_CLIENTE; } set { _PV_COD_CLIENTE = value; } }
        public string PV_NOMBRE { get { return _PV_NOMBRE; } set { _PV_NOMBRE = value; } }
        public string PV_SEGUNDO_NOMBRE { get { return _PV_SEGUNDO_NOMBRE; } set { _PV_SEGUNDO_NOMBRE = value; } }
        public string PV_TERCER_NOMBRE { get { return _PV_TERCER_NOMBRE; } set { _PV_TERCER_NOMBRE = value; } }

        public string PV_APELLIDO_P { get { return _PV_APELLIDO_P; } set { _PV_APELLIDO_P = value; } }
        public string PV_APELLIDO_M { get { return _PV_APELLIDO_M; } set { _PV_APELLIDO_M = value; } }
        public string PV_APELLIDO_MA { get { return _PV_APELLIDO_MA; } set { _PV_APELLIDO_MA = value; } }
        public string PV_SEXO { get { return _PV_SEXO; } set { _PV_SEXO = value; } }
        public string PV_LUG_NAC { get { return _PV_LUG_NAC; } set { _PV_LUG_NAC = value; } }
        public string PV_NACIONALIDAD { get { return _PV_NACIONALIDAD; } set { _PV_NACIONALIDAD = value; } }
        public string PV_PAIS { get { return _PV_PAIS; } set { _PV_PAIS = value; } }
        public int PI_EDAD { get { return _PI_EDAD; } set { _PI_EDAD = value; } }
        public string PV_NIVEL_EDUCACION { get { return _PV_NIVEL_EDUCACION; } set { _PV_NIVEL_EDUCACION = value; } }
        public string PV_ESTADO_CIVIL { get { return _PV_ESTADO_CIVIL; } set { _PV_ESTADO_CIVIL = value; } }
        public DateTime PD_FECHA_FUNNAC { get { return _PD_FECHA_FUNNAC; } set { _PD_FECHA_FUNNAC = value; } }
        public string PV_NUMERO_DOCUMENTO { get { return _PV_NUMERO_DOCUMENTO; } set { _PV_NUMERO_DOCUMENTO = value; } }
        public string PV_EXT { get { return _PV_EXT; } set { _PV_EXT = value; } }
        public string PV_EXPEDIDO { get { return _PV_EXPEDIDO; } set { _PV_EXPEDIDO = value; } }
        public string PV_PROFESION { get { return _PV_PROFESION; } set { _PV_PROFESION = value; } }
        public int PI_NRO_DEPENDIENTES { get { return _PI_NRO_DEPENDIENTES; } set { _PI_NRO_DEPENDIENTES = value; } }
        public string PV_TELEFONO_CELULAR { get { return _PV_TELEFONO_CELULAR; } set { _PV_TELEFONO_CELULAR = value; } }
        public string PV_EMAIL { get { return _PV_EMAIL; } set { _PV_EMAIL = value; } }
        // JURIDICA
        public string PV_RAZON_SOCIAL { get { return _PV_RAZON_SOCIAL; } set { _PV_RAZON_SOCIAL = value; } }
        public string PV_SOCIEDAD { get { return _PV_SOCIEDAD; } set { _PV_SOCIEDAD = value; } }
        public string PV_ACTIVIDAD { get { return _PV_ACTIVIDAD; } set { _PV_ACTIVIDAD = value; } }
        public string PV_RUBRO { get { return _PV_RUBRO; } set { _PV_RUBRO = value; } }
        public string PV_GRUPO_ECO { get { return _PV_GRUPO_ECO; } set { _PV_GRUPO_ECO = value; } }
        public string PV_TELEFONO_FIJO { get { return _PV_TELEFONO_FIJO; } set { _PV_TELEFONO_FIJO = value; } }
        public string PV_PAGINA_WEB { get { return _PV_PAGINA_WEB; } set { _PV_PAGINA_WEB = value; } }
        // CONYUGUE
        public string PV_COD_CLIENTE_CONYUGUE { get { return _PV_COD_CLIENTE_CONYUGUE; } set { _PV_COD_CLIENTE_CONYUGUE = value; } }
        public string PV_NOMBREC { get { return _PV_NOMBREC; } set { _PV_NOMBREC = value; } }
        public string PV_SEGUNDO_NOMBREC { get { return _PV_SEGUNDO_NOMBREC; } set { _PV_SEGUNDO_NOMBREC = value; } }
        public string PV_TERCER_NOMBREC { get { return _PV_TERCER_NOMBREC; } set { _PV_TERCER_NOMBREC = value; } }
        public string PV_APELLIDO_PC { get { return _PV_APELLIDO_PC; } set { _PV_APELLIDO_PC = value; } }
        public string PV_APELLIDO_MC { get { return _PV_APELLIDO_MC; } set { _PV_APELLIDO_MC = value; } }
        public string PV_APELLIDO_MAC { get { return _PV_APELLIDO_MAC; } set { _PV_APELLIDO_MAC = value; } }
        public string PV_SEXOC { get { return _PV_SEXOC; } set { _PV_SEXOC = value; } }
        public string PV_LUG_NACC { get { return _PV_LUG_NACC; } set { _PV_LUG_NACC = value; } }
        public string PV_NACIONALIDADC { get { return _PV_NACIONALIDADC; } set { _PV_NACIONALIDADC = value; } }
        public string PV_PAISC { get { return _PV_PAISC; } set { _PV_PAISC = value; } }
        public int PI_EDADC { get { return _PI_EDADC; } set { _PI_EDADC = value; } }
        public string PV_NIVEL_EDUCACIONC { get { return _PV_NIVEL_EDUCACIONC; } set { _PV_NIVEL_EDUCACIONC = value; } }
        public string PV_ESTADO_CIVILC { get { return _PV_ESTADO_CIVILC; } set { _PV_ESTADO_CIVILC = value; } }
        public DateTime PD_FECHA_FUNNACC { get { return _PD_FECHA_FUNNACC; } set { _PD_FECHA_FUNNACC = value; } }
        public string PV_NUMERO_DOCUMENTOC { get { return _PV_NUMERO_DOCUMENTOC; } set { _PV_NUMERO_DOCUMENTOC = value; } }
        public string PV_EXTC { get { return _PV_EXTC; } set { _PV_EXTC = value; } }
        public string PV_EXPEDIDOC { get { return _PV_EXPEDIDOC; } set { _PV_EXPEDIDOC = value; } }
        public string PV_TELEFONO_CELULARC { get { return _PV_TELEFONO_CELULARC; } set { _PV_TELEFONO_CELULARC = value; } }
        public string PV_EMPRESA_LABORALC { get { return _PV_EMPRESA_LABORALC; } set { _PV_EMPRESA_LABORALC = value; } }
        public string PV_PROFESIONC { get { return _PV_PROFESIONC; } set { _PV_PROFESIONC = value; } }
        public string PV_CARGOC { get { return _PV_CARGOC; } set { _PV_CARGOC = value; } }
        public decimal PI_ANTIGUEDADC { get { return _PI_ANTIGUEDADC; } set { _PI_ANTIGUEDADC = value; } }
        public string PV_TIPOANTIGUEDADC { get { return _PV_TIPOANTIGUEDADC; } set { _PV_TIPOANTIGUEDADC = value; } }
        public string PV_DIRECCION_EMPRESAC { get { return _PV_DIRECCION_EMPRESAC; } set { _PV_DIRECCION_EMPRESAC = value; } }
        public string PV_TELEFONO_FIJOC { get { return _PV_TELEFONO_FIJOC; } set { _PV_TELEFONO_FIJOC = value; } }
        public string PV_EMAILC { get { return _PV_EMAILC; } set { _PV_EMAILC = value; } }
        // DIRECCION
        public string PV_COD_DIRECCION { get { return _PV_COD_DIRECCION; } set { _PV_COD_DIRECCION = value; } }
        public string PV_TIPO_VIVIENDA { get { return _PV_TIPO_VIVIENDA; } set { _PV_TIPO_VIVIENDA = value; } }
        public string PV_DETALLE { get { return _PV_DETALLE; } set { _PV_DETALLE = value; } }
        public string PV_BARRIO { get { return _PV_BARRIO; } set { _PV_BARRIO = value; } }
        public string PV_CONDOMINIO { get { return _PV_CONDOMINIO; } set { _PV_CONDOMINIO = value; } }
        public string PV_URBANIZACION { get { return _PV_URBANIZACION; } set { _PV_URBANIZACION = value; } }
        public string PV_CIUDAD { get { return _PV_CIUDAD; } set { _PV_CIUDAD = value; } }
        public string PV_AVENIDA { get { return _PV_AVENIDA; } set { _PV_AVENIDA = value; } }
        public string PV_CALLE { get { return _PV_CALLE; } set { _PV_CALLE = value; } }
        public string PV_PASIILO_CARRETERA { get { return _PV_PASIILO_CARRETERA; } set { _PV_PASIILO_CARRETERA = value; } }
        public string PV_NRO { get { return _PV_NRO; } set { _PV_NRO = value; } }
        public string PV_EDIFICIO { get { return _PV_EDIFICIO; } set { _PV_EDIFICIO = value; } }
        public string PV_PISO { get { return _PV_PISO; } set { _PV_PISO = value; } }
        public string PV_NRO_DPTO { get { return _PV_NRO_DPTO; } set { _PV_NRO_DPTO = value; } }
        public string PV_TELEFONO { get { return _PV_TELEFONO; } set { _PV_TELEFONO = value; } }
        public string PV_REFERENCIA { get { return _PV_REFERENCIA; } set { _PV_REFERENCIA = value; } }
        public string PV_LATITUD { get { return _PV_LATITUD; } set { _PV_LATITUD = value; } }
        public string PV_LONGITUD { get { return _PV_LONGITUD; } set { _PV_LONGITUD = value; } }
        public byte[] PI_IMAGEN { get { return _PI_IMAGEN; } set { _PI_IMAGEN = value; } }
        // SITUACION LABORAL

        public string PV_COD_DATO_LABORAL { get { return _PV_COD_DATO_LABORAL; } set { _PV_COD_DATO_LABORAL = value; } }
        public string PV_SITUACION_LABORAL { get { return _PV_SITUACION_LABORAL; } set { _PV_SITUACION_LABORAL = value; } }
        public string PV_RELACION_LABORAL { get { return _PV_RELACION_LABORAL; } set { _PV_RELACION_LABORAL = value; } }
        public decimal PD_ANTIGUEDADSL { get { return _PD_ANTIGUEDADSL; } set { _PD_ANTIGUEDADSL = value; } }
        public string PV_TIPOANTIGUEDASL { get { return _PV_TIPOANTIGUEDASL; } set { _PV_TIPOANTIGUEDASL = value; } }
        public string PV_CARGOSL { get { return _PV_CARGOSL; } set { _PV_CARGOSL = value; } }
        public string PV_EMPRESASL { get { return _PV_EMPRESASL; } set { _PV_EMPRESASL = value; } }
        public string PV_DIRECCIONSL { get { return _PV_DIRECCIONSL; } set { _PV_DIRECCIONSL = value; } }
        public string PV_TELEFONOSl { get { return _PV_TELEFONOSl; } set { _PV_TELEFONOSl = value; } }
        public string PV_EMAILSL { get { return _PV_EMAILSL; } set { _PV_EMAILSL = value; } }
        public decimal PD_INGRESO_BSSL { get { return _PD_INGRESO_BSSL; } set { _PD_INGRESO_BSSL = value; } }
        // REFERENCIAS
        public string PV_COD_REFERENCIAREF1 { get { return _PV_COD_REFERENCIAREF1; } set { _PV_COD_REFERENCIAREF1 = value; } }
        public string PV_TIPO_REFERENCIAREF1 { get { return _PV_TIPO_REFERENCIAREF1; } set { _PV_TIPO_REFERENCIAREF1 = value; } }
        public string PV_NOMBRE_COMPLETOREF1 { get { return _PV_NOMBRE_COMPLETOREF1; } set { _PV_NOMBRE_COMPLETOREF1 = value; } }
        public string PV_OCUPACIONREF1 { get { return _PV_OCUPACIONREF1; } set { _PV_OCUPACIONREF1 = value; } }
        public string PV_TELEFONOREF1 { get { return _PV_TELEFONOREF1; } set { _PV_TELEFONOREF1 = value; } }

        public string PV_COD_REFERENCIAREF2 { get { return _PV_COD_REFERENCIAREF2; } set { _PV_COD_REFERENCIAREF2 = value; } }
        public string PV_TIPO_REFERENCIAREF2 { get { return _PV_TIPO_REFERENCIAREF2; } set { _PV_TIPO_REFERENCIAREF2 = value; } }
        public string PV_NOMBRE_COMPLETOREF2 { get { return _PV_NOMBRE_COMPLETOREF2; } set { _PV_NOMBRE_COMPLETOREF2 = value; } }
        public string PV_OCUPACIONREF2 { get { return _PV_OCUPACIONREF2; } set { _PV_OCUPACIONREF2 = value; } }
        public string PV_TELEFONOREF2 { get { return _PV_TELEFONOREF2; } set { _PV_TELEFONOREF2 = value; } }

        public string PV_COD_REFERENCIAREF3 { get { return _PV_COD_REFERENCIAREF3; } set { _PV_COD_REFERENCIAREF3 = value; } }
        public string PV_TIPO_REFERENCIAREF3 { get { return _PV_TIPO_REFERENCIAREF3; } set { _PV_TIPO_REFERENCIAREF3 = value; } }
        public string PV_NOMBRE_COMPLETOREF3 { get { return _PV_NOMBRE_COMPLETOREF3; } set { _PV_NOMBRE_COMPLETOREF3 = value; } }
        public string PV_OCUPACIONREF3 { get { return _PV_OCUPACIONREF3; } set { _PV_OCUPACIONREF3 = value; } }
        public string PV_TELEFONOREF3 { get { return _PV_TELEFONOREF3; } set { _PV_TELEFONOREF3 = value; } }
        // BALANCE
        public string PV_COD_BALANCE { get { return _PV_COD_BALANCE; } set { _PV_COD_BALANCE = value; } }
        public decimal PD_TOTAL_ACTIVOS_SUS { get { return _PD_TOTAL_ACTIVOS_SUS; } set { _PD_TOTAL_ACTIVOS_SUS = value; } }
        public decimal PD_TOTAL_PASIVOS { get { return _PD_TOTAL_PASIVOS; } set { _PD_TOTAL_PASIVOS = value; } }
        // INGRESOS EGRESOS
        public string PV_INGRESOS { get { return _PV_INGRESOS; } set { _PV_INGRESOS = value; } }
        public string PV_EGRESOS { get { return _PV_EGRESOS; } set { _PV_EGRESOS = value; } }
        // GARANTE
        public string PV_COD_CLIENTE_GARANTE { get { return _PV_COD_CLIENTE_GARANTE; } set { _PV_COD_CLIENTE_GARANTE = value; } }
        public string PV_NOMBREG { get { return _PV_NOMBREG; } set { _PV_NOMBREG = value; } }
        public string PV_SEGUNDO_NOMBREG { get { return _PV_SEGUNDO_NOMBREG; } set { _PV_SEGUNDO_NOMBREG = value; } }
        public string PV_TERCER_NOMBREG { get { return _PV_TERCER_NOMBREG; } set { _PV_TERCER_NOMBREG = value; } }
        public string PV_APELLIDO_PG { get { return _PV_APELLIDO_PG; } set { _PV_APELLIDO_PG = value; } }
        public string PV_APELLIDO_MG { get { return _PV_APELLIDO_MG; } set { _PV_APELLIDO_MG = value; } }
        public string PV_APELLIDO_MAG { get { return _PV_APELLIDO_MAG; } set { _PV_APELLIDO_MAG = value; } }
        public string PV_SEXOG { get { return _PV_SEXOG; } set { _PV_SEXOG = value; } }
        public string PV_LUG_NACG { get { return _PV_LUG_NACG; } set { _PV_LUG_NACG = value; } }
        public string PV_NACIONALIDADG { get { return _PV_NACIONALIDADG; } set { _PV_NACIONALIDADG = value; } }
        public string PV_PAISG { get { return _PV_PAISG; } set { _PV_PAISG = value; } }
        public int PI_EDADG { get { return _PI_EDADG; } set { _PI_EDADG = value; } }
        public string PV_NIVEL_EDUCACIONG { get { return _PV_NIVEL_EDUCACIONG; } set { _PV_NIVEL_EDUCACIONG = value; } }
        public string PV_ESTADO_CIVILG { get { return _PV_ESTADO_CIVILG; } set { _PV_ESTADO_CIVILG = value; } }
        public DateTime PD_FECHA_FUNNACG { get { return _PD_FECHA_FUNNACG; } set { _PD_FECHA_FUNNACG = value; } }
        public string PV_NUMERO_DOCUMENTOG { get { return _PV_NUMERO_DOCUMENTOG; } set { _PV_NUMERO_DOCUMENTOG = value; } }
        public string PV_EXTG { get { return _PV_EXTG; } set { _PV_EXTG = value; } }
        public string PV_EXPEDIDOG { get { return _PV_EXPEDIDOG; } set { _PV_EXPEDIDOG = value; } }
        public string PV_PROFESIONG { get { return _PV_PROFESIONG; } set { _PV_PROFESIONG = value; } }
        public int PI_NRO_DEPENDIENTESG { get { return _PI_NRO_DEPENDIENTESG; } set { _PI_NRO_DEPENDIENTESG = value; } }
        public string PV_TELEFONO_CELULARG { get { return _PV_TELEFONO_CELULARG; } set { _PV_TELEFONO_CELULARG = value; } }
        public string PV_EMAILG { get { return _PV_EMAILG; } set { _PV_EMAILG = value; } }
        // SITUACION LABORAL GARANTE
        public string PV_COD_DATO_LABORAL_GARANTE { get { return _PV_COD_DATO_LABORAL_GARANTE; } set { _PV_COD_DATO_LABORAL_GARANTE = value; } }
        public string PV_SITUACION_LABORALG { get { return _PV_SITUACION_LABORALG; } set { _PV_SITUACION_LABORALG = value; } }
        public string PV_RELACION_LABORALG { get { return _PV_RELACION_LABORALG; } set { _PV_RELACION_LABORALG = value; } }
        public decimal PD_ANTIGUEDADSLG { get { return _PD_ANTIGUEDADSLG; } set { _PD_ANTIGUEDADSLG = value; } }
        public string PV_TIPOANTIGUEDADSLG { get { return _PV_TIPOANTIGUEDADSLG; } set { _PV_TIPOANTIGUEDADSLG = value; } }
        public string PV_CARGOSLG { get { return _PV_CARGOSLG; } set { _PV_CARGOSLG = value; } }
        public string PV_EMPRESASLG { get { return _PV_EMPRESASLG; } set { _PV_EMPRESASLG = value; } }
        public string PV_DIRECCIONSLG { get { return _PV_DIRECCIONSLG; } set { _PV_DIRECCIONSLG = value; } }
        public string PV_TELEFONOSlG { get { return _PV_TELEFONOSlG; } set { _PV_TELEFONOSlG = value; } }
        public string PV_EMAILSLG { get { return _PV_EMAILSLG; } set { _PV_EMAILSLG = value; } }
        public decimal PD_INGRESO_BSSLG { get { return _PD_INGRESO_BSSLG; } set { _PD_INGRESO_BSSLG = value; } }
        // REPRESENTANTES LEGALES

        public string PV_COD_REP_LEGAL1 { get { return _PV_COD_REP_LEGAL1; } set { _PV_COD_REP_LEGAL1 = value; } }
        public string PV_NOMBRE_COMPLETOL1 { get { return _PV_NOMBRE_COMPLETOL1; } set { _PV_NOMBRE_COMPLETOL1 = value; } }
        public string PV_NRO_PODERL1 { get { return _PV_NRO_PODERL1; } set { _PV_NRO_PODERL1 = value; } }
        public string PV_CARGOL1 { get { return _PV_CARGOL1; } set { _PV_CARGOL1 = value; } }
        public string PV_EMAILL1 { get { return _PV_EMAILL1; } set { _PV_EMAILL1 = value; } }
        public string PV_TELEFONOL1 { get { return _PV_TELEFONOL1; } set { _PV_TELEFONOL1 = value; } }
        public string PV_NUMERO_DOCUMENTOL1 { get { return _PV_NUMERO_DOCUMENTOL1; } set { _PV_NUMERO_DOCUMENTOL1 = value; } }
        public string PV_COD_REP_LEGAL2 { get { return _PV_COD_REP_LEGAL2; } set { _PV_COD_REP_LEGAL2 = value; } }
        public string PV_NOMBRE_COMPLETOL2 { get { return _PV_NOMBRE_COMPLETOL2; } set { _PV_NOMBRE_COMPLETOL2 = value; } }
        public string PV_NRO_PODERL2 { get { return _PV_NRO_PODERL2; } set { _PV_NRO_PODERL2 = value; } }
        public string PV_CARGOL2 { get { return _PV_CARGOL2; } set { _PV_CARGOL2 = value; } }
        public string PV_EMAILL2 { get { return _PV_EMAILL2; } set { _PV_EMAILL2 = value; } }
        public string PV_TELEFONOL2 { get { return _PV_TELEFONOL2; } set { _PV_TELEFONOL2 = value; } }
        public string PV_NUMERO_DOCUMENTOL2 { get { return _PV_NUMERO_DOCUMENTOL2; } set { _PV_NUMERO_DOCUMENTOL2 = value; } }
        public string PV_COD_REP_LEGAL3 { get { return _PV_COD_REP_LEGAL3; } set { _PV_COD_REP_LEGAL3 = value; } }
        public string PV_NOMBRE_COMPLETOL3 { get { return _PV_NOMBRE_COMPLETOL3; } set { _PV_NOMBRE_COMPLETOL3 = value; } }
        public string PV_NRO_PODERL3 { get { return _PV_NRO_PODERL3; } set { _PV_NRO_PODERL3 = value; } }
        public string PV_CARGOL3 { get { return _PV_CARGOL3; } set { _PV_CARGOL3 = value; } }
        public string PV_EMAILL3 { get { return _PV_EMAILL3; } set { _PV_EMAILL3 = value; } }
        public string PV_TELEFONOL3 { get { return _PV_TELEFONOL3; } set { _PV_TELEFONOL3 = value; } }
        public string PV_NUMERO_DOCUMENTOL3 { get { return _PV_NUMERO_DOCUMENTOL3; } set { _PV_NUMERO_DOCUMENTOL3 = value; } }
        public string PV_COD_REP_LEGAL4 { get { return _PV_COD_REP_LEGAL4; } set { _PV_COD_REP_LEGAL4 = value; } }
        public string PV_NOMBRE_COMPLETOL4 { get { return _PV_NOMBRE_COMPLETOL4; } set { _PV_NOMBRE_COMPLETOL4 = value; } }
        public string PV_NRO_PODERL4 { get { return _PV_NRO_PODERL4; } set { _PV_NRO_PODERL4 = value; } }
        public string PV_CARGOL4 { get { return _PV_CARGOL4; } set { _PV_CARGOL4 = value; } }
        public string PV_EMAILL4 { get { return _PV_EMAILL4; } set { _PV_EMAILL4 = value; } }
        public string PV_TELEFONOL4 { get { return _PV_TELEFONOL4; } set { _PV_TELEFONOL4 = value; } }
        public string PV_NUMERO_DOCUMENTOL4 { get { return _PV_NUMERO_DOCUMENTOL4; } set { _PV_NUMERO_DOCUMENTOL4 = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
       
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        public string PV_CODIGO_SOLICITUD { get { return _PV_CODIGO_SOLICITUD; } set { _PV_CODIGO_SOLICITUD = value; } }
        #endregion

        #region Constructores
        //public Simulador(string Cod_sumulador)
        //{

        //    RecuperarDatos();
        //}
        public clientes( string pV_TIPO_OPERACION ,  string pV_TIPO_CLIENTE ,  string pV_COD_CLIENTE ,
            string pV_NOMBRE , string pV_SEGUNDO_NOMBRE, string pV_TERCER_NOMBRE,
        string pV_APELLIDO_P ,string pV_APELLIDO_M ,string pV_APELLIDO_MA ,
        string pV_SEXO ,string pV_LUG_NAC , string pV_NACIONALIDAD, 
        string pV_PAIS, int pI_EDAD,string pV_NIVEL_EDUCACION ,
        string pV_ESTADO_CIVIL , DateTime pD_FECHA_FUNNAC,string pV_NUMERO_DOCUMENTO , 
        string pV_EXT, string pV_EXPEDIDO ,string pV_PROFESION ,
        int pI_NRO_DEPENDIENTES,string pV_TELEFONO_CELULAR , string pV_EMAIL ,
        string pV_RAZON_SOCIAL ,  string pV_SOCIEDAD , string pV_ACTIVIDAD ,
        string pV_RUBRO ,string pV_GRUPO_ECO ,  string pV_TELEFONO_FIJO ,
        string pV_PAGINA_WEB ,string pV_COD_CLIENTE_CONYUGUE , string pV_NOMBREC, 
        string pV_SEGUNDO_NOMBREC, string pV_TERCER_NOMBREC, string pV_APELLIDO_PC ,
        string pV_APELLIDO_MC , string pV_APELLIDO_MAC , string pV_SEXOC ,
        string pV_LUG_NACC , string pV_NACIONALIDADC ,string pV_PAISC,
        int pI_EDADC,string pV_NIVEL_EDUCACIONC , string pV_ESTADO_CIVILC ,
        DateTime pD_FECHA_FUNNACC,string pV_NUMERO_DOCUMENTOC, string pV_EXTC, 
        string pV_EXPEDIDOC ,string pV_TELEFONO_CELULARC , string pV_EMPRESA_LABORALC ,
        string pV_PROFESIONC ,string pV_CARGOC, decimal pI_ANTIGUEDADC ,string pV_TIPOANTIGUEDADC,
        string pV_DIRECCION_EMPRESAC ,string pV_TELEFONO_FIJOC ,string pV_EMAILC ,
        string pV_COD_DIRECCION , string pV_TIPO_VIVIENDA , string pV_DETALLE ,
        string pV_BARRIO ,string pV_CONDOMINIO , string pV_URBANIZACION , 
        string pV_CIUDAD ,string pV_AVENIDA ,  string pV_CALLE ,
        string pV_PASIILO_CARRETERA ,string pV_NRO , string pV_EDIFICIO ,
        string pV_PISO ,string pV_NRO_DPTO , string pV_TELEFONO ,
        string pV_REFERENCIA , string pV_LATITUD , string pV_LONGITUD ,byte[] pI_IMAGEN,
        string pV_COD_DATO_LABORAL ,string pV_SITUACION_LABORAL , string pV_RELACION_LABORAL ,
        decimal pD_ANTIGUEDADSL, string pV_TIPOANTIGUEDASL, string pV_CARGOSL , string pV_EMPRESASL ,
        string pV_DIRECCIONSL ,string pV_TELEFONOSl , string pV_EMAILSL ,
        decimal pD_INGRESO_BSSL, string pV_COD_REFERENCIAREF1 ,string pV_TIPO_REFERENCIAREF1 ,
        string pV_NOMBRE_COMPLETOREF1 , string pV_OCUPACIONREF1 , string pV_TELEFONOREF1 ,
        string pV_COD_REFERENCIAREF2 ,string pV_TIPO_REFERENCIAREF2 , string pV_NOMBRE_COMPLETOREF2 ,
        string pV_OCUPACIONREF2 ,string pV_TELEFONOREF2 , string pV_COD_REFERENCIAREF3 ,
        string pV_TIPO_REFERENCIAREF3 ,string pV_NOMBRE_COMPLETOREF3 ,
        string pV_OCUPACIONREF3 ,string pV_TELEFONOREF3 , string pV_COD_BALANCE ,
        decimal pD_TOTAL_ACTIVOS_SUS, decimal pD_TOTAL_PASIVOS,string pV_INGRESOS ,
        string pV_EGRESOS ,string pV_COD_CLIENTE_GARANTE ,string pV_NOMBREG, 
        string pV_SEGUNDO_NOMBREG, string pV_TERCER_NOMBREG, string pV_APELLIDO_PG ,
        string pV_APELLIDO_MG ,string pV_APELLIDO_MAG ,string pV_SEXOG ,
        string pV_LUG_NACG , string pV_NACIONALIDADG, string pV_PAISG, 
        int pI_EDADG,string pV_NIVEL_EDUCACIONG , string pV_ESTADO_CIVILG ,
        DateTime pD_FECHA_FUNNACG,string pV_NUMERO_DOCUMENTOG, string pV_EXTG, 
        string pV_EXPEDIDOG ,string pV_PROFESIONG , int pI_NRO_DEPENDIENTESG,
        string pV_TELEFONO_CELULARG ,string pV_EMAILG ,string pV_COD_DATO_LABORAL_GARANTE ,
        string pV_SITUACION_LABORALG ,string pV_RELACION_LABORALG ,
        decimal pD_ANTIGUEDADSLG, string pV_TIPOANTIGUEDADSLG, string pV_CARGOSLG , string pV_EMPRESASLG ,
        string pV_DIRECCIONSLG ,string pV_TELEFONOSlG , string pV_EMAILSLG ,
        decimal pD_INGRESO_BSSLG,string pV_COD_REP_LEGAL1 , string pV_NOMBRE_COMPLETOL1 ,
        string pV_NRO_PODERL1 ,string pV_CARGOL1 ,  string pV_EMAILL1 ,
        string pV_TELEFONOL1 ,string pV_NUMERO_DOCUMENTOL1 , string pV_COD_REP_LEGAL2 ,
        string pV_NOMBRE_COMPLETOL2 ,string pV_NRO_PODERL2 , string pV_CARGOL2 , 
        string pV_EMAILL2 ,string pV_TELEFONOL2, string pV_NUMERO_DOCUMENTOL2 ,
        string pV_COD_REP_LEGAL3 ,string pV_NOMBRE_COMPLETOL3 , string pV_NRO_PODERL3 ,
        string pV_CARGOL3 ,string pV_EMAILL3 , string pV_TELEFONOL3 ,
        string pV_NUMERO_DOCUMENTOL3 ,string pV_COD_REP_LEGAL4 , string pV_NOMBRE_COMPLETOL4 , 
        string pV_NRO_PODERL4 ,string pV_CARGOL4 , string pV_EMAILL4 ,
        string pV_TELEFONOL4 , string pV_NUMERO_DOCUMENTOL4 ,string pV_USUARIO ,string pV_CODIGO_SOLICITUD)
        {
              _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
          _PV_TIPO_CLIENTE = pV_TIPO_CLIENTE;
          _PV_COD_CLIENTE = pV_COD_CLIENTE;
          _PV_NOMBRE = pV_NOMBRE;
            _PV_SEGUNDO_NOMBRE = pV_SEGUNDO_NOMBRE;
            _PV_TERCER_NOMBRE = pV_TERCER_NOMBRE;
            _PV_APELLIDO_P = pV_APELLIDO_P;
          _PV_APELLIDO_M = pV_APELLIDO_M;
          _PV_APELLIDO_MA = pV_APELLIDO_MA;
          _PV_SEXO = pV_SEXO;
          _PV_LUG_NAC = pV_LUG_NAC;
          _PV_NACIONALIDAD = pV_NACIONALIDAD;
            _PV_PAIS = pV_PAIS;
            _PI_EDAD = pI_EDAD;
          _PV_NIVEL_EDUCACION = pV_NIVEL_EDUCACION;
          _PV_ESTADO_CIVIL = pV_ESTADO_CIVIL;
            _PD_FECHA_FUNNAC = pD_FECHA_FUNNAC;
          _PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
            _PV_EXT = pV_EXT;
            _PV_EXPEDIDO = pV_EXPEDIDO;
          _PV_PROFESION = pV_PROFESION;
          _PI_NRO_DEPENDIENTES = pI_NRO_DEPENDIENTES;
          _PV_TELEFONO_CELULAR = pV_TELEFONO_CELULAR;
          _PV_EMAIL = pV_EMAIL;
          _PV_RAZON_SOCIAL = pV_RAZON_SOCIAL;
          _PV_SOCIEDAD = pV_SOCIEDAD;
          _PV_ACTIVIDAD = pV_ACTIVIDAD;
          _PV_RUBRO = pV_RUBRO;
          _PV_GRUPO_ECO = pV_GRUPO_ECO;
          _PV_TELEFONO_FIJO = pV_TELEFONO_FIJO;
          _PV_PAGINA_WEB = pV_PAGINA_WEB;
          _PV_COD_CLIENTE_CONYUGUE = pV_COD_CLIENTE_CONYUGUE;
          _PV_NOMBREC = pV_NOMBREC;
            _PV_SEGUNDO_NOMBREC = pV_SEGUNDO_NOMBREC;
            _PV_TERCER_NOMBREC = pV_TERCER_NOMBREC;
            _PV_APELLIDO_PC = pV_APELLIDO_PC;
          _PV_APELLIDO_MC = pV_APELLIDO_MC;
          _PV_APELLIDO_MAC = pV_APELLIDO_MAC;
          _PV_SEXOC = pV_SEXOC;
          _PV_LUG_NACC = pV_LUG_NACC;
          _PV_NACIONALIDADC = pV_NACIONALIDADC;
            _PV_PAISC = pV_PAISC;
            _PI_EDADC = pI_EDADC;
          _PV_NIVEL_EDUCACIONC = pV_NIVEL_EDUCACIONC;
          _PV_ESTADO_CIVILC = pV_ESTADO_CIVILC;
         _PD_FECHA_FUNNACC = pD_FECHA_FUNNACC;
          _PV_NUMERO_DOCUMENTOC = pV_NUMERO_DOCUMENTOC;
            _PV_EXTC = pV_EXTC;
            _PV_EXPEDIDOC = pV_EXPEDIDOC;
          _PV_TELEFONO_CELULARC = pV_TELEFONO_CELULARC;
          _PV_EMPRESA_LABORALC = pV_EMPRESA_LABORALC;
          _PV_PROFESIONC = pV_PROFESIONC;
          _PV_CARGOC = pV_CARGOC;
         _PI_ANTIGUEDADC = pI_ANTIGUEDADC;
            _PV_TIPOANTIGUEDADC = pV_TIPOANTIGUEDADC;
            _PV_DIRECCION_EMPRESAC = pV_DIRECCION_EMPRESAC;
          _PV_TELEFONO_FIJOC = pV_TELEFONO_FIJOC;
          _PV_EMAILC = pV_EMAILC;
          _PV_COD_DIRECCION = pV_COD_DIRECCION;
          _PV_TIPO_VIVIENDA = pV_TIPO_VIVIENDA;
          _PV_DETALLE = pV_DETALLE;
          _PV_BARRIO = pV_BARRIO;
          _PV_CONDOMINIO = pV_CONDOMINIO;
          _PV_URBANIZACION = pV_URBANIZACION;
          _PV_CIUDAD = pV_CIUDAD;
          _PV_AVENIDA = pV_AVENIDA;
          _PV_CALLE = pV_CALLE;
          _PV_PASIILO_CARRETERA = pV_PASIILO_CARRETERA;
          _PV_NRO = pV_NRO;
          _PV_EDIFICIO = pV_EDIFICIO;
          _PV_PISO = pV_PISO;
          _PV_NRO_DPTO = pV_NRO_DPTO;
          _PV_TELEFONO = pV_TELEFONO;
          _PV_REFERENCIA = pV_REFERENCIA;
          _PV_LATITUD = pV_LATITUD;
          _PV_LONGITUD = pV_LONGITUD;
            _PI_IMAGEN = pI_IMAGEN;
          _PV_COD_DATO_LABORAL = pV_COD_DATO_LABORAL;
          _PV_SITUACION_LABORAL = pV_SITUACION_LABORAL;
          _PV_RELACION_LABORAL = pV_RELACION_LABORAL;
          _PD_ANTIGUEDADSL = pD_ANTIGUEDADSL;
            _PV_TIPOANTIGUEDASL = pV_TIPOANTIGUEDASL;
            _PV_CARGOSL = pV_CARGOSL;
          _PV_EMPRESASL = pV_EMPRESASL;
          _PV_DIRECCIONSL = pV_DIRECCIONSL;
          _PV_TELEFONOSl = pV_TELEFONOSl;
          _PV_EMAILSL = pV_EMAILSL;
          _PD_INGRESO_BSSL = pD_INGRESO_BSSL;

          _PV_COD_REFERENCIAREF1 = pV_COD_REFERENCIAREF1;
          _PV_TIPO_REFERENCIAREF1 = pV_TIPO_REFERENCIAREF1;
          _PV_NOMBRE_COMPLETOREF1 = pV_NOMBRE_COMPLETOREF1;
          _PV_OCUPACIONREF1 = pV_OCUPACIONREF1;
          _PV_TELEFONOREF1 = pV_TELEFONOREF1;

          _PV_COD_REFERENCIAREF2 = pV_COD_REFERENCIAREF2;
          _PV_TIPO_REFERENCIAREF2 = pV_TIPO_REFERENCIAREF2;
          _PV_NOMBRE_COMPLETOREF2 = pV_NOMBRE_COMPLETOREF2;
          _PV_OCUPACIONREF2 = pV_OCUPACIONREF2;
          _PV_TELEFONOREF2 = pV_TELEFONOREF2;

          _PV_COD_REFERENCIAREF3 = pV_COD_REFERENCIAREF3;
          _PV_TIPO_REFERENCIAREF3 = pV_TIPO_REFERENCIAREF3;
          _PV_NOMBRE_COMPLETOREF3 = pV_NOMBRE_COMPLETOREF3;
          _PV_OCUPACIONREF3 = pV_OCUPACIONREF3;
          _PV_TELEFONOREF3 = pV_TELEFONOREF3;

          _PV_COD_BALANCE = pV_COD_BALANCE;
         _PD_TOTAL_ACTIVOS_SUS = pD_TOTAL_ACTIVOS_SUS;
         _PD_TOTAL_PASIVOS = pD_TOTAL_PASIVOS;
          _PV_INGRESOS = pV_INGRESOS;
          _PV_EGRESOS = pV_EGRESOS;

          _PV_COD_CLIENTE_GARANTE = pV_COD_CLIENTE_GARANTE;
          _PV_NOMBREG = pV_NOMBREG;
            _PV_SEGUNDO_NOMBREG = pV_SEGUNDO_NOMBREG;
            _PV_TERCER_NOMBREG = pV_TERCER_NOMBREG;
            _PV_APELLIDO_PG = pV_APELLIDO_PG;
          _PV_APELLIDO_MG = pV_APELLIDO_MG;
          _PV_APELLIDO_MAG = pV_APELLIDO_MAG;
          _PV_SEXOG = pV_SEXOG;
          _PV_LUG_NACG = pV_LUG_NACG;
          _PV_NACIONALIDADG = pV_NACIONALIDADG;
            _PV_PAISG = pV_PAISG;
            _PI_EDADG = pI_EDADG;
          _PV_NIVEL_EDUCACIONG = pV_NIVEL_EDUCACIONG;
          _PV_ESTADO_CIVILG = pV_ESTADO_CIVILG;
         _PD_FECHA_FUNNACG = pD_FECHA_FUNNACG;
          _PV_NUMERO_DOCUMENTOG = pV_NUMERO_DOCUMENTOG;
            _PV_EXTG = pV_EXTG;
            _PV_EXPEDIDOG = pV_EXPEDIDOG;
          _PV_PROFESIONG = pV_PROFESIONG;
         _PI_NRO_DEPENDIENTESG = pI_NRO_DEPENDIENTESG;
          _PV_TELEFONO_CELULARG = pV_TELEFONO_CELULARG;
          _PV_EMAILG = pV_EMAILG;
          _PV_COD_DATO_LABORAL_GARANTE = pV_COD_DATO_LABORAL_GARANTE;
            _PV_SITUACION_LABORALG = pV_SITUACION_LABORALG;
          _PV_RELACION_LABORALG = pV_RELACION_LABORALG;
         _PD_ANTIGUEDADSLG = pD_ANTIGUEDADSLG;
            _PV_TIPOANTIGUEDADSLG = pV_TIPOANTIGUEDADSLG;
            _PV_CARGOSLG = pV_CARGOSLG;
          _PV_EMPRESASLG = pV_EMPRESASLG;
          _PV_DIRECCIONSLG = pV_DIRECCIONSLG;
          _PV_TELEFONOSlG = pV_TELEFONOSlG;
          _PV_EMAILSLG = pV_EMAILSLG;
         _PD_INGRESO_BSSLG = pD_INGRESO_BSSLG;

          _PV_COD_REP_LEGAL1 = pV_COD_REP_LEGAL1;
          _PV_NOMBRE_COMPLETOL1 = pV_NOMBRE_COMPLETOL1;
          _PV_NRO_PODERL1 = pV_NRO_PODERL1;
          _PV_CARGOL1 = pV_CARGOL1;
          _PV_EMAILL1 = pV_EMAILL1;
          _PV_TELEFONOL1 = pV_TELEFONOL1;
          _PV_NUMERO_DOCUMENTOL1 = pV_NUMERO_DOCUMENTOL1;

          _PV_COD_REP_LEGAL2 = pV_COD_REP_LEGAL2;
          _PV_NOMBRE_COMPLETOL2 = pV_NOMBRE_COMPLETOL2;
          _PV_NRO_PODERL2 = pV_NRO_PODERL2;
          _PV_CARGOL2 = pV_CARGOL2;
          _PV_EMAILL2 = pV_EMAILL2;
          _PV_TELEFONOL2 = pV_TELEFONOL2;
          _PV_NUMERO_DOCUMENTOL2 = pV_NUMERO_DOCUMENTOL2;

          _PV_COD_REP_LEGAL3 = pV_COD_REP_LEGAL3;
          _PV_NOMBRE_COMPLETOL3 = pV_NOMBRE_COMPLETOL3;
          _PV_NRO_PODERL3 = pV_NRO_PODERL3;
          _PV_CARGOL3 = pV_CARGOL3;
          _PV_EMAILL3 = pV_EMAILL3;
          _PV_TELEFONOL3 = pV_TELEFONOL3;
          _PV_NUMERO_DOCUMENTOL3 = pV_NUMERO_DOCUMENTOL3;

          _PV_COD_REP_LEGAL4 = pV_COD_REP_LEGAL4;
          _PV_NOMBRE_COMPLETOL4 = pV_NOMBRE_COMPLETOL4;
          _PV_NRO_PODERL4 = pV_NRO_PODERL4;
          _PV_CARGOL4 = pV_CARGOL4;
          _PV_EMAILL4 = pV_EMAILL4;
          _PV_TELEFONOL4 = pV_TELEFONOL4;
          _PV_NUMERO_DOCUMENTOL4 = pV_NUMERO_DOCUMENTOL4;

          _PV_USUARIO = pV_USUARIO;
            _PV_CODIGO_SOLICITUD = pV_CODIGO_SOLICITUD;
    }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista_clientes_natural()
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CLIENTES_PN");

            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista_clientes_juridica()
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CLIENTES_PJ");

            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable PR_GET_CLIENTE(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CLIENTE");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable PR_GET_REPRESENTANTE_LEGAL(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_REPRESENTANTE_LEGAL");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_DIRECCION(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DIRECCION");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_REFERENCIAS(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_REFERENCIAS");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_BALANCE(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_BALANCE");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_GARANTE(string COD_CLIENTE,string PV_CODIGO_SOLICITUD)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_GARANTE");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            db1.AddInParameter(cmd, "PV_CODIGO_SOLICITUD", DbType.String, PV_CODIGO_SOLICITUD); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_CONYUGUE(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CONYUGUE");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_DATOS_LABORALES(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_LABORALES");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_EGRESOS(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_EGRESOS");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_INGRESOS(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_INGRESOS");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_GET_INGRESOSEGRESOS(string COD_CLIENTE)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_GET_INGRESOSEGRESOS");
            db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, COD_CLIENTE); // Enviar el código del usuario conectado
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



        public string ABM()
        {
            string resultado = "";
            try
            {
                if (_PV_TIPO_OPERACION == "I")
                {
                    verifica_vacios();
                    //_PV_COD_CLIENTE = null;
                    //_PV_COD_CLIENTE_CONYUGUE = null;
                    //_PV_COD_DIRECCION = null;
                    //_PV_COD_DATO_LABORAL = null;
                    //_PV_COD_REFERENCIAREF1 = null;
                    //_PV_COD_REFERENCIAREF2 = null;
                    //_PV_COD_REFERENCIAREF3 = null;
                    //_PV_COD_BALANCE = null;
                    //_PV_COD_CLIENTE_GARANTE = null;
                    //_PV_COD_DATO_LABORAL_GARANTE = null;
                    //_PV_COD_REP_LEGAL1 = null;
                    //_PV_COD_REP_LEGAL2 = null;
                    //_PV_COD_REP_LEGAL3 = null;
                    //_PV_COD_REP_LEGAL4 = null;
                    //if (_PV_NUMERO_DOCUMENTO == "") { _PV_NUMERO_DOCUMENTO = null; }
                    //if (_PV_NUMERO_DOCUMENTOC == "") { _PV_NUMERO_DOCUMENTOC = null; }
                    //if (_PV_NUMERO_DOCUMENTOG == "") { _PV_NUMERO_DOCUMENTOG = null; }
                    //if (_PV_NUMERO_DOCUMENTOL1 == "") { _PV_NUMERO_DOCUMENTOL1 = null; }
                    //if (_PV_NUMERO_DOCUMENTOL2 == "") { _PV_NUMERO_DOCUMENTOL2 = null; }
                    //if (_PV_NUMERO_DOCUMENTOL3 == "") { _PV_NUMERO_DOCUMENTOL3 = null; }
                    //if (_PV_NUMERO_DOCUMENTOL4 == "") { _PV_NUMERO_DOCUMENTOL4 = null; }
                }
                DbCommand cmd = db1.GetStoredProcCommand("PR_ABM_CLIENTES");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_TIPO_CLIENTE", DbType.String, _PV_TIPO_CLIENTE);
                db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, _PV_COD_CLIENTE);
                db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, _PV_NOMBRE);
                db1.AddInParameter(cmd, "PV_SEGUNDO_NOMBRE", DbType.String, _PV_SEGUNDO_NOMBRE);
                db1.AddInParameter(cmd, "PV_TERCER_NOMBRE", DbType.String, _PV_TERCER_NOMBRE);
                db1.AddInParameter(cmd, "PV_APELLIDO_P", DbType.String, _PV_APELLIDO_P);
                db1.AddInParameter(cmd, "PV_APELLIDO_M", DbType.String, _PV_APELLIDO_M);
                db1.AddInParameter(cmd, "PV_APELLIDO_MA", DbType.String, _PV_APELLIDO_MA);
                db1.AddInParameter(cmd, "PV_SEXO", DbType.String, _PV_SEXO);
                db1.AddInParameter(cmd, "PV_LUG_NAC", DbType.String, _PV_LUG_NAC);
                db1.AddInParameter(cmd, "PV_PAIS", DbType.String, _PV_PAIS);
                db1.AddInParameter(cmd, "PV_NACIONALIDAD", DbType.String, _PV_NACIONALIDAD);
                db1.AddInParameter(cmd, "PI_EDAD", DbType.Int32, _PI_EDAD);
                db1.AddInParameter(cmd, "PV_NIVEL_EDUCACION", DbType.String, _PV_NIVEL_EDUCACION);
                db1.AddInParameter(cmd, "PV_ESTADO_CIVIL", DbType.String, _PV_ESTADO_CIVIL);
                if(_PD_FECHA_FUNNAC==DateTime.Parse("01/01/3000"))
                    db1.AddInParameter(cmd, "PD_FECHA_FUNNAC", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "PD_FECHA_FUNNAC", DbType.DateTime, _PD_FECHA_FUNNAC);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, _PV_NUMERO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_EXT", DbType.String, _PV_EXT);
                db1.AddInParameter(cmd, "PV_EXPEDIDO", DbType.String, _PV_EXPEDIDO);
                db1.AddInParameter(cmd, "PV_PROFESION", DbType.String, _PV_PROFESION);
                db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTES", DbType.Int32, _PI_NRO_DEPENDIENTES);
                db1.AddInParameter(cmd, "PV_TELEFONO_CELULAR", DbType.String, _PV_TELEFONO_CELULAR);
                db1.AddInParameter(cmd, "PV_EMAIL", DbType.String, _PV_EMAIL);
                db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, _PV_RAZON_SOCIAL);
                db1.AddInParameter(cmd, "PV_SOCIEDAD", DbType.String, _PV_SOCIEDAD);
                db1.AddInParameter(cmd, "PV_ACTIVIDAD", DbType.String, _PV_ACTIVIDAD);
                db1.AddInParameter(cmd, "PV_RUBRO", DbType.String, _PV_RUBRO);
                db1.AddInParameter(cmd, "PV_GRUPO_ECO", DbType.String, _PV_GRUPO_ECO);
                db1.AddInParameter(cmd, "PV_TELEFONO_FIJO", DbType.String, _PV_TELEFONO_FIJO);
                db1.AddInParameter(cmd, "PV_PAGINA_WEB", DbType.String, _PV_PAGINA_WEB);

                db1.AddInParameter(cmd, "PV_COD_CLIENTE_CONYUGUE", DbType.String, _PV_COD_CLIENTE_CONYUGUE);
                db1.AddInParameter(cmd, "PV_NOMBREC", DbType.String, _PV_NOMBREC);
                db1.AddInParameter(cmd, "PV_SEGUNDO_NOMBREC", DbType.String, _PV_SEGUNDO_NOMBREC);
                db1.AddInParameter(cmd, "PV_TERCER_NOMBREC", DbType.String, _PV_TERCER_NOMBREC);
                db1.AddInParameter(cmd, "PV_APELLIDO_PC", DbType.String, _PV_APELLIDO_PC);
                db1.AddInParameter(cmd, "PV_APELLIDO_MC", DbType.String, _PV_APELLIDO_MC);
                db1.AddInParameter(cmd, "PV_APELLIDO_MAC", DbType.String, _PV_APELLIDO_MAC);
                db1.AddInParameter(cmd, "PV_SEXOC", DbType.String, _PV_SEXOC);
                db1.AddInParameter(cmd, "PV_LUG_NACC", DbType.String, _PV_LUG_NACC);
                db1.AddInParameter(cmd, "PV_NACIONALIDADC", DbType.String, _PV_NACIONALIDADC);
                db1.AddInParameter(cmd, "PV_PAISC", DbType.String, _PV_PAISC);
                db1.AddInParameter(cmd, "PI_EDADC", DbType.Int32, _PI_EDADC);
                db1.AddInParameter(cmd, "PV_NIVEL_EDUCACIONC", DbType.String, _PV_NIVEL_EDUCACIONC);
                db1.AddInParameter(cmd, "PV_ESTADO_CIVILC", DbType.String, _PV_ESTADO_CIVILC);
                if (_PD_FECHA_FUNNACC == DateTime.Parse("01/01/3000"))
                    db1.AddInParameter(cmd, "PD_FECHA_FUNNACC", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "PD_FECHA_FUNNACC", DbType.DateTime, _PD_FECHA_FUNNACC);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTOC", DbType.String, _PV_NUMERO_DOCUMENTOC);
                db1.AddInParameter(cmd, "PV_EXTC", DbType.String, _PV_EXTC);
                db1.AddInParameter(cmd, "PV_EXPEDIDOC", DbType.String, _PV_EXPEDIDOC);
                db1.AddInParameter(cmd, "PV_TELEFONO_CELULARC", DbType.String, _PV_TELEFONO_CELULARC);
                db1.AddInParameter(cmd, "PV_EMPRESA_LABORALC", DbType.String, _PV_EMPRESA_LABORALC);
                db1.AddInParameter(cmd, "PV_PROFESIONC", DbType.String, _PV_PROFESIONC);
                db1.AddInParameter(cmd, "PV_CARGOC", DbType.String, _PV_CARGOC);
                if(_PI_ANTIGUEDADC==0)
                    db1.AddInParameter(cmd, "PI_ANTIGUEDADC", DbType.Decimal, null);
                else
                    db1.AddInParameter(cmd, "PI_ANTIGUEDADC", DbType.Decimal, _PI_ANTIGUEDADC);

                db1.AddInParameter(cmd, "PV_TIPOANTIGUEDADC", DbType.String, _PV_TIPOANTIGUEDADC);
                db1.AddInParameter(cmd, "PV_DIRECCION_EMPRESAC", DbType.String, _PV_DIRECCION_EMPRESAC);
                db1.AddInParameter(cmd, "PV_TELEFONO_FIJOC", DbType.String, _PV_TELEFONO_FIJOC);
                db1.AddInParameter(cmd, "PV_EMAILC", DbType.String, _PV_EMAILC);
              
                db1.AddInParameter(cmd, "PV_COD_DIRECCION", DbType.String, _PV_COD_DIRECCION);
                db1.AddInParameter(cmd, "PV_TIPO_VIVIENDA", DbType.String, _PV_TIPO_VIVIENDA);
                db1.AddInParameter(cmd, "PV_DETALLE", DbType.String, _PV_DETALLE);
                db1.AddInParameter(cmd, "PV_BARRIO", DbType.String, _PV_BARRIO);
		        db1.AddInParameter(cmd, "PV_CONDOMINIO", DbType.String, _PV_CONDOMINIO);
                db1.AddInParameter(cmd, "PV_URBANIZACION", DbType.String, _PV_URBANIZACION);
                db1.AddInParameter(cmd, "PV_CIUDAD", DbType.String, _PV_CIUDAD);
                db1.AddInParameter(cmd, "PV_AVENIDA", DbType.String, _PV_AVENIDA);
                db1.AddInParameter(cmd, "PV_CALLE", DbType.String, _PV_CALLE);
                db1.AddInParameter(cmd, "PV_PASIILO_CARRETERA", DbType.String, _PV_PASIILO_CARRETERA);
                db1.AddInParameter(cmd, "PV_NRO", DbType.String, _PV_NRO);
                db1.AddInParameter(cmd, "PV_EDIFICIO", DbType.String, _PV_EDIFICIO);
                db1.AddInParameter(cmd, "PV_PISO", DbType.String, _PV_PISO);
                db1.AddInParameter(cmd, "PV_NRO_DPTO", DbType.String, _PV_NRO_DPTO);
                db1.AddInParameter(cmd, "PV_TELEFONO", DbType.String, _PV_TELEFONO);
                db1.AddInParameter(cmd, "PV_REFERENCIA", DbType.String, _PV_REFERENCIA);
                db1.AddInParameter(cmd, "PV_LATITUD", DbType.String, _PV_LATITUD);
                db1.AddInParameter(cmd, "PV_LONGITUD", DbType.String, _PV_LONGITUD);
                db1.AddInParameter(cmd, "PV_IMAGEN", DbType.Binary, _PI_IMAGEN);

                db1.AddInParameter(cmd, "PV_COD_DATO_LABORAL", DbType.String, _PV_COD_DATO_LABORAL);
                db1.AddInParameter(cmd, "PV_SITUACION_LABORAL", DbType.String, _PV_SITUACION_LABORAL);
                db1.AddInParameter(cmd, "PV_RELACION_LABORAL", DbType.String, _PV_RELACION_LABORAL);
                db1.AddInParameter(cmd, "PD_ANTIGUEDADSL", DbType.Decimal, _PD_ANTIGUEDADSL);
                db1.AddInParameter(cmd, "PV_TIPOANTIGUEDADSL", DbType.String, _PV_TIPOANTIGUEDASL);
                db1.AddInParameter(cmd, "PV_CARGOSL", DbType.String, _PV_CARGOSL);
                db1.AddInParameter(cmd, "PV_EMPRESASL", DbType.String, _PV_EMPRESASL);
                db1.AddInParameter(cmd, "PV_DIRECCIONSL", DbType.String, _PV_DIRECCIONSL);
                db1.AddInParameter(cmd, "PV_TELEFONOSl", DbType.String, _PV_TELEFONOSl);
                db1.AddInParameter(cmd, "PV_EMAILSL", DbType.String, _PV_EMAILSL);
                db1.AddInParameter(cmd, "PD_INGRESO_BSSL", DbType.Decimal, _PD_INGRESO_BSSL);
                
                db1.AddInParameter(cmd, "PV_COD_REFERENCIAREF1", DbType.String, _PV_COD_REFERENCIAREF1);
                db1.AddInParameter(cmd, "PV_TIPO_REFERENCIAREF1", DbType.String, _PV_TIPO_REFERENCIAREF1);
                db1.AddInParameter(cmd, "PV_NOMBRE_COMPLETOREF1", DbType.String, _PV_NOMBRE_COMPLETOREF1);
                db1.AddInParameter(cmd, "PV_OCUPACIONREF1", DbType.String, _PV_OCUPACIONREF1);
                db1.AddInParameter(cmd, "PV_TELEFONOREF1", DbType.String, _PV_TELEFONOREF1);

                db1.AddInParameter(cmd, "PV_COD_REFERENCIAREF2", DbType.String, _PV_COD_REFERENCIAREF2);
                db1.AddInParameter(cmd, "PV_TIPO_REFERENCIAREF2", DbType.String, _PV_TIPO_REFERENCIAREF2);
                db1.AddInParameter(cmd, "PV_NOMBRE_COMPLETOREF2", DbType.String, _PV_NOMBRE_COMPLETOREF2);
                db1.AddInParameter(cmd, "PV_OCUPACIONREF2", DbType.String, _PV_OCUPACIONREF2);
                db1.AddInParameter(cmd, "PV_TELEFONOREF2", DbType.String, _PV_TELEFONOREF2);

                db1.AddInParameter(cmd, "PV_COD_REFERENCIAREF3", DbType.String, _PV_COD_REFERENCIAREF3);
                db1.AddInParameter(cmd, "PV_TIPO_REFERENCIAREF3", DbType.String, _PV_TIPO_REFERENCIAREF3);
                db1.AddInParameter(cmd, "PV_NOMBRE_COMPLETOREF3", DbType.String, _PV_NOMBRE_COMPLETOREF3);
                db1.AddInParameter(cmd, "PV_OCUPACIONREF3", DbType.String, _PV_OCUPACIONREF3);
                db1.AddInParameter(cmd, "PV_TELEFONOREF3", DbType.String, _PV_TELEFONOREF3);
                
                db1.AddInParameter(cmd, "PV_COD_BALANCE", DbType.String, _PV_COD_BALANCE);
                db1.AddInParameter(cmd, "PD_TOTAL_ACTIVOS_SUS", DbType.Decimal, _PD_TOTAL_ACTIVOS_SUS);
                db1.AddInParameter(cmd, "PD_TOTAL_PASIVOS", DbType.Decimal, _PD_TOTAL_PASIVOS);
                
                db1.AddInParameter(cmd, "PV_INGRESOS", DbType.String, _PV_INGRESOS);
                db1.AddInParameter(cmd, "PV_EGRESOS", DbType.String, _PV_EGRESOS);

                db1.AddInParameter(cmd, "PV_COD_CLIENTE_GARANTE", DbType.String, _PV_COD_CLIENTE_GARANTE);
                db1.AddInParameter(cmd, "PV_NOMBREG", DbType.String, _PV_NOMBREG);
                db1.AddInParameter(cmd, "PV_SEGUNDO_NOMBREG", DbType.String, _PV_SEGUNDO_NOMBREG);
                db1.AddInParameter(cmd, "PV_TERCER_NOMBREG", DbType.String, _PV_TERCER_NOMBREG);
                db1.AddInParameter(cmd, "PV_APELLIDO_PG", DbType.String, _PV_APELLIDO_PG);
                db1.AddInParameter(cmd, "PV_APELLIDO_MG", DbType.String, _PV_APELLIDO_MG);
                db1.AddInParameter(cmd, "PV_APELLIDO_MAG", DbType.String, _PV_APELLIDO_MAG);
                db1.AddInParameter(cmd, "PV_SEXOG", DbType.String, _PV_SEXOG);
                db1.AddInParameter(cmd, "PV_LUG_NACG", DbType.String, _PV_LUG_NACG);
                db1.AddInParameter(cmd, "PV_NACIONALIDADG", DbType.String, _PV_NACIONALIDADG);
                db1.AddInParameter(cmd, "PV_PAISG", DbType.String, _PV_PAISG);
                db1.AddInParameter(cmd, "PI_EDADG", DbType.Int32, _PI_EDADG);
                db1.AddInParameter(cmd, "PV_NIVEL_EDUCACIONG", DbType.String, _PV_NIVEL_EDUCACIONG);
                db1.AddInParameter(cmd, "PV_ESTADO_CIVILG", DbType.String, _PV_ESTADO_CIVILG);
                if (_PD_FECHA_FUNNACG == DateTime.Parse("01/01/3000"))
                    db1.AddInParameter(cmd, "PD_FECHA_FUNNACG", DbType.DateTime, null);
                else
                    db1.AddInParameter(cmd, "PD_FECHA_FUNNACG", DbType.DateTime, _PD_FECHA_FUNNACG);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTOG", DbType.String, _PV_NUMERO_DOCUMENTOG);
                db1.AddInParameter(cmd, "PV_EXTG", DbType.String, _PV_EXTG);
                db1.AddInParameter(cmd, "PV_EXPEDIDOG", DbType.String, _PV_EXPEDIDOG);
                db1.AddInParameter(cmd, "PV_PROFESIONG", DbType.String, _PV_PROFESIONG);
                db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTESG", DbType.Int32, _PI_NRO_DEPENDIENTESG);
                db1.AddInParameter(cmd, "PV_TELEFONO_CELULARG", DbType.String, _PV_TELEFONO_CELULARG);
                db1.AddInParameter(cmd, "PV_EMAILG", DbType.String, _PV_EMAILG);
             
                db1.AddInParameter(cmd, "PV_COD_DATO_LABORAL_GARANTE", DbType.String, _PV_COD_DATO_LABORAL_GARANTE);
                db1.AddInParameter(cmd, "PV_SITUACION_LABORALG", DbType.String, _PV_SITUACION_LABORALG);
                db1.AddInParameter(cmd, "PV_RELACION_LABORALG", DbType.String, _PV_RELACION_LABORALG);
                if(_PD_ANTIGUEDADSLG==0)
                    db1.AddInParameter(cmd, "PD_ANTIGUEDADSLG", DbType.Decimal, null);
                else
                    db1.AddInParameter(cmd, "PD_ANTIGUEDADSLG", DbType.Decimal, _PD_ANTIGUEDADSLG);
                db1.AddInParameter(cmd, "PV_TIPOANTIGUEDADSLG", DbType.String, _PV_TIPOANTIGUEDADSLG);
                db1.AddInParameter(cmd, "PV_CARGOSLG", DbType.String, _PV_CARGOSLG);
                db1.AddInParameter(cmd, "PV_EMPRESASLG", DbType.String, _PV_EMPRESASLG);
                db1.AddInParameter(cmd, "PV_DIRECCIONSLG", DbType.String, _PV_DIRECCIONSLG);
                db1.AddInParameter(cmd, "PV_TELEFONOSlG", DbType.String, _PV_TELEFONOSlG);
                db1.AddInParameter(cmd, "PV_EMAILSLG", DbType.String, _PV_EMAILSLG);
                db1.AddInParameter(cmd, "PD_INGRESO_BSSLG", DbType.Decimal, _PD_INGRESO_BSSLG);
                
                db1.AddInParameter(cmd, "PV_COD_REP_LEGAL1", DbType.String, _PV_COD_REP_LEGAL1);
                db1.AddInParameter(cmd, "PV_NOMBRE_COMPLETOL1", DbType.String, _PV_NOMBRE_COMPLETOL1);
                db1.AddInParameter(cmd, "PV_NRO_PODERL1", DbType.String, _PV_NRO_PODERL1);
                db1.AddInParameter(cmd, "PV_CARGOL1", DbType.String, _PV_CARGOL1);
                db1.AddInParameter(cmd, "PV_EMAILL1", DbType.String, _PV_EMAILL1);
                db1.AddInParameter(cmd, "PV_TELEFONOL1", DbType.String, _PV_TELEFONOL1);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTOL1", DbType.String, _PV_NUMERO_DOCUMENTOL1);
                db1.AddInParameter(cmd, "PV_COD_REP_LEGAL2", DbType.String, _PV_COD_REP_LEGAL2);
                db1.AddInParameter(cmd, "PV_NOMBRE_COMPLETOL2", DbType.String, _PV_NOMBRE_COMPLETOL2);
                db1.AddInParameter(cmd, "PV_NRO_PODERL2", DbType.String, _PV_NRO_PODERL2);
                db1.AddInParameter(cmd, "PV_CARGOL2", DbType.String, _PV_CARGOL2);
                db1.AddInParameter(cmd, "PV_EMAILL2", DbType.String, _PV_EMAILL2);
                db1.AddInParameter(cmd, "PV_TELEFONOL2", DbType.String, _PV_TELEFONOL2);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTOL2", DbType.String, _PV_NUMERO_DOCUMENTOL2);
                db1.AddInParameter(cmd, "PV_COD_REP_LEGAL3", DbType.String, _PV_COD_REP_LEGAL3);
                db1.AddInParameter(cmd, "PV_NOMBRE_COMPLETOL3", DbType.String, _PV_NOMBRE_COMPLETOL3);
                db1.AddInParameter(cmd, "PV_NRO_PODERL3", DbType.String, _PV_NRO_PODERL3);
                db1.AddInParameter(cmd, "PV_CARGOL3", DbType.String, _PV_CARGOL3);
                db1.AddInParameter(cmd, "PV_EMAILL3", DbType.String, _PV_EMAILL3);
                db1.AddInParameter(cmd, "PV_TELEFONOL3", DbType.String, _PV_TELEFONOL3);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTOL3", DbType.String, _PV_NUMERO_DOCUMENTOL3);
                db1.AddInParameter(cmd, "PV_COD_REP_LEGAL4", DbType.String, _PV_COD_REP_LEGAL4);
                db1.AddInParameter(cmd, "PV_NOMBRE_COMPLETOL4", DbType.String, _PV_NOMBRE_COMPLETOL4);
                db1.AddInParameter(cmd, "PV_NRO_PODERL4", DbType.String, _PV_NRO_PODERL4);
                db1.AddInParameter(cmd, "PV_CARGOL4", DbType.String, _PV_CARGOL4);
                db1.AddInParameter(cmd, "PV_EMAILL4", DbType.String, _PV_EMAILL4);
                db1.AddInParameter(cmd, "PV_TELEFONOL4", DbType.String, _PV_TELEFONOL4);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTOL4", DbType.String, _PV_NUMERO_DOCUMENTOL4);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddInParameter(cmd, "PV_CODIGO_SOLICITUD", DbType.String, _PV_CODIGO_SOLICITUD);

                db1.AddOutParameter(cmd, "PV_COD_CLIENTE_RET", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);

                resultado = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION")+"|"+ (string)db1.GetParameterValue(cmd, "PV_COD_CLIENTE_RET");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                //resultado = "Se produjo un error al registrar";
                resultado = ex.ToString() + "|";
                return resultado;
            }
        }
        public void verifica_vacios()
        {
            if (_PV_COD_CLIENTE == "") { _PV_COD_CLIENTE=null;}
            if (_PV_NOMBRE == "") { _PV_NOMBRE = null;}
            if (_PV_APELLIDO_P == "") { _PV_APELLIDO_P = null;}
            if (_PV_APELLIDO_M == "") { _PV_APELLIDO_M = null;}
            if (_PV_APELLIDO_MA == "") { _PV_APELLIDO_MA = null;}
            if (_PV_SEXO == "") { _PV_SEXO = null;}
            if (_PV_LUG_NAC == "") { _PV_LUG_NAC = null;}
            if (_PV_NACIONALIDAD == "") { _PV_NACIONALIDAD = null;}
            if (_PV_NIVEL_EDUCACION == "SELECCIONAR"|| _PV_NIVEL_EDUCACION == "") { _PV_NIVEL_EDUCACION = null;}
            if (_PV_ESTADO_CIVIL == "SELECCIONAR" || _PV_ESTADO_CIVIL == "") { _PV_ESTADO_CIVIL = null;}
            //if (_PD_FECHA_FUNNAC == "") { pD_FECHA_FUNNAC=null;}
            
            if (_PV_NUMERO_DOCUMENTO == "") { _PV_NUMERO_DOCUMENTO = null;}
            
            if (_PV_EXPEDIDO == "SELECCIONAR" || _PV_EXPEDIDO == "") { _PV_EXPEDIDO = null;}
            if (_PV_PROFESION == "") { _PV_PROFESION = null;}
            //if (_PI_NRO_DEPENDIENTES == "") { pI_NRO_DEPENDIENTES=null;}
            if (_PV_TELEFONO_CELULAR == "") { _PV_TELEFONO_CELULAR = null;}
            if (_PV_EMAIL == "") { _PV_EMAIL = null;}
            if (_PV_RAZON_SOCIAL == "") { _PV_RAZON_SOCIAL = null;}
            if (_PV_SOCIEDAD == "") { _PV_SOCIEDAD = null;}
            if (_PV_ACTIVIDAD == "") { _PV_ACTIVIDAD = null;}
            if (_PV_RUBRO == "") { _PV_RUBRO = null;}
            if (_PV_GRUPO_ECO == "") { _PV_GRUPO_ECO = null;}
            if (_PV_TELEFONO_FIJO == "") { _PV_TELEFONO_FIJO = null;}
            if (_PV_PAGINA_WEB == "") { _PV_PAGINA_WEB = null;}
            if (_PV_COD_CLIENTE_CONYUGUE == "") { _PV_COD_CLIENTE_CONYUGUE = null;}
            if (_PV_NOMBREC == "") { _PV_NOMBREC = null;}
            if (_PV_APELLIDO_PC == "") { _PV_APELLIDO_PC = null;}
            if (_PV_APELLIDO_MC == "") { _PV_APELLIDO_MC = null;}
            if (_PV_APELLIDO_MAC == "") { _PV_APELLIDO_MAC = null;}
            if (_PV_SEXOC == "") { _PV_SEXOC = null;}
            if (_PV_LUG_NACC == "SELECCIONAR" || _PV_LUG_NACC == "") { _PV_LUG_NACC = null;}
            if (_PV_NACIONALIDADC == "") { _PV_NACIONALIDADC = null;}
            //if (_PI_EDADC == "") { pI_EDADC=null;}
            if (_PV_NIVEL_EDUCACIONC == "SELECCIONAR" || _PV_NIVEL_EDUCACIONC == "") { _PV_NIVEL_EDUCACIONC = null;}
            if (_PV_ESTADO_CIVILC == "SELECCIONAR" || _PV_ESTADO_CIVILC == "") { _PV_ESTADO_CIVILC = null;}
            //if (_PD_FECHA_FUNNACC == "") { pD_FECHA_FUNNACC=null;}
            if (_PV_NUMERO_DOCUMENTOC == "") { _PV_NUMERO_DOCUMENTOC = null;}
            if (_PV_EXPEDIDOC == "SELECCIONAR" || _PV_EXPEDIDOC == "") { _PV_EXPEDIDOC = null;}
            if (_PV_TELEFONO_CELULARC == "") { _PV_TELEFONO_CELULARC = null;}
            if (_PV_EMPRESA_LABORALC == "") { _PV_EMPRESA_LABORALC = null;}
            if (_PV_PROFESIONC == "") { _PV_PROFESIONC = null;}
            if (_PV_CARGOC == "") { _PV_CARGOC = null;}
            //if (_PI_ANTIGUEDADC == "") { pI_ANTIGUEDADC=null;}
            if (_PV_CODIGO_SOLICITUD == "") { _PV_CODIGO_SOLICITUD = null; }
            if (_PV_DIRECCION_EMPRESAC == "") { _PV_DIRECCION_EMPRESAC = null;}
            if (_PV_TELEFONO_FIJOC == "") { _PV_TELEFONO_FIJOC = null;}
            if (_PV_EMAILC == "") { _PV_EMAILC = null;}
            if (_PV_COD_DIRECCION == "") { _PV_COD_DIRECCION = null;}
            if (_PV_TIPO_VIVIENDA == "") { _PV_TIPO_VIVIENDA = null;}
            if (_PV_DETALLE == "") { _PV_DETALLE = null;}
            if (_PV_BARRIO == "") { _PV_BARRIO = null;}
            if (_PV_CONDOMINIO == "") { _PV_CONDOMINIO = null;}
            if (_PV_URBANIZACION == "") { _PV_URBANIZACION = null;}
            if (_PV_CIUDAD == "") { _PV_CIUDAD = null;}
            if (_PV_AVENIDA == "") { _PV_AVENIDA = null;}
            if (_PV_CALLE == "") { _PV_CALLE = null;}
            if (_PV_PASIILO_CARRETERA == "") { _PV_PASIILO_CARRETERA = null;}
            if (_PV_NRO == "") { _PV_NRO = null;}
            if (_PV_EDIFICIO == "") { _PV_EDIFICIO = null;}
            if (_PV_PISO == "") { _PV_PISO = null;}
            if (_PV_NRO_DPTO == "") { _PV_NRO_DPTO = null;}
            if (_PV_TELEFONO == "") { _PV_TELEFONO = null;}
            if (_PV_REFERENCIA == "") { _PV_REFERENCIA = null;}
            if (_PV_LATITUD == "") { _PV_LATITUD = null;}
            if (_PV_LONGITUD == "") { _PV_LONGITUD = null;}
            if (_PV_COD_DATO_LABORAL == "") { _PV_COD_DATO_LABORAL = null;}
            if (_PV_SITUACION_LABORAL == "") { _PV_SITUACION_LABORAL = null;}
            if (_PV_RELACION_LABORAL == "") { _PV_RELACION_LABORAL = "IND"; }
            //if (_PD_ANTIGUEDADSL == "") { pD_ANTIGUEDADSL=null;}
            if (_PV_CARGOSL == "") { _PV_CARGOSL = null;}
            if (_PV_EMPRESASL == "") { _PV_EMPRESASL = null;}
            if (_PV_DIRECCIONSL == "") { _PV_DIRECCIONSL = null;}
            if (_PV_TELEFONOSl == "") { _PV_TELEFONOSl = null;}
            if (_PV_EMAILSL == "") { _PV_EMAILSL = null;}
            //if (_PD_INGRESO_BSSL == "") { pD_INGRESO_BSSL=null;}

            if (_PV_COD_REFERENCIAREF1 == "") { _PV_COD_REFERENCIAREF1 = null;}
            if (_PV_TIPO_REFERENCIAREF1 == "") { _PV_TIPO_REFERENCIAREF1 = null;}
            if (_PV_NOMBRE_COMPLETOREF1 == "") { _PV_NOMBRE_COMPLETOREF1 = null;}
            if (_PV_OCUPACIONREF1 == "") { _PV_OCUPACIONREF1 = null;}
            if (_PV_TELEFONOREF1 == "") { _PV_TELEFONOREF1 = null;}

            if (_PV_COD_REFERENCIAREF2 == "") { _PV_COD_REFERENCIAREF2 = null;}
            if (_PV_TIPO_REFERENCIAREF2 == "") { _PV_TIPO_REFERENCIAREF2 = null;}
            if (_PV_NOMBRE_COMPLETOREF2 == "") { _PV_NOMBRE_COMPLETOREF2 = null;}
            if (_PV_OCUPACIONREF2 == "") { _PV_OCUPACIONREF2 = null;}
            if (_PV_TELEFONOREF2 == "") { _PV_TELEFONOREF2 = null;}

            if (_PV_COD_REFERENCIAREF3 == "") { _PV_COD_REFERENCIAREF3 = null;}
            if (_PV_TIPO_REFERENCIAREF3 == "") { _PV_TIPO_REFERENCIAREF3 = null;}
            if (_PV_NOMBRE_COMPLETOREF3 == "") { _PV_NOMBRE_COMPLETOREF3 = null;}
            if (_PV_OCUPACIONREF3 == "") { _PV_OCUPACIONREF3 = null;}
            if (_PV_TELEFONOREF3 == "") { _PV_TELEFONOREF3 = null;}

            if (_PV_COD_BALANCE == "") { _PV_COD_BALANCE = null;}
            //if (_PD_TOTAL_ACTIVOS_SUS == "") { pD_TOTAL_ACTIVOS_SUS=null;}
            //if (_PD_TOTAL_PASIVOS == "") { pD_TOTAL_PASIVOS=null;}
            if (_PV_INGRESOS == "") { _PV_INGRESOS = null;}
            if (_PV_EGRESOS == "") { _PV_EGRESOS = null;}
            if (_PV_COD_CLIENTE_GARANTE == "") { _PV_COD_CLIENTE_GARANTE = null;}
            if (_PV_NOMBREG == "") { _PV_NOMBREG = null;}
            if (_PV_APELLIDO_PG == "") { _PV_APELLIDO_PG = null;}
            if (_PV_APELLIDO_MG == "") { _PV_APELLIDO_MG = null;}
            if (_PV_APELLIDO_MAG == "") { _PV_APELLIDO_MAG = null;}
            if (_PV_SEXOG == "") { _PV_SEXOG = null;}
            if (_PV_LUG_NACG == "SELECCIONAR" || _PV_LUG_NACG == "") { _PV_LUG_NACG = null;}
            if (_PV_NACIONALIDADG == "") { _PV_NACIONALIDADG = null;}
            //if (_PI_EDADG == "") { pI_EDADG=null;}
            if (_PV_NIVEL_EDUCACIONG == "SELECCIONAR" || _PV_NIVEL_EDUCACIONG == "") { _PV_NIVEL_EDUCACIONG = null;}
            if (_PV_ESTADO_CIVILG == "SELECCIONAR" || _PV_ESTADO_CIVILG == "") { _PV_ESTADO_CIVILG = null;}
            //if (_PD_FECHA_FUNNACG == DateTime.Parse("01/01/3000")) { _PD_FECHA_FUNNACG = null;}
            if (_PV_NUMERO_DOCUMENTOG == "") { _PV_NUMERO_DOCUMENTOG = null;_PV_CODIGO_SOLICITUD = null; }
            if (_PV_EXPEDIDOG == "SELECCIONAR" || _PV_EXPEDIDOG == "") { _PV_EXPEDIDOG = null;}
            if (_PV_PROFESIONG == "") { _PV_PROFESIONG = null;}
            //if (_PI_NRO_DEPENDIENTESG == "") { pI_NRO_DEPENDIENTESG=null;}
            if (_PV_TELEFONO_CELULARG == "") { _PV_TELEFONO_CELULARG = null;}
            if (_PV_EMAILG == "") { _PV_EMAILG = null;}
            if (_PV_COD_DATO_LABORAL_GARANTE == "") { _PV_COD_DATO_LABORAL_GARANTE = null;}
            if (_PV_SITUACION_LABORALG == "") { _PV_SITUACION_LABORALG = null;}
            if (_PV_RELACION_LABORALG == "") { _PV_RELACION_LABORALG = null;}
           // if (_PD_ANTIGUEDADSLG == "") { pD_ANTIGUEDADSLG=null;}
            if (_PV_CARGOSLG == "") { _PV_CARGOSLG = null;}
            if (_PV_EMPRESASLG == "") { _PV_EMPRESASLG = null;}
            if (_PV_DIRECCIONSLG == "") { _PV_DIRECCIONSLG = null;}
            if (_PV_TELEFONOSlG == "") { _PV_TELEFONOSlG = null;}
            if (_PV_EMAILSLG == "") { _PV_EMAILSLG = null;}
            //if (_PD_INGRESO_BSSLG == "") { pD_INGRESO_BSSLG=null;}

            if (_PV_COD_REP_LEGAL1 == "") { _PV_COD_REP_LEGAL1 = null;}
            if (_PV_NOMBRE_COMPLETOL1 == "") { _PV_NOMBRE_COMPLETOL1 = null;}
            if (_PV_NRO_PODERL1 == "") { _PV_NRO_PODERL1 = null;}
            if (_PV_CARGOL1 == "") { _PV_CARGOL1 = null;}
            if (_PV_EMAILL1 == "") { _PV_EMAILL1 = null;}
            if (_PV_TELEFONOL1 == "") { _PV_TELEFONOL1 = null;}
            if (_PV_NUMERO_DOCUMENTOL1 == "") { _PV_NUMERO_DOCUMENTOL1 = null;}

            if (_PV_COD_REP_LEGAL2 == "") { _PV_COD_REP_LEGAL2 = null;}
            if (_PV_NOMBRE_COMPLETOL2 == "") { _PV_NOMBRE_COMPLETOL2 = null;}
            if (_PV_NRO_PODERL2 == "") { _PV_NRO_PODERL2 = null;}
            if (_PV_CARGOL2 == "") { _PV_CARGOL2 = null;}
            if (_PV_EMAILL2 == "") { _PV_EMAILL2 = null;}
            if (_PV_TELEFONOL2 == "") { _PV_TELEFONOL2 = null;}
            if (_PV_NUMERO_DOCUMENTOL2 == "") { _PV_NUMERO_DOCUMENTOL2 = null;}

            if (_PV_COD_REP_LEGAL3 == "") { _PV_COD_REP_LEGAL3 = null;}
            if (_PV_NOMBRE_COMPLETOL3 == "") { _PV_NOMBRE_COMPLETOL3 = null;}
            if (_PV_NRO_PODERL3 == "") { _PV_NRO_PODERL3 = null;}
            if (_PV_CARGOL3 == "") { _PV_CARGOL3 = null;}
            if (_PV_EMAILL3 == "") { _PV_EMAILL3 = null;}
            if (_PV_TELEFONOL3 == "") { _PV_TELEFONOL3 = null;}
            if (_PV_NUMERO_DOCUMENTOL3 == "") { _PV_NUMERO_DOCUMENTOL3 = null;}

            if (_PV_COD_REP_LEGAL4 == "") { _PV_COD_REP_LEGAL4 = null;}
            if (_PV_NOMBRE_COMPLETOL4 == "") { _PV_NOMBRE_COMPLETOL4 = null;}
            if (_PV_NRO_PODERL4 == "") { _PV_NRO_PODERL4 = null;}
            if (_PV_CARGOL4 == "") { _PV_CARGOL4 = null;}
            if (_PV_EMAILL4 == "") { _PV_EMAILL4 = null;}
            if (_PV_TELEFONOL4 == "") { _PV_TELEFONOL4 = null;}
            if (_PV_NUMERO_DOCUMENTOL4 == "") { _PV_NUMERO_DOCUMENTOL4 = null;}
            if (_PV_TIPOANTIGUEDADC == "") { _PV_TIPOANTIGUEDADC = null; }
            if (_PV_TIPOANTIGUEDADSLG == "") { _PV_TIPOANTIGUEDADSLG = null; }
            if (_PV_TIPOANTIGUEDASL == "") { _PV_TIPOANTIGUEDASL = null; }

        }
        #endregion
    }
}