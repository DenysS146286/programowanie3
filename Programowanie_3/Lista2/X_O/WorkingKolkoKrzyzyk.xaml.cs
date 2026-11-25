using System;
using System.Windows;
using System.Windows.Controls;

namespace Lista2
{
    public partial class WorkingKolkoKrzyzyk : Window
    {
        Gra gra = new Gra();

        public WorkingKolkoKrzyzyk()
        {
            InitializeComponent();
            DataContext = gra;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            gra.Ruch(Convert.ToInt32(przycisk.Tag));
        }
    }
}
