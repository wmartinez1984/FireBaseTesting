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

            if (Action.Equals("LoadDataGroupByGraf"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = GetDataFrontDateRangeGropByGraf(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);

            }

            if (Action.Equals("LoadDataGroupByGrafAll"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = GetDataFrontDataGropByGrafAll(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);

            }

            if (Action.Equals("LoadDataQualificationAll"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = GetDataFrontDataQualificationGropByGrafAll(context);
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
                decimal valor = 0;
                int puntos = 0;
                int cumplimiento = 0;
                int incumplimiento = 0;
                string cliente ="";
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
                                if (property.Key.Equals("valor"))
                                {
                                    valor = int.Parse(property_.Value.ToString());
                                }
                                if (property.Key.Equals("puntos"))
                                {
                                    puntos = int.Parse(property_.Value.ToString());
                                }
                                if (property.Key.Equals("cliente"))
                                {
                                    cliente = property_.Value.ToString();
                                }

                                if (property.Key.Equals("cumplimiento"))
                                {
                                    cumplimiento = int.Parse(property_.Value.ToString());
                                    if (cumplimiento == 0)
                                        incumplimiento = 1;
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
                            valor = valor,
                            puntos = puntos,
                            cumplimiento = cumplimiento,
                            incumplimiento = incumplimiento,
                            cliente = cliente,

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
                decimal valor = 0;
                int puntos = 0;
                int cumplimiento = 0;
                int incumplimiento = 0;
                string cliente = "";
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
                                if (property.Key.Equals("cliente"))
                                {
                                    cliente = property_.Value.ToString();
                                }

                                if (property.Key.Equals("valor"))
                                {
                                    valor = decimal.Parse( property_.Value.ToString());
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
                            valor = valor,
                            puntos = puntos,
                            cumplimiento = cumplimiento,
                            incumplimiento = incumplimiento,
                            cliente = cliente,

                        });


                    }
                }


            }

            
            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Rows));

        }

        public string GetDataFrontDateRangeGropByGraf(HttpContext parametro)
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

            var Tecnicos =  new List<Tecnico>();


            using (WebClient webClient = new System.Net.WebClient())
            {

                string latitude = "";
                string longitude = "";
                string urlFoto = "";
                string nombreTecnico = "";
                string estado = "";
                string direccion = "";
                Decimal total = 0;
                decimal valor = 0;
                int puntos = 0;
                int cumplimiento = 1;
                int incumplimiento = 0;
                string cliente = "";

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
                                    total = Decimal.Parse(property_.Value.ToString());
                                }

                                if (property.Key.Equals("cliente"))
                                {
                                    cliente = property_.Value.ToString();
                                }

                                if (property.Key.Equals("valor"))
                                {
                                    valor = Decimal.Parse(property_.Value.ToString());
                                }

                                if (property.Key.Equals("puntos"))
                                {
                                    puntos = int.Parse(property_.Value.ToString());
                                }

                                if (property.Key.Equals("cumplimiento"))
                                {
                                    cumplimiento = int.Parse(property_.Value.ToString());
                                    if (cumplimiento == 0)
                                        incumplimiento = 1;
                                }


                            }
                        }

                    }
                    
                    if (creado >= creadoStart.AddDays(-1) && creado <= creadoEnd.AddDays(1))
                    {
                        Tecnicos.Add(
                                new Tecnico {
                                    nombreTecnico = nombreTecnico,
                                    total = total,
                                    valor = valor,
                                    puntos = puntos,
                                    cumplimiento = cumplimiento,
                                    incumplimiento = incumplimiento,

                                }                              
                        );

                        
                    }
                }


            }

            var TotalesTecnicos =
                            from tecnico in Tecnicos 
                            group tecnico by tecnico.nombreTecnico into tecnicoGroup
                             
                            select new
                            {
                                NombreTecnico = tecnicoGroup.Key,
                                Puntos = tecnicoGroup.Sum(x => x.puntos),
                                Total = tecnicoGroup.Sum(x => x.total),
                                ValorCot = tecnicoGroup.Sum(x => x.valor),
                                Cumplimiento = tecnicoGroup.Sum(x => x.cumplimiento),
                                InCumplimiento = tecnicoGroup.Sum(x => x.incumplimiento),
                                CountGroup = tecnicoGroup.Count(),
                            } ;

            var sortedList = TotalesTecnicos.OrderBy(tec => tec.Puntos).ToList();
            sortedList.Sort((tec, tec2) => tec2.Puntos.CompareTo(tec.Puntos));

            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(sortedList));

        }

        public string GetDataFrontDataGropByGrafAll(HttpContext parametro)
        {
            
            var Tecnicos = new List<Tecnico>();
            using (WebClient webClient = new System.Net.WebClient())
            {

                string latitude = "";
                string longitude = "";
                string urlFoto = "";
                string nombreTecnico = "";
                string estado = "";
                string direccion = "";
                Decimal total = 0;
                decimal valor = 0;
                int puntos = 0;
                int cumplimiento = 0;
                int incumplimiento = 0;
                string cliente = "";

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
                                    total = Decimal.Parse(property_.Value.ToString());
                                }

                                if (property.Key.Equals("cliente"))
                                {
                                    cliente = property_.Value.ToString();
                                }

                                if (property.Key.Equals("valor"))
                                {
                                    valor = Decimal.Parse(property_.Value.ToString());
                                }

                                if (property.Key.Equals("puntos"))
                                {
                                    puntos = int.Parse(property_.Value.ToString());
                                }

                                if (property.Key.Equals("cumplimiento"))
                                {
                                    cumplimiento = int.Parse(property_.Value.ToString());
                                    if (cumplimiento == 0)
                                        incumplimiento = 1;
                                }
                               

                            }
                        }

                    }

                    if (creado >= DateTime.Now.AddMonths(-1))
                    {
                        Tecnicos.Add(
                                new Tecnico
                                {
                                    nombreTecnico = nombreTecnico,
                                    total = total,
                                    valor = valor,
                                    puntos = puntos,
                                    cumplimiento = cumplimiento,
                                    incumplimiento = incumplimiento,

                                }
                        );


                    }
                }


            }

            var TotalesTecnicos =
                            from tecnico in Tecnicos
                            group tecnico by tecnico.nombreTecnico into tecnicoGroup

                            select new
                            {
                                NombreTecnico = tecnicoGroup.Key,
                                Puntos = tecnicoGroup.Sum(x => x.puntos),
                                Total = tecnicoGroup.Sum(x => x.total),
                                ValorCot = tecnicoGroup.Sum(x => x.valor),
                                Cumplimiento = tecnicoGroup.Sum(x => x.cumplimiento),
                                InCumplimiento = tecnicoGroup.Sum(x => x.incumplimiento),
                                CountGroup = tecnicoGroup.Count(),
                            };

            var sortedList = TotalesTecnicos.OrderBy(tec => tec.Puntos).ToList();
            sortedList.Sort((tec, tec2) => tec2.Puntos.CompareTo(tec.Puntos));

            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(sortedList));

        }

        public string GetDataFrontDataQualificationGropByGrafAll(HttpContext parametro)
        {

            var Tecnicos = new List<Tecnico>();
            using (WebClient webClient = new System.Net.WebClient())
            {

                string tecnico = "";
                Decimal promedio = 0;      
                DateTime creado = DateTime.Now;

                webClient.Encoding = Encoding.UTF8;
                webClient.Encoding = UTF8Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/json");
                var json = webClient.DownloadString("https://firestore.googleapis.com/v1/projects/apptecnicos-9a471/databases/(default)/documents/calificacion");
                JObject FireBaseSearch = JObject.Parse(json);
                IList<JToken> results = FireBaseSearch["documents"].Children()["fields"].ToList();

                foreach (JToken result in results)
                {

                    JObject FireBaseTable = JObject.Parse(result.ToString());
                    foreach (KeyValuePair<string, JToken> property in FireBaseTable)
                    {

                        
                            JObject FireBaseValorCampo = JObject.Parse(property.Value.ToString());
                            foreach (KeyValuePair<string, JToken> property_ in FireBaseValorCampo)
                            {

                                if (property.Key.Equals("createdAt"))
                                {
                                    creado = DateTimeOffset.Parse(property_.Value.ToString()).UtcDateTime;
                                }
                                                               
                                if (property.Key.Equals("promedio"))
                                {
                                    promedio = decimal.Parse(property_.Value.ToString());
                                }

                                if (property.Key.Equals("tecnico"))
                                {
                                    tecnico = property_.Value.ToString();
                                }

                            }
                        

                    }

                    if (creado >= DateTime.Now.AddMonths(-1))
                    {
                        Tecnicos.Add(
                                new Tecnico
                                {
                                    nombreTecnico = tecnico,
                                    total = promedio,
                                  
                                }
                        );


                    }
                }


            }

            var TotalesTecnicos =
                            from tecnico in Tecnicos
                            group tecnico by tecnico.nombreTecnico into tecnicoGroup

                            select new
                            {
                                NombreTecnico = tecnicoGroup.Key,
                                Total = tecnicoGroup.Sum(x => x.total) / tecnicoGroup.Count(),
                                CountGroup = tecnicoGroup.Count(),
                            };

            var sortedList = TotalesTecnicos.OrderBy(tec => tec.Total).ToList();
            sortedList.Sort((tec, tec2) => tec2.Total.CompareTo(tec.Total));

            return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(sortedList));

        }


        public class Tecnico
        {

            public string latitude { get; set; }
            public string longitude { get; set; }
            public string urlFoto { get; set; }
            public string nombreTecnico { get; set; }
            public string estado { get; set; }
            public string direccion { get; set; }
            public Decimal total { get; set; }
            public decimal valor { get; set; }
            public int puntos { get; set; }
            public int cumplimiento { get; set; }
            public int incumplimiento { get; set; }
            public string cliente { get; set; }
            public DateTime creado { get; set; }
            public int CountGroup { get; set; }
        };


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}