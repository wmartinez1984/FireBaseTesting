<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataOP.ascx.cs" Inherits="FireBaseTesting.Temporizadores.Controles.DataOP" %>
<div style="border-radius:30px;border-color:#ff0000;border:double; border-width:20px;background-color:#ffffff; width:97%;">
    <table style="color:#ff6a00;font-size:18px;width:88%;">
        <tr>
            <td style="text-align:right;font-size:30px;color:#ff6a00" colspan="2" >
               <img src="Images/Fruselva.png" style="width:200px" />
            </td>
          
        </tr>
        <tr>
            <td style="text-align:left;font-size:30px;" colspan="2" >
                <strong>
                   Datos de la OP 
                </strong>  
            </td>
          
        </tr>
         <tr>
            <td style="text-align:left;">
                Estado OP:
            </td>
            <td>
               <strong style="color:#009714;font-size:15px;" >
                   <input type="text" id="EstadoOP" name="EstadoOP" style="background-color:transparent;border:none;" readonly="readonly"/>
               </strong>  
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                OP:
            </td>
            <td>
                <strong style="color:#009714;font-size:15px;">                  
                  <input type="text" id="DataspanOP" name="DataspanOP" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                NAVI:
            </td>
            <td>
                <strong style="color:#009714;font-size:15px;">
                     <input type="text" id="NAVI" name="NAVI" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        <tr>
            <td  style="text-align:left;">
                Nombre del producto:	
            </td>
            <td>
                <strong style="color:#009714;font-size:15px;">
                    <input type="text" id="NombreProducto" name="NombreProducto" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                Unidades a Fabricar:
            </td>
            <td>
                <strong style="color:#009714;font-size:15px;">
                     <input type="text" id="UnidadesFabricar" name="UnidadesFabricar" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                Cliente:
            </td>
            <td>
                <strong style="color:#009714;font-size:15px;">
                     <input type="text" id="Cliente" name="Cliente" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                Tiempo de Lavado(Minutos):
            </td>
            <td>
                <strong style="color:#009714;font-size:15px;">
                      <input type="text" id="Lavado" name="Lavado" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        
    </table>
</div>