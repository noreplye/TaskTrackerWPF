using Project_3;
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
using System.Windows.Shapes;

namespace Project_3_main_window
{
    /// <summary>
    /// Логика взаимодействия для scroll.xaml
    /// </summary>
    public partial class scroll : Window
    {
        public scroll()
        {
            InitializeComponent();
        }
        private void go_to_window(object sender, RoutedEventArgs e)
        {
            boards bord = new boards();
            bord.Show();
            Hide();
        }
        private void edit_text (object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
