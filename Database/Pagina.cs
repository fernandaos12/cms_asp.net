using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Pagina
    {
        private string SqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection conn = new SqlConnection(SqlConn()))
            {
                string queryString = "SELECT * FROM paginas";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Connection.Open();
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
           
        }

    }
}
