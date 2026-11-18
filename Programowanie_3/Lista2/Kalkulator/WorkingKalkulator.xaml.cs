using System.Windows;
using System.Windows.Controls;

namespace Lista2
{
    public partial class WorkingKalkulator : Window
    {
        Kalkulator kalkulator = new Kalkulator();

        public WorkingKalkulator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            string znak = przycisk.Content.ToString();

            // CLEAR
            if (znak == "C")
            {
                kalkulator.Wynik = "0";
                kalkulator.Liczba0 = 0;
                kalkulator.Dzialanie = "";
                kalkulator.NowaLiczba = true;
            }

            // OPERATIONS
            else if (znak == "+" || znak == "-" || znak == "*" || znak == "/")
            {
                double liczba;
                double.TryParse(wynik.Text, out liczba);

                kalkulator.Liczba0 = liczba;
                kalkulator.Dzialanie = znak;
                kalkulator.NowaLiczba = true;
            }

            // EQUALS
            else if (znak == "=")
            {
                double liczba2;

                if (!double.TryParse(wynik.Text, out liczba2))
                    return;

                double rezultat = 0;

                switch (kalkulator.Dzialanie)
                {
                    case "+":
                        rezultat = kalkulator.Liczba0 + liczba2;
                        break;

                    case "-":
                        rezultat = kalkulator.Liczba0 - liczba2;
                        break;

                    case "*":
                        rezultat = kalkulator.Liczba0 * liczba2;
                        break;

                    case "/":
                        if (liczba2 == 0)
                        {
                            wynik.Text = "Error";
                            kalkulator.NowaLiczba = true;
                            return;
                        }

                        rezultat = kalkulator.Liczba0 / liczba2;
                        break;
                }

                kalkulator.Wynik = rezultat.ToString();
                kalkulator.Dzialanie = "";
                kalkulator.NowaLiczba = true;
            }

            // NUMBERS
            else
            {
                if (kalkulator.NowaLiczba)
                {
                    kalkulator.Wynik = znak;
                    kalkulator.NowaLiczba = false;
                }
                else
                {
                    if (kalkulator.Wynik == "0")
                        kalkulator.Wynik = znak;
                    else
                        kalkulator.Wynik += znak;
                }
            }

            // UPDATE TEXTBOX
            wynik.Text = kalkulator.Wynik;
        }
    }

    public class Kalkulator
    {
        public string Wynik { get; set; } = "0";

        public double Liczba0 { get; set; }

        public string Dzialanie { get; set; } = "";

        public bool NowaLiczba { get; set; } = true;
    }
}
