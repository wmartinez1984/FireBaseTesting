using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireBaseTesting
{
    
    
    public class ACTFDALKeys
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "iBcbS7xIoCfCEj2lc8mAdFBNV4ZqqS599tMOVdCQ",
            BasePath = "https://fruselvaclient.firebaseio.com/",
        };

        IFirebaseClient client;
        public void ACTFKeysSave(ACTFKeyss aCTFKeyss)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                SetResponse resp = client.Set("ACTFKeys/" + aCTFKeyss.id, aCTFKeyss);

            }
        }

        public void ACTFKeysDelete(ACTFKeyss aCTFKeyss)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                string path = "ACTFKeys/" + aCTFKeyss.id.ToString();
                client.Delete(path);

            }
        }

        public List<ACTFKeyss> ACTFKeyssList()
        {
            Settings settings = new Settings();
            var data = new List<ACTFKeyss>();
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                FirebaseResponse response = client.Get("ACTFKeys");
                var json = response.Body;
                if (json != null && json != "null")
                {
                    var Jsondata = JObject.Parse(json);
                    foreach (KeyValuePair<string, JToken> property in Jsondata)
                    {
                        ACTFKeyss CTFKeyssList = JsonConvert.DeserializeObject<ACTFKeyss>(property.Value.ToString());

                        ACTFKeyss ACTFKeyssList_ = new ACTFKeyss();
                        ACTFKeyssList_.id = CTFKeyssList.id;
                        ACTFKeyssList_.KeyApi = CTFKeyssList.KeyApi;
                        ACTFKeyssList_.CreationDate = CTFKeyssList.CreationDate;
                       
                        data.Add(ACTFKeyssList_);
                    }
                }


            }

            return data;
        }

    }
}