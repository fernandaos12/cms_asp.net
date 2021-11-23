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
        public string Conteudo  { get; set; }
        public DateTime Data { get; set; }


        public List<Pagina> Lista()
        {
            var Lista = new List<Pagina>();
            var paginaDb = new Database.Pagina();
            
                foreach(DataRow row in paginaDb.Lista().Rows)
                {
                var pagina = new Pagina();
                pagina.Id = Convert.ToInt32(row["Id"]);
                pagina.Name = Convert.ToString(row["Name"]);
                pagina.Conteudo = row["Conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);

                
            }
           return Lista;
        }

    }
}
