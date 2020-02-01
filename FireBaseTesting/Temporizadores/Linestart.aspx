<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Linestart.aspx.cs" Inherits="FireBaseTesting.Temporizadores.Linestart" %>
<%@ Register Src="~/Temporizadores/Controles/DataOP.ascx" TagPrefix="uc1" TagName="DataOP1" %>
<%@ Register Src="~/Temporizadores/Controles/Comandos.ascx" TagPrefix="uc1" TagName="Comandos" %>
<%@ Register Src="~/Temporizadores/Controles/ComandoDetener.ascx" TagPrefix="uc1" TagName="ComandoDetener1" %>
<%@ Register Src="~/Temporizadores/Controles/ComandoDetenerL2.ascx" TagPrefix="uc1" TagName="ComandoDetenerL2_" %>
<%@ Register Src="~/Temporizadores/Controles/ComandoDetenerL3.ascx" TagPrefix="uc1" TagName="ComandoDetenerL3_" %>






<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>Operaciones</title>

	
	<%--NECESARIOS PARA EJECUTAR AJAX,  JSON--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
	<script src="js/DataOP.js"></script>

	<%--NECESARIOS PARA DISEÑO--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
	<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css'><link rel="stylesheet" href="./style.css">
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

<div class="cards">

	<div class="contact"> <i><span class="fa fa-gear" style="color:#808080; width:300px; font-size:17px; color:white; " id="ConfiguracionA">Configuración de Operación</span></i> </div>
	<div class="contact-form">
		<a href="#" class="close" id="closeA"><i class="fa fa-times"></i></a>
		<form>
	
	   <div class="modal-content">
		
		<table>
			<tr>
				
				<td colspan="3" style="text-align:left;">
					<div class="searchBox" style="">
					  <input class="searchInput" type="text" name="" id="txtsearchInput" placeholder="Consultar" />
					  <button class="searchButton" onclick="DataClient(); return false;">
						<i class="material-icons">
						  OP
						</i>
					  </button>
					</div>
					<br />
					<br />
				</td>
				
			</tr>
			<tr>
				<td>
						<br />
						OP consultada: 
					
				</td>
				<td colspan="2">
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

			<tr>
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
		<a class="card-toggle" >Inicio <i class="fa fa-arrow-circle-left"></i></a>
		<div class="card-content">			
			<div class="row" style="width:100%;">
				 <%--<h3 style="color:#186635;font-size:15px;width:200px;"><strong>En proceso L1:</strong> </h3>	
				 <br />
				 <h3 style="color:#5f0909;font-size:15px;"><strong>En proceso L2:</strong> </h3>	
				<br />
				<br />
				<h3 style="color:#5f0909;font-size:15px;"><strong>En proceso L3:</strong> </h3>	--%>
				<div class="left col" style="text-align:left;">					
				 	
				  
				  <div class="progress-factor flexy-item" style="margin-top:-70px;width:500px;cursor:pointer;" >
						<div class="progress-bar">
							<div class="bar has-rotation has-colors navy ruler" style="background-color:#cc3105" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-1">
								<div class="tooltip white"></div>
								<div class="bar-face face-position roof percentage" style="background-color:#45b817"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL1"></strong> </h3></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position right"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position front percentage volume-lights shine"></div>
								<h3 style="color:white;font-size:25px;"><strong> Línea de producción 1</strong> </h3>
							</div>
							
						</div>
					</div>
					
					<br />
					<div class="progress-factor flexy-item" style="width:500px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors orange ruler-3" style="background-color:#4e10b1" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-2">
								<div class="tooltip white" ></div>
								<div class="bar-face face-position roof percentage" style="background-color:#ff6a00"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL2"></strong> </h3></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position right" ></div>
								<div class="bar-face face-position front percentage volume-lights shine"></div>
								<h3 style="color:white;font-size:25px;"><strong> Línea de producción 2</strong> </h3>
							</div>
						</div>
					</div>
					<br />
					<div class="progress-factor flexy-item" style="width:500px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors navy ruler" style="background-color:#cc3105" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="bar-3">
								<div class="tooltip white"></div>
								<div class="bar-face face-position roof percentage" style="background-color:#45b817"><h3 style="color:white;font-size:25px;"><strong id="spanEstatusL3"></strong> </h3></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position right"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position front percentage volume-lights shine"></div>
								<h3 style="color:white;font-size:25px;"><strong> Línea de producción 3</strong> </h3>
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
				</div>
			</div>
		</div>
	</div> 
	
	<div class="card" id="dribbble" onclick="document.getElementById('txtL').value = 1; ">
		<a class="card-toggle"><i><span class="fa fa-list"></span></i></a>
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
		<a class="card-toggle"><i><span class="fa fa-list"></span></i></a>
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
		<a class="card-toggle"><i><span class="fa fa-list"></span></i></a>
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
		<a class="card-toggle"><i><span class="fa fa-calendar-check-o"></span></i></a>
		<div class="card-content">
			<div class="row">
				<div class="left col">
					<h3>Datos de <strong> Incio y finalización de operación</strong></h3>
				
					<table>
						<tr>
					<td>
						<div class="control"><label for="message">Término de producción L1: </label></div>
					</td>
					<td>
							<select id="normal-select-1" class="select-css" >
								  <option value="1" class="select-dropdown__list-item">01 Hora</option>
								  <option value="2" class="select-dropdown__list-item">02 Horas</option>
								  <option value="3" class="select-dropdown__list-item">03 Horas</option>
								  <option value="4" class="select-dropdown__list-item">04 Horas</option>
								  <option value="5" class="select-dropdown__list-item">05 Horas</option>
								  <option value="6" class="select-dropdown__list-item">06 Horas</option>
								  <option value="7" class="select-dropdown__list-item">07 Horas</option>
								  <option value="8" class="select-dropdown__list-item">08 Horas</option>
								  <option value="9" class="select-dropdown__list-item">09 Horas</option>
								  <option value="10" class="select-dropdown__list-item">10 Horas</option>
								  <option value="11" class="select-dropdown__list-item">11 Horas</option>
								  <option value="12" class="select-dropdown__list-item">12 Horas</option>
								  <option value="13" class="select-dropdown__list-item">13 Horas</option>
								  <option value="14" class="select-dropdown__list-item">14 Horas</option>
								  <option value="15" class="select-dropdown__list-item">15 Horas</option>
								  <option value="16" class="select-dropdown__list-item">16 Horas</option>
								  <option value="17" class="select-dropdown__list-item">17 Horas</option>
								  <option value="18" class="select-dropdown__list-item">18 Horas</option>
								  <option value="19" class="select-dropdown__list-item">19 Horas</option>
								  <option value="20" class="select-dropdown__list-item">20 Horas</option>
								  <option value="21" class="select-dropdown__list-item">21 Horas</option>
								  <option value="22" class="select-dropdown__list-item">22 Horas</option>
								  <option value="23" class="select-dropdown__list-item">23 Horas</option>
								  <option value="24" class="select-dropdown__list-item">24 Horas</option>
							 </select>
						</td>
						<td>
							 <select id="normal-select-2" class="select-css" >
								  <option value="0" class="select-dropdown__list-item">00 Minutos</option>
								  <option value="1" class="select-dropdown__list-item">01 Minuto</option>
								  <option value="2" class="select-dropdown__list-item">02 Minutos</option>
								  <option value="3" class="select-dropdown__list-item">03 Minutos</option>
								  <option value="4" class="select-dropdown__list-item">04 Minutos</option>
								  <option value="5" class="select-dropdown__list-item">05 Minutos</option>
								  <option value="6" class="select-dropdown__list-item">06 Minutos</option>
								  <option value="7" class="select-dropdown__list-item">07 Minutos</option>
								  <option value="8" class="select-dropdown__list-item">08 Minutos</option>
								  <option value="9" class="select-dropdown__list-item">09 Minutos</option>
								  <option value="10" class="select-dropdown__list-item">10 Minutos</option>
								  <option value="11" class="select-dropdown__list-item">11 Minutos</option>
								  <option value="12" class="select-dropdown__list-item">12 Minutos</option>
								  <option value="13" class="select-dropdown__list-item">13 Minutos</option>
								  <option value="14" class="select-dropdown__list-item">14 Minutos</option>
								  <option value="15" class="select-dropdown__list-item">15 Minutos</option>
								  <option value="16" class="select-dropdown__list-item">16 Minutos</option>
								  <option value="17" class="select-dropdown__list-item">17 Minutos</option>
								  <option value="18" class="select-dropdown__list-item">18 Minutos</option>
								  <option value="19" class="select-dropdown__list-item">19 Minutos</option>
								  <option value="20" class="select-dropdown__list-item">20 Minutos</option>
								  <option value="21" class="select-dropdown__list-item">21 Minutos</option>
								  <option value="22" class="select-dropdown__list-item">22 Minutos</option>
								  <option value="23" class="select-dropdown__list-item">23 Minutos</option>
								  <option value="24" class="select-dropdown__list-item">24 Minutos</option>
			  
								  <option value="25" class="select-dropdown__list-item">25 Minutos</option>
								  <option value="26" class="select-dropdown__list-item">26 Minutos</option>
								  <option value="27" class="select-dropdown__list-item">27 Minutos</option>
								  <option value="28" class="select-dropdown__list-item">28 Minutos</option>
								  <option value="29" class="select-dropdown__list-item">29 Minutos</option>
								  <option value="30" class="select-dropdown__list-item">30 Minutos</option>
								  <option value="31" class="select-dropdown__list-item">31 Minutos</option>
								  <option value="32" class="select-dropdown__list-item">32 Minutos</option>
								  <option value="33" class="select-dropdown__list-item">33 Minutos</option>
								  <option value="34" class="select-dropdown__list-item">34 Minutos</option>
								  <option value="35" class="select-dropdown__list-item">35 Minutos</option>
								  <option value="36" class="select-dropdown__list-item">36 Minutos</option>
								  <option value="37" class="select-dropdown__list-item">38 Minutos</option>
								  <option value="39" class="select-dropdown__list-item">39 Minutos</option>
								  <option value="40" class="select-dropdown__list-item">40 Minutos</option>
								  <option value="41" class="select-dropdown__list-item">41 Minutos</option>
								  <option value="42" class="select-dropdown__list-item">42 Minutos</option>
								  <option value="43" class="select-dropdown__list-item">43 Minutos</option>
								  <option value="44" class="select-dropdown__list-item">44 Minutos</option>
								  <option value="45" class="select-dropdown__list-item">45 Minutos</option>
								  <option value="46" class="select-dropdown__list-item">46 Minutos</option>
								  <option value="47" class="select-dropdown__list-item">47 Minutos</option>
								  <option value="48" class="select-dropdown__list-item">49 Minutos</option>
								  <option value="49" class="select-dropdown__list-item">49 Minutos</option>
								  <option value="50" class="select-dropdown__list-item">50 Minutos</option>
								  <option value="51" class="select-dropdown__list-item">51 Minutos</option>
								  <option value="52" class="select-dropdown__list-item">52 Minutos</option>
								  <option value="53" class="select-dropdown__list-item">53 Minutos</option>
								  <option value="54" class="select-dropdown__list-item">54 Minutos</option>
								  <option value="55" class="select-dropdown__list-item">55 Minutos</option>
								  <option value="56" class="select-dropdown__list-item">56 Minutos</option>
								  <option value="57" class="select-dropdown__list-item">57 Minutos</option>
								  <option value="58" class="select-dropdown__list-item">58 Minutos</option>
								  <option value="59" class="select-dropdown__list-item">59 Minutos</option>	 
							 </select>
						</td>
					</tr>
					<tr>
						<td>
							<div class="control"><label for="message">Término de producción L2: </label></div>
						</td>
						<td>
							<select id="normal-select-3" class="select-css" >
							  <option value="1" class="select-dropdown__list-item">01 Hora</option>
							  <option value="2" class="select-dropdown__list-item">02 Horas</option>
							  <option value="3" class="select-dropdown__list-item">03 Horas</option>
							  <option value="4" class="select-dropdown__list-item">04 Horas</option>
							  <option value="5" class="select-dropdown__list-item">05 Horas</option>
							  <option value="6" class="select-dropdown__list-item">06 Horas</option>
							  <option value="7" class="select-dropdown__list-item">07 Horas</option>
							  <option value="8" class="select-dropdown__list-item">08 Horas</option>
							  <option value="9" class="select-dropdown__list-item">09 Horas</option>
							  <option value="10" class="select-dropdown__list-item">10 Horas</option>
							  <option value="11" class="select-dropdown__list-item">11 Horas</option>
							  <option value="12" class="select-dropdown__list-item">12 Horas</option>
							  <option value="13" class="select-dropdown__list-item">13 Horas</option>
							  <option value="14" class="select-dropdown__list-item">14 Horas</option>
							  <option value="15" class="select-dropdown__list-item">15 Horas</option>
							  <option value="16" class="select-dropdown__list-item">16 Horas</option>
							  <option value="17" class="select-dropdown__list-item">17 Horas</option>
							  <option value="18" class="select-dropdown__list-item">18 Horas</option>
							  <option value="19" class="select-dropdown__list-item">19 Horas</option>
							  <option value="20" class="select-dropdown__list-item">20 Horas</option>
							  <option value="21" class="select-dropdown__list-item">21 Horas</option>
							  <option value="22" class="select-dropdown__list-item">22 Horas</option>
							  <option value="23" class="select-dropdown__list-item">23 Horas</option>
							  <option value="24" class="select-dropdown__list-item">24 Horas</option>
							 </select>
						</td>
						<td>
							 <select id="normal-select-4" class="select-css" >
							 <option value="0" class="select-dropdown__list-item">00 Minutos</option>
							  <option value="1" class="select-dropdown__list-item">01 Minuto</option>
							  <option value="2" class="select-dropdown__list-item">02 Minutos</option>
							  <option value="3" class="select-dropdown__list-item">03 Minutos</option>
							  <option value="4" class="select-dropdown__list-item">04 Minutos</option>
							  <option value="5" class="select-dropdown__list-item">05 Minutos</option>
							  <option value="6" class="select-dropdown__list-item">06 Minutos</option>
							  <option value="7" class="select-dropdown__list-item">07 Minutos</option>
							  <option value="8" class="select-dropdown__list-item">08 Minutos</option>
							  <option value="9" class="select-dropdown__list-item">09 Minutos</option>
							  <option value="10" class="select-dropdown__list-item">10 Minutos</option>
							  <option value="11" class="select-dropdown__list-item">11 Minutos</option>
							  <option value="12" class="select-dropdown__list-item">12 Minutos</option>
							  <option value="13" class="select-dropdown__list-item">13 Minutos</option>
							  <option value="14" class="select-dropdown__list-item">14 Minutos</option>
							  <option value="15" class="select-dropdown__list-item">15 Minutos</option>
							  <option value="16" class="select-dropdown__list-item">16 Minutos</option>
							  <option value="17" class="select-dropdown__list-item">17 Minutos</option>
							  <option value="18" class="select-dropdown__list-item">18 Minutos</option>
							  <option value="19" class="select-dropdown__list-item">19 Minutos</option>
							  <option value="20" class="select-dropdown__list-item">20 Minutos</option>
							  <option value="21" class="select-dropdown__list-item">21 Minutos</option>
							  <option value="22" class="select-dropdown__list-item">22 Minutos</option>
							  <option value="23" class="select-dropdown__list-item">23 Minutos</option>
							  <option value="24" class="select-dropdown__list-item">24 Minutos</option>
			  
							  <option value="25" class="select-dropdown__list-item">25 Minutos</option>
							  <option value="26" class="select-dropdown__list-item">26 Minutos</option>
							  <option value="27" class="select-dropdown__list-item">27 Minutos</option>
							  <option value="28" class="select-dropdown__list-item">28 Minutos</option>
							  <option value="29" class="select-dropdown__list-item">29 Minutos</option>
							  <option value="30" class="select-dropdown__list-item">30 Minutos</option>
							  <option value="31" class="select-dropdown__list-item">31 Minutos</option>
							  <option value="32" class="select-dropdown__list-item">32 Minutos</option>
							  <option value="33" class="select-dropdown__list-item">33 Minutos</option>
							  <option value="34" class="select-dropdown__list-item">34 Minutos</option>
							  <option value="35" class="select-dropdown__list-item">35 Minutos</option>
							  <option value="36" class="select-dropdown__list-item">36 Minutos</option>
							  <option value="37" class="select-dropdown__list-item">38 Minutos</option>
							  <option value="39" class="select-dropdown__list-item">39 Minutos</option>
							  <option value="40" class="select-dropdown__list-item">40 Minutos</option>
							  <option value="41" class="select-dropdown__list-item">41 Minutos</option>
							  <option value="42" class="select-dropdown__list-item">42 Minutos</option>
							  <option value="43" class="select-dropdown__list-item">43 Minutos</option>
							  <option value="44" class="select-dropdown__list-item">44 Minutos</option>
							  <option value="45" class="select-dropdown__list-item">45 Minutos</option>
							  <option value="46" class="select-dropdown__list-item">46 Minutos</option>
							  <option value="47" class="select-dropdown__list-item">47 Minutos</option>
							  <option value="48" class="select-dropdown__list-item">49 Minutos</option>
							  <option value="49" class="select-dropdown__list-item">49 Minutos</option>
							  <option value="50" class="select-dropdown__list-item">50 Minutos</option>
							  <option value="51" class="select-dropdown__list-item">51 Minutos</option>
							  <option value="52" class="select-dropdown__list-item">52 Minutos</option>
							  <option value="53" class="select-dropdown__list-item">53 Minutos</option>
							  <option value="54" class="select-dropdown__list-item">54 Minutos</option>
							  <option value="55" class="select-dropdown__list-item">55 Minutos</option>
							  <option value="56" class="select-dropdown__list-item">56 Minutos</option>
							  <option value="57" class="select-dropdown__list-item">57 Minutos</option>
							  <option value="58" class="select-dropdown__list-item">58 Minutos</option>
							  <option value="59" class="select-dropdown__list-item">59 Minutos</option>	 
							 </select>
						</td>
					</tr>
					<tr>
						<td>
							<div class="control"><label for="message">Término de producción L3: </label></div>
						</td>
						<td>
							<select id="normal-select-5" class="select-css" >
							  <option value="1" class="select-dropdown__list-item">01 Hora</option>
							  <option value="2" class="select-dropdown__list-item">02 Horas</option>
							  <option value="3" class="select-dropdown__list-item">03 Horas</option>
							  <option value="4" class="select-dropdown__list-item">04 Horas</option>
							  <option value="5" class="select-dropdown__list-item">05 Horas</option>
							  <option value="6" class="select-dropdown__list-item">06 Horas</option>
							  <option value="7" class="select-dropdown__list-item">07 Horas</option>
							  <option value="8" class="select-dropdown__list-item">08 Horas</option>
							  <option value="9" class="select-dropdown__list-item">09 Horas</option>
							  <option value="10" class="select-dropdown__list-item">10 Horas</option>
							  <option value="11" class="select-dropdown__list-item">11 Horas</option>
							  <option value="12" class="select-dropdown__list-item">12 Horas</option>
							  <option value="13" class="select-dropdown__list-item">13 Horas</option>
							  <option value="14" class="select-dropdown__list-item">14 Horas</option>
							  <option value="15" class="select-dropdown__list-item">15 Horas</option>
							  <option value="16" class="select-dropdown__list-item">16 Horas</option>
							  <option value="17" class="select-dropdown__list-item">17 Horas</option>
							  <option value="18" class="select-dropdown__list-item">18 Horas</option>
							  <option value="19" class="select-dropdown__list-item">19 Horas</option>
							  <option value="20" class="select-dropdown__list-item">20 Horas</option>
							  <option value="21" class="select-dropdown__list-item">21 Horas</option>
							  <option value="22" class="select-dropdown__list-item">22 Horas</option>
							  <option value="23" class="select-dropdown__list-item">23 Horas</option>
							  <option value="24" class="select-dropdown__list-item">24 Horas</option>
							 </select>
						</td>
						<td>
							 <select id="normal-select-6" class="select-css" >
							  <option value="0" class="select-dropdown__list-item">00 Minutos</option>
							  <option value="1" class="select-dropdown__list-item">01 Minuto</option>
							  <option value="2" class="select-dropdown__list-item">02 Minutos</option>
							  <option value="3" class="select-dropdown__list-item">03 Minutos</option>
							  <option value="4" class="select-dropdown__list-item">04 Minutos</option>
							  <option value="5" class="select-dropdown__list-item">05 Minutos</option>
							  <option value="6" class="select-dropdown__list-item">06 Minutos</option>
							  <option value="7" class="select-dropdown__list-item">07 Minutos</option>
							  <option value="8" class="select-dropdown__list-item">08 Minutos</option>
							  <option value="9" class="select-dropdown__list-item">09 Minutos</option>
							  <option value="10" class="select-dropdown__list-item">10 Minutos</option>
							  <option value="11" class="select-dropdown__list-item">11 Minutos</option>
							  <option value="12" class="select-dropdown__list-item">12 Minutos</option>
							  <option value="13" class="select-dropdown__list-item">13 Minutos</option>
							  <option value="14" class="select-dropdown__list-item">14 Minutos</option>
							  <option value="15" class="select-dropdown__list-item">15 Minutos</option>
							  <option value="16" class="select-dropdown__list-item">16 Minutos</option>
							  <option value="17" class="select-dropdown__list-item">17 Minutos</option>
							  <option value="18" class="select-dropdown__list-item">18 Minutos</option>
							  <option value="19" class="select-dropdown__list-item">19 Minutos</option>
							  <option value="20" class="select-dropdown__list-item">20 Minutos</option>
							  <option value="21" class="select-dropdown__list-item">21 Minutos</option>
							  <option value="22" class="select-dropdown__list-item">22 Minutos</option>
							  <option value="23" class="select-dropdown__list-item">23 Minutos</option>
							  <option value="24" class="select-dropdown__list-item">24 Minutos</option>
			  
							  <option value="25" class="select-dropdown__list-item">25 Minutos</option>
							  <option value="26" class="select-dropdown__list-item">26 Minutos</option>
							  <option value="27" class="select-dropdown__list-item">27 Minutos</option>
							  <option value="28" class="select-dropdown__list-item">28 Minutos</option>
							  <option value="29" class="select-dropdown__list-item">29 Minutos</option>
							  <option value="30" class="select-dropdown__list-item">30 Minutos</option>
							  <option value="31" class="select-dropdown__list-item">31 Minutos</option>
							  <option value="32" class="select-dropdown__list-item">32 Minutos</option>
							  <option value="33" class="select-dropdown__list-item">33 Minutos</option>
							  <option value="34" class="select-dropdown__list-item">34 Minutos</option>
							  <option value="35" class="select-dropdown__list-item">35 Minutos</option>
							  <option value="36" class="select-dropdown__list-item">36 Minutos</option>
							  <option value="37" class="select-dropdown__list-item">38 Minutos</option>
							  <option value="39" class="select-dropdown__list-item">39 Minutos</option>
							  <option value="40" class="select-dropdown__list-item">40 Minutos</option>
							  <option value="41" class="select-dropdown__list-item">41 Minutos</option>
							  <option value="42" class="select-dropdown__list-item">42 Minutos</option>
							  <option value="43" class="select-dropdown__list-item">43 Minutos</option>
							  <option value="44" class="select-dropdown__list-item">44 Minutos</option>
							  <option value="45" class="select-dropdown__list-item">45 Minutos</option>
							  <option value="46" class="select-dropdown__list-item">46 Minutos</option>
							  <option value="47" class="select-dropdown__list-item">47 Minutos</option>
							  <option value="48" class="select-dropdown__list-item">49 Minutos</option>
							  <option value="49" class="select-dropdown__list-item">49 Minutos</option>
							  <option value="50" class="select-dropdown__list-item">50 Minutos</option>
							  <option value="51" class="select-dropdown__list-item">51 Minutos</option>
							  <option value="52" class="select-dropdown__list-item">52 Minutos</option>
							  <option value="53" class="select-dropdown__list-item">53 Minutos</option>
							  <option value="54" class="select-dropdown__list-item">54 Minutos</option>
							  <option value="55" class="select-dropdown__list-item">55 Minutos</option>
							  <option value="56" class="select-dropdown__list-item">56 Minutos</option>
							  <option value="57" class="select-dropdown__list-item">57 Minutos</option>
							  <option value="58" class="select-dropdown__list-item">58 Minutos</option>
							  <option value="59" class="select-dropdown__list-item">59 Minutos</option>	 
							 </select>
						</td>
					</tr>
					</table>
				</div>
				<div class="right col">
					  <uc1:DataOP1 runat="server" id="DataOP5" />			
			   </div>
			</div>
		</div>
	</div>

	<div class="card" id="twitter2" >
		
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
	<a class="card-toggle" href="login.aspx"  style="width:90%;text-align:right;"><i><span class="fa fa-sign-out" style="width:200px;color:black;font-size:21px;">Log out</span></i></a>
</div>

<%--MODAL OP--%>

<div id="mask"></div>
<div class="modal">
	<a class="close-modal" href="javascript:void(0)">
	<i class="fa fa-times"></i>
	</a>
	<div>
		<span>Seleccione el tipo de parada:</span>
		<select id="SelectParadas" class="select-css" style="width:100%;">
                    <option value="30">Parada Minima</option>
                    <option value="45">Parada Media</option>
                    <option value="60">Parada por mantenimiento</option>
         </select>
		<br />
		<input class="btn" type="button" value="Parar" onclick="EjecutarParada();" style="background-color:#ff0000; color:#ffffff;  font-size:30px;border-radius:5px; width:100%;">
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
					<input class="btn" type="button" value="Reiniciar" onclick="EjecutarReinicioDeParada();" style="background-color:#ff0000; color:#ffffff;  font-size:15px;border-radius:5px; width:100%;">
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

       
       
        //var Bar = document.getElementById('bar-1');
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

        //var Bar2 = document.getElementById('bar-2');
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

        //var Bar3 = document.getElementById('bar-3');
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

        OPResgistradasSelect();					
	</script>


</body>
</html>

