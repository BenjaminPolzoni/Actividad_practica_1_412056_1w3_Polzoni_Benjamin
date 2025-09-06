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
    public class ArticleServices
    {
        private IArticleRepository _Repository;

        public ArticleServices()
        {
            _Repository = new ArticleRepository();
        }

        public List<Article> GetAll()
        {
            List<Article> list = _Repository.GetAll();

            return list;
        }
    }
}
