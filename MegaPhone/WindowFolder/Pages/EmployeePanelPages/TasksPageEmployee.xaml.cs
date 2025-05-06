using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MegaPhone.DataFolder;
using MegaPhone.ClassFolder;
using MegaPhone.WindowFolder.Buttons_DataBase;
using System.Threading.Tasks;
using MegaPhone.WindowFolder.Buttons_DataBase.Buttons_EpmloyeePanel;

namespace MegaPhone.WindowFolder.Pages.EmployeePanelPages
{
    public partial class TasksPageEmployee : Page
    {
        public TasksPageEmployee()
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
            // Фильтрация задач по текущему сотруднику
            TaskDG.ItemsSource = App.db.Tasks
                .Where(t => t.user_id == App.CurrentUser.id)  // Отфильтровываем по текущему сотруднику
                .OrderBy(t => t.date)
                .ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTB.Text.ToLower();
            TaskDG.ItemsSource = App.db.Tasks
                .Where(t => t.user_id == App.CurrentUser.id && // Отфильтровываем по текущему сотруднику
                           (t.description.ToLower().Contains(searchText)
                           || t.Users.full_name.ToLower().Contains(searchText)
                           || t.Categories.name.ToLower().Contains(searchText)
                           || t.date.Year.ToString().Contains(searchText)   // Преобразуем год в строку для поиска по году
                           || t.date.Month.ToString().Contains(searchText)  // Преобразуем месяц в строку для поиска по месяцу
                           || t.date.Day.ToString().Contains(searchText)))  // Преобразуем день в строку для поиска по дню
                .OrderBy(t => t.date)
                .ToList();

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Add_Task addToDB = new Add_Task();
            addToDB.ShowDialog();
        }

        private void Redact(object sender, RoutedEventArgs e)
        {
            var selectedTask = TaskDG.SelectedItem as Tasks;
            if (selectedTask == null)
            {
                MB.Info("Выберите задачу для редактирования.");
                return;
            }

            // Создаем и открываем окно редактирования задачи, передаем в него выбранную задачу
            Edit_Task editTaskWindow = new Edit_Task(selectedTask);
            editTaskWindow.ShowDialog();

            // Обновляем список задач после редактирования
            LoadTasks();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var selectedTask = TaskDG.SelectedItem as Tasks;
            if (selectedTask == null)
            {
                MB.Info("Выберите задачу для удаления.");
                return;
            }

            var result = MB.Question(
                "Вы действительно хотите удалить выбранную задачу?");

            if (result == true)
            {
                try
                {
                    App.db.Tasks.Remove(selectedTask);
                    App.db.SaveChanges();
                    MB.Info("Задача успешно удалена.");
                    LoadTasks(); // Обновляем таблицу
                }
                catch (Exception ex)
                {
                    MB.Error($"Ошибка при удалении: {ex.Message}");
                }
            }
        }
    }
}