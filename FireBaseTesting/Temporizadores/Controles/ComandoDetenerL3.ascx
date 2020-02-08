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
<div class="container"> 
    <table style="width:100%;text-align:left;">        
        
        <tr>
            <td colspan="2">
               <input class="btn" type="button" id="Parada1L3" value="Parada Mínima" onclick="ParadaLineasdeProduccion(30);" style="background-color:#ed4109; color:#ffffff;  font-size:20px;border-radius:10px;width:290px; height:60px;">
                <input class="btn" type="button" id="ReinicioParada1L3" value="Reiniciar con Parada Mínima" onclick="EjecutarReinicioDeParada(30);" style="background-color: #226062;
                        color: #ffffff;
                        font-size: 20px;
                        border-radius: 10px;
                        width: 300px;
                        height: 60px;
                        display: none;">
            </td>
            <td>
                 <input class="btn" type="button" value="ReIniciar" onclick="IniciarLinea();" style="background-color: #058616;
                            color: #ffffff;
                            font-size: 20px;
                            border-radius: 10px;
                            width: 210px;
                            height: 60px;">
            </td>
        </tr>
        <tr>
            <td>
              <input class="btn" type="button" id="Parada2L3" value="Pararada Media" onclick="ParadaLineasdeProduccion(45);" style="background-color: #ed4109;
					        color: #ffffff;
					        font-size: 20px;
					        border-radius: 10px;
					        width: 290px;
					        height: 60px;">

                <input class="btn" type="button" id="ReinicioParada2L3" value="Reinicio con Pararada Media" onclick="EjecutarReinicioDeParada(45);" style="background-color: #226062;
					        color: #ffffff;
					        font-size: 20px;
					        border-radius: 10px;
					        width: 300px;
					        height: 60px;
                            display:none;">
            </td>
            <td>
               
            </td>
        </tr>
        <tr>
            <td>
                <input class="btn" type="button" id="Parada3L3" value="Pararada por Mantenimiento" onclick="ParadaLineasdeProduccion(60);" style="background-color: #ed4109;
                        color: #ffffff;
                        font-size: 20px;
                        border-radius: 10px;
                        width: 290px;
                        height: 60px;">
                    <input class="btn" type="button" id="ReinicioParada3L3" value="Reinicio con Mantenimiento" onclick="EjecutarReinicioDeParada(60);" style="                            background-color: #226062;
                            color: #ffffff;
                            font-size: 20px;
                            border-radius: 10px;
                            width: 300px;
                            height: 60px;
                            display: none;">
                
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
            <td colspan="2">
                <br />
                <br />
                 <div id="countdownL3" style="font-size: 20px;"></div>
            </td>
        </tr>
    </table>

</div>

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
            
            IniciarLineaDespuesdeTimer(3);
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

        document.getElementById('countdownL3').innerHTML = ' La parada termina en: <br/>';
        document.getElementById('countdownL3').innerHTML += daysL3 + ' dia(s), ';
        document.getElementById('countdownL3').innerHTML += hoursL3 + ' hora(s), ';
        document.getElementById('countdownL3').innerHTML += minutesL3 + ' minuto(s) y ';
        document.getElementById('countdownL3').innerHTML += secondsL3 + ' segundo(s) ';

        var PorcenBar = (minutesL3  * 100) / MinParadaL3;
       // var PorcenBarRegreso = 100 - PorcenBar;
        Bar3.setAttribute("aria-valuenow", parseInt(PorcenBar));
        document.getElementById('tooltipL3').innerHTML = daysL3 + ":" + hoursL3 + ":" + minutesL3 +":"+ secondsL3;
       // alert(PorcenBarRegreso);

        
        
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
    function ShowTimerLavandoL3(date_) {

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

             // Finalizar aquí cuando termine el tiempo de lavado
            FinalizarOP();
            window.clearInterval(timerL3);
            document.getElementById('countdownL3').innerHTML = '';

            return;
        }
        var daysL3 = Math.floor(distanceL3 / _dayL3);
        var hoursL3 = Math.floor((distanceL3 % _dayL3) / _hourL3);
        var minutesL3 = Math.floor((distanceL3 % _hourL3) / _minuteL3);
        var secondsL3 = Math.floor((distanceL3 % _minuteL3) / _secondL3);

        document.getElementById('countdownL3').innerHTML = ' La parada termina en: <br/>';
        document.getElementById('countdownL3').innerHTML += daysL3 + ' dia(s), ';
        document.getElementById('countdownL3').innerHTML += hoursL3 + ' hora(s), ';
        document.getElementById('countdownL3').innerHTML += minutesL3 + ' minuto(s) y ';
        document.getElementById('countdownL3').innerHTML += secondsL3 + ' segundo(s) ';

        var PorcenBar = (minutesL3 * 100) / MinParadaL3;
        // var PorcenBarRegreso = 100 - PorcenBar;
        Bar3.setAttribute("aria-valuenow", parseInt(PorcenBar));
        document.getElementById('tooltipL3').innerHTML = daysL3 + ":" + hoursL3 + ":" + minutesL3 + ":" + secondsL3;
        // alert(PorcenBarRegreso);



    }



    </script>