function confirmar() {
    document.getElementById('divConfirm').style.display = "none";
    document.getElementById('divResultados').style.display = "inline";
    window.scrollTo(0, 0);

    var ApiKeyList = document.getElementById('spanApiKeys').innerHTML;
    var Keys = ApiKeyList.split('|');
    var countCall = 0;
    var TotalCall = 60;
    var periodo = 2;
    for (var i = 0; i < Keys.length; i++) {
        //Keys[i]
        if (Keys[i] != "") {
            countCall += 1;
            if (countCall < TotalCall) {

                ApiTechnicalAnalysis(Keys[i], document.getElementById('SelectTipoPrecio').value, periodo, document.getElementById('SelectTemporalidad').value, document.getElementById('SelectActivo').value, document.getElementById('SelectIndicador').value, countCall);
                periodo = periodo + 1;

                var TotalEjecutadas = i + 1;
                if (TotalEjecutadas == Keys.length && countCall < TotalCall)
                    i = 0;
            }
            else {
                return false;
            }


        }
        var TotalEjecutadas = i + 1;
        if (TotalEjecutadas == Keys.length && countCall < TotalCall)
            i = 0;

    }
  
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

                if (exists)
                    swal('Datos necesarios', 'No olvide parametrizar los datos necesarios para iniciar con la simulación, presione Ok para continuar :)  ', 'success');
                

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

    //swal('Incia el proceso', 'Por favor espere, este proceso puede tardar varios minutos...', 'warning');
    var Sesiones = document.getElementById('txtSesiones').value;
    var  ConsultaInicial = document.getElementById('spanTotal').innerHTML;
    var ValCell = document.getElementById("TableResult").rows[99].cells;
    ValCell[columna].innerHTML = apikey;

    try {
        $.ajax({
            type: "POST",
            url: "Simulador.aspx.ashx?Action=TechnicalAnalysis&apikey=" + apikey + "&series_type=" + series_type + "&time_period=" + time_period + "&interval=" + interval + "&symbol=" + symbol + "&indicador=" + indicador + "&Sesiones=" + Sesiones + "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    exists = true;
                    count += 1;

                    if (count <= Sesiones) {
                        if (columna == 1) {
                            var fechaCell = document.getElementById("TableResult").rows[count].cells;
                            fechaCell[0].innerHTML = item.Name;
                            var ValCell = document.getElementById("TableResult").rows[count].cells;
                            ValCell[1].innerHTML = item.Value;
                           // ValCell[1].innerHTML = item.Value + ":\n" + apikey + ":\n" + time_period;
                        }
                        else {

                            var ValCell = document.getElementById("TableResult").rows[count].cells;
                            ValCell[columna].innerHTML = item.Value;
                            //ValCell[columna].innerHTML = item.Value + ":\n" + apikey + ":\n" + time_period;
                            
                        }
                       

                    }
                    else {
                        return false;
                    }
                   

                });

                
                if (!exists) {
                    swal('Sin Data:', 'No hemos podido consultar información con  el Api Key ' + apikey + '', 'error');
                }
                else {

                    var TotalConsultasEjecutadas = parseInt(document.getElementById('spanTotal').innerHTML);
                    TotalConsultasEjecutadas += 1;
                    document.getElementById('spanTotal').innerHTML = TotalConsultasEjecutadas;

                    if (TotalConsultasEjecutadas >=59)
                        document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede continuar"; 
                }
                   

            },
            failure: function (r) {
                var TotalConsultasEjecutadas = parseInt(document.getElementById('spanTotal').innerHTML);
                TotalConsultasEjecutadas += 1;
                document.getElementById('spanTotal').innerHTML = TotalConsultasEjecutadas;
                return false;
            },
            error: function (r) {
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
    //Agrego las filas de acuerdo a las sessiones especificadas en el formulario 
    for (row = 1; row <= Sesiones; row++) {
        $('#TableResult').append($('<tr>')
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))

            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))

            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))

            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))

            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))

            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))
            .append($('<td>').append("Waiting..."))


        )
    }

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