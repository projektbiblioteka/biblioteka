using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


using biblioteka;


    
namespace bibliotekaTests
{
    
    [TestClass]
    public class wypozyczenia_lastrownumber_test
    {
        [TestMethod]
        public void testowanie()
        {
            int expected = 16;

            int actual = biblioteka.Dodawaniewypozyczenia.loadlastrownumber();

            Assert.AreEqual(expected, actual, 0.001, "Metoda niepoprawnie wczytuje numer ostatniego wiersza");
        }
    }
}
