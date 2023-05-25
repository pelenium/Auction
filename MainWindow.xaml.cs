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
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            // Изначальное время

            time = new TimeSpan(0, 0, 0);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time = time.Subtract(TimeSpan.FromSeconds(1));

            if (time.TotalSeconds <= 0)
            {
                timer.Stop();
                MessageBox.Show("Время истекло!");
                time= TimeSpan.Zero;
            }

            UpdateTimerDisplay();
        }

        private void UpdateTimerDisplay()
        {
            // Отображение времени в формате "hh:mm:ss"
            timerLabel.Content = time.ToString(@"hh\:mm\:ss");
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (time.TotalSeconds > 0)
            {
                timer.Start();
            }
        }

        private void pauseButton_Click(Object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            time = new TimeSpan(0, 0, 0);
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

        private void setTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (TimeSpan.TryParse(timerTextBox.Text, out TimeSpan userInputTime))
            {
                time = userInputTime;
                UpdateTimerDisplay();
            }
            else
            {
                MessageBox.Show("Некорректный формат времени. Пожалуйста, введите время в формате hh:mm:ss");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LotInformation.Text != null && LotRate != null)
            {
                Lot lot = new Lot();

                lot.InformationLabel.Content = LotInformation.Text;
                lot.RateLabel.Content = LotRate.Text;

                Lots.Add(lot);

                lot.InformationLabel.HorizontalAlignment = HorizontalAlignment.Left;
                lot.InformationLabel.Margin = new Thickness(0, 10, 0, 0);
                lot.RateLabel.HorizontalAlignment = HorizontalAlignment.Left;

                stackPanel.Children.Add(lot.InformationLabel);
                stackPanel.Children.Add(lot.RateLabel);


                Canvas.SetLeft(lot.InformationLabel, 0);
                Canvas.SetTop(lot.InformationLabel, 38 * (Lots.Count() + 1) - 30);

                
            }
        }


    }
}
