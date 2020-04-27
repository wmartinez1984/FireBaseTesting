<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Privatedashboard.aspx.cs" Inherits="FireBaseTesting.Admin.Privatedashboard" %>


<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <title>Panel Privado</title>
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

  <!-- =======================================================
    Theme Name: eStartup
    Theme URL: https://bootstrapmade.com/estartup-bootstrap-landing-page-template/
    Author: BootstrapMade.com
    License: https://bootstrapmade.com/license/
  ======================================================= -->
</head>

<body>

  <header id="header" class="header header-hide">
    <div class="container">

      <div id="logo" class="pull-left">
        <h1><a href="#body" class="scrollto"><span>S</span>istema</a> de <span>S</span>eguimiento</h1>
        <!-- Uncomment below if you prefer to use an image logo -->
        <!-- <a href="#body"><img src="img/logo.png" alt="" title="" /></a>-->
      </div>

      <nav id="nav-menu-container">
        <ul class="nav-menu">
          <li class="menu-active"><a href="#hero">Home</a></li>
          <li><a href="#">FO-SST-82</a></li>
          <li><a href="#">FO-SST-83</a></li>
          <li><a href="#">FO -SST-84</a></li>
          <li><a href="#">Reportes</a></li>
          <li><a href="login.aspx">Salir</a></li>
        
        </ul>
      </nav><!-- #nav-menu-container -->
    </div>
  </header><!-- #header -->

  <!--==========================
    Hero Section
  ============================-->
  <section id="hero" class="wow fadeIn">
    <div class="hero-container">

      <h1 style="color:#808080">Administración de datos</h1>      
      <img src="img/hero-img.png" alt="Hero Imgs"> 
        
    </div>
  </section><!-- #hero -->

  <!--==========================
    Get Started Section
  ============================-->
  <section id="get-started" class="padd-section text-center wow fadeInUp">

    <div class="container">
      <div class="section-title text-center">

        <h2>Opciones del Sistema</h2>
        <p class="separator"> Seleccione una de las siguientes opciones </p>

      </div>
    </div>

    <div class="container">
      <div class="row">

        <div class="col-md-6 col-lg-4" style="cursor:pointer;">
          <div class="feature-block">

            <img src="img/vitrine.png" alt="img" class="img-fluid">
            <h4>
                ENCUESTA DE INGRESO  POSIBLES SÍNTOMAS DEL VIRUS SARS-CoV-2, INFORMACIÓN SOBRE FECTORES DE RIESGO PARA EL COVID-19
            </h4>
            <p>En esta sección podrá capturar la información de este formato </p>
            <a href="#">Ingresar</a>

          </div>
        </div>

         <div class="col-md-6 col-lg-4" style="cursor:pointer;">
          <div class="feature-block">

            <img src="img/vitrine.png" alt="img" class="img-fluid">
            <h4>
                FORMATO SEGUIMIENTO JORNADAS DE DESINFECCION 
            </h4>
            <p>En esta sección podrá capturar la información de este formato </p>
            <a href="#">Ingresar</a>

          </div>
        </div>

        <div class="col-md-6 col-lg-4" style="cursor:pointer;">
          <div class="feature-block">

            <img src="img/vitrine.png" alt="img" class="img-fluid">
            <h4>
                MATRIZ DE SEGUIMIENTO CASOS POSITIVO PARA COVID-19
            </h4>
            <p>En esta sección podrá capturar la información de este formato </p>
            <a href="#">Ingresar</a>

          </div>
        </div>

      </div>
    </div>

  </section>





  <!--==========================
    Footer
  ============================-->
  <footer class="footer">
    <div class="container">
      <div class="row">

        <div class="col-md-12 col-lg-4">
          <div class="footer-logo">

            <a class="navbar-brand" href="#">Administración de datos</a>
            <p>

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
        <p>&copy; Todos los derechos reservados - Asdelogy 2020.</p>
        <div class="credits">
        
        </div>
      </div>
    </div>

  </footer>



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

</body>
</html>

