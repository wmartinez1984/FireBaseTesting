using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireBaseTesting;
namespace FireBaseTesting.Temporizadores
{
    /// <summary>
    /// Descripción breve de DataOP
    /// </summary>
    public class DataOP : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Action"].ToString().Equals("OPSelect"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = ProductionOrderSelect(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("SaveOP"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = ProductionOrderSave(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("OPRegistradas"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = OrdenesRegistradasSelect(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("InciarLinea"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = IniciarLineadeProduccion(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }
        }

        public static string IniciarLineadeProduccion(HttpContext context)
        {
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            ProductionOrderEntity data = new ProductionOrderEntity();
            Settings settings = new Settings();
            data.id = Guid.NewGuid();
            data.OP = context.Request.QueryString["OP"];
            data.ProductoOP = context.Request.QueryString["ProductoOP"];
            data.Descripcion = context.Request.QueryString["Descripcion"];
            data.Cantidad = context.Request.QueryString["Cantidad"];
            data.Ubicacion = context.Request.QueryString["Ubicacion"];
            data.CodCliente = context.Request.QueryString["CodCliente"];
            data.NombreCliente = context.Request.QueryString["NombreCliente"];
            data.EestadoL1 = int.Parse(context.Request.QueryString["L1"]);
            data.EestadoL2 = int.Parse(context.Request.QueryString["L2"]);
            data.EestadoL3 = int.Parse(context.Request.QueryString["L3"]);
            data.EestadoOP = settings.Envasando;
            data.MinParadaL1 = settings.SinParada;
            data.MinParadaL2 = settings.SinParada;
            data.MinParadaL3 = settings.SinParada;
            data.TiempoLavado = int.Parse(context.Request.QueryString["TiempoLavado"]);
            data.DescripLavado = context.Request.QueryString["DescripLavado"];
            data.HoraInicio = "NA";
            data.HoraFinalizacion = "NA";
            data.CantFabricados = "NA";
            data.FechaCreacion = DateTime.Now;

            productionOrderDAL.OP_Insert(data);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }

        public static string OrdenesRegistradasSelect(HttpContext context)
        {
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL(); 
            List<ProductionOrderEntity> list = new List<ProductionOrderEntity>();
            list = productionOrderDAL.OrdenesRegistradas_Select();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize(list));
        }

        public static string ProductionOrderSave(HttpContext context)
        {
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            ProductionOrderEntity data = new ProductionOrderEntity();
            Settings settings = new Settings();
            data.id = Guid.NewGuid();
            data.OP = context.Request.QueryString["OP"];
            data.ProductoOP = context.Request.QueryString["ProductoOP"];
            data.Descripcion = context.Request.QueryString["Descripcion"];
            data.Cantidad = context.Request.QueryString["Cantidad"];
            data.Ubicacion = context.Request.QueryString["Ubicacion"];
            data.CodCliente = context.Request.QueryString["CodCliente"];
            data.NombreCliente = context.Request.QueryString["NombreCliente"];
            data.EestadoL1 = settings.Iniciada;
            data.EestadoL2 = settings.Iniciada;
            data.EestadoL3 = settings.Iniciada;
            data.EestadoOP = settings.Iniciada;
            data.MinParadaL1 = settings.SinParada;
            data.MinParadaL2 = settings.SinParada;
            data.MinParadaL3 = settings.SinParada;
            data.TiempoLavado = int.Parse(context.Request.QueryString["TiempoLavado"]);
            data.DescripLavado = context.Request.QueryString["DescripLavado"];
            data.HoraInicio = "NA";
            data.HoraFinalizacion = "NA";
            data.CantFabricados = "NA";
            data.FechaCreacion =  DateTime.Now;
            
            productionOrderDAL.OP_Insert(data);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }

        public static string ProductionOrderSelect(HttpContext context)
        {
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            ProductionOrderEntity data = new ProductionOrderEntity();
            data.OP = context.Request.QueryString["OP"];
            List<ProductionOrderEntity> list = new List<ProductionOrderEntity>();
            list = productionOrderDAL.ProductionOrder_Select(data);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize(list));
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