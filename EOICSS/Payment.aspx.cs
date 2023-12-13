using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EOICSS
{
    public partial class Payment : System.Web.UI.Page
    {
        public string strkey;
        public string amount;
        public string ordername;
        public string orderdesc;
        public string orderId;
        public string CName;
        public string Cemail;
        public string CMob;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (!IsPostBack)
            {
                Commoncss.ClsRazorPay obrzrpay = new Commoncss.ClsRazorPay();
                amount = "400000";
                ordername = "Demo test";
                orderdesc = DateTime.Now.ToString("ddMMyyyyhhmmss");
                CName = "Chandra";
                Cemail = "it.developer@roahnbuilders.com";
                CMob = "9023247986";
                strkey = obrzrpay.key;


            }

        }


        public void redirectss()
        {
            Commoncss.ClsRazorPay objrazorpay = new Commoncss.ClsRazorPay();
            string strkey = objrazorpay.key;
            string strsecret = objrazorpay.secret;
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", txamount.Text.Trim() + "00"); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", DateTime.Now.ToString("ddMMyyyhhmmss"));
            input.Add("payment_capture", 1);

            string key = strkey;// "rzp_test_mpoFK73QDCwSQD";
            string secret = strsecret;// "GzkBI9GTPK6Drir70OPwxhl4";


            RazorpayClient client = new RazorpayClient(key, secret);
            amount = txamount.Text.Trim() + "00";
            strkey = key;
            ordername = "Demo test";
            orderdesc = "this is demo test";
            CName = "Chandra";
            Cemail = "it.developer@rohanbuilders.com";
            CMob = "7696117339";

            Order order = client.Order.Create(input);
            orderId = order["id"].ToString();
        }

        protected void btnpayaa_Click(object sender, EventArgs e)
        {
            redirectss();
        }
    }
}