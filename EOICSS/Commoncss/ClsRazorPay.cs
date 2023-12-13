using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EOICSS.Commoncss
{
    public class ClsRazorPay
    {
        #region Live
        //public string key = "rzp_live_FHYV6DAmAOL9Y5";//"rzp_test_mpoFK73QDCwSQD";//rzp_live_FHYV6DAmAOL9Y5;//
        //public string secret = "DVaPGbf29OE6X01XAKPb9BUA";//"GzkBI9GTPK6Drir70OPwxhl4";//"DVaPGbf29OE6X01XAKPb9BUA";//
        //public string rzramount = "5000000";//"200";//"5000000";
        //public string actualamount = "50000";//"2";//"50000";
        #endregion

        #region Test
        public string key = "rzp_test_mpoFK73QDCwSQD";//rzp_live_FHYV6DAmAOL9Y5;//
        public string secret = "GzkBI9GTPK6Drir70OPwxhl4";//"DVaPGbf29OE6X01XAKPb9BUA";//
        public string rzramount = "200";//"5000000";
        public string actualamount = "2";//"50000";
        #endregion
    }
}