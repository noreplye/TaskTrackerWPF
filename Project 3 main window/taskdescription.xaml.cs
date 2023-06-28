using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using static System.Net.Mime.MediaTypeNames;

namespace Project_3_main_window
{
    /// <summary>
    /// Логика взаимодействия для scroll.xaml
    /// </summary>
    public partial class scroll : Window
    {
        int userId {  get; set; }
        int columnId { get; set; }
        int boardId { get; set; }
        int id { get; set; }
        public string desc { get; set; }
        public scroll()
        {
            InitializeComponent();
        }
        public scroll(int userId,int boardId,int columnId,int id)
        {   
            this.userId = userId;
            this.columnId = columnId;
            this.boardId = boardId;
            this.id = id;
            InitializeComponent();

        }
        private void go_to_window(object sender, RoutedEventArgs e)
        {
            boards bord = new boards(userId, boardId);
            bord.Show();
            bord.Top = Top; bord.Left = Left;
            bord.Width = Width; bord.Height = Height;
            BL.TaskDescEdit(desc_txt.Text, id);
            Hide();
            Close();
        }
        private void edit_text (object sender, TextChangedEventArgs e)
        {
            desc = desc_txt.Text;
            BL.TaskDescEdit(desc_txt.Text, id);

        }
        private void save_text(object sender, RoutedEventArgs e)
        {
            desc = desc_txt.Text;
            BL.TaskDescEdit(desc_txt.Text, id);

        }
        private void reName_Task(object sender, RoutedEventArgs e)
        {
            TaskName Bord_Name = new TaskName();
            Bord_Name.ShowDialog();
            BL.RenameTask(id, Bord_Name.Naming);

        }
        private void delete_Task(object sender, RoutedEventArgs e)
        {
            BL.DeleteTask(id);
            boards bord = new boards(userId, boardId);
            bord.Show();
            bord.Top = Top; bord.Left = Left;
            bord.Width = Width; bord.Height = Height;
            Hide();
            Close();
        }
    }
}
