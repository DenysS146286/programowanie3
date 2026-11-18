using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Biblioteka.Models;
using Biblioteka.Services;

namespace Biblioteka.ViewModels
{
    public partial class MainVM : ObservableObject
    {
        [ObservableProperty][NotifyCanExecuteChangedFor(nameof(ZapiszCommand))] private Ksiazka? wybranaKsiazka; // daje to public wlasciwosc WybranaKsiazka
        [RelayCommand] private void Odswiez() { } // generator robi z tego OdzswiezCommand
        [RelayCommand(CanExecute = nameof(CzyWybranoKsiazke))] private void Zapisz() { } // generator robi z tego ZapiszCommand
        private bool CzyWybranoKsiazke() { return WybranaKsiazka != null; }

        /*wnioski z Etapu 1:
        - generator zrobiw publiczna wlasciwosc WybranaKsiazka z get/set, ktora sprawdza czy wartosc sie zmienila i wywoluje OnPropertyChanged
        - wlasciwosc OdzswiezCommand i ZapiszCommand typu IRelayCommand zamiast wlasney klasy RealayCommand
        - przy zmianie wlasciwosci WybranaKsiazka wywoluje ZapiszCommand.NotifyCanExecuteChangedFor(nameof(ZapiszCommand))]

        Zadanie 1.5:
        bez NotifyCanExecuteChangedFor przyczisk Zapisz nie zmienia stanu po zaznaczeniu/odznaczeniu ksiazki, bo toolKit nie uzywa CommandManager
        */

        private readonly InMemoryKsiazkaRepository ksiazkaRepo;
        private readonly InMemoryKategoriaRepository kategoriaRepo;

        //VM dostaje repo z zewnatrz, sam ich nie tworzy
        public MainVM(InMemoryKsiazkaRepository ksiazkaRepo, InMemoryKategoriaRepository kategoriaRepo)
        {
            this.ksiazkaRepo = ksiazkaRepo;
            this.kategoriaRepo = kategoriaRepo;
        }
    }
}