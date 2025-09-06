using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data.Interfaces
{
    public interface IInvoiceReposiotry
    {
        List<Invoice> GetAll();
        Invoice GetById(int id);
        bool Save(Invoice invoice);
        bool Delete(int id);
    }
}
