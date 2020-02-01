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
                 <div id="countdownL2" style="font-size:30px;"></div>
            </td>
        </tr>
    </table>
</div>


<script>
        var end = new Date('01/29/2019 6:59 PM');
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
                document.getElementById('countdownL2').innerHTML = '';

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