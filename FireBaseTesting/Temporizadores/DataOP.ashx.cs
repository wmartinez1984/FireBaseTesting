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

            if (context.Request.QueryString["Action"].ToString().Equals("EsperandoLavado"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = EsperandoLavadoLineadeProduccionHoraInicioyFin(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("IniciandoHoraInicio"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = IniciarLineadeProduccionHoraInicio(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("IniciarLavado"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = IniciarLavado(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("FinalizarOP"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = FinalizarLineasyOP(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

            if (context.Request.QueryString["Action"].ToString().Equals("OPRegistradasTable"))
            {

                string callback = context.Request.QueryString["callback"];
                string json = OrdenesRegistradasSelectTable(context);
                if (!string.IsNullOrEmpty(callback))
                {
                    json = string.Format("{0}({1});", callback, json);
                }
                context.Response.ContentType = "text/json";
                context.Response.Write(json);


            }

        }


        public static string OrdenesRegistradasSelectTable(HttpContext context)
        {
            Settings settings = new Settings();
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            List<ProductionOrderEntity> list = new List<ProductionOrderEntity>();
            list = productionOrderDAL.OrdenesRegistradas_Select(context.Request.QueryString["GrupoLinea"].ToString());
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();          
            return (serializer.Serialize(list));
        }

        public static string FinalizarLineasyOP(HttpContext context)
        {
            OrdenesRegistradasSelect(context);// primero valido como estaban los datos antes de hacer el cambio;

            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            ProductionOrderEntity data = new ProductionOrderEntity();
            Settings settings = new Settings();
            data.id = Settings.id;
            data.OP = context.Request.QueryString["OP"];
            data.ProductoOP = context.Request.QueryString["ProductoOP"];
            data.Descripcion = context.Request.QueryString["Descripcion"];
            data.Cantidad = int.Parse(context.Request.QueryString["Cantidad"]);
            data.Ubicacion = context.Request.QueryString["Ubicacion"];
            data.CodCliente = context.Request.QueryString["CodCliente"];
            data.NombreCliente = context.Request.QueryString["NombreCliente"];
            data.EestadoL1 = int.Parse(context.Request.QueryString["L1"]);
            data.EestadoL2 = int.Parse(context.Request.QueryString["L2"]);
            data.EestadoL3 = int.Parse(context.Request.QueryString["L3"]);
            data.EestadoOP = settings.Terminada;
            data.MinParadaL1 = Settings.MinParadaL1;
            data.MinParadaL2 = Settings.MinParadaL2;
            data.MinParadaL3 = Settings.MinParadaL3;
            data.TiempoLavado = int.Parse(context.Request.QueryString["TiempoLavado"]);
            data.DescripLavado = context.Request.QueryString["DescripLavado"];
            data.HoraInicio = Settings.HoraInicio;
            data.HoraFinalizacion = Settings.HoraFinalizacion;
            data.CantFabricados = int.Parse(context.Request.QueryString["Cantidad"]);
            data.FechaCreacion = Settings.FechaCreacion;
            data.FechaModificacion = DateTime.Now;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            data.FechaInicioLavado = DateTime.Now.AddMinutes(int.Parse(context.Request.QueryString["TiempoLavado"]));


            //Todas las líneas en lavando 
            data.EestadoL1 = settings.Terminada;
            data.EestadoL2 = settings.Terminada;
            data.EestadoL3 = settings.Terminada;

            data.InicioHoraL1 = Settings.InicioHoraL1;
            data.InicioMinutosL1 = Settings.InicioMinutosL1;
            data.InicioFechaL1 = Settings.InicioFechaL1;
            data.FinHoraL1 = Settings.FinHoraL1;
            data.FinMinutosL1 = Settings.FinMinutosL1;
            data.FinFechaL1 = Settings.FinFechaL1;
            data.InicioHoraL2 = Settings.InicioHoraL2;
            data.InicioMinutosL2 = Settings.InicioMinutosL2;
            data.InicioFechaL2 = Settings.InicioFechaL2;
            data.FinHoraL2 = Settings.FinHoraL2;
            data.FinMinutosL2 = Settings.FinMinutosL2;
            data.FinFechaL2 = Settings.FinFechaL2;
            data.InicioHoraL3 = Settings.InicioHoraL3;
            data.InicioMinutosL3 = Settings.InicioMinutosL3;
            data.InicioFechaL3 = Settings.InicioFechaL3;
            data.FinHoraL3 = Settings.FinHoraL3;
            data.FinMinutosL3 = Settings.FinMinutosL3;
            data.FinFechaL3 = Settings.FinFechaL3;

            productionOrderDAL.OP_Insert(data, context.Request.QueryString["GrupoLinea"].ToString());

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }


        public static string IniciarLavado(HttpContext context)
        {
            OrdenesRegistradasSelect(context);// primero valido como estaban los datos antes de hacer el cambio;
            
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            ProductionOrderEntity data = new ProductionOrderEntity();
            Settings settings = new Settings();
            data.id = Settings.id;
            data.OP = context.Request.QueryString["OP"];
            data.ProductoOP = context.Request.QueryString["ProductoOP"];
            data.Descripcion = context.Request.QueryString["Descripcion"];
            data.Cantidad = int.Parse(context.Request.QueryString["Cantidad"]);
            data.Ubicacion = context.Request.QueryString["Ubicacion"];
            data.CodCliente = context.Request.QueryString["CodCliente"];
            data.NombreCliente = context.Request.QueryString["NombreCliente"];
            data.EestadoL1 = int.Parse(context.Request.QueryString["L1"]);
            data.EestadoL2 = int.Parse(context.Request.QueryString["L2"]);
            data.EestadoL3 = int.Parse(context.Request.QueryString["L3"]);
            data.EestadoOP = settings.Lavando;
            data.MinParadaL1 = Settings.MinParadaL1;
            data.MinParadaL2 = Settings.MinParadaL2;
            data.MinParadaL3 = Settings.MinParadaL3;
            data.TiempoLavado = int.Parse(context.Request.QueryString["TiempoLavado"]);
            data.DescripLavado = context.Request.QueryString["DescripLavado"];
            data.HoraInicio = Settings.HoraInicio;
            data.HoraFinalizacion = Settings.HoraFinalizacion;
            data.CantFabricados = int.Parse(context.Request.QueryString["Cantidad"]);
            data.FechaCreacion = Settings.FechaCreacion;
            data.FechaModificacion = DateTime.Now;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            
            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            data.FechaInicioLavado = DateTime.Now.AddMinutes(int.Parse(context.Request.QueryString["TiempoLavado"]));

            
           //Todas las líneas en lavando 
            data.EestadoL1 = settings.Lavando;            
            data.EestadoL2 = settings.Lavando;
            data.EestadoL3 = settings.Lavando;          

            data.InicioHoraL1 = Settings.InicioHoraL1;            
            data.InicioMinutosL1 = Settings.InicioMinutosL1;
            data.InicioFechaL1 = Settings.InicioFechaL1;           
            data.FinHoraL1 = Settings.FinHoraL1;            
            data.FinMinutosL1 = Settings.FinMinutosL1;
            data.FinFechaL1 = Settings.FinFechaL1;       
            data.InicioHoraL2 = Settings.InicioHoraL2;          
            data.InicioMinutosL2 = Settings.InicioMinutosL2;
            data.InicioFechaL2 = Settings.InicioFechaL2;           
            data.FinHoraL2 = Settings.FinHoraL2;           
            data.FinMinutosL2 = Settings.FinMinutosL2;
            data.FinFechaL2 = Settings.FinFechaL2;
            data.InicioHoraL3 = Settings.InicioHoraL3;
            data.InicioMinutosL3 = Settings.InicioMinutosL3;
            data.InicioFechaL3 = Settings.InicioFechaL3;
            data.FinHoraL3 = Settings.FinHoraL3;            
            data.FinMinutosL3 = Settings.FinMinutosL3;
            data.FinFechaL3 = Settings.FinFechaL3;

            productionOrderDAL.OP_Insert(data, context.Request.QueryString["GrupoLinea"].ToString());

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }

        public static string IniciarLineadeProduccionHoraInicio(HttpContext context)
        {
            OrdenesRegistradasSelect(context);// primero valido como estaban los datos antes de hacer el cambio;
            int LP = int.Parse(context.Request.QueryString["LP"]);
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            ProductionOrderEntity data = new ProductionOrderEntity();
            Settings settings = new Settings();
            data.id = Guid.NewGuid();
            data.OP = context.Request.QueryString["OP"];
            data.ProductoOP = context.Request.QueryString["ProductoOP"];
            data.Descripcion = context.Request.QueryString["Descripcion"];
            data.Cantidad = int.Parse(context.Request.QueryString["Cantidad"]);
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
            data.CantFabricados = int.Parse(context.Request.QueryString["Cantidad"]);
            data.FechaCreacion = Settings.FechaCreacion;
            data.FechaModificacion = DateTime.Now;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            data.FechaInicioLavado = Settings.FechaInicioLavado;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            data.FechaInicioLavado = Settings.FechaInicioLavado;

            // datos nuevos 
            //valido qué línea  es la que se está finalizando
            if (LP == Settings.L1)
            {
                data.EestadoL1 = settings.Envasando;
            }

            if (LP == Settings.L2)
            {
                data.EestadoL2 = settings.Envasando;
            }
            if (LP == Settings.L3)
            {
                data.EestadoL3 = settings.Envasando;
            }

            if (context.Request.QueryString["InicioHoraL1"] != null)
                data.InicioHoraL1 = context.Request.QueryString["InicioHoraL1"];
            else
                data.InicioHoraL1 = Settings.InicioHoraL1;

            if (context.Request.QueryString["InicioMinutosL1"] != null)
                data.InicioMinutosL1 = context.Request.QueryString["InicioMinutosL1"];
            else
                data.InicioMinutosL1 = Settings.InicioMinutosL1;

            data.InicioFechaL1 = DateTime.Now;

            if (context.Request.QueryString["FinHoraL1"] != null)
                data.FinHoraL1 = context.Request.QueryString["FinHoraL1"];
            else
                data.FinHoraL1 = Settings.FinHoraL1;

            if (context.Request.QueryString["FinMinutosL1"] != null)
                data.FinMinutosL1 = context.Request.QueryString["FinMinutosL1"];
            else
                data.FinMinutosL1 = Settings.FinMinutosL1;

            data.FinFechaL1 = DateTime.Now;

            if (context.Request.QueryString["InicioHoraL2"] != null)
                data.InicioHoraL2 = context.Request.QueryString["InicioHoraL2"];
            else
                data.InicioHoraL2 = Settings.InicioHoraL2;


            if (context.Request.QueryString["InicioMinutosL2"] != null)
                data.InicioMinutosL2 = context.Request.QueryString["InicioMinutosL2"];
            else
                data.InicioMinutosL2 = Settings.InicioMinutosL2;

            data.InicioFechaL2 = DateTime.Now;

            if (context.Request.QueryString["FinHoraL2"] != null)
                data.FinHoraL2 = context.Request.QueryString["FinHoraL2"];
            else
                data.FinHoraL2 = Settings.FinHoraL2;

            if (context.Request.QueryString["FinMinutosL2"] != null)
                data.FinMinutosL2 = context.Request.QueryString["FinMinutosL2"];
            else
                data.FinMinutosL2 = Settings.FinMinutosL2;

            data.FinFechaL2 = DateTime.Now;

            if (context.Request.QueryString["InicioHoraL3"] != null)
                data.InicioHoraL3 = context.Request.QueryString["InicioHoraL3"];
            else
                data.InicioHoraL3 = Settings.InicioHoraL3;

            if (context.Request.QueryString["InicioMinutosL3"] != null)
                data.InicioMinutosL3 = context.Request.QueryString["InicioMinutosL3"];
            else
                data.InicioMinutosL3 = Settings.InicioMinutosL3;

            data.InicioFechaL3 = DateTime.Now;

            if (context.Request.QueryString["FinHoraL3"] != null)
                data.FinHoraL3 = context.Request.QueryString["FinHoraL3"];
            else
                data.FinHoraL3 = Settings.FinHoraL3;

            if (context.Request.QueryString["FinMinutosL3"] != null)
                data.FinMinutosL3 = context.Request.QueryString["FinMinutosL3"];
            else
                data.FinMinutosL3 = Settings.FinMinutosL3;

            data.FinFechaL3 = DateTime.Now;

            productionOrderDAL.OP_Insert(data, context.Request.QueryString["GrupoLinea"].ToString());

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }


        public static string EsperandoLavadoLineadeProduccionHoraInicioyFin(HttpContext context)
        {
            OrdenesRegistradasSelect(context);// primero valido como estaban los datos antes de hacer el cambio;
            int LP = int.Parse(context.Request.QueryString["LP"]);
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            ProductionOrderEntity data = new ProductionOrderEntity();
            Settings settings = new Settings();
            data.id = Guid.NewGuid();
            data.OP = context.Request.QueryString["OP"];
            data.ProductoOP = context.Request.QueryString["ProductoOP"];
            data.Descripcion = context.Request.QueryString["Descripcion"];
            data.Cantidad = int.Parse(context.Request.QueryString["Cantidad"]);
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
            data.CantFabricados = int.Parse(context.Request.QueryString["Cantidad"]);
            data.FechaCreacion = Settings.FechaCreacion;
            data.FechaModificacion = DateTime.Now;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            data.FechaInicioLavado = Settings.FechaInicioLavado;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            data.FechaInicioLavado = Settings.FechaInicioLavado;

            // datos nuevos 
            //valido qué línea  es la que se está finalizando
            if (LP == Settings.L1)
            {
                data.EestadoL1 = settings.Terminada;
            }

            if (LP == Settings.L2)
            {
                data.EestadoL2 = settings.Terminada;
            }
            if (LP == Settings.L3)
            {
                data.EestadoL3 = settings.Terminada;
            }

            if (context.Request.QueryString["InicioHoraL1"] != null)
                data.InicioHoraL1 = context.Request.QueryString["InicioHoraL1"];
            else
                data.InicioHoraL1 = Settings.InicioHoraL1;

            if (context.Request.QueryString["InicioMinutosL1"] != null)
                data.InicioMinutosL1 = context.Request.QueryString["InicioMinutosL1"];
            else
                data.InicioMinutosL1 = Settings.InicioMinutosL1;

            data.InicioFechaL1 = DateTime.Now;

            if (context.Request.QueryString["FinHoraL1"] != null)
                data.FinHoraL1 = context.Request.QueryString["FinHoraL1"];
            else
                data.FinHoraL1 = Settings.FinHoraL1;

            if (context.Request.QueryString["FinMinutosL1"] != null)
                data.FinMinutosL1 = context.Request.QueryString["FinMinutosL1"];
            else
                data.FinMinutosL1 = Settings.FinMinutosL1;
                      
            data.FinFechaL1 = DateTime.Now;

            if (context.Request.QueryString["InicioHoraL2"] != null)
                data.InicioHoraL2 = context.Request.QueryString["InicioHoraL2"];
            else
                data.InicioHoraL2 = Settings.InicioHoraL2;


            if (context.Request.QueryString["InicioMinutosL2"] != null)
                data.InicioMinutosL2 = context.Request.QueryString["InicioMinutosL2"];
            else
                data.InicioMinutosL2 = Settings.InicioMinutosL2;

            data.InicioFechaL2 = DateTime.Now;

            if (context.Request.QueryString["FinHoraL2"] != null)
                data.FinHoraL2 = context.Request.QueryString["FinHoraL2"];
            else
                data.FinHoraL2 = Settings.FinHoraL2;

            if (context.Request.QueryString["FinMinutosL2"] != null)
                data.FinMinutosL2 = context.Request.QueryString["FinMinutosL2"];
            else
                data.FinMinutosL2 = Settings.FinMinutosL2;

            data.FinFechaL2 = DateTime.Now;

            if (context.Request.QueryString["InicioHoraL3"] != null)
                data.InicioHoraL3 = context.Request.QueryString["InicioHoraL3"];
            else
                data.InicioHoraL3 = Settings.InicioHoraL3;

            if (context.Request.QueryString["InicioMinutosL3"] != null)
                data.InicioMinutosL3 = context.Request.QueryString["InicioMinutosL3"];
            else
                data.InicioMinutosL3 = Settings.InicioMinutosL3;

            data.InicioFechaL3 = DateTime.Now;

            if (context.Request.QueryString["FinHoraL3"] != null)
                data.FinHoraL3 = context.Request.QueryString["FinHoraL3"];
            else
                data.FinHoraL3 = Settings.FinHoraL3;

            if (context.Request.QueryString["FinMinutosL3"] != null)
                data.FinMinutosL3 = context.Request.QueryString["FinMinutosL3"];
            else
                data.FinMinutosL3 = Settings.FinMinutosL3;

            data.FinFechaL3 = DateTime.Now;

            productionOrderDAL.OP_Insert(data, context.Request.QueryString["GrupoLinea"].ToString());

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
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
            data.Cantidad = int.Parse(context.Request.QueryString["Cantidad"]);
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
            data.CantFabricados = 0;
            data.FechaCreacion = Settings.FechaCreacion;
            data.FechaModificacion = DateTime.Now;
            data.FechaInicioLavado = Settings.FechaInicioLavado;


            // datos nuevos 
            data.InicioHoraL1 = Settings.InicioHoraL1;
            data.InicioMinutosL1 = Settings.InicioMinutosL1;
            data.InicioFechaL1 = Settings.InicioFechaL1;
            data.FinHoraL1 = Settings.FinHoraL1;
            data.FinMinutosL1 = Settings.FinMinutosL1;
            data.FinFechaL1 = Settings.FinFechaL1;

            data.InicioHoraL2 = Settings.InicioHoraL2;
            data.InicioMinutosL2 = Settings.InicioMinutosL2;
            data.InicioFechaL2 = Settings.InicioFechaL2;
            data.FinHoraL2 = Settings.FinHoraL2;
            data.FinMinutosL2 = Settings.FinMinutosL2;
            data.FinFechaL2 = Settings.FinFechaL2;

            data.InicioHoraL3 = Settings.InicioHoraL3;
            data.InicioMinutosL3 = Settings.InicioMinutosL3;
            data.InicioFechaL3 = Settings.InicioFechaL3;
            data.FinHoraL3 = Settings.FinHoraL3;
            data.FinMinutosL3 = Settings.FinMinutosL3;
            data.FinFechaL3 = Settings.FinFechaL3;

            productionOrderDAL.OP_Insert(data, context.Request.QueryString["GrupoLinea"].ToString());
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }


        public static string OrdenesRegistradasSelectFinalDeLinea(HttpContext context)
        {

            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL();
            List<ProductionOrderEntity> list = new List<ProductionOrderEntity>();
            list = productionOrderDAL.OrdenesRegistradas_Select(context.Request.QueryString["GrupoLinea"].ToString());
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
            data.Cantidad = int.Parse(context.Request.QueryString["Cantidad"]);
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
            data.CantFabricados = int.Parse(context.Request.QueryString["Cantidad"]);
            data.FechaCreacion =   Settings.FechaCreacion;
            data.FechaModificacion = DateTime.Now;

            data.FechaParadaL1 = Settings.FechaParadaL1;
            data.FechaParadaL2 = Settings.FechaParadaL2;
            data.FechaParadaL3 = Settings.FechaParadaL3;
            data.FechaInicioLavado = Settings.FechaInicioLavado;

            // datos nuevos 
            data.InicioHoraL1 =  Settings.InicioHoraL1;
            data.InicioMinutosL1 = Settings.InicioMinutosL1 ;
            data.InicioFechaL1 =  Settings.InicioFechaL1 ;
            data.FinHoraL1 =  Settings.FinHoraL1 ;
            data.FinMinutosL1 =  Settings.FinMinutosL1 ;
            data.FinFechaL1 = Settings.FinFechaL1 ;

            data.InicioHoraL2 = Settings.InicioHoraL2 ;
            data.InicioMinutosL2 =  Settings.InicioMinutosL2;
            data.InicioFechaL2 = Settings.InicioFechaL2 ;
            data.FinHoraL2 = Settings.FinHoraL2 ;
            data.FinMinutosL2 = Settings.FinMinutosL2 ;
            data.FinFechaL2 = Settings.FinFechaL2 ;

            data.InicioHoraL3 = Settings.InicioHoraL3 ;
            data.InicioMinutosL3 = Settings.InicioMinutosL3 ;
            data.InicioFechaL3 = Settings.InicioFechaL3 ;
            data.FinHoraL3 = Settings.FinHoraL3;
            data.FinMinutosL3 = Settings.FinMinutosL3;
            data.FinFechaL3 = Settings.FinFechaL3;

            productionOrderDAL.OP_Insert(data, context.Request.QueryString["GrupoLinea"].ToString());
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return (serializer.Serialize("ok,ok"));
        }

        
        public static string OrdenesRegistradasSelect(HttpContext context)
        {
            Settings settings = new Settings();
            ProductionOrderDAL productionOrderDAL = new ProductionOrderDAL(); 
            List<ProductionOrderEntity> list = new List<ProductionOrderEntity>();
            list = productionOrderDAL.OrdenesRegistradas_Select(context.Request.QueryString["GrupoLinea"].ToString());
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

                    //datos nuevos 
                    Settings.InicioHoraL1 = dataColum.InicioHoraL1;
                    Settings.InicioMinutosL1 = dataColum.InicioMinutosL1;
                    Settings.InicioFechaL1 = dataColum.InicioFechaL1;
                    Settings.FinHoraL1 = dataColum.FinHoraL1;
                    Settings.FinMinutosL1 = dataColum.FinMinutosL1;
                    Settings.FinFechaL1 = dataColum.FinFechaL1;

                    Settings.InicioHoraL2 = dataColum.InicioHoraL2;
                    Settings.InicioMinutosL2 = dataColum.InicioMinutosL2;
                    Settings.InicioFechaL2 = dataColum.InicioFechaL2;
                    Settings.FinHoraL2 = dataColum.FinHoraL2;
                    Settings.FinMinutosL2 = dataColum.FinMinutosL2;
                    Settings.FinFechaL2 = dataColum.FinFechaL2;

                    Settings.InicioHoraL3 = dataColum.InicioHoraL3;
                    Settings.InicioMinutosL3 = dataColum.InicioMinutosL3;
                    Settings.InicioFechaL3 = dataColum.InicioFechaL3;
                    Settings.FinHoraL3 = dataColum.FinHoraL3;
                    Settings.FinMinutosL3 = dataColum.FinMinutosL3;
                    Settings.FinFechaL3 = dataColum.FinFechaL3;


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
                data.Cantidad = int.Parse(context.Request.QueryString["Cantidad"]);
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
                data.CantFabricados = 0;
                data.FechaCreacion = DateTime.Now;
                data.FechaModificacion = DateTime.Now;

                productionOrderDAL.OP_Insert(data, context.Request.QueryString["GrupoLinea"].ToString());
                
            

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