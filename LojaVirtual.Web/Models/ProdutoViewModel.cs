using LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;

namespace LojaVirtual.Web.Models
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos;
        public Paginacao Paginacao { get; set; }
        public string CategoriaAtual { get; set; }
    }
}