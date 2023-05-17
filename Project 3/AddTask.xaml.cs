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

namespace Project_3
{
    /// <summary>
    /// Логика взаимодействия для AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public AddTask()
        {
            InitializeComponent();
        }
        private void click_to_add_board(object sender, RoutedEventArgs e)
        {
            string data = Data.Text.Trim();
            string task = Task.Text.Trim();
            if ((data.Length < 10) || (!data.Contains(".")))
            {
                Data.ToolTip = "Неправильно введена дата, день/месяц/год разбивается \".\"";
                Data.Background = Brushes.Red;
            }
            else if (task.Length < 1)
            {
                Task.ToolTip = "Введите цель";
                Task.Background = Brushes.Red;
            }
            else
            {
                Data.ToolTip = "";
                Data.Background = Brushes.SeaGreen;
                Task.ToolTip = "";
                Task.Background = Brushes.SeaGreen;
                Hide();
                
            }
          
        }
    }
}
