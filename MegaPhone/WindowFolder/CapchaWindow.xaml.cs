using MegaPhone.ClassFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MegaPhone.WindowFolder
{
    public partial class CapchaWindow : Window
    {
        string captcha1;
        public bool IsCaptchaValid { get; set; }
        public CapchaWindow()
        {
            InitializeComponent();
            GenerateCaptcha();
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void GenerateCaptcha()
        {
            string captchaText = GenerateRandomString(6);  // Генерация случайной строки
            captcha1 = captchaText.ToLower();  // Приводим к нижнему регистру

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Фон с градиентом
                LinearGradientBrush backgroundBrush = new LinearGradientBrush(
                    Colors.LightSkyBlue, Colors.LightGreen, 45);
                drawingContext.DrawRectangle(backgroundBrush, null, new Rect(0, 0, 250, 70));

                // Разнообразные цвета для текста
                Brush[] brushes = new Brush[] { Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.Orange, Brushes.Purple, Brushes.Yellow };
                Random random = new Random();
                double x = 10;

                // Рисуем текст капчи
                for (int i = 0; i < captchaText.Length; i++)
                {
                    // Рандомный шрифт и размер
                    Typeface typeface = new Typeface(new FontFamily("Comic Sans MS"), FontStyles.Italic, FontWeights.Bold, FontStretches.Normal);
                    FormattedText formattedText = new FormattedText(captchaText[i].ToString(), System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, typeface, 30 + random.Next(5), brushes[random.Next(6)]);
                    drawingContext.DrawText(formattedText, new Point(x, 20 + random.Next(20)));

                    // Добавляем помехи в виде рандомных точек
                    for (int j = 0; j < 15; j++)
                    {
                        drawingContext.DrawEllipse(Brushes.Gray, null, new Point(x + random.Next(60), random.Next(70)), 1, 1);
                    }

                    // Добавляем помехи в виде линий
                    for (int k = 0; k < 4; k++)
                    {
                        Point start = new Point(x + random.Next(60), random.Next(70));
                        Point end = new Point(x + random.Next(60), random.Next(70));
                        drawingContext.DrawLine(new Pen(brushes[random.Next(6)], 1), start, end);
                    }

                    x += formattedText.WidthIncludingTrailingWhitespace + 10 + random.Next(5);
                }
            }

            RenderTargetBitmap bmp = new RenderTargetBitmap(250, 70, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            Image captchaImage = new Image();
            captchaImage.Stretch = Stretch.Fill;
            captchaImage.Source = bmp;
            CaptchaImage.Source = captchaImage.Source;  // Отображаем капчу
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaUserText.Text != captcha1)
            {
                MB.Error("Капча не совпадает, попробуйте еще раз...");
                return;
            }
            else if (string.IsNullOrWhiteSpace(CaptchaUserText.Text))
            {
                MB.Error("Введите капчу!");
                return;
            }
            else if (CaptchaUserText.Text == captcha1)
            {
                IsCaptchaValid = (CaptchaUserText.Text == captcha1);
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha();  // Перегенерируем капчу
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();  // Двигаем окно
            }
        }
    }
}
