using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class boards : Window
    {
        int userId;
        int boardId;
        public boards()
        {
            InitializeComponent();
        }
        private void go_to_add_task(object sender, RoutedEventArgs e)
        {
            //  AddTask addTask = new AddTask();
            //  addTask.Show();


            Column(1, null);
            BordPanel.Children.Clear();
            foreach (var item in BL.GetColumns(boardId))
            {
                BordPanel.Children.Add(Column(2, item));
            }


        }
        public boards(int userId, int boardId)
        {
            InitializeComponent();
            this.userId = userId;
            this.boardId = boardId;
            foreach (var item in BL.GetColumns(boardId))
            {
                BordPanel.Children.Add(Column(2, item));
            }
            
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
        private Border Column(int select,Column column)
        {
            Border bord = new Border()
            {
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Padding = new Thickness(15),
                CornerRadius = new CornerRadius(10),

            };
            



            StackPanel stackPanel = new StackPanel();
            
            TextBlock BordName = new TextBlock()
            {
                
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            if (select == 1)
            {
                TaskName Bord_Name = new TaskName();
                Bord_Name.ShowDialog();
                BL.AddColumn(boardId, Bord_Name.Naming);
                return null;
            }
            if (select == 2)
            {
                BordName.Text = column.name;
                stackPanel.Children.Add(BordName);

                bord.Name = BordName.Text;

                stackPanel.Name = bord.Name; // МАКСИМ!! ТУТ Я НАЗЫВАЮ ВСЕ ИМЕНЕМ, КОТОРОЕ ВБИВАЮ ЧЕРЕЗ ТАСКНЭЙМ, МОЖЕШЬ СДЕЛАТЬ ТАК, ЧТОБЫ ПРИ СОЗДАНИИ ЭТО НАЗВАНИЕ ЗАПОМИНАЛОСЬ, ДЛЯ ГЕНЕРАЦИИ ТАКОЙ ЖЕ ИКОНКИ!!!

                var reName = new Button
                {
                    Margin = new Thickness(10),
                    Width = 225,
                    Height = 40,
                    Content = "Rename",

                };
                reName.Click += (s, e) => //Максим, добавил кнопку для переименования, тут надо в бдшке поменять delete.Name, stackPanel.Name, bord.Name, BordName.Text на Bord_Name.Naming
                {
                    TaskName Bord_Name = new TaskName();
                    Bord_Name.ShowDialog();
                    BL.RenameColumn(column.id,Bord_Name.Naming);
                    BordPanel.Children.Clear();
                    foreach (var item in BL.GetColumns(boardId))
                    {
                        BordPanel.Children.Add(Column(2, item));
                    }
                };

                var delete = new Button
                {
                    Margin = new Thickness(10),
                    Width = 225,
                    Height = 40,
                    Content = "Delete Card",
                    Name = bord.Name,
                    Background = new SolidColorBrush(Colors.DarkRed),
                };
                var Add = new Button
                {
                    Margin = new Thickness(10),
                    Width = 225,
                    Height = 40,
                    Content = "Add Task",

                };
                // delete.Click += new RoutedEventHandler(DeleteCard);
                delete.Click += (s, e) =>
                {
                    BL.RemoveColumn(column.id);
                    BordPanel.Children.Clear();
                    foreach (var item in BL.GetColumns(boardId))
                    {
                        BordPanel.Children.Add(Column(2, item));
                    }
                    
                };
                Add.Click += (s, e) =>
                {
                    var task = new Button
                    {
                        Margin = new Thickness(10),
                        Background = new SolidColorBrush(Colors.White),
                        Width = 225,
                        Height = 40,
                        Foreground = new SolidColorBrush(Colors.Black)
                    };
                    string NameOfTask;
                    TaskName newTaskName = new TaskName();
                    newTaskName.ShowDialog();
                    NameOfTask = newTaskName.Naming;
                    task.Name = NameOfTask;
                    task.Content = NameOfTask;



                    stackPanel.Children.Add(task);



                    task.Click += new RoutedEventHandler(go_to_task_desc);

                };

                stackPanel.Children.Add(reName);
                stackPanel.Children.Add(Add);
                stackPanel.Children.Add(delete);
                bord.Child = stackPanel;
            }
            return (bord);
        }

        private void DeleteCard(object sender, RoutedEventArgs e)
        {
            Border bordsss = (Border)LogicalTreeHelper.FindLogicalNode(BordPanel, "Bord1");
            BordPanel.Children.Remove(bordsss);
        }

        private void go_to_task_desc(object sender, RoutedEventArgs e)
        {
            
            scroll sc = new scroll();
            sc.Width = Width; 
            sc.Height = Height;
            sc.Top = Top;
            sc.Left = Left;
            sc.Show();
            Hide();
            Close();
        }

        private void go_to_RealBoard(object sender, RoutedEventArgs e)
        {
            RealBoardWindow window = new RealBoardWindow(userId);
            window.Top = Top;
            window.Left = Left;
            window.Width = Width;
            window.Height = Height;
            window.Show();
            Hide();
            Close();
        }

        private Button AddTask(object sender, RoutedEventArgs e)
        {
            var task = new Button
            {
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.White),
                Width = 225,
                Height = 40,
            };

            return (task);
       //     StackPanel sus = (StackPanel)LogicalTreeHelper.FindLogicalNode(BordPanel, "Bord1");
            
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
/*
 Юзер (логин, пароль), Доска (название, владелец, тип: частная или общественная, столбцы((айди))), столцы(название, цели) 
 цели(участника добавить, название, содержание(в тасках))
 */