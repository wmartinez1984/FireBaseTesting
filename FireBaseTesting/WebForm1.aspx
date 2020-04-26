<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FireBaseTesting.WebForm1" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Editor de texto</title>
  <link href="https://stackpath.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
  <script src="https://stackpath.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link href="https://cdn.jsdelivr.net/npm/summernote@0.8.16/dist/summernote.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/summernote@0.8.16/dist/summernote.min.js"></script>

 <script>
     function GetHtmlText() {
         //Agregar data
         //var markupStr1 = 'Hola, test!';
         //$('#summernote').summernote('code', markupStr1);

         //Leer data
         var markupStr = $('#summernote').summernote('code');
         document.getElementById('htmlBody').innerHTML = markupStr;
       //  alert(markupStr);

     }
 </script>
</head>
<body>
  <div id="summernote"><p>Hello Summernote</p></div>
  <button onclick="GetHtmlText();">test</button>
  
    <div id="htmlBody"></div>
  <script>
    $(document).ready(function() {
        $('#summernote').summernote({
            lang: 'es-MX' // default: 'en-US'
        });
    });
  </script>
</body>
</html>
