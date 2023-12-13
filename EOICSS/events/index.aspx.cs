using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EOICSS.events
{
    public partial class index : System.Web.UI.Page
    {
        public string strkey;
        public int amount;
        public string ordername;
        public string orderdesc;
        public string orderId;
        public string CName;
        public string Cemail;
        public string CMob;

        public string salt = System.Configuration.ConfigurationSettings.AppSettings["saltantra"];
        public string Key = System.Configuration.ConfigurationSettings.AppSettings["keyantra"];

        public string env = System.Configuration.ConfigurationSettings.AppSettings["envantra"];
        public string surls = System.Configuration.ConfigurationSettings.AppSettings["surl"];
        public string furls = System.Configuration.ConfigurationSettings.AppSettings["furl"];
    


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.AppendHeader("Cache-Control", "no-store, no-cache, must-revalidate, post-check=0, pre-check=0");
            if (!Request.IsSecureConnection)
            {
                //redirect visitor to SSL connection
                Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
            }
        }


        protected void btnpaydata_Click(object sender, EventArgs e)
        {
            redirectss();
        }
        public void redirectss()
        {

            //"csshdnName" runat = "se
            //"csshdnMob" runat = "ser
            //"csshdnEmailid" runat =
            //"csshdnAmount" runat = "
            //"" runat =
            //"" runat
            //"" ru
            //"" runa
            //"" runat = "
            //"" ru

            string strpaymentgatway = System.Configuration.ConfigurationSettings.AppSettings["PgatewaySource"];

        string strName = csshdnName.Value.ToString().Trim();
            string strmob= csshdnMob.Value.ToString().Trim();
            string stremailds= csshdnEmailid.Value.ToString().Trim();
            string cmount = csshdnAmount.Value.ToString().Trim();
            string strkyctyps= csshdnKYCTyps.Value.ToString().Trim();
            string strgovtidsno= csshdnGovtIdNo.Value.ToString().Trim();
            string strphases= csshdnPhasesTypes.Value.ToString().Trim();
            string strbuildings= csshdnBuildings.Value.ToString().Trim();
            string strunitnos= csshdnUnitNo.Value.ToString().Trim();
            string strprojectnames= csshdnProjectName.Value.ToString().Trim();
            string strSourcess= csshdnSources.Value.ToString().Trim();
            string strIpaddress= csshdnIpAddress.Value.ToString().Trim();
            string strDevicessss= csshdnDevicess.Value.ToString().Trim();

            DataTable dtstransdata = new DataTable();
            dtstransdata.Columns.Add("Names", typeof(string));
            dtstransdata.Columns.Add("MOb", typeof(string));
            dtstransdata.Columns.Add("Emailids", typeof(string));
            dtstransdata.Columns.Add("Amount", typeof(string));
            dtstransdata.Columns.Add("KycTyp", typeof(string));
            dtstransdata.Columns.Add("GovtIdNo", typeof(string));
            dtstransdata.Columns.Add("Phasetyp", typeof(string));
            dtstransdata.Columns.Add("Buildings", typeof(string));
            dtstransdata.Columns.Add("unitno", typeof(string));
            dtstransdata.Columns.Add("ProjectNames", typeof(string));

            dtstransdata.Rows.Add(strName, strmob, stremailds, cmount, strkyctyps, strgovtidsno, strphases, strbuildings, strunitnos, strprojectnames);

            Session["getdatatableevents"] = dtstransdata;

            Commoncss.SendClass objcm = new Commoncss.SendClass();
            string strqueryddd = "exec [DB_LaunchEvents].[dbo].[SP_Insert_LaunchData] '0','"+ strName + "','"+ strmob + "','"+ strkyctyps + "','"+ strgovtidsno + "','"+ strprojectnames + "','"+ strphases + "','"+ strbuildings + "','"+ strunitnos + "','"+ strSourcess + "','"+ strIpaddress + "','','','','','"+ strpaymentgatway + "','"+ cmount + "','"+ stremailds + "','"+ env + "','"+ strDevicessss + "'";

            DataTable dtctrdata = new DataTable();
            dtctrdata = objcm.GetAllData(strqueryddd);
            if (dtctrdata.Rows.Count > 0)
            {
                if (dtctrdata.Rows[0][0].ToString().ToLower().Contains("error"))
                {
                    Response.Redirect("/events/");
                }
                else
                {
                    string strreturvalues = dtctrdata.Rows[0][0].ToString();

                    string strids = strreturvalues.Split('^')[0].ToString().Trim();
                    string strunirefidss = strreturvalues.Split('^')[1].ToString().Trim();
                    string strfinencrypte = objcm.EnryptString(strreturvalues);

                    ///easebuz details
                    string amount = csshdnAmount.Value.ToString().Trim();
                    string firstname = csshdnName.Value.ToString().Trim();
                    string email = csshdnEmailid.Value.ToString().Trim();
                    string phone = csshdnMob.Value.ToString().Trim();
                    string productinfo = "EOI-Booking";
                    string surl = surls + "/events/Thankyou.aspx?ids=" + strfinencrypte;
                    string furl = furls + "/events/Thankyou.aspx?ids=" + strfinencrypte;
                    string Txnid = strunirefidss.Trim();
                    string UDF1 = "";
                    string UDF2 = "";
                    string UDF3 = "";
                    string UDF4 = "";
                    string UDF5 = "";

                    string UDF6 = "";
                    string UDF7 = "";
                    string UDF8 = "";
                    string UDF9 = "";
                    string UDF10 = "";

                    string Show_payment_mode = "";

                    string split_payments = "";
                    string sub_merchant_id = "";

                    string strsubmarchntids = strprojectnames + strphases;

                    strsubmarchntids = strsubmarchntids.Trim();

                    string submrchntidproj = System.Configuration.ConfigurationSettings.AppSettings[strsubmarchntids];

                    if (!String.IsNullOrEmpty(submrchntidproj))
                    {
                        sub_merchant_id = System.Configuration.ConfigurationSettings.AppSettings["isphasees"].ToString() == "Yes" ? submrchntidproj : "";
                    }

                    //call the object of class and start payment
                    Commoncss.Easebuzz t = new Commoncss.Easebuzz(salt, Key, env);
                    string strForm = t.initiatePaymentAPI(amount, firstname, email, phone, productinfo, surl, furl, Txnid, UDF1, UDF2, UDF3, UDF4, UDF5, UDF6, UDF7, UDF8, UDF9, UDF10, Show_payment_mode, split_payments, sub_merchant_id);
                    Page.Controls.Add(new LiteralControl(strForm));

                }
            }
        }


    }
}