<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinaldeLinea.aspx.cs" Inherits="FireBaseTesting.Temporizadores.FinaldeLinea" %>

<%@ Register Src="~/Temporizadores/Controles/DataOP2.ascx" TagPrefix="uc1" TagName="DataOP2" %>

<!DOCTYPE html>
<html>

<head>
    <title>Final de Línea</title>
     <%--NECESARIOS PARA EJECUTAR AJAX,  JSON--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="js/sweetalert-dev.js"></script>
	<script src="js/DataOPv5.js"></script>

     <%--NECESARIOS PARA DISEÑO---%>
   
    <link href="css/sweetalert.css" rel="stylesheet" />
    <style>
        * {
            box-sizing: border-box;
        }

        .wrapper {
            perspective: 800px;
        }

        .btn {
            position: relative;
            height: 200px;
            width: 100%;
            transform-style: preserve-3d;
            transition: transform 300ms ease-in-out;
            transform: translateZ(-75px);
        }

        .btn:hover {
            transform: rotateX(-90deg) translateY(75px);
        }

        .side {
            position: absolute;
            backface-visibility: hidden;
            width: 100%;
            height: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 4em;
            font-weight: bold;
        }

        .default-side {
            background-color: white;
            border: 10px solid #069;
            color: #069;
            transform: translateZ(75px);
        }

        .hover-side {
            color: white;
            background-color: #069;
            transform: rotateX(90deg) translateZ(95px);
        }

        /* Background Styles Only */

        @import url("https://fonts.googleapis.com/css?family=Raleway");

        * {
            font-family: Raleway;
        }

        /*html {
            width: 100%;
            height: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #dfdfdf;
        }*/

        .side-links {
            position: absolute;
            top: 15px;
            right: 15px;
        }

        .side-link {
            display: flex;
            align-items: center;
            justify-content: center;
            text-decoration: none;
            margin-bottom: 10px;
            color: white;
            width: 180px;
            padding: 10px 0;
            border-radius: 10px;
        }

        .side-link-icon {
            color: white;
            font-size: 30px;
        }

    </style>
    <link href="css/demo.css" rel="stylesheet" />
</head>

<body  onload="document.getElementById('btnStart').click();">
   <%-- Audios/Inicio.mp3--%>
     <div style="display:none;">
		<input type="text"  id="txtL"/>
		<input type="text"  id="txtL1"/>
		<input type="text"  id="txtL2"/>
		<input type="text"  id="txtL3"/>
	 </div>
					
<%--    <div class="wrapper">--%>
       
        <table style="width:100%;">
            <tr>

                <td style="width:65%;height:200px;text-align:center;">
                   <div class="box2">
		                <select id="SelectGrupo" onchange="OPMonitoreadaSiguientesUpdates();">
		                    <option value="L1L2L3">Grupo L1L2L3</option>
		                    <option value="L4L5L6">Grupo L4L5L6</option>
		                    <option value="L7L8L9">Grupo L7L8L9</option>			
		                    </select>
	                 </div>
                    <div class="btn" id="divL1">
                        <div class="side default-side" style="font-size:90px;width:100%;color:black; ">
                             <h3><strong id="spanEstatusL1"></strong> </h3>
                             
                        </div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">
                             <div id="tooltipL1" style="color:white;" ></div>
                        </div>

                    </div>
                    
                </td>

                <td rowspan="3" style="text-align: right;">
                    <uc1:DataOP2 runat="server" ID="DataOP2" />
                    <h3 style="color:#207529; text-align:left; font-size:12px;" id="messageUpdateData"></h3>

                </td>

            </tr>
            <tr>
                <td style="width: 65%;height: 200px; text-align: center;">
                    <div class="btn" id="divL2">
                        <div class="side default-side" style="font-size:90px;width:100%;color:black; ">
                            <h3><strong id="spanEstatusL2"></strong> </h3>
                            
                        </div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">
                           <div id="tooltipL2" style="color:white;"></div>
                        </div>

                    </div>
                   
                </td>
            </tr>

            <tr>
                <td style="width: 65%; height: 200px; text-align: center;">
                    <div class="btn" id="divL3" >
                        <div class="side default-side" id="divDefaultL3" style="font-size:90px;width:100%;color:black; ">
                            <h3><strong id="spanEstatusL3"></strong> </h3>                            
                        </div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">
                            <div id="tooltipL3" style="color:white;"></div>
                        </div>
                    </div>
                </td>
            </tr>

        </table>

    <%--</div>--%>
    <div style="display:none;">
            <input id="Submit1" type="submit" value="submit"  onclick="MovimientosMesas();"/>
            <input id="Submit2" type="submit" value="submit"  onclick="MovimientosMesas2();"/>
    </div>

    <button id="btnStart" onclick="document.getElementById('id01').style.display='block'" style="display:none;">Open Modal</button>

    <div id="id01" class="modal">
      <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">×</span>
      <form class="modal-content">
        <div class="container">
          <h1 style="color:#207529; font-size:90px; "><strong>¡Bienvenido!</strong> </h1>
          <p style="font-size:30px;">Damos inicio a la consola de <strong>Final de Línea</strong> , en este momento usted podrá visualizar en tiempo real el comportamiento de la Orden de Producción que  esté ejecutándose, presione el botón  “OK” para  dar inicio al proceso correctamente</p>
    
          <div class="clearfix">
            <button id="bt1AudioInicio" onclick="playAudio(); EjecutarAll(); document.getElementById('id01').style.display='none';" type="button" style="width:200px; ">OK</button>
            <button onclick="pauseAudio()" type="button" style="display:none;">Pause Audio</button> 
          </div>
        </div>
      </form>
    </div>

    <div style="display:none;">
         <audio id="myAudio">
          <source src="Audios/Inicio.mp3" type="audio/ogg">
          <source src="Audios/Inicio.mp3" type="audio/mpeg">
          Your browser does not support the audio element.
        </audio>
        <audio id="myAudio2">
          <source src="Audios/Parada.mp3" type="audio/ogg">
          <source src="Audios/Parada.mp3" type="audio/mpeg">
          Your browser does not support the audio element.
        </audio>      
        <audio id="myAudio3">
          <source src="Audios/Envasando.mp3" type="audio/ogg">
          <source src="Audios/Envasando.mp3" type="audio/mpeg">
          Your browser does not support the audio element.
        </audio>    
         <audio id="myAudio4">
          <source src="Audios/Lavando.mp3" type="audio/ogg">
          <source src="Audios/Lavando.mp3" type="audio/mpeg">
          Your browser does not support the audio element.
        </audio>   
         <audio id="myAudio5">
          <source src="Audios/Terminada.mp3" type="audio/ogg">
          <source src="Audios/Terminada.mp3" type="audio/mpeg">
          Your browser does not support the audio element.
        </audio>   
    </div>
    
<script>
    var x = document.getElementById("myAudio");
    x.play();
    document.getElementById('bt1AudioInicio').click();
    function playAudio() {
        x.play();
    }

    function pauseAudio() {
        x.pause();
    } 
</script>
<script>
    function EjecutarAll() {
        OPMonitoreada();
        setInterval(function () { OPMonitoreadaSiguientesUpdates(); }, 7000);
        setInterval(function () { document.getElementById('Submit1').click(); }, 2000);
        setInterval(function () { document.getElementById('Submit2').click(); }, 3000);
    }
  

    function MovimientosMesas() {
        
        if (document.getElementById('spanEstatusL3').innerHTML == "ESTADO:Detenida" || document.getElementById('spanEstatusL3').innerHTML == "ESTADO:Lavando")
            document.getElementById('divL3').style.transform = "rotateX(-90deg) translateY(75px)";

        if (document.getElementById('spanEstatusL2').innerHTML == "ESTADO:Detenida" || document.getElementById('spanEstatusL2').innerHTML == "ESTADO:Lavando")
            document.getElementById('divL2').style.transform = "rotateX(-90deg) translateY(75px)";

        if (document.getElementById('spanEstatusL1').innerHTML == "ESTADO:Detenida" || document.getElementById('spanEstatusL1').innerHTML == "ESTADO:Lavando")
            document.getElementById('divL1').style.transform = "rotateX(-90deg) translateY(75px)";
    }
    function MovimientosMesas2() {

        //document.getElementById('divDefaultL3').style.display = "side hover-side";
        document.getElementById('divL3').style.transform = "";
        document.getElementById('divL1').style.transform = "";
        document.getElementById('divL2').style.transform = "";
    }

</script>
<script>

    var endL1;
    var _secondL1 = 1000;
    var _minuteL1 = _secondL1 * 60;
    var _hourL1 = _minuteL1 * 60;
    var _dayL1 = _hourL1 * 24;
    var timerL1;
    var MinParadaL1;
    function ShowTimerL1(date_) {

        endL1 = new Date(date_);
        _secondL1 = 1000;
        _minuteL1 = _secondL1 * 60;
        _hourL1 = _minuteL1 * 60;
        _dayL1 = _hourL1 * 24;

        timerL1 = setInterval(showRemainingL1, 1000);

    }

    function showRemainingL1() {
        var nowL1 = new Date();
        //alert(endL1 + ":" + nowL1);
        var distanceL1 = endL1 - nowL1;
        if (distanceL1 < 0) {

            if (MinParadaL1 != 0) {
                IniciarLineaDespuesdeTimerFinaldeLinea(1);
                MinParadaL1 = 0;
            }
               

            document.getElementById('tooltipL1').innerHTML = "";
            window.clearInterval(timerL1);

            return;
        }
        var daysL1 = Math.floor(distanceL1 / _dayL1);
        var hoursL1 = Math.floor((distanceL1 % _dayL1) / _hourL1);
        var minutesL1 = Math.floor((distanceL1 % _hourL1) / _minuteL1);
        var secondsL1 = Math.floor((distanceL1 % _minuteL1) / _secondL1);
       

        var PorcenBar = (minutesL1 * 100) / MinParadaL1;
        // var PorcenBarRegreso = 100 - PorcenBar;
        //Bar.setAttribute("aria-valuenow", parseInt(PorcenBar));
        if (MinParadaL1 == 0)
            document.getElementById('tooltipL1').innerHTML = "";
        else
        document.getElementById('tooltipL1').innerHTML = daysL1 + ":" + hoursL1 + ":" + minutesL1 + ":" + secondsL1;
    }

</script>

<script>

    var end;
    var _second = 1000;
    var _minute = _second * 60;
    var _hour = _minute * 60;
    var _day = _hour * 24;
    var timer;
    var MinParadaL2;
    function ShowTimerL2(date_) {

        end = new Date(date_);
        _second = 1000;
        _minute = _second * 60;
        _hour = _minute * 60;
        _day = _hour * 24;

        timer = setInterval(showRemainingL2, 1000);

    }

    function showRemainingL2() {
        var now = new Date();
        var distance = end - now;
        if (distance < 0) {

            if (MinParadaL2 != 0) {
                IniciarLineaDespuesdeTimerFinaldeLinea(2);
                MinParadaL2 = 0;
            }
               

            clearInterval(timer);
            document.getElementById('tooltipL2').innerHTML = "";

            return;
        }
        var days = Math.floor(distance / _day);
        var hours = Math.floor((distance % _day) / _hour);
        var minutes = Math.floor((distance % _hour) / _minute);
        var seconds = Math.floor((distance % _minute) / _second);


        var PorcenBarL2 = (minutes * 100) / MinParadaL2;
        // var PorcenBarRegreso = 100 - PorcenBar;
        //Bar2.setAttribute("aria-valuenow", parseInt(PorcenBarL2));
        if (MinParadaL2 == 0)
            document.getElementById('tooltipL2').innerHTML = "";
        else
            document.getElementById('tooltipL2').innerHTML =  days + ":" + hours + ":" + minutes + ":" + seconds;
    }

    </script>


    <script>
        var timerL3;
        var endL3;
        var _secondL3;
        var _minuteL3;
        var _hourL3;
        var _dayL3;
        var distanceInicialL3;
        var MinParadaL3;
        function ShowTimerL3(date_) {

            endL3 = new Date(date_);
            _secondL3 = 1000;
            _minuteL3 = _secondL3 * 60;
            _hourL3 = _minuteL3 * 60;
            _dayL3 = _hourL3 * 24;

            timerL3 = setInterval(showRemainingL3, 1000);
        }

        function showRemainingL3() {

            var nowL3 = new Date();
            var distanceL3 = endL3 - nowL3;



            if (distanceL3 < 0) {

                if (MinParadaL3 != 0) {
                    IniciarLineaDespuesdeTimerFinaldeLinea(3);
                    MinParadaL3 = 0;
                }
                    

                document.getElementById('tooltipL3').innerHTML = "";
                window.clearInterval(timerL3);
                return;
            }
            var daysL3 = Math.floor(distanceL3 / _dayL3);
            var hoursL3 = Math.floor((distanceL3 % _dayL3) / _hourL3);
            var minutesL3 = Math.floor((distanceL3 % _hourL3) / _minuteL3);
            var secondsL3 = Math.floor((distanceL3 % _minuteL3) / _secondL3);

            var PorcenBar = (minutesL3 * 100) / MinParadaL3;
            // var PorcenBarRegreso = 100 - PorcenBar;
            //  Bar3.setAttribute("aria-valuenow", parseInt(PorcenBar));
            if (MinParadaL3 == 0)
                document.getElementById('tooltipL3').innerHTML = "";
            else
            document.getElementById('tooltipL3').innerHTML =  daysL3 + ":" + hoursL3 + ":" + minutesL3 + ":" + secondsL3;
            // alert(PorcenBarRegreso);



        }



    </script>
   <style>
       body {font-family: Arial, Helvetica, sans-serif;}
            * {box-sizing: border-box;}

            /* Set a style for all buttons */
            button {
              background-color: #4CAF50;
              color: white;
              padding: 14px 20px;
              margin: 8px 0;
              border: none;
              cursor: pointer;
              width: 100%;
              opacity: 0.9;
            }

            button:hover {
              opacity:1;
            }

            /* Float cancel and delete buttons and add an equal width */
            .cancelbtn, .deletebtn {
              float: left;
              width: 50%;
            }

            /* Add a color to the cancel button */
            .cancelbtn {
              background-color: #ccc;
              color: black;
            }

            /* Add a color to the delete button */
            .deletebtn {
              background-color: #f44336;
            }

            /* Add padding and center-align text to the container */
            .container {
              padding: 16px;
              text-align: center;
            }

            /* The Modal (background) */
            .modal {
              display: none; /* Hidden by default */
              position: fixed; /* Stay in place */
              z-index: 1; /* Sit on top */
              left: 0;
              top: 0;
              width: 100%; /* Full width */
              height: 100%; /* Full height */
              overflow: auto; /* Enable scroll if needed */
              background-color: rgba(238, 42, 28, 0.69);
              padding-top: 50px;
            }

            /* Modal Content/Box */
            .modal-content {
              background-color: #fefefe;
              margin: 5% auto 15% auto; /* 5% from the top, 15% from the bottom and centered */
              border: 1px solid #888;
              width: 50%; /* Could be more or less, depending on screen size */
            }

            /* Style the horizontal ruler */
            hr {
              border: 1px solid #f1f1f1;
              margin-bottom: 25px;
            }
 
            /* The Modal Close Button (x) */
            .close {
              position: absolute;
              right: 35px;
              top: 15px;
              font-size: 40px;
              font-weight: bold;
              color: #f1f1f1;
            }

            .close:hover,
            .close:focus {
              color: #f44336;
              cursor: pointer;
            }

            /* Clear floats */
            .clearfix::after {
              content: "";
              clear: both;
              display: table;
            }

            /* Change styles for cancel button and delete button on extra small screens */
            @media screen and (max-width: 300px) {
              .cancelbtn, .deletebtn {
                 width: 100%;
              }
            }
</style>
<script>
    // Get the modal
    var modal = document.getElementById('id01');

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
</script>

</body>

</html>
