using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;


namespace biblioteka
{
    /// <summary>
    /// Klasa obsługująca wyświetlanie listy zaległości w oddawaniu książek
    /// </summary>
    public partial class arrears : Page
    {
        public arrears()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Przypisanie do zmiennej adresu gdzie przechowywana jest baza danych
        /// </summary>
        string dbConnectionString = @"Data Source=..\..\Baza\Ksiazki.db;Version=3;";

        /// <summary>
        /// Metoda wywoływana po naciśnięciu na przycisk załaduj tabelę
        /// </summary>
          private void load_table_txt_Click(object sender, RoutedEventArgs e)
        {

            ///Utworzenie nowego połączenia z bazą danych
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            try
            {

                sqliteCon.Open();
                ///Zmienna Query przechowuje komendę wysyłaną do bazy SQLite, Tutaj jest to wyświetlenie wszystkich wypożyczeń gdzie data wypożyczenia jest starsza niż 14 dni
                string Query = "select IDWypozyczenia, Tytuły, date(Data_wypozyczenia), Imie, Nazwisko, IDUcznia from Wypozyczenia  where Data_wypozyczenia <date('now' ,'-14 days')";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                ///Utworzenie komendy i jej wykonanie
                createCommand.ExecuteNonQuery();

                ///Wypełnienie tabeli dataGrid wartościami z tabeli Wypozyczenia
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable("Wypozyczenia");
                dataAdp.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                ///Zakończenie połączenia z bazą
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
