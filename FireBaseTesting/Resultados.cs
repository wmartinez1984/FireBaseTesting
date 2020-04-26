using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireBaseTesting
{
    public class Resultados
    {
        public Guid id { get; set; }       
        public DateTime Fecha { get; set; }
        public string Activo { get; set; }
        public string Estrategia { get; set; }
        public int Secciones { get; set; }
        public string Indicador { get; set; }
        public string Temporalidad { get; set; }

        public string TipoPrecio { get; set; }
        public decimal CapitalInicial { get; set; }

        public int resultados { get; set; }

        public decimal ComisionEntrada { get; set; }

        public decimal ComisionSalida { get; set; }


    }
}