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

    /// <summary>
    /// Klasa testowa
    /// </summary>
    [TestClass]
    public class wypozyczenia_lastrownumber_test
    {
        /// <summary>
        /// Metoda testowanie sprawdza czy pobrany numer ostatniego rekordu z tabeli Wypożyczenia, rzeczywiście jest poprawny.
        /// </summary>
        [TestMethod]
        public void testowanie()
        {
            ///Spodziewana wartość to 13
            int expected = 13;

            ///Przypisanie do zmiennej actual, wyniku otrzymanego w rezultacie działania metody
            int actual = biblioteka.Dodawaniewypozyczenia.loadlastrownumber();

            ///Sprawdzenie czy otrzymana wartość jest zgodna z oczekiwaniami, jeżeli nie zostanie zwrócony błąd.
            Assert.AreEqual(expected, actual, 0.001, "Metoda niepoprawnie wczytuje numer ostatniego wiersza");
        }
    }
}
