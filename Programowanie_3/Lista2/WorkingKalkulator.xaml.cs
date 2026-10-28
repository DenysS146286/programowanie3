using System;
using System.Windows;
using System.Windows.Controls;

namespace Lista2
{
    public partial class WorkingKalkulator : Window
    {
        private double firstNumber = 0;
        private string operation = "";
        private bool newNumber = true;

        public WorkingKalkulator()
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
                firstNumber = 0;
                operation = "";
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
                if (operation == "")
                    return;

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
                        if (secondNumber == 0)
                        {
                            wynik.Text = "Error";
                            operation = "";
                            newNumber = true;
                            return;
                        }

                        result = firstNumber / secondNumber;
                        break;
                }

                wynik.Text = result.ToString();
                operation = "";
                newNumber = true;
                return;
            }

            if (double.TryParse(wynik.Text, out double number))
                firstNumber = number;

            operation = value;
            newNumber = true;
        }
    }
}
