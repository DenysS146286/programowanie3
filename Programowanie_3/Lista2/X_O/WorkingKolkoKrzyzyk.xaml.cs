
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;

            if (przycisk.Content != null)
                return;

            if (gra.Koniec)
                return;

            przycisk.Content = gra.Gracz;

            gra.Plansza[Grid.GetRow(przycisk) - 1,
                        Grid.GetColumn(przycisk)] = gra.Gracz;

            if (gra.SprawdzWygrana())
            {
                status.Text = "Wygrywa gracz: " + gra.Gracz;
                gra.Koniec = true;
                return;
            }

            gra.Licznik++;

            if (gra.Licznik == 9)
            {
                status.Text = "Remis!";
                gra.Koniec = true;
                return;
            }

            if (gra.Gracz == "X")
                gra.Gracz = "O";
            else
                gra.Gracz = "X";

            status.Text = "Ruch gracza: " + gra.Gracz;
        }
    }

    public class Gra
    {
        public string[,] Plansza = new string[3, 3];

        public string Gracz = "X";

        public int Licznik = 0;

        public bool Koniec = false;

        public bool SprawdzWygrana()
        {
            // Wiersze
            for (int i = 0; i < 3; i++)
            {
                if (Plansza[i, 0] == Gracz &&
                    Plansza[i, 1] == Gracz &&
                    Plansza[i, 2] == Gracz)
                    return true;
            }

            // Kolumny
            for (int i = 0; i < 3; i++)
            {
                if (Plansza[0, i] == Gracz &&
                    Plansza[1, i] == Gracz &&
                    Plansza[2, i] == Gracz)
                    return true;
            }

            // Przekatne
            if (Plansza[0, 0] == Gracz &&
                Plansza[1, 1] == Gracz &&
                Plansza[2, 2] == Gracz)
                return true;

            if (Plansza[0, 2] == Gracz &&
                Plansza[1, 1] == Gracz &&
                Plansza[2, 0] == Gracz)
                return true;

            return false;
        }
    }
}
