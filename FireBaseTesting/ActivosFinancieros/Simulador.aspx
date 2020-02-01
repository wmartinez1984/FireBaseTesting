<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simulador.aspx.cs" Inherits="FireBaseTesting.ActivosFinancieros.Simulador" %>

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
        <h1><a href="#body" class="scrollto"><span>A</span>Ctivos</a> Financieros</h1>
        <!-- Uncomment below if you prefer to use an image logo -->
        <!-- <a href="#body"><img src="img/logo.png" alt="" title="" /></a>-->
      </div>

      <nav id="nav-menu-container">
        <ul class="nav-menu">
          <li class="menu-active"><a href="Home.aspx">Home</a></li>
          <li><a href="Simulador.aspx">Simulador</a></li>
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
            <h1>Cargar Simulación</h1>
            <br />
            <form>

              <div class="form-row">
                <div class="form-group col-md-6">
                   <label for="inputEmail4">Activo</label>
                   <select id="SelectActivo" class="form-control">
                    <option selected>Choose...</option>
                    <option> Option 1</option>
                    <option> Option 2</option>
                  </select>
                  
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                  <label for="inputPassword4">Capital Inicial</label>
                  <input type="text" class="form-control" id="txtCapitalIncial"  value="10000"/>
                  
                  <div class="line"></div>
                </div>
              </div>
                            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Tipo de estrategia</label>
                   <select id="SelectTipoEstrategia" class="form-control">
                    <option selected>Seleccione</option>
                    <option>Largo</option>
                    <option>Corto</option>
                    
                  </select>
                  
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                
                </div>
              </div>
              
              
              <div class="form-row">
                <div class="form-group col-md-6">
                  <label for="inputEmail4">Indicador</label>
                   <select id="SelectIndicador" class="form-control">
                    <option selected>Seleccione</option>
                    <option>EMA</option>
                    <option>SMA</option>
                    <option>WMA</option>
                    <option>VWAP</option>
                  </select>
                  
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                  <label for="inputPassword4">Cantida de resultados a Mostrar</label>
                  <input type="text" class="form-control" id="txtCantidadResultados"  value="50"/>
                  
                  <div class="line"></div>
                </div>
              </div>

             <div class="form-row">
                <div class="form-group col-md-6">
                   <label for="inputEmail4">Temporalidad de la gráfica</label>
                   <select id="SelectTemporalidad" class="form-control">
                    <option selected="selected">Diario</option>
                    <option>Mensual</option>
                    <option>Semanal</option>                    
                  </select>
                  
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                   <label for="inputPassword4">Valor comisión Entrada(%)</label>
                  <input type="text" class="form-control" id="txtValorComisionEntrada" value="0.5" />
                  
                  <div class="line"></div>
                </div>
              </div>

              <div class="form-row">
                <div class="form-group col-md-6">
                  <label for="inputPassword4">Sesiones</label>
                  <input type="text" class="form-control" id="txtSesiones" />
                  
                  
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                  <label for="inputPassword4">Valor Comisión Salida(%)</label>
                  <input type="text" class="form-control" id="txtValorComisionSalida"  value="0.5"/>                  
                  <div class="line"></div>
                </div>
              </div>

              <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Tipo de precio</label>
                   <select id="SelectTipoPrecio" class="form-control">
                    <option selected>Seleccione</option>
                    <option>Cierre</option>
                    <option>Apertura</option>
                    <option>Máximo</option>
                    <option>Mínimo</option>
                  </select>
                  
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                
                </div>
              </div>
              
             <div class="form-row">
                <div class="form-group col-md-6">
                  <label for="inputPassword4">MM Rápida Inicial</label>
                  <input type="text" class="form-control" id="txtRapidaInicial" value="2" />
                  
                  
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                  <label for="inputPassword4">MM Rápida Final</label>
                  <input type="text" class="form-control" id="txtRapidaFinal" value="15"/>                  
                  <div class="line"></div>
                </div>
              </div>

             <div class="form-row">
                <div class="form-group col-md-6">
                  <label for="inputPassword4">MM Lenta inicial</label>
                  <input type="text" class="form-control" id="txtMMLenta" value="16" />
                  
                  
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                  <label for="inputPassword4">MM Lenta Final</label>
                  <input type="text" class="form-control" id="txtMMLentaFinal" value="60"/>                  
                  <div class="line"></div>
                </div>
              </div>


                <p><button class="w3-button w3-block w3-teal">Iniciar</button></p>
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
            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the.</p>

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
</body>
</html>


