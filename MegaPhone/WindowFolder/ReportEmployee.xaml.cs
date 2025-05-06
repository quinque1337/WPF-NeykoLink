using MegaPhone.ClassFolder;
using MegaPhone.DataFolder;
using MegaPhone.WindowFolder.Pages;
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

namespace MegaPhone.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для Add_Employee.xaml
    /// </summary>
    public partial class ReportEmployee : Window
    {
        public ReportEmployee()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранного сотрудника
            var employeeuser = App.CurrentUser;

            var selectedItem = PeriodComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null)
            {
                MB.Info("Период не выбран.");
                return;
            }
            string selectedPeriod = selectedItem.Content.ToString();

            // Фильтруем задачи сотрудника по выбранному периоду
            var tasks = FilterTasksByPeriod(employeeuser.id, selectedPeriod);

            // Генерация отчета в Word
            CreateWordReport(employeeuser, tasks);
        }
        private List<MegaPhone.DataFolder.Tasks> FilterTasksByPeriod(int employeeId, string period)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            switch (period.ToLower())
            {
                case "за день":
                    startDate = DateTime.Today;
                    endDate = DateTime.Today.AddDays(1).AddSeconds(-1);
                    break;
                case "за неделю":
                    startDate = DateTime.Today.AddDays(-7);
                    break;
                case "за месяц":
                    startDate = DateTime.Today.AddMonths(-1);
                    break;
                case "за год":
                    startDate = DateTime.Today.AddYears(-1);
                    break;
                case "за все время":
                    startDate = DateTime.MinValue; // Начало временной шкалы
                    break;
                default:
                    MB.Info("Неверный период.");
                    return null;
            }

            return App.db.Tasks
                .Where(t => t.user_id == employeeId && t.date >= startDate && t.date <= endDate)
                .OrderBy(t => t.date)
                .ToList();
        }
        private void CreateWordReport(Users employee, List<MegaPhone.DataFolder.Tasks> tasks)
        {
            // Запускаем Word
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            var wordDoc = wordApp.Documents.Add();

            // Настроим заголовок
            wordDoc.Content.Text = $"Отчет по задачам сотрудника {employee.full_name}";

            // Добавим задачи в таблицу
            var table = wordDoc.Tables.Add(wordDoc.Range(0, 0), tasks.Count + 1, 3);
            table.Borders.Enable = 1;

            // Заголовки таблицы
            table.Cell(1, 1).Range.Text = "Дата";
            table.Cell(1, 2).Range.Text = "Описание";
            table.Cell(1, 3).Range.Text = "Категория";

            // Добавляем задачи в таблицу
            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                table.Cell(i + 2, 1).Range.Text = task.date.ToString("dd.MM.yyyy");
                table.Cell(i + 2, 2).Range.Text = task.description;
                table.Cell(i + 2, 3).Range.Text = task.Categories?.name ?? "Без категории";
            }

            // Сохраняем документ на рабочем столе
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, $"Отчет_за_{employee.full_name}_{DateTime.Now:yyyyMMdd_HHmmss}.docx");
            wordDoc.SaveAs2(filePath);

            // Закрываем Word
            wordDoc.Close();
            wordApp.Quit();

            // Открываем файл
            System.Diagnostics.Process.Start(filePath);

            // Копируем путь к файлу в буфер обмена
            Clipboard.SetText(filePath);

            MB.Info($"Отчет сохранен на рабочем столе: {filePath}");
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
