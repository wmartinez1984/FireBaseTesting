using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

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

            int TotalPeriodo = int.Parse(time_period);
            var dataTechnicaList = new List<DataTechnical>();
            DataTechnical dataTechnical = new DataTechnical();
            
            using (WebClient webClient = new System.Net.WebClient())
            {

                webClient.Encoding = Encoding.UTF8;
                webClient.Encoding = UTF8Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/json");
                
                //IList<JToken> results = FireBaseSearch["documents"].Children()["fields"].ToList();
                //Search["Technical Analysis: "+ indicador +""].ToList();
                //Lo siguiente es para validar si no hay un error en la respuesta del api, si lo hay me espero un minuto y vuelvo a intentarlo
                int countTime = 0;
                bool retry = false;
                do
                {
                    retry = false;
                    try
                    {
                        //WebProxy wp = new WebProxy("221.141.86.43", 1080);
                        //webClient.Proxy = wp;
                     
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
                            Thread.Sleep(50000);
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


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}