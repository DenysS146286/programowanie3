using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lista2
{
    public partial class MainWindow : Window
    {
        private double firstNumber = 0;
        private string operation = "";
        private bool newNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void On_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string value = button.Content.ToString();

            if (value == "C")
            {
                wynik.Text = "0";
                newNumber = true;
                return;
            }

            if ("0123456789".Contains(value))
            {
                if (newNumber || wynik.Text == "0")
                    wynik.Text = value;
                else
                    wynik.Text += value;
                newNumber = false;
                return;
            }

            if (value == "=")
            {
                double secondNumber = double.Parse(wynik.Text);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        result = firstNumber / secondNumber;
                        break;
                }
                wynik.Text = result.ToString();
                newNumber = true;
                operation = "";
                return;
            }

            firstNumber = double.Parse(wynik.Text);
            operation = value;
            newNumber = true;
        }
    }
}