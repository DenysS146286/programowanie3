
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lista2
{
    public partial class Gracz1 : Window
    {
        GraStatki graStatki;

        Button[] mojePrzyciski = new Button[100];
        Button[] przeciwnikPrzyciski = new Button[100];

        public Gracz1()
        {
            InitializeComponent();

            graStatki = new GraStatki();

            TworzPlansze();

            Gracz2 gracz2 = new Gracz2(graStatki);
            gracz2.Show();

            AktualizujObiePlansze();
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

            graStatki.ZmienStatek(0, numerPola);

            AktualizujObiePlansze();
        }

        private void Przeciwnik_Click(object sender, RoutedEventArgs e)
        {
            Button kliknietyPrzycisk = (Button)sender;
            int numerPola = Array.IndexOf(przeciwnikPrzyciski, kliknietyPrzycisk);

            graStatki.Strzal(0, numerPola);

            AktualizujObiePlansze();
        }

        public void AktualizujPlansze()
        {
            for (int numerPola = 0; numerPola < 100; numerPola++)
            {
                mojePrzyciski[numerPola].Tag =
                    graStatki.PobierzStanMojejPlanszy(0, numerPola);

                przeciwnikPrzyciski[numerPola].Tag =
                    graStatki.PobierzStanPola(0, numerPola);

                mojePrzyciski[numerPola].IsEnabled =
                    !graStatki.Koniec;

                przeciwnikPrzyciski[numerPola].IsEnabled =
                    graStatki.AktualnyGracz == 1 &&
                    !graStatki.Koniec &&
                    !graStatki.Strzaly[0, numerPola];
            }

            if (graStatki.Koniec)
                status.Text = "Wygral gracz " + graStatki.Zwyciezca;
            else if (graStatki.AktualnyGracz == 1)
                status.Text = "Twoja kolej - Gracz 1";
            else
                status.Text = "Czekasz na Gracza 2";
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
