using LiveCharts.Wpf;
using LiveCharts;
using MegaPhone.DataFolder;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System;
using System.Windows.Controls;

namespace MegaPhone.WindowFolder.Pages.EmployeePanelPages
{
    public partial class StatisticEmployee : Page
    {
        public SeriesCollection TaskSeries { get; set; }
        public List<string> Labels { get; set; }
        private Users currentUser;

        public StatisticEmployee() // Принимаем текущего пользователя
        {
            InitializeComponent();
            currentUser = App.CurrentUser; // Сохраняем текущего пользователя
            LoadChartData();
            LoadStatistics();
            LoadBirthdayList();
            DataContext = this;
        }

        private void LoadChartData()
        {
            // Загружаем данные о выполненных задачах только для текущего сотрудника
            var data = App.db.Tasks
                .Where(t => t.user_id == currentUser.id) // Фильтруем по ID текущего сотрудника
                .GroupBy(t => t.user_id)
                .Select(g => new
                {
                    EmployeeName = g.Key,
                    TaskCount = g.Count()
                })
                .ToList();

            // Проверка данных и создание списка меток
            Labels = new List<string> { currentUser.full_name };

            // Создаем SeriesCollection для графика
            TaskSeries = new SeriesCollection
            {
                
                new ColumnSeries
                {
                    Title = "Задачи",
                    Values = new ChartValues<int>(data.Select(d => d.TaskCount)), // Количество задач
                    StrokeThickness = 2
                }
                
            };
        }

        private void LoadStatistics()
        {
            // Общее количество задач для текущего сотрудника
            int totalTasks = App.db.Tasks.Count(t => t.user_id == currentUser.id);

            // Дата первой и последней задачи
            var firstTask = App.db.Tasks
                .Where(t => t.user_id == currentUser.id)
                .OrderBy(t => t.date)
                .FirstOrDefault();
            var lastTask = App.db.Tasks
                .Where(t => t.user_id == currentUser.id)
                .OrderByDescending(t => t.date)
                .FirstOrDefault();

            // Заполнение TextBlock'ов
            TaskCountText.Text = $"Общее количество задач: {totalTasks}";
            FirstTaskText.Text = $"Первая задача: {firstTask?.date.ToString("dd MMMM yyyy", new CultureInfo("ru-RU")) ?? "Не найдено"}";
            LastTaskText.Text = $"Последняя задача: {lastTask?.date.ToString("dd MMMM yyyy", new CultureInfo("ru-RU")) ?? "Не найдено"}";
        }

        private void LoadBirthdayList()
        {
            var today = DateTime.Today;

            var users = App.db.Users
    .Where(u => u.birth_date != null)
    .ToList();

            var upcomingBirthdays = users
                .Select(u =>
                {
                    DateTime nextBirthday;

                    try
                    {
                        var thisYearBirthday = new DateTime(today.Year, u.birth_date.Value.Month, u.birth_date.Value.Day);
                        nextBirthday = thisYearBirthday < today
                            ? new DateTime(today.Year + 1, u.birth_date.Value.Month, u.birth_date.Value.Day)
                            : thisYearBirthday;
                    }
                    catch
                    {
                        nextBirthday = new DateTime(today.Year + 1, 3, 1); // запасной вариант
                    }

                    return new
                    {
                        u.full_name,
                        NextBirthday = nextBirthday
                    };
                })
                .OrderBy(x => x.NextBirthday)
                .Take(5)
                .ToList();

            BirthdayList.ItemsSource = upcomingBirthdays
                .Select(x => new { DisplayText = $"{x.full_name} — {x.NextBirthday:dd MMMM}" })
                .ToList();
        }
    }
}
