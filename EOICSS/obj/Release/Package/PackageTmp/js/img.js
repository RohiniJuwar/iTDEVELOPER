/*$(document).ready(function(){
	$("#crew-content").html('<img src="img/Image 1.png" alt="Header Image" width="500px" />');

	$(window).resize(function(e){
   if($(window).width() < 700) {

	$("#crew-content").html('<img src="img/01.png" alt="Header Image" width="500px" />');

            } else if ($(window).width() >= 700) {
				$("#crew-content").html('<img src="img/Image 1.png" alt="Header Image" width="500px" />');
    }         
});
});
	*/

  
   var ua = navigator.userAgent;
   var checker = {
       iphone: ua.match(/iPhone/),
       blackberry: ua.match(/BlackBerry/),
       android: ua.match(/Android/),
       ipad: ua.match(/(iPod|iPad)/)
   };


setTimeout(function(){
   if (checker.android || checker.iphone || checker.blackberry || checker.ipad ) {
      $("#crew-content").html('<img src="../../img/min/Rohan-Viti-Creative1m.webp" alt="Rohan Viti Creative1" class=" img-fluid" />');
      $("#crew-content1").html('<img src="../../img/min/Rohan-Viti-Project1m.webp" class="d-block w-100" alt="Rohan Viti Project Image1" />');
      $("#crew-content3").html('<img src="../../img/min/Rohan-Viti-Project3m.webp" class="d-block w-100" alt="Rohan Viti Project Image3" />');
      $("#crew-content4").html('<img src="../../img/min/Rohan-Viti-Project4m.webp" class="d-block w-100" alt="Rohan Viti Project Image4" />');
      $("#crew-content5").html('<img src="../../img/min/Rohan-Viti-Project5m.webp" class="d-block w-100" alt="Rohan Viti Project Image5" />');
      $("#crew-content6").html('<img src="../../img/min/Rohan-Viti-Project6m.webp" class="d-block w-100" alt="Rohan Viti Project Image6" />');
      $("#crew-content7").html('<img src="../../img/min/old-Rohan-Viti-Master-Plan-m.webp" alt="Rohan Viti Master Plan" class="img-fluid " />');
      $("#crew-content8").html('<img  id="main-img" height="" src="../../img/min/Rohan-Viti-Location-Map-m.webp" class="img-fluid " alt="Rohan Viti Location Map"/>');

   }
   else {
      $("#crew-content").html('<img src="../../img/Rohan-Viti-Creative1.webp"  alt="Rohan Viti Creative1" class=" img-fluid" />');
      $("#crew-content1").html('<img src="../../img/Rohan-Viti-Project1.webp" class="d-block w-100" alt="Rohan Viti Project Image1" />');
      $("#crew-content3").html('<img src="../../img/Rohan-Viti-Project3.webp" class="d-block w-100" alt="Rohan Viti Project Image3" />');
      $("#crew-content4").html('<img src="../../img/Rohan-Viti-Project4.webp" class="d-block w-100" alt="Rohan Viti Project Image4" />');
      $("#crew-content5").html('<img src="../../img/Rohan-Viti-Project5.webp" class="d-block w-100" alt="Rohan Viti Project Image5" />');
      $("#crew-content6").html('<img src="../../img/Rohan-Viti-Project6.webp" class="d-block w-100" alt="Rohan Viti Project Image6" />');
      $("#crew-content7").html('<img src="../../img/Rohan-Viti-Master-Plan.webp" alt="Rohan Viti Master Plan" class="img-fluid " />');
      $("#crew-content8").html('<img id="main-img" height="" src="../../img/Rohan-Viti-Location-Map.webp" class="img-fluid " alt="Rohan Viti Location Map"/>');
   }

},3000);


