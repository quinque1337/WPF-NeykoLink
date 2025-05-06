using MegaPhone.ClassFolder;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MegaPhone.WindowFolder;
using System.Xml.Linq;

namespace MegaPhone.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void LoadAnimations()
        {
            var scaleAnimation = new DoubleAnimation
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(scaleAnimation, LoaderBorder);
            Storyboard.SetTargetProperty(scaleAnimation,
                new PropertyPath("RenderTransform.ScaleX"));

            var scaleYAnimation = scaleAnimation.Clone();
            Storyboard.SetTargetProperty(scaleYAnimation,
                new PropertyPath("RenderTransform.ScaleY"));

            var openStoryboard = new Storyboard();
            openStoryboard.Children.Add(scaleAnimation);
            openStoryboard.Children.Add(scaleYAnimation);

            var resizeWidthAnimation = new DoubleAnimation
            {
                To = 620,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            var resizeHeightAnimation = new DoubleAnimation
            {
                To = 500,
                Duration = TimeSpan.FromSeconds(0.8),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            var fadeInContentAnimation = new DoubleAnimation
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };

            var hideSpinnerAnimation = new DoubleAnimation
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            var hideButtonAnim = new DoubleAnimation
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            var showButtonAnim = new DoubleAnimation
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            var finalStoryboard = new Storyboard();
            finalStoryboard.Children.Add(resizeWidthAnimation);
            finalStoryboard.Children.Add(resizeHeightAnimation);
            finalStoryboard.Children.Add(fadeInContentAnimation);
            finalStoryboard.Children.Add(hideSpinnerAnimation);

            Storyboard.SetTarget(resizeWidthAnimation, LoaderBorder);
            Storyboard.SetTargetProperty(resizeWidthAnimation, new PropertyPath("Width"));

            Storyboard.SetTarget(resizeHeightAnimation, LoaderBorder);
            Storyboard.SetTargetProperty(resizeHeightAnimation, new PropertyPath("Height"));

            Storyboard.SetTarget(fadeInContentAnimation, PageContent);
            Storyboard.SetTargetProperty(fadeInContentAnimation, new PropertyPath("Opacity"));

            Storyboard.SetTarget(hideSpinnerAnimation, Spinner);
            Storyboard.SetTargetProperty(hideSpinnerAnimation, new PropertyPath("Opacity"));

            openStoryboard.Completed += (s, e) =>
            {
                PageContent.IsHitTestVisible = false;

                Task.Delay(2500).ContinueWith(_ =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        finalStoryboard.Begin();
                        PageContent.IsHitTestVisible = true;
                    });
                });
            };

            openStoryboard.Begin();
        }

        private int captchaValue = 0; // Счетчик неправильных попыток капчи

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            Validation();
            Capcha();

            var user = App.db.Users.FirstOrDefault(x => x.username == LoginTB.Text);

            if (user == null)
            {
                MB.Error("Пользователь не найден!");
                captchaValue++;
                return;
            }

            // Получаем хэш пароля из базы данных
            string passwordHash = user.password_hash;

            bool isPasswordValid = false;

            // Проверяем, хэширован ли пароль
            if (passwordHash.StartsWith("$2a$")) // Это означает, что пароль уже хэширован (формат BCrypt)
            {
                // Если хэширован, проверяем его с введенным паролем
                isPasswordValid = BCrypt.Net.BCrypt.Verify(PasswordPB.Password, passwordHash);
            }
            else
            {
                // Если пароль не хэширован, хэшируем введенный пароль и сравниваем
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(PasswordPB.Password);
                isPasswordValid = passwordHash == hashedPassword;
            }

            if (isPasswordValid)
            {
                // Если пароль правильный, продолжаем авторизацию
                App.CurrentUser = user;
                string role = App.CurrentUser.role;
                switch (role)
                {
                    case "admin":
                        AdminPanel adminka = new AdminPanel();
                        adminka.Show();
                        this.Close();
                        break;
                    case "employee":
                        EmployeePanel employee_panel = new EmployeePanel();
                        employee_panel.Show();
                        this.Close();
                        break;
                    default:
                        MB.Error("Неизвестная роль пользователя.");
                        break;
                }
            }
            else
            {
                MB.Error("Неверный пароль!");
                captchaValue++;
            }
        }


        private void Validation()
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MB.Error("Введите логин!");
                LoginTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MB.Error("Введите пароль!");
                PasswordPB.Focus();
                return;
            }
            else if (LoginTB.Text.Length < 3)
            {
                MB.Error("Логин должен содержать не менее 3 символов");
                LoginTB.Focus();
                return;
            }
            else if (PasswordPB.Password.Length < 6)
            {
                MB.Error("Пароль должен содержать не менее 6 символов!");
                PasswordPB.Focus();
                return;
            }
        }


        private void Capcha()
        {
            if (captchaValue >= 3)
            {
                CapchaWindow window = new CapchaWindow();
                window.ShowDialog();
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAnimations();
        }

        private string previousText = string.Empty;
        private bool isAnimating = false;

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
