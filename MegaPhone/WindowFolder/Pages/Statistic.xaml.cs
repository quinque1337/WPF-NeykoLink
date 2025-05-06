using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
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
using LiveCharts;
using LiveCharts.Wpf;
using System.Globalization;

namespace MegaPhone.WindowFolder.Pages
{
    public partial class Statistic : Page
    {
        public SeriesCollection TaskSeries { get; set; }
        public List<string> Labels { get; set; }
        public Statistic()
        {
            InitializeComponent();
            LoadChartData();
            LoadStatistics();
            LoadBirthdayList();
            DataContext = this;
        }

        private void LoadChartData()
        {
            // Загружаем данные о выполненных задачах
            var data = App.db.Tasks
                .GroupBy(t => t.user_id)  // Группировка по имени сотрудника
                .Select(g => new
                {
                    EmployeeName = g.Key,
                    TaskCount = g.Count()
                })
                .ToList();

            // Проверка данных и создание списка меток
            Labels = data.Select(d => App.db.Users.FirstOrDefault(u => u.id == d.EmployeeName)?.full_name ?? "Не найдено").ToList();


            // Создаем SeriesCollection для графика
            TaskSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Задачи",
                    Values = new ChartValues<int>(data.Select(d => d.TaskCount)), // Количество задач
                    StrokeThickness = 2

                }
            };
        }
        private void LoadStatistics()
        {
            // Общее количество задач
            int totalTasks = App.db.Tasks.Count();

            // Дата первой и последней задачи
            var firstTask = App.db.Tasks.OrderBy(t => t.date).FirstOrDefault();
            var lastTask = App.db.Tasks.OrderByDescending(t => t.date).FirstOrDefault();

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
