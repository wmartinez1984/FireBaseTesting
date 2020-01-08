using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FireBaseTesting
{
    public partial class Dashboard : System.Web.UI.Page
    {

        string latitude;
        string longitude;
        string urlFoto;
        string nombreTecnico;
        string estado;
        string direccion;
        string total;
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Documents> listDocumentsData = new List<Documents>();
            //using (WebClient webClient = new System.Net.WebClient())
            //{
            //    webClient.Encoding = Encoding.UTF8;
            //    webClient.Encoding = UTF8Encoding.UTF8;
            //    webClient.Headers.Add("Content-Type", "application/json");
            //    var json = webClient.DownloadString("https://firestore.googleapis.com/v1/projects/apptecnicos-9a471/databases/(default)/documents/prueba");
            //    JObject FireBaseSearch = JObject.Parse(json);
            //    IList<JToken> results = FireBaseSearch["documents"].Children()["fields"].ToList();
            //    string dataString = "";
            //    foreach (JToken result in results)
            //    {
                    
            //        JObject FireBaseTable = JObject.Parse(result.ToString());
            //        foreach (KeyValuePair<string, JToken> property in FireBaseTable)
            //        {
            //            dataString += "\n\n <br/> " + property.Key;

            //            if(property.Key.Equals("ubicacion"))
            //            {
            //                dataString += " : " + property.Value.ToString();

            //                IList<JToken> resultsUbicacion;
            //                JObject FireBaseSearchubicacion = JObject.Parse(property.Value.ToString());
            //                resultsUbicacion = FireBaseSearchubicacion["mapValue"]["fields"]["latitude"].Children().ToList();
            //                foreach (JToken resultU in resultsUbicacion)
            //                {
            //                    dataString += " <br/> " + ((Newtonsoft.Json.Linq.JProperty)resultU).Value.ToString();
            //                    latitude = ((Newtonsoft.Json.Linq.JProperty)resultU).Value.ToString();
            //                }

                            
            //                resultsUbicacion = FireBaseSearchubicacion["mapValue"]["fields"]["longitude"].Children().ToList();
            //                foreach (JToken resultU in resultsUbicacion)
            //                {
            //                    dataString += " <br/> " + ((Newtonsoft.Json.Linq.JProperty)resultU).Value.ToString();
            //                    longitude = ((Newtonsoft.Json.Linq.JProperty)resultU).Value.ToString();
            //                }

            //            }
            //            else
            //            {
            //                JObject FireBaseValorCampo = JObject.Parse(property.Value.ToString());
            //                foreach (KeyValuePair<string, JToken> property_ in FireBaseValorCampo)
            //                {
            //                    dataString += " : " + property_.Value.ToString();
            //                    if (property.Key.Equals("urlFoto"))
            //                    {
            //                        urlFoto = property_.Value.ToString();
            //                    }
            //                    if (property.Key.Equals("nombreTecnico"))
            //                    {
            //                        nombreTecnico = property_.Value.ToString();
            //                    }
            //                    if (property.Key.Equals("estado"))
            //                    {
            //                        estado = property_.Value.ToString();
            //                    }
            //                    if (property.Key.Equals("direccion"))
            //                    {
            //                        direccion = property_.Value.ToString();
            //                    }
            //                    if (property.Key.Equals("total"))
            //                    {
            //                        total = property_.Value.ToString();
            //                    }
            //                }
            //            }                    
                      
            //        }
            //        listDocumentsData.Add(new Documents(latitude, longitude, estado, direccion, total));

            //        dataString += "\n\n <br/> **********************************************************************************************************";
            //        dataString += "\n\n <br/> **********************************************************************************************************";
            //    }

            //    divjson.InnerHtml = dataString;
            //}

            
        }
       
        

        

    }
}