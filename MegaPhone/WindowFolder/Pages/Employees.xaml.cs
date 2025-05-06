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
using MegaPhone.ClassFolder;
using MegaPhone.DataFolder;
using MegaPhone.WindowFolder.Buttons_DataBase;

namespace MegaPhone.WindowFolder.Pages
{
    public partial class Employees : Page
    {
        public Employees()
        {
            InitializeComponent();
            EmployeeDG.ItemsSource = App.db.Users.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Add_Employee addToDB = new Add_Employee();
            if (addToDB.ShowDialog() == true)
            {
                RefreshData();
            }
        }


        private void Redact(object sender, RoutedEventArgs e)
        {
            var selectedUser = EmployeeDG.SelectedItem as Users;
            if (selectedUser == null)
            {
                MB.Info("Выберите пользователя для редактирования.");
                return;
            }

            var editWindow = new Edit_Employee(selectedUser);
            editWindow.ShowDialog();

            // Обновим DataGrid после закрытия
            EmployeeDG.ItemsSource = App.db.Users.ToList();
        }



        private void Delete(object sender, RoutedEventArgs e)
        {
            if (EmployeeDG.SelectedItem is Users selectedClient)
            {
                if (MB.Question("Вы точно хотите удалить выбранного клиента?") == true)
                {
                    try
                    {
                        App.db.Users.Remove(selectedClient);
                        App.db.SaveChanges();
                        RefreshData();
                        MB.Info("Клиент удалён.");
                    }
                    catch (Exception ex)
                    {
                        MB.Info("Ошибка при удалении: " + ex.Message);
                    }
                }
            }
            else
            {
                MB.Info("Выберите клиента для удаления.");
            }
        }


        private void Refresh(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            EmployeeDG.ItemsSource = App.db.Users.ToList();
        }
        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTB.Text.ToLower();

            EmployeeDG.ItemsSource = App.db.Users
                .Where(c => c.full_name.ToLower().Contains(searchText)
                         || c.username.ToLower().Contains(searchText)
                         || c.role.ToLower().Contains(searchText)
                         || c.birth_date.ToString().Contains(searchText))
                .OrderBy(c => c.full_name)
                .ToList();
        }

    }
}
