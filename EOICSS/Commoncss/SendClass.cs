using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Web;
using System.Net.Mime;

namespace EOICSS.Commoncss
{
    public class SendClass
    {
        private static string constr = ConfigurationManager.AppSettings["finkraftconn"].ToString();
        public bool execqry(string qry)
        {
            SqlConnection sqlConnection = new SqlConnection(SendClass.constr);
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = qry;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }

        public string execqryWithResult(string qry)
        {
            string strreturn = "N^Something Went wrong!";
            SqlConnection sqlConnection = new SqlConnection(SendClass.constr);
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = qry;
                sqlCommand.ExecuteNonQuery();
                strreturn = "Y^Data saved successfully";
            }
            catch (Exception ex)
            {
                ex.ToString();
                strreturn = "Y^" + ex.Message.ToString();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
            return strreturn;
        }

        public string StatQuery(string qry)
        {
            string strmsg = "N";
            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(SendClass.constr);
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = qry;
                SqlDataAdapter dp = new SqlDataAdapter(sqlCommand);
                dp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strmsg = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
            return strmsg;
        }

        public DataTable GetAllData(string strquery)
        {
            string strmsg = "N";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(SendClass.constr);
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strquery;
                SqlDataAdapter dp = new SqlDataAdapter(sqlCommand);
                dp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
            return dt;

        }


        public DataTable GetCommonData(string query, Dictionary<string, string> dic, string tf, string typee)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(SendClass.constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    if (tf == "T")
                    {
                        foreach (KeyValuePair<string, string> item in dic)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }
                    }

                    cmd.CommandType = typee == "Text" ? CommandType.Text : CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dp.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                    }
                }
            }
            return dt;
        }



        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

    }
}