using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appAmascuotas.Clases
{
    public class Tickets
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        // JURIDICA
        private string _PV_TIPO_OPERACION = "";
        private string _PV_COD_SOLICITUD = "";
        private string _PV_PNR = "";
        private string _PV_TIPO = "";
        private string _PV_ITINERARIORUTA_ORIGEN = "";
        private string _PV_CADENA = "";
        
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas

        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_COD_SOLICITUD { get { return _PV_COD_SOLICITUD; } set { _PV_COD_SOLICITUD = value; } }
        public string PV_PNR { get { return _PV_PNR; } set { _PV_PNR = value; } }
        public string PV_TIPO { get { return _PV_TIPO; } set { _PV_TIPO = value; } }
        public string PV_ITINERARIORUTA_ORIGEN { get { return _PV_ITINERARIORUTA_ORIGEN; } set { _PV_ITINERARIORUTA_ORIGEN = value; } }
        public string PV_CADENA { get { return _PV_CADENA; } set { _PV_CADENA = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        //public Simulador(string Cod_sumulador)
        //{

        //    RecuperarDatos();
        //}
        public Tickets(string pV_TIPO_OPERACION, string pV_COD_SOLICITUD, 
            string pV_PNR, string pV_TIPO, string pV_ITINERARIORUTA_ORIGEN,
        string pV_CADENA, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_COD_SOLICITUD = pV_COD_SOLICITUD;
            _PV_PNR = pV_PNR;
            _PV_TIPO = pV_TIPO;
            _PV_ITINERARIORUTA_ORIGEN = pV_ITINERARIORUTA_ORIGEN;
            _PV_CADENA = pV_CADENA;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        
        public static DataTable GET_TICKETS(string PV_COD_SOLICITUD)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_TICKETS");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, PV_COD_SOLICITUD); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable GET_TICKETS_DETALLE(string PV_COD_SOLICITUD_TICKET)
        {
            DbCommand cmd = db1.GetStoredProcCommand("GET_TICKETS_DETALLE");
            db1.AddInParameter(cmd, "PV_COD_SOLICITUD_TICKET", DbType.String, PV_COD_SOLICITUD_TICKET); // Enviar el código del usuario conectado
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }



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
                DbCommand cmd = db1.GetStoredProcCommand("PR_ABM_TICKETS");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_COD_SOLICITUD", DbType.String, _PV_COD_SOLICITUD);
                db1.AddInParameter(cmd, "PV_PNR", DbType.String, _PV_PNR);
                db1.AddInParameter(cmd, "PV_TIPO", DbType.String, _PV_TIPO);
                db1.AddInParameter(cmd, "PV_ITINERARIORUTA_ORIGEN", DbType.String, _PV_ITINERARIORUTA_ORIGEN);
                db1.AddInParameter(cmd, "PV_CADENA", DbType.String, _PV_CADENA);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);

                resultado = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR") ;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                //resultado = "Se produjo un error al registrar";
                resultado = ex.ToString();
                return resultado;
            }
        }
        
        #endregion
    }
}