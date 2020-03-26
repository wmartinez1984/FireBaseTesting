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
        }
        public string TechnicalAnalysisListExcel(HttpContext Context)
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
                            workSheet.Column(Columna).AutoFit();
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
                int ColumInicial = 1;
                for (int s = RapidaInicial; s <= RapidaFinal; s++)
                {
                    int LentaInicialRows = LentaInicial;
                    for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                    {
                        SenalSheet1.Cells[1, c].Value = "Señal (" + s + ", " + LentaInicialRows + ") ";

                        //Primera fila por default
                        SenalSheet1.Cells[2, c].Value = "SELL ( " + s + " = " + decimal.Parse(workSheet.Cells[2, s + 1].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[2, LentaInicialRows + 1].Value + ")";
                        SenalSheet1.Row(2).Style.Font.Bold = true;
                        SenalSheet1.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //Señales por columna
                        for (int f = 3; f <= int.Parse(Sesiones); f++)
                        {
                            if (workSheet.Cells[f, s + 1].Value != null && workSheet.Cells[s, LentaInicialRows + 1].Value != null)
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

                                //SenalSheet1.Cells[f, c].Value = "SELL.." + workSheet.Cells[f, s].Value + ":"+ workSheet.Cells[f, LentaInicialRows].Value;
                                SenalSheet1.Cells[f, c].Value = "" + strSenal + " ( " + s + " = " + decimal.Parse(workSheet.Cells[f, s + 1].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[f, LentaInicialRows + 1].Value + ")";
                            }


                        }

                        //última fila por default
                        SenalSheet1.Cells[int.Parse(Sesiones) + 1, c].Value = "NEUTRO ( " + s + " = " + decimal.Parse(workSheet.Cells[int.Parse(Sesiones) + 1, s + 1].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[int.Parse(Sesiones) + 1, LentaInicialRows + 1].Value + ")";
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


                //Cant.Acciones, Capital.Neto, Ganancia.OP
                ColumInicial = 1;
                for (int s = RapidaInicial; s <= RapidaFinal; s++)
                {
                    for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                    {
                        decimal Acciones = 0;
                        decimal Capitalneto = CapitalInicial;
                        decimal Ganancia = 0;
                        decimal PrecioActual = 0;
                        string texttoValoresAdicionales = "";
                        //ÚLTIMA LÍNEA...
                        PrecioActual = decimal.Parse(workSheet.Cells[2, 2].Value.ToString());
                        texttoValoresAdicionales = ", Precio = " + PrecioActual + ", Cant.Acciones = " + Acciones + ", Capital.Neto = " + Capitalneto + ", Ganancia.OP = " + Ganancia + " ";
                        SenalSheet1.Cells[int.Parse(Sesiones) + 1, c].Value = SenalSheet1.Cells[int.Parse(Sesiones) + 1, c].Value + texttoValoresAdicionales;

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
                            }

                            texttoValoresAdicionales = ", Precio = " + PrecioActual + ", Cant.Acciones = " + Decimal.Round(Acciones, 5) + ", Capital.Neto = " + Decimal.Round(Capitalneto, 5) + ", Ganancia.OP = " + Ganancia + " ";

                            SenalSheet1.Cells[f, c].Value = SenalSheet1.Cells[f, c].Value + texttoValoresAdicionales;

                            SenalSheet1.Row(f).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            SenalSheet1.Row(f).Style.Font.Size = 12;
                            SenalSheet1.Column(c).AutoFit();
                        }



                    }

                    ColumInicial += (LentaFinal - LentaInicial) + 1;
                }




            }
            catch(Exception ex)
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

            int EjecutarProxy = 1;
            for (var i = 0; i < Keys.Length; i++)
            {
                if (Keys[i] != "")
                {
                   
                    if (countCall <= TotalCall)
                    {
                        countCall += 1;

                        //Aquí van las ejecuciones 
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
                                        else
                                             json = webClient.DownloadString("https://www.alphavantage.co/query?function="+ function + "&symbol="+ symbol  + "&apikey="+ Keys[i] + "");

                                        JObject Search = JObject.Parse(json);

                                        IList<JToken> results = Search[dataListName].ToList();
                                        EjecutarProxy++;

                                        int count = 1;
                                        foreach (JToken result in results)
                                        {
                                            dataTechnical.Name = ((Newtonsoft.Json.Linq.JProperty)result).Name.ToString();

                                            JObject RowsTable = JObject.Parse(((Newtonsoft.Json.Linq.JProperty)result).Value.ToString());
                                            foreach (KeyValuePair<string, JToken> property in RowsTable)
                                            {
                                                if( property.Key.Contains(series_type))
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
                                                Thread.Sleep(3000);
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
                                                Thread.Sleep(3000);
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
                               where dta.count <= int.Parse(Sesiones)  //solo datos menores a la sessiones (número de registros a analizar)
                               select dta;

            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(filteredList));

        }

        public void ProxyAdd(int EjecutarProxy, WebClient webClient)
        {
            //Ejecutan individualmente
            if (EjecutarProxy == 1)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

            }

            if (EjecutarProxy == 2)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
            }

            if (EjecutarProxy == 3)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
            }

            if (EjecutarProxy == 4)
            {

                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-fr", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 5)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-de", "8jcnmagkxr9x");

            }


            if (EjecutarProxy == 6)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-co", "8jcnmagkxr9x");
            }

            if (EjecutarProxy == 7)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-country-it", "hm0pssiuy51s");
            }

            if (EjecutarProxy == 8)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-ar", "950qr9c3oy74");

            }

            if (EjecutarProxy == 9)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-bg", "950qr9c3oy74");
            }

            if (EjecutarProxy == 10)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
            }

            if (EjecutarProxy == 11)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block", "950qr9c3oy74");
            }

            if (EjecutarProxy == 12)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block", "8jcnmagkxr9x");
            }

            if (EjecutarProxy == 13)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block-country-us", "8jcnmagkxr9x");

            }

            if (EjecutarProxy == 14)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block-country-ie", "950qr9c3oy74");
            }

            if (EjecutarProxy == 15)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 16)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
            }


            if (EjecutarProxy == 18)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-route_err-block", "hm0pssiuy51s");
            }

            if (EjecutarProxy == 19)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 20)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

            }

            if (EjecutarProxy == 21)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

            }

            if (EjecutarProxy == 22)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4", "dkynyah79ep4");
            }

            if (EjecutarProxy == 23)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-gb", "dkynyah79ep4");
            }

            if (EjecutarProxy == 24)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-us", "dkynyah79ep4");
            }

            if (EjecutarProxy == 25)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-al", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 26)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-au", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 27)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-eg", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 28)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-fi", "dkynyah79ep4");
            }

            if (EjecutarProxy == 29)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5", "ihz4r4y1afpi");
            }

            if (EjecutarProxy == 30)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-cn", "ihz4r4y1afpi");
            }

            if (EjecutarProxy == 31)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-in", "ihz4r4y1afpi");
            }

            if (EjecutarProxy == 32)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-in", "nk9fkr5guhqo");
            }

            if (EjecutarProxy == 33)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-id", "nk9fkr5guhqo");
            }


            if (EjecutarProxy == 33)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-au", "nk9fkr5guhqo");
            }

            if (EjecutarProxy == 33)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-ar", "nk9fkr5guhqo");
            }

            if (EjecutarProxy == 34)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-uz", "nk9fkr5guhqo");
            }

            if (EjecutarProxy == 35)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-uz", "hmgkn0ztpad0");
            }


            //******************************************************************************************
            if (EjecutarProxy == 36)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

            }

            if (EjecutarProxy == 37)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
            }

            if (EjecutarProxy == 38)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
            }

            if (EjecutarProxy == 39)
            {

                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-fr", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 40)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-de", "8jcnmagkxr9x");

            }


            if (EjecutarProxy == 41)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-co", "8jcnmagkxr9x");
            }

            if (EjecutarProxy == 42)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-country-it", "hm0pssiuy51s");
            }

            if (EjecutarProxy == 43)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-ar", "950qr9c3oy74");

            }

            if (EjecutarProxy == 44)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-bg", "950qr9c3oy74");
            }

            if (EjecutarProxy == 45)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
            }

            if (EjecutarProxy == 46)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block", "950qr9c3oy74");
            }

            if (EjecutarProxy == 47)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block", "8jcnmagkxr9x");
            }

            if (EjecutarProxy == 48)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block-country-us", "8jcnmagkxr9x");

            }

            if (EjecutarProxy == 49)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block-country-ie", "950qr9c3oy74");
            }

            if (EjecutarProxy == 50)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 51)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
            }


            if (EjecutarProxy == 52)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-route_err-block", "hm0pssiuy51s");
            }

            if (EjecutarProxy == 53)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 54)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

            }

            if (EjecutarProxy == 55)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

            }

            if (EjecutarProxy == 56)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4", "dkynyah79ep4");
            }

            if (EjecutarProxy == 57)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-gb", "dkynyah79ep4");
            }

            if (EjecutarProxy == 58)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-us", "dkynyah79ep4");
            }

            if (EjecutarProxy == 59)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-al", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 60)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-au", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 61)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-eg", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 62)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-fi", "dkynyah79ep4");
            }

            if (EjecutarProxy == 63)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5", "ihz4r4y1afpi");
            }

            if (EjecutarProxy == 64)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-cn", "ihz4r4y1afpi");
            }

            if (EjecutarProxy == 65)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-in", "ihz4r4y1afpi");
            }

            if (EjecutarProxy == 66)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-in", "nk9fkr5guhqo");
            }

            if (EjecutarProxy == 67)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 68)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
            }

            if (EjecutarProxy == 69)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
            }

            if (EjecutarProxy == 70)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
            }

            if (EjecutarProxy == 71)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
            }

            if (EjecutarProxy == 72)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
            }

            if (EjecutarProxy == 74)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
            }

            if (EjecutarProxy == 75)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8-route_err-block", "hoa63y623ppr");
            }

            if (EjecutarProxy == 76)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 77)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 78)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
            }

            if (EjecutarProxy == 79)
            {
                webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-de", "8jcnmagkxr9x");

            }
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