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

namespace MegaPhone.WindowFolder.Buttons_DataBase
{
    /// <summary>
    /// Логика взаимодействия для Add_Employee.xaml
    /// </summary>
    public partial class Add_Employee : Window
    {
        public Add_Employee()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустые поля
            if (string.IsNullOrEmpty(UsernameTB.Text) ||
                string.IsNullOrEmpty(PasswordTB.Password) ||
                string.IsNullOrEmpty(FullNameTB.Text) ||
                RoleCB.SelectedItem == null || // Проверка на выбор роли
                BirthDateDP.SelectedDate == null)
                {
                MB.Info("Все поля должны быть заполнены.");
                return;
            }

            try
            {
                // Хэшируем пароль
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(PasswordTB.Password);

                // Получаем выбранную роль, используя Tag для сохранения в базе данных
                string role = (RoleCB.SelectedItem as ComboBoxItem)?.Tag.ToString() ?? "employee";
                string fullName = FullNameTB.Text;
                DateTime? birthDate = BirthDateDP.SelectedDate;

                // Создаем нового пользователя
                var newUser = new Users
                {
                    username = UsernameTB.Text,
                    password_hash = passwordHash,
                    role = role,
                    full_name = fullName,
                    birth_date = birthDate
                };

                // Добавляем пользователя в базу данных через App.db
                App.db.Users.Add(newUser);
                App.db.SaveChanges();

                MB.Info("Сотрудник успешно добавлен.");

                // Закрываем окно после добавления
                this.Close();
            }
            catch (Exception ex)
            {
                MB.Error($"Произошла ошибка при добавлении сотрудника: {ex.Message}");
            }
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
