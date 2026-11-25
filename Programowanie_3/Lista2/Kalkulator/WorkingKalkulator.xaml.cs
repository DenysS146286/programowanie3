using System.Windows;
using System.Windows.Controls;

namespace Lista2
{
    public partial class WorkingKalkulator : Window
    {
        Kalkulator kalkulator = new Kalkulator();

        public WorkingKalkulator()
        {
            InitializeComponent();
            DataContext = kalkulator;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            kalkulator.Wcisnij(przycisk.Content.ToString()!);
        }
    }
}
