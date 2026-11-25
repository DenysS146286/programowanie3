using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lista2
{
    public class GraStatki : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Stany pola na planszy
        public const int Puste = 0;
        public const int Statek = 1;
        public const int Pudlo = 2;
        public const int Trafienie = 3;

        // Plansze[0] - plansza gracza 1, Plansze[1] - plansza gracza 2
        public ObservableCollection<int>[] Plansze =
        {
            new ObservableCollection<int>(new int[100]),
            new ObservableCollection<int>(new int[100])
        };

        private int _aktualnyGracz = 0;

        // 0 albo 1
        public int AktualnyGracz
        {
            get { return _aktualnyGracz; }
            private set
            {
                _aktualnyGracz = value;
                OnPropertyChanged("AktualnyGracz");
            }
        }

        private bool _koniec = false;

        public bool Koniec
        {
            get { return _koniec; }
            private set
            {
                _koniec = value;
                OnPropertyChanged("Koniec");
            }
        }

        public int Zwyciezca { get; private set; } = -1;

        public void ZmienStatek(int gracz, int numerPola)
        {
            if (Koniec)
                return;

            var plansza = Plansze[gracz];

            // Nie mozna zmieniac pola, w ktore przeciwnik juz strzelal.
            if (plansza[numerPola] == Puste)
                plansza[numerPola] = Statek;
            else if (plansza[numerPola] == Statek)
                plansza[numerPola] = Puste;
        }

        public void Strzal(int gracz, int numerPola)
        {
            if (Koniec || AktualnyGracz != gracz)
                return;

            var planszaPrzeciwnika = Plansze[1 - gracz];

            if (planszaPrzeciwnika[numerPola] == Pudlo ||
                planszaPrzeciwnika[numerPola] == Trafienie)
                return;

            if (planszaPrzeciwnika[numerPola] == Statek)
            {
                planszaPrzeciwnika[numerPola] = Trafienie;

                if (!planszaPrzeciwnika.Contains(Statek))
                {
                    Zwyciezca = gracz;
                    Koniec = true;
                    return;
                }
            }
            else
            {
                planszaPrzeciwnika[numerPola] = Pudlo;
            }

            AktualnyGracz = 1 - AktualnyGracz;
        }

        void OnPropertyChanged(string nazwa)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwa));
        }
    }
}
