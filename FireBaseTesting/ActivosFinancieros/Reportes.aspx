<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="FireBaseTesting.ActivosFinancieros.Reportes" %>


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
<%--  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Roboto:100,300,400,500,700|Philosopher:400,400i,700,700i" rel="stylesheet">--%>

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
<%--	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>--%>

	<script src="ACTFDatav2.js"></script>
     


    <%--NECESARIOS PARA  MENSAJES DEL SISTEMA--%>
    <script src="js/sweetalert-dev.js"></script>
	<link href="css/sweetalert.css" rel="stylesheet" />

    <style>
        table {
          border-collapse: collapse;
          border-spacing: 0;
          width: 100%;
          border: 1px solid #ddd;
        }

        th, td {
          text-align: left;
          padding: 8px;
        }

        tr:nth-child(even){background-color: #f2f2f2}


   </style>

</head>

<body onload="ResultadosList();">

   
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
          <li><a href="Activos.aspx">Mis Activos</a></li>
          <li><a href="ApiKey.aspx">Api Key</a></li>
          <li  class="menu-active"><a href="Reportes.aspx">Reportes</a></li>
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

 
          <div class="container" style="width:100%;">
            <h2 style="color:#71c55d;">Histórico  de consultas realizadas</h2>

            <br />
            <form>

             
               
              <p style="width:100%;text-align:right;">
                 
              </p>

                <div class="bs-example container" data-example-id="striped-table">
                <div style="overflow-x:auto;">
                 
                  <table class="table table-striped table-bordered table-hover" id="TableActivosRegistrados" style="width:100%;">
                    <thead>
                        <tr>
                            <th style="text-align:center;">Detalle</th>
                            <th style="text-align:center;">Eliminar</th>
                            <th style="text-align:center;">Fecha</th>
                            <th style="text-align:center;">Activo</th>
                            <th style="text-align:center;">Estrategia</th>
                            <th style="text-align:center;">Sesiones</th>
                            <th style="text-align:center;">Indicador</th>
                            <th style="text-align:center;">Temporalidad</th>
                            <th style="text-align:center;">T.Precio</th>
                            <th style="text-align:center;">C.Inicial</th>
                            <th style="text-align:center;">resultados</th>
                            <th style="text-align:center;">C.Entrada</th>
                            <th style="text-align:center;">C.Salida</th>
                            
                        </tr>
                    </thead>
                    <tbody>
                    
                    </tbody>
                    <tfoot>
            
                    </tfoot>
                 </table>
                </div>
                </div>


            </form>
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
<div id="myModal" class="modal" >

  <!-- Modal content -->
  <div class="modal-content"  style="width:95%;margin-top:-40px;">
   <p style="width:100%;text-align:right;">
       <span  class="close">&times;</span>
   </p> 
  
      <h3 id="message"></h3>
<%--    <script>
        function CargarTabla() {
            $("#TableActivos").DataTable();
        }
    </script>
      <input id="Button1" type="button" value="button" onclick="CargarTabla();" />--%>
    <div class="bs-example container" data-example-id="striped-table">
     
     <div  style="overflow-x:auto;">
     <h3 id="hmensaje" style="color:#ff6a00"></h3>
     <table class="table table-striped table-bordered table-hover" id="TableActivos">
        <thead>
            <tr>
                <th style="text-align:center;">Señal</th>
                <th style="text-align:center;">C.días</th>
                <th style="text-align:center;">Días.fuera</th>
                <th style="text-align:center;">Días.dentro</th>
                <th style="text-align:center;">Cant.total.OP</th>
                <th style="text-align:center;">Cant.total.OP.Ganadoras</th>
                <th style="text-align:center;">Cant.total.OP.Perdedoras</th>
                <th style="text-align:center;">Ganancia.Máxima</th>
                <th style="text-align:center;">Perdida.Máxima</th>
                <th style="text-align:center;">Perf.Total</th>
                <th style="text-align:center;">Perf.Anualizada</th>
                <th style="text-align:center;">Perf.Buy&Hold</th>
                <th style="text-align:center;">Perf.Buy&Hold.Anualizada</th>
                <th style="text-align:center;">EM</th>
                <th style="text-align:center;">Racha.Ganadora</th>
                <th style="text-align:center;">Racha.Perdedora</th>

            </tr>
        </thead>
        <tbody>
              <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>

                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>

                <td></td>
                <td></td>
                <td></td>


            </tr>       
        </tbody>
        <tfoot>
            
        </tfoot>
     </table>
    </div>
  </div>
  </div>

</div>

  <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>

  <!-- JavaScript Libraries -->
<%--  <script src="lib/jquery/jquery.min.js"></script>
  <script src="lib/jquery/jquery-migrate.min.js"></script>
  <script src="lib/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="lib/superfish/hoverIntent.js"></script>
  <script src="lib/superfish/superfish.min.js"></script>
  <script src="lib/easing/easing.min.js"></script>
  <script src="lib/modal-video/js/modal-video.js"></script>
  <script src="lib/owlcarousel/owl.carousel.min.js"></script>
  <script src="lib/wow/wow.min.js"></script>
  <!-- Contact Form JavaScript File -->
  <script src="contactform/contactform.js"></script>--%>

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
    //var btn = document.getElementById("myBtn");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks the button, open the modal 
    //btn.onclick = function () {
        
    //     modal.style.display = "block";
       

    //    return false;
    //}

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


    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>


    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdn.datatables.net/1.10.16/css/dataTables.bootstrap.min.css" rel="stylesheet">

 <style>
        .dataTables_length,
        .dataTables_wrapper {
            font-size: 1.6rem;
        }

        .dataTables_length select,
        .dataTables_length input,
        .dataTables_wrapper select,
        .dataTables_wrapper input {
            background-color: #fefefe;
            border: 1px solid #999;
            border-radius: 4px;
            height: 3rem;
            line-height: 2;
            font-size: 1.3rem;
            color: #333;
        }

        .dataTables_length .dataTables_length,
        .dataTables_length .dataTables_filter,
        .dataTables_wrapper .dataTables_length,
        .dataTables_wrapper .dataTables_filter {
            margin-top: 30px;
            margin-right: 20px;
            margin-bottom: 10px;
            display: inline-flex;
        }

        .paginate_button {
            min-width: 4rem;
            display: inline-block;
            text-align: center;
            padding: 1rem 1.6rem;
            margin-top: -1rem;
            border: 2px solid lightblue;
        }

            .paginate_button:not(.previous) {
                border-left: none;
            }

            .paginate_button.previous {
                border-radius: 8px 0 0 8px;
                min-width: 7rem;
            }

            .paginate_button.next {
                border-radius: 0 8px 8px 0;
                min-width: 7rem;
            }

            .paginate_button:hover {
                cursor: pointer;
                background-color: #888;
                text-decoration: none;
            }
    </style>
</body>
</html>




