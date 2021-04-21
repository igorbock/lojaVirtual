using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Web.Models;
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
        public int produtosPorPagina = 2;

        // GET: Vitrine
        public ViewResult ListaProdutos(int pagina = 1)
        {
            context = new LojaDbContext();

            ProdutoViewModel produtoViewModel = new ProdutoViewModel()
            {
                Produtos = context.Produtos.OrderBy(p => p.Descricao).Skip((pagina - 1) * produtosPorPagina).Take(produtosPorPagina),
                Paginacao = new Paginacao()
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = produtosPorPagina,
                    ItensTotal = context.Produtos.Count()
                }
            };
                 
            return View(produtoViewModel);
        }
    }
}