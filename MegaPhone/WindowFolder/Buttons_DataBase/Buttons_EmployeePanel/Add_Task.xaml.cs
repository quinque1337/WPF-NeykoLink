using MegaPhone.ClassFolder;
using MegaPhone.DataFolder;
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

namespace MegaPhone.WindowFolder.Buttons_DataBase.Buttons_EpmloyeePanel
{
    /// <summary>
    /// Логика взаимодействия для Add_Employee.xaml
    /// </summary>
    public partial class Add_Task : Window
    {
        public Add_Task()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            CategoryComboBox.ItemsSource = App.db.Categories.ToList();  // Загрузим категории
            CategoryComboBox.DisplayMemberPath = "name";  // Указываем, что в комбобоксе должно отображаться поле "name" у каждой категории
            CategoryComboBox.SelectedIndex = 0; // Выбор первой категории по умолчанию
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполненные поля
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MB.Info("Описание задачи не может быть пустым.");
                return;
            }

            if (CategoryComboBox.SelectedItem == null)
            {
                MB.Info("Выберите категорию задачи.");
                return;
            }

            var selectedCategory = CategoryComboBox.SelectedItem as Categories;
            if (selectedCategory == null)
            {
                MB.Info("Ошибка при получении категории.");
                return;
            }

            // Создание новой задачи
            var newTask = new Tasks
            {
                description = DescriptionTextBox.Text,
                category_id = selectedCategory.id, // Используем ID выбранной категории
                date = DateTime.Today, // Устанавливаем сегодняшнюю дату
                user_id = App.CurrentUser.id // Задача для текущего пользователя
            };

            // Добавление задачи в базу данных
            App.db.Tasks.Add(newTask);
            App.db.SaveChanges(); // Сохраняем изменения в базе данных

            MB.Info("Задача успешно добавлена!");
            this.Close();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
