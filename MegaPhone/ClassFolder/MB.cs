using MegaPhone.WindowFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using MegaPhone.WindowFolder.Notifications;

namespace MegaPhone.ClassFolder
{
    class MB
    {

        public static void Error(string msg)
        {
            Error mainWindow = new Error(msg);
            mainWindow.ShowDialog();
            return;
        }

        public static void Error(Exception ex)
        {
            Error mainWindow = new Error(ex.Message);
            mainWindow.ShowDialog();
            return;
        }

        public static void Info(string msg)
        {
            Notify mainWindow = new Notify(msg);
            mainWindow.ShowDialog();
            return;
        }

        public static bool? Question(string msg)
        {
            Question mainWindow = new Question(msg);
            return mainWindow.ShowDialog();
        }

        public static void Exit()
        {
            var result = MB.Question("Вы действительно хотите выйти из приложения?");

            if (result == true)
            {
                App.Current.Shutdown();
            }
        }
    }
}
