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
    public class SellerServices
    {
        private ISellerRepository _repository;
        public SellerServices()
        {
            _repository = new SellerRepository();
        }
        public List<Seller> GetAll()
        {
            return _repository.GetAll();
        }
        public bool SaveProduct(Seller seller)
        {
            return _repository.Save(seller);
        }
    }
}
