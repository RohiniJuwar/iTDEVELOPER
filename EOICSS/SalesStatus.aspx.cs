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
    public partial class SalesStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spresult.InnerHtml = "Please Wait....";
            string strStatus = "";
            #region EaseBuzz
            try
            {
                
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

                            strTokenNo = objmdoc.getTokenNoFromMdoc(AccessToken, CpProjecids, CPTokentypids, trasactionIds, strfirstname, strMiddlename, strLastname, strmob, stremailids, CPTokenAmount, CPPreference, CpSourcesIds, CpSourscDetaildID, strdescription, strchequen, strbankname, strbankaddress, strcomments, strplanunitids);


                        }

                        ///************

                        //string strbody = "Status: <strong>Success</strong><br>";
                        //strbody += "<br>Cheque No: <strong>" + strchequen + "</strong>";
                        //strbody += "<br>Bank Name: <strong>" + strbankname + "</strong>";
                        //strbody += "<br>Bank Branch: <strong>" + strbankaddress + "</strong>";
                        //strbody += "<br>TokenNo: <strong>" + strTokenNo + "</strong>";

                        string strbody = "Congratulations!. Your token number<b>(" + strTokenNo + ")</b> has been genereated & it has been emailed to you. We will inform you about the date of allotment soon. In case of any queries, please contact +912066669700. Thank you!.<br> Team Rohan Builders.";

                        spresult.InnerHtml = strbody;
                        //Session["strresult"] = strbody;
                        //string strquery = "exec [dbSSProcedures].[SP_Update_Transaction_PaymentDetails] '" + strtrmsnids + "','" + streasepayid + "','" + strbank_ref_num + "','" + strsessioids + "','" + strTokenNo + "','" + strStatus + "','" + strReturnAllValues + "','" + strPGatewySourc + "'";



                        //DataTable dtcss = new DataTable();


                        //dtcss = objcm.GetAllData(strquery);
                        Session["transactionIds"] = null;
                        //Response.Redirect("PayStatus.aspx");
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
                string strbodyerr = "Congratulations!. Your token number has been genereated & it has been emailed to you. We will inform you about the date of allotment soon. In case of any queries, please contact <xxx>. Thank you!.<br> Team Rohan Builders.";
                spresult.InnerHtml = strbodyerr;// "<span style='color:red'>" + ex.Message + "</span>";
            }
            #endregion
        }
    }
}