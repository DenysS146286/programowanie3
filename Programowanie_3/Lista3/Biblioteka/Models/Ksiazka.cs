using CommunityToolkit.Mvvm.ComponentModel;

namespace Biblioteka.Models
{
    internal partial class Ksiazka : ObservableObject
    {
        // ksiazke edetyjemy w apce, wiec ona i musze powiadamiac o zmianich
        // np zaznaczamy przeczytana s widok musi sie odswiezyc
        //Kategorii nie edytujemy , tylko wyswietlamy , wiec nie musze powiadamiac o zmianach

        [ObservableProperty] private int id;
        [ObservableProperty] private string tytul = "";
        [ObservableProperty] private string autor = "";
        [ObservableProperty] private int? rokWydania;
        [ObservableProperty] private int kategoriaId;
        [ObservableProperty] private bool przeczytana;

        [ObservableProperty] private string kategoriaNazwa = "";
    }
}
