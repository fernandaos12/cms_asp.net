using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Pagina
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }


        public List<Pagina> Lista()
        {
            var lista = new List<Pagina>();
            var paginaDb = new Database.Paginadb();

            foreach (DataRow row in paginaDb.Lista().Rows)
            {
                var pagina = new Pagina();

                pagina.Id = Convert.ToInt32(row["Id"]);
                pagina.Name = Convert.ToString(row["Name"]);
                pagina.Conteudo = row["Conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);

                lista.Add(pagina);
            }
            return lista;
        }

        public static object BuscaPorId(int id)
        {
            var pagina = new Pagina();
            var paginaDb = new Database.Paginadb();

            foreach (DataRow row in paginaDb.BuscaPorId(id).Rows)
            {
                pagina.Id = Convert.ToInt32(row["Id"]);
                pagina.Name = Convert.ToString(row["Name"]);
                pagina.Conteudo = row["Conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);

            }
            return pagina; //retorna o obj q trouxe do bd
        }

        public static void Excluir(int id)
        {
            new Database.Paginadb().Excluir(id);
        }

        public void Save()
        {
            new Database.Paginadb().Salvar(this.Id, this.Name, this.Conteudo, this.Data);
        }
    }
}
