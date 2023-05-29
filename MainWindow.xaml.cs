using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Auction
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Lot> Lots = new List<Lot>();
        private DispatcherTimer timer;
        private TimeSpan time;


        public MainWindow()
        {
            InitializeComponent();

            // Инициализация таймера

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            ImageBrush subImg = new ImageBrush();
            subImg.ImageSource = new BitmapImage(new Uri(@"substract.png", UriKind.Absolute));
            subtractMinuteButton.Background = subImg;

            ImageBrush addImg = new ImageBrush();
            addImg.ImageSource = new BitmapImage(new Uri(@"add.png", UriKind.Absolute));
            addMinuteButton.Background = addImg;

            // Изначальное время

            time = new TimeSpan(0, 10, 0); 
        }

        #region Timer_Block
        private void Timer_Tick(object sender, EventArgs e)
        {
            time = time.Subtract(TimeSpan.FromSeconds(1));

            if (time.TotalSeconds <= 0)
            {
                timer.Stop();
                MessageBox.Show("Время истекло!");
                time = TimeSpan.Zero;
            }

            UpdateTimerDisplay();
        }

        private void UpdateTimerDisplay()
        {
            // Отображение времени в формате "hh:mm:ss"
            timerLabel.Content = time.ToString(@"hh\:mm\:ss");
        }

        private void pauseButton_Click(Object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                ImageBrush img = new ImageBrush();
                img.ImageSource =
                    new BitmapImage(new Uri(@"", UriKind.Absolute));
                PlayPauseButton.Background = img;
                timer.Stop();
            }
            else
            {
                ImageBrush img = new ImageBrush();
                img.ImageSource =
                    new BitmapImage(new Uri(@"", UriKind.Absolute));
                PlayPauseButton.Background = img;
                if (time.TotalSeconds > 0)
                {
                    timer.Start();
                }
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            time = new TimeSpan(0, 10, 0);
            UpdateTimerDisplay();
        }

        private void addMinuteButton_Click(object sender, RoutedEventArgs e)
        {
            time = time.Add(TimeSpan.FromMinutes(1));
            UpdateTimerDisplay();
        }

        private void subtractMinuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (time.TotalMinutes >= 1)
            {
                time = time.Subtract(TimeSpan.FromMinutes(1));
                UpdateTimerDisplay();
            }
        }

        #endregion

        #region LotAdding
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LotInformation.Text != "" && LotRate.Text != "")
            {
                try
                {

                    float check = float.Parse(LotRate.Text.Replace('.', ','));

                    Lot lot = new Lot(ref stackPanel);

                    StackPanel panel = new StackPanel();
                    panel.Orientation = Orientation.Horizontal;

                    lot.InformationLabel.Content = LotInformation.Text;
                    lot.RateLabel.Content = LotRate.Text.Replace(',', '.');

                    Lots.Add(lot);

                    TextBox additionToRate = new TextBox();
                    additionToRate.Width = 150;
                    additionToRate.Height = 38;
                    additionToRate.FontSize = 20;
                    additionToRate.Foreground = Brushes.White;
                    additionToRate.Background = new SolidColorBrush(Color.FromArgb(255, 36, 36, 36));
                    additionToRate.HorizontalContentAlignment = HorizontalAlignment.Center;
                    additionToRate.VerticalContentAlignment = VerticalAlignment.Center;
                    additionToRate.BorderThickness = new Thickness(1);
                    additionToRate.BorderBrush = Brushes.White;
                    additionToRate.Margin = new Thickness(5, 10, 0, 0);

                    additionToRate.LostFocus += (s, ev) => RateAdd_EndChange(s, ev, lot.RateLabel, lot.RateLabel.Content.ToString(), additionToRate);

                    Label plusSign = new Label();
                    plusSign.FontSize = 20;
                    plusSign.Width = 38;
                    plusSign.Height = 38;
                    plusSign.Foreground = Brushes.White;
                    plusSign.Background = new SolidColorBrush(Color.FromArgb(255, 36, 36, 36));
                    plusSign.BorderThickness = new Thickness(1);
                    plusSign.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    plusSign.VerticalContentAlignment = VerticalAlignment.Bottom;
                    plusSign.HorizontalContentAlignment = HorizontalAlignment.Center;
                    plusSign.Margin = new Thickness(5, 10, 0, 0);
                    plusSign.Content = "➕";

                    Button DeleteButton = new Button();
                    DeleteButton.Width = 38;
                    DeleteButton.Height = 38;
                    DeleteButton.Content = "🗑️";
                    DeleteButton.BorderThickness = new Thickness(1);
                    DeleteButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    DeleteButton.Foreground = Brushes.White;
                    DeleteButton.Background = new SolidColorBrush(Color.FromArgb(255, 46, 56, 58));
                    DeleteButton.Margin = new Thickness(0, 10, 0, 0);

                    DeleteButton.Click += (s, ev) => DeleteButton_Click(sender, e, panel);

                    panel.Children.Add(DeleteButton);
                    panel.Children.Add(lot.InformationLabel);
                    panel.Children.Add(lot.RateLabel);
                    panel.Children.Add(plusSign);
                    panel.Children.Add(additionToRate);

                    stackPanel.Children.Add(panel);

                    LotInformation.Text = "";
                    LotRate.Text = "";
                }
                catch (FormatException) { }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e, StackPanel panel) => stackPanel.Children.Remove(panel);

        private void RateAdd_EndChange(object sender, RoutedEventArgs e, Label label, string rate, TextBox adding)
        {
            try
            {
                label.Content = (float.Parse(rate.Replace('.', ',')) + float.Parse(adding.Text.Replace('.', ','))).ToString().Replace(',', '.');
                adding.Text = "";
            }
            catch (FormatException)
            {
                label.Content = rate;
            }
        }

        #endregion
    }
}