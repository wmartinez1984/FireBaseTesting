using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireBaseTesting
{
    public class ResultadosDetalle
    {
        public Guid id { get; set; }
        public string Senal { get; set; }
        public int Cantidaddedias { get; set; }
        public int Cantidadediasfueradelmercado { get; set; }
        public int Cantidaddediasdentrodelmercado { get; set; }
        public int CantidadtotaldeOperaciones { get; set; }
        public string CantidadtotaldeOPGanadoras { get; set; }
        public string CantidadtotaldeOPPerdedoras { get; set; }

        public decimal GananciaMaxima { get; set; }
        public decimal PerdidaMaxima { get; set; }
        public decimal PerformanceTotal { get; set; }
        public decimal PerformanceAnualizada { get; set; }
        public decimal PerformanceBuyAndHold { get; set; }
        public decimal PerformanceBuyAndHoldAnualizada { get; set; }
        public decimal EM { get; set; }
        public decimal RachaGanadora { get; set; }
        public decimal RachaPerdedora { get; set; }



    }
}