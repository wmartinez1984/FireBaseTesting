

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
                var pTotalIncumplimiento = 0;
                $.each(data, function (index, item) {
                    count += 1;
                    DataTotal.push([item.Total]);
                    DataPuntos.push([item.Puntos]);
                    DataValorCot.push([item.ValorCot]);
                    DataCumplimiento.push([item.Cumplimiento]);

                    //DataBar.push([item.NombreTecnico, item.Total, item.Puntos, item.ValorCot,  item.Cumplimiento, item.InCumplimiento,]);
                    DataBar.push([item.NombreTecnico, item.Total, item.Puntos, item.ValorCot, item.Cumplimiento, item.InCumplimiento, item.CountGroup,]);
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
                    pTotal = ((DataBar[i][1] * 100) / pTotalMaxValorCot);
                    pTotalValorCot = ((DataBar[i][3] * 100) / pTotalMaxValorCot);
                    pTotalCumplimiento = ((DataBar[i][4] * 100) / DataBar[i][6]);
                    pTotalIncumplimiento = ((DataBar[i][5] * 100) / DataBar[i][6]);

                    var pTotalpase = parseInt(pTotalPuntos);
                    var pTotalPuntospase = parseInt(pTotal);
                    var pTotalValorCotpase = parseInt(pTotalValorCot);
                    var pTotalCumplimientopase = parseInt(pTotalCumplimiento);
                    var pTotalIncumplimientopase = parseInt(pTotalIncumplimiento);

                    //$("#DivGrag").append("<strong>Ténico: " + DataBar[i][0] + " </strong>  <div class='containerGraf'> <div class='Back CantidadPuntos' style='width:" + pTotalpase + "%'>" + parseInt(DataBar[i][2]).toLocaleString() + "</div> <strong></strong> <div class='Back valorcotizado' style='width:" + pTotalValorCotpase + "%'>" + parseInt(DataBar[i][3]).toLocaleString() + "</div> <div class='Back valorreal' style='width:" + pTotalPuntospase + "%'>" + parseInt(DataBar[i][1]).toLocaleString() + "</div>   <div class='Back NumeroCumplimientos' style='width:" + pTotalCumplimientopase + "%'>" + parseInt(DataBar[i][4]).toLocaleString() + "</div> </div> <br/>");
                    $("#DivGrag").append("<strong>Ténico: " + DataBar[i][0] + " </strong>  <div class='containerGraf'> <div class='Back CantidadPuntos' style='width:" + pTotalpase + "%'>" + parseInt(DataBar[i][2]).toLocaleString() + "</div> <strong></strong> <div class='Back valorcotizado' style='width:" + pTotalValorCotpase + "%'>" + parseInt(DataBar[i][3]).toLocaleString() + "</div> <div class='Back valorreal' style='width:" + pTotalPuntospase + "%'>" + parseInt(DataBar[i][1]).toLocaleString() + "</div>   <div class='Back NumeroCumplimientos' style='width:" + pTotalCumplimientopase + "%'>" + parseInt(DataBar[i][4]).toLocaleString() + "</div>  <div class='Back NumeroIncumplimientos' style='width:" + pTotalIncumplimientopase + "%'>" + parseInt(DataBar[i][5]).toLocaleString() + "</div> </div> <br/>");
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
            var DataIncumplimiento = [];
            var TotalMax = 0;
            var TotalMaxPuntos = 0;
            var TotalIncumplimientos = 0;
            var pTotalPuntos = 0;
            var pTotal = 0;
            var pTotalMaxValorCot = 0;
            var pTotalValorCot = 0;
            var pTotalMaxCumplimiento = 0;
            var pTotalCumplimiento = 0;
            var pTotalIncumplimiento = 0;
            $.each(data, function (index, item) {

                DataTotal.push([item.Total]);
                DataPuntos.push([item.Puntos]);
                DataValorCot.push([item.ValorCot]);
                DataCumplimiento.push([item.Cumplimiento]);


                DataBar.push([item.NombreTecnico, item.Total, item.Puntos, item.ValorCot, item.Cumplimiento, item.InCumplimiento, item.CountGroup]);

                count += 1;
            });


            if (count <= 0) {
                swal('', 'No se encontraron datos para el rango de fecha seleccionado', 'error');
            }
            else {

                document.getElementById('datepicker').value = "";
                document.getElementById('datepickerEnd').value = "";
            }


            TotalMax = Math.max.apply(null, DataTotal); //Valor más alto
            TotalMaxPuntos = Math.max.apply(null, DataPuntos); //Valor más alto
            pTotalMaxValorCot = Math.max.apply(null, DataValorCot); //Valor más alto
            //pTotalMaxCumplimiento = Math.max.apply(null, DataCumplimiento); //Valor más alto

            for (i = 0; i < DataBar.length; i++) {

                pTotalPuntos = ((DataBar[i][2] * 100) / TotalMaxPuntos);
                pTotal = ((DataBar[i][1] * 100) / pTotalMaxValorCot);
                pTotalValorCot = ((DataBar[i][3] * 100) / pTotalMaxValorCot);
                pTotalCumplimiento = ((DataBar[i][4] * 100) / DataBar[i][6]);
                pTotalIncumplimiento = ((DataBar[i][5] * 100) / DataBar[i][6]);


                var pTotalpase = parseInt(pTotalPuntos);
                var pTotalPuntospase = parseInt(pTotal);
                var pTotalValorCotpase = parseInt(pTotalValorCot);
                var pTotalCumplimientopase = parseInt(pTotalCumplimiento);
                var pTotalIncumplimientopase = parseInt(pTotalIncumplimiento);

                $("#DivGrag").append("<strong>Ténico: " + DataBar[i][0] + " </strong>  <div class='containerGraf'> <div class='Back CantidadPuntos' style='width:" + pTotalpase + "%'>" + parseInt(DataBar[i][2]).toLocaleString() + "</div> <strong></strong> <div class='Back valorcotizado' style='width:" + pTotalValorCotpase + "%'>" + parseInt(DataBar[i][3]).toLocaleString() + "</div> <div class='Back valorreal' style='width:" + pTotalPuntospase + "%'>" + parseInt(DataBar[i][1]).toLocaleString() + "</div>   <div class='Back NumeroCumplimientos' style='width:" + pTotalCumplimientopase + "%'>" + parseInt(DataBar[i][4]).toLocaleString() + "</div>  <div class='Back NumeroIncumplimientos' style='width:" + pTotalIncumplimientopase + "%'>" + parseInt(DataBar[i][5]).toLocaleString() + "</div> </div> <br/>");

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

function LoadDataGroupByQualificationALL() {

    document.getElementById('DivGragCalficaciones').innerHTML = "";
    $.ajax({
        url: 'Dashboard.ashx?action=LoadDataQualificationAll',
        type: 'POST',
        success: function (data) {
            var count = 0;            
            var DataBar = [];
            var DataTotal = [];
            var TotalMax = 0;
            $.each(data, function (index, item) {

               
                DataTotal.push([item.Total]);
               
                DataBar.push([item.NombreTecnico, item.Total, item.CountGroup]);

                count += 1;
            });


            if (count <= 0) {
                swal('', 'No se encontraron datos de calficaciones para el rango de fecha seleccionado', 'error');
            }
           
            TotalMax = Math.max.apply(null, DataTotal); //Valor más alto
          

            for (i = 0; i < DataBar.length; i++) {

                var pTotalPromedio = ((DataBar[i][1] * 100) / TotalMax);       
                var pTotalpase = parseInt(pTotalPromedio); 

                if (DataBar[i][1] > 4)
                    var cssname = 'BackCalificaciones NumeroCumplimientos';
                if (DataBar[i][1] > 3.4 && DataBar[i][1] <= 4)
                    var cssname = 'BackCalificaciones valorcotizado';
                if (DataBar[i][1] <= 3.4)
                    var cssname = 'BackCalificaciones NumeroIncumplimientos';


                var TotalPromedio = DataBar[i][1];
                var nPromedio = TotalPromedio.toFixed(2);
                

                $("#DivGragCalficaciones").append("<strong>Ténico: " + DataBar[i][0] + " </strong>  <div class='containerGraf'> <div class='" + cssname + "' style='width:" + pTotalpase + "%'> Promedio: " + nPromedio + ", Total Calificaciones:"+ DataBar[i][2] +"</div> </div> <br/>");

            }

          

        },
        error: function (data) {
            swal('', 'Error al intentar recuperar los datos de calficaciones, vuelva a intentarlo por favor', 'error');
           
        }
    });

    

}