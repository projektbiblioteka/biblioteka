using System;
using System.Data.SQLite;



namespace biblioteka
{
    /// <summary>
    /// Klasa obsługująca pobieranie id ostatniego wypożyczenia oraz inkrementacja go o 1
    /// </summary>

    public class Dodawaniewypozyczenia
    {

        /// <summary>
        /// Metoda pobierająca numer ostatniego wiersza
        /// </summary>
        /// <returns>
        /// Zwraca zmienną typu int - newId
        /// </returns>
        public static int loadlastrownumber()
        {

            ///Przypisanie do zmiennej adresu gdzie przechowywana jest baza danych
            string dbConnectionString = @"Data Source=..\..\..\Biblioteka\Baza\Ksiazki.db;Version=3;";

            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą


            sqliteCon.Open();
            //Zmienna Query przechowuje komendę wysyłaną do bazy SQLite w tym przypadku będzie to pobranie liczby indeksującej ostatni wiersz
            string Queryz = "select seq from sqlite_sequence where name='Wypozyczenia'; ";
            ///Utworzenie komendy i jej wykonanie
            SQLiteCommand lastrowid = new SQLiteCommand(Queryz, sqliteCon);
            lastrowid.ExecuteNonQuery();
            ///Konwersja pobranej wartości do typu integer
            int newId = Convert.ToInt32(lastrowid.ExecuteScalar());
            ///Zwiększenie wartości o 1
            newId = newId + 1;

            ///Zakończenie połączenia z bazą
            sqliteCon.Close();

            ///Zwrócenie powiększonej o 1 liczby ostatniego wiersza
            return newId;
        }




    }
}
