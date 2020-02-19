<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfAdmin.aspx.cs" Inherits="FireBaseTesting.PdfAdmin" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Admin PDF</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

      <link href="https://cdn.jsdelivr.net/npm/font-awesome@4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>

  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
   

         <!--Calendar...-->
  <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
  <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />

  <%--NECESARIOS PARA  MENSAJES DEL SISTEMA--%>
   
    <script src="Scripts/sweetalert-dev.js"></script>
	<link href="css/sweetalert.css" rel="stylesheet" />
</head>
<body>
<form runat="server">


<div class="container">
  <h1>Administración de links</h1>
  <p>Use este espacio para la generación de links anexando un archivo PDF </p>
  <div class="card">
    <div class="card-body">
      <h1 class="card-title">Datos del Link</h1>     
    </div>
    <div id="divDatos" runat="server">
        <table style="width:80%;margin:auto;">
        <tr>
            <td>
                <h4 class="card-text">Fecha de caducidad</h4>
            </td>
            <td style="text-align:center;">
                
            </td>
        </tr>
        <tr>
            <td>
                <input id="datepicker" style="width:200px;" readonly="readonly"  />
            </td>
            <td style="text-align:right;">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <h4>Descripción del link</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtDescripciones" runat="server" TextMode="MultiLine" Width="100%" Rows="5" MaxLength="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    </div>
    <div id="divLink" style="display:none;" runat="server">
        <p style="color:#398d16;font-size:30px;">
            Link generado!
        </p>
        <a target="_blank" runat="server" href="#" id="Alink">
            Haga click aquí para visualizar el link
        </a>
        <br />
         <br />
         <br />
        <input id="btnNuevo" type="button" value="Nuevo"  onclick=" document.getElementById('divLink').style.display = 'none'; document.getElementById('divDatos').style.display = 'inline'; "/>
    </div>
       

  </div>

</div>
</form>

 <script>
     
     $('#datepicker').datepicker({
         uiLibrary: 'bootstrap'
     });
    </script>

    <script>
        function OpenPDF(file) {
            var a = "";
            Swal.fire({
                title: '<strong>Links <u>generado!</u></strong>',
                icon: 'info',
                html:
                    'El link se generó correctamente \n\n' +
                    '<a href="' + file + '" target="_blank"><b>Visualizar link</b></a> ' +
                    '',
                showCloseButton: false,
                showCancelButton: false,
                focusConfirm: false,
                confirmButtonText:
                    '<a href="pdf/' + file + '.pdf" target="_blank"><b>Ok</b></a> ',
                confirmButtonAriaLabel: 'Thumbs up, great!',

            })
    </script>
</body>
</html>

