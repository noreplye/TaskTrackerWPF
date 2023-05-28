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
    /// Логика взаимодействия для TaskName.xaml
    /// </summary>
    public partial class TaskName : Window
    {
        public string Naming {get; set;}
        public TaskName()
        {
            InitializeComponent();
        }
        private void click_to_done_name(object sender, RoutedEventArgs e)
        {
            Naming = Element_Name.Text.Trim();
            this.Close();
        }

    }
}
