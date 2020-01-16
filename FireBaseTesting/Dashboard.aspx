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

         .containerGrafColum {
            width: 120px;
            height:100%;
            background-color: rgba(211, 208, 208, 0.78);
        }

        .BackCalificaciones {
            text-align: right;
            padding-top: 15px;
            padding-bottom: 15px;
            color: #355974;
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
            color: white
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
                <table >
                    
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
                            &nbsp;&nbsp;<input id="btnSearch" type="button" value="Buscar"  class="btn-success" style="height: 35px; width: 100px;" onclick="return LoadDateRange(); "/>                           
                        </td>
                    </tr>
                    <tr style="background-color:#2b91db;height:30px;border:dotted;border-width:9px;border-color:white;color:white;">
                        <td >
                            Cerrado: <img src="http://maps.google.com/mapfiles/ms/icons/green.png" />
                        </td>
                        <td>
                             Trabjando: <img  src="http://maps.google.com/mapfiles/ms/icons/yellow.png"/>
                        </td>
                        <td>
                            Nuevo: <img  src="http://maps.google.com/mapfiles/ms/icons/red.png"/>
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
                            <td style="background-color:#d21010;height:30px;border:dotted;border-width:9px;border-color:white;">
                                <p style="color:transparent;font-size:10px;color:white;"> Incumplimiento </p>
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
        <div  style="width:100%;" >   
            <p style="font-size:30px;color:#808080;width:100%;text-align:left;">
                    <strong>
                        Calificaciones
                    </strong>
            </p>
            <div id="DivGragCalficaciones">
                ......
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

<%--    <div class="container text-center">
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
    </div>--%>


    <footer class="container-fluid text-center" style="background-color:#355974">
        <p>Footer Text, definir que poner aquí</p>
    </footer>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <%--    js  para cargar datos --%>
    <script src="Scripts/DataReports.js"></script>
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
                if (count > 0) {
                    LoadDataGroupByGrafALL();
                    LoadDataGroupByQualificationALL();
                }
                   
                TotalMax = Math.max.apply(null, DataTotal);
               
                

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
                

            },
            error: function (data) {
                swal('Error al intentar recuperar los datos, vuelva a intentarlo por favor', '', 'error');
               
            }
        });
    </script>

     <script>
        

        
    </script>

      <script>
        
        </script>

         <script>
       
        </script>
</body>
</html>
