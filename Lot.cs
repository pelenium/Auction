using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace Auction
{
    internal class Lot
    {
        public Label InformationLabel = new Label();
        public Label RateLabel = new Label();
        public StackPanel stackPanel;

        public Lot(ref StackPanel stackPanel)
        {
            this.stackPanel = stackPanel;
            InformationLabel.FontSize = 20;
            RateLabel.FontSize = 20;

            InformationLabel.Foreground = Brushes.White;
            RateLabel.Foreground = Brushes.White;

            InformationLabel.Background = new SolidColorBrush(Color.FromArgb(255, 36, 36, 36));
            InformationLabel.BorderThickness = new Thickness(1);
            InformationLabel.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            RateLabel.Background = new SolidColorBrush(Color.FromArgb(255, 36, 36, 36));
            RateLabel.BorderThickness = new Thickness(1);
            RateLabel.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            InformationLabel.HorizontalAlignment = HorizontalAlignment.Left;
            InformationLabel.Margin = new Thickness(5, 10, 0, 0);
            RateLabel.HorizontalAlignment = HorizontalAlignment.Right;
            RateLabel.Margin = new Thickness(5, 10, 0, 0);
        }
    }
}