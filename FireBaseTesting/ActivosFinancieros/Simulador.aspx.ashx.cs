using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.IO;

using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Web.Script.Serialization;
using System.Collections;

namespace FireBaseTesting.ActivosFinancieros
{
    /// <summary>
    /// Descripción breve de Simulador_aspx
    /// </summary>
    public class Simulador_aspx : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Action"].ToString().Equals("TechnicalAnalysis"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = TechnicalAnalysisList(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("TechnicalAnalysisExcel"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = TechnicalAnalysisListExcel(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("TechnicalAnalysisExcelP2y3"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = TechnicalAnalysisListExcelP2y3(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("TechnicalAnalysisExcelP3"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = TechnicalAnalysisListExcelP3(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("TechnicalAnalysisExceMasColumnas"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = TechnicalAnalysisListExcelP2MasColumnasAdicionales(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("GuardandoHistorico"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = GuardarHistoricodeResultados(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }
        }

        public string GuardarHistoricodeResultados(HttpContext Context)
        {

            var excel = new ExcelPackage(new FileInfo(Context.Server.MapPath("DadaExcel/Result.xlsx").ToString()));
            ExcelWorksheet workSheet = excel.Workbook.Worksheets[1];
            ExcelDataResult TechnicaListResult = new ExcelDataResult();           
            TechnicaListResult.URL = "";

            try
            {

                string Activo = Context.Request.QueryString["Activo"];
                string Sesiones = Context.Request.QueryString["Sesiones"];
                int RapidaInicial = int.Parse(Context.Request.QueryString["RapidaInicial"]);
                int RapidaFinal = int.Parse(Context.Request.QueryString["RapidaFinal"]);
                int LentaInicial = int.Parse(Context.Request.QueryString["LentaInicial"]);
                int LentaFinal = int.Parse(Context.Request.QueryString["LentaFinal"]);
                decimal CapitalInicial = decimal.Parse(Context.Request.QueryString["CapitalInicial"]);
                decimal ComisionEntrada = decimal.Parse(Context.Request.QueryString["ComisionEntrada"]);
                decimal ComisionSalida = decimal.Parse(Context.Request.QueryString["ComisionSalida"]);


                //datos que hacen falta 
                string TipoEstrategia = Context.Request.QueryString["TipoEstrategia"];
                string Indicador = Context.Request.QueryString["Indicador"];
                string Temporalidad = Context.Request.QueryString["Temporalidad"];
                string TipoPrecio = Context.Request.QueryString["TipoPrecio"];
                int Resultados = int.Parse(Context.Request.QueryString["Resultados"]);

                //instanciamos la clase para agregar nuevo resultado a la base de datos 
                Guid id = Guid.NewGuid();
                Resultados resultados = new Resultados();
                resultados.id = id;
                resultados.Fecha = DateTime.Now;
                resultados.Activo = Activo;
                resultados.Estrategia = TipoEstrategia;
                resultados.Secciones = int.Parse(Sesiones);
                resultados.Indicador = Indicador;
                resultados.Temporalidad = Temporalidad;
                resultados.TipoPrecio = TipoPrecio;
                resultados.CapitalInicial = CapitalInicial;
                resultados.resultados = Resultados;
                resultados.ComisionEntrada = ComisionEntrada;
                resultados.ComisionSalida = ComisionSalida;

                ACTFResultados aCTFResultados = new ACTFResultados();
                aCTFResultados.Insert(resultados);

                //loop all worksheets
                var data = new List<ResultadosDetalle>();
                foreach (ExcelWorksheet worksheet in excel.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                    {
                        ResultadosDetalle resultadosDetalle = new ResultadosDetalle();
                        if (worksheet.Cells[i, 1].Value != null)
                        {
                            resultadosDetalle.id = Guid.NewGuid();
                            resultadosDetalle.Senal = worksheet.Cells[i, 1].Value.ToString();
                            resultadosDetalle.Cantidaddedias = int.Parse(worksheet.Cells[i, 2].Value.ToString());
                            resultadosDetalle.Cantidadediasfueradelmercado = int.Parse(worksheet.Cells[i, 3].Value.ToString());
                            resultadosDetalle.Cantidaddediasdentrodelmercado = int.Parse(worksheet.Cells[i, 4].Value.ToString());
                            resultadosDetalle.CantidadtotaldeOperaciones = int.Parse(worksheet.Cells[i, 5].Value.ToString());
                            if(resultadosDetalle.CantidadtotaldeOperaciones != 0)
                            {
                                decimal Ganadoras = int.Parse(worksheet.Cells[i, 6].Value.ToString());
                                decimal PGanadoras = (decimal.Parse(Ganadoras.ToString().Trim()) / decimal.Parse(resultadosDetalle.CantidadtotaldeOperaciones.ToString().Trim())) * 100;
                                resultadosDetalle.CantidadtotaldeOPGanadoras = worksheet.Cells[i, 6].Value.ToString() + " (" + Decimal.Round(PGanadoras, 4).ToString() + ")";

                                decimal perdedoras = int.Parse(worksheet.Cells[i, 7].Value.ToString());
                                decimal Pperdedoras = (decimal.Parse(perdedoras.ToString().Trim()) / decimal.Parse(resultadosDetalle.CantidadtotaldeOperaciones.ToString().Trim())) * 100;
                                resultadosDetalle.CantidadtotaldeOPPerdedoras = worksheet.Cells[i, 7].Value.ToString() + " (" + Decimal.Round(Pperdedoras, 4) + ")";

                            }
                            else
                            {
                                resultadosDetalle.CantidadtotaldeOPGanadoras = worksheet.Cells[i, 6].Value.ToString();
                                resultadosDetalle.CantidadtotaldeOPPerdedoras = worksheet.Cells[i, 7].Value.ToString();

                            }
                            resultadosDetalle.GananciaMaxima = Decimal.Round(decimal.Parse(worksheet.Cells[i, 8].Value.ToString()), 4);
                            resultadosDetalle.PerdidaMaxima = Decimal.Round(decimal.Parse(worksheet.Cells[i, 9].Value.ToString()), 4);
                            resultadosDetalle.PerformanceTotal = Decimal.Round(decimal.Parse(worksheet.Cells[i, 10].Value.ToString()), 4);
                            resultadosDetalle.PerformanceAnualizada = Decimal.Round(decimal.Parse(worksheet.Cells[i, 11].Value.ToString()), 4);
                            resultadosDetalle.PerformanceBuyAndHold = Decimal.Round(decimal.Parse(worksheet.Cells[i, 12].Value.ToString()), 4);
                            resultadosDetalle.PerformanceBuyAndHoldAnualizada = Decimal.Round(decimal.Parse(worksheet.Cells[i, 13].Value.ToString()), 4);
                            resultadosDetalle.EM = Decimal.Round(decimal.Parse(worksheet.Cells[i, 14].Value.ToString()), 4);
                            resultadosDetalle.RachaGanadora = Decimal.Round(decimal.Parse(worksheet.Cells[i, 15].Value.ToString()), 4);
                            resultadosDetalle.RachaPerdedora = Decimal.Round(decimal.Parse(worksheet.Cells[i, 16].Value.ToString()), 4);

                        }

                        data.Add(resultadosDetalle);                      

                    }

                }
                if(data.Count > 0)
                aCTFResultados.InsertDetalle(data, id);


            }
            catch (Exception ex)
            {
                try
                {
                    string nameLog = DateTime.Now.ToString();
                    string p_strPathLog1 = Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt").ToString();
                    if (File.Exists(p_strPathLog1))
                        File.Delete(p_strPathLog1);

                    using (StreamWriter _testData = new StreamWriter(Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt"), true))
                    {
                        _testData.WriteLine(ex.ToString());
                    }

                }
                catch
                {

                }


            }

            
            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(TechnicaListResult));
        }



        public string TechnicalAnalysisListExcelP2MasColumnasAdicionales(HttpContext Context)
        {

            var excel = new ExcelPackage(new FileInfo(Context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString()));
            ExcelWorksheet workSheet = excel.Workbook.Worksheets[1];

            var excel2 = new ExcelPackage(new FileInfo(Context.Server.MapPath("DadaExcel/Senales.xlsx").ToString()));
            ExcelWorksheet SenalSheet1 = excel2.Workbook.Worksheets[1];

            string FileName = "DadaExcel/Senales.xlsx";

            //procesar datos recibidos en JSON
            ExcelDataResult TechnicaListResult = new ExcelDataResult();

            //TechnicaListResult.ExcelName = "TechnicalAnalysisv2.xlsx";
            TechnicaListResult.URL = FileName;

            try
            {



                string Activo = Context.Request.QueryString["Activo"];
                string Sesiones = Context.Request.QueryString["Sesiones"];
                int RapidaInicial = int.Parse(Context.Request.QueryString["RapidaInicial"]);
                int RapidaFinal = int.Parse(Context.Request.QueryString["RapidaFinal"]);
                int LentaInicial = int.Parse(Context.Request.QueryString["LentaInicial"]);
                int LentaFinal = int.Parse(Context.Request.QueryString["LentaFinal"]);
                decimal CapitalInicial = decimal.Parse(Context.Request.QueryString["CapitalInicial"]);
                decimal ComisionEntrada = decimal.Parse(Context.Request.QueryString["ComisionEntrada"]);
                decimal ComisionSalida = decimal.Parse(Context.Request.QueryString["ComisionSalida"]);
                string Estrategia = Context.Request.QueryString["Estrategia"];

                int RapidaInicialColum = RapidaInicial;
                int ColumInicial = 1;             

                ColumInicial = 1;
                int FilaPestanaFinal = 2;
                decimal PrecioActual = 0;
                PrecioActual = decimal.Parse(workSheet.Cells[2, 2].Value.ToString());
                decimal PrecioInicial = 0;
                PrecioInicial = decimal.Parse(workSheet.Cells[int.Parse(Sesiones) + 1, 2].Value.ToString());

                for (int s = RapidaInicial; s <= RapidaFinal; s++)
                {

                    for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                    {
                        //Cant.Acciones, Capital.Neto, Ganancia.OP
                        int DiasDentroMercado = 0;
                        int DiasFueraMercado = 0;
                        int Ganadora = 0;
                        int Perdedora = 0;
                        int CantGanadora = 0;
                        int CantPerdedora = 0;
                        string GanadoraPerdedora = "0";
                        decimal GananciaMaxima = 0;
                        decimal PerdidaMaxima = 0;
                        int GanadoraMax = 0;
                        int PerdedoraMax = 0;
                        decimal Acciones = 0;
                        decimal Capitalneto = CapitalInicial;
                        decimal Ganancia = 0;

                        string texttoValoresAdicionales = "";

                        //ÚLTIMA LÍNEA...

                        texttoValoresAdicionales = ", Precio = " + PrecioActual + ", Cant.Acciones = " + Acciones + ", Capital.Neto = " + Capitalneto + ", Ganancia.OP = " + Ganancia + " , Ganadoras/Perdedoras = " + GanadoraPerdedora + ", Racha Ganadora = " + Ganadora + ", Racha Perdedora = " + Perdedora + " ";
                        SenalSheet1.Cells[int.Parse(Sesiones) + 1, c].Value = SenalSheet1.Cells[int.Parse(Sesiones) + 1, c].Value + texttoValoresAdicionales;

                        if (Estrategia.Contains("Largo"))
                        {
                            for (int f = int.Parse(Sesiones); f >= 2; f--)
                            {



                                PrecioActual = decimal.Parse(workSheet.Cells[f, 2].Value.ToString());
                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("NEUTRO"))
                                {
                                    Acciones = (Acciones * 1);
                                    Capitalneto = Capitalneto * 1;
                                    Ganancia = 0;
                                }

                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("SELL"))
                                {
                                    if (Acciones != 0)
                                    {
                                        decimal CapitalnetoAnterior = Capitalneto; //antes de recalcular el Capitalneto almaceno el anterior
                                        Capitalneto = (Acciones * PrecioActual) - (((Acciones * PrecioActual) / 100) * ComisionSalida);
                                        Ganancia = (Capitalneto / CapitalnetoAnterior) - 1;
                                        Acciones = 0;
                                    }
                                    else
                                    {
                                        Capitalneto = (Capitalneto * 1);
                                        Acciones = 0;
                                    }
                                }

                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("BUY"))
                                {
                                    Capitalneto = (Capitalneto - ((Capitalneto / 100) * ComisionEntrada));
                                    Acciones = Capitalneto / PrecioActual;
                                    Ganancia = 0;
                                }

                                if (Ganancia > 0)
                                {
                                    GanadoraPerdedora = "1";
                                    Ganadora += 1;
                                    Perdedora = 0;
                                    CantGanadora += 1;
                                }
                                if (Ganancia < 0)
                                {
                                    GanadoraPerdedora = "-1";
                                    Ganadora = 0;
                                    Perdedora = (Perdedora - 1);
                                    CantPerdedora += 1;
                                }

                                if (Ganancia == 0)
                                {
                                    GanadoraPerdedora = "0";
                                }

                                if (Acciones == 0)
                                    DiasFueraMercado += 1;



                                if (Ganancia > GananciaMaxima)
                                    GananciaMaxima = Ganancia;

                                if (Ganancia < PerdidaMaxima)
                                    PerdidaMaxima = Ganancia;

                                if (Ganadora > GanadoraMax)
                                    GanadoraMax = Ganadora;

                                if (Perdedora < PerdedoraMax)
                                    PerdedoraMax = Perdedora;


                                texttoValoresAdicionales = ", Precio = " + PrecioActual + ", Cant.Acciones = " + Decimal.Round(Acciones, 5) + ", Capital.Neto = " + Decimal.Round(Capitalneto, 5) + ", Ganancia.OP = " + Ganancia + ", Ganadoras/Perdedoras = " + GanadoraPerdedora + ", Racha Ganadora = " + Ganadora + ", Racha Perdedora = " + Perdedora + " ";

                                SenalSheet1.Cells[f, c].Value = SenalSheet1.Cells[f, c].Value + texttoValoresAdicionales;


                            }
                        }

                        else //Cálculo para cortos
                        {
                            for (int f = int.Parse(Sesiones); f >= 2; f--)
                            {



                                PrecioActual = decimal.Parse(workSheet.Cells[f, 2].Value.ToString());
                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("NEUTRO"))
                                {
                                    Acciones = (Acciones * 1);
                                    Capitalneto = Capitalneto * 1;
                                    Ganancia = 0;
                                }

                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("SELL"))
                                {
                                    Capitalneto = (Capitalneto - ((Capitalneto / 100) * ComisionEntrada));
                                    Acciones = Capitalneto / PrecioActual;
                                    Ganancia = 0;
                                }

                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("BUY"))
                                {
                                    if (Acciones != 0)
                                    {
                                        decimal CapitalnetoAnterior = Capitalneto; //antes de recalcular el Capitalneto almaceno el anterior
                                        Capitalneto = (Acciones * PrecioActual) - (((Acciones * PrecioActual) / 100) * ComisionSalida);
                                        Ganancia = (Capitalneto / CapitalnetoAnterior) - 1;
                                        Acciones = 0;
                                    }
                                    else
                                    {
                                        Capitalneto = (Capitalneto * 1);
                                        Acciones = 0;
                                    }
                                }

                                if (Ganancia > 0)
                                {
                                    GanadoraPerdedora = "1";
                                    Ganadora += 1;
                                    Perdedora = 0;
                                    CantGanadora += 1;
                                }
                                if (Ganancia < 0)
                                {
                                    GanadoraPerdedora = "-1";
                                    Ganadora = 0;
                                    Perdedora = (Perdedora - 1);
                                    CantPerdedora += 1;
                                }

                                if (Ganancia == 0)
                                {
                                    GanadoraPerdedora = "0";
                                }

                                if (Acciones == 0)
                                    DiasFueraMercado += 1;



                                if (Ganancia > GananciaMaxima)
                                    GananciaMaxima = Ganancia;

                                if (Ganancia < PerdidaMaxima)
                                    PerdidaMaxima = Ganancia;

                                if (Ganadora > GanadoraMax)
                                    GanadoraMax = Ganadora;

                                if (Perdedora < PerdedoraMax)
                                    PerdedoraMax = Perdedora;


                                texttoValoresAdicionales = ", Precio = " + PrecioActual + ", Cant.Acciones = " + Decimal.Round(Acciones, 5) + ", Capital.Neto = " + Decimal.Round(Capitalneto, 5) + ", Ganancia.OP = " + Ganancia + ", Ganadoras/Perdedoras = " + GanadoraPerdedora + ", Racha Ganadora = " + Ganadora + ", Racha Perdedora = " + Perdedora + " ";

                                SenalSheet1.Cells[f, c].Value = SenalSheet1.Cells[f, c].Value + texttoValoresAdicionales;


                            }
                        }
                        

                        
                        FilaPestanaFinal += 1;

                    }

                    ColumInicial += (LentaFinal - LentaInicial) + 1;

                }

            }
            catch (Exception ex)
            {
                try
                {
                    string nameLog = DateTime.Now.ToString();
                    string p_strPathLog1 = Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt").ToString();
                    if (File.Exists(p_strPathLog1))
                        File.Delete(p_strPathLog1);

                    using (StreamWriter _testData = new StreamWriter(Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt"), true))
                    {
                        _testData.WriteLine(ex.ToString());
                    }

                }
                catch
                {

                }


            }

            try
            {
                string p_strPath = Context.Server.MapPath(FileName).ToString();
                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                // Create excel file on physical disk  
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // Write content to excel file  
                File.WriteAllBytes(p_strPath, excel2.GetAsByteArray());
                //Close Excel package 
                excel2.Dispose();
                excel.Dispose();
            }
            catch (Exception ex)
            {

            }



            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(TechnicaListResult));
        }



        public string TechnicalAnalysisListExcelP3(HttpContext Context)
        {
            var excel = new ExcelPackage(new FileInfo(Context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString()));
            ExcelWorksheet workSheet = excel.Workbook.Worksheets[1];

            var excelSenales = new ExcelPackage(new FileInfo(Context.Server.MapPath("DadaExcel/Senales.xlsx").ToString()));
            ExcelWorksheet SenalSheet1 = excelSenales.Workbook.Worksheets[1];

            ExcelPackage excel2 = new ExcelPackage();
            var SenalSheet2 = excel2.Workbook.Worksheets.Add("Resultados");

            string FileName = "DadaExcel/Result.xlsx";
            //procesar datos recibidos en JSON
            ExcelDataResult TechnicaListResult = new ExcelDataResult();
            //TechnicaListResult.ExcelName = "TechnicalAnalysisv2.xlsx";
            TechnicaListResult.URL = FileName;


            //Encabezado última pestaña 
            SenalSheet2.Cells[1, 1].Value = "Señal";
            SenalSheet2.Cells[1, 2].Value = "Cantidad de días";
            SenalSheet2.Cells[1, 3].Value = "Cantida de días fuera del mercado";
            SenalSheet2.Cells[1, 4].Value = "Cantidad de días dentro del mercado";
            SenalSheet2.Cells[1, 5].Value = "Cantidad total de Operaciones";
            SenalSheet2.Cells[1, 6].Value = "Cantidad total de OP. Ganadoras";
            SenalSheet2.Cells[1, 7].Value = "Cantidad total de OP. Perdedoras";
            SenalSheet2.Cells[1, 8].Value = "Ganancia Máxima";
            SenalSheet2.Cells[1, 9].Value = "Perdida Máxima";
            SenalSheet2.Cells[1, 10].Value = "Performance Total";
            SenalSheet2.Cells[1, 11].Value = "Performance Anualizada";
            SenalSheet2.Cells[1, 12].Value = "Performance Buy&Hold";
            SenalSheet2.Cells[1, 13].Value = "Performance Buy&Hold Anualizada";
            SenalSheet2.Cells[1, 14].Value = "EM (Esperanza Matemática) ";
            SenalSheet2.Cells[1, 15].Value = "Racha Ganadora";
            SenalSheet2.Cells[1, 16].Value = "Racha Perdedora";

            

            try
            {



                string Activo = Context.Request.QueryString["Activo"];
                string Sesiones = Context.Request.QueryString["Sesiones"];
                int RapidaInicial = int.Parse(Context.Request.QueryString["RapidaInicial"]);
                int RapidaFinal = int.Parse(Context.Request.QueryString["RapidaFinal"]);
                int LentaInicial = int.Parse(Context.Request.QueryString["LentaInicial"]);
                int LentaFinal = int.Parse(Context.Request.QueryString["LentaFinal"]);
                decimal CapitalInicial = decimal.Parse(Context.Request.QueryString["CapitalInicial"]);
                decimal ComisionEntrada = decimal.Parse(Context.Request.QueryString["ComisionEntrada"]);
                decimal ComisionSalida = decimal.Parse(Context.Request.QueryString["ComisionSalida"]);
                string Estrategia = Context.Request.QueryString["Estrategia"];

                int RapidaInicialColum = RapidaInicial;
                int ColumInicial = 1;
                
                ColumInicial = 1;
                int FilaPestanaFinal = 2;
                decimal PrecioActual = 0;
                PrecioActual = decimal.Parse(workSheet.Cells[2, 2].Value.ToString());
                decimal PrecioInicial = 0;
                PrecioInicial = decimal.Parse(workSheet.Cells[int.Parse(Sesiones) + 1, 2].Value.ToString());


                //última pestaña 
                DateTime FechaInicio = DateTime.Parse(workSheet.Cells[2, 1].Value.ToString());
                DateTime FechaFinal = DateTime.Parse(workSheet.Cells[int.Parse(Sesiones) + 1, 1].Value.ToString());
                TimeSpan tSpan = FechaInicio - FechaFinal;
                int diasTotales = tSpan.Days; //Días transcurridos desde la fecha inicial de la pestaña uno a la final de la misma pestaña

                if (diasTotales == 0)
                    diasTotales = 1;

                //Performance Buy&Hold
                //1. Calculo el capital inicial después de descontar la comisión de entrada
                Decimal CapitalInicialLibreComisiones = CapitalInicial - ((CapitalInicial * ComisionEntrada) / 100);
                // 2. Calculo la cantidad de acciones que puedo comprar con el capital incial lire de comisiones (Capital inicial libre de comisiones/Precio inicial
                Decimal CantidadAcciones = CapitalInicialLibreComisiones / PrecioInicial;
                //3. Calculo el capital final bruto, es decir la cantidad de plata que voy a recibir al final de la estrategía por vender la cantidad de acciones que calcule en el punto 2 (Cantidad de acciones por el precio final
                Decimal CapitalFinalBruto = CantidadAcciones * PrecioActual;
               // CapitalFinalBruto = Decimal.Round(CapitalFinalBruto, 4);
                //4. Calculo el capital final neto, descontando comisiones
                Decimal CapitalFinalNeto = CapitalFinalBruto - ((CapitalFinalBruto * ComisionSalida) / 100);
                //5. Calculo la performance (capital final neto/capital inicial
                Decimal TotalBuyHold = (CapitalFinalNeto / CapitalInicial) - 1;
                //6. Calculo la performance en %
                TotalBuyHold = (TotalBuyHold * 100);

                //Performance Buy&Hold Anualizada
                Decimal TotalBuyHoldAnual = (TotalBuyHold / diasTotales) * 365;

                for (int s = RapidaInicial; s <= RapidaFinal; s++)
                {

                    for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                    {
                        //Cant.Acciones, Capital.Neto, Ganancia.OP
                        
                        int DiasFueraMercado = 0;
                        int Ganadora = 0;
                        int Perdedora = 0;
                        int CantGanadora = 0;
                        int CantPerdedora = 0;
                        string GanadoraPerdedora = "0";
                        decimal GananciaMaxima = 0;
                        decimal PerdidaMaxima = 0;
                        int GanadoraMax = 0;
                        int PerdedoraMax = 0;
                        decimal Acciones = 0;
                        decimal Capitalneto = CapitalInicial;
                        decimal Ganancia = 0;
                        if (Estrategia.Contains("Largo"))
                        {
                            for (int f = int.Parse(Sesiones); f >= 2; f--)
                            {

                                PrecioActual = decimal.Parse(workSheet.Cells[f, 2].Value.ToString());
                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("NEUTRO"))
                                {
                                    Acciones = (Acciones * 1);
                                    Capitalneto = Capitalneto * 1;
                                    Ganancia = 0;
                                }

                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("SELL"))
                                {
                                    if (Acciones != 0)
                                    {
                                        decimal CapitalnetoAnterior = Capitalneto; //antes de recalcular el Capitalneto almaceno el anterior
                                        Capitalneto = (Acciones * PrecioActual) - (((Acciones * PrecioActual) / 100) * ComisionSalida);
                                        Ganancia = (Capitalneto / CapitalnetoAnterior) - 1;
                                        Acciones = 0;
                                    }
                                    else
                                    {

                                        Capitalneto = (Capitalneto * 1);
                                        Acciones = 0;
                                    }
                                }

                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("BUY"))
                                {
                                    Capitalneto = (Capitalneto - ((Capitalneto / 100) * ComisionEntrada));
                                    Acciones = Capitalneto / PrecioActual;
                                    Ganancia = 0;
                                }

                                if (Ganancia > 0)
                                {
                                    GanadoraPerdedora = "1";
                                    Ganadora += 1;
                                    Perdedora = 0;
                                    CantGanadora += 1;
                                }
                                if (Ganancia < 0)
                                {
                                    GanadoraPerdedora = "-1";
                                    Ganadora = 0;
                                    Perdedora = (Perdedora - 1);
                                    CantPerdedora += 1;
                                }

                                if (Ganancia == 0)
                                {
                                    GanadoraPerdedora = "0";
                                }

                                if (Acciones == 0)
                                    DiasFueraMercado += 1;



                                if (Ganancia > GananciaMaxima)
                                    GananciaMaxima = Ganancia;

                                if (Ganancia < PerdidaMaxima)
                                    PerdidaMaxima = Ganancia;

                                if (Ganadora > GanadoraMax)
                                    GanadoraMax = Ganadora;

                                if (Perdedora < PerdedoraMax)
                                    PerdedoraMax = Perdedora;


                            }
                        }
                        else //cálculo diferente para cotos 
                        {
                            for (int f = int.Parse(Sesiones); f >= 2; f--)
                            {

                                PrecioActual = decimal.Parse(workSheet.Cells[f, 2].Value.ToString());
                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("NEUTRO"))
                                {
                                    Acciones = (Acciones * 1);
                                    Capitalneto = Capitalneto * 1;
                                    Ganancia = 0;
                                }

                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("SELL"))
                                {
                                    Capitalneto = (Capitalneto - ((Capitalneto / 100) * ComisionEntrada));
                                    Acciones = Capitalneto / PrecioActual;
                                    Ganancia = 0;

                                }

                                if (SenalSheet1.Cells[f, c].Value.ToString().Contains("BUY"))
                                {
                                    if (Acciones != 0)
                                    {
                                        decimal CapitalnetoAnterior = Capitalneto; //antes de recalcular el Capitalneto almaceno el anterior
                                        Capitalneto = (Acciones * PrecioActual) - (((Acciones * PrecioActual) / 100) * ComisionSalida);
                                        Ganancia = (Capitalneto / CapitalnetoAnterior) - 1;
                                        Acciones = 0;
                                    }
                                    else
                                    {

                                        Capitalneto = (Capitalneto * 1);
                                        Acciones = 0;
                                    }
                                }

                                if (Ganancia > 0)
                                {
                                    GanadoraPerdedora = "1";
                                    Ganadora += 1;
                                    Perdedora = 0;
                                    CantGanadora += 1;
                                }
                                if (Ganancia < 0)
                                {
                                    GanadoraPerdedora = "-1";
                                    Ganadora = 0;
                                    Perdedora = (Perdedora - 1);
                                    CantPerdedora += 1;
                                }

                                if (Ganancia == 0)
                                {
                                    GanadoraPerdedora = "0";
                                }

                                if (Acciones == 0)
                                    DiasFueraMercado += 1;



                                if (Ganancia > GananciaMaxima)
                                    GananciaMaxima = Ganancia;

                                if (Ganancia < PerdidaMaxima)
                                    PerdidaMaxima = Ganancia;

                                if (Ganadora > GanadoraMax)
                                    GanadoraMax = Ganadora;

                                if (Perdedora < PerdedoraMax)
                                    PerdedoraMax = Perdedora;


                            }
                        }
                        

                        SenalSheet2.Cells[FilaPestanaFinal, 1].Value = SenalSheet1.Cells[1, c].Value;
                        SenalSheet2.Cells[FilaPestanaFinal, 2].Value = diasTotales;
                        SenalSheet2.Cells[FilaPestanaFinal, 3].Value = DiasFueraMercado;
                        SenalSheet2.Cells[FilaPestanaFinal, 4].Value = diasTotales - DiasFueraMercado;
                        SenalSheet2.Cells[FilaPestanaFinal, 5].Value = CantGanadora + CantPerdedora;
                        SenalSheet2.Cells[FilaPestanaFinal, 6].Value = CantGanadora;
                        SenalSheet2.Cells[FilaPestanaFinal, 7].Value = CantPerdedora;
                        SenalSheet2.Cells[FilaPestanaFinal, 8].Value = GananciaMaxima;
                        SenalSheet2.Cells[FilaPestanaFinal, 9].Value = PerdidaMaxima;

                        decimal PerformanceTotal = (((Capitalneto - CapitalInicial) * 100) / CapitalInicial);
                        SenalSheet2.Cells[FilaPestanaFinal, 10].Value = Decimal.Round(PerformanceTotal, 3);

                        decimal PerformanceAnualizado = (PerformanceTotal / diasTotales) * 365;
                        SenalSheet2.Cells[FilaPestanaFinal, 11].Value = Decimal.Round(PerformanceAnualizado, 3);



                        //Performance buy and hold
                        SenalSheet2.Cells[FilaPestanaFinal, 12].Value = TotalBuyHold;
                        //Performance Buy&Hold Anualizada                       
                        SenalSheet2.Cells[FilaPestanaFinal, 13].Value = TotalBuyHoldAnual;


                        //******************************************************
                        int TotalOP = CantGanadora + CantPerdedora;
                        if (TotalOP == 0) // ESTO ES PORQUE NO SE PUEDE DIVIDIR ENTRE CERO
                        {
                            SenalSheet2.Cells[FilaPestanaFinal, 14].Value = 0;

                        }
                        else
                            SenalSheet2.Cells[FilaPestanaFinal, 14].Value = (PerformanceTotal / (CantGanadora + CantPerdedora));

                        SenalSheet2.Cells[FilaPestanaFinal, 15].Value = GanadoraMax;
                        SenalSheet2.Cells[FilaPestanaFinal, 16].Value = PerdedoraMax;



                        FilaPestanaFinal += 1;

                    }

                    ColumInicial += (LentaFinal - LentaInicial) + 1;


                }



            }
            catch (Exception ex)
            {
                try
                {
                    string nameLog = DateTime.Now.ToString();
                    string p_strPathLog1 = Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt").ToString();
                    if (File.Exists(p_strPathLog1))
                        File.Delete(p_strPathLog1);

                    using (StreamWriter _testData = new StreamWriter(Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt"), true))
                    {
                        _testData.WriteLine(ex.ToString());
                    }

                }
                catch
                {

                }


            }

            try
            {
                string p_strPath = Context.Server.MapPath(FileName).ToString();
                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                // Create excel file on physical disk  
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // Write content to excel file  
                File.WriteAllBytes(p_strPath, excel2.GetAsByteArray());
                //Close Excel package 
                excel2.Dispose();
                excel.Dispose();
            }
            catch (Exception ex)
            {

            }
                       
            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(TechnicaListResult));
        }
        
        public string TechnicalAnalysisListExcelP2y3(HttpContext Context)
        {
            
            var excel = new ExcelPackage(new FileInfo(Context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString()));
            ExcelWorksheet workSheet = excel.Workbook.Worksheets[1];

            ExcelPackage excel2 = new ExcelPackage();
            var SenalSheet1 = excel2.Workbook.Worksheets.Add("Señales");
            string FileName = "DadaExcel/Senales.xlsx";            
            ExcelDataResult TechnicaListResult = new ExcelDataResult();
            TechnicaListResult.URL = FileName;

            try
            {

                string Activo = Context.Request.QueryString["Activo"];
                string Sesiones = Context.Request.QueryString["Sesiones"];
                int RapidaInicial = int.Parse(Context.Request.QueryString["RapidaInicial"]);
                int RapidaFinal = int.Parse(Context.Request.QueryString["RapidaFinal"]);
                int LentaInicial = int.Parse(Context.Request.QueryString["LentaInicial"]);
                int LentaFinal = int.Parse(Context.Request.QueryString["LentaFinal"]);
                decimal CapitalInicial = decimal.Parse(Context.Request.QueryString["CapitalInicial"]);
                decimal ComisionEntrada = decimal.Parse(Context.Request.QueryString["ComisionEntrada"]);
                decimal ComisionSalida = decimal.Parse(Context.Request.QueryString["ComisionSalida"]);


                int RapidaInicialColum = RapidaInicial;
                int ColumInicial = 1;
                for (int s = RapidaInicial; s <= RapidaFinal; s++)
                {
                    int LentaInicialRows = LentaInicial;
                    for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                    {
                        SenalSheet1.Cells[1, c].Value = "Señal (" + s + ", " + LentaInicialRows + ") ";

                        //Primera fila por default
                         SenalSheet1.Cells[2, c].Value = "SELL ( " + s + " = " + decimal.Parse(workSheet.Cells[2, s + 1].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[2, LentaInicialRows + 1].Value + ")";
                        //Señales por columna
                        for (int f = 3; f <= int.Parse(Sesiones); f++)
                        {
                            if (workSheet.Cells[f, s + 1].Value != null && workSheet.Cells[s, LentaInicialRows + 1].Value != null)
                            {
                                    try
                                    {
                                        decimal C1 = decimal.Parse(workSheet.Cells[f, s + 1].Value.ToString());
                                        decimal C2 = decimal.Parse(workSheet.Cells[f, LentaInicialRows + 1].Value.ToString());
                                        decimal C3 = decimal.Parse(workSheet.Cells[f + 1, s + 1].Value.ToString());
                                        decimal C4 = decimal.Parse(workSheet.Cells[f + 1, LentaInicialRows + 1].Value.ToString());

                                        string strSenal = "";

                                        if (C1 > C2 && C4 > C3)
                                            strSenal = "BUY";
                                        else if (C1 < C2 && C3 > C4)
                                            strSenal = "SELL";
                                        else
                                            strSenal = "NEUTRO";

                                        SenalSheet1.Cells[f, c].Value = "" + strSenal + " ( " + s + " = " + decimal.Parse(workSheet.Cells[f, s + 1].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[f, LentaInicialRows + 1].Value + ")";

                                    }
                                    catch(Exception ex)
                                    {


                                    }
                            }


                        }

                        //última fila por default
                        SenalSheet1.Cells[int.Parse(Sesiones) + 1, c].Value = "NEUTRO ( " + s + " = " + decimal.Parse(workSheet.Cells[int.Parse(Sesiones) + 1, s + 1].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[int.Parse(Sesiones) + 1, LentaInicialRows + 1].Value + ")";
                        LentaInicialRows += 1;
                        
                    }

                    ColumInicial += (LentaFinal - LentaInicial) + 1;
                }

            }
            catch (Exception ex)
            {
                try
                {
                    string nameLog = DateTime.Now.ToString();
                    string p_strPathLog1 = Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt").ToString();
                    if (File.Exists(p_strPathLog1))
                        File.Delete(p_strPathLog1);

                    using (StreamWriter _testData = new StreamWriter(Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt"), true))
                    {
                        _testData.WriteLine(ex.ToString());
                    }

                }
                catch
                {

                }


            }

            try
            {
                string p_strPath = Context.Server.MapPath(FileName).ToString();
                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                // Create excel file on physical disk  
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // Write content to excel file  
                File.WriteAllBytes(p_strPath, excel2.GetAsByteArray());
                //Close Excel package 
                excel2.Dispose();
                excel.Dispose();
            }
            catch (Exception ex)
            {

            }



            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(TechnicaListResult));
        }


        public string TechnicalAnalysisListExcel(HttpContext Context)
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("TechnicalAnalysis"); 
            //procesar datos recibidos en JSON
            ExcelDataResult TechnicaListResult = new ExcelDataResult();
            string strJson = new StreamReader(Context.Request.InputStream).ReadToEnd();
            //TechnicaListResult.ExcelName = "TechnicalAnalysisv2.xlsx";
            TechnicaListResult.URL = "DadaExcel/TechnicalAnalysisv2.xlsx";

            try
            {

                JavaScriptSerializer j = new JavaScriptSerializer();
                object Data = j.Deserialize(strJson, typeof(object));

                //Crear  primera pestaña del  excel con los datos consultados por el API
                IEnumerable enumerable = Data as IEnumerable;
                if (enumerable != null)
                {
                    int Fila = 1;
                    foreach (object element in enumerable)
                    {

                        IEnumerable enumerableColumna = element as IEnumerable;
                        int Columna = 1;
                        foreach (object elementColumna in enumerableColumna)
                        {

                           workSheet.Cells[Fila, Columna].Value = elementColumna;
                            //workSheet.Column(Columna).AutoFit();
                            Columna++;

                        }

                        Fila++;
                    }
                }

                string Sesiones = Context.Request.QueryString["Sesiones"];
                int RapidaInicial = int.Parse(Context.Request.QueryString["RapidaInicial"]);
                int RapidaFinal = int.Parse(Context.Request.QueryString["RapidaFinal"]);
                int LentaInicial = int.Parse(Context.Request.QueryString["LentaInicial"]);
                int LentaFinal = int.Parse(Context.Request.QueryString["LentaFinal"]);
                decimal CapitalInicial = decimal.Parse(Context.Request.QueryString["CapitalInicial"]);
                decimal ComisionEntrada = decimal.Parse(Context.Request.QueryString["ComisionEntrada"]);
                decimal ComisionSalida = decimal.Parse(Context.Request.QueryString["ComisionSalida"]);
                int RapidaInicialColum = RapidaInicial;
               

               

            }
            catch (Exception ex)
            {
                try
                {
                    string nameLog = DateTime.Now.ToString();
                    string p_strPathLog1 = Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt").ToString();
                    if (File.Exists(p_strPathLog1))
                        File.Delete(p_strPathLog1);

                    using (StreamWriter _testData = new StreamWriter(Context.Server.MapPath("DadaExcel/log" + nameLog + ".txt"), true))
                    {
                        _testData.WriteLine(ex.ToString());
                    }

                }
                catch { 

                }

                
            }

            try
            {
                string p_strPath = Context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();
                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                // Create excel file on physical disk  
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // Write content to excel file  
                File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                //Close Excel package 
                excel.Dispose();
            }
            catch(Exception ex)
            {

            }
           
            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(TechnicaListResult));
        }

       
        public class ExcelDataResult
        {
            public string ExcelName { get; set; }
            public string URL { get; set; }
           
        }

        public string TechnicalAnalysisList(HttpContext parametro)
        {
            string apikey = parametro.Request.QueryString["apikey"];
            string series_type = parametro.Request.QueryString["series_type"];
            string time_period = parametro.Request.QueryString["time_period"];
            string interval = parametro.Request.QueryString["interval"];
            string symbol = parametro.Request.QueryString["symbol"];
            string indicador = parametro.Request.QueryString["indicador"];
            string Sesiones = parametro.Request.QueryString["Sesiones"];
            int LentaFinal = int.Parse(parametro.Request.QueryString["LentaFinal"]);
            int NumPeriodo = int.Parse(time_period);

            string function = "";
            string dataListName = "";
            switch (interval)
            {
                case "1min":
                    function = "TIME_SERIES_INTRADAY";
                    dataListName = "Time Series (1min)";
                    break;
                case "5min":
                    function = "TIME_SERIES_INTRADAY";
                    dataListName = "Time Series (5min)";
                    break;
                case "15min":
                    function = "TIME_SERIES_INTRADAY";
                    dataListName = "Time Series (15min)";
                    break;
                case "30min":
                    function = "TIME_SERIES_INTRADAY";
                    dataListName = "Time Series (30min)";
                    break;
                case "60min":
                    function = "TIME_SERIES_INTRADAY";
                    dataListName = "Time Series (60min)";
                    break;
                case "daily":
                    function= "TIME_SERIES_DAILY_ADJUSTED";
                    dataListName = "Time Series (Daily)";
                    break;
                case "weekly":
                    function = "TIME_SERIES_WEEKLY_ADJUSTED";
                    dataListName = "Weekly Adjusted Time Series";
                    break;
                case "monthly":
                    function = "TIME_SERIES_MONTHLY_ADJUSTED";
                    dataListName = "Monthly Adjusted Time Series";
                    break;
            }

            var countCall = 0;
            var TotalCall = LentaFinal;
            var Keys = apikey.Split('|');
            int TotalEjecutadas = 0;
            var dataTechnicaList = new List<DataTechnical>();
            DataTechnical dataTechnical = new DataTechnical();

            int EjecutarProxy = 0;
            for (var i = 0; i < Keys.Length; i++)
            {
                if (Keys[i] != "")
                {
                   
                    if (countCall <= TotalCall)
                    {
                        countCall += 1;

                        //Aquí van las ejecuciones,  esto es solo para obtener la columna de precio 
                        if(LentaFinal == 1)
                        {

                            using (WebClient webClient = new System.Net.WebClient())
                            {
                                int countTime = 0;
                                bool retry = false;
                                do
                                {
                                    retry = false;
                                    try
                                    {
                                        webClient.Encoding = Encoding.UTF8;
                                        webClient.Encoding = UTF8Encoding.UTF8;
                                        webClient.Headers.Add("Content-Type", "application/json");

                                        ProxyAdd(EjecutarProxy, webClient);
                                        var json = "";
                                        if (interval.Equals("daily"))
                                             json = webClient.DownloadString("https://www.alphavantage.co/query?function="+ function +"&symbol="+ symbol  + "&outputsize=full&apikey=" + Keys[i] + "");
                                        else if (interval.Contains("min"))
                                            json = webClient.DownloadString("https://www.alphavantage.co/query?function=" + function + "&symbol=" + symbol + "&interval="+ interval +"&outputsize=full&apikey=" + Keys[i] + "");
                                        else 
                                             json = webClient.DownloadString("https://www.alphavantage.co/query?function="+ function + "&symbol="+ symbol  + "&apikey="+ Keys[i] + "");

                                        JObject Search = JObject.Parse(json);

                                        IList<JToken> results = Search[dataListName].ToList();
                                        

                                        int count = 1;
                                        foreach (JToken result in results)
                                        {
                                            dataTechnical.Name = ((Newtonsoft.Json.Linq.JProperty)result).Name.ToString();

                                            JObject RowsTable = JObject.Parse(((Newtonsoft.Json.Linq.JProperty)result).Value.ToString());
                                            foreach (KeyValuePair<string, JToken> property in RowsTable)
                                            {
                                                if( property.Key.Contains(series_type))
                                                {
                                                    dataTechnical.Value = property.Value.ToString();
                                                    break;
                                                }
                                                   
                                            }

                                            dataTechnical.count = count;
                                            dataTechnicaList.Add(new DataTechnical
                                            {

                                                Name = dataTechnical.Name,
                                                Value = dataTechnical.Value,
                                                count = dataTechnical.count

                                            });

                                            count += 1;

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        if (countTime < 300)
                                        {
                                            retry = true;
                                            EjecutarProxy += 1;
                                            if (EjecutarProxy >= 3)
                                            {
                                                Thread.Sleep(7000);
                                                EjecutarProxy = 1;
                                            }

                                            countTime++;
                                        }
                                        else
                                        {
                                            throw ex;
                                        }
                                    }
                                } while (retry);


                            }


                        }
                        else
                        {
                            using (WebClient webClient = new System.Net.WebClient())
                            {
                                int countTime = 0;
                                bool retry = false;
                                do
                                {
                                    retry = false;
                                    try
                                    {
                                        webClient.Encoding = Encoding.UTF8;
                                        webClient.Encoding = UTF8Encoding.UTF8;
                                        webClient.Headers.Add("Content-Type", "application/json");

                                        ProxyAdd(EjecutarProxy, webClient);

                                        var json = webClient.DownloadString("https://www.alphavantage.co/query?function=" + indicador + "&symbol=" + symbol + "&interval=" + interval + "&time_period=" + NumPeriodo + "&series_type=" + series_type + "&apikey=" + Keys[i] + "");
                                        JObject Search = JObject.Parse(json);

                                        IList<JToken> results = Search["Technical Analysis: " + indicador + ""].ToList();
                                        EjecutarProxy++;

                                        int count = 1;
                                        foreach (JToken result in results)
                                        {
                                            dataTechnical.Name = ((Newtonsoft.Json.Linq.JProperty)result).Name.ToString();

                                            JObject RowsTable = JObject.Parse(((Newtonsoft.Json.Linq.JProperty)result).Value.ToString());
                                            foreach (KeyValuePair<string, JToken> property in RowsTable)
                                            {
                                                dataTechnical.Value = property.Value.ToString();
                                            }

                                            dataTechnical.count = count;
                                            dataTechnicaList.Add(new DataTechnical
                                            {

                                                Name = dataTechnical.Name,
                                                Value = dataTechnical.Value,
                                                count = dataTechnical.count

                                            });

                                            count += 1;

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        if (countTime < 300)
                                        {
                                            retry = true;
                                            EjecutarProxy++;
                                            if (EjecutarProxy >= 66)
                                            {
                                                Thread.Sleep(7000);
                                                EjecutarProxy = 1;
                                            }

                                            countTime++;
                                        }
                                        else
                                        {
                                            throw ex;
                                        }
                                    }
                                } while (retry);


                            }

                        }


                        
                        TotalEjecutadas = i + 1;
                        if (TotalEjecutadas == Keys.Length && countCall < TotalCall)
                            i = 0;

                    }
                    else
                    {
                        break;
                    }


                }

                TotalEjecutadas = i + 1;
                if (TotalEjecutadas == Keys.Length && countCall < TotalCall)
                    i = 0;
            }

            

            var filteredList = from dta in dataTechnicaList
                               where dta.count <= int.Parse(Sesiones)  //solo datos menores a la sesiones (número de registros a analizar)
                               select dta;

            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(filteredList));

        }


        public void DataTechnicalExcel(IEnumerable<DataTechnical> dataTechnicals, HttpContext context)
        {


            ExcelPackage excel = new ExcelPackage();           
            var workSheet = excel.Workbook.Worksheets.Add("TechnicalAnalysis");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;           
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;            
            workSheet.Cells[1, 1].Value = "Fecha";
            workSheet.Cells[2, 1].Value = "DateTimeValue";
            for (int i = 2; i <= 60; i++)
            {

                workSheet.Cells[1, 2].Value = "2";
                workSheet.Cells[1, 3].Value = "3";
                workSheet.Cells[1, 4].Value = "4";
            }

            int recordIndex = 2;

            foreach (var data in dataTechnicals)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = data.Name;
                workSheet.Cells[recordIndex, 3].Value = data.Value;
                recordIndex++;
            }

          
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();          
            string p_strPath = context.Server.MapPath("DadaExcel/TechnicalAnalysis.xlsx").ToString();
            if (File.Exists(p_strPath))
                File.Delete(p_strPath);
 
            FileStream objFileStrm = File.Create(p_strPath);
            objFileStrm.Close();
              
            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            
            excel.Dispose();
        }


        public void ProxyAdd(int EjecutarProxy, WebClient webClient)
        {
            //Ejecutan individualmente
            if (EjecutarProxy == 1)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_ddc5b127-zone-zone1", "dz4p6fkcofc7");

            }

            if (EjecutarProxy == 2)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_ddc5b127-zone-zone2", "1bnsxgqm49nv");
            }

            if (EjecutarProxy == 3)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_ddc5b127-zone-zone3", "w02nnb9t2vsg");
            }

            //if (EjecutarProxy == 4)
            //{

            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-fr", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 5)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-de", "8jcnmagkxr9x");

            //}


            //if (EjecutarProxy == 6)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-co", "8jcnmagkxr9x");
            //}

            //if (EjecutarProxy == 7)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-country-it", "hm0pssiuy51s");
            //}

            //if (EjecutarProxy == 8)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-ar", "950qr9c3oy74");

            //}

            //if (EjecutarProxy == 9)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-bg", "950qr9c3oy74");
            //}

            //if (EjecutarProxy == 10)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
            //}

            //if (EjecutarProxy == 11)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block", "950qr9c3oy74");
            //}

            //if (EjecutarProxy == 12)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block", "8jcnmagkxr9x");
            //}

            //if (EjecutarProxy == 13)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block-country-us", "8jcnmagkxr9x");

            //}

            //if (EjecutarProxy == 14)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block-country-ie", "950qr9c3oy74");
            //}

            //if (EjecutarProxy == 15)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 16)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
            //}


            //if (EjecutarProxy == 18)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-route_err-block", "hm0pssiuy51s");
            //}

            //if (EjecutarProxy == 19)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 20)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

            //}

            //if (EjecutarProxy == 21)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

            //}

            //if (EjecutarProxy == 22)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4", "dkynyah79ep4");
            //}

            //if (EjecutarProxy == 23)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-gb", "dkynyah79ep4");
            //}

            //if (EjecutarProxy == 24)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-us", "dkynyah79ep4");
            //}

            //if (EjecutarProxy == 25)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-al", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 26)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-au", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 27)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-eg", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 28)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-fi", "dkynyah79ep4");
            //}

            //if (EjecutarProxy == 29)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5", "ihz4r4y1afpi");
            //}

            //if (EjecutarProxy == 30)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-cn", "ihz4r4y1afpi");
            //}

            //if (EjecutarProxy == 31)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-in", "ihz4r4y1afpi");
            //}

            //if (EjecutarProxy == 32)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-in", "nk9fkr5guhqo");
            //}

            //if (EjecutarProxy == 33)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-id", "nk9fkr5guhqo");
            //}


            //if (EjecutarProxy == 33)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-au", "nk9fkr5guhqo");
            //}

            //if (EjecutarProxy == 33)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-ar", "nk9fkr5guhqo");
            //}

            //if (EjecutarProxy == 34)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-uz", "nk9fkr5guhqo");
            //}

            //if (EjecutarProxy == 35)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-uz", "hmgkn0ztpad0");
            //}


            ////******************************************************************************************
            //if (EjecutarProxy == 36)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

            //}

            //if (EjecutarProxy == 37)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
            //}

            //if (EjecutarProxy == 38)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
            //}

            //if (EjecutarProxy == 39)
            //{

            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-fr", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 40)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-de", "8jcnmagkxr9x");

            //}


            //if (EjecutarProxy == 41)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-co", "8jcnmagkxr9x");
            //}

            //if (EjecutarProxy == 42)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-country-it", "hm0pssiuy51s");
            //}

            //if (EjecutarProxy == 43)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-ar", "950qr9c3oy74");

            //}

            //if (EjecutarProxy == 44)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-bg", "950qr9c3oy74");
            //}

            //if (EjecutarProxy == 45)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
            //}

            //if (EjecutarProxy == 46)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block", "950qr9c3oy74");
            //}

            //if (EjecutarProxy == 47)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block", "8jcnmagkxr9x");
            //}

            //if (EjecutarProxy == 48)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block-country-us", "8jcnmagkxr9x");

            //}

            //if (EjecutarProxy == 49)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block-country-ie", "950qr9c3oy74");
            //}

            //if (EjecutarProxy == 50)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 51)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
            //}


            //if (EjecutarProxy == 52)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-route_err-block", "hm0pssiuy51s");
            //}

            //if (EjecutarProxy == 53)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 54)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

            //}

            //if (EjecutarProxy == 55)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

            //}

            //if (EjecutarProxy == 56)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4", "dkynyah79ep4");
            //}

            //if (EjecutarProxy == 57)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-gb", "dkynyah79ep4");
            //}

            //if (EjecutarProxy == 58)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-us", "dkynyah79ep4");
            //}

            //if (EjecutarProxy == 59)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-al", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 60)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-au", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 61)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-eg", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 62)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-fi", "dkynyah79ep4");
            //}

            //if (EjecutarProxy == 63)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5", "ihz4r4y1afpi");
            //}

            //if (EjecutarProxy == 64)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-cn", "ihz4r4y1afpi");
            //}

            //if (EjecutarProxy == 65)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-in", "ihz4r4y1afpi");
            //}

            //if (EjecutarProxy == 66)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-in", "nk9fkr5guhqo");
            //}

            //if (EjecutarProxy == 67)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 68)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
            //}

            //if (EjecutarProxy == 69)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
            //}

            //if (EjecutarProxy == 70)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
            //}

            //if (EjecutarProxy == 71)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
            //}

            //if (EjecutarProxy == 72)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
            //}

            //if (EjecutarProxy == 74)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
            //}

            //if (EjecutarProxy == 75)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8-route_err-block", "hoa63y623ppr");
            //}

            //if (EjecutarProxy == 76)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 77)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            //}

            //if (EjecutarProxy == 78)
            //{
            //    webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
            //    webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            //}

        }
       

        public class DataTechnical
        {
            public  string Name { get; set; }
            public string Value { get; set; }
            public int count { get; set; }
        }



        public class ExcelData
        {
            public string Col1 { get; set; }
            public string Col2 { get; set; }
            public string Col3 { get; set; }
            public string Col4 { get; set; }
            public string Col5 { get; set; }


            public string Col6 { get; set; }
            public string Col7 { get; set; }
            public string Col8 { get; set; }
            public string Col9 { get; set; }
            public string Col10 { get; set; }

            public string Col11 { get; set; }
            public string Col12 { get; set; }
            public string Col13 { get; set; }
            public string Col14 { get; set; }
            public string Col15 { get; set; }

            public string Col16 { get; set; }
            public string Col17 { get; set; }
            public string Col18 { get; set; }
            public string Col19 { get; set; }
            public string Col20 { get; set; }

            public string Col21 { get; set; }
            public string Col22 { get; set; }
            public string Col23 { get; set; }
            public string Col24 { get; set; }
            public string Col25 { get; set; }


            public string Col26 { get; set; }
            public string Col27 { get; set; }
            public string Col28 { get; set; }
            public string Col29 { get; set; }
            public string Col30 { get; set; }


            public string Col31 { get; set; }
            public string Col32 { get; set; }
            public string Col33 { get; set; }
            public string Col34 { get; set; }
            public string Col35 { get; set; }


            public string Col36 { get; set; }
            public string Col37 { get; set; }
            public string Col38 { get; set; }
            public string Col39 { get; set; }
            public string Col40 { get; set; }

            public string Col41 { get; set; }
            public string Col42 { get; set; }
            public string Col43 { get; set; }
            public string Col44 { get; set; }
            public string Col45 { get; set; }


            public string Col46 { get; set; }
            public string Col47 { get; set; }
            public string Col48 { get; set; }
            public string Col49 { get; set; }
            public string Col50 { get; set; }

            public string Col51 { get; set; }
            public string Col52 { get; set; }
            public string Col53 { get; set; }
            public string Col54 { get; set; }
            public string Col55 { get; set; }


            public string Col56 { get; set; }
            public string Col57 { get; set; }
            public string Col58 { get; set; }
            public string Col59 { get; set; }
            public string Col60 { get; set; }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}