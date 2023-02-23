using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace appAmascuotas.Clases
{
    public class Clientes
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private long _PB_ID_CLIENT = 0;
        private string _PV_TYPE_CLIENT = "";
        private string _PV_SOCIETY = "";
        private string _PV_NAME = "";
        private string _PV_SURNAMES = "";
        private DateTime _PD_DATE_BIRTH = DateTime.Now;
        private string _PV_ADDRESS = "";
        private string _PV_COUNTRY = "";
        private string _PV_CITY = "";
        private string _PV_VILLAGE_NAME = "";
        private string _PV_POSTALE_CODE = "";
        private string _PV_LONGITUD = "";
        private string _PV_LATITUD = "";
        private string _PV_EMAIL = "";
        private long _PB_PHONE =0;
        private long _PB_MOBILE = 0;
        private long _PB_FAX = 0;
        private string _PV_TYPE_COMMUNICATION = "";
        private string _PV_TYPE_COMMUNICATION_DESC = "";
        private string _PV_DOOR_NUMBER = "";
        private string _PV_FLOOR = "";
        private string _PV_COMMENTS = "";
        private string _PV_ADDRESS_FACT = "";
        private string _PV_COUNTRY_FACT = "";
        private string _PV_CITY_FACT = "";
        private string _PV_VILLAGE_NAME_FACT = "";
        private string _PV_POSTALE_CODE_FACT = "";
        private string _PV_LONGITUD_FACT = "";
        private string _PV_LATITUD_FACT = "";


        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        private long _PB_ID_CLIENTOUT = 0;

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public long PB_ID_CLIENT { get { return _PB_ID_CLIENT; } set { _PB_ID_CLIENT = value; } }
        public string PV_TYPE_CLIENT { get { return _PV_TYPE_CLIENT; } set { _PV_TYPE_CLIENT = value; } }
        public string PV_SOCIETY { get { return _PV_SOCIETY; } set { _PV_SOCIETY = value; } }
        public string PV_NAME { get { return _PV_NAME; } set { _PV_NAME = value; } }
        public string PV_SURNAMES { get { return _PV_SURNAMES; } set { _PV_SURNAMES = value; } }
        public DateTime PD_DATE_BIRTH { get { return _PD_DATE_BIRTH; } set { _PD_DATE_BIRTH = value; } }
        public string PV_ADDRESS { get { return _PV_ADDRESS; } set { _PV_ADDRESS = value; } }
        public string PV_COUNTRY { get { return _PV_COUNTRY; } set { _PV_COUNTRY = value; } }
        public string PV_CITY { get { return _PV_CITY; } set { _PV_CITY = value; } }
        public string PV_VILLAGE_NAME { get { return _PV_VILLAGE_NAME; } set { _PV_VILLAGE_NAME = value; } }
        public string PV_POSTALE_CODE { get { return _PV_POSTALE_CODE; } set { _PV_POSTALE_CODE = value; } }
        public string PV_LONGITUD { get { return _PV_LONGITUD; } set { _PV_LONGITUD = value; } }
        public string PV_LATITUD { get { return _PV_LATITUD; } set { _PV_LATITUD = value; } }
        public string PV_EMAIL { get { return _PV_EMAIL; } set { _PV_EMAIL = value; } }
        public long PB_PHONE { get { return _PB_PHONE; } set { _PB_PHONE = value; } }
        public long PB_MOBILE { get { return _PB_MOBILE; } set { _PB_MOBILE = value; } }
        public long PB_FAX { get { return _PB_FAX; } set { _PB_FAX = value; } }
        public string PV_TYPE_COMMUNICATION { get { return _PV_TYPE_COMMUNICATION; } set { _PV_TYPE_COMMUNICATION = value; } }
        public string PV_TYPE_COMMUNICATION_DESC { get { return _PV_TYPE_COMMUNICATION_DESC; } set { _PV_TYPE_COMMUNICATION_DESC = value; } }
        public string PV_DOOR_NUMBER { get { return _PV_DOOR_NUMBER; } set { _PV_DOOR_NUMBER = value; } }
        public string PV_FLOOR { get { return _PV_FLOOR; } set { _PV_FLOOR = value; } }
        public string PV_COMMENTS { get { return _PV_COMMENTS; } set { _PV_COMMENTS = value; } }
        public string PV_ADDRESS_FACT { get { return _PV_ADDRESS_FACT; } set { _PV_ADDRESS_FACT = value; } }
        public string PV_COUNTRY_FACT { get { return _PV_COUNTRY_FACT; } set { _PV_COUNTRY_FACT = value; } }
        public string PV_CITY_FACT { get { return _PV_CITY_FACT; } set { _PV_CITY_FACT = value; } }
        public string PV_VILLAGE_NAME_FACT { get { return _PV_VILLAGE_NAME_FACT; } set { _PV_VILLAGE_NAME_FACT = value; } }
        public string PV_POSTALE_CODE_FACT { get { return _PV_POSTALE_CODE_FACT; } set { _PV_POSTALE_CODE_FACT = value; } }
        public string PV_LONGITUD_FACT { get { return _PV_LONGITUD_FACT; } set { _PV_LONGITUD_FACT = value; } }
        public string PV_LATITUD_FACT { get { return _PV_LATITUD_FACT; } set { _PV_LATITUD_FACT = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        public long PB_ID_CLIENTOUT { get { return _PB_ID_CLIENTOUT; } set { _PB_ID_CLIENTOUT = value; } }

        #endregion

        #region Constructores
        public Clientes(long pB_ID_CLIENT)
        {
            _PB_ID_CLIENT = pB_ID_CLIENT;
            RecuperarDatos();
        }
        public Clientes(string pV_TIPO_OPERACION, long pB_ID_CLIENT, string pV_TYPE_CLIENT, string pV_SOCIETY, string pV_NAME, string pV_SURNAMES, DateTime pD_DATE_BIRTH, 
            string pV_ADDRESS, string pV_COUNTRY, string pV_CITY, string pV_VILLAGE_NAME, string pV_POSTALE_CODE, string pV_LONGITUD, string pV_LATITUD,
            string pV_EMAIL, long pB_PHONE, long pB_MOBILE, long pB_FAX, string pV_TYPE_COMMUNICATION, string pV_DOOR_NUMBER, string pV_FLOOR, string pV_COMMENTS, 
            string pV_ADDRESS_FACT, string pV_COUNTRY_FACT, string pV_CITY_FACT, string pV_VILLAGE_NAME_FACT, string pV_POSTALE_CODE_FACT, string pV_LONGITUD_FACT, 
            string pV_LATITUD_FACT, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_CLIENT = pB_ID_CLIENT;
            _PV_TYPE_CLIENT = pV_TYPE_CLIENT;
            _PV_SOCIETY = pV_SOCIETY;
            _PV_NAME = pV_NAME;
            _PV_SURNAMES = pV_SURNAMES;
            _PD_DATE_BIRTH = pD_DATE_BIRTH;
            _PV_ADDRESS = pV_ADDRESS;
            _PV_COUNTRY = pV_COUNTRY;
            _PV_CITY = pV_CITY;
            _PV_VILLAGE_NAME = pV_VILLAGE_NAME;
            _PV_POSTALE_CODE = pV_POSTALE_CODE;
            _PV_LONGITUD = pV_LONGITUD;
            _PV_LATITUD = pV_LATITUD;
            _PV_EMAIL = pV_EMAIL;
            _PB_PHONE = pB_PHONE;
            _PB_MOBILE = pB_MOBILE;
            _PB_FAX = pB_FAX;
            _PV_TYPE_COMMUNICATION = pV_TYPE_COMMUNICATION;
            _PV_DOOR_NUMBER = pV_DOOR_NUMBER;
            _PV_FLOOR = pV_FLOOR;
            _PV_COMMENTS = pV_COMMENTS;
            _PV_ADDRESS_FACT = pV_ADDRESS_FACT;
            _PV_COUNTRY_FACT = pV_COUNTRY_FACT;
            _PV_CITY_FACT = pV_CITY_FACT;
            _PV_VILLAGE_NAME_FACT = pV_VILLAGE_NAME_FACT;
            _PV_POSTALE_CODE_FACT = pV_POSTALE_CODE_FACT;
            _PV_LONGITUD_FACT = pV_LONGITUD_FACT;
            _PV_LATITUD_FACT = pV_LATITUD_FACT;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable PR_CLI_GET_CLIENTES()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_CLI_GET_CLIENTES");
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




        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_CLI_GET_CLIENTES_IND");
                db1.AddInParameter(cmd, "PV_ID_CLIENT", DbType.String, _PB_ID_CLIENT);
                db1.ExecuteNonQuery(cmd);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _PV_TYPE_CLIENT = (string)dr["TYPE_CLIENT"];
                        _PV_SOCIETY = (string)dr["SOCIETY"];
                        _PV_NAME = (string)dr["NAME"];
                        _PV_SURNAMES = (string)dr["SURNAMES"];
                        _PD_DATE_BIRTH = (DateTime)dr["DATE_BIRTH"];
                        _PV_ADDRESS = (string)dr["ADDRESS"];
                        _PV_COUNTRY = (string)dr["COUNTRY"];
                        _PV_CITY = (string)dr["CITY"];
                        _PV_VILLAGE_NAME = (string)dr["VILLAGE_NAME"];
                        _PV_POSTALE_CODE = (string)dr["POSTALE_CODE"];
                        _PV_LONGITUD = (string)dr["LONGITUD"];
                        _PV_LATITUD = (string)dr["LATITUD"];
                        _PV_EMAIL = (string)dr["EMAIL"];
                        _PB_PHONE = (long)dr["PHONE"];
                        _PB_MOBILE = (long)dr["MOBILE"];
                        _PB_FAX = (long)dr["FAX"];
                        _PV_TYPE_COMMUNICATION = (string)dr["TYPE_COMMUNICATION"];
                        _PV_TYPE_COMMUNICATION_DESC = (string)dr["DESC_TYPE_COMMUNICATION"];
                        _PV_DOOR_NUMBER = (string)dr["DOOR_NUMBER"];
                        _PV_FLOOR = (string)dr["FLOOR"];
                        _PV_COMMENTS = (string)dr["COMMENTS"];
                        _PV_ADDRESS_FACT = (string)dr["ADDRESS_FACT"];
                        _PV_COUNTRY_FACT = (string)dr["COUNTRY_FACT"];
                        _PV_CITY_FACT = (string)dr["CITY_FACT"];
                        _PV_VILLAGE_NAME_FACT = (string)dr["VILLAGE_NAME_FACT"];
                        _PV_POSTALE_CODE_FACT = (string)dr["POSTALE_CODE_FACT"];
                        _PV_LONGITUD_FACT = (string)dr["LONGITUD_FACT"];
                        _PV_LATITUD_FACT = (string)dr["LATITUD_FACT"];
                        //if (string.IsNullOrEmpty(dr["COD_MENU_PADRE"].ToString()))
                        //{ _PB_COD_MENU_PADRE = ""; }
                        //else
                        //{ _PB_COD_MENU_PADRE = (string)dr["COD_MENU_PADRE"]; }
                       
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_CLI_ABM_CLIENTS");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                if (_PB_ID_CLIENT == 0)
                    db1.AddInParameter(cmd, "PB_ID_CLIENT", DbType.Int64, null);
                else
                    db1.AddInParameter(cmd, "PB_ID_CLIENT", DbType.Int64, _PB_ID_CLIENT);
                db1.AddInParameter(cmd, "PV_TYPE_CLIENT", DbType.String, _PV_TYPE_CLIENT);
                db1.AddInParameter(cmd, "PV_SOCIETY", DbType.String, _PV_SOCIETY);
                db1.AddInParameter(cmd, "PV_NAME", DbType.String, _PV_NAME);
                db1.AddInParameter(cmd, "PV_SURNAMES", DbType.String, _PV_SURNAMES);
                db1.AddInParameter(cmd, "PD_DATE_BIRTH", DbType.DateTime, _PD_DATE_BIRTH);
                db1.AddInParameter(cmd, "PV_ADDRESS", DbType.String, _PV_ADDRESS);
                db1.AddInParameter(cmd, "PV_COUNTRY", DbType.String, _PV_COUNTRY);
                db1.AddInParameter(cmd, "PV_CITY", DbType.String, _PV_CITY);
                db1.AddInParameter(cmd, "PV_VILLAGE_NAME", DbType.String, _PV_VILLAGE_NAME);
                db1.AddInParameter(cmd, "PV_POSTALE_CODE", DbType.String, _PV_POSTALE_CODE);
                db1.AddInParameter(cmd, "PV_LONGITUD", DbType.String, _PV_LONGITUD);
                db1.AddInParameter(cmd, "PV_LATITUD", DbType.String, _PV_LATITUD);
                db1.AddInParameter(cmd, "PV_EMAIL", DbType.String, _PV_EMAIL);
                db1.AddInParameter(cmd, "PB_PHONE", DbType.Int64, _PB_PHONE);
                db1.AddInParameter(cmd, "PB_MOBILE", DbType.Int64, _PB_MOBILE);
                db1.AddInParameter(cmd, "PB_FAX", DbType.Int64, _PB_FAX);
                db1.AddInParameter(cmd, "PV_TYPE_COMMUNICATION", DbType.String, _PV_TYPE_COMMUNICATION);
                db1.AddInParameter(cmd, "PV_DOOR_NUMBER", DbType.String, _PV_DOOR_NUMBER);
                db1.AddInParameter(cmd, "PV_FLOOR", DbType.String, _PV_FLOOR);
                db1.AddInParameter(cmd, "PV_COMMENTS", DbType.String, _PV_COMMENTS);
                db1.AddInParameter(cmd, "PV_ADDRESS_FACT", DbType.String, _PV_ADDRESS_FACT);
                db1.AddInParameter(cmd, "PV_COUNTRY_FACT", DbType.String, _PV_COUNTRY_FACT);
                db1.AddInParameter(cmd, "PV_CITY_FACT", DbType.String, _PV_CITY_FACT);
                db1.AddInParameter(cmd, "PV_VILLAGE_NAME_FACT", DbType.String, _PV_VILLAGE_NAME_FACT);
                db1.AddInParameter(cmd, "PV_POSTALE_CODE_FACT", DbType.String, _PV_POSTALE_CODE_FACT);
                db1.AddInParameter(cmd, "PV_LONGITUD_FACT", DbType.String, _PV_LONGITUD_FACT);
                db1.AddInParameter(cmd, "PV_LATITUD_FACT", DbType.String, _PV_LATITUD_FACT);

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PB_ID_CLIENTOUT", DbType.Int64, 250);
                db1.ExecuteNonQuery(cmd);
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_USER").ToString()))
                //    PV_USUARIO = "";
                //else
                //    PV_USUARIO = (string)db1.GetParameterValue(cmd, "PV_USER");
                PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION");
                PB_ID_CLIENTOUT = long.Parse(db1.GetParameterValue(cmd, "PB_ID_CLIENTOUT").ToString());
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                resultado = PV_ERROR + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|";// + PB_ID_CLIENTOUT;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar|||";
                return resultado;
            }
        }

        #endregion
    }
}