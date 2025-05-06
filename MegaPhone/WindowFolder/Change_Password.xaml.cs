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
using BCrypt.Net;

namespace MegaPhone.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для Add_Employee.xaml
    /// </summary>
    public partial class Change_Password : Window
    {
        public Change_Password()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.CurrentUser;
            string oldPassword = OldPasswordBox.Password;
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (newPassword != confirmPassword)
            {
                MB.Info("Новый пароль и подтверждение не совпадают.");
                return;
            }

            var user = App.db.Users.FirstOrDefault(u => u.username == currentUser.username);
            if (user == null)
            {
                MB.Info("Пользователь не найден.");
                return;
            }

            string hash = user.password_hash;
            bool isPlain = !hash.StartsWith("$2a$") && !hash.StartsWith("$2b$") && !hash.StartsWith("$2y$");

            if (isPlain)
            {
                // Пароль в открытом виде
                if (user.password_hash == oldPassword)
                {
                    // Сначала захешируем старый
                    string hashedOld = BCrypt.Net.BCrypt.HashPassword(oldPassword);
                    user.password_hash = hashedOld;
                    App.db.SaveChanges();

                    // Теперь обновим на новый
                    user.password_hash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    App.db.SaveChanges();

                    MB.Info("Пароль успешно изменен.");
                    this.Close();
                }
                else
                {
                    MB.Info("Неверный старый пароль.");
                }
            }
            else
            {
                // Пароль уже в хеше
                if (BCrypt.Net.BCrypt.Verify(oldPassword, hash))
                {
                    user.password_hash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    App.db.SaveChanges();
                    MB.Info("Пароль успешно изменен.");
                    this.Close();
                }
                else
                {
                    MB.Info("Неверный старый пароль.");
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
