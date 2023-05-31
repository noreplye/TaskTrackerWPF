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

namespace Project_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void click_to_end_reg(object sender, RoutedEventArgs e)  //получаю данные для регистрации, Trim - не учитывает пробелы до и после ввода
        {
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();
            string ret_password = RepeatPassword.Password.Trim();
            
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
            else if (password != ret_password)
            {
                RepeatPassword.ToolTip = "Пароль не совпадает";
                RepeatPassword.Background = Brushes.Red;
            }
            else if (BL.CheckLogin(login))
            {
                Login.ToolTip = "Логин уже занят";
                Login.Background = Brushes.Red;
            }
            else 
            {
                Login.ToolTip = "";
                Login.Background = Brushes.SeaGreen;
                Password.ToolTip = "";
                Password.Background = Brushes.SeaGreen;
                RepeatPassword.ToolTip = "";
                RepeatPassword.Background = Brushes.SeaGreen;
                
                BL.Registration(login, password);

                MessageBox.Show("Регистрация завершена!");

                SignInWindow signInWindow = new SignInWindow();
                signInWindow.Show();
                Hide();
                Close();
            }
        }
        
        private void go_to_sign(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            Hide();
            Close();
        }

       
    }
}
