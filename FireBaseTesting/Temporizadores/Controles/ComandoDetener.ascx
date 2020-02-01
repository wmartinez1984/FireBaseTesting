<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComandoDetener.ascx.cs" Inherits="FireBaseTesting.Temporizadores.Controles.ComandoDetener" %>

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
<div class="container"> 
    <table style="width:100%;text-align:left;">        
        
        <tr>
            <td colspan="2">
                <input class="btn" type="button" value="Iniciar" onclick="IniciarLinea();" style="background-color:#058616;color:#ffffff; font-size:40px;border-radius:10px;width:350px; height:110px;">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <input class="btn" type="button" value="Parada" onclick="OpenModalNew(1);" style="background-color:#ff0000; color:#ffffff;  font-size:40px;border-radius:10px; width:350px; height:110px;">
                <br />
            </td>
            <td>
               
            </td>
        </tr>
        <tr>

            <td>
                 <input class="btn" type="button" value="Reiniciar Parada" onclick="OpenModalNew2();" style="background-color:#ffd800; font-size:40px;border-radius:10px; width:350px; height:110px;">                
            </td>
            <td>                     
	            
            </td>

        </tr>
        <tr>
            <td colspan="2">
                 <div id="countdownL1" style="font-size:30px;"></div>
            </td>
        </tr>
    </table>
</div>


<script>
        var endL1 = new Date('01/29/2019 5:31 PM');
        var _secondL1 = 1000;
        var _minuteL1 = _secondL1 * 60;
        var _hourL1 = _minuteL1 * 60;
        var _dayL1 = _hourL1 * 24;
        var timerL1;

        function showRemainingL1() {
            var nowL1 = new Date();
            var distanceL1 = endL1 - nowL1;
            if (distanceL1 < 0) {

                clearInterval(timerL1);
                document.getElementById('countdownL1').innerHTML = '';

                return;
            }
            var daysL1 = Math.floor(distanceL1 / _dayL1);
            var hoursL1 = Math.floor((distanceL1 % _dayL1) / _hourL1);
            var minutesL1 = Math.floor((distanceL1 % _hourL1) / _minuteL1);
            var secondsL1 = Math.floor((distanceL1 % _minuteL1) / _secondL1);

            document.getElementById('countdownL1').innerHTML = daysL1 + ' dias, ';
            document.getElementById('countdownL1').innerHTML += hoursL1 + ' horas, ';
            document.getElementById('countdownL1').innerHTML += minutesL1 + ' minutos y ';
            document.getElementById('countdownL1').innerHTML += secondsL1 + ' segundos';
        }

        timerL1 = setInterval(showRemainingL1, 1000);

    </script>