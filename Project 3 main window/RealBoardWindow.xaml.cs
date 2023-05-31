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
            board.Name = "Board1";
           
            StackPanel stackPanel = new StackPanel();
            if (names != null)
            {
                foreach (string name in names)
                {
                    stackPanel.Children.Add(Board(name, stackPanel, stackPanel.Children.Count));
                }
            }
            
            

            stackPanel.Name = board.Name;
            var delete = new Button
            {
                Margin = new Thickness(10),
                Width = 225,
                Height = 40,
                Content = "Delete Board"
            };
            var view = new Button
            {
                Margin = new Thickness(10),
                Width = 225,
                Height = 40,
                Content = "ViewTasks"
            };
            
            
            
            delete.Click += new RoutedEventHandler(DeleteBoard);
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
        
        private void DeleteBoard(object sender, RoutedEventArgs e)
        {
            Border bordsss = (Border)LogicalTreeHelper.FindLogicalNode(BordPanel, "Bord1");
            BordPanel.Children.Remove(bordsss);
        }
        private Button Board(string name, StackPanel cards, int index)
        {
            var task = new Button
            {
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.White),
                Width = 225,
                Height = 40,
                Content = name
            };
            
            //    task.Click += new RoutedEventHandler(AddTask);
            return task;
        }
        private StackPanel Stack()
        {
            List<string> list = new List<string> { "govno" };
            BordPanel.Children.Add(Column(list));
            
        
          
            return (BordPanel);
        }
    }


    
}