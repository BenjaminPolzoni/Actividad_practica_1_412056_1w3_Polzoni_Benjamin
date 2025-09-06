using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data.Interfaces;
using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data.Utiliti;
using Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data
{
    public class InvoiceRepository : IInvoiceReposiotry
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Invoice invoice)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_INSERTAR_FACTURA", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cliente", invoice.Client.Cod);
                cmd.Parameters.AddWithValue("@vendedor", invoice.Seller.Cod);

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                int InvoidId = (int)param.Value;

                // Recorro la lista de los detalles donde cargare uno a uno los detalles respectivamente
                foreach (var detail in invoice.DetailInvoices)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE_FACTURA", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;

                    cmdDetail.Parameters.AddWithValue("@id_articulo", detail.Article.Cod);
                    cmdDetail.Parameters.AddWithValue("@id_factura", InvoidId);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Count);
                    cmdDetail.Parameters.AddWithValue("@precio", detail.UnitPrice);
                    cmdDetail.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch (SqlException e)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                // Si no es nula y esta abierta, la cerramos
                if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
