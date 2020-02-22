<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataOP2.ascx.cs" Inherits="FireBaseTesting.Temporizadores.Controles.DataOP2" %>

<div id="divDatosAdicionales" style="margin-top:-5px;">
    <table style="width:90%;margin:auto;">
          <tr>
                <td style="text-align:right;font-size:30px;color:#ff6a00" >
                     <a href="login.aspx">
                      <img src="Images/Fruselva.png" style="width:200px" />
                    </a> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p style="color:#ff6a00; font-size:25px;text-align:left; ">
                        <strong style="color:#000000;font-size:45px;">
                                Pouch por Caja
                        </strong>
					</p>	
                </td>
                
            </tr>
            
			<tr>				
				<td style="text-align:left;" colspan="2">                    				
					<input id="txtPouchPorCaja" type="text" style="width:100%; font-size:90px; text-align:left;background-color:transparent;border:none;"  maxlength="3"/>
				</td>
               
			</tr>
             <tr>
                <td colspan="2">
                    <p style="color:#ff6a00; font-size:25px;text-align:left; ">
                        <strong style="color:#000000;font-size:45px;">
                               Personas por Mesa
                        </strong>
					</p>	
                </td>
                
            </tr>            
			<tr>				
				<td style="text-align:left;" colspan="2">                    				
					<input id="txtPersonasPorMesa" type="text"  style="width:100%; font-size:90px; text-align:left;background-color:transparent;border:none;" maxlength="2"/>
				</td>
               
			</tr>
            <tr>
                <td colspan="2">
                      <p style="color:#ff6a00; text-align:left;">
                           <strong style="color:#000000;font-size:45px;">
                                  Nombre del producto:	
                            </strong>
					  </p>	
                </td>
            </tr>
            <tr>
                 <td  style="text-align:left;" colspan="2">
                    <input id="NombreProducto" name="NombreProducto" type="text" style="width:100%; font-size:30px; text-align:center;background-color:transparent;border:none;"  readonly="readonly"/>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p style="color:#ff6a00;text-align:left;">
                        <strong style="color:#000000;font-size:28px;">
                                  Código Navision prod.Terminado
                        </strong>
					</p>
                </td>
            </tr>
            <tr>
                <td style="text-align:left;" colspan="2">
                    <input id="NAVI" name="NAVI" type="text" style="width:100%; font-size:130px; text-align:left;background-color:transparent;border:none;"  readonly="readonly"/>                   
                </td>
            </tr>
	</table>
</div>


<div style="border-radius:30px;border-color:#ff0000; border-width:20px;background-color:rgba(255, 255, 255, 0.64); width:97%;">

    <table style="color:#ff6a00;font-size:18px;width:80%;margin:auto;display:none;">
        <tr>
            <td style="text-align:right;font-size:30px;color:#ff6a00" colspan="2" >
              <a href="login.aspx">
                  <img src="Images/Fruselva.png" style="width:200px" />
              </a> 
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
               <strong style="color:#009714;font-size:25px;" >
                   <input type="text" id="EstadoOP" name="EstadoOP" style="background-color:transparent;border:none;" readonly="readonly"/>
               </strong>  
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                OP:
            </td>
            <td>
                <strong style="color:#009714;font-size:25px;">                  
                  <input type="text" id="DataspanOP" name="DataspanOP" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                NAVI:
            </td>
            <td>
                <strong style="color:#009714;font-size:25px;">
                     
                </strong>
            </td>
        </tr>
        <tr>
            <td  style="text-align:left;">
                 <strong style="color:#000000;font-size:65px;">
                      Nombre del producto:	
                </strong>
               
            </td>
            <td>
                <strong style="color:#009714;font-size:25px;">
                    <%--<input type="text" id="NombreProducto" name="NombreProducto" style="background-color:transparent;border:none;" readonly="readonly"/>--%>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                Unidades a Fabricar:
            </td>
            <td>
                <strong style="color:#009714;font-size:25px;">
                     <input type="text" id="UnidadesFabricar" name="UnidadesFabricar" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                Cliente:
            </td>
            <td>
                <strong style="color:#009714;font-size:25px;">
                     <input type="text" id="Cliente" name="Cliente" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                Tiempo de Lavado(Minutos):
            </td>
            <td>
                <strong style="color:#009714;font-size:25px;">
                      <input type="text" id="Lavado" name="Lavado" style="background-color:transparent;border:none;" readonly="readonly"/>
                </strong>               
            </td>
        </tr>
        
    </table>
</div>