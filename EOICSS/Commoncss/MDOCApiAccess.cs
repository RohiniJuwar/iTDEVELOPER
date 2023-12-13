using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace EOICSS.Commoncss
{
    public class MDOCApiAccess
    {


        public string strAccessToken()
        {
            string strat = "";

            var client = new RestClient("https://mdoc.rohanbuilders.com/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "BASIC N2ZlYzExYzgtYzk2ZC00MDczLWFiODQtY2Q4OTU5MzMzZTBkOjYzZDQ1OGQ5LTIwYTEtNGJhNC05NTQzLTllZDI4M2JlZTQ0ZA==");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", ".AspNet.ApplicationCookie=zwqOvnX9ucEYk3yNUbK1wXuJopmBmltQaTCfliVb5p6KrkoxZvlH--eQu3pMsjtC6DYvu45ZrSojsTbhnxrAhNRCabCQ712HiwjDmEL6ev-YswaqP5IVFuePJUmCOVzQJcqcPsWhmQTNUcx0MNfSDAW-WcYNXaMtSuCm73g_kgTLf9vOUo-xG_-mZaqnJeo7BwdP_KcYpzI8zYeCPQ6AkqwEi8nFWUDQjhLhVUpQqfjLqUm8aSMkj1Us3YZNLIBRGGV72TWkM5URuDPiby63UG-47qo94IXuVfwcfZ1QqgVglkbS-eJ6XGx_-vWlLGSC_J0ElNmyG2jvB-UqR4ONUNVsARLVqaVjpCUC6W-juRND-n8htyFSe9uluAg_KqFSEEW-74QrTokYZqbZOdAWvcpdS7nn-I-YzSy2VEooW7QA8voQtccHq5N5En3RCSOsGKm-bCK6k74zSNDSBxbBDGIYzIWFOSQfraQTczf7mKE4ytcbodelsrh_YmliTN4DVngke-AOzEEq2visKyG6mg");
            request.AddParameter("username", "IT.Support");
            request.AddParameter("password", "Mak@1234");
            request.AddParameter("grant_type", "password");
            IRestResponse response = client.Execute(request);
            strat = response.Content;

            return strat;
        }


        public string strReturnJSONValues(string strheadername,string strjsondata) {
            string strreturnval = "";
            var details = JObject.Parse(strjsondata);
            strreturnval = details[strheadername].ToString();
            return strreturnval;
        }


        public string GetJArrayValue(JObject yourJArray)
        {
            string value = "";
            try
            {
                foreach (JToken item in yourJArray.Children())
                {
                    if (item.ToString().Contains("success"))
                    {
                        string sed = yourJArray["error_message"].ToString();
                        value = "E^" + sed;
                    }
                    else if (item.ToString().Contains("request_id"))
                    {
                        string sed = yourJArray["request_id"].ToString();
                        value = "S^" + sed;
                    }
                    else if (item.ToString().Contains("MessageID"))
                    {
                        string sed = yourJArray["MessageID"].ToString();
                        value = "S^" + sed;
                    }
                    else
                    {
                        value = "E^" + yourJArray.ToString();
                    }
                    //var itemProperties = item.Children<JProperty>();
                    ////If the property name is equal to key, we get the value
                    //var myElement = itemProperties.FirstOrDefault(x => x.Name == "request_id".ToString());
                    //value = myElement.Value.ToString(); //It run into an exception here because myElement is null
                    break;
                }
            }
            catch (Exception exxc)
            {
                value = "E^" + exxc.Message.ToString();
            }

            return value;
        }

        public DataTable GetChannelPartenrdetail(string strAccess,string strIds)
        {
            string strres = strAccessToken();
            string strheadder = strReturnJSONValues("access_token", strres);
            strAccess = strheadder;
            string stastusscc = "",strnamss="",strsourcids = "";
            DataTable dts = new DataTable();
            dts.Columns.Add("Name", typeof(string));
            dts.Columns.Add("Mob", typeof(string));
            dts.Columns.Add("Emailid", typeof(string));
            dts.Columns.Add("SourceIds", typeof(string));
            dts.Columns.Add("SourcdetailId", typeof(string));
            dts.Columns.Add("Addres", typeof(string));

            //var client = new RestClient("https://mdoc.rohanbuilders.com/MDocBoxAPI/GetChannelPartnerByPanNo?panNo="+ strIds);
            //var client = new RestClient("https://mdoc.rohanbuilders.com/MDocBoxAPI/GetChannelPartnerByName?name=" + strIds);
            var client = new RestClient("https://mdoc.rohanbuilders.com/MDocBoxAPI/GetChannelPartnerById?id=" + strIds);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer "+ strAccess);
            IRestResponse response = client.Execute(request);
            string strreponsee = response.Content.ToString();
            stastusscc = strReturnJSONValues("status", strreponsee);
            if (stastusscc == "success")
            {
                string strpacck = strReturnJSONValues("package_info", strreponsee);

                dts.Rows.Add(strReturnJSONValues("channelPartnerName", strpacck), strReturnJSONValues("mobileNo", strpacck), strReturnJSONValues("emailId", strpacck), strReturnJSONValues("sourceId", strpacck), strReturnJSONValues("sourceDetailId", strpacck), strReturnJSONValues("address", strpacck));
            }
            else
            {
                string strmessg = strReturnJSONValues("message", strreponsee);
                dts.Rows.Add(strmessg, strmessg, strmessg, strmessg, strmessg, strmessg);
            }

            return dts;
        }

        public DataTable GetBindListMDOC(string strAccess, string strIds,string strTypss)
        {

            string strres = strAccessToken();
            string strheadder = strReturnJSONValues("access_token", strres);
            strAccess = strheadder;

            string stastusscc = "", strnamss = "", strsourcids = "";
            DataSet dsts = new DataSet();
            DataTable dts = new DataTable();
            dts.Columns.Add("Texts", typeof(string));
            dts.Columns.Add("Values", typeof(string));

            string strurl = strTypss == "SQFT" ? "https://mdoc.rohanbuilders.com/MDocBoxAPI/GetMappingUnitInfo?Id=" + strIds + "" : strTypss == "MOB"? "https://mdoc.rohanbuilders.com/MDocBoxAPI/GetCheckUniqueMobileNumber?projectId=" + strIds.Split('^')[0].ToString() + "&mobileNo=" + strIds.Split('^')[1].ToString() + "" : strTypss == "EMAIL" ? "https://mdoc.rohanbuilders.com/MDocBoxAPI/GetCheckUniqueEmail?projectId=" + strIds.Split('^')[0].ToString() + "&email=" + strIds.Split('^')[1].ToString() + "" : strTypss =="UT" || strTypss=="UN" ? "https://mdoc.rohanbuilders.com/MDocBoxAPI/GetTokenUnitMappingFloorPlanProjectWingUnitTypeFlatNoList?projectId=" + strIds.Split('^')[0].ToString() + "&wing=" + strIds.Split('^')[1].ToString() + "&unitType=" + strIds.Split('^')[2].ToString() + "" :  strTypss == "TAMT" || strTypss=="WG" ? "https://mdoc.rohanbuilders.com/MDocBoxAPI/GetProjectTokenTypeData?projectId=" + strIds.Split('^')[0].ToString() + "&tokenTypeId=" + strIds.Split('^')[1].ToString() + "" : strTypss == "PL" || strTypss == "TTL" ? "https://mdoc.rohanbuilders.com/MDocBoxAPI/GetTokenBookingProjectData?projectId=" + strIds + "" : "https://mdoc.rohanbuilders.com/MDocBoxAPI/GetTokenBookingFormData";

            var client = new RestClient(strurl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + strAccess);
            IRestResponse response = client.Execute(request);
            string strreponsee = response.Content.ToString();
            stastusscc = strReturnJSONValues("status", strreponsee);

            #region Mobile Number or Email Id Exists or not
            if (strTypss == "MOB" || strTypss == "EMAIL")
            {
                dts.Rows.Add(strReturnJSONValues("status", strreponsee), strReturnJSONValues("message", strreponsee));
            }
            #endregion
            else if (stastusscc == "success")
            {
                string strpacck = strReturnJSONValues("package_info", strreponsee);
                #region ProjectList
                if (strTypss=="PR")
                {
                    //string strprojectsd = strReturnJSONValues("listProjects", strpacck);
                    string strprojectsd = strReturnJSONValues("projects", strpacck);
                    List<object> lstProject = JsonConvert.DeserializeObject<List<object>>(strprojectsd);
                    if (lstProject.Count > 0)
                    {

                        for (int i = 0; i < lstProject.Count; i++)
                        {
                            string strprojlist = lstProject[i].ToString();
                            dts.Rows.Add(strReturnJSONValues("Text", strprojlist), strReturnJSONValues("Value", strprojlist));
                        }
                    }
                }
                #endregion

                #region Solution
                if (strTypss == "SL")
                {
                    string strsolutation = strReturnJSONValues("salutation", strpacck);
                    List<object> draftInvoices = JsonConvert.DeserializeObject<List<object>>(strsolutation);
                    if (draftInvoices.Count > 0)
                    {
                        for (int i = 0; i < draftInvoices.Count; i++)
                        {
                            string strindisesaolut = draftInvoices[i].ToString();
                            dts.Rows.Add(strReturnJSONValues("Text", strindisesaolut), strReturnJSONValues("Value", strindisesaolut));
                        }
                    }
                }
                #endregion

                #region Token List
                if (strTypss == "TTL")
                {
                    //string strTokenTypeList = strReturnJSONValues("filterTokenTypeList", strpacck);
                    string strTokenTypeList = strReturnJSONValues("projectTokenTypeList", strpacck);
                    List<object> lsttokentypelist = JsonConvert.DeserializeObject<List<object>>(strTokenTypeList);
                    if (lsttokentypelist.Count > 0)
                    {
                        for (int i = 0; i < lsttokentypelist.Count; i++)
                        {
                            string strtokentypelist = lsttokentypelist[i].ToString();
                            dts.Rows.Add(strReturnJSONValues("Text", strtokentypelist), strReturnJSONValues("Value", strtokentypelist));
                        }
                    }
                }
                #endregion

                #region Token Amount
                if (strTypss == "TAMT")
                {
                    string strTokenAmount = strReturnJSONValues("tokenAmount", strpacck);
                    string stramountt = strTokenAmount.Contains(".") == true ? strTokenAmount.Split('.')[0].ToString() : strTokenAmount;
                    dts.Rows.Add(strTokenAmount, stramountt);
                }
                #endregion

                #region Preference List
                if (strTypss == "PL")
                {
                    string strprefenceList = strReturnJSONValues("preferenceList", strpacck);
                    List<object> lstpreferList = JsonConvert.DeserializeObject<List<object>>(strprefenceList);
                    if (lstpreferList.Count > 0)
                    {
                        for (int i = 0; i < lstpreferList.Count; i++)
                        {
                            string strpreflist = lstpreferList[i].ToString();
                            dts.Rows.Add(strReturnJSONValues("Text", strpreflist), strReturnJSONValues("Value", strpreflist));
                        }
                    }
                }
                #endregion

                #region WingList
                if (strTypss == "WG")
                {
                    string strStatuMapping = strReturnJSONValues("showUnitMapping", strpacck);
                    if (strStatuMapping == "True")
                    {
                        string strWingList= strReturnJSONValues("wingList", strpacck);
                        List<object> lstwinglist = JsonConvert.DeserializeObject<List<object>>(strWingList);
                        if (lstwinglist.Count > 0)
                        {
                            for (int i = 0; i < lstwinglist.Count; i++)
                            {
                                string strwnglist = lstwinglist[i].ToString();
                                dts.Rows.Add(strReturnJSONValues("Text", strwnglist), strReturnJSONValues("Value", strwnglist));
                            }
                        }
                    }
                }
                #endregion

                #region UnitTypes
                if (strTypss == "UT")
                {
                    string strunittypeList = strReturnJSONValues("unitTypeList", strpacck);
                    List<object> lstunittypelist = JsonConvert.DeserializeObject<List<object>>(strunittypeList);
                    if (lstunittypelist.Count > 0)
                    {
                        for (int i = 0; i < lstunittypelist.Count; i++)
                        {
                            string strutlist = lstunittypelist[i].ToString();
                            dts.Rows.Add(strReturnJSONValues("Text", strutlist), strReturnJSONValues("Value", strutlist));
                        }
                    }
                }
                #endregion

                #region Unit Number
                if (strTypss == "UN")
                {
                    string strflateList = strReturnJSONValues("flatNoList", strpacck);
                    List<object> lstflatlist = JsonConvert.DeserializeObject<List<object>>(strflateList);
                    if (lstflatlist.Count > 0)
                    {
                        for (int i = 0; i < lstflatlist.Count; i++)
                        {
                            string strflatlist = lstflatlist[i].ToString();
                            dts.Rows.Add(strReturnJSONValues("Text", strflatlist), strReturnJSONValues("Value", strflatlist));
                        }
                    }
                }
                #endregion

                #region CarpetArea
                if (strTypss == "SQFT")
                {
                    string strTokenAmount = strReturnJSONValues("totalUsableAreaSqft", strpacck);
                    //string stramountt = strTokenAmount.Contains(".") == true ? strTokenAmount.Split('.')[0].ToString() : strTokenAmount;
                    dts.Rows.Add(strTokenAmount, strTokenAmount);
                }
                #endregion

            }
            return dts;
        }

        public string getTokenNoFromMdoc(string strAccessTokens,string projids,string strtokenTypeIds,string strSID,string strFirstname,string strMiddelname,string strlastname,string strMobNo,string strEmailids,string strToeknAmount,string strPreference,string strSourceIds,string strSourDetailiDs,string strSourcDes,string strChequeno,string strBankName,string strBankAdress,string strComments,string strfllorPlanids)
        {
            string strres = strAccessToken();
            string strheadder = strReturnJSONValues("access_token", strres);
            strAccessTokens = strheadder;

            string strReferencNo = "", stastusscc = "";
            var client = new RestClient("https://mdoc.rohanbuilders.com/MDocBoxAPI/AddTokenBooking");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer "+ strAccessTokens);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("PrId", projids);
            request.AddParameter("TokenTypeId", strtokenTypeIds);
            request.AddParameter("SID", "1");
            request.AddParameter("FirstName", strFirstname);
            request.AddParameter("MiddleName", strMiddelname);
            request.AddParameter("LastName", strlastname);
            request.AddParameter("MobileNo", strMobNo);
            request.AddParameter("Email", strEmailids);
            request.AddParameter("TokenAmount", strToeknAmount);
            request.AddParameter("Preference", strPreference);
            request.AddParameter("SourceId", strSourceIds);
            request.AddParameter("SourceDetailId", strSourDetailiDs);
            request.AddParameter("SourceDescription", strSourcDes);
            request.AddParameter("ChequeNo", strChequeno);
            request.AddParameter("BankName", strBankName);
            request.AddParameter("BankAddress", strBankAdress);
            request.AddParameter("Comments", strComments);
            request.AddParameter("FloorPlanId", strfllorPlanids);
            IRestResponse response = client.Execute(request);

            string strreponsee = response.Content.ToString();
            stastusscc = strReturnJSONValues("status", strreponsee);
            if (stastusscc == "success")
            {
                string strToenN= strReturnJSONValues("tokenNumber", strreponsee);
                strReferencNo = strToenN;
            }
            else
            {
                strReferencNo = strReturnJSONValues("message", strreponsee);
            }
                return strReferencNo;
        }
    }
}