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
    public partial class boards : Window
    {
        public boards()
        {
            InitializeComponent();
        }
        private void go_to_add_board(object sender, RoutedEventArgs e)
        {
            //  AddTask addTask = new AddTask();
            //  addTask.Show();
            Stack();
            
        }

        //public void CreateButton (object sender, RoutedEventArgs e)
        //{
        //    int StartX = 100;
        //    int StartY = 100;

        //    Button new_button = new Button();
            
        //    new_button.Width = 100;
        //    new_button.Height = 100;
        //    Panelka.Children



        //}
        private Border Column(List<string> names)
        {
            Border bord = new Border()
            {
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Padding = new Thickness(10),
                CornerRadius = new CornerRadius(10),
                
            };
            bord.Name = "Bord1";
           
            StackPanel stackPanel = new StackPanel();
            if (names != null)
            {
                foreach (string name in names)
                {
                    stackPanel.Children.Add(Card(name, stackPanel, stackPanel.Children.Count));
                }
            }
            stackPanel.Name = bord.Name;
            var delete = new Button
            {
                Margin = new Thickness(10),
                Width = 225,
                Height = 40,
                Content = "Delete Card"
            };
            var Add = new Button
            {
                Margin = new Thickness(10),
                Width = 225,
                Height = 40,
                Content = "Add Task"
            };
            delete.Click += new RoutedEventHandler(DeleteCard);
            Add.Click += new RoutedEventHandler(AddTask);
            stackPanel.Children.Add(Add);
            stackPanel.Children.Add(delete);
            bord.Child = stackPanel;
            return (bord);
        }

        private void DeleteCard(object sender, RoutedEventArgs e)
        {
            Border bordsss = (Border)LogicalTreeHelper.FindLogicalNode(BordPanel, "Bord1");
            BordPanel.Children.Remove(bordsss);
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            var task = new Button
            {
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.White),
                Width = 225,
                Height = 40,
            };

       //     StackPanel sus = (StackPanel)LogicalTreeHelper.FindLogicalNode(BordPanel, "Bord1");
            
        }

        private StackPanel Stack()
        {
            List<string> list = new List<string> { "govno" };
            BordPanel.Children.Add(Column(list));
            

          
            return (BordPanel);
        }

        private Button Card(string name, StackPanel cards, int index)
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

        //private 

        //private void Task_Click(object sender, RoutedEventArgs e)
        //{
         //   throw new NotImplementedException();
       // }

        
    }   


}
