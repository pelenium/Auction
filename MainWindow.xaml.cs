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
