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
    /// Interaction logic for MainWindow.xaml
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

            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Otwarcie połączenia z bazą
            try {
                sqliteCon.Open();
                string Query = "select * from Users where Username='" + this.txt_username.Text + "' and Password ='" + this.txt_password.Password + "' ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);

                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();

                int count = 0;
                while (dr.Read())
                {
                    count++;
                }

                if (count == 1)
                {
                    MessageBox.Show("Wpisano poprawne dane logowania. Witaj!");
                    MainMenu objFrmMain = new MainMenu();
                    this.Hide();
                    objFrmMain.Show();


                }
                
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
