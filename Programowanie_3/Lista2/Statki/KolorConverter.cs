
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Lista2
{
    public class KolorConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            switch (value?.ToString())
            {
                case "Ship":
                    return Brushes.Black;

                case "Hit":
                    return Brushes.Red;

                case "Miss":
                    return Brushes.LightGray;

                default:
                    return Brushes.White;
            }
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return "Empty";
        }
    }
}
