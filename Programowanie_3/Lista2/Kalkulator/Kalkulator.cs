using System.ComponentModel;

namespace Lista2
{
    public class Kalkulator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _wynik = "0";

        public string Wynik
        {
            get { return _wynik; }
            set
            {
                _wynik = value;
                OnPropertyChanged("Wynik");
            }
        }

        private double liczba0;
        private string dzialanie = "";
        private bool nowaLiczba = true;

        public void Wcisnij(string znak)
        {
            if (znak == "C")
            {
                Wynik = "0";
                liczba0 = 0;
                dzialanie = "";
                nowaLiczba = true;
            }
            else if (znak == "+" || znak == "-" || znak == "*" || znak == "/")
            {
                double.TryParse(Wynik, out liczba0);
                dzialanie = znak;
                nowaLiczba = true;
            }
            else if (znak == "=")
            {
                Policz();
            }
            else
            {
                if (nowaLiczba || Wynik == "0")
                    Wynik = znak;
                else
                    Wynik += znak;

                nowaLiczba = false;
            }
        }

        private void Policz()
        {
            double liczba2;

            if (!double.TryParse(Wynik, out liczba2))
                return;

            double rezultat = liczba2;

            switch (dzialanie)
            {
                case "+":
                    rezultat = liczba0 + liczba2;
                    break;
                case "-":
                    rezultat = liczba0 - liczba2;
                    break;
                case "*":
                    rezultat = liczba0 * liczba2;
                    break;
                case "/":
                    if (liczba2 == 0)
                    {
                        Wynik = "Error";
                        dzialanie = "";
                        nowaLiczba = true;
                        return;
                    }
                    rezultat = liczba0 / liczba2;
                    break;
            }

            Wynik = rezultat.ToString();
            dzialanie = "";
            nowaLiczba = true;
        }

        void OnPropertyChanged(string nazwa)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwa));
        }
    }
}
