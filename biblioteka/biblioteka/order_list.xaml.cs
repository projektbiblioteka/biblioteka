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

        string dbConnectionString = @"Data Source=..\..\Baza\Ksiazki.db;Version=3;";

        private void load_table_txt_Click(object sender, RoutedEventArgs e)
        {


            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            try
            {

                sqliteCon.Open();
                string Query = "select IDWypozyczenia, Tytuły, date(Data_wypozyczenia), Imie, Nazwisko, IDUcznia from Wypozyczenia  ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();

                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable("Wypozyczenia");
                dataAdp.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);


                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą
    

            sqliteCon.Open();
            string Queryz = "select seq from sqlite_sequence where name='Wypozyczenia'; ";
            SQLiteCommand lastrowid = new SQLiteCommand(Queryz, sqliteCon);
            lastrowid.ExecuteNonQuery();
            int newId = Convert.ToInt32(lastrowid.ExecuteScalar());
            newId = newId + 1;
            String data = DateTime.Now.ToString("yyyy.MM.dd");
            string datex = DateTime.Now.ToString("yyyy-MM-dd");
            sqliteCon.Close();
            MessageBox.Show(newId.ToString());
            try
            {
                sqliteCon.Open();
                string Query = "insert into Wypozyczenia (IDWypozyczenia, Tytuły, Data_wypozyczenia, Imie, Nazwisko, IDUcznia) values('" + newId + "',  '" + this.tytuly_txtbx.Text + "', '" + datex + "' , '" +this.imie_ucznia_txtbx.Text + "', '" + this.nazwisko_ucznia_txtbx.Text + "', '" + this.id_ucznia_txtbx.Text + "')";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Zapiano");
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą
            try
            {
                sqliteCon.Open();
                
                string Query = "delete from Wypozyczenia where IDWypozyczenia='" + this.id_wypozyczenia_txtbx.Text + "'";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
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


