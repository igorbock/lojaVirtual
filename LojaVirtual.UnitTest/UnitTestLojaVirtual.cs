using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
    }
}
