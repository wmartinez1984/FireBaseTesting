<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPdf.aspx.cs" Inherits="FireBaseTesting.ViewPdf" %>

<!DOCTYPE html>
<html>
<head>
    <title>PDF Viewer</title>
    <meta charset="UTF-8" />
    <link rel="stylesheet" href="./styles.css" />
   
     <link href="https://cdn.jsdelivr.net/npm/font-awesome@4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>

   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
   <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
   <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
   

         <!--Calendar...-->
  <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
  <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/sweetalert-dev.js"></script>
	<link href="css/sweetalert.css" rel="stylesheet" />
</head>

<body onload="CargarDocumento();">
    <p style="font-size:20px;color:#ffffff;text-align:center;background-color:rgba(255, 106, 0, 0.62)" runat="server" id="pMensaje">

    </p>
    <input id="txtFilename" type="text" runat="server"  style="display:none;" />
    <div id="app">
        <div role="toolbar" id="toolbar" style="text-align:center;">
            <div id="pager">
                <button data-pager="prev">prev</button>
                <button data-pager="next">next</button>
            </div>
            <div id="page-mode">
                <label>Page Mode <input type="number" value="1" min="1" /></label>
            </div>
        </div>
        <div id="viewport-container"><div role="main" id="viewport"></div></div>
    </div>
    <script src="https://unpkg.com/pdfjs-dist@2.0.489/build/pdf.min.js"></script>
    <script src="index.js"></script>
    <script>

        function CargarDocumento() {

            var message = document.getElementById('pMensaje').innerText
            if (message != "") {
                swal('Mensaje', message, 'warning');
                
            }
           
            var NameFile = "pdfs/" + document.getElementById('txtFilename').value;
            initPDFViewer(
                NameFile
            );
        }
       
    </script>

    <script type='text/javascript'>
        document.oncontextmenu = function () { return false }
    </script>

    <script type="text/x-javascript">
        

        var isCtrl = false;
        document.onkeyup=function(e){
            if(e.which == 17) isCtrl=false;
        }

        document.onkeydown=function(e){
            if(e.which == 17) isCtrl=true;
            if(e.which == 80 && isCtrl == true) {
                //Combinancion de teclas CTRL+P y bloquear su ejecucion en el navegador
                return false;
            }
        }
    </script>

</body>
</html>