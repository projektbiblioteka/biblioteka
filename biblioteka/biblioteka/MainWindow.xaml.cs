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
namespace biblioteka
{
    /// <summary>
    /// Klasa zawierająca informacje na temat logiki MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString = @"Data Source=..\..\Baza\Ksiazki.db;Version=3;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            ///Utworzenie nowego połączenia z bazą danych
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
     
            try {
                sqliteCon.Open();
                ///Zmienna Query przechowuje komendę wysyłaną do bazy SQLite, tutaj jest to pobranie wszystkich rekordów z tabeli Users
                string Query = "select * from Users where Username='" + this.txt_username.Text + "' and Password ='" + this.txt_password.Password + "' ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                ///Utworzenie komendy i jej wykonanie
                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();

                ///Zmienna count posłuży do identyfikacji odpowiedzi jaką otrzymamy po naciśnięciu przycisku zaloguj
                int count = 0;

                //dr.Read() przechodzi po rekordach pobranych z bazy
                while (dr.Read())
                {
                    count++;
                }

                ///Jeżeli count jest równe 1 to oznacza że istnieje taki rekord w bazie
                if (count == 1)
                {
                    MessageBox.Show("Wpisano poprawne dane logowania. Witaj!");
                    ///Przejście do menu głównego
                    MainMenu objFrmMain = new MainMenu();
                    this.Hide();
                    objFrmMain.Show();


                }
                
                ///Jeżeli count jest mniejsze od 1, oznacza to że nie znaleziono żadnego takiego użytkownika w bazie
                if (count < 1)
                {
                    MessageBox.Show("Wpisano błędny login bądź hasło. Spróbuj ponownie!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Zdarzenie obsługiwane po naciśnięciu na przycisk wyjście
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
