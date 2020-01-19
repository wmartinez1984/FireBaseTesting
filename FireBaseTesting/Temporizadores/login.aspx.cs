using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FireBaseTesting.Temporizadores
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string a = "";
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            if (username.Value.Equals("Nivel1"))
            {
                Response.Redirect("Temporizador");
            }
            else if (username.Value.Equals("Nivel2"))
            {
                Response.Redirect("Data");
            }
            else
                spanMessage.InnerText = "Usuario no válido";
        }
    }
}