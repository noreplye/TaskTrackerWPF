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
        public RealBoardWindow()
        {
            InitializeComponent();
        }
        private void go_to_add_board(object sender, RoutedEventArgs e)
        {
            //  AddTask addTask = new AddTask();
            //  addTask.Show();
            Stack();
            
        }
    
        
        
        private Border Column(List<string> names)
        {
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
            //if (names != null)
            //{
            //    foreach (string name in names)
            //    {
            //        stackPanel.Children.Add(Board(name, stackPanel, stackPanel.Children.Count));
            //    }
            //}
            TextBlock BordName = new TextBlock()
            {

                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            TaskName Bord_Name = new TaskName();
            Bord_Name.ShowDialog();
            BordName.Text = Bord_Name.Naming;
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
                Name = board.Name,
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
                Border bordss = (Border)LogicalTreeHelper.FindLogicalNode(BordPanel, delete.Name);
                BordPanel.Children.Remove(bordss);
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
            stackPanel.Children.Add(view);
            stackPanel.Children.Add(delete);
            board.Child = stackPanel;
            return (board);
        }
        
        //private void DeleteBoard(object sender, RoutedEventArgs e)
        //{
        //    Border bordsss = (Border)LogicalTreeHelper.FindLogicalNode(BordPanel, "Bord1");
        //    BordPanel.Children.Remove(bordsss);
        //}
      
        private StackPanel Stack()
        {
            List<string> list = new List<string> { "govno" };
            BordPanel.Children.Add(Column(list));
            
        
          
            return (BordPanel);
        }
    }


    
}