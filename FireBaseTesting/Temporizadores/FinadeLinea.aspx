<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinadeLinea.aspx.cs" Inherits="FireBaseTesting.Temporizadores.FinadeLinea" %>

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
	<script src="js/DataOPv3.js"></script>

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
            transform: rotateX(90deg) translateZ(75px);
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

        .side-link-youtube {
            background-color: red;
        }

        .side-link-twitter {
            background-color: #1da1f2;
        }

        .side-link-github {
            background-color: #6e5494;
        }

        .side-link-text {
            margin-left: 10px;
            font-size: 18px;
        }

        .side-link-icon {
            color: white;
            font-size: 30px;
        }

    </style>
</head>

<body>
    
    <div class="wrapper">
        <table style="width:100%;">
            <tr>

                <td style="width:65%;height:250px;text-align:center;">
                    <div class="btn">
                        <div class="side default-side" style="font-size:120px;width:100%;color:black; ">
                             <h3><strong id="spanEstatusL1"></strong> </h3>
                              <div id="tooltipL1" style="font-size:45px;"></div>
                        </div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">00:00:000</div>

                    </div>
                    <br />
                </td>

                <td rowspan="3" style="text-align: right;">

                    <uc1:DataOP2 runat="server" ID="DataOP2" />
                    <h3 style="color:#207529; text-align:left; font-size:12px;" id="messageUpdateData"></h3>


                </td>

            </tr>
            <tr>
                <td style="width: 65%;height: 200px; text-align: center;">
                    <div class="btn">
                        <div class="side default-side" style="font-size:120px;width:100%;color:black; ">
                            <h3><strong id="spanEstatusL2"></strong> </h3>
                            <div id="tooltipL2" style="font-size:45px;"></div>
                        </div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">
                            1:0:22:00
                            <p>Parada</p>
                        </div>

                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 65%;height: 200px;text-align: center;">
                    <div class="btn">
                        <div class="side default-side" style="font-size:120px;width:100%;color:black; ">
                            <h3><strong id="spanEstatusL3"></strong> </h3>
                            <div id="tooltipL3" style="font-size:45px;"></div>
                        </div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">1:0:22:00</div>
                    </div>
                </td>
            </tr>

        </table>

    </div>

<script>

    OPMonitoreada();
    setInterval(function () { OPMonitoreada(); }, 9000);

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

                document.getElementById('tooltipL3').innerHTML = "";
                window.clearInterval(timerL3);
                //var myVar = setTimeout(location.reload(), 45000);
                //clearInterval(timer3);
                //document.getElementById('countdownL3').innerHTML = '';

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
   
</body>

</html>
