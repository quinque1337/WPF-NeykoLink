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

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAnimations();
        }

        private string previousText = string.Empty;
        private bool isAnimating = false;
        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool wasEmpty = string.IsNullOrWhiteSpace(previousText);
            bool isEmpty = string.IsNullOrWhiteSpace(LoginTB.Text);
            previousText = LoginTB.Text;

            if (isEmpty)
            {
                if (!wasEmpty)
                {
                    StartButtonAnimation(false);
                }
                return;
            }

            if (wasEmpty)
            {
                StartButtonAnimation(true);
            }
        }

        private void StartButtonAnimation(bool show)
        {
            if (isAnimating) return;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = show ? 0 : 1,
                To = show ? 1 : 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            Storyboard.SetTarget(animation, ContinueButton);
            Storyboard.SetTargetProperty(animation, new PropertyPath(OpacityProperty));

            storyboard.Completed += (s, _) => {
                isAnimating = false;
                if (!show) ContinueButton.Visibility = Visibility.Hidden;
            };

            if (show) ContinueButton.Visibility = Visibility.Visible;

            isAnimating = true;
            storyboard.Begin();
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
