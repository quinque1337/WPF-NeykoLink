using MegaPhone.DataFolder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MegaPhone
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DataFolder.CRM_MFC_DataBaseEntities db { get; set; } = new DataFolder.CRM_MFC_DataBaseEntities();
    }
    public partial class App : Application
    {
        public static Users CurrentUser { get; set; }
    }
}
