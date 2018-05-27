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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);


            GridCoursor.Margin = new Thickness(10 + (150 * index), 45, 0, 10);

            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnClickP1(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
           GridCoursor.Margin = new Thickness(10 + (150 * index), 45, 0, 10);
            Main.Content = new book_list();

        }
    }
}
