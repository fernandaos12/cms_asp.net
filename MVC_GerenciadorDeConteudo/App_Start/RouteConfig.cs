using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "sobre",
               "sobre", new { controller = "Home", action = "About" }
               );

            routes.MapRoute(
             "paginas",
             "paginas", new { controller = "Paginas", action = "Index" }
             );

            routes.MapRoute(
              "paginas_novo",
              "paginas/novo", new { controller = "Paginas", action = "Novo" }
              );

            routes.MapRoute(
               "paginas_criar",
               "paginas/criar", new { controller = "Paginas", action = "Criar" }
               );

            routes.MapRoute(
             "paginas_editar",
             "paginas/{id}/editar", new { controller = "Paginas", action = "Editar", id = 0 }
             );

            routes.MapRoute(
             "paginas_alterar",
             "paginas/{id}/alterar", new { controller = "Paginas", action = "Alterar", id = 0 }
             );

            routes.MapRoute(
            "paginas_preview",
            "paginas/{id}/preview", new { controller = "Paginas", action = "Preview", id = 0 }
            );

            routes.MapRoute(
          "paginas_excluir",
          "paginas/{id}/excluir", new { controller = "Paginas", action = "Excluir", id = 0 }
          );

            routes.MapRoute(
             "consulta_cep",
             "consulta_cep", new { controller = "Cep", action = "Index" }

             );

            routes.MapRoute(
                "contato",
                "contato", new { controller = "Home", action = "Contact" }

                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
