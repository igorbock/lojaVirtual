using LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private LojaDbContext context;

        // GET: Categoria
        public PartialViewResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;

            context = new LojaDbContext();

            IEnumerable<string> categorias = context.Produtos
                .Select(c => c.Categoria)
                .Distinct()
                .OrderBy(c => c);

            return PartialView(categorias);
        }
    }
}