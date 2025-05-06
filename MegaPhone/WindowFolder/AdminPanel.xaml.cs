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
using MegaPhone.ClassFolder;
using MegaPhone.WindowFolder.Pages;

namespace MegaPhone.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
            string name = App.CurrentUser.full_name;
            string role = App.CurrentUser.role;
            FIOLabel.Content = name;
            switch (role)
            {
                case "admin":
                    RoleLabel.Content = "Администратор";
                    break;
                case "employee":
                    RoleLabel.Content = "Сотрудник";
                    break;
            }
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Statistic());
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Employees());
        }
        private void Tastks_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TasksPage());
        }

        private void Otchet_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Report());
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            Change_Password change_password = new Change_Password();
            change_password.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MB.Exit();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
