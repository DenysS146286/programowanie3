using System;
using System.Windows;
using System.Windows.Controls;

namespace Lista2
{
    public partial class GraczOkno : Window
    {
        GraczWidok widok;

        public GraczOkno(GraczWidok widok)
        {
            InitializeComponent();
            this.widok = widok;
            DataContext = widok;
        }

        private void MojaPlansza_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            widok.Gra.ZmienStatek(widok.Gracz, Convert.ToInt32(przycisk.Tag));
        }

        private void Przeciwnik_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            widok.Gra.Strzal(widok.Gracz, Convert.ToInt32(przycisk.Tag));
        }
    }
}
