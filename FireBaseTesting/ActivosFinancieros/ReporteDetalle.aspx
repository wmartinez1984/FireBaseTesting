<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteDetalle.aspx.cs" Inherits="FireBaseTesting.ActivosFinancieros.ReporteDetalle" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>
        Detalle del reporte
    </title>
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

    <link href="img/apple-touch-icon.png" rel="apple-touch-icon">
     <link href="img/favicon.png" rel="icon">
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" rel="stylesheet">
    <link href="https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css" rel="stylesheet">

    <script>
        $(document).ready(function () {
            
            document.getElementById('hmensaje').innerHTML = "Cargando información, por favor espere...";
   
            try {
                $.ajax({
                    type: "POST",
                    url: "Activos.ashx?Action=ResultadosDetalleList&id=" + document.getElementById('HiddenID').value + "",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        var exists = false;
                        var count = 0;
               

              

                        $.each(data, function (index, item) {
                            exists = true;

                   

                            $('#example').append("<tr>  <td style='text-align:center;'>" + item.Senal + "</td><td style='text-align:center;'>" + item.Cantidaddedias + "</td><td style='text-align:center;'>" + item.Cantidadediasfueradelmercado + "</td> <td style='text-align:center;'>" + item.Cantidaddediasdentrodelmercado + "</td> <td style='text-align:center;'>" + item.CantidadtotaldeOperaciones + "</td> <td style='text-align:center;'>" + item.CantidadtotaldeOPGanadoras + "</td> <td style='text-align:center;'>" + item.CantidadtotaldeOPPerdedoras + "</td> <td style='text-align:center;'>" + item.GananciaMaxima + "</td> <td style='text-align:center;'>" + item.PerdidaMaxima + "</td> <td style='text-align:center;'>" + item.PerformanceTotal + "</td> <td style='text-align:center;'>" + item.PerformanceAnualizada + "</td>  <td style='text-align:center;'>" + item.PerformanceBuyAndHold + "</td>  <td style='text-align:center;'>" + item.PerformanceBuyAndHoldAnualizada + "</td>  <td style='text-align:center;'>" + item.EM + "</td> <td style='text-align:center;'>" + item.RachaGanadora + "</td> <td style='text-align:center;'>" + item.RachaPerdedora + "</td> </tr>");
                   
                        });

                
                        document.getElementById('hmensaje').innerHTML = "";
                        $("#example").DataTable();
                        // $('#example').DataTable();


                    },
                    failure: function (r) {
                        document.getElementById('hmensaje').innerHTML = "";
                        swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                        return false;
                    },
                    error: function (r) {
                        document.getElementById('hmensaje').innerHTML = "";
                        swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                        return false;
                    }

                });

            }
            catch (err) {
                swal('Error:', 'No podemos cargar tus datos en este momento', 'error');
                return false;
            }

                 
        });
        $('#example').DataTable();

    </script>
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
       <%--   <li><a href="Home.aspx">Home</a></li>
          <li><a href="Simulador.aspx">Simulador</a></li>
          <li><a href="Activos.aspx">Mis Activos</a></li>
          <li><a href="ApiKey.aspx">Api Key</a></li>
          <li  class="menu-active"><a href="Reportes.aspx">Reportes</a></li>--%>
          <li class="menu-active"><a onclick="window.close();" href="#">panel de resultados </a></li>
        
        </ul>
      </nav><!-- #nav-menu-container -->
    </div>
  </header><!-- #header -->
    <br />
    <br />
    <br />
    <input id="HiddenID" type="hidden" value="" runat="server"/>
    <h3 id="hmensaje" style="color:#ff6a00"></h3>
    <h2 style="color:#71c55d;">Result list</h2>
    <div style="overflow-x:auto;">
        <table id="example" class="table table-striped table-bordered" style="width:100%;margin:auto;">
            <thead>
                <tr>
                    <th>Señal</th>
                    <th>C.días</th>
                    <th>Días.fuera</th>
                    <th>Días.dentro</th>
                    <th>Cant.total.OP</th>
                    <th>Cant.total.OP.Ganadoras</th>
                    <th>Cant.total.OP.Perdedoras</th>

                    <th>Ganancia.Máxima</th>
                    <th>Perdida.Máxima</th>
                    <th>Perf.Total</th>
                    <th>Perf.Anualizada</th>
                    <th>Perf.Buy&Hold</th>
                    <th>Perf.Buy&Hold.Anualizada</th>

                    <th>EM</th>
                    <th>Racha.Ganadora</th>
                    <th>Racha.Perdedora</th>


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
                <tr>
                    <th>Señal</th>
                    <th>C.días</th>
                    <th>Días.fuera</th>
                    <th>Días.dentro</th>
                    <th>Cant.total.OP</th>
                    <th>Cant.total.OP.Ganadoras</th>
                    <th>Cant.total.OP.Perdedoras</th>

                    <th>Ganancia.Máxima</th>
                    <th>Perdida.Máxima</th>
                    <th>Perf.Total</th>
                    <th>Perf.Anualizada</th>
                    <th>Perf.Buy&Hold</th>
                    <th>Perf.Buy&Hold.Anualizada</th>

                    <th>EM</th>
                    <th>Racha.Ganadora</th>
                    <th>Racha.Perdedora</th>
                </tr>
            </tfoot>
        </table>
    </div>
    
</body>
</html>