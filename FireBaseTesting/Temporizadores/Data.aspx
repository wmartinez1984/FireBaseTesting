<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="FireBaseTesting.Temporizadores.Data" %>

<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>Operaciones</title>
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
<%--	 onload="swal('Bienvenido', 'Los datos ingresados son correctos, puede continuar...', 'success');"--%>
<!-- partial:index.partial.html -->
<div class="cards">
	
	<div class="contact">Datos de Operación</div>
	<div class="contact-form">
		<a href="#" class="close"><i class="fa fa-times"></i></a>
		<form>
			<div class="control"><input type="text"  id="name"/><label for="name">OP Actual</label></div>
			<div class="control"><input type="text"  id="email"/><label for="email">Lavado</label></div>
			<div class="control"><input type="text"  id="url"/><label for="url">NNN</label></div>
			<div class="control"><textarea name="" id="message"></textarea><label for="message">NNN</label></div>
			<div class="control submit" onclick="swal('Datos correctos', 'Los datos ingresados son correctos, puede continuar...', 'success');"><input type="submit" /></div>
		</form>
	</div>

	 <div class="card active" id="overview">
		<a class="card-toggle" >Inicio <i class="fa fa-arrow-circle-left"></i></a>
		<div class="card-content">			
			<div class="row">
				<div class="left col" style="text-align:center;">					
				  <h2 style="color:#1d4189;"><strong>Líneas de producción</strong> </h2>							
				  <div class="progress-factor flexy-item" style="width:500px;">
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

				<div class="right col" style="text-align:center;">					
						<h2><strong style="color:#186635">Datos</strong> </h2>	
					<h2><strong style="color:#186635">.....</strong> </h2>	
					
				</div>
			</div>
		</div>
	</div> 
	
	<div class="card" id="dribbble">
		<a class="card-toggle"><i><span class="fa fa-list"></span></i></a>
		<div class="card-content">
			<div class="row">
				<div class="left col">
					<h2>Línea <strong>No 1</strong></h2>				
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
					<h2>Línea <strong>No 2</strong></h2>
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
				   <span style="color:white;font-size:30px;"> <strong>Datos</strong> </span><br />
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
				<h2>Línea <strong>No 3</strong></h2>
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
					<h2>Datos de <strong> Incio y finalización de operación</strong></h2>
				
					<p>Fugit veniam, animi architecto doloribus veritatis vitae sint doloremque possimus quae. Pariatur libero, veniam voluptatibus alias distinctio qui nostrum debitis voluptate amet hic repellat officiis nam quos vel doloremque praesentium.</p>
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
		// $("#change-color .bar").click(function(){
		//     $(this).toggleClass('sleep');
		// });
	</script>

</body>
</html>
