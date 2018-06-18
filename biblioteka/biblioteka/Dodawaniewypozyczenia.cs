using System;
using System.Data.SQLite;



namespace biblioteka
{
    public class Dodawaniewypozyczenia
    {
        
        public static int loadlastrownumber()
        {
            
            string dbConnectionString = @"Data Source=..\..\..\Biblioteka\Baza\Ksiazki.db;Version=3;";

            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą


            sqliteCon.Open();
            string Queryz = "select seq from sqlite_sequence where name='Wypozyczenia'; ";
            SQLiteCommand lastrowid = new SQLiteCommand(Queryz, sqliteCon);
            lastrowid.ExecuteNonQuery();
            int newId = Convert.ToInt32(lastrowid.ExecuteScalar());
            newId = newId + 1;
            sqliteCon.Close();

            return newId;
        }




    }
}
