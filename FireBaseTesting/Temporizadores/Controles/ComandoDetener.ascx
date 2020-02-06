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
    <table style="width:100%;">
			<tr>
				<td>
					<input class="btn" type="button" id="Parada1L1" value="Parada Mínima" onclick="ParadaLineasdeProduccion(30);" style="background-color:#ed4109; color:#ffffff;  font-size:20px;border-radius:10px;width:290px; height:60px;">
                    <input class="btn" type="button" id="ReinicioParada1L1" value="Reiniciar con Parada Mínima" onclick="EjecutarReinicioDeParada(30);" style="                            background-color: rgb(34, 96, 98);
                            color: #ffffff;
                            font-size: 20px;
                            border-radius: 10px;
                            width: 300px;
                            height: 60px;
                            display: none;">
				</td>
                <td style="text-align:right;">
                    <input class="btn" type="button" value="Iniciar" onclick="IniciarLinea();" style="background-color: #058616;
                            color: #ffffff;
                            font-size: 20px;
                            border-radius: 10px;
                            width: 210px;
                            height: 60px;">
                </td>
			</tr>
			<tr>
				<td>
					<input class="btn" type="button" id="Parada2L1" value="Pararada Media" onclick="ParadaLineasdeProduccion(45);" style="background-color: #ed4109;
					        color: #ffffff;
					        font-size: 20px;
					        border-radius: 10px;
					        width: 290px;
					        height: 60px;">
                    <input class="btn" type="button" id="ReinicioParada2L1" value="Reinicio con Pararada Media" onclick="EjecutarReinicioDeParada(45);" style="background-color: rgb(34, 96, 98);
                            color: #ffffff;
                            font-size: 20px;
                            border-radius: 10px;
                            width: 300px;
                            height: 60px;
                            display: none;">
				</td>
                <td style="text-align: right;">
                                
                </td>
			</tr>
			<tr>
				<td>
					<input class="btn" type="button" id="Parada3L1" value="Pararada por Mantenimiento" onclick="ParadaLineasdeProduccion(60);" style="background-color: #ed4109;
					        color: #ffffff;
					        font-size: 20px;
					        border-radius: 10px;
					        width: 290px;
					        height: 60px;">
                    <input class="btn" type="button" id="ReinicioParada3L1" value="Reinicio con Mantenimiento" onclick="EjecutarReinicioDeParada(60);" style="background-color:rgb(34, 96, 98); color:#ffffff;   font-size:20px;border-radius:10px;width:300px; height:60px;display:none;">
				</td>
                <td>

                </td>
			</tr>
		</table>
    <table style="width:100%;text-align:left;">        
        
        <tr>
            <td colspan="2">
                
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <input class="btn" type="button" value="Parada" onclick="OpenModalNew(1);" style="background-color: #ff0000;
                        color: #ffffff;
                        font-size: 20px;
                        border-radius: 10px;
                        width: 210px;
                        height: 60px;
                        display: none;">
                <br />
            </td>
            <td>
               
            </td>
        </tr>
        <tr>

            <td>
                
            </td>
            <td>                     
	            
            </td>

        </tr>
        <tr>
            <td colspan="2">
                 <div id="countdownL1" style="font-size: 20px;"></div>
            </td>
        </tr>
    </table>
</div>


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
        var distanceL1 = endL1 - nowL1;
        if (distanceL1 < 0) {

            IniciarLineaDespuesdeTimer(1);
            window.clearInterval(timerL1);

            return;
        }
        var daysL1 = Math.floor(distanceL1 / _dayL1);
        var hoursL1 = Math.floor((distanceL1 % _dayL1) / _hourL1);
        var minutesL1 = Math.floor((distanceL1 % _hourL1) / _minuteL1);
        var secondsL1 = Math.floor((distanceL1 % _minuteL1) / _secondL1);
        document.getElementById('countdownL1').innerHTML = 'La parada termina en: ';
        document.getElementById('countdownL1').innerHTML += daysL1 + ' días, ';
        document.getElementById('countdownL1').innerHTML += hoursL1 + ' horas, ';
        document.getElementById('countdownL1').innerHTML += minutesL1 + ' minutos y ';
        document.getElementById('countdownL1').innerHTML += secondsL1 + ' segundos';

        var PorcenBar = (minutesL1 * 100) / MinParadaL1;
        // var PorcenBarRegreso = 100 - PorcenBar;
        Bar.setAttribute("aria-valuenow", parseInt(PorcenBar));
        document.getElementById('tooltipL1').innerHTML = daysL1 + ":" + hoursL1 + ":" + minutesL1 + ":" + secondsL1;
    }

       

    </script>