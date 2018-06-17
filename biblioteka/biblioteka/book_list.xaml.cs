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
    /// Interaction logic for book_list.xaml
    /// </summary>
    public partial class book_list : Page
    {
        public book_list()
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
                string Query = "select IDKsiazki, Tytul, Autor, Rok_Wydania, Wydawnictwo, Filia from Ksiazki  ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();

                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable("Ksiazki");
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
            try
            {
                sqliteCon.Open();
                string Query = "insert into Ksiazki (IDKsiazki, Tytul, Autor, Rok_Wydania, Wydawnictwo, Filia) values('" + this.ksiazki_id_txtbx.Text + "', '" + this.tytul_txtbx.Text + "', '" + this.autor_txtbx.Text + "', '" + this.rok_wydania_txtbx.Text + "', '" + this.wydawnictwo_txtbx.Text + "', '" + this.fillia_txtbx.Text + "')";
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

        public void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą
            try
            {
                sqliteCon.Open();
                string Query = "delete from Ksiazki where IDKsiazki='" + this.ksiazki_id_txtbx.Text + "'";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Usunięto");
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą
            try
            {
                sqliteCon.Open();
                string Query = "update Ksiazki set IDKsiazki='" + this.ksiazki_id_txtbx.Text + "', Tytul='" + this.tytul_txtbx.Text + "', Autor='" + this.autor_txtbx.Text + "', Rok_Wydania='" + this.rok_wydania_txtbx.Text + "', Wydawnictwo='" + this.wydawnictwo_txtbx.Text + "', Filia='" + this.fillia_txtbx.Text + "' where IDKsiazki='" + this.ksiazki_id_txtbx.Text + "' ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Zaktualizowano");
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
