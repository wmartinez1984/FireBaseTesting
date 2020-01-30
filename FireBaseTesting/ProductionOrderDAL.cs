using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FireBaseTesting
{
    public class ProductionOrderDAL
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "iBcbS7xIoCfCEj2lc8mAdFBNV4ZqqS599tMOVdCQ",
            BasePath = "https://fruselvaclient.firebaseio.com/",
        };
        IFirebaseClient client;

        public List<ProductionOrderEntity> OrdenesRegistradas_Select()
        {
            Settings settings = new Settings();
            var data = new List<ProductionOrderEntity>();
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                FirebaseResponse response = client.Get("OperationOrder");
                var json = response.Body;
                if (json != null && json != "null")
                {
                    var Jsondata = JObject.Parse(json);
                    foreach (KeyValuePair<string, JToken> property in Jsondata)
                    {
                        ProductionOrderEntity productionOrder = JsonConvert.DeserializeObject<ProductionOrderEntity>(property.Value.ToString());
                      
                        ProductionOrderEntity productionOrderEntity_ = new ProductionOrderEntity();
                        productionOrderEntity_.OP = productionOrder.OP;
                        productionOrderEntity_.ProductoOP = productionOrder.ProductoOP.ToUpper();
                        productionOrderEntity_.Descripcion = productionOrder.Descripcion;
                        productionOrderEntity_.Cantidad = productionOrder.Cantidad;
                        productionOrderEntity_.CodCliente = productionOrder.CodCliente;
                        productionOrderEntity_.NombreCliente = productionOrder.NombreCliente;
                        productionOrderEntity_.EestadoL1 = productionOrder.EestadoL1;
                        productionOrderEntity_.EestadoL2 = productionOrder.EestadoL2;
                        productionOrderEntity_.EestadoL3 = productionOrder.EestadoL3;
                        productionOrderEntity_.EestadoOP = productionOrder.EestadoOP;
                        productionOrderEntity_.MinParadaL1 = productionOrder.MinParadaL1;
                        productionOrderEntity_.MinParadaL2 = productionOrder.MinParadaL2;
                        productionOrderEntity_.MinParadaL3 = productionOrder.MinParadaL3;
                        productionOrderEntity_.TiempoLavado = productionOrder.TiempoLavado;
                        productionOrderEntity_.DescripLavado = productionOrder.DescripLavado;
                        productionOrderEntity_.HoraInicio = productionOrder.HoraInicio;
                        productionOrderEntity_.HoraFinalizacion = productionOrder.HoraFinalizacion;
                        productionOrderEntity_.CantFabricados = productionOrder.CantFabricados;
                        productionOrderEntity_.FechaCreacion = productionOrder.FechaCreacion;
                        productionOrderEntity_.FechaModificacion = productionOrder.FechaModificacion;

                        productionOrderEntity_.FechaParadaL1 = productionOrder.FechaParadaL1;
                        productionOrderEntity_.FechaParadaL2 = productionOrder.FechaParadaL2;
                        productionOrderEntity_.FechaParadaL3 = productionOrder.FechaParadaL3;
                        productionOrderEntity_.FechaInicioLavado = productionOrder.FechaInicioLavado;

                        data.Add(productionOrderEntity_);
                    }
                }


            }

            
            return data;
        }
        public List<ProductionOrderEntity> ProductionOrder_Select(ProductionOrderEntity productionOrderEntity)
        {
            
            var data = new List<ProductionOrderEntity>();
            Queries select = new Queries();
            var parametros = new SqlParameter[] {
                      new SqlParameter("@OP", productionOrderEntity.OP),

            };

            SqlDataReader reader = select.Select("SELECT [OP],[Producto OP],[Descripcion],[Pedido],[Cantidad],[Ubicacion],[Cod Cliente],[Nombre Cliente] FROM [dbo].[SQL_TIRADAS_MEZCLAS_OP_PROD_TER]  WHERE OP = @OP", parametros);
            while (reader.Read())
            {
                ProductionOrderEntity productionOrderEntity_ = new ProductionOrderEntity();
                productionOrderEntity_.OP = reader["OP"].ToString().ToUpper();
                productionOrderEntity_.ProductoOP = reader["Producto OP"].ToString().ToUpper();
                productionOrderEntity_.Descripcion = reader["Descripcion"].ToString().ToUpper();
                productionOrderEntity_.Cantidad = reader["Cantidad"].ToString().ToUpper();
                productionOrderEntity_.CodCliente = reader["Cod Cliente"].ToString().ToUpper();
                productionOrderEntity_.NombreCliente = reader["Nombre Cliente"].ToString().ToUpper();

                data.Add(productionOrderEntity_);
            }
            return data;
        }

        public void OP_Insert(ProductionOrderEntity productionOrderEntity)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {              
                SetResponse resp = client.Set("OperationOrder/" + productionOrderEntity.OP, productionOrderEntity);     
                
            }
        }

        

    }
}