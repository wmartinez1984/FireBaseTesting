using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireBaseTesting.ActivosFinancieros
{
    /// <summary>
    /// Descripción breve de ApiKey_aspx
    /// </summary>
    public class ApiKey_aspx : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Action"].ToString().Equals("InsertKey"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = SaveKey(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("keysList"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = KeysList(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("DeleteKey"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = DeleteKey(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }
        }


        public static string DeleteKey(HttpContext context)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            ACTFDALKeys aCTFDALKeys = new ACTFDALKeys();

            ACTFKeyss data = new ACTFKeyss();
            data.id = new Guid(context.Request.QueryString["id"]);
            aCTFDALKeys.ACTFKeysDelete(data);
            return (serializer.Serialize("ok,ok"));
        }

        public static string KeysList(HttpContext context)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            ACTFDALKeys aCTFDALKeys = new ACTFDALKeys();
            List<ACTFKeyss> list = new List<ACTFKeyss>();
            list = aCTFDALKeys.ACTFKeyssList();
            
            return (serializer.Serialize(list));

        }

        public static string SaveKey(HttpContext context)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            ACTFDALKeys aCTFDALKeys = new ACTFDALKeys();

            ACTFKeyss data = new ACTFKeyss();
            data.id = Guid.NewGuid();
            data.KeyApi = context.Request.QueryString["KeyApi"];
            data.CreationDate = DateTime.Now;

            aCTFDALKeys.ACTFKeysSave(data);
            return (serializer.Serialize("ok,ok"));
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