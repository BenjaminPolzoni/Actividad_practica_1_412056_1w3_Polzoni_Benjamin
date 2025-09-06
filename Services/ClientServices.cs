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
    public class ClientServices
    {
        private IClientRepository _repository;
        public ClientServices()
        {
            _repository = new ClientRepostory();
        }
        public List<Client> GetAll()
        {
            return _repository.GetAll();
        }
        public bool SaveProduct(Client client)
        {
            return _repository.Save(client);
        }
    }
}
