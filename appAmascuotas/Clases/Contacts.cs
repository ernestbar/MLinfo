using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appAmascuotas.Clases
{
    public class Contacts
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private long _PB_ID_CONTACT = 0;
        private long _PB_ID_CLIENT = 0;
        private string _PV_NAME = "";
        private string _PV_SURNAMES = "";
        private string _PV_EMAIL = "";
        private long _PB_PHONE = 0;
        private long _PB_MOBILE = 0;
        private string _PV_COMMENTS = "";
        
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public long PB_ID_CONTACT { get { return _PB_ID_CONTACT; } set { _PB_ID_CONTACT = value; } }
        public long PB_ID_CLIENT { get { return _PB_ID_CLIENT; } set { _PB_ID_CLIENT = value; } }
        public string PV_NAME { get { return _PV_NAME; } set { _PV_NAME = value; } }
        public string PV_SURNAMES { get { return _PV_SURNAMES; } set { _PV_SURNAMES = value; } }
        public string PV_EMAIL { get { return _PV_EMAIL; } set { _PV_EMAIL = value; } }
        public long PB_PHONE { get { return _PB_PHONE; } set { _PB_PHONE = value; } }
        public long PB_MOBILE { get { return _PB_MOBILE; } set { _PB_MOBILE = value; } }
        public string PV_COMMENTS { get { return _PV_COMMENTS; } set { _PV_COMMENTS = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Contacts(long pB_ID_CONTACT)
        {
            _PB_ID_CONTACT = pB_ID_CONTACT;
            RecuperarDatos();
        }
        public Contacts(string pV_TIPO_OPERACION, long pB_ID_CONTACT, long pB_ID_CLIENT , string pV_NAME, string pV_SURNAMES, string pV_EMAIL, long pB_PHONE, long pB_MOBILE,
            string pV_COMMENTS, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            
            _PB_ID_CONTACT = pB_ID_CONTACT;
            _PB_ID_CLIENT = pB_ID_CLIENT;
            _PV_NAME = pV_NAME;
            _PV_SURNAMES = pV_SURNAMES;
            _PV_EMAIL = pV_EMAIL;
            _PB_PHONE = pB_PHONE;
            _PB_MOBILE = pB_MOBILE;
            _PV_COMMENTS = pV_COMMENTS;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable PR_CLI_GET_CONTACTS(long pB_ID_CLIENT)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_CLI_GET_CONTACTS");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "PV_ID_CLIENT", DbType.Int64, pB_ID_CLIENT);
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_CLI_GET_CONTACTS_IND");
                db1.AddInParameter(cmd, "PV_ID_CONTACT", DbType.Int64, _PB_ID_CONTACT);
                db1.ExecuteNonQuery(cmd);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _PB_ID_CLIENT = (long)dr["ID_CLIENT"];
                        _PV_NAME = (string)dr["NAME"];
                        _PV_SURNAMES = (string)dr["SURNAMES"];
                        _PV_EMAIL = (string)dr["EMAIL"];
                        _PB_PHONE = (long)dr["PHONE"];
                        _PB_MOBILE = (long)dr["MOBILE"];
                        _PV_COMMENTS = (string)dr["COMMENTS"];
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_CLI_ABM_CONTACTS");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                if (_PB_ID_CONTACT == 0)
                    db1.AddInParameter(cmd, "PB_ID_CONTACT", DbType.Int64, null);
                else
                    db1.AddInParameter(cmd, "PB_ID_CONTACT", DbType.Int64, _PB_ID_CONTACT);
                db1.AddInParameter(cmd, "PB_ID_CLIENT", DbType.String, _PB_ID_CLIENT);
                db1.AddInParameter(cmd, "PV_NAME", DbType.String, _PV_NAME);
                db1.AddInParameter(cmd, "PV_SURNAMES", DbType.String, _PV_SURNAMES);
                db1.AddInParameter(cmd, "PV_EMAIL", DbType.String, _PV_EMAIL);
                db1.AddInParameter(cmd, "PB_PHONE", DbType.Int64, _PB_PHONE);
                db1.AddInParameter(cmd, "PB_MOBILE", DbType.Int64, _PB_MOBILE);
                db1.AddInParameter(cmd, "PV_COMMENTS", DbType.String, _PV_COMMENTS);

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_USER").ToString()))
                //    PV_USUARIO = "";
                //else
                //    PV_USUARIO = (string)db1.GetParameterValue(cmd, "PV_USER");
                PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                resultado = PV_ERROR + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCIONPR ;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar||";
                return resultado;
            }
        }

        #endregion

    }
}