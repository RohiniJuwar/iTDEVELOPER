using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EOICSS
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Request.IsSecureConnection)
            //{
            //    //redirect visitor to SSL connection
            //    Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
            //}
        }
    }
}