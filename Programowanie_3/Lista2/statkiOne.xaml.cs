using System.Windows;

namespace Lista2
{
    public partial class statkiOne : Window
    {
        public statkiOne()
        {
            InitializeComponent();
            DataContext = GameData.Player1;
            new statkiTwo().Show();
        }
    }
}