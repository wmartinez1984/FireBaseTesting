<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="FireBaseTesting.Temporizadores.Data" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
      <meta name="viewport" content="width=device-width, initial-scale=1"><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
      <link rel="stylesheet" href="./style.css">
      <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>


</head>
<body style="background-image: linear-gradient(to right, rgba(255,0,0,0), rgba(255,0,0,1));">
  
<!-- partial -->
  
    <table style="width:100%;margin-top:-24px;"  class="table">
       
        <tr> 
            <td style="width:30%;text-align:center;border-radius: 22% / 82%;" >
                <p style="color:#6e1414;font-size:30px;text-align:center;">
                  <strong>
                      Lavados
                  </strong> 
                </p>

                <div id="app4" class="button">
                      <zz-button-progress text="Enjuague" ref="zzUpload" v-on:progress="moveProgress" v-on:progress-finished="endProgress"  style="background-color:rgb(232, 41, 26);"></zz-button-progress>
                 </div>
                 <br />
                <div id="app5" class="button">
                      <zz-button-progress text="CIP" ref="zzUpload" v-on:progress="moveProgress" v-on:progress-finished="endProgress" style="background-color:#ff6a00;"></zz-button-progress>
                 </div>
                 <br />
                 <div id="app6" class="button">
                      <zz-button-progress text="CIP Ácido" ref="zzUpload" v-on:progress="moveProgress" v-on:progress-finished="endProgress" style="background-color: #83174c;"></zz-button-progress>
                 </div>
            </td>
            <td style="                    text-align: right;
                    text-align: center;
                    background-color: transparent;">                
                    <a href="login.aspx" style="margin-top: -360px;">
                        <img src="Images/Fruselva.png"  style="width:300px;margin-top:-560px;"/>
                    </a>
                
                <p style="text-align:left;width:100%;">
                        <strong style="font-size:30px;">
                               Datos<br />
                        </strong> 
                        OP Actual: <br />
                        Lavado:<br />
                        OP Siguiente:<br />
                        Término de Producción:
                   
              
            </td>
            <td style="width:30%;text-align:center;border-radius: 12% / 32%;">
                <p style="text-align:center;font-size:30px;color:#6e1414">
                   <strong>
                       Paradas
                   </strong> 
                </p>
                 <div id="app"  class="button">
                      <zz-button-progress text="Mínima" ref="zzUpload" v-on:progress="moveProgress" v-on:progress-finished="endProgress"  style="background-color:#f7ce39;"></zz-button-progress>
                 </div>
                <br />
                 <div id="app2" class="button">
                      <zz-button-progress text="Media" ref="zzUpload" v-on:progress="moveProgress" v-on:progress-finished="endProgress" style="background-color:#24189d;"></zz-button-progress>
                 </div>
                 <br />
                 <div id="app3" class="button">
                      <zz-button-progress text="Mantenimiento" ref="zzUpload" v-on:progress="moveProgress" v-on:progress-finished="endProgress" style="background-color:turquoise;"></zz-button-progress>
                 </div>

                 <script src='https://cdnjs.cloudflare.com/ajax/libs/vue/2.6.10/vue.min.js'></script><script  src="./script.js"></script>
                <br />
            </td>
        </tr>
       
        </table> 
    <table style="width:100%;margin-top:-24px;" class="table2">
        <tr>
            <td style="width: 30%; height: 110px; cursor: pointer; border-radius: 22% / 22%;" id="L1">
                 <p style="color:#ffffff;font-size:20px;text-align:center;">
                  <strong>
                      Línea 1
                  </strong> 
                </p>
            </td>
            <td style="height: 110px; cursor: pointer; border-radius: 2% / 32%" id="L2">
                <p style="color:#ffffff;font-size:20px;text-align:center;">
                  <strong>
                      Línea 2
                  </strong> 
                </p>
            </td>
            <td style="width:30%;cursor:pointer;height: 110px;  border-radius: 12% / 92%" id="L3">
                <p style="color:#ffffff;font-size:20px;text-align:center;">
                  <strong>
                      Línea 3
                  </strong> 
                </p>
            </td>
        </tr>
    </table>
   
    <style>
        table {
            border-collapse: separate;
            border-spacing: 15px;
        }
        .table td:hover {
              background-color:transparent;
        }
        .table td {
            background-color:rgba(255, 255, 255, 0.34);
        }
        

        table2 {
            border-collapse: separate;
            border-spacing: 15px;
            background-color: #388a43;
        }
        .table2 td:hover {
              background-color: rgba(32, 63, 17, 0.32);
        }
      
        .table2 td {
            background-color:#21612a;
        }

        .button:hover {background-color: rgba(155, 133, 133, 0.50)}
    </style>
    

     <script src='https://cdnjs.cloudflare.com/ajax/libs/vue/2.6.10/vue.min.js'>
     </script><script  src="js/jsbtn1.js"></script>
</body>
</html>
