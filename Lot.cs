using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;

namespace Auction
{
    internal class Lot
    {
        public Label InformationLabel = new Label();
        public Label RateLabel = new Label();

        public Lot()
        {
            InformationLabel.FontSize = 20;
            RateLabel.FontSize = 20;

            InformationLabel.Foreground = Brushes.White;
            RateLabel.Foreground = Brushes.White;

            InformationLabel.Background = Brushes.Red;
            RateLabel.Background = Brushes.Blue;
        }
    }
}
