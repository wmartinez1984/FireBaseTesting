<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CopiaEndLine.aspx.cs" Inherits="FireBaseTesting.Temporizadores.CopiaEndLine" %>

<%@ Register Src="~/Temporizadores/Controles/DataOP.ascx" TagPrefix="uc1" TagName="DataOP" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Monitor</title>
    <%--NECESARIOS PARA EJECUTAR AJAX,  JSON--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="js/sweetalert-dev.js"></script>
	<script src="js/DataOPv3.js"></script>

     <%--NECESARIOS PARA DISEÑO---%>
    <link href="styleMonitor.css" rel="stylesheet" />
    <link href="css/sweetalert.css" rel="stylesheet" />
</head>
<body style="">



 <div class="cards">    
    
    <table style="width:100%;margin-top:-24px; background-image:url('Images/gif.gif')" class="table" >        
        <tr>

            <td style="width:65%;height:200px;text-align:center;">
                <span style="font-size:25px;color:#0b220e"> <strong>Mesa de producción 1</strong> </span>
                <h3 style="color:white;font-size:25px; color:#207529; "><strong id="spanEstatusL1"></strong> </h3>
                <div id="tooltipL1" style="font-size:45px; color:#ff6a00; "></div>
            </td>

            <td rowspan="3" style="text-align: right;
                    background-color: #E5E8EF;
                    border-left: 10px;
                    border-left-color: #359840;
                    border-left-width: 10px;
                    border-left-style: dashed;">
                   <a href="login.aspx">
                       <uc1:DataOP runat="server" ID="DataOP"  />
                   </a>
                   <h3 style="color:#207529; text-align:left; font-size:12px;" id="messageUpdateData">...</h3>
              
                
            </td>

        </tr>
        <tr>
            <td style="width: 65%;height: 200px;
                    text-align: center;">
                <span style="font-size:25px;color:#0b220e"> <strong>Mesa de producción 2</strong> </span>
                <h3 style="color:white;font-size:25px;color:#207529"><strong id="spanEstatusL2"></strong> </h3>
                <div id="tooltipL2" style="font-size:45px; color:#ff6a00; "></div>
            </td>
        </tr>
         <tr>
            <td style="width: 65%;height: 200px;text-align: center;">
                <span style="font-size:30px;color:#0b220e"> <strong>Mesa de producción 3</strong> </span>
                <h3 style="color:white;font-size:25px;color:#207529; "><strong id="spanEstatusL3"></strong> </h3>
                 <div id="tooltipL3" style="font-size:45px; color:#ff6a00; "></div>
            </td>
        </tr>

    </table>

  </div>
    
    <style>
        table {
            border-collapse: separate;
            border-spacing: 15px;
        }
        .table td:hover {
              background-color: #808080;
        }
        .table td {
            background-color:#E5E8EF;
        }

        .table td {
            cursor:pointer;
        }
        
    </style>
  
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
