using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> ProdutosCarrinho = new List<ItemCarrinho>();

        //Adicionar
        public void AdicionarItemCarrinho(Produto produto, int quantidade)
        {
            ItemCarrinho item = ProdutosCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if(item == null)
            {
                ProdutosCarrinho.Add(new ItemCarrinho { Produto = produto, Quantidade = quantidade });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        //Remover
        public void RemoverItem(Produto produto)
        {
            ProdutosCarrinho.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }

        //Obter valor total
        public decimal ObterValorTotal() 
        {
            return ProdutosCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);
        }

        //Limpar carrinho
        public void LimparCarrinho()
        {
            ProdutosCarrinho.Clear();
        }

        //Itens carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho { get { return ProdutosCarrinho; } }
    }
}
