using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Domain
{
    public class DetailInvoice
    {
        public Article Article { get; set; }
        public int UnitPrice { get; set; }
        public int Count { get; set; }

    }
}
