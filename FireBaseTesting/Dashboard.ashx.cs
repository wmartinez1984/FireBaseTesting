using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace FireBaseTesting
{
    /// <summary>
    /// Summary description for Dashboard1
    /// </summary>
    public class Dashboard1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Action = context.Request.QueryString["action"];
            if (Action.Equals("LoadData"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = GetDataFront(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);

            }

            if (Action.Equals("LoadDataDateRange"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = GetDataFrontDateRange(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);

            }

        }

        public string GetDataFront(HttpContext parametro)
        {
            System.Collections.Generic.List<object> Rows = new System.Collections.Generic.List<object>();
            
            using (WebClient webClient = new System.Net.WebClient())
            {
              

                string latitude = "";
                string longitude = "";
                string urlFoto = "";
                string nombreTecnico = "";
                string estado = "";
                string direccion = "";
                string total = "";
                DateTime creado = DateTime.Now;

                webClient.Encoding = Encoding.UTF8;
                webClient.Encoding = UTF8Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/json");
                var json = webClient.DownloadString("https://firestore.googleapis.com/v1/projects/apptecnicos-9a471/databases/(default)/documents/prueba");
                JObject FireBaseSearch = JObject.Parse(json);
                IList<JToken> results = FireBaseSearch["documents"].Children()["fields"].ToList();

                foreach (JToken result in results)
                {

                    JObject FireBaseTable = JObject.Parse(result.ToString());
                    foreach (KeyValuePair<string, JToken> property in FireBaseTable)
                    {


                        if (property.Key.Equals("ubicacion"))
                        {
                            IList<JToken> resultsUbicacion;
                            JObject FireBaseSearchubicacion = JObject.Parse(property.Value.ToString());
                            resultsUbicacion = FireBaseSearchubicacion["mapValue"]["fields"]["latitude"].Children().ToList();
                            foreach (JToken resultU in resultsUbicacion)
                            {
                                latitude = ((Newtonsoft.Json.Linq.JProperty)resultU).Value.ToString();
                            }


                            resultsUbicacion = FireBaseSearchubicacion["mapValue"]["fields"]["longitude"].Children().ToList();
                            foreach (JToken resultU in resultsUbicacion)
                            {
                                longitude = ((Newtonsoft.Json.Linq.JProperty)resultU).Value.ToString();
                            }

                        }
                        else
                        {
                            JObject FireBaseValorCampo = JObject.Parse(property.Value.ToString());
                            foreach (KeyValuePair<string, JToken> property_ in FireBaseValorCampo)
                            {

                                if (property.Key.Equals("creado"))
                                {
                                    creado = DateTimeOffset.Parse(property_.Value.ToString()).UtcDateTime;
                                }
                                
                                if (property.Key.Equals("urlFoto"))
                                {
                                    urlFoto = property_.Value.ToString();
                                }
                                if (property.Key.Equals("nombreTecnico"))
                                {
                                    nombreTecnico = property_.Value.ToString();
                                }
                                if (property.Key.Equals("estado"))
                                {
                                    estado = property_.Value.ToString();
                                }
                                if (property.Key.Equals("direccion"))
                                {
                                    direccion = property_.Value.ToString();
                                }
                                if (property.Key.Equals("total"))
                                {
                                    total = property_.Value.ToString();
                                }

                                
                            }
                        }

                    }
                
                    if (creado >= DateTime.Now.AddMonths(-1))
                    {
                    
                        Rows.Add(new
                        {
                            latitude = latitude,
                            longitude = longitude,
                            estado = estado,
                            urlFoto = urlFoto,
                            direccion = direccion,
                            total = total,
                            nombreTecnico = nombreTecnico,
                            creado = creado.ToString(),
                        });

                    }
                }


            }
            
            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Rows));

        }

        public string GetDataFrontDateRange(HttpContext parametro)
        {

            DateTime creadoStart;
            DateTime creadoEnd;
            try
            {
                creadoStart = DateTime.Parse(parametro.Request.QueryString["startDate"].ToString());
                creadoEnd = DateTime.Parse(parametro.Request.QueryString["EndDate"].ToString());
            }
            catch
            {
                creadoStart = DateTime.Parse("07/01/2020");
                creadoEnd = DateTime.Parse("23/01/2020");
            }

            System.Collections.Generic.List<object> Rows = new System.Collections.Generic.List<object>();           
           using (WebClient webClient = new System.Net.WebClient())
            {
                
                string latitude = "";
                string longitude = "";
                string urlFoto = "";
                string nombreTecnico = "";
                string estado = "";
                string direccion = "";
                string total = "";
                DateTime creado = DateTime.Now;

                webClient.Encoding = Encoding.UTF8;
                webClient.Encoding = UTF8Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/json");
                var json = webClient.DownloadString("https://firestore.googleapis.com/v1/projects/apptecnicos-9a471/databases/(default)/documents/prueba");
                JObject FireBaseSearch = JObject.Parse(json);
                IList<JToken> results = FireBaseSearch["documents"].Children()["fields"].ToList();

                foreach (JToken result in results)
                {

                    JObject FireBaseTable = JObject.Parse(result.ToString());
                    foreach (KeyValuePair<string, JToken> property in FireBaseTable)
                    {


                        if (property.Key.Equals("ubicacion"))
                        {
                            IList<JToken> resultsUbicacion;
                            JObject FireBaseSearchubicacion = JObject.Parse(property.Value.ToString());
                            resultsUbicacion = FireBaseSearchubicacion["mapValue"]["fields"]["latitude"].Children().ToList();
                            foreach (JToken resultU in resultsUbicacion)
                            {
                                latitude = ((Newtonsoft.Json.Linq.JProperty)resultU).Value.ToString();
                            }


                            resultsUbicacion = FireBaseSearchubicacion["mapValue"]["fields"]["longitude"].Children().ToList();
                            foreach (JToken resultU in resultsUbicacion)
                            {
                                longitude = ((Newtonsoft.Json.Linq.JProperty)resultU).Value.ToString();
                            }

                        }
                        else
                        {
                            JObject FireBaseValorCampo = JObject.Parse(property.Value.ToString());
                            foreach (KeyValuePair<string, JToken> property_ in FireBaseValorCampo)
                            {

                                if (property.Key.Equals("creado"))
                                {
                                    creado = DateTimeOffset.Parse(property_.Value.ToString()).UtcDateTime;
                                }

                                if (property.Key.Equals("urlFoto"))
                                {
                                    urlFoto = property_.Value.ToString();
                                }
                                if (property.Key.Equals("nombreTecnico"))
                                {
                                    nombreTecnico = property_.Value.ToString();
                                }
                                if (property.Key.Equals("estado"))
                                {
                                    estado = property_.Value.ToString();
                                }
                                if (property.Key.Equals("direccion"))
                                {
                                    direccion = property_.Value.ToString();
                                }
                                if (property.Key.Equals("total"))
                                {
                                    total = property_.Value.ToString();
                                }


                            }
                        }

                    }

                    if (creado >= creadoStart.AddDays(-1) && creado <= creadoEnd.AddDays(1))
                    {

                        Rows.Add(new
                        {
                            latitude = latitude,
                            longitude = longitude,
                            estado = estado,
                            urlFoto = urlFoto,
                            direccion = direccion,
                            total = total,
                            nombreTecnico = nombreTecnico,
                            creado = creado.ToString(),
                        });


                    }
                }


            }

            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Rows));

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