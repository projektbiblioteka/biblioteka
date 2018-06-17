﻿using System;
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
    public partial class arrears : Page
    {
        public arrears()
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
                string Query = "select IDWypozyczenia, Tytuły, date(Data_wypozyczenia), Imie, Nazwisko, IDUcznia from Wypozyczenia  where Data_wypozyczenia <date('now' ,'-14 days')";
                //string Query = "select IDWypozyczenia, Tytuły, Data_wypozyczenia, Imie, Nazwisko, IDUcznia from Wypozyczenia  where Data_wypozyczenia > '2018-05-30'";
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

        
    }
}