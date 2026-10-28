using System.Windows;

namespace Lista2
{
    public partial class kolko_krzyayk : Window
    {
        public kolko_krzyayk()
        {
            InitializeComponent();
            DataContext = new KolkoViewModel();
        }
    }
}   