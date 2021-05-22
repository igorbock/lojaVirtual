using LojaVirtual.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            //Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItemCarrinho(produto1, 2);
            carrinho.AdicionarItemCarrinho(produto2, 3);
            carrinho.AdicionarItemCarrinho(produto1, 14);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
            Assert.AreEqual(itens[0].Quantidade, 16);
        }

        [TestMethod]
        public void RemoverItemCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Produto produto3 = new Produto()
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItemCarrinho(produto1, 3);
            carrinho.AdicionarItemCarrinho(produto2, 5);
            carrinho.AdicionarItemCarrinho(produto3, 6);

            carrinho.RemoverItem(produto2);

            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(resultado.Length, 2);
        }

        [TestMethod]
        public void ObterValorCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 200M
            };

            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 100M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItemCarrinho(produto1, 3);
            carrinho.AdicionarItemCarrinho(produto2, 5);

            //Act
            decimal resultado = carrinho.ObterValorTotal();

            //Assert
            Assert.AreEqual(resultado, 1100M);
        }

        [TestMethod]
        public void LimparCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 300M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItemCarrinho(produto1, 2);
            carrinho.AdicionarItemCarrinho(produto2, 3);

            //Act
            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
