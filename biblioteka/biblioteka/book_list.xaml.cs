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
    /// Klasa obsługująca wyświetlanie listy wszystkich ksiązek w bazie
    /// </summary>
    public partial class book_list : Page
    {
        public book_list()
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
                ///Zmienna Query przechowuje komendę wysyłaną do bazy SQLite, Tutaj jest to wyświetlenie wszystkich rekordów z tabeli Ksiazki
                string Query = "select IDKsiazki, Tytul, Autor, Rok_Wydania, Wydawnictwo, Filia from Ksiazki  ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                ///Utworzenie komendy i jej wykonanie
                createCommand.ExecuteNonQuery();

                ///Wypełnienie tabeli dataGrid wartościami z tabeli Ksiazki
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable("Ksiazki");
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


        /// <summary>
        /// Metoda wywoływana po naciśnięciu na przycisk dodaj (książkę)
        /// </summary>
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {

            ///Utworzenie nowego połączenia z bazą danych
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
           
            try
            {
                sqliteCon.Open();
                ///Zmienna Query przechowuje komendę wysyłaną do bazy SQLite umieszczającą w niej nowy rekord
                string Query = "insert into Ksiazki (IDKsiazki, Tytul, Autor, Rok_Wydania, Wydawnictwo, Filia) values('" + this.ksiazki_id_txtbx.Text + "', '" + this.tytul_txtbx.Text + "', '" + this.autor_txtbx.Text + "', '" + this.rok_wydania_txtbx.Text + "', '" + this.wydawnictwo_txtbx.Text + "', '" + this.fillia_txtbx.Text + "')";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                ///Utworzenie komendy i jej wykonanie
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Zapiano");
                ///Zakończenie połączenia z bazą
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// Metoda wywoływana po naciśnięciu na przycisk usuń (książkę)
        /// </summary>
        public void delete_btn_Click(object sender, RoutedEventArgs e)
        {

            //Utworzenie nowego połączenia z bazą danych
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
           
            try
            {
                sqliteCon.Open();
                ///Zmienna Query przechowuje komendę wysyłaną do bazy SQLite, Tutaj jest to usuwanie książki wg. podanego ID
                string Query = "delete from Ksiazki where IDKsiazki='" + this.ksiazki_id_txtbx.Text + "'";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                ///Utworzenie komendy i jej wykonanie
                createCommand.ExecuteNonQuery();

                MessageBox.Show("Usunięto");

                ///Zakończenie połączenia z bazą
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        
        /// <summary>
        /// Metoda wywoływana po naciśnięciu na przycisk aktualizuj (książkę)
        /// </summary>
        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            ///Utworzenie nowego połączenia z bazą danych
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            
            try
            {
                sqliteCon.Open();
                ///Zmienna Query przechowuje komendę wysyłaną do bazy SQLite, Tutaj jest to wyświetlenie wszystkich wypożyczeń gdzie data wypożyczenia jest starsza niż 14 dni
                string Query = "update Ksiazki set IDKsiazki='" + this.ksiazki_id_txtbx.Text + "', Tytul='" + this.tytul_txtbx.Text + "', Autor='" + this.autor_txtbx.Text + "', Rok_Wydania='" + this.rok_wydania_txtbx.Text + "', Wydawnictwo='" + this.wydawnictwo_txtbx.Text + "', Filia='" + this.fillia_txtbx.Text + "' where IDKsiazki='" + this.ksiazki_id_txtbx.Text + "' ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);

                ///Utworzenie komendy i jej wykonanie
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Zaktualizowano");

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
