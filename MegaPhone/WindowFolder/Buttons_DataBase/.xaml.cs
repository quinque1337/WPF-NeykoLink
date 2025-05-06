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
    public partial class Edit_Employee : Window
    {
        private Users _user;
        public Edit_Employee(Users user)
        {
            InitializeComponent();
            _user = user;

            // Заполняем поля значениями пользователя
            UsernameTB.Text = _user.username;
            PasswordTB.Password = ""; // нельзя отобразить хеш, пусть пользователь вводит новый, если надо
            FullNameTB.Text = _user.full_name;
            BirthDateDP.SelectedDate = _user.birth_date;

            RoleCB.ItemsSource = new List<string> { "Администратор", "Сотрудник" };
            RoleCB.SelectedItem = _user.role == "admin" ? "Администратор" : "Сотрудник";
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTB.Text) ||
                string.IsNullOrEmpty(PasswordTB.Password) ||
                string.IsNullOrEmpty(FullNameTB.Text) ||
                RoleCB.SelectedItem == null || // Проверка на выбор роли
                BirthDateDP.SelectedDate == null)
            {
                MB.Info("Все поля должны быть заполнены.");
                return;
            }

            // Обновляем значения
            _user.username = UsernameTB.Text;
            _user.full_name = FullNameTB.Text;
            _user.birth_date = (DateTime)BirthDateDP.SelectedDate;
            _user.role = (RoleCB.SelectedItem.ToString() == "Администратор") ? "admin" : "employee";

            // Если введен новый пароль — хэшируем и сохраняем
            if (!string.IsNullOrWhiteSpace(PasswordTB.Password))
            {
                _user.password_hash = BCrypt.Net.BCrypt.HashPassword(PasswordTB.Password);
            }

            try
            {
                App.db.SaveChanges();
                MB.Info("Пользователь успешно обновлён.");
                this.Close();
            }
            catch (Exception ex)
            {
                MB.Info("Ошибка при сохранении: " + ex.Message);
            }
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
