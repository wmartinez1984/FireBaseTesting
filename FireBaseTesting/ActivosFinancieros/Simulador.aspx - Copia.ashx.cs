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

namespace FireBaseTesting.ActivosFinancieros
{
    /// <summary>
    /// Descripción breve de Simulador_aspx
    /// </summary>
    public class Simulador_aspxv2 : IHttpHandler
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

            int RapidaInicial = int.Parse( parametro.Request.QueryString["RapidaInicial"]);
            int RapidaFinal = int.Parse( parametro.Request.QueryString["RapidaFinal"]);
            int LentaInicial = int.Parse( parametro.Request.QueryString["LentaInicial"]);
            int LentaFinal = int.Parse( parametro.Request.QueryString["LentaFinal"]);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("TechnicalAnalysis");
            var SenalSheet1 = excel.Workbook.Worksheets.Add("Señales"); //Pestaña de señales

            // setting the properties 
            // of the work sheet  
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            SenalSheet1.TabColor = System.Drawing.Color.Brown;
            SenalSheet1.DefaultRowHeight = 12;

            // Setting the properties 
            // of the first row 
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            SenalSheet1.Row(1).Height = 30;
            SenalSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            SenalSheet1.Row(1).Style.Font.Bold = true;

            // Header of the Excel sheet 
            workSheet.Cells[1, 1].Value = "Fecha";
            //Creamos 59 columnas más, en total 60
            for (int i = 2; i <= LentaFinal; i++)
            {
                workSheet.Cells[1, i].Value = i.ToString();
            }


            int NumPeriodo = int.Parse(time_period);

            var countCall = 0;
            var TotalCall = LentaFinal;
            var Keys = apikey.Split('|');
            int TotalEjecutadas = 0;
            var dataTechnicaList = new List<DataTechnical>();
            DataTechnical dataTechnical = new DataTechnical();
        try
        {
            for (var i = 0; i < Keys.Length; i++)
            {
                if (Keys[i] != "")
                {
                    countCall += 1;
                    if (countCall < TotalCall)
                    {

                        //Aquí van las ejecuciones 

                       

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

                                    //si es menor a 8 se ejecuta normal, sin proxy 
                                    if (NumPeriodo > 5 && NumPeriodo <= 10)
                                    {
                                        webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                        webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

                                    }

                                    if (NumPeriodo > 10 && NumPeriodo <= 15)
                                    {
                                        webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                        webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
                                    }

                                    if (NumPeriodo > 15 && NumPeriodo <= 20)
                                    {
                                        webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                        webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
                                    }

                                    if (NumPeriodo > 20 && NumPeriodo <= 25)
                                    {

                                    }

                                    if (NumPeriodo > 25 && NumPeriodo <=  30)
                                    {
                                        webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                        webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

                                    }


                                    if (NumPeriodo > 35 && NumPeriodo <= 40)
                                    {
                                        webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                        webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
                                    }

                                    if (NumPeriodo > 40 && NumPeriodo <= 45)
                                    {
                                        webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                        webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
                                    }

                                    if (NumPeriodo > 45 && NumPeriodo <= 50)
                                    {
                                        webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                        webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

                                    }

                                    if (NumPeriodo > 50 && NumPeriodo <= 55)
                                    {
                                        webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                        webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
                                    }

                                    var json = webClient.DownloadString("https://www.alphavantage.co/query?function=" + indicador + "&symbol=" + symbol + "&interval=" + interval + "&time_period=" + NumPeriodo + "&series_type=" + series_type + "&apikey=" + Keys[i] + "");
                                    JObject Search = JObject.Parse(json);

                                    IList<JToken> results = Search["Technical Analysis: " + indicador + ""].ToList();

                                    int count = 1;
                                    // Inserting the  data into excel 
                                   
                                    int recordIndex = 2;
                                    int DataCount = 0;
                                    int sessiones = 15;
                                    int sessionesCount = 0;
                                    foreach (JToken result in results)
                                    {
                                        if (count <= int.Parse(Sesiones))
                                        {

                                            dataTechnical.Name = ((Newtonsoft.Json.Linq.JProperty)result).Name.ToString();

                                            JObject RowsTable = JObject.Parse(((Newtonsoft.Json.Linq.JProperty)result).Value.ToString());
                                            foreach (KeyValuePair<string, JToken> property in RowsTable)
                                            {
                                                dataTechnical.Value = property.Value.ToString();
                                            }

                                            if(NumPeriodo ==2)//sí es la primera,lleno la columna con las fechas
                                                workSheet.Cells[recordIndex, 1].Value = dataTechnical.Name;

                                            workSheet.Cells[recordIndex, NumPeriodo].Value = dataTechnical.Value;

                                           
                                            recordIndex++;

                                            count += 1;

                                        }
                                        else
                                            break;
                                       

                                    }

                                    //ajusto la columna que llené 
                                    workSheet.Column(NumPeriodo).AutoFit();

                                }
                                catch (Exception ex)
                                {
                                    if (countTime < 100)
                                    {
                                        retry = true;
                                        Thread.Sleep(60000);
                                        countTime++;
                                    }
                                    else
                                    {
                                        throw ex;
                                    }
                                }
                            } while (retry);


                        }

                        NumPeriodo = NumPeriodo + 1;
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

                //cálculo  de  Señales
                try
                {


                    int RapidaInicialColum = RapidaInicial;
                    int ColumInicial = 1;
                    for (int s = RapidaInicial; s < RapidaFinal; s++)
                    {
                        int LentaInicialRows = LentaInicial;
                        for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                        {
                            SenalSheet1.Cells[1, c].Value = "Señal (" + s + ", " + LentaInicialRows + ") ";

                            //Primera fila por default
                            SenalSheet1.Cells[2, c].Value = "SELL ( " + s + " = " + decimal.Parse(workSheet.Cells[2, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[2, LentaInicialRows].Value + ")";
                            SenalSheet1.Row(2).Style.Font.Bold = true;
                            SenalSheet1.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            //Señales por columna
                            for (int f = 3; f <= int.Parse(Sesiones); f++)
                            {
                                if (workSheet.Cells[f, s].Value != null && workSheet.Cells[s, LentaInicialRows].Value != null)
                                {
                                    decimal C1 = decimal.Parse(workSheet.Cells[f, s].Value.ToString());
                                    decimal C2 = decimal.Parse(workSheet.Cells[f, LentaInicialRows].Value.ToString());
                                    decimal C3 = decimal.Parse(workSheet.Cells[f + 1, s].Value.ToString());
                                    decimal C4 = decimal.Parse(workSheet.Cells[f + 1, LentaInicialRows].Value.ToString());

                                    string strSenal = "";

                                    if (C1 > C2 && C4 > C3)
                                        strSenal = "BUY";
                                    else if (C1 < C2 && C3 > C4)
                                        strSenal = "SELL";
                                    else
                                        strSenal = "NEUTRO";

                                    //SenalSheet1.Cells[f, c].Value = "SELL.." + workSheet.Cells[f, s].Value + ":"+ workSheet.Cells[f, LentaInicialRows].Value;
                                    SenalSheet1.Cells[f, c].Value = "" + strSenal + " ( " + s + " = " + decimal.Parse(workSheet.Cells[f, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[f, LentaInicialRows].Value + ")";
                                }


                            }
                            //última fila por default
                            SenalSheet1.Cells[int.Parse(Sesiones) + 1, c].Value = "NEUTRO ( " + s + " = " + decimal.Parse(workSheet.Cells[int.Parse(Sesiones) + 1, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[int.Parse(Sesiones) + 1, LentaInicialRows].Value + ")";
                            SenalSheet1.Row(int.Parse(Sesiones) + 1).Style.Font.Bold = true;
                            SenalSheet1.Row(int.Parse(Sesiones) + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            LentaInicialRows += 1;
                            SenalSheet1.Row(1).Height = 30;
                            SenalSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            SenalSheet1.Row(1).Style.Font.Size = 12;
                            SenalSheet1.Row(1).Style.Font.Bold = true;
                            SenalSheet1.Column(c).AutoFit();

                        }

                        ColumInicial += (LentaFinal - LentaInicial) + 1;



                    }

                    string p_strPathLog1 = parametro.Server.MapPath("DadaExcel/log.txt").ToString();
                    if (File.Exists(p_strPathLog1))
                        File.Delete(p_strPathLog1);


                    using (StreamWriter _testData = new StreamWriter(parametro.Server.MapPath("DadaExcel/log.txt"), true))
                    {
                        _testData.WriteLine("Proceso de señales correcto + " + DateTime.Now.ToString() + "");
                    }
                }
                catch(Exception ex)
                {
                    string p_strPathLog2 = parametro.Server.MapPath("DadaExcel/log.txt").ToString();
                    if (File.Exists(p_strPathLog2))
                        File.Delete(p_strPathLog2);


                    using (StreamWriter _testData = new StreamWriter(parametro.Server.MapPath("DadaExcel/log.txt"), true))
                    {
                        _testData.WriteLine("Error señales: " + ex.ToString() + ", " + DateTime.Now.ToString() + "");
                    }
                }


            // file name with .xlsx extension  
            //string p_strPath = context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();
            string p_strPath = parametro.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();

            if (File.Exists(p_strPath))
                File.Delete(p_strPath);

            // Create excel file on physical disk  
            FileStream objFileStrm = File.Create(p_strPath);
            objFileStrm.Close();

            // Write content to excel file  
            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            //Close Excel package 
            excel.Dispose();

            string p_strPathLog = parametro.Server.MapPath("DadaExcel/log.txt").ToString();
            if (File.Exists(p_strPathLog))
                 File.Delete(p_strPathLog);

            
            using (StreamWriter _testData = new StreamWriter(parametro.Server.MapPath("DadaExcel/log.txt"), true))
            {
                _testData.WriteLine("Ha terminado el proceso correctamente + "+ DateTime.Now.ToString() +"");
            }


        }
        catch (Exception ex)
        {

                string p_strPathLog = parametro.Server.MapPath("DadaExcel/log.txt").ToString();
                if (File.Exists(p_strPathLog))
                    File.Delete(p_strPathLog);

               
                using (StreamWriter _testData = new StreamWriter(parametro.Server.MapPath("DadaExcel/log.txt"), true))
                {
                    _testData.WriteLine("Error: " + ex.ToString() +", " + DateTime.Now.ToString() + "");
                }

                dataTechnical.Name = "Error";
                dataTechnical.Value =  ex.ToString().Substring(0,20);

        }

            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dataTechnical));

        }


        public void CargarDataLocal(HttpContext context)
        {

            var ls = new List<ExcelData>();
            List<string> excelData = new List<string>();

            // if you use asp.net, get the relative path
            byte[] bin = File.ReadAllBytes(context.Server.MapPath("DadaExcel/TechnicalAnalysis.xlsx"));

            //create a new Excel package in a memorystream
            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                //loop all worksheets
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        //loop all columns in a row

                        ls.Add(new ExcelData
                        {
                            Col1 = worksheet.Cells[i,1].Value.ToString(),
                            Col2 = worksheet.Cells[i, 2].Value.ToString(),
                            Col3 = worksheet.Cells[i, 3].Value.ToString(),
                            Col4 = worksheet.Cells[i,4].Value.ToString(),
                            Col5 = worksheet.Cells[i,5].Value.ToString(),

                            Col6 = worksheet.Cells[i,6].Value.ToString(),
                            Col7 = worksheet.Cells[i,7].Value.ToString(),
                            Col8 = worksheet.Cells[i,8].Value.ToString(),
                            Col9 = worksheet.Cells[i,9].Value.ToString(),
                            Col10 = worksheet.Cells[i,10].Value.ToString(),

                            Col11 = worksheet.Cells[i,11].Value.ToString(),
                            Col12 = worksheet.Cells[i,12].Value.ToString(),
                            Col13 = worksheet.Cells[i,13].Value.ToString(),
                            Col14 = worksheet.Cells[i,14].Value.ToString(),
                            Col15 = worksheet.Cells[i,15].Value.ToString(),

                            Col16 = worksheet.Cells[i,16].Value.ToString(),
                            Col17 = worksheet.Cells[i,17].Value.ToString(),
                            Col18 = worksheet.Cells[i,18].Value.ToString(),
                            Col19 = worksheet.Cells[i,19].Value.ToString(),
                            Col20 = worksheet.Cells[i,20].Value.ToString(),

                            Col21 = worksheet.Cells[i,21].Value.ToString(),
                            Col22 = worksheet.Cells[i,22].Value.ToString(),
                            Col23 = worksheet.Cells[i,23].Value.ToString(),
                            Col24 = worksheet.Cells[i,24].Value.ToString(),
                            Col25 = worksheet.Cells[i,25].Value.ToString(),

                            Col26 = worksheet.Cells[i,26].Value.ToString(),
                            Col27 = worksheet.Cells[i,27].Value.ToString(),
                            Col28 = worksheet.Cells[i,28].Value.ToString(),
                            Col29 = worksheet.Cells[i,29].Value.ToString(),
                            Col30 = worksheet.Cells[i,30].Value.ToString(),

                            Col31 = worksheet.Cells[i,31].Value.ToString(),
                            Col32 = worksheet.Cells[i,32].Value.ToString(),
                            Col33 = worksheet.Cells[i,33].Value.ToString(),
                            Col34 = worksheet.Cells[i,34].Value.ToString(),
                            Col35 = worksheet.Cells[i,35].Value.ToString(),


                            Col36 = worksheet.Cells[i,36].Value.ToString(),
                            Col37 = worksheet.Cells[i,37].Value.ToString(),
                            Col38 = worksheet.Cells[i,38].Value.ToString(),
                            Col39 = worksheet.Cells[i,39].Value.ToString(),
                            Col40 = worksheet.Cells[i,40].Value.ToString(),


                            Col41 = worksheet.Cells[i,41].Value.ToString(),
                            Col42 = worksheet.Cells[i,42].Value.ToString(),
                            Col43 = worksheet.Cells[i,43].Value.ToString(),
                            Col44 = worksheet.Cells[i,44].Value.ToString(),
                            Col45 = worksheet.Cells[i,45].Value.ToString(),


                            Col46 = worksheet.Cells[i,46].Value.ToString(),
                            Col47 = worksheet.Cells[i,47].Value.ToString(),
                            Col48 = worksheet.Cells[i,48].Value.ToString(),
                            Col49 = worksheet.Cells[i,49].Value.ToString(),
                            Col50 = worksheet.Cells[i,50].Value.ToString(),


                            Col51 = worksheet.Cells[i,51].Value.ToString(),
                            Col52 = worksheet.Cells[i,52].Value.ToString(),
                            Col53 = worksheet.Cells[i,53].Value.ToString(),
                            Col54 = worksheet.Cells[i,54].Value.ToString(),
                            Col55 = worksheet.Cells[i,55].Value.ToString(),

                            Col56 = worksheet.Cells[i,56].Value.ToString(),
                            Col57 = worksheet.Cells[i,57].Value.ToString(),
                            Col58 = worksheet.Cells[i,58].Value.ToString(),
                            Col59 = worksheet.Cells[i,59].Value.ToString(),
                            Col60 = worksheet.Cells[i,60].Value.ToString(),

                        });



                    }
                }
            }

            DataTechnicalExcel(ls, context);
        }

        public void DataTechnicalExcel(List<ExcelData> Data, HttpContext context)
        {

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("TechnicalAnalysis");
            var SenalSheet1 = excel.Workbook.Worksheets.Add("Señales"); //Pestaña de señales

            // setting the properties 
            // of the work sheet  
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            SenalSheet1.TabColor = System.Drawing.Color.Brown;
            SenalSheet1.DefaultRowHeight = 12;

            // Setting the properties 
            // of the first row 
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            SenalSheet1.Row(1).Height = 30;
            SenalSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            SenalSheet1.Row(1).Style.Font.Bold = true;

            // Header of the Excel sheet 
            workSheet.Cells[1, 1].Value = "Fecha";
            //Creamos 59 columnas más, en total 60
            for (int i = 2; i <= 60; i++)
            {
                workSheet.Cells[1, i].Value = i.ToString();
            }

            // Inserting the  data into excel 
            // sheet by using the for each loop 
            // As we have values to the first row  
            // we will start with second row 
            int recordIndex = 2;
            int DataCount = 0;
            int sessiones = 15;
            int sessionesCount = 0;
            foreach (var data in Data)
            {
                if (sessionesCount < (sessiones))
                {
                    if (DataCount > 0)
                    {
                        sessionesCount++;
                        workSheet.Cells[recordIndex, 1].Value = data.Col1;
                        workSheet.Cells[recordIndex, 2].Value = data.Col2;
                        workSheet.Cells[recordIndex, 3].Value = data.Col3;
                        workSheet.Cells[recordIndex, 4].Value = data.Col4;
                        workSheet.Cells[recordIndex, 5].Value = data.Col5;
                        workSheet.Cells[recordIndex, 6].Value = data.Col6;
                        workSheet.Cells[recordIndex, 7].Value = data.Col7;
                        workSheet.Cells[recordIndex, 8].Value = data.Col8;
                        workSheet.Cells[recordIndex, 9].Value = data.Col9;
                        workSheet.Cells[recordIndex, 10].Value = data.Col10;

                        workSheet.Cells[recordIndex, 11].Value = data.Col11;
                        workSheet.Cells[recordIndex, 12].Value = data.Col12;
                        workSheet.Cells[recordIndex, 13].Value = data.Col13;
                        workSheet.Cells[recordIndex, 14].Value = data.Col14;
                        workSheet.Cells[recordIndex, 15].Value = data.Col15;
                        workSheet.Cells[recordIndex, 16].Value = data.Col16;
                        workSheet.Cells[recordIndex, 17].Value = data.Col17;
                        workSheet.Cells[recordIndex, 18].Value = data.Col18;
                        workSheet.Cells[recordIndex, 19].Value = data.Col19;
                        workSheet.Cells[recordIndex, 20].Value = data.Col20;

                        workSheet.Cells[recordIndex, 21].Value = data.Col21;
                        workSheet.Cells[recordIndex, 22].Value = data.Col22;
                        workSheet.Cells[recordIndex, 23].Value = data.Col23;
                        workSheet.Cells[recordIndex, 24].Value = data.Col24;
                        workSheet.Cells[recordIndex, 25].Value = data.Col25;
                        workSheet.Cells[recordIndex, 26].Value = data.Col26;
                        workSheet.Cells[recordIndex, 27].Value = data.Col27;
                        workSheet.Cells[recordIndex, 28].Value = data.Col28;
                        workSheet.Cells[recordIndex, 29].Value = data.Col29;
                        workSheet.Cells[recordIndex, 30].Value = data.Col30;

                        workSheet.Cells[recordIndex, 31].Value = data.Col31;
                        workSheet.Cells[recordIndex, 32].Value = data.Col32;
                        workSheet.Cells[recordIndex, 33].Value = data.Col33;
                        workSheet.Cells[recordIndex, 34].Value = data.Col34;
                        workSheet.Cells[recordIndex, 35].Value = data.Col35;
                        workSheet.Cells[recordIndex, 36].Value = data.Col36;
                        workSheet.Cells[recordIndex, 37].Value = data.Col37;
                        workSheet.Cells[recordIndex, 38].Value = data.Col38;
                        workSheet.Cells[recordIndex, 39].Value = data.Col39;
                        workSheet.Cells[recordIndex, 40].Value = data.Col40;

                        workSheet.Cells[recordIndex, 41].Value = data.Col41;
                        workSheet.Cells[recordIndex, 42].Value = data.Col42;
                        workSheet.Cells[recordIndex, 43].Value = data.Col43;
                        workSheet.Cells[recordIndex, 44].Value = data.Col44;
                        workSheet.Cells[recordIndex, 45].Value = data.Col45;
                        workSheet.Cells[recordIndex, 46].Value = data.Col46;
                        workSheet.Cells[recordIndex, 47].Value = data.Col47;
                        workSheet.Cells[recordIndex, 48].Value = data.Col48;
                        workSheet.Cells[recordIndex, 49].Value = data.Col49;
                        workSheet.Cells[recordIndex, 50].Value = data.Col50;

                        workSheet.Cells[recordIndex, 51].Value = data.Col51;
                        workSheet.Cells[recordIndex, 52].Value = data.Col52;
                        workSheet.Cells[recordIndex, 53].Value = data.Col53;
                        workSheet.Cells[recordIndex, 54].Value = data.Col54;
                        workSheet.Cells[recordIndex, 55].Value = data.Col55;
                        workSheet.Cells[recordIndex, 56].Value = data.Col56;
                        workSheet.Cells[recordIndex, 57].Value = data.Col57;
                        workSheet.Cells[recordIndex, 58].Value = data.Col58;
                        workSheet.Cells[recordIndex, 59].Value = data.Col59;
                        workSheet.Cells[recordIndex, 60].Value = data.Col60;
                        recordIndex++;

                    }

                    DataCount++;
                }
            }

            // By default, the column width is not  
            // set to auto fit for the content 
            // of the range, so we are using 
            // AutoFit() method here.  
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();


            //cálculo  de  Señales
            int RapidaInicial = 2;
            int RapidaFinal = 15;
            int LentaInicial = 16;
            int LentaFinal = 60;


            int RapidaInicialColum = RapidaInicial;
            int ColumInicial = 1;
            for (int s = RapidaInicial; s <= RapidaFinal; s++)
            {
                int LentaInicialRows = LentaInicial;
                for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                {
                    SenalSheet1.Cells[1, c].Value = "Señal (" + s + ", " + LentaInicialRows + ") ";

                    //Primera fila por default
                    SenalSheet1.Cells[2, c].Value = "SELL ( " + s + " = " + decimal.Parse(workSheet.Cells[2, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[2, LentaInicialRows].Value + ")";
                    SenalSheet1.Row(2).Style.Font.Bold = true;
                    SenalSheet1.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    //Señales por columna
                    for (int f = 3; f <= sessiones; f++)
                    {
                        if (workSheet.Cells[f, s].Value != null && workSheet.Cells[s, LentaInicialRows].Value != null)
                        {
                            decimal C1 = decimal.Parse(workSheet.Cells[f, s].Value.ToString());
                            decimal C2 = decimal.Parse(workSheet.Cells[f, LentaInicialRows].Value.ToString());
                            decimal C3 = decimal.Parse(workSheet.Cells[f + 1, s].Value.ToString());
                            decimal C4 = decimal.Parse(workSheet.Cells[f + 1, LentaInicialRows].Value.ToString());

                            string strSenal = "";

                            if (C1 > C2 && C4 > C3)
                                strSenal = "BUY";
                            else if (C1 < C2 && C3 > C4)
                                strSenal = "SELL";
                            else
                                strSenal = "NEUTRO";

                            //SenalSheet1.Cells[f, c].Value = "SELL.." + workSheet.Cells[f, s].Value + ":"+ workSheet.Cells[f, LentaInicialRows].Value;
                            SenalSheet1.Cells[f, c].Value = "" + strSenal + " ( " + s + " = " + decimal.Parse(workSheet.Cells[f, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[f, LentaInicialRows].Value + ")";
                        }


                    }
                    //última fila por default
                    SenalSheet1.Cells[sessiones + 1, c].Value = "NEUTRO ( " + s + " = " + decimal.Parse(workSheet.Cells[sessiones + 1, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[sessiones + 1, LentaInicialRows].Value + ")";
                    SenalSheet1.Row(sessiones + 1).Style.Font.Bold = true;
                    SenalSheet1.Row(sessiones + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                    LentaInicialRows += 1;
                    SenalSheet1.Row(1).Height = 30;
                    SenalSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    SenalSheet1.Row(1).Style.Font.Size = 12;
                    SenalSheet1.Row(1).Style.Font.Bold = true;
                    SenalSheet1.Column(c).AutoFit();

                }

                ColumInicial += (LentaFinal - LentaInicial) + 1;



            }






            // file name with .xlsx extension  
            //string p_strPath = context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();
            string p_strPath = context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();

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


        public class DataTechnical
        {
            public  string Name { get; set; }
            public string Value { get; set; }
            public int count { get; set; }
        }

        public void DataTechnicalExcel(IEnumerable<DataTechnical> dataTechnicals, HttpContext context)
        {
           

            ExcelPackage excel = new ExcelPackage();
            // name of the sheet 
            var workSheet = excel.Workbook.Worksheets.Add("TechnicalAnalysis");

            // setting the properties 
            // of the work sheet  
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            // Setting the properties 
            // of the first row 
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            // Header of the Excel sheet 
            workSheet.Cells[1, 1].Value = "Fecha";
            workSheet.Cells[2, 1].Value = "DateTimeValue";
            for (int i = 2; i <= 60; i++)
            {
                
                workSheet.Cells[1, 2].Value = "2";
                workSheet.Cells[1, 3].Value = "3";
                workSheet.Cells[1, 4].Value = "4";
            }
            

            // Inserting the article data into excel 
            // sheet by using the for each loop 
            // As we have values to the first row  
            // we will start with second row 
            int recordIndex = 2;

            foreach (var data in dataTechnicals)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = data.Name;
                workSheet.Cells[recordIndex, 3].Value = data.Value;
                recordIndex++;
            }

            // By default, the column width is not  
            // set to auto fit for the content 
            // of the range, so we are using 
            // AutoFit() method here.  
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();

           
            // file name with .xlsx extension  
            string p_strPath = context.Server.MapPath("DadaExcel/TechnicalAnalysis.xlsx").ToString();

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