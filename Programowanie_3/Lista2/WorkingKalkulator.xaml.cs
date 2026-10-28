using System.Windows;

namespace Lista2
{
    public partial class WorkingKalkulator : Window
    {
        public WorkingKalkulator()
        {
            InitializeComponent();
            DataContext = new KalkulatorViewModel();
        }
    }
}