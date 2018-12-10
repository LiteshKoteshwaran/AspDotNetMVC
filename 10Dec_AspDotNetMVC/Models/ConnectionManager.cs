using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _10Dec_AspDotNetMVC.Models
{
    public class ConnectionManager
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        internal DataSet Fill(string QueryForAutoFilling)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = QueryForAutoFilling;
                DataSet objDs = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter();
                dAdapter.SelectCommand = cmd;
                con.Open();
                dAdapter.Fill(objDs);
                con.Close();
                return objDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}