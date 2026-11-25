using Biblioteka.Models;
using Biblioteka.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Biblioteka.ViewModels
{
    public partial class MainVM : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<Ksiazka> ksiazki = new();
        [ObservableProperty] private ObservableCollection<Kategoria> kategorie = new();
        [ObservableProperty][NotifyCanExecuteChangedFor(nameof(ZapiszCommand))] private Ksiazka? wybranaKsiazka; // daje to public wlasciwosc WybranaKsiazka
        [RelayCommand] private async Task Odswiez() {
            Ksiazki = new ObservableCollection<Ksiazka>(await ksiazkaRepo.GetAllAsync());
            Kategorie = new ObservableCollection<Kategoria>(await kategoriaRepo.GetAllAsync());
        } // generator robi z tego OdzswiezCommand
        [RelayCommand(CanExecute = nameof(CzyWybranoKsiazke))] private void Zapisz() { } // generator robi z tego ZapiszCommand
        private bool CzyWybranoKsiazke() { return WybranaKsiazka != null; }

        /*wnioski z Etapu 1:
        - generator zrobiw publiczna wlasciwosc WybranaKsiazka z get/set, ktora sprawdza czy wartosc sie zmienila i wywoluje OnPropertyChanged
        - wlasciwosc OdzswiezCommand i ZapiszCommand typu IRelayCommand zamiast wlasney klasy RealayCommand
        - przy zmianie wlasciwosci WybranaKsiazka wywoluje ZapiszCommand.NotifyCanExecuteChangedFor(nameof(ZapiszCommand))]

        Zadanie 1.5:
        bez NotifyCanExecuteChangedFor przyczisk Zapisz nie zmienia stanu po zaznaczeniu/odznaczeniu ksiazki, bo toolKit nie uzywa CommandManager
        */

        private readonly IKsiazkaRepository ksiazkaRepo;
        private readonly IKategoriaRepository kategoriaRepo;

        // VM dostaje repo z zewnatrz przez interfejs, sam ich nie tworzy.
        // Nie wie, skad pochodza dane - zrodlo mozna podmienic w App.xaml.cs.
        public MainVM(IKsiazkaRepository ksiazkaRepo, IKategoriaRepository kategoriaRepo)
        {
            this.ksiazkaRepo = ksiazkaRepo;
            this.kategoriaRepo = kategoriaRepo;
        }
    }
}