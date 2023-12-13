<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="EOICSS.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <form id="fm1" action="PayResult.aspx" method="post" name="razorpayForm">
            <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" />
            <input id="razorpay_order_id" type="hidden" name="razorpay_order_id" />
            <input id="razorpay_signature" type="hidden" name="razorpay_signature" />
       </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="row" style="margin-top:8%;">
        <div class="col-4">
            <asp:TextBox ID="txamount" runat="server" placeholder="Amount"></asp:TextBox>
        </div>
         <div class="col-4">
            <asp:Button ID="btnpayaa" runat="server" Text="Pay Now" OnClick="btnpayaa_Click"/>
             <asp:Button ID="btnfinalsubmit" runat="server" Text="Ready to Pay" />
        </div>
    </div>
    
     <%-- Razor pay script start--%>
      <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
        <script>

            //$("#ContentPlaceHolder1_btnpayaa").click(function () {
            //    return true;
            //});
            $("#ContentPlaceHolder1_btnfinalsubmit").click(function (e) {
                e.preventDefault();
                var orderId = "<%=orderId%>"
                var name = "<%=CName%>"
                var varorderdesc = "<%=orderdesc%>"
            var vemail = "<%=Cemail%>"
                var vmob = "<%=CMob%>"

                var options = {
                    "name": name,
                    "description": varorderdesc,
                    "order_id": orderId,
                    "image": "http://customerportal.rohanbuilders.com/img/LogoBanner/rbdlogo.jpg",
                    "prefill": {
                        "name": name,
                        "email": vemail,
                        "contact": vmob,
                    },
                    "theme": {
                        "color": "#528FF0"
                    }
                }
                // Boolean whether to show image inside a white frame. (default: true)
                options.theme.image_padding = false;
                options.handler = function (response) {
                    document.getElementById('razorpay_payment_id').value = response.razorpay_payment_id;
                    document.getElementById('razorpay_order_id').value = orderId;
                    document.getElementById('razorpay_signature').value = response.razorpay_signature;
                    document.razorpayForm.submit();
                };
                options.modal = {
                    ondismiss: function () {
                        console.log("This code runs when the popup is closed");
                    },
                    // Boolean indicating whether pressing escape key 
                    // should close the checkout form. (default: true)
                    escape: true,
                    // Boolean indicating whether clicking translucent blank
                    // space outside checkout form should close the form. (default: false)
                    backdropclose: false
                };
                var rzp = new Razorpay(options);



                setTimeout(function () {
                    //$('#rzp-button1').click();
                    rzp.open();
                    e.preventDefault();
                }, 1000);


            });

        </script>


     <%-- Razor pay script End--%>
</asp:Content>
