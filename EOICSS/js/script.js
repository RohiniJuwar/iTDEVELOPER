
let digitValidate = function (ele) {
    console.log(ele.value);
    ele.value = ele.value.replace(/[^0-9]/g, '');
}

let tabChange = function (val) {
    let ele = document.getElementsByClassName('otp');
    if (ele[val - 1].value != '') {
        ele[val].focus();
    } else if (ele[val - 1].value == '') {
        ele[val - 2].focus();
    }
}

      // Add active class to the current menu (highlight it)
      //var header = document.getElementById("navbarSupportedContent");
      //var btns = header.getElementsByClassName("nav-link");
      //for (var i = 0; i < btns.length; i++) {
      //  btns[i].addEventListener("click", function() {
      //  var current = document.getElementsByClassName("active");
      //  current[0].className = current[0].className.replace(" active", "");
      //  this.className += " active";
      //  });
      //}
   
       
    $('.navbar-nav>li>a').on('click', function(){
      $('.navbar-collapse').collapse('hide');
      
    });
	
	 $(function () { $('#sp1').on("click", function () { $(this).text(''); $('#dv1').toggle('slow'); }); $('#dv1').on("click", function () { $('#sp1').text('Read More'); $('#dv1').toggle('slow'); }); $('#dv1').hide().children('td'); }); function isNumberKey(evt) {
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
 
	
	   $("#popup-name").keypress(function (e) {
                var key = e.keyCode;
                if (key >= 48 && key <= 57) {
                    e.preventDefault();
                }
            });

            $(function () {
                $('[class^=clsreq-]').on("click", function () {
    
    var thisname=$(this).text();
    $("#isdownload").val((thisname.indexOf("Download") != -1)?"Y":"N");
    
                    var thiscc = $(this).attr("class").split(" ")[0].split("-")[1];
                    $('#cmb_typeofapartment_popup option')
                        .removeAttr('selected')
                        .filter('[value="' + thiscc + '"]')
                        .attr('selected', true)
                });
            });

$("#btn_submit_popup").click(function () {

  $('#recaptcha').css("border", "");
    var $captcha = $('#recaptcha'),
        response = grecaptcha.getResponse();
    if (response.length === 0) {
        $('#recaptcha').css("border", "1px solid red");
        return false;
    } else {

        var varname = $('#popup-name').val().trim();
        var varemail = $('#popup-email').val().trim();
        var varphone = $('#popup-phone').val().trim();
        var varapartment = $('#cmb_typeofapartment_popup').val();
        var msg = "y";
        $('#popup-name, #popup-email, #popup-phone').css("border-bottom", "");
        $('#popup-phone').removeClass("blink");
        if (varname == '' && varemail == '' && varphone == '') {
            msg = "n";
            //alert("Enter All Details");
            //return false;
            $('#popup-name, #popup-email, #popup-phone').css("border-bottom", "1px solid red");
        }
        else {
            if (varname == '') {
                $('#popup-name').css("border-bottom", "1px solid red");
                msg = "n";
            }
			else
			{
				if(validateName(varname)){
					
				}
				else{
					 $('#popup-name').css("border-bottom", "1px solid red");
                msg = "n";
				}
			}
            if (varemail == '') {
                $('#popup-email').css("border-bottom", "1px solid red");
                msg = "n";
            }
            else {
                if (validateEmail($('#popup-email').val())) {
                }
                else {
                    $('#popup-email').css("border-bottom", "1px solid red");
                    msg = "n";
                }
            }
            if (varphone == '') {
                $('#popup-phone').css("border-bottom", "1px solid red");
                msg = "n";
            }
            else {
                if (varphone.length == 10) {
                    var sd = varphone.replace(/[^0-9]/gi, '');
                    var number = parseInt(sd, 10);
                    var vd = number.toString();
                    if (vd.length == 10) {

                    }
                    else {
                        blink("#popup-phone", 6, 200);
                        msg = "n";
                    }
                }
                else {
                    blink("#popup-phone", 6, 200);
                    msg = "n";
                }
            }
        }

        if (msg == 'y') {
            dataLayer.push({ 'event': 'leads', 'enhanced_conversion_data': { "email": $("#popup-email").val() } })
            localStorage.setItem("email", $("#popup-email").val());

			 var vrsource = "-";
            var vrsourcedetails = "-";
            var url = window.location.href;
            if (url.indexOf('/c/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "Colombia";
            }
            else if (url.indexOf('/d/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "Dailyhunt";
            }
            else if (url.indexOf('/e/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "EMAIL BLAST";
            }
            else if (url.indexOf('/f/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "FacebookAd";
            }
            else if (url.indexOf('/g/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "GoogleAds";
            }
            else if (url.indexOf('/gg/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "GoogleAds";
            }
            else if (url.indexOf('/i/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "Inshorts";
            }
            else if (url.indexOf('/ns/') > -1) {
                vrsource = "NEWSPAPER";
                vrsourcedetails = "Sakal";
            }
            else if (url.indexOf('/nt/') > -1) {
                vrsource = "NEWSPAPER";
                vrsourcedetails = "Times of India";
            }
            else if (url.indexOf('/o/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "Outbrain";
            }
            else if (url.indexOf('/q/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "Quora";
            }
            else if (url.indexOf('/s/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "SMS";
            }
            else if (url.indexOf('/sm/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "FacebookAd";
            }
            else if (url.indexOf('/t/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "taboola";
            }
            else if (url.indexOf('/ts/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "TimesArticle";
            }
            else if (url.indexOf('/v/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "Verizon";
            }
            else if (url.indexOf('/y/') > -1) {
                vrsource = "SEM";
                vrsourcedetails = "GAd-YT";
            }
			  else if (url.indexOf('/test/') > -1) {
               vrsource = "SEM";
                vrsourcedetails = "GoogleAds";
            }
            else {
                vrsource = url;
                vrsourcedetails = url;
            }
			
            $("#btn_submit_popup").css({ "pointer-events": "none" });
            var keyword = getParameterByName('utm_keyword');
            var matchtype = getParameterByName('matchtype');
            var creative = getParameterByName('creative');
            var placement = getParameterByName('utm_placement');
            var model = getParameterByName('utm_model');
            var utm_campaign = getParameterByName('utm_campaign').replace("_", "-");
            var campaigntype = getParameterByName('utm_campaigntype');
            var utm_source = getParameterByName('utm_source');
            var utm_medium = getParameterByName('utm_medium');
            var utm_adgroup = getParameterByName('utm_adgroup');
            var mobiled = getParameterByName('utm_mobile');
            var gclid = getParameterByName('gclid');
            var source = getParameterByName('source');
            var sourcedetails = getParameterByName('sourcedetails');
            var campaign = getParameterByName('utm_campaign').replace("_", "-");
            var adgroup = getParameterByName('utm_adgroup').replace("_", "-");
            var device = getParameterByName('utm_device').replace("_", "-");

            // var vrsource = localStorage.getItem("source");
            // var vrsourcedetails = localStorage.getItem("sourcedetails");

			

            //alert("keyword: " + keyword + ",matchtype: " + matchtype + ",creative: " + creative + ",placement: " + placement + ",model: " + model + ",utm_campaign: " + utm_campaign + ",campaigntype: " + campaigntype + ",utm_source: " + utm_source + ",utm_medium: " + utm_medium + ",utm_adgroup: " + utm_adgroup + ",mobiled: " + mobiled + ",gclid: " + gclid + ",source: " + source + ",sourcedetails: " + sourcedetails + ",campaign: " + campaign + ",adgroup: " + adgroup + ",device: " + device);


            //return false;
            var site = "Rohan Viti";
            var utype = "U";
            if (keyword == '') {
                keyword = "-"
            }
            if (matchtype == '') {
                matchtype = "-"
            }
            if (creative == '') {
                creative = "-"
            }
            if (placement == '') {
                placement = "-"
            }
            if (model == '') {
                model = "-"
            }
            if (campaigntype == '') {
                campaigntype = "-"
            }
            if (utm_source == '') {
                utm_source = "-"
            }
            if (utm_medium == '') {
                utm_medium = "-"
            }
            if (gclid == '') {
                gclid = "-"
            }
            if (campaign == '') {
                campaign = "-"
            }
            if (campaign == '') {
                campaign = "-"
            }
            if (adgroup == '') {
                adgroup = "-"
            }
            if (device == '') {
                device = "-"
            }
			if (source == '-') {
                source = vrsource
            }
            if (sourcedetails == '-' || sourcedetails == 'null') {
                sourcedetails = vrsourcedetails
            }

            if (utm_campaign == '') {
                utm_campaign = "-"
            }
            if (utm_adgroup == '') {
                utm_adgroup = "-"
            }
            if (device == '') {
                device = "-"
            }
            if (mobiled == '') {
                mobiled = "-"
            }

           
         
            //$(".imgloading").css({ "display": "inline-block", "position": "absolute", "margin-top": "-39px", "margin-left": "70%" });
             setTimeout(function () {
                  window.location.href = "thank-you.html";
              }, 10);


         

             
           $.ajax({
               async: false,
                 processing: true,
                type: "POST",
                contentType: "application/json; charset=utf-8",

                url: "https://msgapi.rohanbuilders.com/ZHOHOAPI.aspx/SendZhohRequestCommon",
                data: "{name: '" + $("#popup-name").val() + "',email: '" + $("#popup-email").val() + "', mobile: '" + $("#popup-phone").val() + "', site: '" + site + "', source: '" + source + "',sourcedetails: '" + sourcedetails + "',typeofunit: '" + varapartment + "',type: '" + utype + "',keyword:'" + keyword + "',matchtype:'" + matchtype + "',creative:'" + creative + "', placement:'" + placement + "', model:'" + model + "', campaigntype:'" + campaigntype + "', utm_source:'" + utm_source + "', utm_medium:'" + utm_medium + "', gclid:'" + gclid + "',utm_campaign:'" + utm_campaign + "',utm_adgroup:'" + utm_adgroup + "',device:'" + device + "',mobiled:'" + mobiled + "'}",
               dataType: "json",
               success: function (data) {
           
                 }
                 
            });
            try {
                if($("#isdownload").val()=="Y")
                {
                    window.open("../../download/Rohan-Viti.pdf", '_blank');
                }
              }
              catch(err) {
              }
        }
        else {
            return false;
        }

    }

});


function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
		results = results == null ? "-" : results;
    if (!results) return '-';
    if (!results[2]) return '-';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function validateEmail($email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test($email);
}

function validateName($name) {
    var namereg = /^[a-zA-Z\s]+$/;
    return namereg.test($name);
}


var count = 0;
function blink(elem, times, speed) {
    count++;
    if (times > 0 || times < 0) {
        if ($(elem).hasClass("blink"))
            $(elem).removeClass("blink");
        else
            $(elem).addClass("blink");
    }

    clearTimeout(function () {
        blink(elem, times, speed);
    });

    if (times > 0 || times < 0) {
        setTimeout(function () {
            blink(elem, times, speed);
        }, speed);
        times -= .5;
    }
    if (count == times) {
        $(elem).addClass("blink");
    }
}



// var url = window.location.href;
// var vrcontano = "";

// if (url.indexOf('/c/') > -1) {
    // vrcontano = "tel:02066669914";
// }
// else if (url.indexOf('/d/') > -1) {
    // vrcontano = "tel:02066669925";
// }
// else if (url.indexOf('/e/') > -1) {
    // vrcontano = "tel:02066669766";
// }
// else if (url.indexOf('/f/') > -1) {
    // vrcontano = "tel:02066669906";
// }
// else if (url.indexOf('/g/') > -1) {
    // vrcontano = "tel:02066669905";
// }
// else if (url.indexOf('/gg/') > -1) {
    // vrcontano = "tel:02066669905";
// }
// else if (url.indexOf('/i/') > -1) {
    // vrcontano = "tel:02066669923";
// }
// else if (url.indexOf('/ns/') > -1) {
    // vrcontano = "tel:02066669904";
// }
// else if (url.indexOf('/nt/') > -1) {
    // vrcontano = "tel:02066669903";
// }
// else if (url.indexOf('/o/') > -1) {
    // vrcontano = "tel:02066669915";
// }
// else if (url.indexOf('/q/') > -1) {
    // vrcontano = "tel:02066669921";
// }
// else if (url.indexOf('/s/') > -1) {
    // vrcontano = "tel:02066669916";
// }
// else if (url.indexOf('/sm/') > -1) {
    // vrcontano = "tel:02066669780";
// }
// else if (url.indexOf('/t/') > -1) {
    // vrcontano = "tel:02066669907";
// }
// else if (url.indexOf('/ts/') > -1) {
    // vrcontano = "tel:02066669920";
// }
// else if (url.indexOf('/v/') > -1) {
    // vrcontano = "tel:02066669918";
// }
// else if (url.indexOf('/y/') > -1) {
    // vrcontano = "tel:02066669917";
// }
  // else if (url.indexOf('/test/') > -1) {
    // vrcontano = "tel:02066669905";
// }

// $("#myModalcss").children("div").children("div").find("a").attr("href", vrcontano);





