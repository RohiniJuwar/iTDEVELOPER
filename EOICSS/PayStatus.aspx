<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PayStatus.aspx.cs" Inherits="EOICSS.PayStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
     /*   #loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('img/loading.gif') 50% 50% no-repeat rgb(249,249,249);
        }  */


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
    background: url('img/loading.gif') 50% 50% no-repeat rgb(249,249,249);
}
    </style>
   <div id="loading">
</div>


    <div class="row" style="margin-top:20%;">
        <div class="col-12">
            <span id="spresult" runat="server">...</span>
        </div>
    </div>
      <script>
        $(window).on('load', function () {
            $('#loading').hide();
        }) 
      </script>
</asp:Content>
