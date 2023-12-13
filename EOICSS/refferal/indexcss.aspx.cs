using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EOICSS.refferal
{
    public partial class indexcss : System.Web.UI.Page
    {
        public string strkey;
        public int amount;
        public string ordername;
        public string orderdesc;
        public string orderId;
        public string CName;
        public string Cemail;
        public string CMob;

        public string salt = System.Configuration.ConfigurationSettings.AppSettings["salt"];
        public string Key = System.Configuration.ConfigurationSettings.AppSettings["key"];

        public string env = System.Configuration.ConfigurationSettings.AppSettings["env"];
        public string surls = System.Configuration.ConfigurationSettings.AppSettings["surl"];
        public string furls = System.Configuration.ConfigurationSettings.AppSettings["furl"];


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.AppendHeader("Cache-Control", "no-store, no-cache, must-revalidate, post-check=0, pre-check=0");
            Commoncss.SendClass objcm = new Commoncss.SendClass();
            Commoncss.MDOCApiAccess objMDOC = new Commoncss.MDOCApiAccess();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {


                    Session["getdatatable"] = null;
                    string strcpids = Request.QueryString["id"];
                    cssCPPanNo.Value = strcpids;
                    Session["CpPanNo"] = strcpids;



                    string strquery = "exec [dbSSProcedures].[SP_Insert_Transaction_LogData] 'New','" + strcpids + "','Index Page','OnLoading','Loaded'";

                    DataTable dtcss = new DataTable();

                    dtcss = objcm.GetAllData(strquery);
                    csshdnSessionids.Value = dtcss.Rows.Count > 0 ? dtcss.Rows[0][0].ToString() : "0";
                    Session["Sessionids"] = csshdnSessionids.Value;


                    string strres = objMDOC.strAccessToken();
                    string strheadder = objMDOC.strReturnJSONValues("access_token", strres);
                    csshdnTokenaccs.Value = strheadder;
                    Session["AccessToken"] = strheadder;


                    //if (Session["Sessionids"] != null)
                    //{
                    //    csshdnTokenaccs.Value = Session["AccessToken"].ToString();

                    //    string strres = objMDOC.strAccessToken();
                    //    string strheadder = objMDOC.strReturnJSONValues("access_token", strres);
                    //    csshdnTokenaccs.Value = strheadder;
                    //    Session["AccessToken"] = strheadder;

                    //}
                    //else
                    //{
                    //    string strquery = "exec [dbSSProcedures].[SP_Insert_Transaction_LogData] 'New','" + strcpids + "','Index Page','OnLoading','Loaded'";

                    //    DataTable dtcss = new DataTable();

                    //    dtcss = objcm.GetAllData(strquery);
                    //    csshdnSessionids.Value = dtcss.Rows.Count > 0 ? dtcss.Rows[0][0].ToString() : "0";
                    //    Session["Sessionids"] = csshdnSessionids.Value;


                    //    string strres = objMDOC.strAccessToken();
                    //    string strheadder = objMDOC.strReturnJSONValues("access_token", strres);
                    //    csshdnTokenaccs.Value = strheadder;
                    //    Session["AccessToken"] = strheadder;
                    //}
                }
                else
                {
                    Session.Abandon();
                    Server.Transfer("/404.aspx");
                }
            }
        }

        protected void btnpaydata_Click(object sender, EventArgs e)
        {
            redirectss();
        }
        public void redirectss()
        {

            string cmount = csshdnAmount.Value.ToString().Trim();
            string strprojecname = csshdncpProjectName.Value.ToString();
            string strToketypidd = csshdncptokenTypds.Value.ToString();
            string strpreferneccd = csshdncpPrefernces.Value.ToString();

            string strids = csshdntransactionId.Value.ToString();

            DataTable dtstransdata = new DataTable();
            dtstransdata.Columns.Add("trasactionIds", typeof(string));
            dtstransdata.Columns.Add("CpSourcesIds", typeof(string));
            dtstransdata.Columns.Add("CpSourscDetaildID", typeof(string));
            dtstransdata.Columns.Add("CpProjecids", typeof(string));
            dtstransdata.Columns.Add("CPTokentypids", typeof(string));
            dtstransdata.Columns.Add("CPTokenAmount", typeof(string));
            dtstransdata.Columns.Add("CPPreference", typeof(string));
            dtstransdata.Columns.Add("AccessToken", typeof(string));
            dtstransdata.Columns.Add("CpPanNo", typeof(string));
            dtstransdata.Columns.Add("UnitNumber", typeof(string));


            dtstransdata.Rows.Add(strids, csshdncpSourcIds.Value.ToString(), csshdncpSourdetailds.Value.ToString(), csshdnProjecids.Value.ToString(), strToketypidd, csshdnAmount.Value.ToString().Trim(), strpreferneccd, csshdnTokenaccs.Value.ToString().Trim(), Session["CpPanNo"].ToString(), csshdncpUnitNumber.Value.ToString().Trim());


            Session["transactionIds"] = strids;
            csshdnSessionids.Value = Session["Sessionids"].ToString();
            Session["getdatatable"] = dtstransdata;

            Commoncss.SendClass objcm = new Commoncss.SendClass();
            string strqueryddd = "exec [dbSSProcedures].[SP_Insert_TempDetails] '0','" + csshdnSessionids.Value.ToString() + "','" + strids + "','" + csshdncpSourcIds.Value.ToString() + "','" + csshdncpSourdetailds.Value.ToString() + "','" + csshdnProjecids.Value.ToString() + "','" + strToketypidd + "','" + csshdnAmount.Value.ToString().Trim() + "','" + strpreferneccd + "','" + csshdnTokenaccs.Value.ToString().Trim() + "','" + csshdncpUnitNumber.Value.ToString().Trim() + "','Refferal','" + csshdncpMobNo.Value.ToString().Trim() + "'";
            DataTable dtctrdata = new DataTable();
            dtctrdata = objcm.GetAllData(strqueryddd);
            if (dtctrdata.Rows.Count > 0)
            {
                if (dtctrdata.Rows[0][0].ToString().Contains("Error"))
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    string strtrnsidss = dtctrdata.Rows[0][0].ToString();
                    string strfinencrypte = objcm.EnryptString(strtrnsidss);

                    ///easebuz details
                    //string amount = csshdnAmount.Value.ToString().Trim();
                    string amount = System.Configuration.ConfigurationSettings.AppSettings["IsTestAmount"].ToString() == "Yes" ? "1" : csshdnAmount.Value.ToString().Trim();
                   

                    string firstname = csshdnName.Value.ToString().Trim();
                    string email = csshdnEmailid.Value.ToString().Trim();
                    string phone = csshdnMob.Value.ToString().Trim();
                    string productinfo = "EOI";
                    string surl = surls + "PayResult.aspx?ids=" + strfinencrypte;
                    string furl = furls + "PayResult.aspx?ids=" + strfinencrypte;
                    string Txnid = strids.Trim();
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


                    strprojecname = strprojecname.Replace("Rohan", "").Trim();

                    string submrchntidproj = System.Configuration.ConfigurationSettings.AppSettings[strprojecname];

                    if (!String.IsNullOrEmpty(submrchntidproj))
                    {
                        sub_merchant_id = submrchntidproj;
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