using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace FireBaseTesting
{
    public class ACTFResultados
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "iBcbS7xIoCfCEj2lc8mAdFBNV4ZqqS599tMOVdCQ",
            BasePath = "https://fruselvaclient.firebaseio.com/",
        };

        IFirebaseClient client;
        public void Insert(Resultados resultados)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                SetResponse resp = client.Set("ACTFResult/" + resultados.id.ToString(), resultados);
            }
        }
        public void InsertDetalle(List<ResultadosDetalle> resultadosDetalles , Guid  id)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                SetResponse resp = client.Set("ACTFResultDetalle/" + id + "/", resultadosDetalles);
            }
        }

    }
}