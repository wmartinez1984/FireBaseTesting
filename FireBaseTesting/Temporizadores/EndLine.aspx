<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndLine.aspx.cs" Inherits="FireBaseTesting.Temporizadores.EndLine" %>


<%@ Register Src="~/Temporizadores/Controles/DataOP.ascx" TagPrefix="uc1" TagName="DataOP" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Monitor</title>
    <%--NECESARIOS PARA EJECUTAR AJAX,  JSON--%>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="js/sweetalert-dev.js"></script>
	<script src="js/DataOP.js"></script>

     <%--NECESARIOS PARA DISEÑO---%>
    <link href="styleMonitor.css" rel="stylesheet" />
    <link href="css/sweetalert.css" rel="stylesheet" />
</head>
<body style="">



 <div class="cards">    
    
    <table style="width:100%;margin-top:-24px; background-image:url('Images/gif.gif')" class="table" >        
        <tr>

            <td style="width:65%;height:200px;text-align:center;">
                <span style="font-size:30px;color:#0b220e"> <strong>Mesa de producción 1</strong> </span>
                <h3 style="color:white;font-size:25px; color:#207529; "><strong id="spanEstatusL1"></strong> </h3>
            </td>

            <td rowspan="3" style="text-align: right;
                    background-color: #E5E8EF;
                    border-left: 10px;
                    border-left-color: #359840;
                    border-left-width: 10px;
                    border-left-style: dashed;">
                   <a href="login.aspx">
                       <uc1:DataOP runat="server" ID="DataOP"  />
                   </a>
                   <h3 style="color:#207529; text-align:left; font-size:12px;" id="messageUpdateData">...</h3>
              
                
            </td>

        </tr>
        <tr>
            <td style="                    width: 65%;
                    height: 200px;
                    text-align: center;
            ">
                <span style="font-size:30px;color:#0b220e"> <strong>Mesa de producción 2</strong> </span>
                <h3 style="color:white;font-size:25px;color:#207529"><strong id="spanEstatusL2"></strong> </h3>
            </td>
        </tr>
         <tr>
            <td style="width: 65%;height: 200px; text-align:center; ">
                <span style="font-size:30px;color:#0b220e"> <strong>Mesa de producción 3</strong> </span>
                <h3 style="color:white;font-size:25px;color:#207529; "><strong id="spanEstatusL3"></strong> </h3>
                <br />
                <br />
            </td>
        </tr>

    </table>

  </div>
    
    <style>
        table {
            border-collapse: separate;
            border-spacing: 15px;
        }
        .table td:hover {
              background-color: #808080;
        }
        .table td {
            background-color:#E5E8EF;
        }

        .table td {
            cursor:pointer;
        }
        
    </style>
  
    <script>

        OPMonitoreada();
        setInterval(function () { OPMonitoreada(); }, 5000);

    </script>

    <style>

    </style>
</body>
</html>
