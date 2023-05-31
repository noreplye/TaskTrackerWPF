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
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void click_to_sign_in(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();

            if ((login.Length > 12) || (login.Length < 4))
            {
                Login.ToolTip = "Длина логина должна быть от 4 до 12 символов"; // ToolTip - подсказка
                Login.Background = Brushes.Red; //через Brushes меняем цвет
            }
            else if (password.Length < 8)
            {
                Login.ToolTip = "";
                Login.Background = Brushes.SeaGreen;
                Password.ToolTip = "Пароль должен быть больше 8 символов";
                Password.Background = Brushes.Red;
            }
            else
            {
                Login.ToolTip = "";
                Login.Background = Brushes.SeaGreen;
                Password.ToolTip = "";
                Password.Background = Brushes.SeaGreen;

                //boards boards = new boards();
                //boards.Show();
                //Hide();

                RealBoardWindow realBoardWindow = new RealBoardWindow();
                realBoardWindow.Show();
                Hide();
                Close();
            }
        }
        private void go_to_reg(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
            Close();
        }
    }
}
