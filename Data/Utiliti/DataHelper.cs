using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Actividad_practica_1_412056_1w3_Polzoni_Benjamin.Data.Utiliti
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.SqlConnection);
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPQuery(string sp)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException e)
            {
                dt = null;
            }
            finally
            {
                _connection.Close();
            }
            return dt;
        }

        public bool ExecuteSpDml(string sp, List<Parameter>? param = null)
        {
            bool result;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (param != null)
                {
                    foreach (Parameter p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                }
                int affectedRows = cmd.ExecuteNonQuery();

                result = affectedRows > 0;
            }
            catch (SqlException ex)
            {

                result = false;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        public int ExecuteSpDMLTransact(string SP, List<Parameter>? param)
        {


            return 0;
        }
    }
}
