using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data.Interfaces;
using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data.Utiliti;
using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data
{
    public class ArticleRepository : IArticleRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAll()
        {
            List<Article> lst = new List<Article>();


            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULOS");

            foreach (DataRow row in dt.Rows)
            {
                Article p = new Article();
                p.Cod = (int)row["cod_articulo"];
                p.Description = (string)row["descripcion"];
                p.MinStock = row["stock_minimo"] == DBNull.Value ? 0 : Convert.ToInt32(row["stock_minimo"]); ;
                p.Stock = Convert.ToInt32(row["stock"]) ;
                p.UnitPrice = Convert.ToDouble(row["pre_unitario"]);
                p.Observation = row["observaciones"] == DBNull.Value ? "" : (string)row["observaciones"];
                lst.Add(p);
            }
            return lst;
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
