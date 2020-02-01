
function EjecutarReinicioDeParada() {
    ReinicioParadaLineasdeProduccion(document.getElementById('SelectParadasR').value);
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

                    OPResgistradasSelect();
                    swal('Línea DETENIDA', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue DETENIDA correctamente ', 'success');
                    document.getElementById('Modal2Close').click();
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

                    OPResgistradasSelect();
                    swal('Línea DETENIDA', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue DETENIDA correctamente ', 'success');
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
                        if (estatusOPL == 6) {
                            estatusOPL_ = "Reiniciando"
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
                    swal('Oops', 'No existe una OP en proceso', 'warning');
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
                   
                    OPResgistradasSelect();
                    swal('Línea Iniciada', 'La Línea de producción No. ' + document.getElementById('txtL').value + ' fue iniciada correctamente ', 'success');
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
    $("#TableOP tbody tr").each(function () {
            this.parentNode.removeChild(this);
    });
        try {
            $.ajax({
                type: "POST",
                url: "DataOP.ashx?Action=OPRegistradas",
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
                            document.getElementById('HiddenEstadoOP').value = 3;
                        }

                        if (estatusOP == 5) {
                            estatusOP_ = "Terminada";
                            document.getElementById('HiddenEstadoOP').value = 5;
                        }

                        if (count == 0) {
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

                            if (estatusOPL == 6) {
                                estatusOPL_ = "Reiniciando"
                            }
                            document.getElementById('spanEstatusL3').innerHTML = "ESTADO:" + estatusOPL_;

                        }

                        $('#TableOP').append("<tr><td>" + item.OP + "</td><td>" + item.ProductoOP + "</td><td>" + item.Descripcion + "</td><td>" + item.Cantidad + "</td><td>" + item.NombreCliente + "</td><td>" + item.TiempoLavado + " Minutos" + "</td><td>" + estatusOP_ + "</td></tr>");
                        count += 1;
                        // swal('OP válida \n' + item.OP + '', 'Producto: ' + item.Descripcion + '\n\n Hemos terminado de consultar la información de la OP, presione “Ok” para continuar', 'success');
                        return true;
                    });
                    if (document.getElementById('HiddenEstadoOP').value == 5 || !exists) {
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
                    swal('OP registrada', 'Información registrada correctamente, en este momento se da inicio a los temporizadores', 'success');

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