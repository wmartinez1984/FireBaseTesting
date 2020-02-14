<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activos.aspx.cs" Inherits="FireBaseTesting.ActivosFinancieros.Activos" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <title>Activos Financieros</title>
  <meta content="width=device-width, initial-scale=1.0" name="viewport">
  <meta content="" name="keywords">
  <meta content="" name="description">
  

  <!-- Favicons -->
  <link href="img/favicon.png" rel="icon">
  <link href="img/apple-touch-icon.png" rel="apple-touch-icon">

  <!-- Google Fonts -->
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Roboto:100,300,400,500,700|Philosopher:400,400i,700,700i" rel="stylesheet">

  <!-- Bootstrap css -->
  <!-- <link rel="stylesheet" href="css/bootstrap.css"> -->
  <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Libraries CSS Files -->
  <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
  <link href="lib/owlcarousel/assets/owl.theme.default.min.css" rel="stylesheet">
  <link href="lib/font-awesome/css/font-awesome.min.css" rel="stylesheet">
  <link href="lib/animate/animate.min.css" rel="stylesheet">
  <link href="lib/modal-video/css/modal-video.min.css" rel="stylesheet">

  <!-- Main Stylesheet File -->
  <link href="css/style.css" rel="stylesheet">
  <link href="css/botones.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" />

 <%--NECESARIOS PARA EJECUTAR AJAX,  JSON--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
	<script src="ACTFData.js"></script>
     
    <%--NECESARIOS PARA  MENSAJES DEL SISTEMA--%>
    <script src="js/sweetalert-dev.js"></script>
	<link href="css/sweetalert.css" rel="stylesheet" />
</head>

<body onload="ActivosRegistradosList();">

  <header id="header" class="header header-hide">
    <div class="container">

      <div id="logo" class="pull-left">
        <h1><a href="#body" class="scrollto"><span>A</span>Ctivos</a> Financieros</h1>
        <!-- Uncomment below if you prefer to use an image logo -->
        <!-- <a href="#body"><img src="img/logo.png" alt="" title="" /></a>-->
      </div>

      <nav id="nav-menu-container">
        <ul class="nav-menu">
          <li><a href="Home.aspx">Home</a></li>
          <li><a href="Simulador.aspx">Simulador</a></li>
          <li class="menu-active"><a href="Activos.aspx">Mis Activos</a></li>
          <li><a href="ApiKey.aspx">Api Key</a></li>
          <li><a href="#features">Reportes</a></li>
          <li><a href="login.aspx">Salir</a></li>
        
        </ul>
      </nav><!-- #nav-menu-container -->
    </div>
  </header><!-- #header -->

<br />
<br />
  <!--==========================
    Form Section
  ============================-->

    <link
     href="https://fonts.googleapis.com/css?family=Montserrat"
   rel="stylesheet"/>
        <div class="wrapper">
          <div class="container">
            <h1>Registrar Activos Financieros</h1>

            <br />
            <form>

              <div class="form-row">
                <div class="form-group col-md-12">
                  <label for="inputPassword4">Nombre del Activo</label>
                  <input type="text" class="form-control" id="txtActivo"  value="" style="width:300px;"/>
                   <button id="myBtn">Agregar</button>
                  <div class="line"></div>
                </div>
              </div>
               
              <p style="width:100%;text-align:right;">
                 
              </p>

                <div class="bs-example container" data-example-id="striped-table">
                  <table class="table table-striped table-bordered table-hover" id="TableActivosRegistrados" style="width:100%;">
                    <thead>
                        <tr style="background-color:#71c55d;">
                            <th style="text-align:center;">Símbolo</th>
                            <th style="text-align:center;">Nombre</th>
                            <th style="text-align:center;">Tipo</th>
                            <th style="text-align:center;">Región</th>
                            <th style="text-align:center;">Mercado Abierto</th>
                            <th style="text-align:center;">Mercado Cerrado</th>
                            <th style="text-align:center;">Zona Horaria</th>
                            <th style="text-align:center;">Moneda</th>
                            <th style="text-align:center;">Puntuación</th>
                            <th style="text-align:center;">Opciones</th>
                        </tr>
                    </thead>
                    <tbody>
                    
                    </tbody>
                    <tfoot>
            
                    </tfoot>
                 </table>
                </div>


            </form>
          </div>
        </div>


  <!--==========================
    Hero Section
  ============================-->
  <section id="hero" class="wow fadeIn">
    <div class="hero-container">
      <h1>Activos Financieros</h1>
      <img src="img/hero-img.png" alt="Hero Imgs">
      
    </div>
  </section><!-- #hero -->

  <!--==========================
    Footer
  ============================-->
  <footer class="footer">
    <div class="container">
      <div class="row">

        <div class="col-md-12 col-lg-4">
          <div class="footer-logo">

            <a class="navbar-brand" href="#">Activos Financieros</a>
            <p>
                Texto de ejemplo
            </p>

          </div>
        </div>

    <%--    <div class="col-sm-6 col-md-3 col-lg-2">
          <div class="list-menu">

            <h4>Abou Us</h4>

            <ul class="list-unstyled">
              <li><a href="#">About us</a></li>
              <li><a href="#">Features item</a></li>
              <li><a href="#">Live streaming</a></li>
              <li><a href="#">Privacy Policy</a></li>
            </ul>

          </div>
        </div>--%>

       

      </div>
    </div>

    <div class="copyrights">
      <div class="container">
        <p>&copy; Todos los derechos reservados - Activos Financieros 2020.</p>
        <div class="credits">
        
        </div>
      </div>
    </div>

  </footer>

  <!-- The Modal -->
<div id="myModal" class="modal">

  <!-- Modal content -->
  <div class="modal-content">
   <p style="width:100%;text-align:right;">
       <span  class="close">&times;</span>
   </p> 
   <p>
      <strong>
          Seleccione y guarde el Activo que desea dar de alta
      </strong> 
   </p>
      <h3 id="message"></h3>
     <table class="table table-striped table-bordered table-hover" id="TableActivos">
        <thead>
            <tr>
                <th style="text-align:center;">Símbolo</th>
                <th style="text-align:center;">Nombre</th>
                <th style="text-align:center;">Tipo</th>
                <th style="text-align:center;">Región</th>
                <th style="text-align:center;">Mercado Abierto</th>
                <th style="text-align:center;">Mercado Cerrado</th>
                <th style="text-align:center;">Zona Horaria</th>
                <th style="text-align:center;">Moneda</th>
                <th style="text-align:center;">Puntuación</th>
                <th style="text-align:center;">Guadar</th>
            </tr>
        </thead>
        <tbody>
                    
        </tbody>
        <tfoot>
            
        </tfoot>
     </table>
  </div>

</div>

  <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>

  <!-- JavaScript Libraries -->
  <script src="lib/jquery/jquery.min.js"></script>
  <script src="lib/jquery/jquery-migrate.min.js"></script>
  <script src="lib/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="lib/superfish/hoverIntent.js"></script>
  <script src="lib/superfish/superfish.min.js"></script>
  <script src="lib/easing/easing.min.js"></script>
  <script src="lib/modal-video/js/modal-video.js"></script>
  <script src="lib/owlcarousel/owl.carousel.min.js"></script>
  <script src="lib/wow/wow.min.js"></script>
  <!-- Contact Form JavaScript File -->
  <script src="contactform/contactform.js"></script>

  <!-- Template Main Javascript File -->
  <script src="js/main.js"></script>
  
 <script>
     function checkValue(element) {
         // check if the input has any value (if we've typed into it)
         if ($(element).val()) $(element).addClass("has-value");
         else $(element).removeClass("has-value");
     }

     $(document).ready(function () {
         // Run on page load
         $(".form-control").each(function () {
             checkValue(this);
         });
         // Run on input exit
         $(".form-control").blur(function () {
             checkValue(this);
         });
     });

 </script>

<style>
    /* The Modal (background) */
    .modal {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 1; /* Sit on top */
        padding-top: 100px; /* Location of the box */
        left: 0;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgb(0,0,0); /* Fallback color */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }

    /* Modal Content */
    .modal-content {
        background-color: #fefefe;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 70%;
    }

    /* The Close Button */
    .close {
        color: #aaaaaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }

    .close:hover,
    .close:focus {
        color: #000;
        text-decoration: none;
        cursor: pointer;
    }
</style>
<script>
    // Get the modal
    var modal = document.getElementById("myModal");

    // Get the button that opens the modal
    var btn = document.getElementById("myBtn");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks the button, open the modal 
    btn.onclick = function () {
        if (document.getElementById('txtActivo').value != "") {
            ActivoList(document.getElementById('txtActivo').value);
            modal.style.display = "block";
        }           
        else
            swal('Mensaje', 'Debe capturar el Activo a buscar', 'warning');

        return false;
    }

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
</script>
</body>
</html>




