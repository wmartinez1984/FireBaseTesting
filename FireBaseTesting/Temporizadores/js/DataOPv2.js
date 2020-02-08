function OPResgistradasSelectTable() {

    
    $("#TableOP tbody tr").each(function () {
            this.parentNode.removeChild(this);
    });
    try {
        $.ajax({
            type: "POST",
            url: "DataOP.ashx?Action=OPRegistradasTable",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    exists = true;

                    var estatusOP = item.EestadoOP;

                    var estatusOP_ = "";
                    if (estatusOP == 1) {
                        estatusOP_ = "Iniciada";

                    }
                    if (item.EestadoL1 == 2 || item.EestadoL2 == 2 || item.EestadoL3 == 2) {
                        estatusOP_ = "Envasando";

                    }
                    else {
                        estatusOP_ = "Iniciada";

                    }
                    if (estatusOP == 3) {
                        estatusOP_ = "Detenida";

                    }

                    if (estatusOP == 4) {
                        estatusOP_ = "Lavando";

                    }

                    if (estatusOP == 5) {
                        estatusOP_ = "Terminada";

                    }
                   
                    $('#TableOP').append("<tr><td>" + item.OP + "</td><td>" + item.ProductoOP + "</td><td>" + item.Descripcion + "</td><td>" + item.Cantidad + "</td><td>" + item.NombreCliente + "</td><td>" + item.TiempoLavado + " Minutos" + "</td><td>" + estatusOP_ + "</td></tr>");
                    count += 1;
                    return true;
                });
               
            },
            failure: function (r) {
                //alert('Error al recuperar los permisos...');
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

function FinalizarOP() {

    var message = "";

    try {

        swal('Finalizando OP...', 'Estamos finalizando la OP, por favor espere, no cierre esta ventana hasta que el proceso termine…', 'warning');
        $.ajax({
            type: "POST",
            url: "DataOP.ashx?Action=FinalizarOP&OP=" + document.getElementsByName('DataspanOP')[0].value +
                "&ProductoOP=" + document.getElementsByName('NAVI')[0].value +
                "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value +
                "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value +
                "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value +
                "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value +
                "&DescripLavado=" + document.getElementById('normal-select-7').innerText +
                "&L1=" + document.getElementById('txtL1').value +
                "&L2=" + document.getElementById('txtL2').value +
                "&L3=" + document.getElementById('txtL3').value + "",

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                OPResgistradasSelectTable();
                OPResgistradasSelect();
                swal('OP Finalizada', 'La OP finalizó correctamente, puede iniciar el proceso con una nueva OP', 'success');
                document.getElementById('divIniciarLavado').style.display = 'none';
                document.getElementById('divLavando').style.display = 'none';

                // var myVar = setTimeout(location.reload(), 15000);
                return false;
            },
            failure: function (r) {
                swal('Error:', 'Error al finalizar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            },
            error: function (r) {
                swal('Error:', 'Error al finalizar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            }

        });
        return false;


        return false;
    }
    catch (err) {
        swal('Error:', 'Error al finalizar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;
}
function InciarLavado() {

    var message = "";

    try {

        swal('Iniciando  Lavado...', 'Estamos iniciando el lavado de la OP, por favor espere, no cierre esta ventana hasta que el proceso termine…', 'warning');
        $.ajax({
            type: "POST",
            url: "DataOP.ashx?Action=IniciarLavado&OP=" + document.getElementsByName('DataspanOP')[0].value +
                "&ProductoOP=" + document.getElementsByName('NAVI')[0].value +
                "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value +
                "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value +
                "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value +
                "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value +
                "&DescripLavado=" + document.getElementById('normal-select-7').innerText +
                "&L1=" + document.getElementById('txtL1').value +
                "&L2=" + document.getElementById('txtL2').value +
                "&L3=" + document.getElementById('txtL3').value +"",

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                OPResgistradasSelect();
                swal('Lavando OP', 'La OP inició el lavado correctamente', 'success');
                document.getElementById('divIniciarLavado').style.display = 'none';
                document.getElementById('divLavando').style.display = 'inline';

               // var myVar = setTimeout(location.reload(), 15000);
                return false;
            },
            failure: function (r) {
                swal('Error:', 'Error al iniciar el lavado, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            },
            error: function (r) {
                swal('Error:', 'Error al iniciar el lavado, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            }

        });
        return false;


        return false;
    }
    catch (err) {
        swal('Error:', 'Error al iniciar el lavado, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;
}

function IniciandoLineaPrimeraVez(Lid) {


    if (Lid == 1 && document.getElementById('txtL1').value != 1) {
        swal('Oops!', 'Sólo se puede iniciar una sola vez la línea 1', 'warning');
        return false;
    }

    if (Lid == 2 && document.getElementById('txtL2').value != 1) {
        swal('Oops!', 'Sólo se puede iniciar una sola vez la línea 2', 'warning');
        return false;
    }

    if (Lid == 3 && document.getElementById('txtL3').value != 1) {
        swal('Oops!', 'Sólo se puede iniciar una sola vez la línea 3', 'warning');
        return false;
    }

    if (Lid == 1 && (document.getElementById('normal-select-1').value == "" || document.getElementById('normal-select-2').value == "")) {
        swal('Oops!', 'Debe seleccionar la hora en que inició la línea 1', 'warning');
        return false;
    }

    if (Lid == 2 && (document.getElementById('normal-select-3').value == "" || document.getElementById('normal-select-4').value == "")) {
        swal('Oops!', 'Debe seleccionar la hora en que inició la línea 2', 'warning');
        return false;
    }

    if (Lid == 3 && (document.getElementById('normal-select-5').value == "" || document.getElementById('normal-select-6').value == "")) {
        swal('Oops!', 'Debe seleccionar la hora en que inició la línea 3', 'warning');
        return false;
    }

    if (Lid == 1)
        document.getElementById('txtL1').value = 2; // si la línea seleccionada es la 1, entonces ponemos el valor de la línea en 2 = Envansando

    if (Lid == 2)
        document.getElementById('txtL2').value = 2; // si la línea seleccionada es la 2, entonces ponemos el valor de la línea en 2 = Envansando

    if (Lid == 3)
        document.getElementById('txtL3').value = 2; // si la línea seleccionada es la 3, entonces ponemos el valor de la línea en 2 = Envansando



    var message = "";

    try {

        swal('Finalizando Línea...', 'Estamos iniciando la Línea No ' + Lid + ', por favor espere, no cierre esta ventana hasta que el proceso termine…', 'warning');
        $.ajax({
            type: "POST",
            url: "DataOP.ashx?Action=IniciandoHoraInicio&OP=" + document.getElementsByName('DataspanOP')[0].value +
                "&ProductoOP=" + document.getElementsByName('NAVI')[0].value +
                "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value +
                "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value +
                "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value +
                "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value +
                "&DescripLavado=" + document.getElementById('normal-select-7').innerText +
                "&L1=" + document.getElementById('txtL1').value +
                "&L2=" + document.getElementById('txtL2').value +
                "&L3=" + document.getElementById('txtL3').value +
                "&LP=" + Lid +
                "&InicioHoraL1=" + document.getElementById('normal-select-1').value +
                "&InicioMinutosL1=" + document.getElementById('normal-select-2').value +
                "&InicioHoraL2=" + document.getElementById('normal-select-3').value +
                "&InicioMinutosL2=" + document.getElementById('normal-select-4').value +
                "&InicioHoraL3=" + document.getElementById('normal-select-5').value +
                "&InicioMinutosL3=" + document.getElementById('normal-select-6').value + "",

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                //OPResgistradasSelect();
                swal('Línea Iniciada', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue iniciada correctamente ', 'success');

                var myVar = setTimeout(location.reload(), 15000);
                return false;
            },
            failure: function (r) {
                swal('Error:', 'Error al iniciar la Línea de producción No ' + document.getElementById('txtL').value + ', por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            },
            error: function (r) {
                swal('Error:', 'Error al iniciar la Línea, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            }

        });
        return false;


        return false;
    }
    catch (err) {
        swal('Error:', 'Error al iniciar la línea, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}

function FinalizaryEsperandoLavadoLinea(Lid) {


    if (Lid == 1 && document.getElementById('txtL1').value != 2) {
        swal('Oops!', 'La línea No 1 debe estar Envasando para poder ser finalizada', 'warning');
        return false;
    }

    if (Lid == 2 && document.getElementById('txtL2').value != 2) {
        swal('Oops!', 'La línea No 2 debe estar Envasando para poder ser finalizada', 'warning');
        return false;
    }

    if (Lid == 3 && document.getElementById('txtL3').value != 2) {
        swal('Oops!', 'La línea No 3 debe estar Envasando para poder ser finalizada', 'warning');
        return false;
    }

    if (Lid == 1 && (document.getElementsByName('normal-select-7Fin')[0].value == "" || document.getElementById('normal-select-8').value == "")) {
        swal('Oops!', 'Debe seleccionar la hora en que finalizó la línea', 'warning');
        return false;
    }

    if (Lid == 2 && (document.getElementById('normal-select-9').value == "" || document.getElementById('normal-select-10').value == "")) {
        swal('Oops!', 'Debe seleccionar la hora en que finalizó la línea', 'warning');
        return false;
    }

    if (Lid == 3 && (document.getElementById('normal-select-11').value == "" || document.getElementById('normal-select-12').value == "")) {
        swal('Oops!', 'Debe seleccionar la hora en que finalizó la línea', 'warning');
        return false;
    }

    if (Lid == 1)
        document.getElementById('txtL1').value = 5; // si la línea seleccionada es la 1, entonces ponemos el valor de la línea en 7 = EsperandoLavado

    if (Lid == 2)
        document.getElementById('txtL2').value = 5; // si la línea seleccionada es la 2, entonces ponemos el valor de la línea en 7 = EsperandoLavado

    if (Lid == 3)
        document.getElementById('txtL3').value = 5; // si la línea seleccionada es la 3, entonces ponemos el valor de la línea en 7 = EsperandoLavado



    var message = "";

    try {

        swal('Finalizando Línea...', 'Estamos finalizando la Línea No ' + Lid + ', por favor espere, no cierre esta ventana hasta que el proceso termine…', 'warning');
        $.ajax({
            type: "POST",
            url: "DataOP.ashx?Action=EsperandoLavado&OP=" + document.getElementsByName('DataspanOP')[0].value +
                "&ProductoOP=" + document.getElementsByName('NAVI')[0].value +
                "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value +
                "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value +
                "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value +
                "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value +
                "&DescripLavado=" + document.getElementById('normal-select-7').innerText +
                "&L1=" + document.getElementById('txtL1').value +
                "&L2=" + document.getElementById('txtL2').value +
                "&L3=" + document.getElementById('txtL3').value +
                "&LP=" + Lid +
                "&FinHoraL1=" + document.getElementsByName('normal-select-7Fin')[0].value +
                "&FinMinutosL1=" + document.getElementById('normal-select-8').value +
                "&FinHoraL2=" + document.getElementById('normal-select-9').value +
                "&FinMinutosL2=" + document.getElementById('normal-select-10').value +
                "&FinHoraL3=" + document.getElementById('normal-select-11').value +
                "&FinMinutosL3=" + document.getElementById('normal-select-12').value + "",

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                //OPResgistradasSelect();
                swal('Línea Finalizada', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue finalizada correctamente ', 'success');

                var myVar = setTimeout(location.reload(), 15000);
                return false;
            },
            failure: function (r) {
                swal('Error:', 'Error al finalizar la Línea de producción No ' + document.getElementById('txtL').value + ', por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            },
            error: function (r) {
                swal('Error:', 'Error al finalizar la Línea, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            }

        });
        return false;


        return false;
    }
    catch (err) {
        swal('Error:', 'Error al finalizar la línea, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}

function IniciarLineaDespuesdeTimerIncio(Lid) {
    if (Lid == 1 && document.getElementById('txtL1').value == 2) {
        swal('Oops!', 'La línea No 1 ya está iniciada', 'warning');
        return false;
    }

    if (Lid == 2 && document.getElementById('txtL2').value == 2) {
        swal('Oops!', 'La línea No 2 ya está iniciada', 'warning');
        return false;
    }

    if (Lid == 3 && document.getElementById('txtL3').value == 2) {
        swal('Oops!', 'La línea No 3 ya está iniciada', 'warning');
        return false;
    }

    if (Lid == 1)
        document.getElementById('txtL1').value = 2; // si la línea seleccionada es la 1, entonces ponemos el valor de la línea en 2 = Envasando

    if (Lid == 2)
        document.getElementById('txtL2').value = 2; // si la línea seleccionada es la 2, entonces ponemos el valor de la línea en 2 = Envasando

    if (Lid == 3)
        document.getElementById('txtL3').value = 2; // si la línea seleccionada es la 3, entonces ponemos el valor de la línea en 2 = Envasando



    var message = "";

    try {

        swal('Iniciando Línea...', 'Estamos iniciando la Línea No ' + Lid + ', por favor espere, no cierre esta ventana hasta que la información termine de registrarse…', 'warning');
        $.ajax({
            type: "POST",
            url: "DataOP.ashx?Action=InciarLinea&OP=" + document.getElementsByName('DataspanOP')[0].value + "&ProductoOP=" + document.getElementsByName('NAVI')[0].value + "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value + "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value + "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value + "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value + "&DescripLavado=" + document.getElementById('normal-select-7').innerText + "&L1=" + document.getElementById('txtL1').value + "&L2=" + document.getElementById('txtL2').value + "&L3=" + document.getElementById('txtL3').value + "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                //OPResgistradasSelect();
                swal('Línea Iniciada', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue iniciada correctamente ', 'success');

                var myVar = setTimeout(location.reload(), 15000);
                return false;
            },
            failure: function (r) {
                swal('Error:', 'Error al iniciar la Línea de producción No ' + document.getElementById('txtL').value + ', por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            },
            error: function (r) {
                swal('Error:', 'Error al inicias la Línea, por favor verifique los datos y vuelva a intentarlo', 'error');
                return false;
            }

        });
        return false;


        return false;
    }
    catch (err) {
        swal('Error:', 'Error al registrar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}


function IniciarLineaDespuesdeTimer(Lid) {

    if (Lid == 1)
        document.getElementById('txtL1').value = 2; // si la línea seleccionada es la 1, entonces ponemos el valor de la línea en 2 = Envasando

    if (Lid == 2)
        document.getElementById('txtL2').value = 2; // si la línea seleccionada es la 2, entonces ponemos el valor de la línea en 2 = Envasando

    if (Lid == 3)
        document.getElementById('txtL3').value = 2; // si la línea seleccionada es la 3, entonces ponemos el valor de la línea en 2 = Envasando



    var message = "";

    try {


        swal('Iniciando Línea...', 'Estamos iniciando la Línea No ' + Lid + ', por favor espere, no cierre esta ventana hasta que la información termine de registrarse…', 'warning');
            $.ajax({
                type: "POST",
                url: "DataOP.ashx?Action=InciarLinea&OP=" + document.getElementsByName('DataspanOP')[0].value + "&ProductoOP=" + document.getElementsByName('NAVI')[0].value + "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value + "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value + "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value + "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value + "&DescripLavado=" + document.getElementById('normal-select-7').innerText + "&L1=" + document.getElementById('txtL1').value + "&L2=" + document.getElementById('txtL2').value + "&L3=" + document.getElementById('txtL3').value + "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //OPResgistradasSelect();
                    swal('Línea Iniciada', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue iniciada correctamente ', 'success');

                    var myVar = setTimeout(location.reload(), 15000);
                    return false;
                },
                failure: function (r) {
                    swal('Error:', 'Error al iniciar la Línea de producción No ' + document.getElementById('txtL').value + ', por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                },
                error: function (r) {
                    swal('Error:', 'Error al inicias la Línea, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                }

            });
            return false;
        

        return false;
    }
    catch (err) {
        swal('Error:', 'Error al registrar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}


function EjecutarReinicioDeParada(tiempo) {
    ReinicioParadaLineasdeProduccion(tiempo);
}

function ReinicioParadaLineasdeProduccion(tiempo) {
    //verifico si ya está denida, sólo así podrá reiniciar línea
    if (document.getElementById('txtL').value == 1 && document.getElementById('txtL1').value != 3) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 1  actualmente no está denida, esta opción sólo se usa cuándo se desea reiniciar el tiempo de parada', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 2 && document.getElementById('txtL2').value != 3) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 2  actualmente no está denida, esta opción sólo se usa cuándo se desea reiniciar el tiempo de parada', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 3 && document.getElementById('txtL3').value != 3) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 3  actualmente no está denida, esta opción sólo se usa cuándo se desea reiniciar el tiempo de parada', 'warning');
        return false;
    }

    

    var message = "";

    try {


        if (document.getElementById('txtL').value == "") {
            message += "Debe seleccionar la línea que desea iniciar\n";

        }

        if (message != "") {
            swal('Por favor verifique lo siguiente: ', message, 'warning');
            return false;
        }
        else {
            swal('Deteniendo Línea...', 'Estamos reiniciando la parada de la Línea No ' + document.getElementById('txtL').value + ', por favor espere, no cierre esta ventana hasta que el proceso termine', 'warning');
            $.ajax({
                type: "POST",
                url: "DataOP.ashx?Action=DetenerLinea&OP=" + document.getElementsByName('DataspanOP')[0].value + "&ProductoOP=" + document.getElementsByName('NAVI')[0].value + "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value + "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value + "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value + "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value + "&DescripLavado=" + document.getElementById('normal-select-7').innerText + "&L1=" + document.getElementById('txtL1').value + "&L2=" + document.getElementById('txtL2').value + "&L3=" + document.getElementById('txtL3').value + "&LP=" + document.getElementById('txtL').value + "&Tiempo=" + tiempo + "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //OPResgistradasSelect();
                    swal('Línea DETENIDA', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue DETENIDA correctamente ', 'success');
                    var myVar = setTimeout(location.reload(), 15000);   
                    //document.getElementById('Modal2Close').click();
                    return false;

                },
                failure: function (r) {
                    swal('Error:', 'Error al REINICIAR la parada de la Línea de producción No ' + document.getElementById('txtL').value + ', por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                },
                error: function (r) {
                    swal('Error:', 'Error al  REINICIAR la parada de la Línea, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                }

            });
            return false;
        }

        return false;
    }
    catch (err) {
        swal('Error:', 'Error al  REINICIAR la parada de la Línea, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}

function EjecutarParada() {
    ParadaLineasdeProduccion(document.getElementById('SelectParadas').value);
}

function ParadaLineasdeProduccion(tiempo) {
    //verifico si ya está denida
    if (document.getElementById('txtL').value == 1 && document.getElementById('txtL1').value == 3) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 1  ya está denida', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 2 && document.getElementById('txtL2').value == 3) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 2  ya está denida', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 3 && document.getElementById('txtL3').value == 3) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 3  ya está denida', 'warning');
        return false;
    }

    // si la línea seleccionada es la 1 y el estatus es Envasando, podemos  continuar, de lo contrario , no
    if (document.getElementById('txtL').value == 1 && document.getElementById('txtL1').value != 2) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 1 debe estar Envasando para poder detenerla', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 2 && document.getElementById('txtL2').value != 2) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 2 debe estar Envasando para poder detenerla', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 3 && document.getElementById('txtL3').value != 2) {
        swal('Por favor verifique lo siguiente: ', 'La Línea de producción No 3 debe estar Envasando para poder detenerla', 'warning');
        return false;
    }

    var message = "";

    try {


        if (document.getElementById('txtL').value == "") {
            message += "Debe seleccionar la línea que desea iniciar\n";

        }

        if (message != "") {
            swal('Por favor verifique lo siguiente: ', message, 'warning');
            return false;
        }
        else {
            swal('Deteniendo Línea...', 'Estamos deteniendo la Línea No ' + document.getElementById('txtL').value + ', por favor espere, no cierre esta ventana hasta que el proceso termine', 'warning');
            $.ajax({
                type: "POST",
                url: "DataOP.ashx?Action=DetenerLinea&OP=" + document.getElementsByName('DataspanOP')[0].value + "&ProductoOP=" + document.getElementsByName('NAVI')[0].value + "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value + "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value + "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value + "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value + "&DescripLavado=" + document.getElementById('normal-select-7').innerText + "&L1=" + document.getElementById('txtL1').value + "&L2=" + document.getElementById('txtL2').value + "&L3=" + document.getElementById('txtL3').value + "&LP=" + document.getElementById('txtL').value + "&Tiempo=" + tiempo + "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    //OPResgistradasSelect();
                    swal('Línea DETENIDA', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue DETENIDA correctamente ', 'success');
                    var myVar = setTimeout(location.reload(), 15000);   
                    return false;

                },
                failure: function (r) {
                    swal('Error:', 'Error al DETENER la Línea de producción No ' + document.getElementById('txtL').value + ', por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                },
                error: function (r) {
                    swal('Error:', 'Error al DETENER la Línea, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                }

            });
            return false;
        }

        return false;
    }
    catch (err) {
        swal('Error:', 'Error al registrar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}

function OPMonitoreada() {

    document.getElementById('messageUpdateData').innerHTML = "Consultando estado de la información...";

    try {
        $.ajax({
            type: "POST",
            url: "DataOP.ashx?Action=OPRegistradasFinalLinea",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var exists = false;
                var count = 0;
                $.each(data, function (index, item) {
                    document.getElementById('messageUpdateData').innerHTML = "";
                    
                    exists = true;
                    var estatusOP = item.EestadoOP;

                    var estatusOP_ = "";
                    if (estatusOP == 1) {
                        estatusOP_ = "Iniciada";
                        
                    }
                    if (item.EestadoL1 == 2 || item.EestadoL2 == 2 || item.EestadoL3 == 2) {
                        estatusOP_ = "Envasando";
                        
                    }
                    else {
                        estatusOP_ = "Iniciada";
                       
                    }
                    if (estatusOP == 3) {
                        estatusOP_ = "Detenida";
                        
                    }

                    if (estatusOP == 4) {
                        estatusOP_ = "Lavando";
                       
                    }

                    if (estatusOP == 5) {
                        estatusOP_ = "Terminada";
                       
                    }
                    
                    if (count == 0) {
                        //document.getElementById('txtL1').value = item.EestadoL1;
                        //document.getElementById('txtL2').value = item.EestadoL2;
                        //document.getElementById('txtL3').value = item.EestadoL3;
                        document.getElementsByName('EstadoOP')[0].value = estatusOP_;                        
                        document.getElementsByName('DataspanOP')[0].value = item.OP;                        
                        document.getElementsByName('NAVI')[0].value = item.ProductoOP;                        
                        document.getElementsByName('NombreProducto')[0].value = item.Descripcion;                       
                        document.getElementsByName('UnidadesFabricar')[0].value = item.Cantidad;                       
                        document.getElementsByName('Cliente')[0].value = item.NombreCliente;                        
                        document.getElementsByName('Lavado')[0].value = item.TiempoLavado;                       

                        //L1
                        var estatusOPL = item.EestadoL1;
                        var estatusOPL_ = "";
                        if (estatusOPL == 1) {
                            estatusOPL_ = "Esperando"
                        }
                        if (estatusOPL == 2) {
                            estatusOPL_ = "Envasando"
                        }
                        if (estatusOPL == 3) {
                            estatusOPL_ = "Detenida"
                        }

                        if (estatusOPL == 4) {
                            estatusOPL_ = "Lavando"
                        }

                        if (estatusOPL == 5) {
                            estatusOPL_ = "Terminada"
                        }
                        if (estatusOPL == 6) {
                            estatusOPL_ = "Reiniciando"
                        }

                        document.getElementById('spanEstatusL1').innerHTML = "ESTADO:" + estatusOPL_;

                        //L2
                        estatusOPL = item.EestadoL2;

                        if (estatusOPL == 1) {
                            estatusOPL_ = "Esperando"
                        }
                        if (estatusOPL == 2) {
                            estatusOPL_ = "Envasando"
                        }
                        if (estatusOPL == 3) {
                            estatusOPL_ = "Detenida"
                        }
                        if (estatusOPL == 4) {
                            estatusOPL_ = "Lavando"
                        }
                        if (estatusOPL == 6) {
                            estatusOPL_ = "Reiniciando"
                        }

                        if (estatusOPL == 5) {
                            estatusOPL_ = "Terminada"
                        }

                        document.getElementById('spanEstatusL2').innerHTML = "ESTADO:" + estatusOPL_;


                        //L3
                        estatusOPL = item.EestadoL3;
                        if (estatusOPL == 1) {
                            estatusOPL_ = "Esperando"
                        }
                        if (estatusOPL == 2) {
                            estatusOPL_ = "Envasando"
                        }
                        if (estatusOPL == 3) {
                            estatusOPL_ = "Detenida"
                        }

                        if (estatusOPL == 4) {
                            estatusOPL_ = "Lavando"
                        }
                        if (estatusOPL == 5) {
                            estatusOPL_ = "Terminada"
                        }

                        if (estatusOPL == 6) {
                            estatusOPL_ = "Reiniciando"
                        }

                        document.getElementById('spanEstatusL3').innerHTML = "ESTADO:" + estatusOPL_;

                    }
                   
                    //$('#TableOP').append("<tr><td>" + item.OP + "</td><td>" + item.ProductoOP + "</td><td>" + item.Descripcion + "</td><td>" + item.Cantidad + "</td><td>" + item.NombreCliente + "</td><td>" + item.TiempoLavado + " Minutos" + "</td><td>" + estatusOP_ + "</td></tr>");
                    count += 1;
                    // swal('OP válida \n' + item.OP + '', 'Producto: ' + item.Descripcion + '\n\n Hemos terminado de consultar la información de la OP, presione “Ok” para continuar', 'success');
                    return true;
                });
                if (!exists) {

                    document.getElementById('spanEstatusL1').innerHTML = "";
                    document.getElementById('spanEstatusL2').innerHTML = "";
                    document.getElementById('spanEstatusL3').innerHTML = "";
                    //swal('Oops', 'No existe una OP en proceso', 'warning');
                    document.getElementById('messageUpdateData').innerHTML = "No existe una OP en proceso";
                }
                    
            },
            failure: function (r) {
                ////alert('Error al recuperar los permisos...');
                //swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                //return false;
            },
            error: function (r) {
                //// alert(r.error + " Permisos");
                //swal('Error:', 'No podemos cargar los datos en este momento, por favor verifique si está conectado correctamente al centro de datos', 'error');
                //return false;
            }

        });

    }
    catch (err) {
        swal('Error:', 'No podemos cargar tus datos en este momento, comuníquese al whatsapp 55-6874-9040 para obtener  ayuda', 'error');
        return false;
    }
    return false;

}

function IniciarLinea() {

    if (document.getElementById('txtL').value == 1 && document.getElementById('txtL1').value != 3) {
        swal('Oops!', 'La línea 1 no está detenida, por lo que no es necesario Reiniciarla', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 2 && document.getElementById('txtL2').value != 3) {
        swal('Oops!', 'La línea 2 no está detenida, por lo que no es necesario Reiniciarla', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 3 && document.getElementById('txtL3').value != 3) {
        swal('Oops!', 'La línea 3 no está detenida, por lo que no es necesario Reiniciarla', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 1 && document.getElementById('txtL1').value == 2) {
        swal('Oops!', 'La línea No 1 ya está iniciada', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 2 && document.getElementById('txtL2').value == 2) {
        swal('Oops!', 'La línea No 2 ya está iniciada', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 3 && document.getElementById('txtL3').value == 2) {
        swal('Oops!', 'La línea No 3 ya está iniciada', 'warning');
        return false;
    }

    if (document.getElementById('txtL').value == 1)
        document.getElementById('txtL1').value = 2; // si la línea seleccionada es la 1, entonces ponemos el valor de la línea en 2 = Envasando

    if (document.getElementById('txtL').value == 2)
        document.getElementById('txtL2').value = 2; // si la línea seleccionada es la 2, entonces ponemos el valor de la línea en 2 = Envasando

    if (document.getElementById('txtL').value == 3)
        document.getElementById('txtL3').value = 2; // si la línea seleccionada es la 3, entonces ponemos el valor de la línea en 2 = Envasando

   

    var message = "";

    try {


        if (document.getElementById('txtL').value == "") {
            message += "Debe seleccionar la línea que desea iniciar\n";

        }

        if (message != "") {
            swal('Por favor verifique lo siguiente: ', message, 'warning');
            return false;
        }
        else {
            swal('Iniciando Línea...', 'Estamos iniciando la Línea No ' + document.getElementById('txtL').value + ', por favor espere, no cierre esta ventana hasta que la información termine de registrarse…', 'warning');
            $.ajax({
                type: "POST",
                url: "DataOP.ashx?Action=InciarLinea&OP=" + document.getElementsByName('DataspanOP')[0].value + "&ProductoOP=" + document.getElementsByName('NAVI')[0].value + "&Descripcion=" + document.getElementsByName('NombreProducto')[0].value + "&Cantidad=" + document.getElementsByName('UnidadesFabricar')[0].value + "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementsByName('Cliente')[0].value + "&TiempoLavado=" + document.getElementsByName('Lavado')[0].value + "&DescripLavado=" + document.getElementById('normal-select-7').innerText + "&L1=" + document.getElementById('txtL1').value + "&L2=" + document.getElementById('txtL2').value + "&L3=" + document.getElementById('txtL3').value + "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    
                    //OPResgistradasSelect();
                    swal('Línea Iniciada', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue iniciada correctamente ', 'success');
                    
                    var myVar = setTimeout(location.reload() , 15000);                    
                    return false;
                },
                failure: function (r) {
                    swal('Error:', 'Error al iniciar la Línea de producción No ' + document.getElementById('txtL').value + ', por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                },
                error: function (r) {
                    swal('Error:', 'Error al inicias la Línea, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                }
                
            });
            return false;
        }

        return false;
    }
    catch (err) {
        swal('Error:', 'Error al registrar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}

function OPResgistradasSelect() {
   
    document.getElementById('HiddenEstadoOP').value = 5;
    //$("#TableOP tbody tr").each(function () {
    //        this.parentNode.removeChild(this);
    //});
        try {
            $.ajax({
                type: "POST",
                url: "DataOP.ashx?Action=OPRegistradas",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var existeopPendiente = false;
                    var exists = false;
                    var count = 0;
                    $.each(data, function (index, item) {
                        exists = true;
                        
                        var estatusOP = item.EestadoOP;
                        var estatusOP_ = "";
                        if (estatusOP == 1) {
                            estatusOP_ = "Iniciada";
                            document.getElementById('HiddenEstadoOP').value = 1;                          
                        }
                        if (item.EestadoL1 == 2 || item.EestadoL2 == 2 || item.EestadoL3 == 2) {
                            estatusOP_ = "Envasando";
                            document.getElementById('HiddenEstadoOP').value = 2;
                        }
                        else {
                            estatusOP_ = "Iniciada";
                            document.getElementById('HiddenEstadoOP').value = 1;  
                        }
                        if (estatusOP == 3) {
                            estatusOP_ = "Detenida";
                            document.getElementById('HiddenEstadoOP').value = 3; 
                        }

                        if (estatusOP == 4) {
                            estatusOP_ = "Lavando";
                            document.getElementById('HiddenEstadoOP').value = 4;
                        }

                        if (estatusOP == 5) {
                            estatusOP_ = "Terminada";
                            document.getElementById('HiddenEstadoOP').value = 5;
                        }
                        
                        if (estatusOP_ != "Terminada") {
                            existeopPendiente = true;
                            document.getElementById('txtL1').value = item.EestadoL1;
                            document.getElementById('txtL2').value = item.EestadoL2;
                            document.getElementById('txtL3').value = item.EestadoL3;
                            document.getElementsByName('EstadoOP')[0].value = estatusOP_;
                            document.getElementsByName('EstadoOP')[1].value = estatusOP_;
                            document.getElementsByName('EstadoOP')[2].value = estatusOP_;
                            document.getElementsByName('EstadoOP')[3].value = estatusOP_;
                            document.getElementsByName('EstadoOP')[4].value = estatusOP_;
                            document.getElementsByName('DataspanOP')[0].value = item.OP; 
                            document.getElementsByName('DataspanOP')[1].value = item.OP; 
                            document.getElementsByName('DataspanOP')[2].value = item.OP;
                            document.getElementsByName('DataspanOP')[3].value = item.OP; 
                            document.getElementsByName('DataspanOP')[4].value = item.OP; 
                            document.getElementsByName('NAVI')[0].value = item.ProductoOP;
                            document.getElementsByName('NAVI')[1].value = item.ProductoOP;
                            document.getElementsByName('NAVI')[2].value = item.ProductoOP;
                            document.getElementsByName('NAVI')[3].value = item.ProductoOP;
                            document.getElementsByName('NAVI')[4].value = item.ProductoOP;
                            document.getElementsByName('NombreProducto')[0].value = item.Descripcion;
                            document.getElementsByName('NombreProducto')[1].value = item.Descripcion;
                            document.getElementsByName('NombreProducto')[2].value = item.Descripcion;
                            document.getElementsByName('NombreProducto')[3].value = item.Descripcion;
                            document.getElementsByName('NombreProducto')[4].value = item.Descripcion;
                            document.getElementsByName('UnidadesFabricar')[0].value = item.Cantidad;
                            document.getElementsByName('UnidadesFabricar')[1].value = item.Cantidad;
                            document.getElementsByName('UnidadesFabricar')[2].value = item.Cantidad;
                            document.getElementsByName('UnidadesFabricar')[3].value = item.Cantidad;
                            document.getElementsByName('UnidadesFabricar')[4].value = item.Cantidad;
                            document.getElementsByName('Cliente')[0].value = item.NombreCliente;
                            document.getElementsByName('Cliente')[1].value = item.NombreCliente;
                            document.getElementsByName('Cliente')[2].value = item.NombreCliente;
                            document.getElementsByName('Cliente')[3].value = item.NombreCliente;
                            document.getElementsByName('Cliente')[4].value = item.NombreCliente;
                            document.getElementsByName('Lavado')[0].value = item.TiempoLavado; 
                            document.getElementsByName('Lavado')[1].value = item.TiempoLavado; 
                            document.getElementsByName('Lavado')[2].value = item.TiempoLavado;
                            document.getElementsByName('Lavado')[3].value = item.TiempoLavado; 
                            document.getElementsByName('Lavado')[4].value = item.TiempoLavado; 

                            //L1
                            var estatusOPL = item.EestadoL1;
                            var estatusOPL_ = "";
                            if (estatusOPL == 1) {
                                estatusOPL_ = "Esperando"
                            }
                            if (estatusOPL == 2) {
                                estatusOPL_ = "Envasando"
                            }
                            if (estatusOPL == 3) {
                                estatusOPL_ = "Detenida"
                            }

                            if (estatusOPL == 4) {
                                estatusOPL_ = "Lavando"
                            }

                            if (estatusOPL == 6) {
                                estatusOPL_ = "Reiniciando"
                            }
                            if (estatusOPL == 5) {
                                estatusOPL_ = "Terminada"
                            }
                            if (estatusOPL == 7) {
                                estatusOPL_ = "Esperando Lavado"
                            }

                            document.getElementById('spanEstatusL1').innerHTML = "ESTADO:" + estatusOPL_;
                           
                            //L2
                            estatusOPL = item.EestadoL2;
                            
                            if (estatusOPL == 1) {
                                estatusOPL_ = "Esperando"
                            }
                            if (estatusOPL == 2) {
                                estatusOPL_ = "Envasando"
                            }
                            if (estatusOPL == 3) {
                                estatusOPL_ = "Detenida"
                            }
                            if (estatusOPL == 4) {
                                estatusOPL_ = "Lavando"
                            }
                            if (estatusOPL == 5) {
                                estatusOPL_ = "Terminada"
                            }
                            if (estatusOPL == 6) {
                                estatusOPL_ = "Reiniciando"
                            }
                            if (estatusOPL == 7) {
                                estatusOPL_ = "Esperando Lavado"
                            }
                            
                            document.getElementById('spanEstatusL2').innerHTML = "ESTADO:" + estatusOPL_;


                            //L3
                            estatusOPL = item.EestadoL3;
                            if (estatusOPL == 1) {
                                estatusOPL_ = "Esperando"
                            }
                            if (estatusOPL == 2) {
                                estatusOPL_ = "Envasando"
                            }
                            if (estatusOPL == 3) {
                                estatusOPL_ = "Detenida"
                                
                            }

                            if (estatusOPL == 4) {
                                estatusOPL_ = "Lavando"
                            }

                            
                            if (estatusOPL == 5) {
                                estatusOPL_ = "Terminada"
                            }

                            if (estatusOPL == 6) {
                                estatusOPL_ = "Reiniciando"
                            }

                            if (estatusOPL == 7) {
                                estatusOPL_ = "Esperando Lavado"
                            }
                            document.getElementById('spanEstatusL3').innerHTML = "ESTADO:" + estatusOPL_;

                            //TimerL3
                            if (item.EestadoL3 == 3) {
                                var String_ValueDateL3 = item.FechaParadaL3;
                                var value = new Date(parseInt(String_ValueDateL3.replace(/(^.*\()|([+-].*$)/g, '')));
                               // var dat = value.toLocaleString();
                                MinParadaL3 = item.MinParadaL3;
                                ShowTimerL3(value);
                                //Mostrar reinicios y ocultar paradas, solo si está detenida 
                                document.getElementById('ReinicioParada1L3').style.display = "inline";
                                document.getElementById('ReinicioParada2L3').style.display = "inline";
                                document.getElementById('ReinicioParada3L3').style.display = "inline";
                                //paradas
                                document.getElementById('Parada1L3').style.display = "none";
                                document.getElementById('Parada2L3').style.display = "none";
                                document.getElementById('Parada3L3').style.display = "none";
                            }
                            else {
                                //Ocultar reinicios y mostrar paradas, solo si no está detenida 
                                document.getElementById('ReinicioParada1L3').style.display = "none";
                                document.getElementById('ReinicioParada2L3').style.display = "none";
                                document.getElementById('ReinicioParada3L3').style.display = "none";
                                //paradas
                                document.getElementById('Parada1L3').style.display = "inline";
                                document.getElementById('Parada2L3').style.display = "inline";
                                document.getElementById('Parada3L3').style.display = "inline";
                            }

                            //TimerL2
                            if (item.EestadoL2 == 3) {
                                var String_ValueDateL2 = item.FechaParadaL2;
                                var valueL2 = new Date(parseInt(String_ValueDateL2.replace(/(^.*\()|([+-].*$)/g, '')));
                                //var datL2 = valueL2.toLocaleString();
                                MinParadaL2 = item.MinParadaL2;
                                ShowTimerL2(valueL2);
                                //Mostrar reinicios y ocultar paradas, solo si está detenida 
                                document.getElementById('ReinicioParada1L2').style.display = "inline";
                                document.getElementById('ReinicioParada2L2').style.display = "inline";
                                document.getElementById('ReinicioParada3L2').style.display = "inline";
                                //paradas
                                document.getElementById('Parada1L2').style.display = "none";
                                document.getElementById('Parada2L2').style.display = "none";
                                document.getElementById('Parada3L2').style.display = "none";
                            }
                            else {
                                //Ocultar reinicios y mostrar paradas, solo si no está detenida 
                                document.getElementById('ReinicioParada1L2').style.display = "none";
                                document.getElementById('ReinicioParada2L2').style.display = "none";
                                document.getElementById('ReinicioParada3L2').style.display = "none";
                                //paradas
                                document.getElementById('Parada1L2').style.display = "inline";
                                document.getElementById('Parada2L2').style.display = "inline";
                                document.getElementById('Parada3L2').style.display = "inline";
                            }

                            //TimerL1
                            if (item.EestadoL1 == 3) {
                                var String_ValueDateL1 = item.FechaParadaL1;
                                var valueL1 = new Date(parseInt(String_ValueDateL1.replace(/(^.*\()|([+-].*$)/g, '')));
                                //var datL1 = valueL1.toLocaleString();
                                MinParadaL1 = item.MinParadaL1;
                                ShowTimerL1(valueL1);

                                //Mostrar reinicios y ocultar paradas, solo si está detenida 
                                document.getElementById('ReinicioParada1L1').style.display = "inline";
                                document.getElementById('ReinicioParada2L1').style.display = "inline";
                                document.getElementById('ReinicioParada3L1').style.display = "inline";
                                //paradas
                                document.getElementById('Parada1L1').style.display = "none";
                                document.getElementById('Parada2L1').style.display = "none";
                                document.getElementById('Parada3L1').style.display = "none";
                            }
                            else {
                                //Ocultar reinicios y mostrar paradas, solo si no está detenida 
                                document.getElementById('ReinicioParada1L1').style.display = "none";
                                document.getElementById('ReinicioParada2L1').style.display = "none";
                                document.getElementById('ReinicioParada3L1').style.display = "none";
                                //paradas
                                document.getElementById('Parada1L1').style.display = "inline";
                                document.getElementById('Parada2L1').style.display = "inline";
                                document.getElementById('Parada3L1').style.display = "inline";
                            }


                            //Inicio 
                            document.getElementById('normal-select-1').value = item.InicioHoraL1;
                            document.getElementById('normal-select-2').value = item.InicioMinutosL1;
                            document.getElementById('normal-select-3').value = item.InicioHoraL2;
                            document.getElementById('normal-select-4').value = item.InicioMinutosL2;
                            document.getElementById('normal-select-5').value = item.InicioHoraL3;
                            document.getElementById('normal-select-6').value = item.InicioMinutosL3;

                            //Hora de finalización
                            document.getElementsByName('normal-select-7Fin')[0].value = item.FinHoraL1;
                            document.getElementById('normal-select-8').value = item.FinMinutosL1;
                            document.getElementById('normal-select-9').value = item.FinHoraL2;
                            document.getElementById('normal-select-10').value = item.FinMinutosL2;
                            document.getElementById('normal-select-11').value = item.FinHoraL3;
                            document.getElementById('normal-select-12').value = item.FinMinutosL3;


                            //las posibilidades para que se habilite el lavado
                            if (item.EestadoOP != 5) {


                                if (item.EestadoL1 == 5 && item.EestadoL2 == 5 && item.EestadoL3 == 5 && item.estatusOP != 5) {

                                    document.getElementById('divIniciarLavado').style.display = 'inline';
                                }
                                else if (item.EestadoL1 == 5 && item.EestadoL2 == 5 && item.EestadoL3 == 1
                                    || (item.EestadoL1 == 5 && item.EestadoL2 == 1 && item.EestadoL3 == 1)
                                    || (item.EestadoL1 == 1 && item.EestadoL2 == 1 && item.EestadoL3 == 5)
                                    || (item.EestadoL1 == 1 && item.EestadoL2 == 5 && item.EestadoL3 == 1)

                                ) {
                                    document.getElementById('divIniciarLavado').style.display = 'inline';
                                }

                                if (item.EestadoL1 == 4 || item.EestadoL2 == 4 || item.EestadoL3 == 4) {

                                    document.getElementById('divLavando').style.display = 'inline';
                                    var String_ValueDate = item.FechaInicioLavado;
                                    var value = new Date(parseInt(String_ValueDate.replace(/(^.*\()|([+-].*$)/g, '')));
                                    // var dat = value.toLocaleString();
                                    MinParadaL1 = item.TiempoLavado;
                                    ShowTimerLavandoL1(value);

                                    MinParadaL2 = item.TiempoLavado;
                                    ShowTimerLavandoL2(value);

                                    MinParadaL3 = item.TiempoLavado;
                                    ShowTimerLavandoL3(value);

                                }
                                else {
                                    document.getElementById('divLavando').style.display = 'none';
                                }

                            }
                            
                            return; //si existe una en proceso ya no valida ninuga otra

                        }

                       // $('#TableOP').append("<tr><td>" + item.OP + "</td><td>" + item.ProductoOP + "</td><td>" + item.Descripcion + "</td><td>" + item.Cantidad + "</td><td>" + item.NombreCliente + "</td><td>" + item.TiempoLavado + " Minutos" + "</td><td>" + estatusOP_ + "</td></tr>");
                        count += 1;
                        // swal('OP válida \n' + item.OP + '', 'Producto: ' + item.Descripcion + '\n\n Hemos terminado de consultar la información de la OP, presione “Ok” para continuar', 'success');
                        return true;
                    });
                    if ((!existeopPendiente && document.getElementById('HiddenEstadoOP').value == 5) || !exists) {
                        document.getElementById('ConfiguracionA').click();
                    }
                },
                failure: function (r) {
                    //alert('Error al recuperar los permisos...');
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

function SaveOp() {

    var message = "";

    try {


        if (document.getElementById('spnOP').innerHTML == "") {
            message += "Debe consultar una OP antes de iniciar\n";

        }

        if (document.getElementById('HiddenEstadoOP').value != 5) {
            message += "Hay una OP que no ha concluido, por lo que no puede iniciar una nueva\n";

        }
        

        if (message != "") {
            swal('Por favor verifique lo siguiente: ', message, 'warning');
            return false;
        }
        else {
            swal('Registrando información…', 'Estamos registrando la información de la OP, por favor espere, no cierre esta ventana hasta que la información termine de registrarse…', 'warning');
            $.ajax({
                type: "POST",
                url: "DataOP.ashx?Action=SaveOP&OP=" + document.getElementById('spnOP').innerHTML + "&ProductoOP=" + document.getElementById('spnNAVI').innerHTML + "&Descripcion=" + document.getElementById('spnNombreProducto').innerHTML + "&Cantidad=" + document.getElementById('spnCantidad').innerHTML + "&Ubicacion=-&CodCliente=-&NombreCliente=" + document.getElementById('spnCliente').innerHTML + "&TiempoLavado=" + document.getElementById('normal-select-7').value + "&DescripLavado=" + document.getElementById('normal-select-7').innerText + "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    document.getElementById('spnOP').innerHTML = "";;
                    document.getElementById('spnNAVI').innerHTML = "";
                    document.getElementById('spnNombreProducto').innerHTML = "";
                    document.getElementById('spnCantidad').innerHTML = "";
                    document.getElementById('spnCliente').innerHTML = "";
                    OPResgistradasSelect();
                    document.getElementById('closeA').click();
                    document.getElementById('btnIncioLine').click();
                    
                    swal('OP registrada', 'Información registrada correctamente, en este momento puede iniciar cada una de las líneas de producción!', 'success');

                },
                failure: function (r) {
                    swal('Error:', 'Error al registrar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                },
                error: function (r) {
                    swal('Error:', 'Error al registrar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
                    return false;
                }

            });
        }


    }
    catch (err) {
        swal('Error:', 'Error al registrar la OP, por favor verifique los datos y vuelva a intentarlo', 'error');
        return false;
    }

    return false;

}


function DataClient() {

    if (document.getElementById('txtsearchInput').value == "") {
        swal('', 'Debe capturar la OP que desea consultar', 'error');

    }
    else {

        swal('', 'Estamos consultando su la OP capturada, por favor espere…. ', 'warning');

        try {
            $.ajax({
                type: "POST",
                url: "DataOP.ashx?Action=OPSelect&OP=" + document.getElementById('txtsearchInput').value + "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var exists = false;
                    $.each(data, function (index, item) {
                        exists = true;
                        document.getElementById('spnOP').innerHTML = item.OP;
                        document.getElementById('spnNAVI').innerHTML = item.ProductoOP;
                        document.getElementById('spnNombreProducto').innerHTML = item.Descripcion;
                        document.getElementById('spnCantidad').innerHTML = item.Cantidad;
                        document.getElementById('spnCliente').innerHTML = item.NombreCliente;
                       

                        swal('OP válida \n' + item.OP + '', 'Producto: ' + item.Descripcion + '\n\n Hemos terminado de consultar la información de la OP, presione “Ok” para continuar', 'success');
                        return true;
                    });
                    if (!exists) {
                        swal('Error:', 'No pudimos consultar los datos de la OP, por favor verifique si capturó la OP correcta', 'error');
                    }
                },
                failure: function (r) {
                    //alert('Error al recuperar los permisos...');
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
}