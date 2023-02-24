using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appAmascuotas.Clases
{
    public class Client_types
    {

        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_ID_CLIENTS_TYPE = "";
        private string _PV_DESCRIPTION = "";
        private decimal _PD_HOURLY_RATE = 0;
        private decimal _PD_TRAVEL_FEE = 0;
        private decimal _PD_REMINDER_FEE_FIRST = 0;
        private decimal _PD_REMINDER_FEE_SECOND = 0;
        private decimal _PD_REMINDER_FEE_THIRD = 0;
        private decimal _PD_RATE_LATE_PAYMENT = 0;
        private string _PV_USUARIO = "";

        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_ID_CLIENTS_TYPE { get { return _PV_ID_CLIENTS_TYPE; } set { _PV_ID_CLIENTS_TYPE = value; } }
        public string PV_DESCRIPTION { get { return _PV_DESCRIPTION; } set { _PV_DESCRIPTION = value; } }
        public decimal PD_HOURLY_RATE { get { return _PD_HOURLY_RATE; } set { _PD_HOURLY_RATE = value; } }
        public decimal PD_TRAVEL_FEE { get { return _PD_TRAVEL_FEE; } set { _PD_TRAVEL_FEE = value; } }
        public decimal PD_REMINDER_FEE_FIRST { get { return _PD_REMINDER_FEE_FIRST; } set { _PD_REMINDER_FEE_FIRST = value; } }
        public decimal PD_REMINDER_FEE_SECOND { get { return _PD_REMINDER_FEE_SECOND; } set { _PD_REMINDER_FEE_SECOND = value; } }
        public decimal PD_REMINDER_FEE_THIRD { get { return _PD_REMINDER_FEE_THIRD; } set { _PD_REMINDER_FEE_THIRD = value; } }
        public decimal PD_RATE_LATE_PAYMENT { get { return _PD_RATE_LATE_PAYMENT; } set { _PD_RATE_LATE_PAYMENT = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Client_types(string pV_ID_CLIENTS_TYPE)
        {
            _PV_ID_CLIENTS_TYPE = pV_ID_CLIENTS_TYPE;
            RecuperarDatos();
        }
        public Client_types(string pV_TIPO_OPERACION, string pV_ID_CLIENTS_TYPE,
            string pV_DESCRIPTION,decimal pD_HOURLY_RATE,decimal pD_TRAVEL_FEE, 
            decimal pD_REMINDER_FEE_FIRST,decimal pD_REMINDER_FEE_SECOND, 
            decimal pD_REMINDER_FEE_THIRD,decimal pD_RATE_LATE_PAYMENT, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_ID_CLIENTS_TYPE = pV_ID_CLIENTS_TYPE;
            _PV_DESCRIPTION = pV_DESCRIPTION;
            _PD_HOURLY_RATE = pD_HOURLY_RATE;
            _PD_TRAVEL_FEE = pD_TRAVEL_FEE;
            _PD_REMINDER_FEE_FIRST = pD_REMINDER_FEE_FIRST;
            _PD_REMINDER_FEE_SECOND = pD_REMINDER_FEE_SECOND;
            _PD_REMINDER_FEE_THIRD = pD_REMINDER_FEE_THIRD;
            _PD_RATE_LATE_PAYMENT = pD_RATE_LATE_PAYMENT;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable PR_PAR_GET_CLIENT_TYPES()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_CLIENT_TYPES");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_PAR_GET_CLIENT_TYPES_HIST(string PV_ID_CLIENTS_TYPE_)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_CLIENT_TYPES_HIST");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "PV_ID_CLIENTS_TYPE", DbType.String, PV_ID_CLIENTS_TYPE_);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_CLIENT_TYPES_IND");
                db1.AddInParameter(cmd, "PV_ID_CLIENTS_TYPE", DbType.String, _PV_ID_CLIENTS_TYPE);
                db1.ExecuteNonQuery(cmd);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _PV_DESCRIPTION = (string)dr["DESCRIPTION"];
                        _PD_HOURLY_RATE = (decimal)dr["HOURLY_RATE"];
                        _PD_TRAVEL_FEE = (decimal)dr["TRAVEL_FEE"];
                        _PD_REMINDER_FEE_FIRST = (decimal)dr["REMINDER_FEE_FIRST"];
                        _PD_REMINDER_FEE_SECOND = (decimal)dr["REMINDER_FEE_SECOND"];
                        _PD_REMINDER_FEE_THIRD = (decimal)dr["REMINDER_FEE_THIRD"];
                        _PD_RATE_LATE_PAYMENT = (decimal)dr["RATE_LATE_PAYMENT"];
                    }

                }

            }
            catch { }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_CLIENT_TYPES");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_ID_CLIENTS_TYPE", DbType.String, _PV_ID_CLIENTS_TYPE);
                db1.AddInParameter(cmd, "PV_DESCRIPTION", DbType.String, _PV_DESCRIPTION);
                db1.AddInParameter(cmd, "PD_HOURLY_RATE", DbType.Decimal, _PD_HOURLY_RATE);
                db1.AddInParameter(cmd, "PD_TRAVEL_FEE", DbType.Decimal, _PD_TRAVEL_FEE);
                db1.AddInParameter(cmd, "PD_REMINDER_FEE_FIRST", DbType.Decimal, _PD_REMINDER_FEE_FIRST);
                db1.AddInParameter(cmd, "PD_REMINDER_FEE_SECOND", DbType.Decimal, _PD_REMINDER_FEE_SECOND);
                db1.AddInParameter(cmd, "PD_REMINDER_FEE_THIRD", DbType.Decimal, _PD_REMINDER_FEE_THIRD);
                db1.AddInParameter(cmd, "PD_RATE_LATE_PAYMENT", DbType.Decimal, _PD_RATE_LATE_PAYMENT);

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
             
                PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                resultado = PV_ERROR + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCIONPR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar" + "||";
                return resultado;
            }
        }

        #endregion

    }
}