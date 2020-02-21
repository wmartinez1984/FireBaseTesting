using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FireBaseTesting
{
    public partial class ViewPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["link"] != null)
                {
                    LINKDataEntity lINKDataEntity = new LINKDataEntity();
                    lINKDataEntity.id = new Guid(Request.QueryString["link"].ToString());
                    LINKDataDAL lINKDataDAL = new LINKDataDAL();
                    List<LINKDataEntity> DataList = lINKDataDAL.LINKDataSelect(lINKDataEntity);
                    if(DataList.Count > 0 )
                    {
                       if(DataList[0].FechaCaducidad>= DateTime.Now)
                       {
                            txtFilename.Value = DataList[0].Documento;
                       }
                       else
                       {
                           pMensaje.InnerHtml = "El documento ha expirado ";
                       }
                       
                    }
                    else
                    {
                        pMensaje.InnerHtml = "No existe el documento para este link";
                    }
                   
                }
                else
                {
                    pMensaje.InnerHtml = "El link no es correcto";
                  
                }

            }
        }
    }
}