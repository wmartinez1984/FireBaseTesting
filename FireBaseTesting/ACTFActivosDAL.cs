using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FireBaseTesting
{


    public class ACTFActivosDAL
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "iBcbS7xIoCfCEj2lc8mAdFBNV4ZqqS599tMOVdCQ",
            BasePath = "https://fruselvaclient.firebaseio.com/",
        };

        IFirebaseClient client;
        public void ACTFActivosDAL_Insert(Activos activos)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                SetResponse resp = client.Set("Activos/" + activos.id.ToString(), activos);

            }
        }

        public void ActivoDelete(Activos activos)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                string path = "Activos/" + activos.id.ToString();
                client.Delete(path);

            }
        }

        public List<Activos> ActivosList()
        {
            Settings settings = new Settings();
            var data = new List<Activos>();
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                FirebaseResponse response = client.Get("Activos");
                var json = response.Body;
                if (json != null && json != "null")
                {
                    var Jsondata = JObject.Parse(json);
                    foreach (KeyValuePair<string, JToken> property in Jsondata)
                    {
                        Activos ActivosResult = JsonConvert.DeserializeObject<Activos>(property.Value.ToString());

                        Activos activos = new Activos();
                        activos.id = ActivosResult.id;
                        activos.symbol = ActivosResult.symbol;
                        activos.name = ActivosResult.name;
                        activos.type = ActivosResult.type;
                        activos.region = ActivosResult.region;
                        activos.marketOpen = ActivosResult.marketOpen;
                        activos.marketClose = ActivosResult.marketClose;
                        activos.timezone = ActivosResult.timezone;
                        activos.currency = ActivosResult.currency;
                        activos.matchScore = ActivosResult.matchScore;
                        activos.creationDate = ActivosResult.creationDate;

                        data.Add(activos);
                    }
                }


            }

            return data;
        }

        public List<Resultados> ResultadosList()
        {
            Settings settings = new Settings();
            var data = new List<Resultados>();
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                FirebaseResponse response = client.Get("ACTFResult");
                var json = response.Body;
                if (json != null && json != "null")
                {
                    var Jsondata = JObject.Parse(json);
                    foreach (KeyValuePair<string, JToken> property in Jsondata)
                    {
                        Resultados resultados_ = JsonConvert.DeserializeObject<Resultados>(property.Value.ToString());

                        Resultados resultados = new Resultados();
                        resultados.id = resultados_.id;
                        resultados.Fecha = resultados_.Fecha;
                        resultados.Activo = resultados_.Activo;
                        resultados.Estrategia = resultados_.Estrategia;
                        resultados.Secciones = resultados_.Secciones;
                        resultados.Indicador = resultados_.Indicador;
                        resultados.Temporalidad = resultados_.Temporalidad;
                        resultados.TipoPrecio = resultados_.TipoPrecio;
                        resultados.CapitalInicial = resultados_.CapitalInicial;
                        resultados.resultados = resultados_.resultados;
                        resultados.ComisionEntrada = resultados_.ComisionEntrada;
                        resultados.ComisionSalida = resultados_.ComisionSalida;
                       
                        data.Add(resultados);
                    }
                }


            }

            return data;
        }


        public List<ResultadosDetalle> ResultadosDetalleList(Guid ResultadoID)
        {
            Settings settings = new Settings();
            var data = new List<ResultadosDetalle>();
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                FirebaseResponse response = client.Get("ACTFResultDetalle/"+ ResultadoID.ToString());
                var json = response.Body;
                if (json != null && json != "null")
                {
                    JavaScriptSerializer j = new JavaScriptSerializer();
                    object Data = j.Deserialize(json, typeof(object));
                    data = JsonConvert.DeserializeObject<List<ResultadosDetalle>>(json);
                  
                }


            }

            return data;
        }
    }
}