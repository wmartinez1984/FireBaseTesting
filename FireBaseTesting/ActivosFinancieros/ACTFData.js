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
        swal('Error:', 'No podemos cargar tus datos en este momento, comuníquese al whatsapp 55-6874-9040 para obtener  ayuda', 'error');
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