using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appAmascuotas
{
    public class dominio
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _CODIGO = "";
        private string _DESCRIPCION = "";

        //Propiedades públicas
        public string CODIGO { get { return _CODIGO; } set { _CODIGO = value; } }
        public string DESCRIPCION { get { return _DESCRIPCION; } set { _DESCRIPCION = value; } }
        #endregion



        #region Métodos que NO requieren constructor
        public static DataTable Lista(string PV_DOMINIO)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_DOMINIOS");
                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, PV_DOMINIO);
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

        public static bool VerificarPlazo(decimal PD_PLAZO)
        {
            try
            {
                bool verifica = false;
                decimal valor1 = 1;
                decimal valor2 = 24;
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_DOMINIOS");
                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, "PLAZO");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable veri= db1.ExecuteDataSet(cmd).Tables[0];
                foreach (DataRow dr in veri.Rows)
                {
                    valor1 = decimal.Parse(dr["valor_caracter"].ToString());
                    valor2 = (decimal)dr["valor_numerico"];
                }
                if (PD_PLAZO >= valor1 & PD_PLAZO<=valor2)
                {
                    verifica = true;
                }
                return verifica;
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return false;
            }
            //try
            //{
            //    string verifica = "";
            //    //Database db = DatabaseFactory.CreateDatabase();
            //    string SQL_FU = "select dbo.FU_getPlazo("+PD_PLAZO+") as campo1";
            //    //string SQL_FU = "select dbo.FU_getPlazo(0) as campo1";
            //    DbCommand cmd = db1.GetSqlStringCommand(SQL_FU);
            //    //db1.AddInParameter(cmd, "PD_PLAZO", DbType.Decimal, PD_PLAZO);
            //    //cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            //    //verifica = db1.ExecuteNonQuery(cmd).ToString();
            //    DataTable veri = db1.ExecuteDataSet(cmd).Tables[0];

            //    return verifica;
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //    //DataTable dt = new DataTable();
            //    return "";
            //}

        }


        #endregion

    }
}