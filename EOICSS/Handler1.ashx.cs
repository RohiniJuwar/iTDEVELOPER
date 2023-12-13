using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EOICSS
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strfilnaamee = "";
            if (context.Request.Files.Count > 0)
            {
                Guid rguid = Guid.NewGuid();
                string guidfd = rguid.ToString(); string singlfilename = "";
                if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/Chequedata/" + guidfd)) == false)
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Chequedata/" + guidfd));
                }


                HttpFileCollection files = context.Request.Files;


                string getgidtr = files.AllKeys[0].ToString().Split('^')[1];
                if (getgidtr == string.Empty)
                {
                    if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/Chequedata/" + guidfd)) == false)
                    {
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Chequedata/" + guidfd));
                    }
                }
                else
                {
                    guidfd = getgidtr;
                    if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/Chequedata/" + guidfd)) == false)
                    {
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Chequedata/" + guidfd));
                    }
                }

                string strname = "";
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fname = context.Server.MapPath("~/Chequedata/" + guidfd + "/" + file.FileName);
                    file.SaveAs(fname);
                    strname = file.FileName;
                }
                strfilnaamee = guidfd+"^"+ strname.TrimEnd(',');
                context.Response.ContentType = "text/plain";
                context.Response.Write(strfilnaamee);
                //context.Response.ContentType = "text/plain";

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}