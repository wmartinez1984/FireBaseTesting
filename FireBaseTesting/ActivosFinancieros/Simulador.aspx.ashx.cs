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

            int NumPeriodo = int.Parse(time_period);

            var dataTechnicaList = new List<DataTechnical>();
            DataTechnical dataTechnical = new DataTechnical();
            
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
                        if (NumPeriodo > 8 && NumPeriodo <= 16)
                        {
                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

                        }

                        if (NumPeriodo > 16 && NumPeriodo <= 24)
                        {
                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
                        }

                        if (NumPeriodo > 24 && NumPeriodo <= 32)
                        {
                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
                        }

                        if (NumPeriodo > 32 && NumPeriodo <= 40)
                        {
                           
                        }

                        if (NumPeriodo > 40 && NumPeriodo <= 48)
                        {
                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

                        }


                        if (NumPeriodo > 48 && NumPeriodo <= 56)
                        {
                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
                        }

                        if (NumPeriodo > 56 )
                        {
                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
                        }


                        var json = webClient.DownloadString("https://www.alphavantage.co/query?function=" + indicador + "&symbol=" + symbol + "&interval=" + interval + "&time_period=" + time_period + "&series_type=" + series_type + "&apikey=" + apikey + "");
                        JObject Search = JObject.Parse(json);

                        IList<JToken> results = Search["Technical Analysis: " + indicador + ""].ToList();
                        
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

            var filteredList = from dta in dataTechnicaList
                               where dta.count <= int.Parse(Sesiones)  //solo datos menores a la sessiones (número de registros a analizar)
                               select dta;

            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(filteredList));

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}