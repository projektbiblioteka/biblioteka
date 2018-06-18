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
    /// Interaction logic for order_list.xaml
    /// </summary>
    public partial class order_list : Page
    {
        public order_list()
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
                ///Zmienna Query przechowuje komendę wysyłaną do bazy SQLite, Tutaj jest to wyświetlenie wszystkich rekordów z tabeli Wypozyczenia
                string Query = "select IDWypozyczenia, Tytuły, date(Data_wypozyczenia), Imie, Nazwisko, IDUcznia from Wypozyczenia  ";
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

        /// <summary>
        /// Metoda wywoływana po naciśnięciu na przycisk dodaj (wypożyczenie)
        /// </summary>
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą
    

            sqliteCon.Open();
            ///Zmienna Querz przechowuje komendę wysyłaną do bazy SQLite, pobierającą wartość indeksującą ostatni wiersz w tabeli
            string Queryz = "select seq from sqlite_sequence where name='Wypozyczenia'; ";
            SQLiteCommand lastrowid = new SQLiteCommand(Queryz, sqliteCon);
            lastrowid.ExecuteNonQuery();
            ///Wykonanie komendy

            ///Konwersja otrzymanych wartości do typu int
            int newId = Convert.ToInt32(lastrowid.ExecuteScalar());
            newId = newId + 1;
            
            ///Przypisanie do zmiennej datex wartości daty w formacie yyyy-MM-dd
            string datex = DateTime.Now.ToString("yyyy-MM-dd");
            sqliteCon.Close();
            ///Zamknięcie połączenia

            MessageBox.Show(newId.ToString());
            try
            {
                ///Ponowne otwarcie połączenia z bazą
                sqliteCon.Open();

                ///Zmienna Query przechowuje komendę umieszczającą w tabeli Wypożyczenia nowy rekord
                string Query = "insert into Wypozyczenia (IDWypozyczenia, Tytuły, Data_wypozyczenia, Imie, Nazwisko, IDUcznia) values('" + newId + "',  '" + this.tytuly_txtbx.Text + "', '" + datex + "' , '" +this.imie_ucznia_txtbx.Text + "', '" + this.nazwisko_ucznia_txtbx.Text + "', '" + this.id_ucznia_txtbx.Text + "')";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                ///Utworzenie i wykonanie polecenia
                createCommand.ExecuteNonQuery();


                MessageBox.Show("Zapiano");
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Metoda wywoływana po naciśnięciu na przycisk usuń
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą
            try
            {
                sqliteCon.Open();
                
                ///Zmienna Query przechowuje komendę która usuwa odpowiedni rekord z tabeli Wypożyczenia
                string Query = "delete from Wypozyczenia where IDWypozyczenia='" + this.id_wypozyczenia_txtbx.Text + "'";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                ///Utworzenie i wykonanie polecenia
                createCommand.ExecuteNonQuery();

                MessageBox.Show("Usunieto");
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}


