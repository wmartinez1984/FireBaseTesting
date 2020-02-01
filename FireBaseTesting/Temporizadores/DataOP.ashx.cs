using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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

            if (context.Request.QueryString["Action"].ToString().Equals("OPRegistradasFinalLinea"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = OrdenesRegistradasSelectFinalDeLinea(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("DetenerLinea"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = DetenerLineadeProduccion(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

        }

        public static string DetenerLineadeProduccion(HttpContext context)
        {
            int LP = int.Parse(context.Request.QueryString["LP"]);

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
            data.EestadoOP = settings.Envasando;
            //valido qué OP es la que se está detienendo
            if (LP == Settings.L1)
            {
                data.MinParadaL1 = int.Parse(context.Request.QueryString["Tiempo"]);
                data.FechaParadaL1 = DateTime.Now.AddMinutes(int.Parse(context.Request.QueryString["Tiempo"]));
                data.EestadoL1 = settings.Detenida;
            }

            else
            {
                data.MinParadaL1 = Settings.MinParadaL1;
                data.FechaParadaL1 = Settings.FechaParadaL1;
                data.EestadoL1 = int.Parse(context.Request.QueryString["L1"]);
            }

            if (LP == Settings.L2)
            {
                data.MinParadaL2 = int.Parse(context.Request.QueryString["Tiempo"]);
                data.FechaParadaL2 = DateTime.Now.AddMinutes(int.Parse(context.Request.QueryString["Tiempo"]));
                data.EestadoL2 = settings.Detenida;
            }
            else
            {
                data.MinParadaL2 = Settings.MinParadaL2;
                data.FechaParadaL2 = Settings.FechaParadaL2;
                data.EestadoL2 = int.Parse(context.Request.QueryString["L2"]);
            }

            if (LP == Settings.L3)
            {
                data.MinParadaL3 = int.Parse(context.Request.QueryString["Tiempo"]);
                data.FechaParadaL3 = DateTime.Now.AddMinutes(int.Parse(context.Request.QueryString["Tiempo"]));
                data.EestadoL3 = settings.Detenida;
            }
            else
            {
                data.MinParadaL3 = Settings.MinParadaL3;
                data.FechaParadaL3 = Settings.FechaParadaL3;
                data.EestadoL3 = int.Parse(context.Request.QueryString["L3"]);
            }


            data.TiempoLavado = int.Parse(context.Request.QueryString["TiempoLavado"]);
            data.DescripLavado = context.Request.QueryString["DescripLavado"];
            data.HoraInicio = Settings.HoraInicio;
            data.HoraFinalizacion = Settings.HoraFinalizacion;
            data.CantFabricados = "0";
            data.FechaCreacion = Settings.FechaCreacion;
            data.FechaModificacion = DateTime.Now;
            data.FechaInicioLavado = Settings.FechaInicioLavado;

            productionOrderDAL.OP_Insert(data);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }


        public static string OrdenesRegistradasSelectFinalDeLinea(HttpContext context)
        {

            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            List<ProductionOrderEntity> list = new List<ProductionOrderEntity>();
            list = productionOrderDAL.OrdenesRegistradas_Select();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var filteredList = from dta in list
                               where dta.EestadoOP != 5  //solo la OP que está pendiente, si es que existe
                               select dta;
            
            return (serializer.Serialize(filteredList));

        }



        public static string IniciarLineadeProduccion(HttpContext context)
        {
            OrdenesRegistradasSelect(context);// primero valido como estaban los datos antes de hacer el cambio;
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
            data.MinParadaL1 = Settings.MinParadaL1;
            data.MinParadaL2 = Settings.MinParadaL2;
            data.MinParadaL3 = Settings.MinParadaL3;
            data.TiempoLavado = int.Parse(context.Request.QueryString["TiempoLavado"]);
            data.DescripLavado = context.Request.QueryString["DescripLavado"];
            data.HoraInicio = Settings.HoraInicio;
            data.HoraFinalizacion = Settings.HoraFinalizacion;
            data.CantFabricados = context.Request.QueryString["Cantidad"];
            data.FechaCreacion =   Settings.FechaCreacion;
            data.FechaModificacion = DateTime.Now;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            data.FechaInicioLavado = Settings.FechaInicioLavado;

            productionOrderDAL.OP_Insert(data);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }

        
        public static string OrdenesRegistradasSelect(HttpContext context)
        {
            Settings settings = new Settings();
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL(); 
            List<ProductionOrderEntity> list = new List<ProductionOrderEntity>();
            list = productionOrderDAL.OrdenesRegistradas_Select();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var filteredList = from dta in list
                               where dta.EestadoOP != 5  //solo la OP que está pendiente, si es que existe
                               select dta;
            int CountData = filteredList.Count(); 
            if (CountData >= 1)
            {
                foreach (ProductionOrderEntity dataColum in filteredList)
                {
                    Settings.OP = dataColum.OP; 
                    Settings.EestadoL1 = dataColum.EestadoL1;
                    Settings.EestadoL2 = dataColum.EestadoL2;
                    Settings.EestadoL3 = dataColum.EestadoL3;
                    Settings.EestadoOP = dataColum.EestadoOP;
                    Settings.MinParadaL1 = dataColum.MinParadaL1;
                    Settings.MinParadaL2 = dataColum.MinParadaL2;
                    Settings.MinParadaL3 = dataColum.MinParadaL3;
                    Settings.HoraInicio = dataColum.HoraInicio;
                    Settings.HoraFinalizacion = dataColum.HoraFinalizacion;
                    Settings.FechaCreacion = dataColum.FechaCreacion;
                    Settings.FechaModificacion = dataColum.FechaModificacion;
                    Settings.FechaParadaL1 = dataColum.FechaParadaL1;
                    Settings.FechaParadaL2 = dataColum.FechaParadaL2;
                    Settings.FechaParadaL3 = dataColum.FechaParadaL3;
                    Settings.FechaInicioLavado = dataColum.FechaInicioLavado;

                }
                
            }

            return (serializer.Serialize(list));
        }

        public static string ProductionOrderSave(HttpContext context)
        {
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();        
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
                data.FechaCreacion = DateTime.Now;
                data.FechaModificacion = DateTime.Now;

                productionOrderDAL.OP_Insert(data);
                
            

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