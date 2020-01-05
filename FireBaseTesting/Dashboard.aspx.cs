using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FireBaseTesting
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                webClient.Encoding = UTF8Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/json");
                //string reply = webClient.UploadString(settings.UrlMessageSend + settings.Apitoken + settings.Instance, "POST", "{\n\t\"phone\":" + phone + ",\n\t\"body\":\"" + settings.AnswerPhrase + "\"\n}");
                var json = webClient.DownloadString("https://firestore.googleapis.com/v1/projects/apptecnicos-9a471/databases/(default)/documents/prueba");
                divjson.InnerHtml = json.ToString();
                //Response.Write(json);

            }
        }
    }
}