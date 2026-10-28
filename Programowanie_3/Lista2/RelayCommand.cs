using System.Windows.Input;

namespace Lista2
{
    internal class RelayCommand : ICommand
    {
        InitializeComponent();
        DataContext = new KolkoViewModel();
    }
}
