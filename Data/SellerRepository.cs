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
    public class SellerRepository : ISellerRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Seller> GetAll()
        {
            List<Seller> lst = new List<Seller>();

            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_VENDEDORES");

            foreach (DataRow row in dt.Rows)
            {
                Seller seller = new Seller();

                seller.Cod = (int)row["cod_vendedor"];
                seller.Name = (string)row["nom_vendedor"];
                seller.LastName = (string)row["ape_vendedor"];
                seller.street = (string)row["calle"];
                seller.Number = Convert.ToInt32(row["altura"]);
                seller.Neighborhood = (int)row["cod_barrio"];
                seller.Tellphone = row["nro_tel"] == DBNull.Value ? 0 : Convert.ToInt32(row["nro_tel"]);
                seller.Email = row["e-mail"] == DBNull.Value ? "" : (string)row["e-mail"];
                seller.birthdate = row["fec_nac"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["fec_nac"];

                lst.Add(seller);
            }
            return lst;
        }

        public Seller GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Seller seller)
        {
            throw new NotImplementedException();
        }
    }
}
