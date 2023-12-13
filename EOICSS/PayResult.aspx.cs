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

namespace EOICSS
{
    public partial class PayResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spresult.InnerHtml = "Please Wait....";
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
                    Commoncss.MDOCApiAccess objmdoc = new Commoncss.MDOCApiAccess();
                    string strtrmsnids = "", strsessioids = "";
                    string strgetquery = Request.QueryString["ids"].ToString();
                    string strdectempIds = objcm.DecryptString(strgetquery);

                    string strqueryddtempd = "select * from [dbSSStandard].[TBl_Tempdetails] where Ids=" + strdectempIds;

                    string trasactionIds = "";
                    string CpSourcesIds = "";
                    string CpSourscDetaildID = "";
                    string CpProjecids = "";
                    string CPTokentypids = "";
                    string CPTokenAmount = "";
                    string CPPreference = "";
                    string AccessToken = "";
                    string CpPanNo = "";
                    string strTokenNo = "", strfirstname = "", strMiddlename = "", strLastname = "", strmob = "", stremailids = "", strchequen = "", strbankname = "", strbankaddress = "", strcomments = "", strplanunitids = "", strdescription = "";
                    DataTable dtgetr = objcm.GetAllData(strqueryddtempd);

                    if (dtgetr.Rows.Count > 0)
                    {

                        string[] merc_hash_vars_seq;
                        string merc_hash_string = string.Empty;
                        string merc_hash = string.Empty;
                        string order_id = string.Empty;
                        string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
                        merc_hash_vars_seq = hash_seq.Split('|');
                        Array.Reverse(merc_hash_vars_seq);
                        merc_hash_string = System.Configuration.ConfigurationSettings.AppSettings["salt"] + "|" + Request.Form["status"];
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

                        strtrmsnids = dtgetr.Rows[0]["Trans_Ids"].ToString();
                        trasactionIds = dtgetr.Rows[0]["Trans_Ids"].ToString();
                        CpSourcesIds = dtgetr.Rows[0]["CpSourcesIds"].ToString();
                        CpSourscDetaildID = dtgetr.Rows[0]["CpSourscDetaildID"].ToString();
                        CpProjecids = dtgetr.Rows[0]["CpProjecids"].ToString();
                        CPTokentypids = dtgetr.Rows[0]["CPTokentypids"].ToString();
                        CPTokenAmount = dtgetr.Rows[0]["CPTokenAmount"].ToString();
                        CPPreference = dtgetr.Rows[0]["CPPreference"].ToString();
                        AccessToken = dtgetr.Rows[0]["AccessToken"].ToString();
                        strplanunitids = dtgetr.Rows[0]["UnitNumber"].ToString();
                        strsessioids = dtgetr.Rows[0]["SessionIds"].ToString();

                        string strqueryddd = "select * from [dbSSStandard].[TransactionData] where Id=" + trasactionIds;

                        DataTable dtctrdata = new DataTable();

                        dtctrdata = objcm.GetAllData(strqueryddd);
                        if (dtctrdata.Rows.Count > 0)
                        {
                            strfirstname = dtctrdata.Rows[0]["First_Name"].ToString();
                            strMiddlename = dtctrdata.Rows[0]["Middle_Name"].ToString();
                            strLastname = dtctrdata.Rows[0]["Last_Name"].ToString();
                            strmob = dtctrdata.Rows[0]["Mob"].ToString();
                            stremailids = dtctrdata.Rows[0]["EmailId"].ToString();
                            strchequen = dtctrdata.Rows[0]["Cheque_TRNNo"].ToString();
                            strbankname = dtctrdata.Rows[0]["Bank_Name"].ToString();
                            strbankaddress = dtctrdata.Rows[0]["Bank_Branch_Address"].ToString();
                            strcomments = dtctrdata.Rows[0]["Comments"].ToString();
                            strdescription = dtctrdata.Rows[0]["Source_Description"].ToString();


                            if (strStatus == "success")
                            {
                                strTokenNo = objmdoc.getTokenNoFromMdoc(AccessToken, CpProjecids, CPTokentypids, trasactionIds, strfirstname, strMiddlename, strLastname, strmob, stremailids, CPTokenAmount, CPPreference, CpSourcesIds, CpSourscDetaildID, strdescription, strchequen, strbankname, strbankaddress, strcomments, strplanunitids);

                            }
                            else
                            {
                                strTokenNo = strStatus;
                            }


                        }

                        ///************

                        string strbody = "Status: <strong>" + strStatus + "</strong><br>PayId: <strong>" + streasepayid + "</strong>";
                        strbody += "<br>Bank_Ref_Num: <strong>" + strbank_ref_num + "</strong>";
                        strbody += "<br>TokenNo: <strong>" + strTokenNo + "</strong>";
                        spresult.InnerHtml = "Please Wait....";

                        Session["strresult"] = strbody;
                        string strquery = "exec [dbSSProcedures].[SP_Update_Transaction_PaymentDetails] '" + strtrmsnids + "','" + streasepayid + "','" + strbank_ref_num + "','" + strsessioids + "','" + strTokenNo + "','" + strStatus + "','" + strReturnAllValues + "','" + strPGatewySourc + "'";



                        DataTable dtcss = new DataTable();


                        dtcss = objcm.GetAllData(strquery);
                        Session["transactionIds"] = null;
                        Response.Redirect("PayStatus.aspx");
                    }
                    else
                    {
                        Response.Redirect("indexcss.aspx");
                    }
                }
                else
                {
                    Response.Redirect("indexcss.aspx");
                }
                ////*************

            }
            catch (Exception ex)
            {
                spresult.InnerHtml = "<span style='color:red'>" + ex.Message + "</span>";
            }
            #endregion

            #region razorpay
            //try
            //{
            //    Commoncss.SendClass objcm = new Commoncss.SendClass();
            //    if (Session["transactionIds"]!=null)
            //    {
            //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //        Commoncss.ClsRazorPay objrazorpay = new Commoncss.ClsRazorPay();
            //        Commoncss.MDOCApiAccess objmdoc = new Commoncss.MDOCApiAccess();

            //        string strkey = objrazorpay.key;
            //        string strsecret = objrazorpay.secret;
            //        string paymentId = Request.Form["razorpay_payment_id"];
            //        string key = strkey;
            //        string secret = strsecret;

            //        RazorpayClient client = new RazorpayClient(key, secret);
            //        string strtrmsnids = Session["transactionIds"].ToString();

            //        Dictionary<string, string> attributes = new Dictionary<string, string>();

            //        attributes.Add("razorpay_payment_id", paymentId);
            //        attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
            //        attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

            //        Utils.verifyPaymentSignature(attributes);




            //        string trasactionIds = "";
            //        string CpSourcesIds = "";
            //        string CpSourscDetaildID = "";
            //        string CpProjecids = "";
            //        string CPTokentypids = "";
            //        string CPTokenAmount = "";
            //        string CPPreference = "";
            //        string AccessToken = "";
            //        string CpPanNo = "";
            //        string strTokenNo = "", strfirstname = "", strMiddlename = "", strLastname = "", strmob = "", stremailids = "", strchequen = "", strbankname = "", strbankaddress = "", strcomments = "", strplanunitids = "", strdescription = "";
            //        DataTable dtgetr = (Session["getdatatable"]) as DataTable;

            //        if (dtgetr.Rows.Count>0)
            //        {
            //            trasactionIds = dtgetr.Rows[0]["trasactionIds"].ToString();
            //            CpSourcesIds = dtgetr.Rows[0]["CpSourcesIds"].ToString();
            //            CpSourscDetaildID = dtgetr.Rows[0]["CpSourscDetaildID"].ToString();
            //            CpProjecids = dtgetr.Rows[0]["CpProjecids"].ToString();
            //            CPTokentypids = dtgetr.Rows[0]["CPTokentypids"].ToString();
            //            CPTokenAmount = dtgetr.Rows[0]["CPTokenAmount"].ToString();
            //            CPPreference = dtgetr.Rows[0]["CPPreference"].ToString();
            //            AccessToken = dtgetr.Rows[0]["AccessToken"].ToString();
            //            strplanunitids = dtgetr.Rows[0]["UnitNumber"].ToString();

            //            string strqueryddd = "select * from [dbSSStandard].[TransactionData] where Id=" + trasactionIds;
            //            DataTable dtctrdata = new DataTable();


            //            dtctrdata = objcm.GetAllData(strqueryddd);
            //            if(dtctrdata.Rows.Count>0)
            //            {
            //                strfirstname = dtctrdata.Rows[0]["First_Name"].ToString();
            //                strMiddlename = dtctrdata.Rows[0]["Middle_Name"].ToString();
            //                strLastname = dtctrdata.Rows[0]["Last_Name"].ToString();
            //                strmob = dtctrdata.Rows[0]["Mob"].ToString();
            //                stremailids = dtctrdata.Rows[0]["EmailId"].ToString();
            //                strchequen = dtctrdata.Rows[0]["Cheque_TRNNo"].ToString();
            //                strbankname = dtctrdata.Rows[0]["Bank_Name"].ToString();
            //                strbankaddress = dtctrdata.Rows[0]["Bank_Branch_Address"].ToString();
            //                strcomments = dtctrdata.Rows[0]["Comments"].ToString();
            //                strdescription = dtctrdata.Rows[0]["Source_Description"].ToString();

            //                strTokenNo = objmdoc.getTokenNoFromMdoc(AccessToken, CpProjecids, CPTokentypids, trasactionIds, strfirstname, strMiddlename, strLastname, strmob, stremailids, CPTokenAmount, CPPreference, CpSourcesIds, CpSourscDetaildID, strdescription, strchequen, strbankname, strbankaddress, strcomments, strplanunitids);
            //            }
            //        }






            //        string strbody = "PaymentId: <strong>" + paymentId + "</strong>";
            //        strbody += "<br>OrderId: <strong>" + Request.Form["razorpay_order_id"] + "</strong>";
            //        strbody += "<br>TokenNo: <strong>" + strTokenNo + "</strong>";
            //        spresult.InnerHtml = strbody;


            //        string strquery = "exec [dbSSProcedures].[SP_Update_Transaction_PaymentDetails] '" + strtrmsnids + "','" + paymentId + "','" + Request.Form["razorpay_order_id"] + "','" + Session["Sessionids"].ToString() + "','" + strTokenNo + "'";



            //        DataTable dtcss = new DataTable();


            //        dtcss = objcm.GetAllData(strquery);
            //        Session["transactionIds"] = null;
            //    }
            //    else
            //    {
            //        Response.Redirect("index.aspx");
            //    }
            //}
            //catch (Exception ewx)
            //{
            //    spresult.InnerText = ewx.Message.ToString();
            //}
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