using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Lista2
{
    public class KalkulatorViewModel : INotifyPropertyChanged
    {
        private string display = "0";
        private double firstNumber;
        private string operation = "";
        private bool newNumber = true;

        public string Display
        {
            get => display;
            set { display = value; OnPropertyChanged(); }
        }

        public ICommand PressCommand { get; }

        public KalkulatorViewModel() =>
            PressCommand = new RelayCommand(p => Press((string)p!));

        private void Press(string value)
        {
            if (value == "C")
            {
                Display = "0";
                firstNumber = 0;
                operation = "";
                newNumber = true;
                return;
            }

            if ("0123456789".Contains(value))
            {
                Display = newNumber || Display == "0" ? value : Display + value;
                newNumber = false;
                return;
            }

            if (value == "=")
            {
                if (operation == "") return;

                double second = double.Parse(Display);
                if (operation == "/" && second == 0)
                {
                    Display = "Error";
                    operation = "";
                    newNumber = true;
                    return;
                }

                double result = operation switch
                {
                    "+" => firstNumber + second,
                    "-" => firstNumber - second,
                    "*" => firstNumber * second,
                    "/" => firstNumber / second,
                    _ => 0
                };

                Display = result.ToString();
                operation = "";
                newNumber = true;
                return;
            }

            if (double.TryParse(Display, out double number))
                firstNumber = number;
            operation = value;
            newNumber = true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}