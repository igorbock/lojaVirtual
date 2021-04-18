using LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class HomeController : Controller
    {
        LojaDbContext context = new LojaDbContext();

        // GET: Home
        public ActionResult Index()
        {
            var produtos = context.Produtos.Take(3);

            return View(produtos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Descricao,Preco,Categoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }
    }
}