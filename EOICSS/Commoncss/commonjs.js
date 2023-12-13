
var urlParamscss = new URLSearchParams(location.search);
//var CPpanno= urlParamscss.get('id');
var urlcsss = window.location.href;

$("#btn_get_otp_new").click(function () {
    var Mob = $("#popup-phone_mob").val();
    var EmailId = $("#popup-email").val();
    if (Mob == "") {

    }
    else {
        fnCommonOTP(Mob, EmailId, 'EOI OTP', 'New', '0', '');
    }
    return false;

});

$(".clsaResend").click(function () {
    var vrotpids = $("#csshdnOTPId").val();
    $(".clsaResend").text("Please wait....");
    $(".clsaResend").css({ "color": "red" });
    //fnVerifiedandpushData(vrotpids, otpenter);
    fnCommonOTP('', '', 'EOI OTP', 'Resend', vrotpids, '');
    return false;
});

$("#btn_get_otp").click(function () {
    var Mob = $("#popup-phone").val();
    var EmailId = $("#popup-email").val();
    var strss = fnInsertData("getotp");
    if (strss == "Y") {
        fnCommonOTP(Mob, EmailId, 'EOI OTP', 'New', '0', '');
    } else {
        alert(strss);
    }
    //$('#recaptcha').css("border", "");
    //var $captcha = $('#recaptcha'),
    //    response = grecaptcha.getResponse();

    //if (response.length === 0) {
    //    $('#recaptcha').css("border", "1px solid red");
    //    return true;
    //}
    //else {
    //    var Mob = $("#popup-phone").val();
    //    var EmailId = $("#popup-email").val();
    //    var strss = fnInsertData("getotp");
    //    if (strss == "Y") {
    //        fnCommonOTP(Mob, EmailId, 'EOI OTP', 'New', '0', '');
    //    } else {
    //        alert(strss);
    //    }
    //}
    return false;

});

$(".customBtn").click(function (e) {
    e.preventDefault();
    $(".clslableotp").text("");
    var vrotpids = $("#csshdnOTPId").val();
    var otpenter = "";
    $(".otp").each(function () {
        var thisvalues = $(this).val();
        otpenter = otpenter + thisvalues;
    });
    $(".clslableotp").text("Please wait....");
    $(".clslableotp").css({ "color": "red" });
    //fnVerifiedandpushData(vrotpids, otpenter);
    fnCommonOTP('', '', 'EOI OTP', 'CheckOTP', vrotpids, otpenter);
});

$("[class^=clsreq]").click(function (e) {
    e.preventDefault();


    //$("#divshowform").show();
    //$('#staticBackdrop').modal("show");
    //return false;

    var thisfrom = $(this).attr("class").split(' ')[0].split('-')[1];
    thisfrom = thisfrom == "abhilasha3" ? "Abhilasha 3" : thisfrom;
    if (thisfrom.indexOf('_') > -1) {
        thisfrom = thisfrom.replace(/_/g, " ");
    }
    thisfrom = "Rohan " + thisfrom;
    $("#ContentPlaceHolder1_csshdncpProjectName").val(thisfrom);
    var jsondataproject = $("#ContentPlaceHolder1_csshdncpProjectListValues").val();
    var jddd = "";
    if (jsondataproject == "") {

    }
    else {
        jddd = $.parseJSON(jsondataproject);
    }

    var isexists = "N";
    $.each(jddd, function (i, item) {
        //alert(jddd[i].Texts.toLowerCase() + " -- " + jddd[i].Values);
        if (jddd[i].Texts.toLowerCase() == thisfrom.toLowerCase()) {
            $("#staticBackdrop").modal("show");
            $(".clsheadertitle").html(thisfrom.toUpperCase());
            isexists = "Y";
            $("#ContentPlaceHolder1_csshdnProjecids").val(jddd[i].Values);
            fngetchannelpartne("", "PL", jddd[i].Values);
            setTimeout(function () {
                fngetchannelpartne("", "TTL", jddd[i].Values);
                var thiopt = "<option value='0'>Token Amount</option>";
                $("#cmb_Token_Amount_popup").html(thiopt);
            }, 500);
            return;
        }

    });

    if (isexists == "N") {
        $(".clsheaderalert").text("Please add this project data in MDOC First");
        $('#staticAlert').modal("show");
        $('#staticAlert').css({ "z-index": "999999999999" });
        return false;
    }
})

$("#btn_get_otp_finalsubmit").click(function (e) {
    e.preventDefault();
    var thitextval = $("#btn_get_otp_finalsubmit").text();
    if (thitextval == "Please wait....") {
        alert(thitextval);
    }
    else {

        $("#loading").show();
        var vraccestoken = $("#ContentPlaceHolder1_csshdnTokenaccs").val();
        var thisEmaiidsvalues = $("#popup-email").val();
        var vrprojids = $("#ContentPlaceHolder1_csshdnProjecids").val();
        var vrfinlvalue = vrprojids + "^" + thisEmaiidsvalues;
        setTimeout(function () {
            fngetchannelpartne(vraccestoken, "EMAIL", vrfinlvalue);
        }, 500);



        fnVerifiedandpushData("", "");
    }


    //$(".clslableotp").text("");
    //var vrotpids = $("#csshdnOTPId").val();
    //var otpenter = "";
    //$(".otp").each(function () {
    //    var thisvalues = $(this).val();
    //    otpenter = otpenter + thisvalues;
    //});
    //$(".clslableotp").text("Please wait....");
    //$(".clslableotp").css({ "color": "red" });
    ////fnVerifiedandpushData(vrotpids, otpenter);
    //fnCommonOTP('', '', 'EOI OTP', 'CheckOTP', vrotpids, otpenter);
});

$("#popup-phone_mob").keyup(function () {
    var thikeyval = $(this).val();
    var thilength = thikeyval.length;
    $("#popup-First-name,#popup-Middle-name,#popup-Last-name,#popup-email,#popup-Cheque,#popup-Bank-name,#popup-Bank-Branch-Address,#txtcomments").val("");
    $("#cmb_Token_Amount_popup").html('<option value="0">Token Amount</option>');

    $("#cmb_Salutation_popup,#cmb_Preferences_popup,#cmb_Token_Type_popup").prop("selectedIndex", 0);

    $("#ContentPlaceHolder1_csshdntransactionId").val("0");
    //$("#cmb_Preferences_popup option[value='..']").attr('selected', 'selected');
    //$("#cmb_Token_Type_popup option[value='..']").attr('selected', 'selected');
    //$("#cmb_Token_Amount_popup option[value='0']").attr('selected', 'selected');
    if (thilength == '10') {
        $("#loading").show();
        var vraccestoken = $("#ContentPlaceHolder1_csshdnTokenaccs").val();
        var thismobvalues = thikeyval;
        var vrprojids = $("#ContentPlaceHolder1_csshdnProjecids").val();
        var vrfinlvalue = vrprojids + "^" + thismobvalues;
        setTimeout(function () {
            fngetchannelpartne(vraccestoken, "MOB", vrfinlvalue);
        }, 500);

    }
});

$('#popup-First-name,#popup-Middle-name,#popup-Last-name').on('keypress', function (e) {
    if (e.which == 32) {
        return false;
    }
});

$("#cmb_Token_Type_popup").change(function (e) {
    e.preventDefault();
    $("#totalusablesqft").val("");
    $("#divwing").css("display", "none");
    var thistokevalues = $(this).val();
    $("#cmb_Wing_popup").html('<option value="0">Wing</option>');
    $("#cmb_Unit_Type_popup").html('<option value="0">Unit Type</option>');
    $("#cmb_Unit_Number_popup").html('<option value="0">Unit Number</option>');
    $("#cmb_Token_Amount_popup").html('<option value="0">Token Amount</option>');

    if (thistokevalues == ".." || thistokevalues == "..." || thistokevalues == "" || thistokevalues == "0") {

    }
    else {
        $("#loading").show();
        var vraccestoken = $("#ContentPlaceHolder1_csshdnTokenaccs").val();
        var vrprojids = $("#ContentPlaceHolder1_csshdnProjecids").val();
        var vrfinlvalue = vrprojids + "^" + thistokevalues;
        fngetchannelpartne(vraccestoken, "TAMT", vrfinlvalue);
        fngetchannelpartne(vraccestoken, "WG", vrfinlvalue);
    }
});

$("#cmb_Wing_popup").change(function (e) {
    e.preventDefault();
    $("#totalusablesqft").val("");
    var optioUt = "<option value='0'>Unit Type</option>";
    var optiUN = "<option value='0'>Unit Number</option>";
    $("#cmb_Unit_Type_popup").html(optioUt);
    $("#cmb_Unit_Number_popup").html(optiUN);

    $("#loading").show();
    var vraccestoken = $("#ContentPlaceHolder1_csshdnTokenaccs").val();
    var thiswingids = $(this).val();
    var vrprojids = $("#ContentPlaceHolder1_csshdnProjecids").val();
    var vrfinlvalue = vrprojids + "^" + thiswingids + "^";
    fngetchannelpartne(vraccestoken, "UT", vrfinlvalue);
});

$("#cmb_Unit_Type_popup").change(function (e) {
    e.preventDefault();
    $("#loading").show();
    $("#totalusablesqft").val("");
    var vraccestoken = $("#ContentPlaceHolder1_csshdnTokenaccs").val();
    var thiswingids = $("#cmb_Wing_popup").val();
    var thisunitytpe = $(this).val();
    var vrprojids = $("#ContentPlaceHolder1_csshdnProjecids").val();
    var vrfinlvalue = vrprojids + "^" + thiswingids + "^" + thisunitytpe;
    fngetchannelpartne(vraccestoken, "UN", vrfinlvalue);
});

$("#cmb_Unit_Number_popup").change(function (e) {
    e.preventDefault();
    $("#loading").show();
    $("#totalusablesqft").val("");
    var vraccestoken = $("#ContentPlaceHolder1_csshdnTokenaccs").val();

    var thisuniNumber = $(this).val();

    var vrfinlvalue = thisuniNumber;
    fngetchannelpartne(vraccestoken, "SQFT", vrfinlvalue);
});

$("#gridCheck").click(function (e) {
    if (urlcsss.indexOf('refferal') > -1) {
        $("#cptnc").hide();
        $("#rfrltnc,#divtncheader").show();
    }
    else {
        $("#cptnc").show();
        $("#rfrltnc,#divtncheader").hide();
    }
    if ($("#gridCheck").prop('checked') == true) {
        $("#statictermNcondition").modal("show");
    }
});

setTimeout(function () {

    var vraccestoken = $("#ContentPlaceHolder1_csshdnTokenaccs").val();
    var vrpannam = $("#ContentPlaceHolder1_cssCPPanNo").val();// "7896541237";
    if (vraccestoken != "") {
        fngetchannelpartne(vraccestoken, "PR", vrpannam);
        $("#loading").show();
        if (urlcsss.indexOf('referral.aspx') > -1) {
            $("#ContentPlaceHolder1_csshdncpSourdetailds").val("fc1935cf-ee52-49dd-8577-92fa69637fbb");
        }
        else if (urlcsss.indexOf('/sales/') > -1) {
            $("#ContentPlaceHolder1_csshdncpSourcIds").val("032ADB2E-FB9B-42EE-A9DF-E5D1A643F47D");
            $("#ContentPlaceHolder1_csshdncpSourdetailds").val("a9b4d2bd-c431-4950-b37e-04e65a100390");
        }
        else {
            fngetchannelpartne(vraccestoken, "CP", vrpannam);
        }
        fngetchannelpartne(vraccestoken, "SL", vrpannam);
        $("#loading").show();
        setTimeout(function () {
            $("#divclickc").click();
            $("#loading").hide();
        }, 500);
        //fngetchannelpartne(vraccestoken, "TTL", vrpannam);
        //setTimeout(function () {
        //    fngetchannelpartne(vraccestoken, "PL", $("#ContentPlaceHolder1_csshdnProjecids").val());
        //}, 500);
    }
}, 3000);

function fngetchannelpartne(accesstk, tpee, vlauessss) {
    $.ajax({
        type: "POST",
        url: "/WebApi.aspx/fnget_CSP_MDOCApi",
        data: "{ straAccesToken:'" + accesstk + "',strtypvalues:'" + tpee + "',strValues:'" + vlauessss + "'}",
        processing: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var thivall2 = JSON.parse(r.d);
            if (tpee == "CP") {
                $.each(thivall2, function (key, val) {
                    let cpname = val.Name;
                    let cpmobno = val.Mob;
                    let sourccid = val.SourceIds;
                    let cpemailod = val.Name;
                    let cpsourdetailsidsd = val.SourcdetailId;
                    $(".clscsscpName").text(cpname);
                    $(".clscsscpMob").text(cpmobno);
                    $("#ContentPlaceHolder1_csshdncpMobNo").val(cpmobno);
                    $("#ContentPlaceHolder1_csshdncpSourcIds").val(sourccid);
                    $("#ContentPlaceHolder1_csshdncpSourdetailds").val(cpsourdetailsidsd);
                });
            }
            else if (tpee == "SL") {
                var thiopt = "<option value='..'>Salutation</option>";
                $.each(thivall2, function (key, val) {
                    thiopt = thiopt + "<option value='" + val.Texts + "'>" + val.Texts + "</option>";
                });
                $("#cmb_Salutation_popup").html(thiopt);
            }
            else if (tpee == "TTL") {
                var thiopt = "<option value='..'>Token Type</option>";
                $.each(thivall2, function (key, val) {
                    thiopt = thiopt + "<option value='" + val.Values + "'>" + val.Texts + "</option>";
                });
                $("#cmb_Token_Type_popup").html(thiopt);
            }
            else if (tpee == "PR") {
                //alert(JSON.stringify(thivall2));
                $("#ContentPlaceHolder1_csshdncpProjectListValues").val(JSON.stringify(thivall2));

                //$.each(thivall2, function (key, val) {
                //    $("#ContentPlaceHolder1_csshdnProjecids").val(val.Values);
                //    fngetchannelpartne(accesstk, "PL", val.Values);
                //});
            }
            else if (tpee == "TAMT") {
                var thiopt = "<option value='0'>Token Amount</option>";
                $.each(thivall2, function (key, val) {
                    thiopt = thiopt + "<option value='" + val.Values + "' selected>" + val.Texts + "</option>";
                });
                $("#cmb_Token_Amount_popup").html(thiopt);
            }
            else if (tpee == "PL") {
                var thiopt = "<option value='..'>Preference</option>";
                $.each(thivall2, function (key, val) {
                    thiopt = thiopt + "<option value='" + val.Values + "'>" + val.Texts + "</option>";
                });
                $("#cmb_Preferences_popup").html(thiopt);


                //var urlPune = window.location.href;
                //if (urlPune.indexOf('/sales/') > -1) {
                //    var thiopt_2 = "<option value='..'>Secondary Preference</option>";
                //    $.each(thivall2, function (key, val) {
                //        thiopt_2 = thiopt_2 + "<option value='" + val.Values + "'>" + val.Texts + "</option>";
                //    });
                //    $("#cmb_Preferences_popup_2").html(thiopt_2);
                //}
            }
            else if (tpee == "WG") {
                var thiopt = "<option value='0'>Wing</option>";
                var ffdd = thivall2;
                if (ffdd == "") {
                    $("#divwing").css("display", "none");
                }
                else {
                    $("#divwing").css({ "display": "flex" });
                }
                $.each(thivall2, function (key, val) {
                    thiopt = thiopt + "<option value='" + val.Values + "'>" + val.Texts + "</option>";
                });
                $("#cmb_Wing_popup").html(thiopt);
            }
            else if (tpee == "UT") {
                var thiopt = "<option value='0'>Unit Type</option>";
                var ffdd = thivall2;
                $.each(thivall2, function (key, val) {
                    thiopt = thiopt + "<option value='" + val.Values + "'>" + val.Texts + "</option>";
                });
                $("#cmb_Unit_Type_popup").html(thiopt);
            }
            else if (tpee == "UN") {
                var thiopt = "<option value='0'>Unit Number</option>";
                var ffdd = thivall2;
                $.each(thivall2, function (key, val) {
                    thiopt = thiopt + "<option value='" + val.Values + "'>" + val.Texts + "</option>";
                });
                $("#cmb_Unit_Number_popup").html(thiopt);
            }
            else if (tpee == "MOB") {
                $.each(thivall2, function (key, val) {
                    var curstatus = val.Texts;
                    var curmss = val.Values;
                    if (curstatus == "success") {
                        $("#popup-phone").val($("#popup-phone_mob").val());
                        $("#popup-phone").attr("disabled", "disabled");
                    }
                    else {

                        $("#popup-phone_mob").val("");
                        $("#popup-phone").val("");
                        $(".clsheaderalert").text(curmss);
                        $('#staticBackdrop')
                            .modal('hide')
                            .on('hidden.bs.modal', function (e) {
                                // $('#modal-Responsedata').modal('show');
                                $('#staticAlert').modal("show");

                                $(this).off('hidden.bs.modal'); // Remove the 'on' event binding
                            });
                    }
                });
            }
            else if (tpee == "SQFT") {
                var thiopt = "";
                $.each(thivall2, function (key, val) {
                    thiopt = val.Texts;
                });
                $("#totalusablesqft").val(thiopt);
            }

            $("#loading").hide();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.responseText);
        }
    });
}

function fnCommonOTP(mobno, emailid, sourcss, btntype, idss, otpentered) {
    $.ajax({
        type: "POST",
        url: "/WebApi.aspx/Generate_otp",
        data: "{ phone_1:'" + mobno + "',stremailid:'" + emailid + "',strSourcess:'" + sourcss + "',strbtntype:'" + btntype + "',strIds:'" + idss + "',strotpentered:'" + otpentered + "'}",
        processing: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var thidddd = r.d;

            if (btntype == 'CheckOTP') {
                if (thidddd == 'Verified') {
                    $(".clslableotp").text("OTP Verified Please wait....");
                    $(".clslableotp").css({ "color": "darkgreen" });
                    $("#divmobn").hide();
                    $("#divshowform").show();
                    setTimeout(function () {

                        $('#staticBackdrop2')
                            .modal('hide')
                            .on('hidden.bs.modal', function (e) {
                                // $('#modal-Responsedata').modal('show');
                                $('#staticBackdrop').modal("show");

                                $(this).off('hidden.bs.modal'); // Remove the 'on' event binding
                            });
                    }, 1000);
                }
                else {
                    $(".clslableotp").text("Invalid OTP");
                    $(".clslableotp").css({ "color": "red" });
                }
            }
            else if (btntype == 'Resend') {
                $(".clsaResend").text("Re-Sent");
                $(".clsaResend").css({ "color": "green" });

                setTimeout(function () {
                    $(".clsaResend").text("Resend OTP");
                    $(".clsaResend").css({ "color": "#0d6efd" });
                }, 5000);
            }
            else {
                $("#csshdnOTPId").val(thidddd);
                $('#staticBackdrop')
                    .modal('hide')
                    .on('hidden.bs.modal', function (e) {
                        // $('#modal-Responsedata').modal('show');
                        $('#staticBackdrop2').modal("show");

                        $(this).off('hidden.bs.modal'); // Remove the 'on' event binding
                    });
            }
        },
        //complete: function () {
        //    if (strstatus == 'CheckOTP') {
        //        var srrr = fnInsertData(btntype);
        //        if (srrr == "Y") {
        //            alert("Complete Function: Y");
        //            //$('#staticBackdrop2').modal("hide");
        //            //$('#myModalPayment').modal('show');
        //            //$('#myModalPayment').modal("show");
        //        }
        //        else {
        //            alert("Next:" + srrr);
        //        }
        //    }
        //},
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.responseText);
        }
    });
    return false;
}



function fnInsertData(btntypee) {
    var CPPanardNo = "DemoPancard";
    var Projects = "";
    var Salutation = $("#cmb_Salutation_popup").val();
    var First_Name = $("#popup-First-name").val();
    var Middle_Name = $("#popup-Middle-name").val();
    var Last_Name = $("#popup-Last-name").val();
    var Mob = $("#popup-phone").val();
    var WhatsAppNo = $("#popup-phone").val();
    var EmailId = $("#popup-email").val();
    var Preferences = $("#cmb_Preferences_popup").val();
    var TokenType = $("#cmb_Token_Type_popup").val();
    var TokenAmount = $("#cmb_Token_Amount_popup").val();
    var Cheque_TRNNo = $("#popup-Cheque").val();
    var Bank_Name = $("#popup-Bank-name").val();
    var Bank_Branch_Address = $("#popup-Bank-Branch-Address").val();
    var Source = $("#cshdnsources").val();
    var Source_Detail = "EOI";
    var Comments = $("#txtcomments").val();
    var strmsg = "";



    if (First_Name == "") {
        strmsg += "\nEnter the valid first Name.";
    }
    if (Mob == "") {
        strmsg += "\nEnter the mob.";
    }
    if (EmailId == "") {
        strmsg += "\nEnter the Valid EmailId.";
    }
    else {
        if (!validateEmail(EmailId)) {
            strmsg += "\nEnter the Valid EmailId.";
        }
    }
    if (TokenType == "" || TokenType == "0") {
        strmsg += "\nSelect Token Amount.";
    }


    if (btntypee == "getotp") {
        if (strmsg == "") {
            strmsg = "Y";
        }
    }
    else if (btntypee == "CheckOTP") {
        $.ajax({
            type: "POST",
            url: "/WebApi.aspx/TransactioninsertData",
            data: "{ Id:'0',CPPanardNo:'" + CPPanardNo + "',Projects:'" + Projects + "',Salutation:'" + Salutation + "',First_Name:'" + First_Name + "',Middle_Name:'" + Middle_Name + "',Last_Name:'" + Last_Name + "',Mob:'" + Mob + "',WhatsAppNo:'" + WhatsAppNo + "',EmailId:'" + EmailId + "',Preferences:'" + Preferences + "',TokenType:'" + TokenType + "',TokenAmount:'" + TokenAmount + "',Cheque_TRNNo:'" + Cheque_TRNNo + "',Bank_Name:'" + Bank_Name + "',Bank_Branch_Address:'" + Bank_Branch_Address + "',Source:'" + Source + "',Source_Detail:'" + Source_Detail + "',Source_Description:'-',Comments:'" + Comments + "',Wing:'-',Unit_Type:'-',Unit_Number:'-',PaymentId:'-',PayRefid:'-',PaymentStatus:'-',btnType:'New'}",
            processing: true,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var thidddd = r.d;
                if (thidddd.indexOf("Error") != -1) {
                    var thistransactioid = thidddd.split(":")[1]; //csstransactionId
                    $("#ContentPlaceHolder1_csshdntransactionId").val(thistransactioid);
                    //setTimeout(function () {
                    //    $("#ContentPlaceHolder1_btnpaydata").click();
                    //}, 1000);
                    strmsg = "Y";
                }
                else {
                    strmsg = thidddd;
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest.responseText);
            }
        });


    }

    return strmsg;
}


function fnVerifiedandpushData(vrotpids, otpenter) {
    var CPPanardNo = $("#ContentPlaceHolder1_cssCPPanNo").val();
    var Projects = $("#ContentPlaceHolder1_csshdnProjecids").val();
    var Salutation = $("#cmb_Salutation_popup").val();
    var First_Name = $("#popup-First-name").val();
    var Middle_Name = $("#popup-Middle-name").val();
    var Last_Name = $("#popup-Last-name").val();
    var Mob = $("#popup-phone").val();
    var WhatsAppNo = $("#popup-phone").val();
    var EmailId = $("#popup-email").val();
    var Preferences = $("#cmb_Preferences_popup").val();
    var TokenType = $("#cmb_Token_Type_popup").val();
    var TokenAmount = $("#cmb_Token_Amount_popup").val();
    var Cheque_TRNNo = $("#popup-Cheque").val();
    var Bank_Name = $("#popup-Bank-name").val();
    var Bank_Branch_Address = $("#popup-Bank-Branch-Address").val();
    var Source = $("#cshdnsources").val();// "Channel Partner";
    var Source_Detail = "EOI";
    var Comments = "";
    Comments = $("#cmb_Preferences_popup_2").val();
    
    //var urlsalessComments = window.location.href;
    //if (urlsalessComments.indexOf('/sales/') > -1) {
    //    Comments = $("#cmb_Preferences_popup_2").val();
    //}
    //else {
    //   Comments = $("#txtcomments").val();
    //}

    var strmsg = "";
    var btntypename = $("#ContentPlaceHolder1_csshdntransactionId").val() == "0" ? "New" : "Update";
    var idss = $("#ContentPlaceHolder1_csshdntransactionId").val();
    var vrsessionidsd = $("#ContentPlaceHolder1_csshdnSessionids").val();
    var wingdd = $("#cmb_Wing_popup").val();
    var unittypedd = $("#cmb_Unit_Type_popup").val();
    var unitnumberdd = $("#cmb_Unit_Number_popup").val();
    var vrSource_Description = "";
    var vrguidss = "";
    var vrfilenames = "";
    if (urlcsss.indexOf('refferal') > -1) {
        var reffrerbyName = $("#Referred-name").val();
        var refbyProjUnit = $("#ProjectsNUnit").val();
        var refbyEmaild = $("#reffered-phone1").val();
        var findescription = 'Reffered By: ' + reffrerbyName + " - " + refbyProjUnit + " - " + refbyEmaild;
        vrSource_Description = findescription;
    }
    //if (TokenType != "34b8b6e1-465f-4b94-9b67-a619fac426ae") {
    //    wingdd = "";
    //    unittypedd = "";
    //    unitnumberdd = "";
    //}

    if (Salutation == "" || Salutation == ".." || Salutation == "0" || Salutation == "...") {
        strmsg += "<br>Select the Salutation first.";
    }

    if (First_Name == "") {
        strmsg += "<br>Enter the valid first Name.";
    }
    if (Mob == "") {
        strmsg += "<br>Enter the mob.";
    }
    if (EmailId == "") {
        strmsg += "<br>Enter the Valid EmailId.";
    }
    else {
        if (!validateEmail(EmailId)) {
            strmsg += "<br>Enter the Valid EmailId.";
        }
    }
    if (TokenType == "" || TokenType == "0" || TokenType == ".." || TokenType == "...") {
        strmsg += "<br>Select Token Type.";
    }
    if (TokenAmount == "" || TokenAmount == "0" || TokenAmount == ".." || TokenType == "...") {
        strmsg += "<br>Select Token Amount.";
    }
    if ($("#gridCheck").prop('checked') == false) {
        strmsg += "<br>check Term & Conditions";
    }

    if (strmsg == "") {
        $('#recaptcha').css("border", "");
        var $captcha = $('#recaptcha'),
            response = grecaptcha.getResponse();

        if (response.length === 0) {
            $('#recaptcha').css("border", "1px solid red");
            return true;
        }
        else {
            $("#btn_get_otp_finalsubmit").text("Please wait....");
            setTimeout(function () {
                var urlsaless = window.location.href;
                if (urlsaless.indexOf('/sales/') > -1 || urlsaless.indexOf('/cp/')) {
                    var fileUpload = $("#fu_cheque").get(0);
                    var files = fileUpload.files;
                    var data = new FormData();
                    for (var i = 0; i < files.length; i++) {
                        //data.append(files[i].name, files[i]);
                        var filename = files[i].name.replace(' ', '');
                        data.append(filename + '^', files[i]);
                    }
                    $.ajax({
                        url: "../Handler1.ashx",
                        type: "POST",
                        data: data,
                        contentType: false,
                        processData: false,
                        success: function (result) {
                            var strvarguid = '';
                            if (result == '') {
                                $(".clsheaderalert").text("Please upload the cheque book.");
                                $('#staticAlert').modal("show");
                                $('#staticAlert').css({ "z-index": "999999999999" });

                                $("#btn_get_otp_finalsubmit").text("Submit");

                            }
                            else {
                                vrguidss = result.split('^')[0];
                                vrfilenames = result.split('^')[1];
                                setTimeout(function () {
                                    $.ajax({
                                        type: "POST",
                                        url: "/WebApi.aspx/VerifiedandTransactioninsertData",
                                        data: "{ Id:'" + idss + "',CPPanardNo:'" + CPPanardNo + "',Projects:'" + Projects + "',Salutation:'" + Salutation + "',First_Name:'" + First_Name + "',Middle_Name:'" + Middle_Name + "',Last_Name:'" + Last_Name + "',Mob:'" + Mob + "',WhatsAppNo:'" + WhatsAppNo + "',EmailId:'" + EmailId + "',Preferences:'" + Preferences + "',TokenType:'" + TokenType + "',TokenAmount:'" + TokenAmount + "',Cheque_TRNNo:'" + Cheque_TRNNo + "',Bank_Name:'" + Bank_Name + "',Bank_Branch_Address:'" + Bank_Branch_Address + "',Source:'" + Source + "',Source_Detail:'" + Source_Detail + "',Source_Description:'" + vrSource_Description + "',Comments:'" + Comments + "',Wing:'" + wingdd + "',Unit_Type:'" + unittypedd + "',Unit_Number:'" + unitnumberdd + "',PaymentId:'-',PayRefid:'-',PaymentStatus:'-',btnType:'" + btntypename + "',strOTPIds:'" + vrotpids + "',strCutOTPEntered:'" + otpenter + "',strsessionids:'" + vrsessionidsd + "',strguids:'" + vrguidss + "',strfilenames:'" + vrfilenames + "'}",
                                        processing: true,
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        success: function (r) {
                                            var thidddd = r.d;
                                            if (thidddd.indexOf("Error") != -1) {
                                                strmsg = thidddd;
                                                alert(strmsg);
                                                $("#btn_get_otp_finalsubmit").text("Submit");
                                            }
                                            else {
                                                if (thidddd.indexOf("Verified") > -1) {
                                                    $(".clslableotp").text("OTP Verified Please wait....");
                                                    $(".clslableotp").css({ "color": "darkgreen" });
                                                    if (thidddd.indexOf(">") > -1) {
                                                        var thisverided = thidddd.split(">")[0];
                                                        var thisvarstatus = thidddd.split(">")[1];
                                                        if (thisvarstatus != 0) {
                                                            var thistransactionid = thidddd.split(":")[1];

                                                            var cname = First_Name + " " + Middle_Name + " " + Last_Name;
                                                            var mobvv = Mob;
                                                            var emsisl = EmailId;
                                                            var amountdd = TokenAmount;
                                                            var vrtokentypeidd = TokenType;
                                                            var vrprefernc = Preferences;

                                                            //var wingdd = $("#cmb_Wing_popup").val();
                                                            //var unittypedd = $("#cmb_Unit_Type_popup").val();
                                                            //var vrunitnumberdd = $("#cmb_Unit_Number_popup").val();

                                                            $("#ContentPlaceHolder1_csshdnName").val(cname.trim());
                                                            $("#ContentPlaceHolder1_csshdnMob").val(mobvv);
                                                            $("#ContentPlaceHolder1_csshdnEmailid").val(emsisl);
                                                            $("#ContentPlaceHolder1_csshdnAmount").val(amountdd);
                                                            $("#ContentPlaceHolder1_csshdntransactionId").val(thistransactionid);
                                                            $("#ContentPlaceHolder1_csshdncptokenTypds").val(vrtokentypeidd);
                                                            $("#ContentPlaceHolder1_csshdncpPrefernces").val(vrprefernc);

                                                            //$("#ContentPlaceHolder1_csshdncpWing").val(wingdd);
                                                            //$("#ContentPlaceHolder1_csshdncpUnittype").val(unittypedd);
                                                            $("#ContentPlaceHolder1_csshdncpUnitNumber").val(unitnumberdd);

                                                            setTimeout(function () {
                                                                $("#ContentPlaceHolder1_btnpaydata").click();
                                                            }, 1000);
                                                            //setTimeout(function () {
                                                            //    // $("#ContentPlaceHolder1_btnpaydata").click();
                                                            //    $('#staticBackdrop').modal("hide");
                                                            //    $('#myModalPayment').modal('show');

                                                            //}, 1000);
                                                        }
                                                        else {
                                                            $(".clslableotp").text(thisvarstatus);
                                                            $(".clslableotp").css({ "color": "red" });
                                                        }
                                                    }
                                                }
                                                else {
                                                    //$(".clslableotp").text(thidddd);
                                                    //$(".clslableotp").css({ "color": "red" });
                                                    $(".clsheaderalert").text(thidddd);
                                                    $('#staticAlert').modal("show");
                                                    $('#staticAlert').css({ "z-index": "999999999999" });

                                                    $("#btn_get_otp_finalsubmit").text("Submit");
                                                }
                                                strmsg = "Y";

                                            }
                                        },
                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                            alert(XMLHttpRequest.responseText);
                                            $("#btn_get_otp_finalsubmit").text("Submit");
                                        }
                                    });
                                }, 700);



                            }
                        }
                    });

                }
                else {
                    $.ajax({
                        type: "POST",
                        url: "/WebApi.aspx/VerifiedandTransactioninsertData",
                        data: "{ Id:'" + idss + "',CPPanardNo:'" + CPPanardNo + "',Projects:'" + Projects + "',Salutation:'" + Salutation + "',First_Name:'" + First_Name + "',Middle_Name:'" + Middle_Name + "',Last_Name:'" + Last_Name + "',Mob:'" + Mob + "',WhatsAppNo:'" + WhatsAppNo + "',EmailId:'" + EmailId + "',Preferences:'" + Preferences + "',TokenType:'" + TokenType + "',TokenAmount:'" + TokenAmount + "',Cheque_TRNNo:'" + Cheque_TRNNo + "',Bank_Name:'" + Bank_Name + "',Bank_Branch_Address:'" + Bank_Branch_Address + "',Source:'" + Source + "',Source_Detail:'" + Source_Detail + "',Source_Description:'" + vrSource_Description + "',Comments:'" + Comments + "',Wing:'" + wingdd + "',Unit_Type:'" + unittypedd + "',Unit_Number:'" + unitnumberdd + "',PaymentId:'-',PayRefid:'-',PaymentStatus:'-',btnType:'" + btntypename + "',strOTPIds:'" + vrotpids + "',strCutOTPEntered:'" + otpenter + "',strsessionids:'" + vrsessionidsd + "',strguids:'" + vrguidss + "',strfilenames:'" + vrfilenames + "'}",
                        processing: true,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            var thidddd = r.d;
                            if (thidddd.indexOf("Error") != -1) {
                                strmsg = thidddd;
                                alert(strmsg);
                                $("#btn_get_otp_finalsubmit").text("Submit");
                            }
                            else {
                                if (thidddd.indexOf("Verified") > -1) {
                                    $(".clslableotp").text("OTP Verified Please wait....");
                                    $(".clslableotp").css({ "color": "darkgreen" });
                                    if (thidddd.indexOf(">") > -1) {
                                        var thisverided = thidddd.split(">")[0];
                                        var thisvarstatus = thidddd.split(">")[1];
                                        if (thisvarstatus != 0) {
                                            var thistransactionid = thidddd.split(":")[1];

                                            var cname = First_Name + " " + Middle_Name + " " + Last_Name;
                                            var mobvv = Mob;
                                            var emsisl = EmailId;
                                            var amountdd = TokenAmount;
                                            var vrtokentypeidd = TokenType;
                                            var vrprefernc = Preferences;

                                            //var wingdd = $("#cmb_Wing_popup").val();
                                            //var unittypedd = $("#cmb_Unit_Type_popup").val();
                                            //var vrunitnumberdd = $("#cmb_Unit_Number_popup").val();

                                            $("#ContentPlaceHolder1_csshdnName").val(cname.trim());
                                            $("#ContentPlaceHolder1_csshdnMob").val(mobvv);
                                            $("#ContentPlaceHolder1_csshdnEmailid").val(emsisl);
                                            $("#ContentPlaceHolder1_csshdnAmount").val(amountdd);
                                            $("#ContentPlaceHolder1_csshdntransactionId").val(thistransactionid);
                                            $("#ContentPlaceHolder1_csshdncptokenTypds").val(vrtokentypeidd);
                                            $("#ContentPlaceHolder1_csshdncpPrefernces").val(vrprefernc);

                                            //$("#ContentPlaceHolder1_csshdncpWing").val(wingdd);
                                            //$("#ContentPlaceHolder1_csshdncpUnittype").val(unittypedd);
                                            $("#ContentPlaceHolder1_csshdncpUnitNumber").val(unitnumberdd);


                                            setTimeout(function () {
                                                // $("#ContentPlaceHolder1_btnpaydata").click();
                                                $('#staticBackdrop').modal("hide");
                                                $('#myModalPayment').modal('show');

                                            }, 1000);
                                        }
                                        else {
                                            $(".clslableotp").text(thisvarstatus);
                                            $(".clslableotp").css({ "color": "red" });
                                        }
                                    }
                                }
                                else {
                                    //$(".clslableotp").text(thidddd);
                                    //$(".clslableotp").css({ "color": "red" });
                                    $(".clsheaderalert").text(thidddd);
                                    $('#staticAlert').modal("show");
                                    $('#staticAlert').css({ "z-index": "999999999999" });

                                    $("#btn_get_otp_finalsubmit").text("Submit");
                                }
                                strmsg = "Y";

                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(XMLHttpRequest.responseText);
                            $("#btn_get_otp_finalsubmit").text("Submit");
                        }
                    });
                }

            }, 800);
        }
    }
    else {
        $(".clsheaderalert").html(strmsg);
        $(".clsheaderalert").css({ "text-align": "initial" });


        //    text-align: initial;
        $('#staticAlert').modal("show");
        $('#staticAlert').css({ "z-index": "999999999999" });

        $("#btn_get_otp_finalsubmit").text("Submit");
    }
}

function validateEmail($email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test($email);
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false; return true;
}
function isAlphabetKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
        return true; else
        return false;
}
