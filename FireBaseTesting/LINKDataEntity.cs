using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireBaseTesting
{
    public class LINKDataEntity
    {
        public Guid id { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string Documento { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}