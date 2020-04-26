
function Recalcular(obj) {

    //Convertir tabla a Array
    var table = document.getElementById("TableResult");
    var result = []
    var rows = table.rows;
    var cells, t;

    // Iterate over rows
    for (var i = 0, iLen = rows.length; i < iLen; i++) {
        cells = rows[i].cells;
        t = [];

        // Iterate over cells
        for (var j = 0, jLen = cells.length; j < jLen; j++) {
            t.push(cells[j].textContent);
        }
        result.push(t);
    }

    
    LlenarExel(result, document.getElementById('txtSesiones').value, document.getElementById('txtRapidaInicial').value, document.getElementById('txtRapidaFinal').value, document.getElementById('txtMMLenta').value, document.getElementById('txtMMLentaFinal').value);

}

function LlenarExelPestana2MasColumnas(objData, Sesiones, RapidaInicial, RapidaFinal, LentaInicial, LentaFinal) {

    // swal('Ejecutando cálculos', 'No cierre hasta que el proceso termine, por favor espere...', 'warning');
    document.getElementById('spanEsperando').style.color = "#71c55d";
    document.getElementById('spanEsperando').innerHTML = "Cargando Resultado Final, por favor espere...";

    try {
        $.ajax({
            type: "POST",
            url: "Simulador.aspx.ashx?Action=TechnicalAnalysisExceMasColumnas&Sesiones=" + Sesiones + "&RapidaInicial=" + RapidaInicial + "&RapidaFinal=" + RapidaFinal + "&LentaInicial=" + LentaInicial + "&LentaFinal=" + LentaFinal + "&CapitalInicial=" + document.getElementById('txtCapitalIncial').value + "&ComisionEntrada=" + document.getElementById('txtValorComisionEntrada').value + "&ComisionSalida=" + document.getElementById('txtValorComisionSalida').value + "&Activo=" + document.getElementById('SelectActivo').value + "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (d) {

                var exists = false;
                var count = 0;
                $.each(d, function (index, item) {
                    exists = true;
                    document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                    document.getElementById('spanEsperando').style.color = "#2b8036";
                    document.getElementById('aDescarga').style.display = "inline";
                    document.getElementById('aDescargaSenales').style.display = "inline";
                    document.getElementById('aDescargaResult').style.display = "inline";
                    document.getElementById('btnRecarlcular').style.display = "none";
                    swal('Terminamos..!', 'El proceso ha concluido correctamente, haga click en ok y luego descargue el resultado!', 'success');
                });

                if (!exists) {

                    document.getElementById('spanEsperando').style.color = "red";
                    document.getElementById('spanEsperando').innerHTML = "El proceso no terminó correctamente, por favor vuelva a intentarlo";
                    document.getElementById('btnRecarlcular').style.display = "inline";
                    swal('No ha terminando el proceso', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'error');
                }



            },
            failure: function (r) {

                document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                document.getElementById('spanEsperando').style.color = "#2b8036";
                document.getElementById('aDescarga').style.display = "inline";

                document.getElementById('btnRecarlcular').style.display = "inline";
                //swal('Failure:', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'warning');
                return false;
            },
            error: function (r) {

                document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                document.getElementById('spanEsperando').style.color = "#2b8036";
                document.getElementById('aDescarga').style.display = "inline";

                document.getElementById('btnRecarlcular').style.display = "inline";
                // swal('Error:', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'warning');
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


function LlenarExelPestana3(objData, Sesiones, RapidaInicial, RapidaFinal, LentaInicial, LentaFinal) {

    // swal('Ejecutando cálculos', 'No cierre hasta que el proceso termine, por favor espere...', 'warning');
    document.getElementById('spanEsperando').style.color = "#71c55d";
    document.getElementById('spanEsperando').innerHTML = "Calculando  Resultado Final  (pestaña 3), por favor espere...";

    try {
        $.ajax({
            type: "POST",
            url: "Simulador.aspx.ashx?Action=TechnicalAnalysisExcelP3&Sesiones=" + Sesiones + "&RapidaInicial=" + RapidaInicial + "&RapidaFinal=" + RapidaFinal + "&LentaInicial=" + LentaInicial + "&LentaFinal=" + LentaFinal + "&CapitalInicial=" + document.getElementById('txtCapitalIncial').value + "&ComisionEntrada=" + document.getElementById('txtValorComisionEntrada').value + "&ComisionSalida=" + document.getElementById('txtValorComisionSalida').value + "&Activo=" + document.getElementById('SelectActivo').value + "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (d) {

                var exists = false;
                var count = 0;
                $.each(d, function (index, item) {
                    exists = true;

                    //document.getElementById('spanEsperando').style.color = "#2b8036";
                    //document.getElementById('aDescarga').style.display = "inline";
                    document.getElementById('btnRecarlcular').style.display = "none";
                    //swal('Terminamos..!', 'El proceso ha concluido correctamente, haga click en ok y luego descargue el resultado!', 'success');
                });

                if (!exists) {

                    document.getElementById('spanEsperando').style.color = "red";
                    document.getElementById('spanEsperando').innerHTML = "El proceso no terminó correctamente, por favor vuelva a intentarlo";
                    document.getElementById('btnRecarlcular').style.display = "inline";
                    swal('No ha terminando el proceso', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'error');
                }
                else {

                    LlenarExelPestana2MasColumnas("", document.getElementById('txtSesiones').value, document.getElementById('txtRapidaInicial').value, document.getElementById('txtRapidaFinal').value, document.getElementById('txtMMLenta').value, document.getElementById('txtMMLentaFinal').value);

                }



            },
            failure: function (r) {

                document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                document.getElementById('spanEsperando').style.color = "#2b8036";
                document.getElementById('aDescarga').style.display = "inline";

                document.getElementById('btnRecarlcular').style.display = "inline";
                //swal('Failure:', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'warning');
                return false;
            },
            error: function (r) {

                document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                document.getElementById('spanEsperando').style.color = "#2b8036";
                document.getElementById('aDescarga').style.display = "inline";

                document.getElementById('btnRecarlcular').style.display = "inline";
                // swal('Error:', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'warning');
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

function LlenarExelPestana2y3(objData, Sesiones, RapidaInicial, RapidaFinal, LentaInicial, LentaFinal) {

    // swal('Ejecutando cálculos', 'No cierre hasta que el proceso termine, por favor espere...', 'warning');
    document.getElementById('spanEsperando').style.color = "#71c55d";
    document.getElementById('spanEsperando').innerHTML = "Calculando Señales  (pestaña 2), por favor espere...";

    try {
        $.ajax({
            type: "POST",
            url: "Simulador.aspx.ashx?Action=TechnicalAnalysisExcelP2y3&Sesiones=" + Sesiones + "&RapidaInicial=" + RapidaInicial + "&RapidaFinal=" + RapidaFinal + "&LentaInicial=" + LentaInicial + "&LentaFinal=" + LentaFinal + "&CapitalInicial=" + document.getElementById('txtCapitalIncial').value + "&ComisionEntrada=" + document.getElementById('txtValorComisionEntrada').value + "&ComisionSalida=" + document.getElementById('txtValorComisionSalida').value + "&Activo=" + document.getElementById('SelectActivo').value + "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (d) {

                var exists = false;
                var count = 0;
                $.each(d, function (index, item) {
                    exists = true;
                    
                    //document.getElementById('spanEsperando').style.color = "#2b8036";
                    //document.getElementById('aDescarga').style.display = "inline";
                    document.getElementById('btnRecarlcular').style.display = "none";
                    //swal('Terminamos..!', 'El proceso ha concluido correctamente, haga click en ok y luego descargue el resultado!', 'success');
                });

                if (!exists) {

                    document.getElementById('spanEsperando').style.color = "red";
                    document.getElementById('spanEsperando').innerHTML = "El proceso no terminó correctamente, por favor vuelva a intentarlo";
                    document.getElementById('btnRecarlcular').style.display = "inline";
                    swal('No ha terminando el proceso', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'error');
                }
                else {

                    LlenarExelPestana3("", document.getElementById('txtSesiones').value, document.getElementById('txtRapidaInicial').value, document.getElementById('txtRapidaFinal').value, document.getElementById('txtMMLenta').value, document.getElementById('txtMMLentaFinal').value);

                }



            },
            failure: function (r) {

                document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                document.getElementById('spanEsperando').style.color = "#2b8036";
                document.getElementById('aDescarga').style.display = "inline";

                document.getElementById('btnRecarlcular').style.display = "inline";
                //swal('Failure:', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'warning');
                return false;
            },
            error: function (r) {

                document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                document.getElementById('spanEsperando').style.color = "#2b8036";
                document.getElementById('aDescarga').style.display = "inline";

                document.getElementById('btnRecarlcular').style.display = "inline";
                // swal('Error:', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'warning');
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

function LlenarExel(objData, Sesiones, RapidaInicial, RapidaFinal, LentaInicial, LentaFinal) {

   // swal('Ejecutando cálculos', 'No cierre hasta que el proceso termine, por favor espere...', 'warning');
    document.getElementById('spanEsperando').style.color = "#71c55d";
    document.getElementById('spanEsperando').innerHTML = "Exportando datos (pestaña 1), por favor espere...";
    
    try {
        $.ajax({
            type: "POST",
            url: "Simulador.aspx.ashx?Action=TechnicalAnalysisExcel&Sesiones=" + Sesiones + "&RapidaInicial=" + RapidaInicial + "&RapidaFinal=" + RapidaFinal + "&LentaInicial=" + LentaInicial + "&LentaFinal=" + LentaFinal + "&CapitalInicial=" + document.getElementById('txtCapitalIncial').value + "&ComisionEntrada=" + document.getElementById('txtValorComisionEntrada').value + "&ComisionSalida=" + document.getElementById('txtValorComisionSalida').value + "",
            data: JSON.stringify(objData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (d) {

                var exists = false;
                var count = 0;
                $.each(d, function (index, item) {
                    exists = true;
                    
                    //document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                    ///document.getElementById('spanEsperando').style.color = "#2b8036";
                    //document.getElementById('aDescarga').style.display = "inline";
                    //document.getElementById('btnRecarlcular').style.display = "none";
                    //swal('Terminamos..!', 'El proceso ha concluido correctamente, haga click en ok y luego descargue el resultado!', 'success');
                });

                if (!exists) {

                    document.getElementById('spanEsperando').style.color = "red";
                    document.getElementById('spanEsperando').innerHTML = "El proceso no terminó correctamente, no se pudo procesar la pestaña 2, por favor vuelva a intentarlo";
                    document.getElementById('btnRecarlcular').style.display = "inline";
                    swal('No ha terminando el proceso', 'El proceso no terminó correctamente, no se pudo procesar la pestaña 2, por favor vuelva a intentarlo', 'error');
                }
                else {
                    LlenarExelPestana2y3("", document.getElementById('txtSesiones').value, document.getElementById('txtRapidaInicial').value, document.getElementById('txtRapidaFinal').value, document.getElementById('txtMMLenta').value, document.getElementById('txtMMLentaFinal').value);

                }
                   
                

            },
            failure: function (r) {

                //document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
               // document.getElementById('spanEsperando').style.color = "#2b8036";
                //document.getElementById('aDescarga').style.display = "inline";     
                
                document.getElementById('btnRecarlcular').style.display = "inline";
                //swal('Failure:', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'warning');
                return false;
            },
            error: function (r) {

               // document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede descargar el resultado";
                //document.getElementById('spanEsperando').style.color = "#2b8036";
                //document.getElementById('aDescarga').style.display = "inline";     
                
                document.getElementById('btnRecarlcular').style.display = "inline";
               // swal('Error:', 'El proceso no terminó correctamente, por favor vuelva a intentarlo', 'warning');
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

function confirmar() {

    document.getElementById('divConfirm').style.display = "none";
    document.getElementById('divResultados').style.display = "inline";
    window.scrollTo(0, 0);

    var ApiKeyList = document.getElementById('spanApiKeys').innerHTML;
    var Keys = ApiKeyList.split('|');
    var countCall = 0;
    var TotalCall = document.getElementById('txtMMLentaFinal').value;
    var periodo = 1; // PORQUE LA PRIMERA LLAMADA CORRESPONDE AL PRECIO, INICIARÍA EN 2 CUANDO CONSULE EMAS...
    for (var i = 0; i < Keys.length; i++) {
        //Keys[i]
        if (Keys[i] != "") {
            countCall += 1;
            if (countCall <= TotalCall) {

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

    //swal('Incia el proceso', 'Por favor espere, este proceso puede tardar varios minutos...', 'warning');
    var Sesiones = document.getElementById('txtSesiones').value;
    var RapidaInicial = document.getElementById('txtRapidaInicial').value;
    var RapidaFinal = document.getElementById('txtRapidaFinal').value;
    var LentaInicial = document.getElementById('txtMMLenta').value;
    var LentaFinal = document.getElementById('txtMMLentaFinal').value;

    var Filas = parseInt(Sesiones);
    var  ConsultaInicial = document.getElementById('spanTotal').innerHTML;
    var ValCell = document.getElementById("TableResult").rows[Filas -1 ].cells;
    ValCell[columna].innerHTML = apikey;

    try {
        $.ajax({
            type: "POST",
            url: "Simulador.aspx.ashx?Action=TechnicalAnalysis&apikey=" + apikey + "&series_type=" + series_type + "&time_period=" + time_period + "&interval=" + interval + "&symbol=" + symbol + "&indicador=" + indicador + "&Sesiones=" + Sesiones + "&LentaFinal=" + columna + "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    exists = true;
                    count += 1;

                    if (count <= Sesiones) {
                        if (columna == 2) {
                            var fechaCell = document.getElementById("TableResult").rows[count].cells;
                            fechaCell[0].innerHTML = item.Name;
                            var ValCell = document.getElementById("TableResult").rows[count].cells;
                            ValCell[2].innerHTML = item.Value;
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

                    if (TotalConsultasEjecutadas > (LentaFinal - 1)) {
                        document.getElementById('spanEsperando').innerHTML = "El proceso ha terminado, puede continuar"; 

                        var keys = [], arrayObj = [];
                        $("#TableResult thead tr th").each(function () {
                            keys.push($(this).html());
                        });

                        $("#TableResult tbody tr").each(function () {
                            var obj = {}, i = 0;
                            $(this).children("td").each(function () {
                                obj[keys[i]] = $(this).html();
                                i++;
                            })
                            arrayObj.push(obj);
                        });

                        
                        //Convertir tabla a Array
                        var table = document.getElementById("TableResult");
                        var result = []
                        var rows = table.rows;
                        var cells, t;
                        
                        // Iterate over rows
                        for (var i = 0, iLen = rows.length; i < iLen; i++) {
                            cells = rows[i].cells;
                            t = [];

                            // Iterate over cells
                            for (var j = 0, jLen = cells.length; j < jLen; j++) {
                                t.push(cells[j].textContent);
                            }
                            result.push(t);
                        }

                        LlenarExel(result, Sesiones, RapidaInicial, RapidaFinal, LentaInicial, LentaFinal);
                        //var sJSON = JSON.stringify(result);

                       // document.getElementById("demoDiv").innerHTML = sJSON;
                    }
                        

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

    var Tabl = document.getElementById('TableResult').style.backgroundColor;
    var Sesiones = document.getElementById('txtSesiones').value;

    //swal('Configurando parámetros', 'Por favor espere...', 'success');
    var columnas = document.getElementById('txtMMLentaFinal').value;
    //Agregar columna 
    
    $("#TableResult tbody tr").each(function () {
        this.parentNode.removeChild(this);
    });

    var table = document.getElementById('TableResult').insertRow(0);
    var ColumnasCount = 2; 
    for (c = 0; c <= columnas; c++) {

        
        var y = table.insertCell(c);
        if (c == 0) {

            y.style.backgroundColor = "#009688";
            y.innerHTML = "Waiting";

        }
        else {
            y.innerHTML = "Waiting";
            ColumnasCount++;
        }
            
    }
    
    //Agrego las filas de acuerdo a las sessiones especificadas en el formulario  Waiting
    for (row = 1; row < Sesiones; row++) {
        
        var table = document.getElementById('TableResult');       

        var x = table.insertRow(0);
        var e = table.rows.length - 1;
        var l = table.rows[e].cells.length;        

        var ColumnasCount = 2;
        for (var c = 0, m = l; c < m; c++) {           
            table.rows[0].insertCell(c);
            table.rows[0].cells[c].innerHTML = "Waiting";
        }

    }

    ColumnasCount = 2;
    var table = document.getElementById("TableResult");
    var header = table.createTHead();
    var row = header.insertRow(0);
    for (c2 = 0; c2 <= columnas; c2++) {
        if (c2 == 0) {
            var cell = row.insertCell(c2);
            cell.innerHTML = "<b>Date</b>";
            cell.style.backgroundColor = "#009688";
        }
        else if (c2 == 1) {
            var cell = row.insertCell(c2);
            cell.innerHTML = "<b>Price</b>";
            cell.style.backgroundColor = "#009618";
        }
        else {
            var cell = row.insertCell(c2);
            cell.innerHTML = ColumnasCount;
            ColumnasCount++;
        }
    }

    //swal('Ok', 'Los parámetros fueron configurado correctamente...', 'success');

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
                    s += '<option value="' + item.symbol + '">' + item.symbol + ' - ' + item.name + ' - ' + item.currency + '</option>';
                    
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