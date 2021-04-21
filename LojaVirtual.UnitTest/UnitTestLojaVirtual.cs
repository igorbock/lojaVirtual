using LojaVirtual.Web.HtmlHelpers;
using LojaVirtual.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestLojaVirtual
    {
        [TestMethod]
        public void Take()
        {
            int[] numeros = { 3, 4, 6, 1, 2, 8, 5, 5, 0, 1 };
            var resultado = from num in numeros.Take(5) select num;
            int[] teste = { 3, 4, 6, 1, 2 };
            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void Skip()
        {
            int[] numeros = { 3, 4, 6, 1, 2, 8, 5, 5, 0, 1 };
            var resultado = from num in numeros.Take(5).Skip(3) select num;
            int[] teste = { 1, 2 };
            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void TestarSeAPaginacaoEstaCorreta()
        {
            //Arrange
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao()
            {
                PaginaAtual = 2,
                ItensTotal = 28,
                ItensPorPagina = 10
            };
            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(

                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                ) ;
        }
    }
}
