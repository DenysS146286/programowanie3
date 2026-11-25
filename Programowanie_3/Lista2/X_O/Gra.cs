using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lista2
{
    public class Gra : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // "" = puste pole, "X" albo "O"
        public ObservableCollection<string> Pola { get; } = new ObservableCollection<string>();

        private string _status = "Ruch gracza: X";

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public string Gracz { get; private set; } = "X";

        public bool Koniec { get; private set; } = false;

        private int licznik = 0;

        public Gra()
        {
            for (int i = 0; i < 9; i++)
                Pola.Add("");
        }

        public void Ruch(int numerPola)
        {
            if (Koniec || Pola[numerPola] != "")
                return;

            Pola[numerPola] = Gracz;
            licznik++;

            if (SprawdzWygrana())
            {
                Status = "Wygrywa gracz: " + Gracz;
                Koniec = true;
                return;
            }

            if (licznik == 9)
            {
                Status = "Remis!";
                Koniec = true;
                return;
            }

            Gracz = Gracz == "X" ? "O" : "X";
            Status = "Ruch gracza: " + Gracz;
        }

        private bool SprawdzWygrana()
        {
            int[,] linie =
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // wiersze
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // kolumny
                { 0, 4, 8 }, { 2, 4, 6 }               // przekatne
            };

            for (int i = 0; i < 8; i++)
            {
                if (Pola[linie[i, 0]] == Gracz &&
                    Pola[linie[i, 1]] == Gracz &&
                    Pola[linie[i, 2]] == Gracz)
                    return true;
            }

            return false;
        }

        void OnPropertyChanged(string nazwa)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwa));
        }
    }
}
