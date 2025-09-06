using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Domain
{
    public class Seller
    {
        public int Cod { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string street { get; set; }
        public  int Number { get; set; }
        public int Neighborhood { get; set; }
        public int Tellphone { get; set; }
        public string Email { get; set; }
        public DateTime birthdate { get; set; }
    }
}
