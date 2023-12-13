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
    public partial class PayStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["strresult"]!=null)
            {
                spresult.InnerHtml = Session["strresult"].ToString();
                Session["strresult"] = null;
            }
            else
            {
                spresult.InnerHtml = "Something went wrong!!";
            }
        }
    }
}