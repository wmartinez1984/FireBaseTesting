<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Linestart.aspx.cs" Inherits="FireBaseTesting.Temporizadores.Linestart" %>
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

	
	<%--NECESARIOS PARA EJECUTAR AJAX,  JSON--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
	<script src="js/DataOPv5.js"></script>

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

	<script>
        function CambiarNumeroDeLineas(valor) {

            if (valor == 0) {

                document.getElementById('NL1').innerHTML = "1";
                document.getElementById('NL2').innerHTML = "2";
                document.getElementById('NL3').innerHTML = "3";
            }

            if (valor == 1) {
                document.getElementById('NL1').innerHTML = "4";
                document.getElementById('NL2').innerHTML = "5";
                document.getElementById('NL3').innerHTML = "6";
            }

            if (valor == 2) {
                document.getElementById('NL1').innerHTML = "7";
                document.getElementById('NL2').innerHTML = "8";
                document.getElementById('NL3').innerHTML = "9";
            }
               
        }
	</script>

</head>
<body  onload="document.getElementById('bntInicio').click();">
<input id="txtLinea" type="text" runat="server"  style="display:none;"/>
<div class="cards">
	<div class="contact" style="margin-top:-25px;width:30%;"> <i><span class="fa fa-gear" style="color:#808080; width:300px; font-size:17px; color:white; " id="ConfiguracionA">Configuración de Operación</span></i> </div>
	<br />
	<div class="contact" style="width:100%;text-align:right;background-color:transparent;margin-top:-25px;"> 
		<a href="login.aspx" style="color:red;">
			<i>
			  <span class="fa fa-backward" style="color:#808080; width:300px; font-size:17px; color:white; " id="ConfiguracionExit">
				Log Out
			   </span>
			</i>
		</a> 
	</div>
	<div class="contact2" style="width:65%;text-align:right;background-color:transparent;margin-top:25px;" > 
		 <div class="box">
		  <select id="SelectGrupo" runat="server" onchange="OPResgistradasSelect();OPResgistradasSelectTable(); CambiarNumeroDeLineas(document.getElementById('SelectGrupo').selectedIndex);">
			<option value="L1L2L3">Grupo L1 L2 L3</option>
			<option value="L4L5L6">Grupo L4 L5 L6</option>
			<option value="L7L8L9">Grupo L7 L8 L9</option>
			
		  </select>
		</div>
	</div>

	<div class="contact-form">
		<a href="#" class="close" id="closeA"><i class="fa fa-times"></i></a>
		<form>
	
	   <div class="modal-content">
		
		<table>
			<tr>
				
				<td colspan="3" style="text-align:center;">
					<div class="searchBox" style="">
					  <input class="searchInput" type="text" name="" id="txtsearchInput" placeholder="Consultar" value="OP" />
					  <button class="searchButton" onclick="DataClient(); return false;">
						<i class="material-icons">
						  OP
						</i>
					  </button>
					</div>
					<br />
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
					<td>
						 <select id="normal-select-7" class="select-css" onchange=" CambiarLavado();" style="width:280px; " >
							 <option value="30" class="select-dropdown__list-item">Cambio de caja</option>
					      <option value="45" class="select-dropdown__list-item">Enjuague 45 minutos</option>
						  <option value="75" class="select-dropdown__list-item">Enjuague intermedio 1hr:15min</option>
						  <option value="135" class="select-dropdown__list-item">CIP 2hrs:15min</option>
						  <option value="180" class="select-dropdown__list-item">CIP acido 3 hrs</option>						 	 
						 </select>
					</td>
					<td style="text-align:center;">
						<span style="color:#4FC3A1;display:none; " id="spLavado" ><strong>45 minutos</strong> </span>
					</td>
	        </tr>

		</table>
		
			<table>
				
				
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
	</div>

	 <div class="card active" id="overview">		
		<a class="card-toggle"  style="display:none" id="bntInicio">Inicio <i class="fa fa-arrow-circle-left"></i></a>
		<div class="card-content" style="background-color:#81cfef">			
			<div class="row" style="width:100%;">
				 <%--<h3 style="color:#186635;font-size:15px;width:200px;"><strong>En proceso L1:</strong> </h3>	
				 <br />
				 <h3 style="color:#5f0909;font-size:15px;"><strong>En proceso L2:</strong> </h3>	
				<br />
				<br />
				<h3 style="color:#5f0909;font-size:15px;"><strong>En proceso L3:</strong> </h3>	--%>
				<div class="left col" style="text-align: left;">					
				 	
				  
				  <div class="progress-factor flexy-item" style="margin-top:-30px;width:500px;cursor:pointer;border-radius:40px;" >
						<div class="progress-bar" >
							<div class="bar has-rotation has-colors navy ruler" style="background-color:white" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-1">
								<div class="tooltip white" style="display:none;"></div>
								<div class="bar-face face-position roof percentage" style="background-color:#45b817"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL1"></strong> </h3></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position right" style="background-color:#45b817"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position front percentage volume-lights shine" id="tooltipL1" style="font-size:50px; color:#ff0000"></div>
								<h3 style="color:black;font-size:60px;"><strong> Línea <span id="NL1"> 1</span> </strong> </h3>
							</div>
							
						</div>
					</div>
					
					<br />
					<div class="progress-factor flexy-item" style="width:500px;border-radius:20px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors orange ruler-3" style="background-color:#4e10b1" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-2">
								<div class="tooltip white" style="display:none;"></div>
								<div class="bar-face face-position roof percentage" style="background-color:#ff6a00"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL2"></strong> </h3></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position right" style="background-color:white"></div>
								<div class="bar-face face-position front percentage volume-lights shine" id="tooltipL2" style="font-size:50px; color:#ff0000"></div>
								<h3 style="color:black;font-size:60px;"><strong> Línea <span id="NL2"> 2</span></strong> </h3>
							</div>
						</div>
					</div>
					<br />
					<div class="progress-factor flexy-item" style="width:500px;border-radius:20px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors navy ruler" style="background-color:#cc3105" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-3">
								<div class="tooltip white" style="display:none;"></div>
								<div class="bar-face face-position roof percentage" style="background-color:#45b817"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL3"></strong> </h3></div>
								<div class="bar-face face-position back percentage" ></div>
								<div class="bar-face face-position floor percentage volume-lights" ></div>
								<div class="bar-face face-position right" style="background-color:#45b817"></div>
								<div class="bar-face face-position left" ></div>
								<div class="bar-face face-position front percentage volume-lights shine"  id="tooltipL3" style="font-size:50px; color:#ff0000"></div>
								<h3 style="color:black;font-size:60px;"><strong> Línea <span id="NL3"> 3</span></strong> </h3>
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

				<div class="right col" style="text-align:right;border-color:#1d4189; border-width:10px;">			
						<uc1:DataOP1 runat="server" id="DataOP1" />	
					<br />
						<table style="width:97%;text-align:center;border-radius:30px;border-color:#45b817; background-color:white">
							<tr>
								<td>
									<div id="divIniciarLavado" style="display:none;">
										<input class="btn" type="button" id="btnLavar" value="Iniciar Lavado" 
											style="background-color: #cc3105;
											color: white;
											font-size: 30px;
											border-radius: 10px;
											width: 300px;
											height: 60px;cursor:pointer;" onclick="InciarLavado();">
									</div>
									<div id="divLavando" style="display:none;">
										<p style="color:#81cfef;font-size:40px;">
											Estamos Lavando...
										</p>
									</div>
									
								</td>
							</tr>
						</table>
				</div>
			</div>
		</div>
	</div> 
	
	<div class="card" id="dribbble" onclick="document.getElementById('txtL').value = 1;" style="background-color:#382B7B" >
		<a style="background-color:white"   class="card-toggle" id="btnL1" onclick="document.getElementById('IncioTab').style.display = 'inline';"><i><span  class="fa fa-list"></span></i></a>
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
	
	<div class="card" id="behance" onclick="document.getElementById('txtL').value = 2; ">
		<a style="background-color:white"  class="card-toggle" onclick="document.getElementById('IncioTab').style.display = 'inline';"><i><span class="fa fa-list"></span></i></a>
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

	<div class="card" id="linkedin" onclick="document.getElementById('txtL').value = 3; ">
		<a style="background-color:white"  class="card-toggle" onclick="document.getElementById('IncioTab').style.display = 'inline';"><i><span class="fa fa-list"></span></i></a>
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

	<div class="card" id="twitter">
		<a style="background-color:white" class="card-toggle"  onclick="document.getElementById('IncioTab').style.display = 'inline';"><i ><span class="fa fa-calendar-check-o" id="btnIncioLine"></span></i></a>
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

	<div class="card" id="IncioTab" style="display:none;">		
		<a style="background-color:white" class="card-toggle"  onclick="HomeLoad();"><i ><span class="fa fa-home" id="btnIncioTab"></span></i></a>		

	</div>

	<div class="card" id="twitter2">
		
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
	
	
</div>

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
					<input class="btn" type="button" value="Reiniciar" onclick="EjecutarReinicioDeParada();" style="					        background-color: #ff0000;
					        color: #ffffff;
					        font-size: 15px;
					        border-radius: 5px;
					        width: 100%;">
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

        document.getElementById('divDatosAdicionales').style.display = "none";
        OPResgistradasSelectTable();
        OPResgistradasSelect();					
	</script>

	<script>
        function HomeLoad() {
            location.href = "Linestart?LineSelected=" + document.getElementById('SelectGrupo').value;
           // document.getElementById('IncioTab').style.display = 'none'; 
        }
	</script>
	<script>
		
	</script>
    
</body>
</html>

