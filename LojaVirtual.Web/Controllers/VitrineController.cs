using LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private LojaDbContext context;
        public int produtosPorPagina = 3;

        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {
            context = new LojaDbContext();

            var produtos = context.Produtos.OrderBy(p => p.Descricao).Skip((pagina - 1) * produtosPorPagina).Take(produtosPorPagina);

            return View(produtos);
        }
    }
}