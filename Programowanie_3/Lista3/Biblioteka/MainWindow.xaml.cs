using System.Windows;

namespace Biblioteka
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Konstruktor VM nie moze byc async - nie da sie w nim zrobic await
        //Dlatego dane wczytujemy dopiro po zalodowaniu okna, przez komende VM
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ((ViewModels.MainVM)DataContext).OdswiezCommand.ExecuteAsync(null);
        }
    }
}