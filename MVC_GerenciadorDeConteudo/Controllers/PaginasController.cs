using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

       
    }
}