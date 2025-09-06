using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data;
using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data.Interfaces;
using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Services
{
    public class InvoiceServices
    {
        private IInvoiceReposiotry _repository;
        public InvoiceServices()
        {
            _repository = new InvoiceRepository();
        }
        public List<Invoice> GetAll()
        {
            return _repository.GetAll();
        }
        public bool Save(Invoice invoice)
        {
            return _repository.Save(invoice);
        }
    }
}
