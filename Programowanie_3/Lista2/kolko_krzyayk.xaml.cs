using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lista2
{
    /// <summary>
    /// Interaction logic for kolko_krzyayk.xaml
    /// </summary>
    public partial class kolko_krzyayk : Window
    {
        string player = "X";
        public kolko_krzyayk()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b.Content != null && b.Content.ToString() != "")
                return;

            b.Content = player;
            // Check rows
            if (b1.Content == b2.Content && b2.Content == b3.Content && b1.Content != null && b1.Content.ToString() != "" ||
                b4.Content == b5.Content && b5.Content == b6.Content && b4.Content != null && b4.Content.ToString() != "" ||
                b7.Content == b8.Content && b8.Content == b9.Content && b7.Content != null && b7.Content.ToString() != "" ||

                // Check columns
                b1.Content == b4.Content && b4.Content == b7.Content && b1.Content != null && b1.Content.ToString() != "" ||
                b2.Content == b5.Content && b5.Content == b8.Content && b2.Content != null && b2.Content.ToString() != "" ||
                b3.Content == b6.Content && b6.Content == b9.Content && b3.Content != null && b3.Content.ToString() != "" ||

                // Check diagonals
                b1.Content == b5.Content && b5.Content == b9.Content && b1.Content != null && b1.Content.ToString() != "" ||
                b3.Content == b5.Content && b5.Content == b7.Content && b3.Content != null && b3.Content.ToString() != "")
            {
                MessageBox.Show(player + " wins!");
                return;
            }

            player = player == "X" ? "O" : "X";

        }
    }
}