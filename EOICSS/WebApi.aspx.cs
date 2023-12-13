using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EOICSS
{
    public partial class WebApi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string Generate_otp(string phone_1, string stremailid, string strSourcess,string strbtntype,string strIds,string strotpentered)
        {
            char[] charArr = "0123456789".ToCharArray();
            string strrandom = string.Empty;
            Random objran = new Random();
            string sre = objran.Next(1111, 9999).ToString();
            
            if(strbtntype== "CheckOTP")
            {
                sre = strotpentered;
            }

            Commoncss.SendClass objcm = new Commoncss.SendClass();

            string strquery = "exec [dbSSProcedures].[SP_InsertUpdateCheck_OTP] "+ strIds + ",'"+ phone_1 + "','"+ stremailid + "','"+ sre + "','"+ strbtntype + "','"+ strSourcess + "'";

            DataTable dtcss = new DataTable();
            try
            {
                dtcss = objcm.GetAllData(strquery);
                strrandom = dtcss.Rows.Count > 0 ? dtcss.Rows[0][0].ToString() : "0";
            }
            catch (Exception exx)
            {
                strrandom = "Error:" + exx.Message.ToString();
            }



            return strrandom;


        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string TransactioninsertData(string Id, string CPPanardNo, string Projects, string Salutation, string First_Name, string Middle_Name, string Last_Name, string Mob, string WhatsAppNo, string EmailId, string Preferences, string TokenType, string TokenAmount, string Cheque_TRNNo, string Bank_Name, string Bank_Branch_Address, string Source, string Source_Detail, string Source_Description, string Comments, string Wing, string Unit_Type, string Unit_Number, string PaymentId, string PayRefid, string PaymentStatus, string btnType)
        {
            Commoncss.SendClass objcm = new Commoncss.SendClass();
            string strstatus = "";
            try
            {
                string strquery = "exec [dbSSProcedures].[SP_InsertUpdate_Transaction]  '" + Id + "','" + CPPanardNo + "','" + Projects + "','" + Salutation + "','" + First_Name + "','" + Middle_Name + "','" + Last_Name + "','" + Mob + "','" + WhatsAppNo + "','" + EmailId + "','" + Preferences + "','" + TokenType + "','" + TokenAmount + "','" + Cheque_TRNNo + "','" + Bank_Name + "','" + Bank_Branch_Address + "','" + Source + "','" + Source_Detail + "','" + Source_Description + "','" + Comments + "','" + Wing + "','" + Unit_Type + "','" + Unit_Number + "','" + PaymentId + "','" + PayRefid + "','" + PaymentStatus + "','" + btnType + "'";

                DataTable dtcss = new DataTable();

                dtcss = objcm.GetAllData(strquery);
                strstatus = dtcss.Rows.Count > 0 ? dtcss.Rows[0][0].ToString() : "0";
            }
            catch (Exception exx)
            {
                strstatus = "Error:" + exx.Message.ToString();
            }
            return strstatus;


        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string VerifiedandTransactioninsertData(string Id, string CPPanardNo, string Projects, string Salutation, string First_Name, string Middle_Name, string Last_Name, string Mob, string WhatsAppNo, string EmailId, string Preferences, string TokenType, string TokenAmount, string Cheque_TRNNo, string Bank_Name, string Bank_Branch_Address, string Source, string Source_Detail, string Source_Description, string Comments, string Wing, string Unit_Type, string Unit_Number, string PaymentId, string PayRefid, string PaymentStatus, string btnType,string strOTPIds,string strCutOTPEntered,string strsessionids,string strguids="",string strfilenames="")
        {
            Commoncss.SendClass objcm = new Commoncss.SendClass();
            Commoncss.MDOCApiAccess objMDOC = new Commoncss.MDOCApiAccess();
            string strstatus = "";
            try
            {
                string stridss = Projects + "^" + EmailId;
                DataTable dtff = new DataTable();
                dtff = objMDOC.GetBindListMDOC("", stridss, "EMAIL");
                string sOTPStatus = "Somethin went wrong";// Generate_otp(Mob, EmailId, "EOI OTP", "CheckOTP", strOTPIds, strCutOTPEntered);
                string strStatusss = "";
                string strvaluess = "";
                if (dtff.Rows.Count>0)
                {
                    strStatusss = dtff.Rows[0][0].ToString();
                    strvaluess = dtff.Rows[0][1].ToString();
                    if (strStatusss == "success")
                    {
                        sOTPStatus = "Verified";
                    }
                    else
                    {
                        sOTPStatus = strvaluess;
                    }
                }
                else
                {

                }
                
                if(sOTPStatus== "Verified")
                {
                    string strquery = "exec [dbSSProcedures].[SP_InsertUpdate_Transaction]  '" + Id + "','" + CPPanardNo + "','" + Projects + "','" + Salutation + "','" + First_Name + "','" + Middle_Name + "','" + Last_Name + "','" + Mob + "','" + WhatsAppNo + "','" + EmailId + "','" + Preferences + "','" + TokenType + "','" + TokenAmount + "','" + Cheque_TRNNo + "','" + Bank_Name + "','" + Bank_Branch_Address + "','" + Source + "','" + Source_Detail + "','" + Source_Description + "','" + Comments + "','" + Wing + "','" + Unit_Type + "','" + Unit_Number + "','" + PaymentId + "','" + PayRefid + "','" + PaymentStatus + "','" + btnType + "','" + strsessionids + "','" + strguids + "','" + strfilenames + "'";

                    DataTable dtcss = new DataTable();

                    dtcss = objcm.GetAllData(strquery);
                    strstatus = dtcss.Rows.Count > 0 ? dtcss.Rows[0][0].ToString() : "0";
                    strstatus = "Verified > " + strstatus;
                }
                else
                {
                    strstatus = sOTPStatus;
                }
            }
            catch (Exception exx)
            {
                strstatus = "Error:" + exx.Message.ToString();
            }
            return strstatus;
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string fngetClientData(string strmobno = "-")
        {
            Commoncss.SendClass objcm = new Commoncss.SendClass();
            string JSONresult = string.Empty;
            try
            {
                //string strquery = "select * from [dbo].[registration_2022] where registration_id='"+ strregid + "' and active='Y'";
                string strquery = "select top 1 * from [dbSSStandard].[TransactionData] where Mob='" + strmobno + "' order by cast(Id as int) desc";
                DataTable dt = objcm.GetAllData(strquery);

                JSONresult = JsonConvert.SerializeObject(dt);

            }
            catch (Exception ex)
            {
                JSONresult = "Error:" + ex.Message.ToString();
            }
            return JSONresult;
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string fnget_CSP_MDOCApi(string straAccesToken = "-",string strtypvalues="-",string strValues="-")
        {
            Commoncss.SendClass objcm = new Commoncss.SendClass();
            Commoncss.MDOCApiAccess objMDOC = new Commoncss.MDOCApiAccess();
            string JSONresult = string.Empty;string strfinaloutput = string.Empty;
            try
            {
                DataTable dts = new DataTable();

                if(strtypvalues=="CP")
                {
                    dts = objMDOC.GetChannelPartenrdetail(straAccesToken, strValues);
                }
                else if(strtypvalues=="PR")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "SL")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "TTL")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "TAMT")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "PL")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "WG")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "UT"|| strtypvalues == "UN")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "MOB")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "EMAIL")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                else if (strtypvalues == "SQFT")
                {
                    dts = objMDOC.GetBindListMDOC(straAccesToken, strValues, strtypvalues);
                }
                JSONresult = JsonConvert.SerializeObject(dts);

            }
            catch (Exception ex)
            {
                JSONresult = "Error:" + ex.Message.ToString();
            }
            return JSONresult;
        }



    }
}