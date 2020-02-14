using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace FireBaseTesting.ActivosFinancieros
{
    /// <summary>
    /// Descripción breve de Activos1
    /// </summary>
    public class Activos1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Action"].ToString().Equals("ActivoList"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = ActivoList(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("ActivoInsert"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = SaveActivos(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);

            }

            if (context.Request.QueryString["Action"].ToString().Equals("ActivoRegistradosList"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = ActivosRegistradosList(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("DeleteAct"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = DeleteActivo(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }
        }

        public static string DeleteActivo(HttpContext context)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            FireBaseTesting.ACTFActivosDAL activosDAL = new FireBaseTesting.ACTFActivosDAL();

            FireBaseTesting.Activos data = new FireBaseTesting.Activos();
            data.id = new Guid(context.Request.QueryString["id"]);
            activosDAL.ActivoDelete(data);
            return (serializer.Serialize("ok,ok"));
        }

        public static string ActivosRegistradosList(HttpContext context)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            FireBaseTesting.ACTFActivosDAL activos = new FireBaseTesting.ACTFActivosDAL();
            List<FireBaseTesting.Activos> list = new List<FireBaseTesting.Activos>();
            list = activos.ActivosList();

            return (serializer.Serialize(list));

        }

        public static string SaveActivos(HttpContext context)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            FireBaseTesting.Activos  activos = new FireBaseTesting.Activos();

            ACTFActivosDAL aCTFActivosDAL = new ACTFActivosDAL();
            activos.id = Guid.NewGuid();
            activos.symbol = context.Request.QueryString["symbol"];
            activos.name = context.Request.QueryString["name"];
            activos.type = context.Request.QueryString["type"];
            activos.region = context.Request.QueryString["region"];
            activos.marketOpen = context.Request.QueryString["marketOpen"];
            activos.marketClose = context.Request.QueryString["marketClose"];
            activos.timezone = context.Request.QueryString["timezone"];
            activos.currency = context.Request.QueryString["currency"];
            activos.matchScore = context.Request.QueryString["matchScore"];
            activos.creationDate = DateTime.Now;
            aCTFActivosDAL.ACTFActivosDAL_Insert(activos);

            return (serializer.Serialize("ok,ok"));
        }

        public string ActivoList(HttpContext parametro)
        {
            string keywords = parametro.Request.QueryString["keywords"];
            var activosList = new List<FireBaseTesting.Activos>();
            FireBaseTesting.Activos activos = new FireBaseTesting.Activos();
            using (WebClient webClient = new System.Net.WebClient())
            {

                webClient.Encoding = Encoding.UTF8;
                webClient.Encoding = UTF8Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/json");
                var json = webClient.DownloadString("https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=" + keywords + "&apikey=SRNXB4IHEWRLEJH7");
                JObject Search = JObject.Parse(json);                
                //IList<JToken> results = FireBaseSearch["documents"].Children()["fields"].ToList();
                IList<JToken> results = Search["bestMatches"].ToList();
                foreach (JToken result in results)
                {

                    JObject RowsTable = JObject.Parse(result.ToString());
                    foreach (KeyValuePair<string, JToken> property in RowsTable)
                    {
                        if (property.Key.Equals("1. symbol"))
                        {
                            activos.symbol = property.Value.ToString();
                        }
                        if (property.Key.Equals("2. name"))
                        {
                            activos.name = property.Value.ToString();
                        }
                        if (property.Key.Equals("3. type"))
                        {
                            activos.type = property.Value.ToString();
                        }
                        if (property.Key.Equals("4. region"))
                        {
                            activos.region = property.Value.ToString();
                        }
                        if (property.Key.Equals("5. marketOpen"))
                        {
                            activos.marketOpen = property.Value.ToString();
                        }
                        if (property.Key.Equals("6. marketClose"))
                        {
                            activos.marketClose = property.Value.ToString();
                        }
                        if (property.Key.Equals("7. timezone"))
                        {
                            activos.timezone = property.Value.ToString();
                        }
                        if (property.Key.Equals("8. currency"))
                        {
                            activos.currency = property.Value.ToString();
                        }
                        if (property.Key.Equals("9. matchScore"))
                        {
                            activos.matchScore = property.Value.ToString();
                        }

                    }

                    activosList.Add(new FireBaseTesting.Activos {
                        symbol = activos.symbol,
                        name = activos.name,
                        type = activos.type,
                        region = activos.region,
                        marketOpen = activos.marketOpen,
                        marketClose = activos.marketClose,
                        timezone = activos.timezone,
                        currency = activos.currency,
                        matchScore = activos.matchScore,
                    } );

                }
            }


            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(activosList));

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