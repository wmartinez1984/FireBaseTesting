<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="FireBaseTesting.Temporizadores.Data" %>

<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>Operaciones</title>

	<style>

	</style>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
	<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css'><link rel="stylesheet" href="./style.css">

	<link href="css/sweetalert.css" rel="stylesheet" />
	<script src="js/sweetalert-dev.js"></script>

	<link rel="shortcut icon" href="favicon.ico">
	<link rel="stylesheet" type="text/css" href="css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.3.0/css/font-awesome.min.css" />
	<link rel="stylesheet" type="text/css" href="css/demo.css" />
	<link rel="stylesheet" type="text/css" href="css/component.css" />
	<link rel="stylesheet" type="text/css" href="css/custom-bars.css" />


	

</head>
<body>

<div class="cards">
	
	<div class="contact">Configuración de Operación</div>
	<div class="contact-form">
		<a href="#" class="close"><i class="fa fa-times"></i></a>
		<form>
			<div class="control">
				<span class="open-modal">
				   <i ><span class="fa fa-calendar-check-o" style="color:#808080; width:230px; font-size:17px;">+ Programación de OP</span></i>
				</span>
			</div>		

			<div class="control">
				<span>
				   <i ><span class="fa fa-life-ring" style="color:#808080; width:330px; font-size:27px;">Datos de la OP Actual</span></i>
				</span>
			</div>	

			<div class="control">
				<p>
				Consultar OP: 
				</p>
				<p>
					OP: 
				</p>
				<p>
					Producto: 
				</p>
				<p>
					Kilógramos: 
				</p>
				<p>
					..............: 
				</p>
			</div>	
			
			<br /><br />
			<div class="control submit" onclick="swal('Datos correctos', 'Los datos ingresados son correctos, puede continuar...', 'success');"><input type="submit" /></div>
		</form>
	</div>

	 <div class="card active" id="overview">
		<a class="card-toggle" >Inicio <i class="fa fa-arrow-circle-left"></i></a>
		<div class="card-content">			
			<div class="row">
				<div class="left col" style="text-align:left;">					
				  <h3 style="color:#1d4189;font-size:30px;"><strong>Líneas de producción</strong> </h3>							
				  <div class="progress-factor flexy-item" style="width:500px;margin-top:-55px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors navy ruler" role="progressbar" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100" id="bar-0_0">
								<div class="tooltip white"></div>
								<div class="bar-face face-position roof percentage"></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position right"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position front percentage volume-lights shine"></div>
							</div>
						</div>
					</div>

					<div class="progress-factor flexy-item" style="width:500px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors orange ruler-3" role="progressbar" aria-valuenow="64" aria-valuemin="0" aria-valuemax="100">
								<div class="tooltip white"></div>
								<div class="bar-face face-position roof percentage"></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position right"></div>
								<div class="bar-face face-position front percentage volume-lights shine"></div>
							</div>
						</div>
					</div>
					
					<div class="progress-factor flexy-item" style="width:500px;">
						<div class="progress-bar" >
							<div class="bar has-rotation has-colors navy ruler" role="progressbar" aria-valuenow="95" aria-valuemin="0" aria-valuemax="100">
								<div class="tooltip"></div>
								<div class="bar-face face-position roof percentage"></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position right"></div>
								<div class="bar-face face-position front percentage volume-lights shine"></div>
							</div>
						</div>
				  </div>			
				
				</div>

				<div class="right col" style="text-align:center;border-left:dashed;border-color:#1d4189; border-width:10px;">					
						<h3><strong style="color:#ff6a00;font-size:30px;">Datos de OP Actual</strong> </h3>	
					   <h2><strong style="color:#186635">.....</strong> </h2>	
					
				</div>
			</div>
		</div>
	</div> 
	
	<div class="card" id="dribbble">
		<a class="card-toggle"><i><span class="fa fa-list"></span></i></a>
		<div class="card-content">
			<div class="row">
				<div class="left col" style="text-align:left;">
					<h3>Línea <strong>No 1</strong></h3>				
					 <div class="progress-factor flexy-item" style="width:100px;">
						<div class="progress-bar">
								<div class="bar has-rotation has-colors navy ruler" role="progressbar" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100" id="bar-0_L1">
									<div class="tooltip white"></div>
									<div class="bar-face face-position roof percentage"></div>
									<div class="bar-face face-position back percentage"></div>
									<div class="bar-face face-position floor percentage volume-lights"></div>
									<div class="bar-face face-position right"></div>
									<div class="bar-face face-position left"></div>
									<div class="bar-face face-position front percentage volume-lights shine"></div>
								</div>
						</div>
					</div>
					<br /><br />
					<span style="color:white;font-size:30px;"> <strong>Paradas</strong> </span> <br />
					<span style="color:white;font-size:30px;"> <strong>....</strong> </span>
				</div>

				<div class="right col">
					<span style="color:white;font-size:30px;"> <strong>Datos</strong> </span><br />
					<span style="color:white;font-size:30px;"> <strong>....</strong> </span>
				</div>
				
			</div>
		</div>

	</div> 
	
	<div class="card" id="behance">
		<a class="card-toggle"><i><span class="fa fa-list"></span></i></a>
		<div class="card-content">
			<div class="row">
				<div class="left col">
					<h3>Línea <strong>No 2</strong></h3>
					<div class="progress-factor flexy-item" style="width:100px;">
						<div class="progress-bar">
							<div class="bar has-rotation has-colors orange ruler-3" role="progressbar" aria-valuenow="64" aria-valuemin="0" aria-valuemax="100">
								<div class="tooltip white"></div>
								<div class="bar-face face-position roof percentage"></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position right"></div>
								<div class="bar-face face-position front percentage volume-lights shine"></div>
							</div>
						</div>
					</div>
					<br /><br />
					<span style="color:white;font-size:30px;"> <strong>Paradas</strong> </span> <br />
					<span style="color:white;font-size:30px;"> <strong>....</strong> </span>
				</div>
				<div class="right col">
				   <span style="				           color: white;
				           font-size: 30px;"> <strong>Datos</strong> </span><br />
					<span style="color:white;font-size:30px;"> <strong>....</strong> </span>
				</div>
			</div>
		</div>
	</div>

	<div class="card" id="linkedin">
		<a class="card-toggle"><i><span class="fa fa-list"></span></i></a>
		<div class="card-content">
			<div class="row">
				<div class="left col">
				<h3>Línea <strong>No 3</strong></h3>
				    <div class="progress-factor flexy-item" style="width:100px;">
						<div class="progress-bar" >
							<div class="bar has-rotation has-colors navy ruler" role="progressbar" aria-valuenow="95" aria-valuemin="0" aria-valuemax="100">
								<div class="tooltip"></div>
								<div class="bar-face face-position roof percentage"></div>
								<div class="bar-face face-position back percentage"></div>
								<div class="bar-face face-position floor percentage volume-lights"></div>
								<div class="bar-face face-position left"></div>
								<div class="bar-face face-position right"></div>
								<div class="bar-face face-position front percentage volume-lights shine"></div>
							</div>
						</div>
				    </div>
					<br /><br />
					<span style="color:white;font-size:30px;"> <strong>Paradas</strong> </span> <br />
					<span style="color:white;font-size:30px;"> <strong>....</strong> </span>
				</div>
				<div class="right col">
					 <span style="color:white;font-size:30px;"> <strong>Datos</strong> </span><br />
					<span style="color:white;font-size:30px;"> <strong>....</strong> </span>
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
				<div class="right col"><img src="https://dl.dropboxusercontent.com/u/26808427/cdn/preview.jpg" alt="" /></div>
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
	<div class="modal-content">
		
		<table>
			<tr>
				
				<td colspan="3" style="text-align:left;">
					<div class="searchBox" style="">
					  <input class="searchInput" type="text" name="" placeholder="Consultar" />
					  <button class="searchButton" href="#">
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
					
						OP consultada: 
					
				</td>
				<td colspan="2">
				
				</td>
			</tr>
			<tr>
				<td>
					
						Producto: 
					
				</td>
				<td colspan="2">
				
				</td>
			</tr>

			<tr>
				<td>
					
						Kilógramos: 
					
				</td>
				<td colspan="2">
					
				</td>
			</tr>

			<tr>
				<td>
					
						NAVI: 
					
				</td>
				<td colspan="2">
				
				</td>
			</tr>

		</table>
		
			<table>
				
				<tr>
					<td>
						<div class="control"><label for="message">Tipo de Lavado</label></div>
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
				<tr>
					<td colspan="3" style="text-align:left; ">
						<br />
						<i onclick="swal('OP Agregada', 'Se agregó correctamente la OP a la Cola de producción', 'success');">
							<span class="fa fa-save" style="font-size:20px;cursor:pointer; " ">Agregar</span>

						</i>
					</td>
				</tr>
			</table>
			
		   
			 <script>
				 function CambiarLavado() {

					 document.getElementById('spLavado').innerHTML = document.getElementById('normal-select-7').value + " Minutos";
				 }
			 </script>
		  
		
		<br />
		<table class="fl-table" style="width:100%;">
			<thead>
			<tr>
				<th>OP</th>
				<th>Producto</th>
				<th>Kilógramos</th>
				<th>NAVI</th>
				<th>Lavado programado</th>
				<th>Estatus OP</th>
				<th>Opciones</th>
			</tr>
			</thead>
			<tbody>
			<tr>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>Pendiente</td>
				<td>
					<a style="cursor:pointer;">
						<i>
							<span class="fa fa-edit">Editar</span>

						</i>
				    </a>
				</td>
			</tr>
			<tr>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>Envasando</td>
				<td>
					<a style="cursor:pointer;">
						<i>
							<span class="fa fa-edit">Editar</span>

						</i>
				    </a>
				</td>
			</tr>
			<tr>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>DATA TEST 1</td>
				<td>Terminada</td>
				<td>
					<a style="cursor:pointer;">
						<i>
							<span class="fa fa-edit">Editar</span>

						</i>
				    </a>
				</td>
			</tr>
        
       
			<tbody>
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


	</script>


</body>
</html>
