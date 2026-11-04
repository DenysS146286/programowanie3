
namespace Lista2
{
    public class GraStatki
    {
        public bool[,] Statki = new bool[2, 100];
        public bool[,] Strzaly = new bool[2, 100];

        public int AktualnyGracz = 1;
        public int[] Trafienia = new int[2];

        public bool Koniec = false;
        public int Zwyciezca = 0;

        public void ZmienStatek(int gracz, int numerPola)
        {
            if (Koniec)
                return;

            // Nie mozna zmienic statku,
            // jezeli przeciwnik juz strzelal w to pole.
            if (Strzaly[1 - gracz, numerPola])
                return;

            Statki[gracz, numerPola] =
                !Statki[gracz, numerPola];
        }

        public void Strzal(int gracz, int numerPola)
        {
            if (Koniec || AktualnyGracz != gracz + 1)
                return;

            if (Strzaly[gracz, numerPola])
                return;

            Strzaly[gracz, numerPola] = true;

            if (Statki[1 - gracz, numerPola])
            {
                Trafienia[gracz]++;

                int liczbaStatkow = 0;

                for (int i = 0; i < 100; i++)
                {
                    if (Statki[1 - gracz, i])
                        liczbaStatkow++;
                }

                if (Trafienia[gracz] == liczbaStatkow &&
                    liczbaStatkow > 0)
                {
                    Koniec = true;
                    Zwyciezca = gracz + 1;
                }
            }

            if (!Koniec)
                AktualnyGracz = 3 - AktualnyGracz;
        }

        // Stan pola na mojej planszy.
        public string PobierzStanMojejPlanszy(
            int gracz, int numerPola)
        {
            if (Strzaly[1 - gracz, numerPola])
            {
                if (Statki[gracz, numerPola])
                    return "Hit";

                return "Miss";
            }

            if (Statki[gracz, numerPola])
                return "Ship";

            return "Empty";
        }

        // Stan pola na planszy przeciwnika.
        public string PobierzStanPola(
            int gracz, int numerPola)
        {
            if (Strzaly[gracz, numerPola])
            {
                if (Statki[1 - gracz, numerPola])
                    return "Hit";

                return "Miss";
            }

            return "Empty";
        }
    }
}
