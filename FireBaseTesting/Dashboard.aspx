<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="FireBaseTesting.Dashboard" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Dashboard</title>

     <!--Mensajes...-->
    <script src="Scripts/sweetalert-dev.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
    <!--Necesarios para...-->
    <script src="https://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link href="css/StyleSheet1.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

     <!--Calendar...-->
     <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <style>
        /* Add a gray background color and some padding to the footer */
        footer {
            background-color: #f2f2f2;
            padding: 25px;
        }

        .carousel-inner img {
            width: 100%; /* Set width to 100% */
            min-height: 200px;
        }

        /* Hide the carousel text when the screen is less than 600 pixels wide */
        @media (max-width: 600px) {
            .carousel-caption {
                display: none;
            }
        }

        
        /* Style de las gráficas*/
        .containerGraf {
            width: 100%;
            background-color: rgba(211, 208, 208, 0.78);
        }


        .Back {
            text-align: right;
            padding-top: 3px;
            padding-bottom: 3px;
            color: white;
        }

        .valorcotizado {
            background-color: #b6ff00;
            color: #808080
        }

        .valorreal {
            background-color: #00ff21;
            color: #808080
        }

        .CantidadPuntos {
            background-color: #085f9e;
            color: #ffffff
        }

        .NumeroIncumplimientos {
            background-color: #d21010;
            color: #d21010
        }

        .NumeroCumplimientos {
            background-color: #067715;
            color: #ffffff
        }

    </style>
</head>
<body>

    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Logo</a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar" style="background-color:#355974">
                <ul class="nav navbar-nav" style="background-color:#355974">
                    <li class="active"><a href="Dashboard.aspx">Home</a></li>
                    <li><a href="Dashboard.aspx">Más reportes</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right" style="background-color:#355974">
                    <li><a href="login.aspx"><span class="glyphicon glyphicon-log-in"></span> Salir</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
        <div class="row">
            <div class="col-sm-7">
                <p style="font-size:30px;color:#808080;width:100%;text-align:left;">
                    <strong>
                        Operaciones, gráfica general
                    </strong>
                </p>
                <table>
                    <tr>
                        <td>
                            <p>Fecha inicio</p>
                            <input id="datepicker" style="width:170px;" readonly="readonly"  />
                            <script>
                                $('#datepicker').datepicker({
                                    uiLibrary: 'bootstrap'
                                });
                            </script>
                        </td>
                        <td>
                            <p>Fecha fin</p>
                            <input id="datepickerEnd" style="width:170px;" readonly="readonly"  />
                            <script>
                                $('#datepickerEnd').datepicker({
                                    uiLibrary: 'bootstrap'
                                });
                            </script>
                        </td>
                        <td>
                            <p style="color:transparent">.</p>
                            &nbsp;&nbsp;<input id="btnSearch" type="button" value="Buscar"  class="btn-success" style="height:35px;width:100px;" onclick="return LoadDateRange(); "/>                           
                        </td>
                    </tr>
                </table>
                <div id="map" style="width: 100%; height: 900px;">

                </div>
            </div>
            <div class="col-sm-5">
                <p style="font-size:30px;color:#808080;width:100%;text-align:left;">
                    <strong>
                        Datos de productividad
                    </strong>
                </p>
                <table >
                        <tr>
                            <td style="background-color:#085f9e;height:30px;border:dotted;border-width:9px;border-color:white;">
                                <p style="color:transparent;font-size:10px;color:white;"> Cant.Puntos </p>
                            </td>

                            <td style="background-color:#00ff21;height:30px;border:dotted;border-width:9px;border-color:white;">
                                <p style="color:transparent;font-size:10px;color:#808080;"> Valor.Real </p>
                            </td>
                            <td style="background-color:#b6ff00;height:30px;border:dotted;border-width:9px;border-color:white;">
                                <p style="color:transparent;font-size:10px;color:#808080;"> Valor.Cotizado </p>
                            </td>
                            <td style="background-color:#067715;height:30px;border:dotted;border-width:9px;border-color:white;">
                                <p style="color:transparent;font-size:10px;color:white;"> Cumplimiento </p>
                            </td>
                        </tr>
                    </table>
                <!--Datos de productividad-->
                <div class="col-sm-12" style="height:1000px;overflow-y:scroll;overflow-x:auto;" >
                   
                    <div id="DivGrag">
                        
                    </div>
                     <dl id="IdlBar" >
                        <dt style="text-align:left;">
                           
                        </dt>                     
                    </dl>
                </div>
            </div>
        </div>
        <hr>
        <h2>Tabla de datos</h2>
        <p>Solo es un ejemplo, los datos recuperados me permitirán armar los gráficos</p>
        <div class="table-responsive">
            <table class="table" id="tableData">
                <thead>
                    <tr>
                        <th>Latitude</th>
                        <th>Longitude</th>
                        <th>Estado</th>
                        <th>Foto</th>
                        <th>Direción</th>
                        <th>Total</th>
                        <th>Creado</th>
                        <th>Técnico</th>
                        <th>Total</th>
                        <th>Valor cotizado</th>
                        <th>Cliente </th>
                    </tr>
                </thead>
                <tbody>
                   
                </tbody>
            </table>
        </div>
    </div>

    <div class="container text-center">
        <h3>Espacio para más datos, si se llegara a utilizar</h3>
        <br>
        <div class="row">
            <div class="col-sm-3">
                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width:100%" alt="Image">
                <p>Datos 1</p>
            </div>
            <div class="col-sm-3">
                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width:100%" alt="Image">
                <p>Datos  2</p>
            </div>
            <div class="col-sm-3">
                <div class="well">
                    <p>Some text..</p>
                </div>
                <div class="well">
                    <p>Some text..</p>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="well">
                    <p>Some text..</p>
                </div>
                <div class="well">
                    <p>Some text..</p>
                </div>
            </div>
        </div>
        <hr>
    </div>


    <footer class="container-fluid text-center" style="background-color:#355974">
        <p>Footer Text, definir que poner aquí</p>
    </footer>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <script>

        $("#tableData tbody tr").each(function () {
            this.parentNode.removeChild(this);
        });

        $.ajax({
            url: 'Dashboard.ashx?action=LoadData',
            type: 'POST',
            success: function (data) {
                var count = 0;
                var itemRow = "<table class='table-responsive'>";
                var tableData = $("tableData");
                var locations = [];
                var DataBar = [];
                var DataTotal = [];
                var TotalMax = 0;
                var pTotal = 0;
                $.each(data, function (index, item) {
                    locations.push(['Cliente: "' + item.cliente + '" <br/>  Dirección: "' + item.direccion + '" <br/> Técnico: "' + item.nombreTecnico + '"<br/> Estado: "' + item.estado + '"<br/> Fecha: "' + item.creado + '"<br/><img  style="width:200px;height:200px;"  src="' + item.urlFoto + '"/>', item.latitude, item.longitude, 4, item.estado]);
                    $('#tableData').append("<tr><td style='text-align:left;'>" + item.latitude + "</td>  <td style='text-align:left;'>" + item.longitude + "</td> <td style='text-align:center;'>" + item.estado + "</td> <td style='text-align:center;'><img  style='width: 200px; height: 200px; '  src='" + item.urlFoto + "'/></td> <td style='text-align:center;'>" + item.direccion + "</td> <td style='text-align:center;'>" + item.total + "</td> <td style='text-align:center;'>" + item.creado + "</td> <td style='text-align:center;'>" + item.nombreTecnico + "</td> <td style='text-align:center;'>" + item.total + "</td> <td style='text-align:center;'>" + item.valor + "</td> <td style='text-align:center;'>" + item.cliente + "</td> </tr>");
                    count += 1;
                    DataTotal.push([item.total]);
                    DataBar.push([item.total, item.direccion, item.nombreTecnico]);

                });
                itemRow += "</table>";
                if (count > 0)
                    LoadDataGroupByGrafALL();
                TotalMax = Math.max.apply(null, DataTotal);
               
                //for (i = 0; i < DataBar.length; i++) {

                //     pTotal = ((DataBar[i][0] * 100) / TotalMax);
                //     var pTotalpase = parseInt(pTotal);
                //     $("#IdlBar").append("<dd style='text-align:left;' class='percentage percentage-" + pTotalpase + "' title='" + DataBar[i][1] + "' ><span class='text' >" + DataBar[i][2] + ": <br/> $ " + DataBar[i][0] + "</span></dd>");
                   
                //}

                var map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 7,
                    center: new google.maps.LatLng(6.247197832423961, -75.6102218851447),
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                });

                var infowindow = new google.maps.InfoWindow();

                var marker, i;
                
                for (i = 0; i < locations.length; i++) {
                    var estado = locations[i][4];
                   // alert(locations[i][1]+ "--"+ locations[i][2]);
                    var sURL = "";
                    if (estado == "cerrado")
                        sURL = 'http://maps.google.com/mapfiles/ms/icons/green.png';
                    if (estado == "trabajando")
                        sURL = 'http://maps.google.com/mapfiles/ms/icons/yellow.png';
                    if (estado == "nuevo")
                        sURL = 'http://maps.google.com/mapfiles/ms/icons/red.png';

                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                        icon: {
                            url: sURL,
                            labelOrigin: new google.maps.Point(15, 10)
                        },
                        map: map
                    });

                    google.maps.event.addListener(marker, 'click', (function (marker, i) {
                        return function () {
                            infowindow.setContent(locations[i][0]);
                            infowindow.open(map, marker);
                        }
                    })(marker, i));

                }
                //document.getElementById("divLocation").innerHTML = locations;

            },
            error: function (data) {
                //swal('Error al intentar recuperar los datos, vuelva a intentarlo por favor', '', 'error');
                //alert('test');
            }
        });
    </script>

     <script>
         function LoadDateRange() {

             if (document.getElementById('datepicker').value != "" && document.getElementById('datepickerEnd').value != "") {

                 document.getElementById("map").innerHTML = "";
                 document.getElementById("IdlBar").innerHTML = "";
                 $("#tableData tbody tr").each(function () {
                     this.parentNode.removeChild(this);
                 });

                 $.ajax({
                     url: 'Dashboard.ashx?action=LoadDataDateRange&startDate=' + document.getElementById('datepicker').value + '&EndDate=' + document.getElementById('datepickerEnd').value + '',
                     type: 'POST',
                     success: function (data) {
                         var count = 0;
                         var itemRow = "<table class='table-responsive'>";
                         var tableData = $("tableData");
                         var locations = [];
                         var DataBar = [];
                         var DataTotal = [];
                         var TotalMax = 0;
                         var pTotal = 0;
                         $.each(data, function (index, item) {
                             locations.push(['Cliente: "' + item.cliente + '" <br/>  Dirección: "' + item.direccion + '" <br/> Técnico: "' + item.nombreTecnico + '"<br/> Estado: "' + item.estado + '"<br/> Fecha: "' + item.creado + '"<br/><img  style="width:200px;height:200px;"  src="' + item.urlFoto + '"/>', item.latitude, item.longitude, 4, item.estado]);
                             $('#tableData').append("<tr><td style='text-align:left;'>" + item.latitude + "</td>  <td style='text-align:left;'>" + item.longitude + "</td> <td style='text-align:center;'>" + item.estado + "</td> <td style='text-align:center;'><img  style='width: 200px; height: 200px; '  src='" + item.urlFoto + "'/></td> <td style='text-align:center;'>" + item.direccion + "</td> <td style='text-align:center;'>" + item.total + "</td> <td style='text-align:center;'>" + item.creado + "</td> <td style='text-align:center;'>" + item.nombreTecnico + "</td> <td style='text-align:center;'>" + item.total + "</td> <td style='text-align:center;'>" + item.valor + "</td> <td style='text-align:center;'>" + item.cliente + "</td></tr>");
                             count += 1;
                             DataTotal.push([item.total]);
                             DataBar.push([item.total, item.direccion, item.nombreTecnico]);

                         });
                         itemRow += "</table>";

                         if (count <= 0) {
                             swal('', 'No se encontraron datos para el rango de fecha seleccionado', 'error');
                         }
                         else {
                             swal('', 'Datos consultados correctamente!, total registros consultados: ' + count + '', 'success');
                             LoadDateRangeGroupByGraf();
                            
                         }
                             

                         TotalMax = Math.max.apply(null, DataTotal);

                         //for (i = 0; i < DataBar.length; i++) {

                         //    pTotal = ((DataBar[i][0] * 100) / TotalMax);
                         //    var pTotalpase = parseInt(pTotal);
                         //    $("#IdlBar").append("<dd style='text-align:left;' class='percentage percentage-" + pTotalpase + "' title='" + DataBar[i][1] + "' ><span class='text' >" + DataBar[i][2] + ": <br/> $ " + DataBar[i][0] + "</span></dd>");

                         //}

                         var map = new google.maps.Map(document.getElementById('map'), {
                             zoom: 7,
                             center: new google.maps.LatLng(6.247197832423961, -75.6102218851447),
                             mapTypeId: google.maps.MapTypeId.ROADMAP
                         });

                         var infowindow = new google.maps.InfoWindow();

                         var marker, i;

                         for (i = 0; i < locations.length; i++) {
                             var estado = locations[i][4];

                             var sURL = "";
                             if (estado == "cerrado")
                                 sURL = 'http://maps.google.com/mapfiles/ms/icons/green.png';
                             if (estado == "trabajando")
                                 sURL = 'http://maps.google.com/mapfiles/ms/icons/yellow.png';
                             if (estado == "nuevo")
                                 sURL = 'http://maps.google.com/mapfiles/ms/icons/red.png';

                             marker = new google.maps.Marker({
                                 position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                                 icon: {
                                     url: sURL,
                                     labelOrigin: new google.maps.Point(15, 10)
                                 },
                                 map: map
                             });

                             google.maps.event.addListener(marker, 'click', (function (marker, i) {
                                 return function () {
                                     infowindow.setContent(locations[i][0]);
                                     infowindow.open(map, marker);
                                 }
                             })(marker, i));

                         }
                         //document.getElementById("divLocation").innerHTML = locations;

                     },
                     error: function (data) {
                         swal('', 'Error al intentar recuperar los datos, vuelva a intentarlo por favor', 'error');
                         //alert('Error');
                     }
                 });
             }
             else {
                 swal('', 'Debe seleccionar el rango de fecha que desea consultar', 'error');
             }
         }

        
    </script>

      <script>
         function LoadDateRangeGroupByGraf() {

             if (document.getElementById('datepicker').value != "" && document.getElementById('datepickerEnd').value != "") {
                 document.getElementById('DivGrag').innerHTML = "";
                 $.ajax({
                     url: 'Dashboard.ashx?action=LoadDataGroupByGraf&startDate=' + document.getElementById('datepicker').value + '&EndDate=' + document.getElementById('datepickerEnd').value + '',
                     type: 'POST',
                     success: function (data) {
                         var count = 0;                         
                         var locations = [];
                         var DataBar = [];
                         var DataTotal = [];
                         var DataPuntos = [];
                         var DataValorCot = [];
                         var DataCumplimiento = [];
                         var TotalMax = 0;
                         var TotalMaxPuntos = 0;
                         var pTotalPuntos = 0;
                         var pTotal = 0;
                         var pTotalMaxValorCot = 0;
                         var pTotalValorCot = 0;
                         var pTotalMaxCumplimiento = 0;
                         var pTotalCumplimiento = 0;
                         $.each(data, function (index, item) {
                             count += 1;
                             DataTotal.push([item.Total]);
                             DataPuntos.push([item.Puntos]);
                             DataValorCot.push([item.ValorCot]);
                             DataCumplimiento.push([item.Cumplimiento]);

                             DataBar.push([item.NombreTecnico, item.Total, item.Puntos, item.ValorCot,  item.Cumplimiento, item.InCumplimiento,]);

                         });
                         

                         if (count <= 0) {
                             swal('', 'No se encontraron datos para el rango de fecha seleccionado', 'error');
                         }
                         else {
                             //swal('', 'Datos TOTALES consultados correctamente!, total registros consultados: '+ count +'', 'success');
                             document.getElementById('datepicker').value = "";
                             document.getElementById('datepickerEnd').value = "";
                         }
                             

                         TotalMax = Math.max.apply(null, DataTotal); //Valor más alto
                         TotalMaxPuntos = Math.max.apply(null, DataPuntos); //Valor más alto
                         pTotalMaxValorCot = Math.max.apply(null, DataValorCot); //Valor más alto
                         pTotalMaxCumplimiento = Math.max.apply(null, DataCumplimiento); //Valor más alto

                         for (i = 0; i < DataBar.length; i++) {

                             pTotalPuntos = ((DataBar[i][2] * 100) / TotalMaxPuntos);
                             pTotal = ((DataBar[i][1] * 100) / TotalMax);
                             pTotalValorCot = ((DataBar[i][3] * 100) / pTotalMaxValorCot);
                             pTotalCumplimiento = ((DataBar[i][4] * 100) / pTotalMaxCumplimiento);

                             var pTotalpase = parseInt(pTotalPuntos);
                             var pTotalPuntospase = parseInt(pTotal);
                             var pTotalValorCotpase = parseInt(pTotalValorCot);
                             var pTotalCumplimientopase = parseInt(pTotalCumplimiento);

                             $("#DivGrag").append("<strong>Ténico: " + DataBar[i][0] + " </strong>  <div class='containerGraf'> <div class='Back CantidadPuntos' style='width:" + pTotalpase + "%'>" + DataBar[i][2] + "</div> <strong></strong> <div class='Back valorcotizado' style='width:" + pTotalValorCotpase + "%'>" + DataBar[i][3] + "</div> <div class='Back valorreal' style='width:" + pTotalPuntospase + "%'>" + DataBar[i][1] + "</div>   <div class='Back NumeroCumplimientos' style='width:" + pTotalCumplimientopase + "%'>" + DataBar[i][4] + "</div> </div> <br/>");

                         }

                         //document.getElementById("divLocation").innerHTML = locations;

                     },
                     error: function (data) {
                         swal('', 'Error al intentar recuperar los datos, vuelva a intentarlo por favor', 'error');
                         //alert('Error');
                     }
                 });

                  document.getElementById('datepicker').value = "";
                  document.getElementById('datepickerEnd').value = "";
             }
             else {
                 swal('', 'Debe seleccionar el rango de fecha que desea consultar', 'error');
             }
          }
        </script>

         <script>
         function LoadDataGroupByGrafALL() {
             
                 document.getElementById('DivGrag').innerHTML = "";
                 $.ajax({
                     url: 'Dashboard.ashx?action=LoadDataGroupByGrafAll',
                     type: 'POST',
                     success: function (data) {
                         var count = 0;                         
                         var locations = [];
                         var DataBar = [];
                         var DataTotal = [];
                         var DataPuntos = [];
                         var DataValorCot = [];
                         var DataCumplimiento = [];
                         var TotalMax = 0;
                         var TotalMaxPuntos = 0;
                         var pTotalPuntos = 0;
                         var pTotal = 0;
                         var pTotalMaxValorCot = 0;
                         var pTotalValorCot = 0;
                         var pTotalMaxCumplimiento = 0;
                         var pTotalCumplimiento = 0;
                         $.each(data, function (index, item) {
                             count += 1;
                             DataTotal.push([item.Total]);
                             DataPuntos.push([item.Puntos]);
                             DataValorCot.push([item.ValorCot]);
                             DataCumplimiento.push([item.Cumplimiento]);

                             DataBar.push([item.NombreTecnico, item.Total, item.Puntos, item.ValorCot,  item.Cumplimiento, item.InCumplimiento,]);

                         });
                         

                         if (count <= 0) {
                             swal('', 'No se encontraron datos para el rango de fecha seleccionado', 'error');
                         }
                         else {
                            // swal('', 'Datos TOTALES consultados correctamente!, total registros consultados: '+ count +'', 'success');
                             document.getElementById('datepicker').value = "";
                             document.getElementById('datepickerEnd').value = "";
                         }
                             

                         TotalMax = Math.max.apply(null, DataTotal); //Valor más alto
                         TotalMaxPuntos = Math.max.apply(null, DataPuntos); //Valor más alto
                         pTotalMaxValorCot = Math.max.apply(null, DataValorCot); //Valor más alto
                         pTotalMaxCumplimiento = Math.max.apply(null, DataCumplimiento); //Valor más alto

                         for (i = 0; i < DataBar.length; i++) {

                             pTotalPuntos = ((DataBar[i][2] * 100) / TotalMaxPuntos);
                             pTotal = ((DataBar[i][1] * 100) / pTotalMaxValorCot);
                             pTotalValorCot = ((DataBar[i][3] * 100) / pTotalMaxValorCot);
                             pTotalCumplimiento = ((DataBar[i][4] * 100) / pTotalMaxCumplimiento);
                            

                             var pTotalpase = parseInt(pTotalPuntos);
                             var pTotalPuntospase = parseInt(pTotal);
                             var pTotalValorCotpase = parseInt(pTotalValorCot);
                             var pTotalCumplimientopase = parseInt(pTotalCumplimiento);

                             $("#DivGrag").append("<strong>Ténico: " + DataBar[i][0] + " </strong>  <div class='containerGraf'> <div class='Back CantidadPuntos' style='width:" + pTotalpase + "%'>" + parseInt(DataBar[i][2]).toLocaleString() + "</div> <strong></strong> <div class='Back valorcotizado' style='width:" + pTotalValorCotpase + "%'>" + parseInt(DataBar[i][3]).toLocaleString() + "</div> <div class='Back valorreal' style='width:" + pTotalPuntospase + "%'>" + parseInt(DataBar[i][1]).toLocaleString() + "</div>   <div class='Back NumeroCumplimientos' style='width:" + pTotalCumplimientopase + "%'>" + parseInt(DataBar[i][4]).toLocaleString() + "</div> </div> <br/>");

                         }

                         //document.getElementById("divLocation").innerHTML = locations;

                     },
                     error: function (data) {
                         swal('', 'Error al intentar recuperar los datos, vuelva a intentarlo por favor', 'error');
                         //alert('Error');
                     }
                 });

                  document.getElementById('datepicker').value = "";
                  document.getElementById('datepickerEnd').value = "";
             
          }
        </script>
</body>
</html>
