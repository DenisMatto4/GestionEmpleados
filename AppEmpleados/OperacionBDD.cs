using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmpleados
{
    public class OperacionBDD
    {
        private string connectionString = "Data Source=79.143.90.12,54321;Initial Catalog=DenisMattoEmployees;User ID=sa;Password=123456789";


        public OperacionBDD() { }

        public OperacionBDD(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Insert(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int InsertReturnId(string query, SqlParameter[] parameters)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    object lastid = command.ExecuteScalar();
                    id = Convert.ToInt32(lastid);
                }
            }
            return id;
        }

        public void Update(string query, SqlParameter[] parameters)
        {
            Insert(query, parameters);
        }

        public void Delete(string query, SqlParameter[] parameters)
        {
            Insert(query, parameters);
        }

        public SqlDataReader Select(string query, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
