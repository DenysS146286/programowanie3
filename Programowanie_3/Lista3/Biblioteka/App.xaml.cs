using Biblioteka.Models;
using Biblioteka.Services;
using Biblioteka.ViewModels;
using System.Windows;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //repozytoria tworzymy tu, VM dostaje je przez konstruktor
            IKategoriaRepository kategoriaRepo = new InMemoryKategoriaRepository();
            IKsiazkaRepository ksiazkaRepo = new InMemoryKsiazkaRepository();

            MainWindow okno = new MainWindow();
            okno.DataContext = new MainVM(ksiazkaRepo, kategoriaRepo);
            okno.Show();
        }
    }

}
