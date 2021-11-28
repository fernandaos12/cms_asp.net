using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Paginas = new Pagina().Lista();

            return View();
        }

        public ActionResult Novo()
        {  
            return View();
        }

        [HttpPost]     
        public void Criar()
        {
            var pagina = new Pagina();
            pagina.Name = Request["name"];
            pagina.Conteudo = Request["conteudo"];
            pagina.Data = Convert.ToDateTime(Request["data"]);

            pagina.Save();
            Response.Redirect("/paginas");
        }
   
        public ActionResult Editar(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }
        
        public void Alterar(int id)
        {
          //  var pagina = new Pagina();

           var pagina = (Pagina)Pagina.BuscaPorId(id);

            pagina.Name = Request["name"];
            pagina.Conteudo = Request["conteudo"];
            pagina.Data = Convert.ToDateTime(Request["data"]);

            pagina.Save();
            Response.Redirect("/paginas");
        }


         public void Excluir(int id)
        {
            Pagina.Excluir(id);
            Response.Redirect("/paginas");
        }

    }
}