using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace biblioteka
{
    /// <summary>
    /// Klasa obsługująca logikę wisoku MainMenu
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

                

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        /// <summary>
        /// Metoda obsługująca zdarzenie po naciśnięciu na przycisk książki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClickP1(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
           
            ///Otwarcie nowej strony book_list
            Main.Content = new book_list();

        }



        /// <summary>
        /// Metoda obsługująca zdarzenie po naciśnięciu na przycisk wypożyczalnia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClickP2(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            ///Otwarcie nowej strony order_list
            Main.Content = new order_list();

        }


        /// <summary>
        /// Metoda obsługująca zdarzenie po naciśnięciu na przycisk zaległości
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClickP3(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            ///Otwarcie nowej strony arrears
            Main.Content = new arrears();

        }


        /// <summary>
        /// Metoda obsługująca zdarzenie po naciśnięciu na przycisk oddziały
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClickP4(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            ///Otwarcie nowej strony contact
            Main.Content = new contact();

        }

    }
}
