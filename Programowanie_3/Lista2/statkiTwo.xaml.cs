using System.Windows;

namespace Lista2
{
    public partial class statkiTwo : Window
    {
        public statkiTwo()
        {
            InitializeComponent();
            DataContext = GameData.Player2;
        }
    }
}