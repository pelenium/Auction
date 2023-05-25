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

namespace Auction
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Lot> Lots = new List<Lot>();

        public MainWindow()
        {
            InitializeComponent();

        }

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

                    Button DeleteButton = new Button();
                    DeleteButton.Width = 25;
                    DeleteButton.Height = 25;
                    DeleteButton.Content = "X";
                    DeleteButton.Foreground = Brushes.White;
                    DeleteButton.Background = new SolidColorBrush(Color.FromArgb(255, 46, 56, 58));
                    DeleteButton.Margin = new Thickness(0, 10, 0, 0);

                    DeleteButton.Click += (s, ev) => DeleteButton_Click(sender, e, panel);

                    panel.Children.Add(DeleteButton);
                    panel.Children.Add(lot.InformationLabel);
                    panel.Children.Add(lot.RateLabel);

                    stackPanel.Children.Add(panel);

                    LotInformation.Text = "";
                    LotRate.Text = "";
                }
                catch (FormatException)
                {
                    Lot lot = new Lot(ref stackPanel);

                    StackPanel panel = new StackPanel();
                    panel.Orientation = Orientation.Horizontal;

                    lot.InformationLabel.Content = LotInformation.Text;
                    lot.RateLabel.Content = "";

                    Lots.Add(lot);

                    Button DeleteButton = new Button();
                    DeleteButton.Width = 25;
                    DeleteButton.Height = 25;
                    DeleteButton.Content = "X";
                    DeleteButton.Foreground = Brushes.White;
                    DeleteButton.Background = new SolidColorBrush(Color.FromArgb(255, 46, 56, 58));
                    DeleteButton.Margin = new Thickness(0, 10, 0, 0);

                    DeleteButton.Click += (s, ev) => DeleteButton_Click(sender, e, panel);

                    panel.Children.Add(DeleteButton);
                    panel.Children.Add(lot.InformationLabel);
                    panel.Children.Add(lot.RateLabel);

                    stackPanel.Children.Add(panel);

                    LotInformation.Text = "";
                    LotRate.Text = "";
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e, StackPanel panel)
        {

            stackPanel.Children.Remove(panel);
        }
    }
}
