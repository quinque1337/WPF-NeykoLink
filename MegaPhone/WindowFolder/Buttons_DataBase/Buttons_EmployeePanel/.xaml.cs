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
    public partial class Edit_Task : Window
    {
        private Tasks _task;
        public Edit_Task(Tasks task)
        {
            InitializeComponent();

            // Сохраняем переданную задачу
            _task = task;

            // Заполняем поля значениями текущей задачи
            DescriptionTextBox.Text = _task.description;
            CategoryComboBox.ItemsSource = App.db.Categories.ToList();  // Загрузим категории
            CategoryComboBox.DisplayMemberPath = "name";  // Указываем, что в комбобоксе должно отображаться поле "name" у каждой категории
            CategoryComboBox.SelectedItem = _task.Categories; // Установим текущую категорию
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что описание не пустое
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MB.Info("Описание задачи не может быть пустым.");
                return;
            }

            // Проверяем, что категория выбрана
            if (CategoryComboBox.SelectedItem == null)
            {
                MB.Info("Выберите категорию задачи.");
                return;
            }

            // Сохраняем изменения в задаче
            _task.description = DescriptionTextBox.Text;
            _task.category_id = (CategoryComboBox.SelectedItem as Categories)?.id;

            // Сохраняем изменения в базе данных
            App.db.SaveChanges();

            // Закрываем окно
            this.Close();

            // Выводим сообщение об успешном редактировании
            MB.Info("Задача успешно отредактирована.");
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
