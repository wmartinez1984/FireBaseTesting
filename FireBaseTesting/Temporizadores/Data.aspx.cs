using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FireBaseTesting.Temporizadores
{
    public partial class Data : System.Web.UI.Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "iBcbS7xIoCfCEj2lc8mAdFBNV4ZqqS599tMOVdCQ",
            BasePath = "https://fruselvaclient.firebaseio.com/",
        };
        IFirebaseClient client;

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        public class DataOP
        {
            public Guid Id { get; set; }
            public string name { get; set; }
            public string OpName { get; set; }
            public string Cliente { get; set; }
        }
    }
}