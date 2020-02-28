using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireBaseTesting
{
    public class ProductionOrderEntity
    {
        public Guid id { get; set; }
        public string OP { get; set; }
        public string ProductoOP { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Ubicacion { get; set; }
        public string CodCliente { get; set; }
        public string NombreCliente { get; set; }
        public int EestadoL1 { get; set; }
        public int EestadoL2 { get; set; }
        public int EestadoL3 { get; set; }
        public int EestadoOP { get; set; }
        public int MinParadaL1 { get; set; }
        public int MinParadaL2 { get; set; }
        public int MinParadaL3 { get; set; }
        public int TiempoLavado { get; set; }
        public string DescripLavado { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinalizacion { get; set; }
        public int CantFabricados { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaParadaL1 { get; set; }
        public DateTime FechaParadaL2 { get; set; }
        public DateTime FechaParadaL3 { get; set; }
        public DateTime FechaInicioLavado { get; set; }

        //Campos nuevos para  el inicio y fin de la OP
        //Campos OP1
        public string InicioHoraL1 { get; set; }
        public string InicioMinutosL1 { get; set; }
        public DateTime InicioFechaL1 { get; set; }
        public string FinHoraL1 { get; set; }
        public string FinMinutosL1 { get; set; }
        public DateTime FinFechaL1 { get; set; }

        //Campos OP2
        public string InicioHoraL2 { get; set; }
        public string InicioMinutosL2 { get; set; }
        public DateTime InicioFechaL2 { get; set; }
        public string FinHoraL2 { get; set; }
        public string FinMinutosL2 { get; set; }
        public DateTime FinFechaL2 { get; set; }


        //Campos OP3
        public string InicioHoraL3 { get; set; }
        public string InicioMinutosL3 { get; set; }
        public DateTime InicioFechaL3 { get; set; }
        public string FinHoraL3 { get; set; }
        public string FinMinutosL3 { get; set; }
        public DateTime FinFechaL3 { get; set; }




    }
}