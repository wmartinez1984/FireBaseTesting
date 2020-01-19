<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Temporizador.aspx.cs" Inherits="FireBaseTesting.Temporizadores.Temporizador" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
  
</head>
<body >

    <table style="width:100%;margin-top:-24px;" class="table" >
        <tr>       
                <td rowspan="2" style="width:20%;height:400px;">

                        <p style="color:white;font-size:50px;text-align:center;">
                            Timer 1
                        </p>
                       
                </td>

                <td rowspan="2" style="width:20%;height:400px;">

                        <p style="color:white;font-size:50px;text-align:center;">
                            Timer 2
                        </p>
                      
                </td>

                <td rowspan="2" style="width: 20%; height: 400px;">

                    <p style="color:white;font-size:50px;text-align:center;">
                        Timer 3
                    </p>
                   
                </td>

                <td   style="text-align:right;text-align:center;background-color:transparent;">
               
                    <a href="login.aspx">
                        <img src="Images/Fruselva.jpeg"  style="width:300px;"/>
                    </a>
                </td>

        </tr>

        <tr>
             <td style="width:40%;height:600px;background-color:#065e3f; border:dotted;border-color:#ffffff;border-width:20px;">
                <p style="color:white;font-size:40px;text-align:center;">
                    DATOS
                </p>
             </td>
        </tr>

        <tr>
            <td>
                <span style="color:white">Texto de ejemplo</span>
            </td>
        </tr>
    </table>
   
    <style>
        table {
            border-collapse: separate;
            border-spacing: 15px;
        }
        .table td:hover {
              background-color: #808080;
        }
        .table td {
            background-color:#388a43;
        }

        .table td {
            cursor:pointer;
        }
        
    </style>
  
    <script>

    </script>
</body>
</html>
