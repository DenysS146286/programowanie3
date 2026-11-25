using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lista2
{
    // To, co widzi jeden gracz. Jedna klasa dla obu graczy (DRY).
    public class GraczWidok : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public GraStatki Gra { get; }

        // 0 albo 1
        public int Gracz { get; }

        public GraczWidok(GraStatki gra, int gracz)
        {
            Gra = gra;
            Gracz = gracz;

            // Gdy zmieni sie stan gry, odswiez status w oknie.
            Gra.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged("Status");
                OnPropertyChanged("MojaTura");
                OnPropertyChanged("MogeUstawiac");
            };
        }

        public string Tytul => "Gracz " + (Gracz + 1);

        public ObservableCollection<int> Moja => Gra.Plansze[Gracz];

        public ObservableCollection<int> Przeciwnika => Gra.Plansze[1 - Gracz];

        public bool MojaTura => !Gra.Koniec && Gra.AktualnyGracz == Gracz;

        public bool MogeUstawiac => !Gra.Koniec;

        public string Status
        {
            get
            {
                if (Gra.Koniec)
                    return "Wygral gracz " + (Gra.Zwyciezca + 1);

                if (MojaTura)
                    return "Twoja kolej - " + Tytul;

                return "Czekasz na Gracza " + (2 - Gracz);
            }
        }

        void OnPropertyChanged(string nazwa)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwa));
        }
    }
}
