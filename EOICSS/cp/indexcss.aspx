<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="indexcss.aspx.cs" Inherits="EOICSS.cp.indexcss" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          
<!--OWL CSS-->

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.theme.default.min.css">

    <style>
        *{
            color:#000;
        }
        .owl-carousel .item {
            height: auto;
        }
        .owl-stage{
            margin:auto !important;
        }
        .ms-options ul{
            list-style:none !important;
        }
        .ms-search{
            display:none;
        }
        .ms-options-wrap > .ms-options > ul input[type="checkbox"] {
              top:11px;
        }
        .ms-options-wrap > button:focus, .ms-options-wrap > button{
            
  /* SVG background image */
  background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 16 16'%3e%3cpath fill='none' stroke='%23343a40' stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='M2 5l6 6 6-6'/%3e%3c/svg%3e");
 background-position: right 0.75rem center;
    background-size: 16px 12px;
    background-repeat: no-repeat;
          border: 0;
    border-bottom: 1px solid black;
  font-weight:normal;
    border-radius: 0;
    padding: 5px 2px;
    color: black;
    color: rgb(56, 56, 56);
    font-size: 15px;
        font-weight: 500;
    

        }
             .ms-options-wrap > button:after{
  border-top-color:transparent;
        }
       ::placeholder{
            color:#000;
             opacity: 1;
        }
       .txt-select{
           padding:5px 2px;
       }
.item{
    text-align: center;
    margin-top: 2rem;
    padding: 0 1rem;
}
.item .projectName{
    font-weight: 600;
}
.item.projectAddress {
    font-size: 14px;
    padding-bottom: 10px;
    font-weight: 600;
}
.item .projectDesc {
    font-size: 14px;
    padding-bottom: 10px;
}
.fa {
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
}
.tooltip2 {
    /* border-bottom: 1px dotted #000000; */
    color: #000000;
    outline: none;
    cursor: help;
    text-decoration: none;
    position: relative;
}

.tooltip2 span {
    margin-left: -999em;
    position: absolute;
    z-index: 9999;
}
.info {
    background: #fff;
    border: 1px solid #2BB0D7;
}
.custom {
    padding: 5px;
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
  background: url('/img/loading.gif') 50% 50% no-repeat rgb(249,249,249);
}
        
.file-input__input {
  width: 0.1px;
  height: 0.1px;
  opacity: 0;
  overflow: hidden;
  position: absolute;
  z-index: -1;
}

.file-input__label {
  cursor: pointer;
  display: inline-flex;
  align-items: center;
  border-radius: 4px;
  font-size: 14px;
  font-weight: 600;
  color: #fff;
  font-size: 14px;
 padding: 5px 5px;
  background-color: #fff;
  border:1px solid #000;
  box-shadow: 0px 0px 2px rgba(0, 0, 0, 0.25);
}

.file-input__label svg {
  height: 16px;
  color:#fff;
  margin-right: 4px;
}

.file-upload-wrapper {
  position: relative;
  width: 100%;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  border:1px solid #000;
  height: 32px;
  margin-left:5px;
}
.file-upload-wrapper:after {
  content: attr(data-text);
  font-size: 14px;
  position: absolute;
  top: 0;
  left: 0;
  background: #fff;
      padding: 0px 15px;
  display: block;
  width: calc(100% - 30px);
  pointer-events: none;
  z-index: 20;
  height: 30px;
  line-height: 30px;
  color: #999;
  border-radius: 5px 10px 10px 5px;
  font-weight: 300;
}
.file-upload-wrapper:before {
     font-family: FontAwesome;
  content: "\f093";
  position: absolute;
  top: 0;
  right: 0;
  display: inline-block;
  height: 30px;
  background: #999;
  color: #fff;
  font-weight: 700;
  z-index: 25;
  font-size: 14px;
  line-height: 30px;
  padding: 0 10px;
  pointer-events: none;

  border-radius: 0 0px 0px 0;
}
.file-upload-wrapper:hover:before {
   background: #999;
}
.file-upload-wrapper input {
  opacity: 0;
  position: absolute;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  z-index: 99;
  height: 30px;
    margin: 0;
  padding: 0;
  display: block;
  cursor: pointer;
  width: 100%;
}
.bootstrap-select .dropdown-toggle:focus, .bootstrap-select>select.mobile-device:focus+.dropdown-toggle{
    outline:none !important;
    border-bottom: 1px solid black;border-radius:0;
}
.bootstrap-select .form-select{
background-color:none !important;
}
.bootstrap-select .form-select .btn{
    background-color:none !important;
    border-bottom: 1px solid black;border-radius:0;
}
.bootstrap-select>.dropdown-toggle{
      background-color:none !important;
    border-bottom: 1px solid black;border-radius:0;
       padding: 5px 2px !important;
}
.bootstrap-select> .btn-light{
    background-color:#fff !important;
}
.bootstrap-select>.dropdown-toggle.bs-placeholder, .bootstrap-select>.dropdown-toggle.bs-placeholder:active, .bootstrap-select>.dropdown-toggle.bs-placeholder:focus, .bootstrap-select>.dropdown-toggle.bs-placeholder:hover{
    background-color:transparent !important;
     outline:none !important;
     border:none;
   
     border-bottom: 1px solid black;border-radius:0;
     width:100% !important;
         padding: 5px 2px !important;
         box-shadow:none !important;
}
.bs-searchbox{
    display:none;
}
    </style>


   <div id="loading">
</div>
    <form id="form52" runat="server">
           <asp:Button ID="btnpaydata" runat="server" OnClick="btnpaydata_Click" Text="Pay Now"  style="display:none;"/>
    <asp:HiddenField ID="cssCPPanNo" runat="server" Value="" />
    <asp:HiddenField ID="csshdnName" runat="server" Value="" />
    <asp:HiddenField ID="csshdnMob" runat="server" Value="" />
    <asp:HiddenField ID="csshdnEmailid" runat="server" Value="" />
    <asp:HiddenField ID="csshdnAmount" runat="server" Value="" />
    <asp:HiddenField ID="csshdntransactionId" runat="server" Value="0" />
    <asp:HiddenField ID="csshdnSessionids" runat="server" Value="0" />
    <asp:HiddenField ID="csshdnTokenaccs" runat="server" Value="" />
    <asp:HiddenField ID="csshdnProjecids" runat="server" Value="9811880d-6c81-48e7-92a8-b74035774de5" />
    <asp:HiddenField ID="csshdncpSourcIds" runat="server" Value="" />
    <asp:HiddenField ID="csshdncpSourdetailds" runat="server" Value="" />
    <asp:HiddenField ID="csshdncptokenTypds" runat="server" Value="" />
    <asp:HiddenField ID="csshdncpPrefernces" runat="server" Value="" />
     <asp:HiddenField ID="csshdncpMobNo" runat="server" Value="" />

    <asp:HiddenField ID="csshdncpWing" runat="server" Value="" />
    <asp:HiddenField ID="csshdncpUnittype" runat="server" Value="" />
    <asp:HiddenField ID="csshdncpUnitNumber" runat="server" Value="" />
        <asp:HiddenField ID="csshdncpProjectListValues" runat="server" Value='[{"Texts":"Rohan Harita","Values":"9811880d-6c81-48e7-92a8-b74035774de5"}]'/>
        <%--<asp:HiddenField ID="csshdncpProjectListValues" runat="server" Value=''/>--%>
        <asp:HiddenField ID="csshdncpProjectName" runat="server" Value="" />
    </form>

    <input type="hidden" id="cshdnsources" value="Channel Patner" />
<!---header-->
<header class="container-fixed mt-md-5 mt-4">
    <%--<img src="/img/Rohan-Viti-Creative-Banner-New.webp" alt="" class="img-fluid">--%>
</header>
     
    <section id="ongoing">
    <div class="container">
       <%-- <div class="row">
    
            <div class="headtext text-center">
    
                <h1 class="fw-bold pb-3 " style="border-bottom: 2px solid #ccc;"> EOI Offer</h1>
    
            </div>
    </div>--%>
    <div class="owl-carousel owl-theme">
       <%-- <div class="item">
            <a class="projectTitle" href="#">

                <h2 class="projectName">Rohan Nidita</h2>

            </a>
            <div class="projectAddress">

              <h5> Rohan Nidit, Next To Rohan Tarang, Wakad<br/>Pune – 411057					
              </h5> 
            </div>

            <div class="projectDesc" >

                    <h6>2 & 3 BHK Homes	</h6>   
        </div>
        <a class="tooltip2  mb-2" href="#">
            <i class="fa fa-info-circle" aria-hidden="true"></i>

            <span class="custom info">

                MAHA RERA Regn. No.:<br/>

                 P52100046719

                </span>

            https://maharera.mahaonline.gov.in
        </a>

        <img src="https://rohanbuilders.com/assets/upload/main-projects/residential/Rohan-Viti/South-West-Side-View-of-the-Facade.webp" alt="Rohan Viti 3 BHK Floor Plan" class="img-fluid mt-2">
       <a href="#" class="clsreq-nidita btn btn-primary w-100 mt-3 ">EOI</a> 
      
    </div>

        <div class="item">
          
            
            <a class="projectTitle" href="#">

                <h2 class="projectName">Rohan Abhilasha 3</h2>

            </a>
            <div class="projectAddress">

              <h5>  GAT No. 110 Part and 112 Part at Somatane,
                Mawal,<br/>Pune, 410506				
              </h5> 
            </div>

            <div class="projectDesc" >

                    <h6> 1.5, 2 & 3 BHK Homes	</h6>   
        </div>
        <a class="tooltip2  mb-2" href="#">
            <i class="fa fa-info-circle" aria-hidden="true"></i>

            <span class="custom info">

            MAHA RERA Regn. No.:<br/>

            </span>

           https://maharera.mahaonline.gov.in
        </a>

        <img src="https://rohanbuilders.com/assets/upload/main-projects/residential/Rohan-Viti/South-West-Side-View-of-the-Facade.webp" alt="Rohan Viti 3 BHK Floor Plan" class="img-fluid mt-2">
        <a href="#" class="clsreq-abhilasha3 btn btn-primary w-100 mt-3 ">EOI</a>     
    </div>    
--%>

        <div class="item">
          
            <div style="text-align:-webkit-center;">
                <img class="img-fluid" src="/img/Antara-Logo.png" style="width:50%;"/>
            </div>
            <a class="projectTitle" href="#">

               <%-- <h2>Rohan Antara</h2> --%>
               <%-- <h2 class="projectName">Rohan Antara</h2>--%>
                 <%-- <h4 class="fw-bolder fs-4 py-3">
                       <img class="img-fluid" src="/img/Antara-Logo.png" />
                  </h4>--%>
            </a>
            <div class="projectAddress">

            <%--  <h5>EOI Creative</h5> --%>
            </div>

          <%--  <div class="projectDesc" >

                    <h6> 1.5, 2 & 3 BHK Homes	</h6>   
        </div>--%>
        <%--<a class="tooltip2  mb-2" href="#">
            <i class="fa fa-info-circle" aria-hidden="true"></i>

            <span class="custom info">

            MAHA RERA Regn. No.:<br/>

            </span>

           https://maharera.mahaonline.gov.in
        </a>--%>
        <img src="../img/min/Rohan_Antara_EOI.png" alt="Rohan Antara EOI" class="img-fluid mt-2">
        <a href="#" id="divclickc" class="clsreq-Harita btn btn-primary w-100 mt-3 ">Reserve Your Token</a>     
    </div>


    </div>
 </div>

</section>

<div id=myModalcss class="modal fade" role=dialog>
    <div class="modal-dialog modal-dialog-centered">
        <div class=modal-content>
            <div class="text-center" style="text-align:center;color:black;font-weight:bold;height: 58px;padding-top: 3%;">
                <h4 class="my-3">Would you like to speak now?</h4>
            </div>
            <div class="text-center mb-3">
                <a class="btn btn-default" href="tel:02066669905" style="background-color: cornflowerblue;">
                    <span style="color:white;">Yes</span>
                </a>
                <button type=button class="btn btn-default" data-bs-dismiss=modal style="color:black;">No</button>
            </div>
        </div>
    </div>
</div>


<%--<div class="clsreq-2BHK button btn-primary rounded-start" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
    <div class="icon btn-primary">
        <i class="fa-solid fa-phone"></i>
    </div>
    <span>Request a call back</span>
</div>--%>


<div class="modal model1  fade" id="staticBackdrop2" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
      <div class="modal-content">
    <div class="container">
        <div class="row justify-content-md-center">
            <div class="col-md-12 text-center">
              <div class="row">
                <div class="col-sm-12  bgWhite">
                  <div class="title">
                    OTP has been sent on your mobile number.
                  </div>
                  
                  <div class="mt-5 form2">
                    <input class="otp" type="text" oninput='digitValidate(this)' onkeyup='tabChange(1)' maxlength=1 >
                    <input class="otp" type="text" oninput='digitValidate(this)' onkeyup='tabChange(2)' maxlength=1 >
                    <input class="otp" type="text" oninput='digitValidate(this)' onkeyup='tabChange(3)' maxlength=1 >
                    <input class="otp" type="text" oninput='digitValidate(this)'onkeyup='tabChange(4)' maxlength=1 >
                  </div>
                    <label style="margin-top:10px;" class="clslableotp"></label>
                  <hr class="mt-4">
                  <button class='btn btn-primary btn-block mt-4 mb-4 customBtn'>Verify</button>
                    <a href="#" class="clsaResend">Resend OTP</a>
                </div>
              </div>
            </div>
        </div>
      </div>
    </div>
  </div>
</div>



    <div class="modal model1  fade" id="staticAlert" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
      <div class="modal-content">
    <div class="container">
        <div class="row justify-content-md-center">
            <div class="col-md-12 text-center">
              <div class="row">
                <div class="col-sm-12  bgWhite">
                  <div class="title" style="margin-top:0;">
                    Alert
                      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" style="float: right;font-size: 10px;margin-top: 11px;"></button>
                  </div>
                  <hr class="mt-4">
                 <h4 class="clsheaderalert"></h4>
                </div>
              </div>
            </div>
        </div>
      </div>
    </div>
  </div>
</div>



    <!-- Button trigger modal -->
    <!-- Button trigger modal -->
    <!-- Modal -->
    <div class="modal model1 fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
          <div class="modal-content">
              <div class="modal-header w-100 px-5">
                  <h4 class="fw-bolder fs-4 py-3" id="staticBackdropLabel" >
                       <img class="img-fluid" src="/img/Antara-Logo.png" style="width:50%;" />
                  </h4>
                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div id="divmobn" class="modal-body pt-0">
                  <div class="register p-3">
                        <div class="row">
                              <div class="col-md-6">

                                      <div class=" border-bottom-1">
                              <input class="form-control txt" name=popup-phone onkeypress="return isNumberKey(event)" id=popup-phone_mob maxlength="10" pattern="[0-9]*" inputmode=numeric autocomplete=off data-validation=length data-validation-length=10-11 required placeholder="Mobile No." />
                                           <small class="text-secondary"><i class="fa-brands text-secondary fa-whatsapp"></i> Whatsapp No Preferred</small>
                          </div>
                              
                              </div>

                             
                          </div>
                           <br />
                          <div class=form-group>
                              <button type=button id=btn_get_otp_new  class="btn btn-primary btn-lg btn-block">Get OTP</button>
                          </div>
                          <div class=form-group>
                              <p style="font-size:9px;margin-bottom: 0px;line-height: 12px" class="my-2">*Your details are safe with us. We'd make no excuse to share them with anyone.</p>
                          </div>
                 </div>
              </div>



              <div id="divshowform" class="modal-body pt-0" style="display:none;">
                  <div class="register1 p-3 " style="display:none;">
                      <h5 class=" pt-2 fw-bold mb-2 ">Channel partner</h5>
                      <div class="row ">
                          <div class="col-md-6">
                              <div class=" border-bottom-1">
                                  <label class="fw-bold">Name</label>
                                  <label class="clscsscpName label ">...</label>
                              </div>
                          </div>
                          <div class="col-md-6">
                              <div class=" border-bottom-1">
                                  <label class="fw-bold">Phone Number</label>
                                  <label class="clscsscpMob label">...</label>
                              </div>

                          </div>

                      </div>
                      <div class="pt-3"><a href="/" class="know  d-none">Know More...</a></div>


                  </div>

                  <div class="register p-3" style="display:block;">
                      <div  id=frm_popup>
                        <div class="row">
                              <div class="col-md-6">

                                      <div class=" border-bottom-1">
                              <input class="form-control txt" name=popup-phone onkeypress="return isNumberKey(event)" id=popup-phone maxlength="10" pattern="[0-9]*" inputmode=numeric autocomplete=off data-validation=length data-validation-length=10-11 required placeholder="Mob No." />
                          </div>
                              
                              </div>

                             
                          </div>
                           <div class="row">
                               <div class="col-md-3">
                                  <div class=border-bottom-1>
                                      <select class="form-select  txt-select txt " id=cmb_Salutation_popup name=cmb_Salutation_popup  required>
                                          <option value="..">Salutation</option>

                                      </select>
                                  </div>
                              </div>
                              <div class="col-md-4">
                                  <div class=" border-bottom-1">
                                      <input class="form-control txt-select txt" name=popup-First-name id=popup-First-name data-validation=length data-validation-length=3-20   data-validation-regexp="[A-Za-z]" required placeholder=" First Name *">
                                  </div>
                              </div>
                                  <div class="col-md-5">
                                  <div class=" border-bottom-1">
                                      <input class="form-control txt-select txt" name=popup-Middle-name id=popup-Middle-name data-validation=length data-validation-length=3-20  data-validation-regexp="[A-Za-z]" required placeholder=" Middle Name">
                                  </div>
                              </div>
                                  
                            </div>

                         
                               <div class="row ">
                              <div class="col-md-6">
                                  <div class=" border-bottom-1">
                                      <input class="form-control txt" name=popup-Last-name id=popup-Last-name data-validation=length data-validation-length=3-20  data-validation-regexp="[A-Za-z]" required placeholder="Last Name">
                                  </div>
                              </div> 
                                     <div class="col-md-6">
                                  <div class=" border-bottom-1">
                                      <input class="form-control txt" name=popup-email id=popup-email data-validation=email  required placeholder="Your e-mail">
                                  </div>
                              </div>
                          </div>
                             <div class="row">
                                  
                            
                             <div class="col-md-6">
                                  <div class=border-bottom-1>
                                      <select class="form-select  txt-select" id=cmb_Preferences_popup name=cmb_Preferences_popup required>
                                          <option value="..">Preference</option>
                                      </select>
                                  </div>
                              </div>
                             
                                        
 
                                  <div class="col-md-6">
                                      <select class="selectpicker w-100 bg-transparent" id=cmb_Preferences_popup_2 name=cmb_Preferences_popup_2  multiple aria-label="Default select example" data-live-search="true" data-none-selected-text="Secondary Preference">
                                    <option value="1.5 BHK">1.5 BHK</option><option value="2 BHK (L)">2 BHK (L)</option><option value="2 BHK (S)">2 BHK (S)</option><option value="3 BHK 2T">3 BHK 2T</option><option value="3 BHK 3T (L)">3 BHK 3T (L)</option><option value="3 BHK 3T (S)">3 BHK 3T (S)</option>

                                      </select>
                                     
                                    
                              </div>
                                  
                          </div>
                          <div class="row">
                              <div class="col-md-6">
                                  <div class=border-bottom-1>
                                      <select class="form-select  txt-select " id=cmb_Token_Type_popup name=cmb_Token_Type_popup required>
                                          <option value="..">Token Type</option>
                                      </select>
                                  </div>
                              </div>
                                <div class="col-md-6">
                                  <div class=" border-bottom-1">
                                     <%-- <input class="form-control txt" name=popup-Token-Amount onkeypress="return isNumberKey(event)" id=popup-Token-Amount maxlength=10 pattern="[0-9]*" inputmode=numeric autocomplete=off data-validation=length data-validation-length=10-11  required placeholder="Token Amount" />--%>
                                       <select class="form-select  txt-select " id=cmb_Token_Amount_popup name=cmb_Token_Amount_popup required>
                                          <option value="0">Token Amount</option>
                                      </select>


                                  </div>
                              </div>
                              
                          </div>
                          <div class="row">
                              <div class="col-md-6">
                                      <label class="mt-3 fw-bold ">
                                  Payment Details:
                              </label>
                              </div>
                           
                          </div>
                          <div class="row   ">
                             
                               <div class="col-md-6">
                                  <div class=" border-bottom-1">
                                 <%--     <input class="form-control txt-select" s name=popup-Cheque onkeypress="return isNumberKey(event)" id=popup-Cheque maxlength=10 pattern="[0-9]*" inputmode=numeric autocomplete=off data-validation=length data-validation-length=10-11  required placeholder="Cheque/TRN No." />--%>

                                          <input class="form-control txt" name=popup-Cheque id=popup-Cheque data-validation=length data-validation-length=3-20  data-validation-regexp="[A-Za-z]" required placeholder=" Cheque No.">

                                  </div>
                              </div>
                              <div class="col-md-6">
                                  <div class=" border-bottom-1">
                                      <input class="form-control txt" name=popup-Bank-name id=popup-Bank-name data-validation=length data-validation-length=3-20  data-validation-regexp="[A-Za-z]" required placeholder=" Bank Name">
                                  </div>
                              </div>
                          </div>

                         <div class="row">
                                <div class="col-md-6">
                                  <div class=" border-bottom-1">
                                      <input class="form-control txt" name=popup-Bank-Branch-Address id=popup-Bank-Branch-Address data-validation=length data-validation-length=3-20  data-validation-regexp="[A-Za-z]" required placeholder=" Bank-Branch/Address">
                                  </div>
                              </div>
                        <%--     <div class="col-md-6">
                                  <div class=" border-bottom-1">
                                      <span>Upload Cheque</span><br />
                                      <input type="file" id="fu_cheque" name="fu_cheque" accept="image/png, image/jpeg" />
                                     
                                  </div>
                              </div>--%>
                                      <div class="col-md-6">
                                  <div class=" border-bottom-1 d-flex justify-content-around align-items-center py-2">
                                      
                                          <div class="file-upload-wrapper" data-text="Upload Cheque Photo">
      <input type="file" id="fu_cheque" name="fu_cheque" class="file-upload-field" value=""accept="image/png, image/jpeg" />

    </div>
                                    
                                  
                                  </div>
                              </div>

                              <span style="font-size:10px;">Note: *Tokens will be valid submit to deposition of cheques at Rohan Antara sales office.</span>
                          </div>

                          <div class="row" id="divwing" style="display:none;">
                                <div class="col-md-3">
                                  <div class=" border-bottom-1">
                                       <select class="form-select  txt-select " id=cmb_Wing_popup name=cmb_Wing_popup required>
                                          <option value="0">Wing</option>
                                      </select>


                                  </div>
                              </div>
                               <div class="col-md-3">
                                  <div class=" border-bottom-1">
                                       <select class="form-select  txt-select " id=cmb_Unit_Type_popup name=cmb_Unit_Type_popup required>
                                          <option value="0">Unit Type</option>
                                      </select>


                                  </div>
                              </div>
                               <div class="col-md-3">
                                  <div class=" border-bottom-1">
                                       <select class="form-select  txt-select " id=cmb_Unit_Number_popup name=cmb_Unit_Number_popup required>
                                          <option value="0">Unit Number</option>
                                      </select>


                                  </div>
                              </div>

                               <div class="col-md-3">
                              <div class=" border-bottom-1">
                                      <input class="form-control txt-select" name=totalusablesqft id="totalusablesqft"  placeholder="Total Usable SqFt" disabled>
                                  </div>
</div>

                          </div>


                        <div class="row" style="display:none;">
                              <div class="col-md-12">
                                       <div class=" border-bottom-1">
                                  <textarea class="form-control txt"  data-validation=length data-validation-length=3-20  data-validation-regexp="[A-Za-z]" required placeholder="Comments" id="txtcomments" rows="2"></textarea> 
                              </div>
                         </div>
                        </div>

                          <div id="recaptcha" class="g-recaptcha my-2" data-sitekey="6LevBLcUAAAAAGdtEQQy0OvyOKeGTppZxKyPYz6y"></div>
                          <div class="form-group ">
                              <div class="form-check">
                                  <input class="form-check-input" type="checkbox" id="gridCheck">
                                  <label class="form-check-label" for="gridCheck">
                                      I agree to terms & conditions
                                  </label>
                              </div>
                          </div>
                          <div class=form-group>
                              <button type=button id=btn_get_otp_finalsubmit  class="btn btn-primary btn-lg btn-block">Submit</button>
                              <img src="/img/loading.gif" class=imgloading style="display:none;" />
                          </div>
                          <div class=form-group>
                              <p style="font-size:9px;margin-bottom: 0px;line-height: 12px" class="my-2">*Your details are safe with us. We'd make no excuse to share them with anyone.</p>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>
  </div>


    <div class="modal model1  fade" id="myModalPayment" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
      <div class="modal-content">
    <div class="container">
        <div class="row justify-content-md-center">
            <div class="col-md-12 text-center">
              <div class="row">
                <div class="col-sm-12  bgWhite">
                  <div class="title">
                    Alert
                  </div>
                     <img src="/img/alert.png" style="width: 30px; text-align: left; float: left;margin-right: -29px; " />
                  <h6 style="margin-top:9px;">You will be redirected to Payment Gateway please do not press 'Back' button</h6> 
                  <hr class="mt-4"> 
                  <button class='btn btn-primary btn-block mt-4 mb-4 CandPay'>Pay</button>
                </div>
              </div>
            </div>
        </div>
      </div>
    </div>
  </div>
</div>

    <input type="hidden" id="csshdnOTPId" name="csshdnOTPId" value="0" />
    <%--<input type="hidden" id="csstransactionId" name="csstransactionId" value="0" />--%>
    <script src="../Commoncss/commonjs.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".CandPay").click(function (e) {
                $(this).text("Please wait...");
                setTimeout(function () {
                    $("#ContentPlaceHolder1_btnpaydata").click();
                }, 500);
                //$("#ContentPlaceHolder1_csshdntransactionId").val("0");
                e.preventDefault();
            });
            //setTimeout(function () {
            //    $("#divclickc").click();



            //    //var thisfrom = "Antara_Phase_2";
            //    //thisfrom = thisfrom == "abhilasha3" ? "Abhilasha 3" : thisfrom;
            //    //if (thisfrom.indexOf('_') > -1) {
            //    //    thisfrom = thisfrom.replace(/_/g, " ");
            //    //}
            //    //thisfrom = "Rohan " + thisfrom;
            //    //$("#ContentPlaceHolder1_csshdncpProjectName").val(thisfrom);
            //    //var jsondataproject = $("#ContentPlaceHolder1_csshdncpProjectListValues").val();
            //    //var jddd = "";
            //    //if (jsondataproject == "") {

            //    //}
            //    //else {
            //    //    jddd = $.parseJSON(jsondataproject);
            //    //}

            //    //var isexists = "N";
            //    //$.each(jddd, function (i, item) {
            //    //    //alert(jddd[i].Texts.toLowerCase() + " -- " + jddd[i].Values);
            //    //    if (jddd[i].Texts.toLowerCase() == thisfrom.toLowerCase()) {
            //    //        $("#staticBackdrop").modal("show");
            //    //        $(".clsheadertitle").html(thisfrom.toUpperCase());
            //    //        isexists = "Y";
            //    //        $("#ContentPlaceHolder1_csshdnProjecids").val(jddd[i].Values);
            //    //        fngetchannelpartne("", "PL", jddd[i].Values);
            //    //        setTimeout(function () {
            //    //            fngetchannelpartne("", "TTL", jddd[i].Values);
            //    //            var thiopt = "<option value='0'>Token Amount</option>";
            //    //            $("#cmb_Token_Amount_popup").html(thiopt);
            //    //        }, 500);
            //    //        return;
            //    //    }

            //    //});

            //    //if (isexists == "N") {
            //    //    $(".clsheaderalert").text("Please add this project data in MDOC First");
            //    //    $('#staticAlert').modal("show");
            //    //    $('#staticAlert').css({ "z-index": "999999999999" });
            //    //    return false;
            //    //}


            //}, 1000);
        })
    </script>
    <script>
        $(window).on('load', function () {
            $('#loading').hide();
        })
    </script>
    


     
<script>
    // ANSWER TO QUESTION https://stackoverflow.com/questions/51751978/html5-canvas-circle-lag-on-display
    // ANSWER TO ISSUE https://github.com/OwlCarousel2/OwlCarousel2/issues/2413 

    $(document).ready(function () {
        $('.owl-carousel').owlCarousel({
            loop: true,
            margin: 10,
            responsiveClass: true,
            responsive: {
                0: {
                    items: 1,
                    nav: true
                },
                600: {
                    items: 2,
                    nav: false
                },
                1000: {
                    items: 3,
                    nav: true,
                    loop: false
                }
            }
        })
    });

    /* CANVAS JS */
    function progressSim(selector) {
        $(selector).each(function () {
            const $item = $(this);

            // prevent double initializetion of canvas
            if ($item.data('initilized') === true) {
                return;
            }

            const percent = $item.data('percent');

            let ctx = $item.get(0).getContext('2d'),
                cw = ctx.canvas.width,
                ch = ctx.canvas.height,
                al = 0,
                sim = setInterval(progress, 25);

            // mark already initialized canvases to prevent double init
            $item.data('initilized', true);

            function progress() {
                let start = 4.72,
                    diff = ((al / 100) * Math.PI * 2 * 10).toFixed(2);

                ctx.clearRect(0, 0, cw, ch);
                ctx.lineWidth = 7;
                ctx.fillStyle = '#000';
                ctx.strokeStyle = "#000";
                ctx.textAlign = 'center';
                ctx.font = "30px Arial";
                ctx.fillText(al + '%', cw * .5, ch * .5 + 2, cw);
                ctx.beginPath();
                ctx.arc(80, 80, 70, start, diff / 10 + start, false);
                ctx.stroke();
                if (al >= percent) {
                    clearTimeout(sim);
                    // Add scripting here that will run when progress completes
                }
                al++;
            };
        })
    }


    $("#staticBackdrop").on("change", ".file-upload-field", function () {
        $(this).parent(".file-upload-wrapper").attr("data-text", $(this).val().replace(/.*(\/|\\)/, ''));
    });



</script>


    

<!--OWL JS-->
<script src="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/lightgallery/2.5.0/lightgallery.min.js"></script>



</asp:Content>

