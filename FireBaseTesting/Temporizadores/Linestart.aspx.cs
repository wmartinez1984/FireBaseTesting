using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FireBaseTesting.Temporizadores
{
    public partial class Linestart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["LineSelected"] != null)
                {
                     txtLinea.Value = Request.QueryString["LineSelected"];
                    SelectGrupo.Value = txtLinea.Value;
                }
                  
            }
        }
    }
}