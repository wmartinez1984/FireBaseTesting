<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndLine.aspx.cs" Inherits="FireBaseTesting.Temporizadores.EndLine" %>

<%@ Register Src="~/Temporizadores/Controles/DataOP.ascx" TagPrefix="uc1" TagName="DataOP1" %>
<%@ Register Src="~/Temporizadores/Controles/Comandos.ascx" TagPrefix="uc1" TagName="Comandos" %>
<%@ Register Src="~/Temporizadores/Controles/ComandoDetener.ascx" TagPrefix="uc1" TagName="ComandoDetener1" %>
<%@ Register Src="~/Temporizadores/Controles/ComandoDetenerL2.ascx" TagPrefix="uc1" TagName="ComandoDetenerL2_" %>
<%@ Register Src="~/Temporizadores/Controles/ComandoDetenerL3.ascx" TagPrefix="uc1" TagName="ComandoDetenerL3_" %>
<%@ Register Src="~/Temporizadores/Controles/Inciar.ascx" TagPrefix="uc1" TagName="Inciar" %>


<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>Operaciones</title>

	<%--Efectos--%>	
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" type="text/css" href="css/normalize.css" />
	<link href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,700,500,900' rel='stylesheet' type='text/css'>
	<link rel="stylesheet" type="text/css" href="css/demowather.css" />
	<link rel="stylesheet" type="text/css" href="css/style1.css" />
<%--	<link rel="stylesheet" type="text/css" href="css/demo.css" />--%>
	
	<%--NECESARIOS PARA EJECUTAR AJAX,  JSON--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
	<script src="js/DataOPv3.js"></script>

	<%--NECESARIOS PARA DISEÑO--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
	<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css'>
	<link rel="stylesheet" href="./styleV2.css">
    <script src="js/sweetalert-dev.js"></script>

	<%--NECESARIOS PARA DISEÑO Y MENSAJES DEL SISTEMA--%>
	<link href="css/sweetalert.css" rel="stylesheet" />
	<link rel="shortcut icon" href="favicon.ico">
	<link rel="stylesheet" type="text/css" href="css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.3.0/css/font-awesome.min.css" />
	<link rel="stylesheet" type="text/css" href="css/demo.css" />
	<link rel="stylesheet" type="text/css" href="css/component.css" />
	<link rel="stylesheet" type="text/css" href="css/custom-bars.css" />

</head>
<body>
<div class="image-preload">
		<img src="img/drop-color.png" alt="">
		<img src="img/drop-alpha.png" alt="">
		<img src="img/weather/texture-rain-fg.png" />
		<img src="img/weather/texture-rain-bg.png" />
		<img src="img/weather/texture-sun-fg.png" />
		<img src="img/weather/texture-sun-bg.png" />
		<img src="img/weather/texture-fallout-fg.png" />
		<img src="img/weather/texture-fallout-bg.png" />
		<img src="img/weather/texture-drizzle-fg.png" />
		<img src="img/weather/texture-drizzle-bg.png" />
	</div>
<div class="container" style="width:100%;">
<div class="cards">

	<div class="contact" style="display:none;"> <i><span class="fa fa-gear" style="color:#808080; width:300px; font-size:17px; color:white; " id="ConfiguracionA">Config</span></i> </div>
	<div class="contact-form">
		<a href="#" class="close" id="closeA"><i class="fa fa-times"></i></a>
		<form>
	
	   <div class="modal-content" style="display:none;">
		
		<table style="display:none;">
			<tr>
				
				<td colspan="3" style="text-align:center;">
					<div class="searchBox" style="">
					  <input class="searchInput" type="text" name="" id="txtsearchInput" placeholder="Consultar" />
					  <button class="searchButton" onclick="DataClient(); return false;">
						<i class="material-icons">
						  OP
						</i>
					  </button>
					</div>
					
				</td>
				
			</tr>
			<tr>
				<td>
					<br />
					OP consultada: 
					
				</td>
				<td colspan="2">
					<br />
					<span id="spnOP" style="font-size:14px;"></span>
				</td>
			</tr>
			<tr>
				<td>
						NAVI: 					
				</td>
				<td colspan="2">
					<span id="spnNAVI" style="font-size:14px;"></span>
				</td>
			</tr>

			<tr>
				<td>
					
						Nombre del producto: 
					
				</td>
				<td colspan="2">
					<span id="spnNombreProducto" style="font-size:14px;"></span>
				</td>
			</tr>

			<tr style="display:none;">
				<td>
					
						Unidades a Fabricar: 
					
				</td>
				<td colspan="2">
					<span id="spnCantidad" style="font-size:14px;"></span>
				</td>
			</tr>

			<tr>
				<td>
					
						Cliente: 
					
				</td>
				<td colspan="2">
				<span id="spnCliente" style="font-size:14px;"></span>
				</td>
			</tr>
			<tr>
					<td>
						Tipo de Lavado:
					</td>
					<td >
						 <select id="normal-select-7" class="select-css" onchange=" CambiarLavado();" >
					      <option value="45" class="select-dropdown__list-item">Enjugaue</option>
						  <option value="135" class="select-dropdown__list-item">CIP</option>
						  <option value="180" class="select-dropdown__list-item">CIP acido</option>						 	 
						 </select>
					</td>
					<td style="text-align:center;">
						<span style="color:#4FC3A1" id="spLavado"><strong>45 minutos</strong> </span>
					</td>
	       </tr>

		</table>
		
			<table style="display:none;">
				
				
				<tr>
					<td colspan="3" style="text-align:left; ">
						<br />
                        <input id="btnInciar" type="button" value="Iniciar" onclick="SaveOp(); return false;" style="background-color:#4FC3A1;border-radius:10px;border-color:#4FC3A1;width:100px;"/>
						
					</td>
				</tr>
			</table>
			
			 <script>
                 function CambiarLavado() {

                     document.getElementById('spLavado').innerHTML = document.getElementById('normal-select-7').value + " Minutos";
                 }
			 </script>
		  
		
		<br />
        <input id="HiddenEstadoOP" type="hidden" />
		<table class="fl-table" style="width:100%;" id="TableOP">
			<thead>
			<tr>
				<th>OP</th>
				<th>NAVI</th>
				<th>Nombre del producto</th>
				<th>Unidades a Fabricar</th>
				<th>Cliente</th>
				<th>Lavado</th>
				<th>Estado OP</th>
				
			</tr>
			</thead>
			<tbody>
			<tr>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>Pendiente</td>
				
			</tr>
			
			<tbody>
		</table>			
	  </div>		
		
		<br />
		<br />
			
		</form>

		<p style="font-size:40px;text-align:center;color:red;"> Actualmente no existe una OP pendiente</p>
		   
	</div>

	 <div class="card active" id="overview">
		<a class="card-toggle"  id="bntInicio">Inicio <i class="fa fa-arrow-circle-left"></i></a>
		<div class="card-content" style="background-color:#81cfef">			
			<div class="row" style="width:100%;">
				 <%--<h3 style="color:#186635;font-size:15px;width:200px;"><strong>En proceso L1:</strong> </h3>	
				 <br />
				 <h3 style="color:#5f0909;font-size:15px;"><strong>En proceso L2:</strong> </h3>	
				<br />
				<br />
				<h3 style="color:#5f0909;font-size:15px;"><strong>En proceso L3:</strong> </h3>	--%>
				<div class="left col" style="text-align:left;">			
				 	
				  <div class="progress-factor flexy-item" style="margin-top:-30px;width:600px;cursor:pointer;border-radius:40px;" >
						<div class="progress-bar" style="width:600px;" >
							<div class="bar has-rotation has-colors navy ruler" style="background-color:white" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-1">
								<div class="tooltip white" style="display:none;"></div>
								<div class="bar-face face-position roof percentage" style="background-color:#45b817"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL1"></strong> </h3></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position right" style="								        background-color: #45b817
								"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position front percentage volume-lights shine" id="tooltipL1" style="font-size:50px; color:#ff0000"></div>
								<h3 style="color:black;font-size:60px;"><strong> Mesa 1</strong> </h3>
							</div>
							
						</div>
					</div>
					
					<br />
					<div class="progress-factor flexy-item" style="width:500px;border-radius:20px;width:600px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors orange ruler-3" style="background-color:#4e10b1" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-2">
								<div class="tooltip white" style="display:none;"></div>
								<div class="bar-face face-position roof percentage" style="background-color:#ff6a00"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL2"></strong> </h3></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position right" style="background-color:white"></div>
								<div class="bar-face face-position front percentage volume-lights shine" id="tooltipL2" style="font-size:50px; color:#ff0000"></div>
								<h3 style="color:black;font-size:60px;"><strong> Mesa 2</strong> </h3>
							</div>
						</div>
					</div>
					<br />
					<div class="progress-factor flexy-item" style="width:500px;border-radius:20px;width:600px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors navy ruler" style="background-color:#cc3105" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-3">
								<div class="tooltip white" style="display:none;"></div>
								<div class="bar-face face-position roof percentage" style="background-color:#45b817"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL3"></strong> </h3></div>
								<div class="bar-face face-position back percentage" ></div>
								<div class="bar-face face-position floor percentage volume-lights" ></div>
								<div class="bar-face face-position right" style="background-color:#45b817"></div>
								<div class="bar-face face-position left" ></div>
								<div class="bar-face face-position front percentage volume-lights shine"  id="tooltipL3" style="font-size:50px; color:#ff0000"></div>
								<h3 style="color:black;font-size:60px;"><strong> Mesa 3</strong> </h3>
							</div>
						</div>
					</div>	
					<br />
					<div style="display:none;">
						<input type="text"  id="txtL"/>
						<input type="text"  id="txtL1"/>
						<input type="text"  id="txtL2"/>
						<input type="text"  id="txtL3"/>
					</div>
					
				</div>

				<div class="right col" style="text-align:right; border-color:#1d4189; border-width:10px;">			
						<uc1:DataOP1 runat="server" id="DataOP1" />	
						
						<table style="width:97%;text-align:center;border-color:#45b817; background-color:rgba(255, 255, 255, 0.64); width:97%;  border-radius:30px;">
							<tr>
								<td>
									<input class="btn" type="button" id="btnLavar" value="Iniciar Lavado" 
											style="background-color: #cc3105;
											color: white;
											font-size: 30px;
											border-radius: 10px;
											width: 300px;
											height: 60px;cursor:pointer;display:none;" onclick="InciarLavado();">
									<div id="divIniciarLavado" style="display:none;">
										<strong>
											Esperando el inicio del lavado...
										</strong> 
									</div>
									<div id="divLavando" style="display:none;">
										Lavando...
										<div class="slideshow" style="width:680px;height:180px;display:none;">
											<canvas width="1" height="1" id="container"style="display:none;" ></canvas>
											<!-- Heavy Rain -->
											<div class="slide" id="slide-1" data-weather="rain" style="display:none;">
				
											</div>
											<!-- Drizzle -->
											<div class="slide" id="slide-2" data-weather="drizzle" style="display:none;">
				
											</div>
											<!-- Sunny -->
											<div class="slide" id="slide-3" data-weather="sunny" style="display:none;">
			
											</div>
			
		
										</div>
										
									</div>
									
									<img  src="../Images/lavando.gif" style="height:157px;display:none; "/>
								</td>
							</tr>
						</table>
				</div>
			</div>
		</div>
	</div> 
	
	<div class="card" id="dribbble" onclick="document.getElementById('txtL').value = 1;" style="background-color:#382B7B; display:none;" >
		<a style="background-color:white"   class="card-toggle" id="btnL1"><i><span  class="fa fa-list"></span></i></a>
		<div class="card-content">
			<div class="row">
				<div class="left col" style="text-align: left;">
					<h3>Línea <strong>No 1</strong></h3>			
					<%--<uc1:Comandos runat="server" id="Comandos" />--%>
					<br />
					<uc1:ComandoDetener1 runat="server" id="ComandoDetener" />
				</div>

				<div class="right col" >
					<uc1:DataOP1 runat="server" id="DataOP2" style="color:#ff6a00"/>	
				</div>
				
			</div>
		</div>

	</div> 
	
	<div class="card" id="behance" onclick="document.getElementById('txtL').value = 2; " style="display:none;">
		<a style="background-color:white"  class="card-toggle"><i><span class="fa fa-list"></span></i></a>
		<div class="card-content">
			<div class="row">
				<div class="left col">
					<h3>Línea <strong>No 2</strong></h3>
					<%--<uc1:Comandos runat="server" id="Comandos1" />--%>
					<uc1:ComandoDetenerL2_ runat="server" id="ComandoDetenerL2" />
				</div>
				<div class="right col">
				  <uc1:DataOP1 runat="server" id="DataOP3" />						
				</div>
			</div>
		</div>
	</div>

	<div class="card" id="linkedin" onclick="document.getElementById('txtL').value = 3; " style="display:none;">
		<a style="background-color:white"  class="card-toggle"><i><span class="fa fa-list"></span></i></a>
		<div class="card-content" >
			<div class="row" style="text-align:left;">
				<div class="left col">
				<h3>Línea <strong>No 3</strong></h3>
				  <%--  <uc1:Comandos runat="server" id="Comandos2" />--%>
					<uc1:ComandoDetenerL3_ runat="server" id="ComandoDetenerL3" />
				</div>
				<div class="right col">
					 <uc1:DataOP1 runat="server" id="DataOP4" />	
				</div>
			</div>
		</div>
	</div>

	<div class="card" id="twitter" style="display:none;">
		<a style="background-color:white" class="card-toggle" ><i ><span class="fa fa-calendar-check-o" id="btnIncioLine"></span></i></a>
		<div class="card-content">
			<div class="row">
				<div class="left col">					
				    <uc1:Inciar runat="server" ID="Inciar" />
				</div>
				<div class="right col">
					  <uc1:DataOP1 runat="server" id="DataOP5" />			
			   </div>
			</div>
		</div>
	</div>

	<div class="card" id="twitter2"  style="display:none;">
		
		<div class="card-content">
			<div class="row">				
				<div class="right col">
					<h2>My <strong>Twitter</strong></h2>
				
					<p>Fugit veniam, animi architecto doloribus veritatis vitae sint doloremque possimus quae. Pariatur libero, veniam voluptatibus alias distinctio qui nostrum debitis voluptate amet hic repellat officiis nam quos vel doloremque praesentium.</p>
				</div>
				<div class="right col"><img src="https://dl.dropboxusercontent.com/u/26808427/cdn/preview.jpg" alt="" /></div>
			</div>
		</div>
	</div>	
	<%--<a class="card-toggle" href="login.aspx"  style="width:90%;text-align:right;color:#ff0000;"><i><span class="fa fa-sign-out" style="width:200px;color:black;font-size:21px; color:#ff0000">Log out</span></i></a>--%>
</div>
		
	</div>
<script src="js/index.min.js"></script>

<%--MODAL OP--%>

<div id="mask"></div>
<div class="modal">
	<a class="close-modal" href="javascript:void(0)">
	<i class="fa fa-times"></i>
	</a>
	<br />
	<div style="text-align:left;">
		
	<%--	<select id="SelectParadas" class="select-css" style="width:100%;">
                    <option value="30">Parada Minima</option>
                    <option value="45">Parada Media</option>
                    <option value="60">Parada por mantenimiento</option>
         </select>--%>
		<table style="text-align:left;">
			<tr>
				<td>
					<input class="btn" type="button" value="Parada Mínima" onclick="ParadaLineasdeProduccion(30);" style="background-color:#ff0000; color:#ffffff;  font-size:15px;border-radius:5px; width:100%;">
				</td>
			</tr>
			<tr>
				<td>
					<input class="btn" type="button" value="Pararada Media" onclick="ParadaLineasdeProduccion(45);" style="background-color:#ff0000; color:#ffffff;  font-size:15px;border-radius:5px; width:100%;">
				</td>
			</tr>
			<tr>
				<td>
					<input class="btn" type="button" value="Pararada por Mantenimiento" onclick="ParadaLineasdeProduccion(60);" style="background-color:#ff0000; color:#ffffff;  font-size:15px;border-radius:5px; width:100%;">
				</td>
			</tr>
		</table>
		<br />
		
		<br />
		
		<br />
		
	</div>
</div>

<div id="mask2"></div>
<div class="modal2">
	<a class="close-modal2" href="javascript:void(0)" id="Modal2Close">
	<i class="fa fa-times"></i>
	</a>
	<div>
	
		<span>Seleccione el tipo de parada con la que desea reiniciar:</span>
		<select id="SelectParadasR" class="select-css" style="width:100%;">
                    <option value="30">Parada Minima</option>
                    <option value="45">Parada Media</option>
                    <option value="60">Parada por mantenimiento</option>
         </select>
		<br />
		<table>
			<tr>
				<td colspan="2">
					<input class="btn" type="button" value="Reiniciar" onclick="EjecutarReinicioDeParada();" style=" background-color: #ff0000; color: #ffffff; font-size: 15px; border-radius: 5px; width: 100%;">
				</td>
				
			</tr>
		</table>
		
	</div>
</div>

<!-- partial -->
<script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
<script  src="./script.js"></script>

	<!-- /container -->
	<script src="js/jquery-2.1.1.min.js" type="text/javascript" charset="utf-8"></script>
	<script type="text/javascript" charset="utf-8">
        $("#change-color .bar").hover(function () {
            // $(this).toggleClass('active');
            $(this).find('.front').toggleClass('shine');
        });

        function openForm() {
            document.getElementById("myForm").style.display = "block";
        }

        function closeForm() {
            document.getElementById("myForm").style.display = "none";
        }

        function openModalBox() {
            var modal = $(".modal, #mask");
            $(".open-modal").on("click", function () {
                modal.fadeIn(300);
            });
            $(".close-modal, #mask").on("click", function () {
                modal.fadeOut(800);
            });
        }
        openModalBox();
        // 

        function openModalBox2() {
            var modal2 = $(".modal2, #mask2");
            $(".open-modal2").on("click", function () {
                modal2.fadeIn(300);
            });
            $(".close-modal2, #mask").on("click", function () {
                modal2.fadeOut(800);
            });
        }
        openModalBox2();

        function OpenModalNew(Lp) {
            //verifico si ya está denida
            if (document.getElementById('txtL').value == 1 && document.getElementById('txtL1').value == 3) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 1  ya está denida', 'warning');
                return false;
            }

            if (document.getElementById('txtL').value == 2 && document.getElementById('txtL2').value == 3) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 2  ya está denida', 'warning');
                return false;
            }

            if (document.getElementById('txtL').value == 3 && document.getElementById('txtL3').value == 3) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 3  ya está denida', 'warning');
                return false;
            }

            // si la línea seleccionada es la 1 y el estatus es Envasando, podemos  continuar, de lo contrario , no
            if (document.getElementById('txtL').value == 1 && document.getElementById('txtL1').value != 2) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 1 debe estar Envasando para poder detenerla', 'warning');
                return false;
            }

            if (document.getElementById('txtL').value == 2 && document.getElementById('txtL2').value != 2) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 2 debe estar Envasando para poder detenerla', 'warning');
                return false;
            }

            if (document.getElementById('txtL').value == 3 && document.getElementById('txtL3').value != 2) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 3 debe estar Envasando para poder detenerla', 'warning');
                return false;
            }
            var modal = $(".modal, #mask");
            modal.fadeIn(300);
        }

        function OpenModalNew2() {
            //verifico si ya está denida, sólo así podrá reiniciar línea
            if (document.getElementById('txtL').value == 1 && document.getElementById('txtL1').value != 3) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 1  actualmente no está parada, esta opción sólo se usa cuándo se desea reiniciar el tiempo de parada', 'warning');
                return false;
            }

            if (document.getElementById('txtL').value == 2 && document.getElementById('txtL2').value != 3) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 2  actualmente no está parada, esta opción sólo se usa cuándo se desea reiniciar el tiempo de parada', 'warning');
                return false;
            }

            if (document.getElementById('txtL').value == 3 && document.getElementById('txtL3').value != 3) {
                swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 3  actualmente no está parada, esta opción sólo se usa cuándo se desea reiniciar el tiempo de parada', 'warning');
                return false;
            }

            var modal2 = $(".modal2, #mask2");
            modal2.fadeIn(300);
        }



        var Bar = document.getElementById('bar-1');
        //var ProgressBarValue_ = 0;
        //var ProgressExe = setInterval(ProgressBar, 200);

        function ProgressBar() {

            var ProgressBarValue = Bar.getAttribute("aria-valuenow");

            if (ProgressBarValue <= 100) {
                ProgressBarValue_ += 10;
            }
            else {
                ProgressBarValue_ = 0;
            }

            Bar.setAttribute("aria-valuenow", ProgressBarValue_);

        }

        var Bar2 = document.getElementById('bar-2');
        //var ProgressBarValue2_ = 0;
        //var ProgressExe2 = setInterval(ProgressBar2, 300);

        function ProgressBar2() {

            var ProgressBarValue2 = Bar2.getAttribute("aria-valuenow");

            if (ProgressBarValue2 <= 100) {
                ProgressBarValue2_ += 10;
            }
            else {
                ProgressBarValue2_ = 0;
            }

            Bar2.setAttribute("aria-valuenow", ProgressBarValue2_);

        }

        var Bar3 = document.getElementById('bar-3');
        //var ProgressBarValue3_ = 0;
        //var ProgressExe3 = setInterval(ProgressBar3, 400);

        function ProgressBar3() {

            var ProgressBarValue3 = Bar3.getAttribute("aria-valuenow");

            if (ProgressBarValue3 <= 100) {
                ProgressBarValue3_ += 10;
            }
            else {
                ProgressBarValue3_ = 0;
            }

            Bar3.setAttribute("aria-valuenow", ProgressBarValue3_);

        }

       // OPResgistradasSelectTable();
        OPResgistradasSelectEndLine(); //La primera vez carga normal y la segunda valida estatus
        setInterval(function () { OPResgistradasSelectEndLineP2(); }, 9000);
	</script>


</body>
</html>


