using Biblioteka.Models;
using Biblioteka.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Biblioteka.ViewModels
{
    public partial class MainVM : ObservableObject
    {
        // ===== Repozytoria =====
        private readonly IKsiazkaRepository ksiazkaRepo;
        private readonly IKategoriaRepository kategoriaRepo;

        // VM dostaje repo z zewnatrz przez interfejs, sam ich nie tworzy.
        // Nie wie, skad pochodza dane - zrodlo mozna podmienic w App.xaml.cs.
        public MainVM(IKsiazkaRepository ksiazkaRepo, IKategoriaRepository kategoriaRepo)
        {
            this.ksiazkaRepo = ksiazkaRepo;
            this.kategoriaRepo = kategoriaRepo;
        }

        // ===== Wlasciwosci (generator robi z pol publiczne wlasciwosci) =====
        [ObservableProperty] private ObservableCollection<Ksiazka> ksiazki = new();
        [ObservableProperty] private ObservableCollection<Kategoria> kategorie = new();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ZapiszCommand))]
        [NotifyCanExecuteChangedFor(nameof(UsunCommand))]
        private Ksiazka? wybranaKsiazka;

        // ===== Komendy (generator robi z metod XxxCommand) =====
        [RelayCommand]
        private async Task Odswiez()
        {
            Ksiazki = new ObservableCollection<Ksiazka>(await ksiazkaRepo.GetAllAsync());
            Kategorie = new ObservableCollection<Kategoria>(await kategoriaRepo.GetAllAsync());
        }

        [RelayCommand]
        private async Task Dodaj()
        {
            var nowa = new Ksiazka
            {
                Tytul = "Nowa ksiazka",
                Autor = "?",
                KategoriaId = Kategorie.FirstOrDefault()?.Id ?? 1
            };
            await ksiazkaRepo.AddAsync(nowa);
            await Odswiez();
            WybranaKsiazka = Ksiazki.FirstOrDefault(k => k.Id == nowa.Id);
        }

        // 4
        [RelayCommand(CanExecute = nameof(CzyMoznaZapisac))]
        private async Task Zapisz()
        {
            WybranaKsiazka!.Waliduj(); // ValidateAllProperties
            if (WybranaKsiazka.HasErrors) return;

            await ksiazkaRepo.UpdateAsync(WybranaKsiazka!);
            await Odswiez();
        }

        [RelayCommand(CanExecute = nameof(CzyMoznaUsunac))]
        private async Task Usun()
        {
            await ksiazkaRepo.DeleteAsync(WybranaKsiazka!.Id);
            await Odswiez();
        }

        private bool CzyMoznaZapisac() { 
            return WybranaKsiazka != null && !WybranaKsiazka.HasErrors; 
        }
        // gdy zmienia sie WybranaKsiazka, nasluchujemy jej bledow walidacji,
        // zeby przycisk Zapisz szarzal od razu przy blendym polu

        partial void OnWybranaKsiazkaChanged(Ksiazka? oldValue, Ksiazka? newValue)
        {
            if (oldValue != null) oldValue.ErrorsChanged -= BlendyZmienone;
            if (newValue != null) newValue.ErrorsChanged += BlendyZmienone;
        }

        private void BlendyZmienone(object? sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            ZapiszCommand.NotifyCanExecuteChanged();
        }

        private bool CzyMoznaUsunac() { return WybranaKsiazka != null; }

        /* wnioski z Etapu 1:
        - generator zrobil publiczna wlasciwosc WybranaKsiazka z get/set, ktora sprawdza czy wartosc sie zmienila i wywoluje OnPropertyChanged
        - wlasciwosci OdswiezCommand i ZapiszCommand typu IRelayCommand zamiast wlasnej klasy RelayCommand
        - przy zmianie WybranaKsiazka generator wywoluje ZapiszCommand.NotifyCanExecuteChanged()
 
        Zadanie 1.5:
        bez NotifyCanExecuteChangedFor przycisk Zapisz nie zmienia stanu po zaznaczeniu/odznaczeniu ksiazki, bo Toolkit nie uzywa CommandManager
 
        Zadanie 3.6:
        metody zwracajace Task -> generator robi IAsyncRelayCommand
        */
    }
}