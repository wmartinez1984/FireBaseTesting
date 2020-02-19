using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FireBaseTesting.Temporizadores
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
                ProductionOrderEntity data = new ProductionOrderEntity();
                data.OP = "222";
                List<ProductionOrderEntity> list = new List<ProductionOrderEntity>();
                list = productionOrderDAL.ProductionOrder_Select(data);
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                Response.Write("Todo ok");
            }
            catch( Exception ex)
            {
                Response.Write(ex);
            }

        }
    }
}