using Project_3_main_window;
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
using System.Xml.Linq;

namespace Project_3
{
    /// <summary>
    /// Логика взаимодействия для boards.xaml
    /// </summary>

    public partial class RealBoardWindow: Window
    {
        int userId;
        public RealBoardWindow()
        {
            InitializeComponent();
        }

        private void go_to_sign_window(object sender, EventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Top = Top;
            signInWindow.Left = Left;
            signInWindow.Width = Width;
            signInWindow.Height = Height;
            signInWindow.Show();
            Hide();
            Close();
        }
        private void go_to_add_board(object sender, RoutedEventArgs e)
        {
            //  AddTask addTask = new AddTask();
            //  addTask.Show();
            Stack(1);
            
        }
        public RealBoardWindow(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            Stack(2);

        }


        private Border Column(int select,Board myBoard)
        {

            if (select == 1)
            {
                TaskName Bord_Name = new TaskName();
                Bord_Name.ShowDialog();
                BL.AddBoard(Bord_Name.Naming, 1, userId);
                Stack(2);
                return null;
            }

            Border board = new Border()
            {
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Padding = new Thickness(10),
                CornerRadius = new CornerRadius(10),
                
            };
            
           
            StackPanel stackPanel = new StackPanel();
            
            TextBlock BordName = new TextBlock()
            {

                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            



            

            

            if (select == 2)
            {

                BordName.Text = myBoard.name;
                stackPanel.Children.Add(BordName);
                board.Name = BordName.Text; // МАКСИМ!! ТУТ Я НАЗЫВАЮ ВСЕ ИМЕНЕМ, КОТОРОЕ ВБИВАЮ ЧЕРЕЗ ТАСКНЭЙМ, МОЖЕШЬ СДЕЛАТЬ ТАК, ЧТОБЫ ПРИ СОЗДАНИИ ЭТО НАЗВАНИЕ ЗАПОМИНАЛОСЬ, ДЛЯ ГЕНЕРАЦИИ ТАКОЙ ЖЕ ИКОНКИ!!!

                stackPanel.Name = board.Name;
                var delete = new Button
                {
                    Margin = new Thickness(10),
                    Width = 225,
                    Height = 40,
                    Content = "Delete Board",
                    Background = new SolidColorBrush(Colors.DarkRed),
                    Name ="a"+ Convert.ToString(myBoard.id),
                };
                var view = new Button
                {
                    Margin = new Thickness(10),
                    Width = 100,
                    Height = 100,
                    Content = "View"
                };
                delete.Click += (s, e) =>
                {
                    var myid=myBoard.id;
                    BL.RemoveBoard(myBoard.id);
                    Stack(2);
                    
                };
                view.Click += (s, e) =>
                {
                    var task = new Button
                    {
                        Margin = new Thickness(10),
                        Background = new SolidColorBrush(Colors.Black),
                        Width = 225,
                        Height = 40,
                    };
                    stackPanel.Children.Add(task);
                    boards boards = new boards();
                    boards.Show();
                    Hide();
                    Close();

                };

                var reName = new Button
                {
                    Margin = new Thickness(10),
                    Width = 225,
                    Height = 40,
                    Content = "Rename",

                };
                reName.Click += (s, e) =>
                {
                    TaskName Bord_Name = new TaskName();
                    Bord_Name.ShowDialog();
                    BordName.Text = Bord_Name.Naming;
                   
                };  //Максим, добавил кнопку для переименования, тут надо в бдшке поменять delete.Name, stackPanel.Name, bord.Name, BordName.Text на Bord_Name.Naming




                //     += (s, e) =>
                // {
                //     var task = new Button
                //     {
                //         Margin = new Thickness(10),
                //         Background = new SolidColorBrush(Colors.White),
                //         Width = 225,
                //         Height = 40,
                //     };
                //     stackPanel.Children.Add(task);
                // };
                stackPanel.Children.Add(reName);
                stackPanel.Children.Add(view);
                stackPanel.Children.Add(delete);
                board.Child = stackPanel;
            }
                return (board);
           
        }
        
        //private void DeleteBoard(object sender, RoutedEventArgs e)
        //{
        //    Border bordsss = (Border)LogicalTreeHelper.FindLogicalNode(BordPanel, "Bord1");
        //    BordPanel.Children.Remove(bordsss);
        //}
      
        private StackPanel Stack(int select)
        {
            if (select == 1)
            {
                Column(select,null);
            }
            if (select == 2)
            {
                var myBoards = BL.GetMyBoards(userId);
                BordPanel.Children.Clear();
                foreach (var mb in  myBoards)
                {
                    BordPanel.Children.Add(Column(select,mb));
                }
                
            }
            
            
        
          
            return (BordPanel);
        }
    }


    
}