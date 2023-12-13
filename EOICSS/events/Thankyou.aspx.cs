using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;


namespace EOICSS.events
{
    public partial class Thankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //spresult.InnerHtml = "Please Wait....";
            #region EaseBuzz
            try
            {
                string strbank_ref_num = string.Empty;
                string streasepayid = string.Empty;
                string strReturnAllValues = string.Empty;
                string strStatus = string.Empty;
                string strPGatewySourc = System.Configuration.ConfigurationSettings.AppSettings["PgatewaySource"];
                if (Request.QueryString["ids"] != null)
                {
                    Commoncss.SendClass objcm = new Commoncss.SendClass();
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    string strtrmsnids = "", strsessioids = "";
                    string strgetquery = Request.QueryString["ids"].ToString();
                    string strdectempIds = objcm.DecryptString(strgetquery);

                    string strIdss = strdectempIds.Split('^')[0].ToString().Trim();
                    string strrefuidss = strdectempIds.Split('^')[1].ToString().Trim();

                    string strqueryddtempd = "select * from [DB_LaunchEvents].[dbo].[Tbl_LaunchData] where Id=" + strIdss + " and PaymentStatus =''";

                    DataTable dtgetr = objcm.GetAllData(strqueryddtempd);
                    if (dtgetr.Rows.Count > 0)
                    {
                        string sstramounts = dtgetr.Rows[0]["PayAmount"].ToString().Trim();
                        string[] merc_hash_vars_seq;
                        string merc_hash_string = string.Empty;
                        string merc_hash = string.Empty;
                        string order_id = string.Empty;
                        string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
                        merc_hash_vars_seq = hash_seq.Split('|');
                        Array.Reverse(merc_hash_vars_seq);
                        merc_hash_string = System.Configuration.ConfigurationSettings.AppSettings["saltantra"] + "|" + Request.Form["status"];
                        foreach (string merc_hash_var in merc_hash_vars_seq)
                        {
                            merc_hash_string += "|";
                            merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");
                        }
                        merc_hash = Easebuzz_Generatehash512(merc_hash_string).ToLower();
                        if (merc_hash != Request.Form["hash"])
                        {
                            //Response.Write("Hash value did not matched");
                            strStatus = "Hash value did not matched";
                        }
                        else
                        {
                            order_id = Request.Form["txnid"];
                            strReturnAllValues = Request.Form.ToString().Replace("&", "~");
                            strStatus = Request.Form["status"].ToString();//success
                            strbank_ref_num = Request.Form["bank_ref_num"].ToString();
                            streasepayid = Request.Form["easepayid"].ToString();
                        }
                        if (strStatus == "success")
                        {
                            imgyes.Style.Add("display", "initial");
                        }
                        else
                        {
                            imgno.Style.Add("display", "initial");
                        }

                        spstatus.InnerText = strStatus;
                        sppaymentid.InnerText = streasepayid;
                        sptransactionid.InnerText = order_id;
                        spamount.InnerText = sstramounts;

                        ///************

                        string strquery = "exec [DB_LaunchEvents].[dbo].[Update_PaymentStatus_Tbl_LaunchData] '" + strIdss + "','" + streasepayid + "','" + order_id + "','" + strStatus + "','" + strReturnAllValues + "'";

                        DataTable dtcss = new DataTable();
                        dtcss = objcm.GetAllData(strquery);
                    }
                    else
                    {
                        Response.Redirect("/events/index.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/events/index.aspx");
                }
                ////*************

            }
            catch (Exception ex)
            {
                Response.Redirect("/events/index.aspx");
            }
            #endregion
        }

        // hashcode generation
        public string Easebuzz_Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;

        }

    }
}