function confirmar() {
    document.getElementById('divConfirm').style.display = "none";
    document.getElementById('divLoading').style.display = "inline";

    window.scrollTo(0, 0);
    var ApiKeyList = document.getElementById('spanApiKeys').innerHTML;
    var periodo = 2;   
    ApiTechnicalAnalysis(ApiKeyList, document.getElementById('SelectTipoPrecio').value, periodo, document.getElementById('SelectTemporalidad').value, document.getElementById('SelectActivo').value, document.getElementById('SelectIndicador').value, 1);
    return false;
}

function KeyListData() {

    document.getElementById('spanApiKeys').innerHTML = "";
    try {
        $.ajax({
            type: "POST",
            url: "ApiKey.aspx.ashx?Action=keysList",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    exists = true;
                    count += 1;
                    document.getElementById('spanApiKeys').innerHTML += item.KeyApi + "|";
                  //  $('#KeytableList').append("<tr>  <td style='text-align:center;'>" + count + "</td><td style='text-align:center;'>" + item.KeyApi + "</td><td style='text-align:center;'>" + dat + "</td><td style='text-align:center;'><button style='width: 100px; background - color: #ff0000; border - radius: 12px;' title=" + id + " onclick='DeleteKey(this); return false;'>Eliminar</button></td> </tr>");

                });

                if (!exists) {
                    swal('Error:', 'Usted debe parametrizar por lo menos 12 Api Key para poder ejecutar el proceso de Simulación', 'error');
                    document.getElementById('spanApiKeys').innerHTML = "";
                    return false;
                }
                   
                if (count < 12 && count > 0) {
                    swal('Error:', 'Usted debe parametrizar por lo menos 12 Api Key para poder ejecutar el proceso de Simulación', 'error');
                    document.getElementById('spanApiKeys').innerHTML = "";
                    return false;
                }

               // if (exists)
                   // swal('Datos necesarios', 'No olvide parametrizar los datos necesarios para iniciar con la simulación, presione Ok para continuar :)  ', 'success');
                

            },
            failure: function (r) {

                swal('Error:', 'No podemos cargar los API Keys en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            },
            error: function (r) {
                // alert(r.error + " Permisos");
                swal('Error:', 'No podemos cargar los API Keys en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            }

        });

    }
    catch (err) {
        swal('Error:', 'No podemos cargar los API Keys en este momento', 'error');
        return false;
    }
    return false;

}

function ApiTechnicalAnalysis(apikey, series_type, time_period, interval, symbol, indicador, columna) {



    var Sesiones = document.getElementById('txtSesiones').value;

    try {
        $.ajax({
            type: "POST",
            url: "Simulador.aspx.ashx?Action=TechnicalAnalysis&apikey=" + apikey + "&series_type=" + series_type + "&time_period=" + time_period + "&interval=" + interval + "&symbol=" + symbol + "&indicador=" + indicador + "&Sesiones=" + Sesiones + "&RapidaInicial=" + document.getElementById('txtRapidaInicial').value + "&RapidaFinal=" + document.getElementById('txtRapidaFinal').value + "&LentaInicial=" + document.getElementById('txtMMLenta').value + "&LentaFinal=" + document.getElementById('txtMMLentaFinal').value + "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    exists = true;

                    if (item.Name == "Error") {

                        swal('Error:', '' + item.Name + '', 'error');
                        document.getElementById('DivResultadoExel').innerHTML = item.Value;
                        return false;
                    }
                    else {
                        swal('Error:', '' + item.Name +'', 'error');
                    }
                   
                });

                
                if (!exists) {
                    swal('Sin Data:', 'No hemos podido terminar con el proceso, por favor intente más tarde', 'error');
                }
                else {

                    document.getElementById('divLoading').style.display = "none";
                    document.getElementById('DivResultadoExel').style.display = "inline";

                    swal('Proceso terminado!', 'Puede usted descargar el resultado a continuación, haga click en OK para continuar  :)  ', 'success');
                    var TotalConsultasEjecutadas = parseInt(document.getElementById('spanTotal').innerHTML);
                    TotalConsultasEjecutadas += 1;
                    document.getElementById('spanTotal').innerHTML = TotalConsultasEjecutadas;

                    if (TotalConsultasEjecutadas >=1)
                        document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede continuar"; 

                    return false;
                }
                   

            },
            failure: function (r) {
                var TotalConsultasEjecutadas = parseInt(document.getElementById('spanTotal').innerHTML);
                TotalConsultasEjecutadas += 1;
                document.getElementById('spanTotal').innerHTML = TotalConsultasEjecutadas;
                return false;
            },
            error: function (r) {
                swal('Error:', 'Error al ejecutar el proceso :(', 'error');
                var TotalConsultasEjecutadas = parseInt(document.getElementById('spanTotal').innerHTML);
                TotalConsultasEjecutadas += 1;
                document.getElementById('spanTotal').innerHTML = TotalConsultasEjecutadas;
                return false;
            }

        });

    }
    catch (err) {
        swal('Error:', 'No podemos cargar tus datos en este momento', 'error');
        return false;
    }
    return false;

}


function CrearTablaDinamicamente() {
    if (document.getElementById('SelectActivo').value == "") {
        swal('Error:', 'Debe seleccionar un Activo', 'error');
        return false;
    }

    if (document.getElementById('SelectIndicador').value == "") {
        swal('Error:', 'Debe seleccionar un Indicador', 'error');
        return false;
    }
    //Limpio la tabla antes de agregar dinamicamente las filas 
    $("#TableResult tbody tr").each(function () {
        this.parentNode.removeChild(this);
    });

    var Tabl = document.getElementById('TableResult');
    var Sesiones = document.getElementById('txtSesiones').value;

    

    document.getElementById('spamActivo').innerHTML = document.getElementById('SelectIndicador').value;
    document.getElementById('Symbol').innerHTML = document.getElementById('SelectActivo').value;
    document.getElementById('Interval').innerHTML = document.getElementById('SelectTemporalidad').value;
    document.getElementById('SeriesType').innerHTML = document.getElementById('SelectTipoPrecio').value;
    document.getElementById('Sesiones').innerHTML = Sesiones;


    document.getElementById('divConfirm').style.display = "inline";
    window.scrollTo(0, 0);
    document.getElementById('divConfirm').className = "bs-example container";
    document.getElementById('DivStep1').style.display = "none";
    
   
}

function ActivosRegistradosListComboBox() {


    try {
        $.ajax({
            type: "POST",
            url: "Activos.ashx?Action=ActivoRegistradosList",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                var s = '<option value="">Seleccione un Activo</option>';
                $.each(data, function (index, item) {
                    exists = true;
                    s += '<option value="' + item.symbol + '">' + item.name + '</option>';
                    
                });

                if (exists)
                    $("#SelectActivo").html(s);  

            },
            failure: function (r) {

                swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            },
            error: function (r) {
                swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            }

        });

    }
    catch (err) {
       
        swal('Error:', 'No podemos cargar tus datos en este momento', 'error');
        return false;
    }
    return false;

}