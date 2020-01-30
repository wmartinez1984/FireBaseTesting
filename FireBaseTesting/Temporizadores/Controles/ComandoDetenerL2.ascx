<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComandoDetenerL2.ascx.cs" Inherits="FireBaseTesting.Temporizadores.Controles.ComandoDetenerL2" %>

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
                <div><h3 style="font-size:30px;">Establecer parada de la Línea 2</h3><span id="time"></span></div>
            </td>
        </tr>
        <tr>

            <td>
                <select id="SelectParadasL2" class="select-css" style="width:100%;">
                    <option value="30">Parada Minima</option>
                    <option value="45">Parada Media</option>
                    <option value="60">Parada por mantenimiento</option>
                </select>

            </td>
            <td>
                   
	                <input class="btn" type="button" value="Start" onclick="IniciarLinea();" style="background-color:#058616;color:#ffffff">
	                <input class="btn" type="button" value="Stop" onclick="EjecutarParadaL2();" style="background-color:#ff0000; color:#ffffff;">
	                <input class="btn" type="button" value="Reset" onclick="reset()" style="background-color:#ffd800">
           
            </td>

        </tr>
        <tr>
            <td colspan="2">
                <div id="countdownL2"></div>
            </td>
        </tr>
    </table>
</div>


<script>
        var end = new Date('01/29/2022 6:59 PM');
        var _second = 1000;
        var _minute = _second * 60;
        var _hour = _minute * 60;
        var _day = _hour * 24;
        var timer;

        function showRemainingL2() {
            var now = new Date();
            var distance = end - now;
            if (distance < 0) {

                clearInterval(timer);
                document.getElementById('countdownL2').innerHTML = 'No hay una parada actualmente!';

                return;
            }
            var days = Math.floor(distance / _day);
            var hours = Math.floor((distance % _day) / _hour);
            var minutes = Math.floor((distance % _hour) / _minute);
            var seconds = Math.floor((distance % _minute) / _second);

            document.getElementById('countdownL2').innerHTML = days + ' dias, ';
            document.getElementById('countdownL2').innerHTML += hours + ' horas, ';
            document.getElementById('countdownL2').innerHTML += minutes + ' minutos y ';
            document.getElementById('countdownL2').innerHTML += seconds + ' segundos';
        }

    timer = setInterval(showRemainingL2, 1000);

    </script>