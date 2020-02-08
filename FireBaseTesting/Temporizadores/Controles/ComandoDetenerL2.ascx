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
<div class="container"> 
    <table style="width:100%;text-align:left;">        
        
        <tr>
            <td colspan="2">
                <input class="btn" type="button" id="Parada1L2" value="Parada Mínima" onclick="ParadaLineasdeProduccion(30);" style="background-color:#ed4109; color:#ffffff;  font-size:20px;border-radius:10px;width:290px; height:60px;">
                <input class="btn" type="button" id="ReinicioParada1L2" value="Reiniciar con Parada Mínima" onclick="EjecutarReinicioDeParada(30);" style="                        background-color: #226062;
                        color: #ffffff;
                        font-size: 20px;
                        border-radius: 10px;
                        width: 300px;
                        height: 60px;
                        display: none;">

            </td>
            <td style=" text-align: right;
            ">
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
              <input class="btn" type="button" id="Parada2L2" value="Pararada Media" onclick="ParadaLineasdeProduccion(45);" style="background-color: #ed4109;
					        color: #ffffff;
					        font-size: 20px;
					        border-radius: 10px;
					        width: 290px;
					        height: 60px;">

                <input class="btn" type="button" id="ReinicioParada2L2" value="Reinicio con Pararada Media" onclick="EjecutarReinicioDeParada(45);" style="                        background-color: #226062;
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
                <input class="btn" type="button" id="Parada3L2" value="Pararada por Mantenimiento" onclick="ParadaLineasdeProduccion(60);" style="background-color: #ed4109;
					        color: #ffffff;
					        font-size: 20px;
					        border-radius: 10px;
					        width: 290px;
					        height: 60px;">
                    <input class="btn" type="button" id="ReinicioParada3L2" value="Reinicio con Mantenimiento" onclick="EjecutarReinicioDeParada(60);" style="                            background-color: #226062;
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

        <table style="                width: 100%;
                text-align: left;">        
        
        <tr>
            <td colspan="2">
                
                <br />
            </td>
        </tr>
        
        <tr>
            <td colspan="2">
                <br />
                <br />
                 <div id="countdownL2" style="font-size: 20px;"></div>
            </td>
        </tr>
    </table>
</div>


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
                IniciarLineaDespuesdeTimer(2);
                clearInterval(timer);
                document.getElementById('countdownL2').innerHTML = '';

                return;
            }
            var days = Math.floor(distance / _day);
            var hours = Math.floor((distance % _day) / _hour);
            var minutes = Math.floor((distance % _hour) / _minute);
            var seconds = Math.floor((distance % _minute) / _second);

            document.getElementById('countdownL2').innerHTML = 'La parada termina en:';
            document.getElementById('countdownL2').innerHTML += days + ' dias, ';
            document.getElementById('countdownL2').innerHTML += hours + ' horas, ';
            document.getElementById('countdownL2').innerHTML += minutes + ' minutos y ';
            document.getElementById('countdownL2').innerHTML += seconds + ' segundos';

            var PorcenBarL2 = (minutes * 100) / MinParadaL2;
            // var PorcenBarRegreso = 100 - PorcenBar;
            Bar2.setAttribute("aria-valuenow", parseInt(PorcenBarL2));
            
            document.getElementById('tooltipL2').innerHTML = days + ":" + hours + ":" + minutes + ":" + seconds;
        }

    </script>