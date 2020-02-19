<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPdf.aspx.cs" Inherits="FireBaseTesting.ViewPdf" %>

<!DOCTYPE html>
<html>
<head>
    <title>PDF Viewer</title>
    <meta charset="UTF-8" />
    <link rel="stylesheet" href="./styles.css" />
</head>

<body>
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

        var NameFile = "PdfLinks/pdfs/example2.pdf";
        initPDFViewer(
            NameFile
        );
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