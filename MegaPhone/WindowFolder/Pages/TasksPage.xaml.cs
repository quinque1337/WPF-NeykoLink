using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MegaPhone.DataFolder;
using MegaPhone.ClassFolder;
using MegaPhone.WindowFolder.Buttons_DataBase;
using System.Threading.Tasks;

namespace MegaPhone.WindowFolder.Pages
{
    public partial class TasksPage : Page
    {
        public TasksPage()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            LoadTasks();
        }

        private void LoadTasks()
        {
            TaskDG.ItemsSource = App.db.Tasks
                .OrderBy(t => t.date)
                .ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTB.Text.ToLower();

            TaskDG.ItemsSource = App.db.Tasks
                .AsEnumerable()
                .Where(t => t.description.ToLower().Contains(searchText)
                         || t.Users.full_name.ToLower().Contains(searchText)
                         || t.Categories.name.ToLower().Contains(searchText)
                         || t.date.ToString("dd.MM.yyyy").Contains(searchText))
                .OrderBy(t => t.date)
                .ToList();


        }
    }
}