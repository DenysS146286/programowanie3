using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Lista2
{
    // Zamienia stan pola (int) na kolor.
    // ConverterParameter="ukryj" - nie pokazuje statkow (plansza przeciwnika).
    public class KolorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool ukryj = parameter as string == "ukryj";

            switch (value)
            {
                case GraStatki.Statek:
                    return ukryj ? Brushes.White : Brushes.Black;
                case GraStatki.Pudlo:
                    return Brushes.LightGray;
                case GraStatki.Trafienie:
                    return Brushes.Red;
                default:
                    return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
