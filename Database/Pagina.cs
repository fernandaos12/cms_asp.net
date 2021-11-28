using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Paginadb
    {
        private string SqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection conn = new SqlConnection(SqlConn()))
            {
                string queryString = "SELECT * FROM paginascms";
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

        public void Salvar(int id, string name, string conteudo, DateTime data)
        {
            data = DateTime.Parse(data.ToString("yyyy-MM-dd HH:mm:ss"), CultureInfo.CreateSpecificCulture("pt-BR"));


            using (SqlConnection conn = new SqlConnection(SqlConn()))
            {
                string queryString = "INSERT INTO paginascms(name,conteudo,data) VALUES ('" + name +"','"+ conteudo +"', '"+ data.ToString("yyyy-MM-dd HH:mm:sssss") +"')";
                SqlCommand command = new SqlCommand(queryString, conn);
               
                if(id != 0)
                {
                    // queryString = "UPDATE paginascms SET name='" + name + "',data='" + data.ToString("yyyy-MM-dd HH:mm:ss") + "', conteudo='" + conteudo + "' WHERE id=" + id ;
                    queryString = "UPDATE paginascms SET name='" + name + "',data='" + data + "', conteudo='" + conteudo + "' WHERE id=" + id;
                }
                command.Connection.Open();
                command.ExecuteNonQuery(); //executa e nao retorna nada             

            }
        }

        public void Excluir(int id)
        {
         //   data = DateTime.Parse(data.ToString("yyyy-MM-dd HH:mm:ss"), CultureInfo.CreateSpecificCulture("pt-BR"));


            using (SqlConnection conn = new SqlConnection(SqlConn()))
            {               
                string queryString = "DELETE FROM paginascms WHERE id=" + id;
                SqlCommand command = new SqlCommand(queryString, conn);
             
                command.Connection.Open();
                command.ExecuteNonQuery(); //executa e nao retorna nada             

            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(SqlConn()))
            {
                string queryString = "SELECT * FROM paginascms WHERE id=" +id;
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
