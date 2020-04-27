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

 <%-- <!-- Google Fonts -->
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Roboto:100,300,400,500,700|Philosopher:400,400i,700,700i" rel="stylesheet">--%>

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
    <script src="Simulador.aspxV10.js"></script>
     <%--NECESARIOS PARA  MENSAJES DEL SISTEMA--%>
    <script src="js/sweetalert-dev.js"></script>
	<link href="css/sweetalert.css" rel="stylesheet" />

</head>

<body onload="ActivosRegistradosListComboBox();KeyListData();">
    
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
          <li class="menu-active"><a href="Simulador.aspx">Simulador</a></li>
          <li><a href="Activos.aspx">Mis Activos</a></li>
          <li><a href="ApiKey.aspx">Api Key</a></li>
          <li><a href="Reportes.aspx">Reportes</a></li>
          <li><a href="login.aspx">Salir</a></li>
        
        </ul>
      </nav><!-- #nav-menu-container -->
    </div>
      <div style="display:none;">
          <form  runat="server">
            <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>
        </form>
      </div>
        
  </header><!-- #header -->

<br />
<br />
  
 
  <!--==========================
    Form Section
  ============================-->

    <link      href="https://fonts.googleapis.com/css?family=Montserrat"   rel="stylesheet"/>
        <div class="wrapper">
          <div class="container" id="DivStep1">
            <span id="spanApiKeys" style="display:none;"></span>
            <h1 style="color:#71c55d;">Parametrizar    Simulación</h1>
            <br />
            <form>

              <div class="form-row">
                <div class="form-group col-md-6">
                   <label for="inputEmail4">Activo</label>
                   <select id="SelectActivo" class="form-control">
                    <option selected>Seleccione</option>                  
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
                    <option value="Largo">Largo</option>
                    <option value="Corto">Corto</option>
                    
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
                    <option value="">Seleccione</option>
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
                        <option value="1min">1min</option>
                        <option value="5min" selected="selected">5min</option>
                        <option value="15min" selected="selected">15min</option>                        
                        <option value="30min" selected="selected">30min</option>
                        <option value="60min" selected="selected">60min</option>
                       
                        <option value="daily">Diario</option>
                        <option value="weekly">Semanal</option>       
                        <option value="monthly">Mensual</option>                                 
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
                  <input type="text" class="form-control" id="txtSesiones"  value="100"/>
                  
                  
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
                        <option value="close">Cierre</option>
                        <option value="open">Apertura</option>
                        <option value="high">Máximo</option>
                        <option value="low">Mínimo</option>
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
                  <input type="text" class="form-control" id="txtRapidaFinal" value="17"/>                  
                  <div class="line"></div>
                </div>
              </div>

             <div class="form-row">
                <div class="form-group col-md-6">
                  <label for="inputPassword4">MM Lenta inicial</label>
                  <input type="text" class="form-control" id="txtMMLenta" value="18" />
                  <div class="line"></div>
                </div>
                <div class="form-group col-md-6">
                  <label for="inputPassword4">MM Lenta Final</label>
                  <input type="text" class="form-control" id="txtMMLentaFinal" value="60"/>                  
                  <div class="line"></div>
                </div>
              </div>

             <p><button class="w3-button w3-block w3-teal" onclick="CrearTablaDinamicamente();return false;">Iniciar</button></p>
            </form>
        </div>
        <div style="display:none;" id="divConfirm">
         <p class="w3-button w3-block w3-teal">Parámetros a ejecutar en el API </p>
         <div class="bs-example container">             
             <table style="margin:auto;">
                 <tr>
                     <td>
                         Function
                     </td>
                     <td>
                         <span id="spamActivo"></span>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Symbol
                     </td>
                     <td>
                         <span id="Symbol"></span>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Interval
                     </td>
                     <td>
                          <span id="Interval"></span>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Series Type
                     </td>
                     <td>
                         <span id="SeriesType"></span>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Time period
                     </td>
                     <td>
                         2 to 60
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Sesiones (Registros a procesar)
                     </td>
                     <td>
                         <span id="Sesiones"></span>
                     </td>
                 </tr>
             </table>
             <br />
            <table style="margin:auto;">
             <tr>
                 <td>
                     <input id="btnCancelarConfirm" type="button" class="w3-button w3-block w3-teal" style="background-color:#792525 !important" onclick="location.reload();" value="Cancelar" />
                 </td>
                 <td>
                      <button class="w3-button w3-block w3-teal" onclick="confirmar();">Inciar Consultas</button>
                 </td>
             </tr>
           </table>            
          </div>
        </div>
        </div>
        <div style="display:none;" id="divResultados">    

        <p class="w3-button w3-block w3-teal">Technical Analysis DATA</p>
        <div class="bs-example container"  >
             
             <p style="font-size:20px;">
                 <strong>
                    Technical Analysis:
                </strong> 
             </p>
             <p>
                 <strong style="font-size:15px;">
                    Total consultas ejecutadas: <span id="spanTotal">0</span><br />
                     <span id="spanEsperando" style="color:red;font-size:23px;">Consultando información, por favor espere que se ejecute el proceso... </span>
                </strong> 
             </p>
            <table style="margin:auto;">
             <tr>
                 
                 <td colspan="2">

                     
                     <a target="_blank" href="DadaExcel/TechnicalAnalysisv2.xlsx" style="display:none;" id="aDescarga">
                         <input id="btnCalcular" class="w3-button w3-block w3-teal" type="button" value="Descargar TechnicalAnalysis"  />
                     </a>  
                     <a target="_blank" href="DadaExcel/Senales.xlsx" style="display:none;" id="aDescargaSenales">
                         <input id="btnDecarga2" class="w3-button w3-block w3-teal" type="button" value="Descargar Señales"  />
                     </a>  
                      <a target="_blank" href="DadaExcel/Result.xlsx" style="display:none;" id="aDescargaResult">
                         <input id="btnDecarga3" class="w3-button w3-block w3-teal" type="button" value="Descargar Result"  />
                     </a>  
                     <input id="btnRecarlcular" class="w3-button w3-block w3-teal"  type="button" value="Ejecutar Cálculo Nuevamente"  style="display:none;" onclick="Recalcular(this);" />
                     <input id="btnCancelar" type="button" class="w3-button w3-block w3-teal" style="background-color:#792525 !important" onclick="location.reload();" value="Salir" />

                 </td>
                
             </tr>
            </table>
        <br />
           
                 <div data-example-id="striped-table" style="width:100%;overflow-x:auto; overflow-y:auto; height:300px;">
            
                    <table class="table table-striped table-bordered table-hover" id="TableResult" style="width:100%;" runat="server">
                    <thead>
                        <%--<tr style="background-color:#009688;">
                            <th style="text-align:center;">Fecha</th>
                          
                        </tr>--%>
                    </thead>
                    <tbody>
                        
                    </tbody>
                    <tfoot>
            
                    </tfoot>
                </table>
                <div id="demoDiv" style="width:100%;">

                </div>
               </div>              
            

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




<script>
    function openPage(pageName, elmnt, color) {
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].style.backgroundColor = "";
        }
        document.getElementById(pageName).style.display = "block";
        elmnt.style.backgroundColor = color;
    }

    // Get the element with id="defaultOpen" and click on it
    document.getElementById("defaultOpen").click();
</script>
<style>
* {box-sizing: border-box}

    /* Set height of body and the document to 100% */
    body, html {
      height: 100%;
      margin: 0;
      font-family: Arial;
    }

    /* Style tab links */
    .tablink {
      background-color: #555;
      color: white;
      float: left;
      border: none;
      outline: none;
      cursor: pointer;
      padding: 14px 16px;
      font-size: 17px;
      width: 25%;
    }

    .tablink:hover {
      background-color: #777;
    }

    /* Style the tab content (and add height:100% for full page content) */
    .tabcontent {
      color: white;
      display: none;
      padding: 100px 20px;
      height: 100%;
    }

    #Home {background-color: transparent;}
    #News {background-color: transparent;}
 
</style>

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
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</body>
</html>


