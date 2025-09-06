using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        Article GetById(int id);
        bool Save(Article article);
        bool Delete(int id);
    }
}
