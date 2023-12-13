<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thankyou.aspx.cs" Inherits="EOICSS.events.Thankyou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Antara | Thank you</title>
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
<style>
@import url('https://fonts.googleapis.com/css2?family=Satisfy&display=swap');

    body, html {
  height: 100%;
  margin: 0;
  font-family: 'Montserrat', sans-serif;
}

* {
  box-sizing: border-box;
}

body {
  /* The image used */
  background-image:linear-gradient(rgba(255, 255, 255, 0.2),  rgb(255, 255, 255,0.2)), url("https://antara.rohanbuilders.com/assets/img/slider/Rohan-Antara-Facade-Image-D8.webp");
  background-attachment: fixed;
  /* Add the blur effect */
  /* Full height */
  height: 100vh; 
  display: flex;
  /* Center and scale the image nicely */
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}
::-webkit-scrollbar {
    display: none;
}
/* Position text in the middle of the page/image */
.bg-text {
  background-color: rgb(0,0,0); /* Fallback color */
  background-color: rgba(0,0,0, 0.7); /* Black w/opacity/see-through */
  color: white;
  font-weight: bold;
  border: 3px solid #f1f1f1;
 margin:auto ;
  z-index: 2;
  width: 50%;
  border-radius: 10px;
  padding:5px 20px;
  text-align: left;
  height: 520px;
  overflow-y: scroll;
}
.thank{
  font-family: 'Satisfy', cursive;
  text-align: center;
}
.thank img{
width: 100px;
background-color: #000;
border-radius: 50%;
}
.bg-text img{  text-align: center;}

    @media all and (max-width: 768px) {
        .bg-text {
            width: 95%;
        }
    }
       #loading {
  position: fixed;
  display: block;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  text-align: center;
  opacity: 0.7;
  background-color: #fff;
  z-index: 999999999;
    background: url('../img/loading.gif') 50% 50% no-repeat rgb(249,249,249);
}
</style>
</head>
<body>
     <div id="loading"></div>
    <div class="row g-2 bg-text"> 
        <div class="m-auto my-2" style=" text-align: center; width: 150px;">
            <img src="https://antara.rohanbuilders.com/assets/img/logo/Rohan-Antara-Logo-white.png" alt="" class="img-fluid" />
        </div>
        <div class="thank">
           <img id="imgyes" runat="server" src="https://antara.rohanbuilders.com/assets/img/logo/yes.png" alt="" class="img-fluid" style="display:none;" />
          <img id="imgno" runat="server" src="https://antara.rohanbuilders.com/assets/img/logo/no.png" alt="" class="img-fluid" style="display:none;" />
        </div>
        <div class="row mb-2"> 
          <label for="status" class="col-sm-3 col-form-label">Status :</label>
          <div class="col-sm-9">
            <span id="spstatus" class="form-control" runat="server">Status</span>
          </div>
        </div>
        <div class="row mb-2"> 
          <label for="payment-id" class="col-sm-3 col-form-label">Payment Id :</label>
          <div class="col-sm-9">
            <span id="sppaymentid" class="form-control" runat="server">Payment Id</span>
          </div>
        </div>
        <div class="row mb-2"> 
          <label for="transaction-id" class="col-sm-3 col-form-label">Ref Id :</label>
          <div class="col-sm-9">
            <span id="sptransactionid" class="form-control" runat="server">transaction id</span>
          </div>
        </div>
        <div class="row mb-3"> 
          <label for="tokan-no" class="col-sm-3 col-form-label">Amount :</label>
          <div class="col-sm-9">
            <span id="spamount" class="form-control" runat="server">Amount</span>
          </div>
        </div>
       
    </div>
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
     <script>
        $(window).on('load', function () {
            $('#loading').hide();
        }) 
     </script>
    </body>
</html>
