<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComandoDetenerL3.ascx.cs" Inherits="FireBaseTesting.Temporizadores.Controles.ComandoDetenerL3" %>

<style>
    body {
  font-family: "Roboto", sans-serif;
}
.btn {
  border: none;
  color: black;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  transition: 0.5s;
}
.btn:hover {
  background-color: #008cba;
}
#time {
  font-size: 5em;
}
h1 {
  font-size: 4em;
}
.container {
  margin: auto;
  text-align: center;
  line-height: 1.5;
}
p {
  margin-top: 10px;
}
@media screen and (max-width: 420px) {
  img {
    width: 50%;
  }
  #time {
    font-size: 3em;
  }
  h1 {
    font-size: 2.5em;
  }
  .btn {
    padding: 10px 21.33333px;
  }
}

</style>
<br />
<br />
<br />
<br />
<div class="container"> 
    <table style="width:100%;text-align:left;">
         
        <tr>
            <td colspan="2">
                <div><h3 style="font-size:30px;">Establecer parada de la Línea 1</h3><span id="time"></span></div>
            </td>
        </tr>
        <tr>

            <td>
                <select id="SelectParadasL3" class="select-css" style="width:100%;">
                    <option value="30">Parada Minima</option>
                    <option value="45">Parada Media</option>
                    <option value="60">Parada por mantenimiento</option>
                </select>
            </td>
            <td>
                   
	                <input class="btn" type="button" value="Start" onclick="IniciarLinea();" style="background-color:#058616;color:#ffffff">
	                <input class="btn" type="button" value="Stop" onclick="EjecutarParadaL3();" style="background-color:#ff0000; color:#ffffff;">
	                <input class="btn" type="button" value="Reset" onclick="reset()" style="background-color:#ffd800">
           
            </td>

        </tr>
        <tr>
            <td colspan="2">
                <div id="countdownL3"></div>
            </td>
        </tr>
    </table>
</div>


<script>
        var endL3 = new Date('01/29/2020 5:31 PM');
        var _secondL3 = 1000;
        var _minuteL3 = _secondL3 * 60;
        var _hourL3 = _minuteL3 * 60;
        var _dayL3 = _hourL3 * 24;
        var timerL3;

        function showRemainingL3() {
            var nowL3 = new Date();
            var distanceL3 = endL3 - nowL3;
            if (distanceL3 < 0) {

                clearInterval(timer3);
                document.getElementById('countdownL3').innerHTML = 'No hay una parada actualmente!';

                return;
            }
            var daysL3 = Math.floor(distanceL3 / _dayL3);
            var hoursL3 = Math.floor((distanceL3 % _dayL3) / _hourL3);
            var minutesL3 = Math.floor((distanceL3 % _hourL3) / _minuteL3);
            var secondsL3 = Math.floor((distanceL3 % _minuteL3) / _secondL3);

            document.getElementById('countdownL3').innerHTML = daysL3 + ' dias, ';
            document.getElementById('countdownL3').innerHTML += hoursL3 + ' horas, ';
            document.getElementById('countdownL3').innerHTML += minutesL3 + ' minutos y ';
            document.getElementById('countdownL3').innerHTML += secondsL3 + ' segundos';
        }

        timerL3 = setInterval(showRemainingL3, 1000);

    </script>