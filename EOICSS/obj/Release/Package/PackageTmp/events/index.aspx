<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EOICSS.events.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Antara</title>
    <script src="https://www.google.com/recaptcha/api.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
<style>


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
  display:flex;
   flex-direction: column;
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
    <form id="form1" runat="server">
        <asp:Button ID="btnpaydata" runat="server" OnClick="btnpaydata_Click" Text="Pay Now"  style="display:none;"/>
    <asp:HiddenField ID="csshdnName" runat="server" Value="" />
    <asp:HiddenField ID="csshdnMob" runat="server" Value="" />
    <asp:HiddenField ID="csshdnEmailid" runat="server" Value="" />
    <asp:HiddenField ID="csshdnAmount" runat="server" Value="" />
    <asp:HiddenField ID="csshdnKYCTyps" runat="server" Value="" />
    <asp:HiddenField ID="csshdnGovtIdNo" runat="server" Value="" />
    <asp:HiddenField ID="csshdnPhasesTypes" runat="server" Value="" />
    <asp:HiddenField ID="csshdnBuildings" runat="server" Value="" />
    <asp:HiddenField ID="csshdnUnitNo" runat="server" Value="" />
    <asp:HiddenField ID="csshdnProjectName" runat="server" Value="Antara" />
    <asp:HiddenField ID="csshdnSources" runat="server" Value="EOIDirect-Form" />
    <asp:HiddenField ID="csshdnIpAddress" runat="server" Value="" />
    <asp:HiddenField ID="csshdnDevicess" runat="server" Value="" />

    </form>
         <div class="row g-2 bg-text"> 
        
        <div class="m-auto my-2" style=" text-align: center; width: 150px;">
            <img src="https://antara.rohanbuilders.com/assets/img/logo/Rohan-Antara-Logo-white.png" alt="" class="img-fluid">
        </div>
          <div class="row ">
           
          
            <div class="col-md-6 mb-2">
                <label for="name" class="col-12 col-form-label">Name :</label>
                <input type="text" class="form-control" id="name" />
              </div>
          <div class="col-md-6 mb-2">
            <label for="phone" class="col-12 col-form-label">EmailId :</label>
            <input type="email" class="form-control" id="emailcss" />
        </div>
        </div>
          <div class="row ">
            <div class="col-md-4 mb-2">
            <label for="phone" class="col-12 col-form-label">Phone No :</label>
            <input type="number" class="form-control" id="phone" />
        </div>
            <div class="col-md-4 mb-2">
                <label for="kyctype" class="col-12 col-form-label">KYC Type:</label>
                <select class="form-select" id="kyctyps">
                    <option selected disabled value="0">Choose...</option>
                    <option value="AdhaarCard">Adhaar Card</option>
                    <option value="PanCard">Pan Card</option>
                  </select>
            </div>
            <div class="col-md-4 mb-2">
                 <label for="govtid" class="clsgovtid col-12 col-form-label">Govt Id No:</label>
                 <input type="text" class="form-control" id="govtidsno" />
              </div>
          </div>
          <div class="row ">
            <div class="col-md-3 mb-2">
                <label for="phase" class="col-12 col-form-label">Phase Details :</label>
                <select class="form-select" id="phase">
                    <option selected disabled value="0">Choose...</option>
                    <option value="Phase1">Phase1</option>
                    <option value="Phase2">Phase2</option>
                  </select>
              </div>
           
            <div class="col-md-3 mb-2">
                <label for="building" class="col-12 col-form-label">Building :</label>
                <select class="form-select" id="building">
                    <option selected disabled value="Choose...">Choose...</option>
                  
                  </select>
            </div>
         
              <div class="col-md-3 mb-2">
                <label for="unit-no" class="col-12 col-form-label">Unit No:</label>
                 <input type="text" class="form-control" id="unitno" />
              </div>
               <div class="col-md-3 mb-2">
                <label for="amount" class="col-12 col-form-label">Amount</label>
                 <input type="number" class="form-control" id="amounts" />
              </div>
          </div>
          
          <div class="row mb-2">
            <div class="col-md-6 m-auto">
                 <div id="recaptcha" class="g-recaptcha my-2 " data-sitekey="6LevBLcUAAAAAGdtEQQy0OvyOKeGTppZxKyPYz6y"></div>
       </div>
    </div>
        <div class="col-4 mb-4 m-auto">
          <button class="clsbtsave btn btn-primary w-100" type="submit">Submit</button>
        </div>

            

    </div>
     <div class="row">
            <div class="col-md-12 mx-auto mt-3 mb-5 bg-black">
                    <p class=" col-form-label text-white" style="text-align:center;">
                         Phase 1 - PRM/KA/RERA/1251/446/PR/200423/005890
                   | 
                     Phase 2 - PRM/KA/RERA/1251/446/PR/200423/005887
                    </p>
       </div>
    </div>
     <input type="hidden" id="hdnipvalues" value="0" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

     <script type="text/javascript">
         $(window).on('load', function () {
             $('#loading').hide();
         })
         $(document).ready(function () {
             $("#hdnipvalues").val("0");



             var vrtet = "";
             var ua = navigator.userAgent;
             var checker = {
                 iphone: ua.match(/iPhone/),
                 blackberry: ua.match(/BlackBerry/),
                 android: ua.match(/Android/),
                 ipad: ua.match(/(iPod|iPad)/)
             };
             if (checker.android) {
                 vrtet = "android";
             }
             else if (checker.iphone) {
                 vrtet = "iphone";
             }
             else if (checker.blackberry) {
                 vrtet = "blackberry";
             }
             else if (checker.ipad) {
                 vrtet = "ipad";
             }
             else {
                 vrtet = "desktop";
             }

             $("#csshdnDevicess").val(vrtet);

             setTimeout(function () {
                 $.ajax({
                     type: "POST",
                     url: "https://msgapi.rohanbuilders.com/IPAddress.aspx/GetIPAddressDetected",
                     data: "{ strusername: '-'}",
                     processing: true,
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (r) {
                         var thisipreseult = r.d;
                         $("#hdnipvalues,#csshdnIpAddress").val(thisipreseult);
                     },
                     error: function (XMLHttpRequest, textStatus, errorThrown) {
                         alert(XMLHttpRequest.responseText);
                     }
                 });
             }, 1000);

             $("#kyctyps").change(function () {
                 var thisvalss = $(this).val();
                 $(".clsgovtid").text(thisvalss + " No:");
             });

             //phase  

             $("#phase").change(function () {
                 var thisoptionbind = '<option selected disabled value="0">Choose...</option>';
                 var thisvals = $(this).val();

                 if (thisvals == "Phase1") {
                     thisoptionbind = thisoptionbind + '<option value="A">A</option><option value="B">B</option><option value="C">C</option>';
                     //$(".clsrerano").html("Phase1: PRM/KA/RERA/1251/446/PR/200423/005890");
                 }
                 else {
                     thisoptionbind = thisoptionbind + '<option value="D">D</option><option value="E">E</option>';
                     //$(".clsrerano").html("Phase2: PRM/KA/RERA/1251/446/PR/200423/005887");
                 }

                 $("#building").html(thisoptionbind);
                 $(".clsrerano").css("font-size", "12px");

             });

             $(".clsbtsave").click(function (e) {
                 e.preventDefault();

                 let thitextbtn = $(this).text();

                 $("#name,#phone,#kyctyps,#govtidsno,#phase,#building,#unitno,#amounts,#emailcss").css("border", "");
                 if (thitextbtn == "Submit") {
                     let msgd = "Y";
                     let ltname = $("#name").val();
                     let ltmobno = $("#phone").val();
                     let ltkyctyps = $("#kyctyps").val();
                     let ltgovtidsno = $("#govtidsno").val();
                     let ltphases = $("#phase").val();
                     let ltbuilding = $("#building").val();
                     let ltunitno = $("#unitno").val();
                     let ltamounts = $("#amounts").val();
                     let ltEmailids = $("#emailcss").val();

                     $("#csshdnName").val(ltname);
                     $("#csshdnMob").val(ltmobno);
                     $("#csshdnEmailid").val(ltEmailids);
                     $("#csshdnAmount").val(ltamounts);
                     $("#csshdnKYCTyps").val(ltkyctyps);
                     $("#csshdnGovtIdNo").val(ltgovtidsno);
                     $("#csshdnPhasesTypes").val(ltphases);
                     $("#csshdnBuildings").val(ltbuilding);
                     $("#csshdnUnitNo").val(ltunitno);

                     if (ltname == "") {
                         msgd = "N";
                         $("#name").css("border", "2px solid red");
                     }
                     if (ltmobno == "") {
                         msgd = "N";
                         $("#phone").css("border", "2px solid red");
                     }
                     if (ltEmailids == "") {
                         msgd = "N";
                         $("#emailcss").css("border", "2px solid red");
                     }
                     else {
                         if (!validEmailDirect(ltEmailids)) {
                             msgd = "N";
                             $("#emailcss").css("border", "2px solid red");
                         }
                     }
                     if (ltkyctyps == "" || ltkyctyps == "0" || ltkyctyps == "null" || ltkyctyps == null) {
                         msgd = "N";
                         $("#kyctyps").css("border", "2px solid red");
                     }
                     if (ltgovtidsno == "") {
                         msgd = "N";
                         $("#govtidsno").css("border", "2px solid red");
                     }
                     if (ltphases == "" || ltphases == "0" || ltphases == "null" || ltphases == null) {
                         msgd = "N";
                         $("#phase").css("border", "2px solid red");
                     }
                     if (ltbuilding == "" || ltbuilding == "0" || ltbuilding == "null" || ltbuilding == null) {
                         msgd = "N";
                         $("#building").css("border", "2px solid red");
                     }
                     if (ltunitno == "") {
                         msgd = "N";
                         $("#unitno").css("border", "2px solid red");
                     }
                     if (ltamounts == "" || parseInt(ltamounts) == "0") {
                         msgd = "N";
                         $("#amounts").css("border", "2px solid red");
                     }

                     $('#recaptcha').css("border", "");
                     var $captcha = $('#recaptcha'),
                         response = 1;//grecaptcha.getResponse();

                     if (response.length === 0) {
                         $('#recaptcha').css("border", "2px solid red");
                         return true;
                     }
                     else {
                         if (msgd == "Y") {
                             $(this).text("Please wait...");
                             setTimeout(function () {
                                 $("#btnpaydata").click();
                             }, 1000);
                         }
                     }



                 }
                 else {
                     alert("Please wait...");
                 }



             })

         })
         function validEmailDirect($email) {
             var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
             return emailReg.test($email);
         }
     </script>
</body>
</html>