<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Temporizador.aspx.cs" Inherits="FireBaseTesting.Temporizadores.Temporizador" %>

<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title>Temporizador</title>
  <link rel="stylesheet" href="css/Timer.css">

</head>
<body>
<!-- partial:index.partial.html -->
	<p style="color:#ff6a00">Línea de producción </p>

	<div  class="divCard">
		<div style="">
		 <div class="shadow">

		 </div>
			<div class="card">
				<div>
				
					<div class="card__overlay"></div>
					<div class="card__button" id="btnstart"></div>
					<div class="card__counter">
			
						<div id="num" class="card__counter__num">
							5
						</div>
			

					</div>		
				</div>	
			</div>
	  </div>
	</div>
		
<!-- partial -->
  <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
  <script src='https://cdnjs.cloudflare.com/ajax/libs/react/0.13.0/react.min.js'></script>
  <script src="js/Timer.js"></script>
</body>
</html>
