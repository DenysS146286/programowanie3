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

            // ksiazkaRepo.SymulacjaBlad = true; // 4.7 - tryb testowy: symulacja bledu w repozytorium
            //repozytoria tworzymy tu, VM dostaje je przez konstruktor
            IKategoriaRepository kategoriaRepo = new InMemoryKategoriaRepository();
            IKsiazkaRepository ksiazkaRepo = new InMemoryKsiazkaRepository();
            IDialogService dialog = new MessageBoxDailogService();

            MainWindow okno = new MainWindow();
            okno.DataContext = new MainVM(ksiazkaRepo, kategoriaRepo,dialog);
            okno.Show();
        }
    }

}
