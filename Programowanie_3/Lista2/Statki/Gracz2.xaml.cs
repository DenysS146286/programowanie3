
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lista2
{
    public partial class Gracz2 : Window
    {
        GraStatki graStatki;

        Button[] mojePrzyciski = new Button[100];
        Button[] przeciwnikPrzyciski = new Button[100];

        public Gracz2(GraStatki przekazanaGra)
        {
            InitializeComponent();

            graStatki = przekazanaGra;

            TworzPlansze();

            AktualizujPlansze();
        }

        private void TworzPlansze()
        {
            for (int numerPola = 0; numerPola < 100; numerPola++)
            {
                Button przyciskMojejPlanszy = new Button();
                przyciskMojejPlanszy.Margin = new Thickness(1);
                przyciskMojejPlanszy.Tag = "Empty";
                przyciskMojejPlanszy.Click += MojaPlansza_Click;

                przyciskMojejPlanszy.SetBinding(
                    Button.BackgroundProperty,
                    new Binding("Tag")
                    {
                        RelativeSource = new RelativeSource(
                            RelativeSourceMode.Self),
                        Converter = (KolorConverter)FindResource("KolorConverter")!
                    });

                mojaPlansza.Children.Add(przyciskMojejPlanszy);
                mojePrzyciski[numerPola] = przyciskMojejPlanszy;

                Button przyciskPrzeciwnika = new Button();
                przyciskPrzeciwnika.Margin = new Thickness(1);
                przyciskPrzeciwnika.Tag = "Empty";
                przyciskPrzeciwnika.Click += Przeciwnik_Click;

                przyciskPrzeciwnika.SetBinding(
                    Button.BackgroundProperty,
                    new Binding("Tag")
                    {
                        RelativeSource = new RelativeSource(
                            RelativeSourceMode.Self),
                        Converter = (KolorConverter)FindResource("KolorConverter")!
                    });

                planszaPrzeciwnika.Children.Add(przyciskPrzeciwnika);
                przeciwnikPrzyciski[numerPola] = przyciskPrzeciwnika;
            }
        }

        private void MojaPlansza_Click(object sender, RoutedEventArgs e)
        {
            Button kliknietyPrzycisk = (Button)sender;
            int numerPola = Array.IndexOf(mojePrzyciski, kliknietyPrzycisk);

            graStatki.ZmienStatek(1, numerPola);

            AktualizujObiePlansze();
        }

        private void Przeciwnik_Click(object sender, RoutedEventArgs e)
        {
            Button kliknietyPrzycisk = (Button)sender;
            int numerPola = Array.IndexOf(przeciwnikPrzyciski, kliknietyPrzycisk);

            graStatki.Strzal(1, numerPola);

            AktualizujObiePlansze();
        }

        public void AktualizujPlansze()
        {
            for (int numerPola = 0; numerPola < 100; numerPola++)
            {
                mojePrzyciski[numerPola].Tag =
                    graStatki.PobierzStanMojejPlanszy(1, numerPola);

                przeciwnikPrzyciski[numerPola].Tag =
                    graStatki.PobierzStanPola(1, numerPola);

                mojePrzyciski[numerPola].IsEnabled =
                    !graStatki.Koniec;

                przeciwnikPrzyciski[numerPola].IsEnabled =
                    graStatki.AktualnyGracz == 2 &&
                    !graStatki.Koniec &&
                    !graStatki.Strzaly[1, numerPola];
            }

            if (graStatki.Koniec)
                status.Text = "Wygral gracz " + graStatki.Zwyciezca;
            else if (graStatki.AktualnyGracz == 2)
                status.Text = "Twoja kolej - Gracz 2";
            else
                status.Text = "Czekasz na Gracza 1";
        }

        private void AktualizujObiePlansze()
        {
            foreach (Window okno in Application.Current.Windows)
            {
                if (okno is Gracz1)
                    ((Gracz1)okno).AktualizujPlansze();

                if (okno is Gracz2)
                    ((Gracz2)okno).AktualizujPlansze();
            }
        }
    }
}
