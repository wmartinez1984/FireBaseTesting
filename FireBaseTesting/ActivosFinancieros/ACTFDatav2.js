
function MostrarDetalle(obj) { 

  
    document.getElementById('hmensaje').innerHTML = "Cargando información, por favor espere...";
    $("#TableActivos tbody tr").each(function () {
        this.parentNode.removeChild(this);
    });

     //$('#TableActivos').DataTable({
     //                   "ajax": "Activos.ashx?Action=ResultadosDetalleList&id=" + obj.title +"",
     //                   "columns": [
     //                       { "data": "Senal" },
     //                       { "data": "Senal" },
     //                       { "data": "Senal" },
     //                       { "data": "Senal" },
     //                       { "data": "Senal" },
     //                       { "data": "Senal" }
     //                   ]
     //               });
   
    try {
        $.ajax({
            type: "POST",
            url: "Activos.ashx?Action=ResultadosDetalleList&id=" + obj.title +"",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
               

              

                $.each(data, function (index, item) {
                    exists = true;

                   

                    $('#TableActivos').append("<tr>  <td style='text-align:center;'>" + item.Senal + "</td><td style='text-align:center;'>" + item.Cantidaddedias + "</td><td style='text-align:center;'>" + item.Cantidadediasfueradelmercado + "</td> <td style='text-align:center;'>" + item.Cantidaddediasdentrodelmercado + "</td> <td style='text-align:center;'>" + item.CantidadtotaldeOperaciones + "</td> <td style='text-align:center;'>" + item.CantidadtotaldeOPGanadoras + "</td> <td style='text-align:center;'>" + item.CantidadtotaldeOPPerdedoras + "</td> <td style='text-align:center;'>" + item.GananciaMaxima + "</td> <td style='text-align:center;'>" + item.PerdidaMaxima + "</td> <td style='text-align:center;'>" + item.PerformanceTotal + "</td> <td style='text-align:center;'>" + item.PerformanceAnualizada + "</td>  <td style='text-align:center;'>" + item.PerformanceBuyAndHold + "</td>  <td style='text-align:center;'>" + item.PerformanceBuyAndHoldAnualizada + "</td>  <td style='text-align:center;'>" + item.EM + "</td> <td style='text-align:center;'>" + item.RachaGanadora + "</td> <td style='text-align:center;'>" + item.RachaPerdedora + "</td> </tr>");
                   
                });

                
                document.getElementById('hmensaje').innerHTML = "";
                $("#TableActivos").DataTable();
              


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
    return false;

}
function MostrarModal() {
    document.getElementById('myModal').style.display = 'block';
}

function ResultadosList() {


    $("#TableActivosRegistrados tbody tr").each(function () {
        this.parentNode.removeChild(this);
    });

    try {
        $.ajax({
            type: "POST",
            url: "Activos.ashx?Action=ResultadosList",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    exists = true;

                    var String_ValueDate = item.Fecha;
                    var value = new Date
                        (
                            parseInt(String_ValueDate.replace(/(^.*\()|([+-].*$)/g, ''))
                        );

                    var dat = value.toLocaleString("es-MX");

                    $('#TableActivosRegistrados').append("<tr>  <td style='text-align:center;'><i class='fa fa-plus' aria-hidden='true' style='font-size:20px;cursor:pointer;' ><a href='ReporteDetalle.aspx?id=" + item.id + "' target='_blank'> Detalle </a></i> </td>  <td style='text-align:center;'><i class='fa fa-trash' aria-hidden='true' style='font-size:20px;cursor:pointer;' title='" + item.id + "' onclick='Eliminar(this); return false;'>Eliminar</i> </td> <td style='text-align:center;'>" + dat + "</td><td style='text-align:center;'>" + item.Activo + "</td><td style='text-align:center;'>" + item.Estrategia + "</td> <td style='text-align:center;'>" + item.Secciones + "</td> <td style='text-align:center;'>" + item.Indicador + "</td> <td style='text-align:center;'>" + item.Temporalidad + "</td> <td style='text-align:center;'>" + item.TipoPrecio + "</td> <td style='text-align:center;'>" + item.CapitalInicial + "</td> <td style='text-align:center;'>" + item.resultados + "</td> <td style='text-align:center;'>" + item.ComisionEntrada + "</td> <td style='text-align:center;'>" + item.ComisionSalida + "</td>  </tr>");

                });

                $("#TableActivosRegistrados").DataTable();

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

function ActivosRegistradosEliminar(btn) {

    try {


        
        swal('Eliminando…', 'Estamos eliminando el Activo, por favor espere, no cierre esta ventana hasta que el proceso termine…', 'warning');
        $.ajax({
            type: "POST",
            url: "Activos.ashx?Action=DeleteAct&id=" + btn.title + "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                ActivosRegistradosList();
                swal('Eliminado!', 'El Activo fue eliminado correctamente', 'success');

            },
            failure: function (r) {
                swal('Error:', 'Error al eliminar el Activo, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            },
            error: function (r) {
                swal('Error:', 'Error al eliminar el Activo, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            }

        });



    }
    catch (err) {
        swal('Error:', 'Error al eliminar el Activo, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}

function ActivosRegistradosList() {

   
    $("#TableActivosRegistrados tbody tr").each(function () {
        this.parentNode.removeChild(this);
    });

    try {
        $.ajax({
            type: "POST",
            url: "Activos.ashx?Action=ActivoRegistradosList",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    exists = true;
                    $('#TableActivosRegistrados').append("<tr>  <td style='text-align:center;'>" + item.symbol + "</td><td style='text-align:center;'>" + item.name + "</td><td style='text-align:center;'>" + item.type + "</td> <td style='text-align:center;'>" + item.region + "</td> <td style='text-align:center;'>" + item.marketOpen + "</td> <td style='text-align:center;'>" + item.marketClose + "</td> <td style='text-align:center;'>" + item.timezone + "</td> <td style='text-align:center;'>" + item.currency + "</td> <td style='text-align:center;'>" + item.matchScore + "</td><td style='text-align:center;'><button style='width: 100px; background - color: #ff0000; border - radius: 12px;' title='" + item.id + "' onclick='ActivosRegistradosEliminar(this); return false;'>- Eliminar </button></td> </tr>");
                    
                });


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
function ActivoSave(obj) {
    var str = obj.title;
    var res = str.split("|");

    //VALIDAR SI EXISTE
    var ExistsKey = false;
    var table = document.getElementById("TableActivosRegistrados");
    var r = 0;
    while (row = table.rows[r++]) {
        var c = 0;
        while (cell = row.cells[c++]) {
            if (c == 2) {
                var span = cell.innerHTML; //Obtengo el span que está dentro de la celda
                //pregunto si es igual a lo que se está capturando
                if (res[1] == span) {
                    ExistsKey = true;
                    break;
                }

            }
        }
    }
    // 
    if (ExistsKey) {
        swal('Error:', 'Ya está registrado el Activo ' + res[1] +' ', 'error');
        return false;

    }

    swal('Registrando...', 'Estamos registrando los datos, por favor espere....', 'warning');
    try {
        $.ajax({
            type: "POST",
            url: "Activos.ashx?Action=ActivoInsert&symbol=" + res[0] +
                "&name=" + res[1] +
                "&type=" + res[2] +
                "&region=" + res[3] +
                "&marketOpen=" + res[4] +
                "&marketClose=" + res[5] +
                "&timezone=" + res[6] +
                "&currency=" + res[7] +
                "&matchScore=" + res[8] +"",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                    ActivosRegistradosList();
                    swal('Datos guardados', 'El activo se registró correctamente en el sistema', 'success');
               
            },
            failure: function (r) {               
                swal('Error:', 'No podemos guardar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            },
            error: function (r) {
               
                swal('Error:', 'No podemos guardar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            }

        });

    }
    catch (err) {
        swal('Error:', 'No podemos guardar los datos en este momento', 'error');
        return false;
    }
    return false;

}

function ActivoList(keywords) {

    document.getElementById('message').innerHTML = "Consultando información...";
    $("#TableActivos tbody tr").each(function () {
        this.parentNode.removeChild(this);
    });
   
    try {
        $.ajax({
            type: "POST",
            url: "Activos.ashx?Action=ActivoList&keywords=" + keywords +"",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    exists = true;

                    $('#TableActivos').append("<tr>  <td style='text-align:center;'>" + item.symbol + "</td><td style='text-align:center;'>" + item.name + "</td><td style='text-align:center;'>" + item.type + "</td> <td style='text-align:center;'>" + item.region + "</td> <td style='text-align:center;'>" + item.marketOpen + "</td> <td style='text-align:center;'>" + item.marketClose + "</td> <td style='text-align:center;'>" + item.timezone + "</td> <td style='text-align:center;'>" + item.currency + "</td> <td style='text-align:center;'>" + item.matchScore + "</td><td style='text-align:center;'><button style='width: 100px; background - color: #ff0000; border - radius: 12px;' title='" + item.symbol + "|" + item.name + "|" + item.type + "|" + item.region + "|" + item.marketOpen + "|" + item.marketClose + "|" + item.timezone + "|" + item.currency + "|" + item.matchScore  + "' onclick='ActivoSave(this); return false;'>+ Guardar </button></td> </tr>");
                    document.getElementById('message').innerHTML = "";
                });

                
            },
            failure: function (r) {
                document.getElementById('message').innerHTML = "";
                swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            },
            error: function (r) {
                // alert(r.error + " Permisos");
                document.getElementById('message').innerHTML = "";
                swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            }

        });

    }
    catch (err) {
        document.getElementById('message').innerHTML = "";
        swal('Error:', 'No podemos cargar tus datos en este momento', 'error');
        return false;
    }
    return false;

}

function KeyListData() {

    //document.getElementById('HiddenEstadoOP').value = 5;
    $("#KeytableList tbody tr").each(function () {
        this.parentNode.removeChild(this);
    });
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
                    var id = item.id;
                    exists = true;
                    count += 1;
                    var String_ValueDate = item.CreationDate;
                    var value = new Date
                        (
                            parseInt(String_ValueDate.replace(/(^.*\()|([+-].*$)/g, ''))
                    );

                    var dat = value.toLocaleString("es-MX");
                    $('#KeytableList').append("<tr>  <td style='text-align:center;'>" + count + "</td><td style='text-align:center;'>" + item.KeyApi + "</td><td style='text-align:center;'>" + dat + "</td><td style='text-align:center;'><button style='width: 100px; background - color: #ff0000; border - radius: 12px;' title=" + id + " onclick='DeleteKey(this); return false;'>Eliminar</button></td> </tr>");
                    
                });

                if (exists)
                    document.getElementById('spanTotal').innerHTML = count;
                else
                    document.getElementById('spanTotal').innerHTML = 0;
            },
            failure: function (r) {
               
                swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                return false;
            },
            error: function (r) {
                // alert(r.error + " Permisos");
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

function DeleteKey(btn) {
    
    try {

       
            //EJECUTO EL AJAX PARA ENVIAR LA PETICIÓN DE GUARDADO O ACTUALIZACIÓN
            swal('Eliminando Api Key…', 'Estamos eliminando el API Key, por favor espere, no cierre esta ventana hasta que el proceso termine…', 'warning');
            $.ajax({
                type: "POST",
                url: "ApiKey.aspx.ashx?Action=DeleteKey&id=" + btn.title + "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    KeyListData();
                    swal('Key Eliminado', 'El API Key fue eliminado correctamente', 'success');

                },
                failure: function (r) {
                    swal('Error:', 'Error al eliminar el API Key, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                },
                error: function (r) {
                    swal('Error:', 'Error al eliminar el API Key, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                }

            });
        


    }
    catch (err) {
        swal('Error:', 'Error al eliminar el API Key, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}
function SaveKeys() {

    var message = "";
   
    try {

        //VALIDAR SI NO ESTÁ VACÍO EL CAMPO 
        if (document.getElementById('txtApiKey').value == "") {
            message += "Debe capturar el API Key\n";

        }
        //VALIDAR SI EXISTE
        var ExistsKey = false;
        var table = document.getElementById("KeytableList");
        var r = 0;
        while (row = table.rows[r++]) {
            var c = 0;
            while (cell = row.cells[c++]) {
                if (c == 2) {
                    var span = cell.innerHTML; //Obtengo el span que está dentro de la celda
                    //pregunto si es igual a lo que se está capturando
                    if (document.getElementById('txtApiKey').value == span) {
                        ExistsKey = true;
                        break;
                    }

                }
            }
        }
        // 
        if (ExistsKey) {
            message += "Ya existe el Api Key que capturó\n";

        }
        //VALIDO SI ALGUN MENSAJE POR MOSTRAR 
        if (message != "") {
            swal('Por favor verifique lo siguiente: ', message, 'warning');
            return false;
        }
        else {
            //EJECUTO EL AJAX PARA ENVIAR LA PETICIÓN DE GUARDADO O ACTUALIZACIÓN
            swal('Registrando información…', 'Estamos registrando el API , por favor espere, no cierre esta ventana hasta que la información termine de registrarse…', 'warning');
            $.ajax({
                type: "POST",
                url: "ApiKey.aspx.ashx?Action=InsertKey&KeyApi=" + document.getElementById('txtApiKey').value + "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    document.getElementById('txtApiKey').value = "";;
                    KeyListData();
                    swal('API Key registrada', 'El API Key fue registrada correctamente', 'success');

                },
                failure: function (r) {
                    swal('Error:', 'Error al registrar el API Key, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                },
                error: function (r) {
                    swal('Error:', 'Error al registrar el API Key, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                }

            });
        }


    }
    catch (err) {
        swal('Error:', 'Error al registrar el API Key, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}