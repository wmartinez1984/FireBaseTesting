using Newtonsoft.Json.Linq;
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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            
            using (WebClient webClient = new System.Net.WebClient())
            {

                string Usuario = "";
                string tipoUsuario = "";
                string correo = "";

                webClient.Encoding = Encoding.UTF8;
                webClient.Encoding = UTF8Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/json");
                var json = webClient.DownloadString("https://firestore.googleapis.com/v1/projects/apptecnicos-9a471/databases/(default)/documents/usuarios");
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

                            if (property.Key.Equals("usuario"))
                            {
                                Usuario = property_.Value.ToString();
                            }

                            if (property.Key.Equals("correo"))
                            {
                                correo = property_.Value.ToString();
                            }

                            if (property.Key.Equals("tipoUsuario"))
                            {
                                tipoUsuario = property_.Value.ToString();
                            }

                        }


                    }

                    if (Usuario.Equals(txtUsername.Value) && correo.Equals(txtPassword.Value) && tipoUsuario.Equals("Administrador"))
                    {
                        Session.Add("Username", txtUsername.Value);
                        Response.Redirect("Dashboard");

                    }
                    else
                    {
                      string  script = @"<script type='text/javascript'>
                                        swal('El usuario o contraseña no son correctos, por favor verifique.', '', 'error');
                                        </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                       
                    }

                }


            }
        }
    }
}