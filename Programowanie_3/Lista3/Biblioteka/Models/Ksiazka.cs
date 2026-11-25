using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    // 4.1 - ObservableValidator zamiast recznego INotifyDataErrorInfo
    // (dziedziczy po ObservableObject wiec ObservableProperty dalej dziala)
    public partial class Ksiazka : ObservableValidator
    {
        // ksiazke edetyjemy w apce, wiec ona i musze powiadamiac o zmianich
        // np zaznaczamy przeczytana s widok musi sie odswiezyc
        //Kategorii nie edytujemy , tylko wyswietlamy , wiec nie musze powiadamiac o zmianach

        [ObservableProperty] private int id;


        // 4.2 - [Required] dla tytułu i autora
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "tytul is required")]
        private string tytul = "";


        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "autor is required")]
        private string autor = "";

        // 4.2 - [Range] dla dolnej granicy (jest stala)
        // 4.2 - gorna (biezacy rok) nie jest stala -> [CustomValidation]
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Range(1450, int.MaxValue, ErrorMessage = "Rok nie moze byc mniejszy niz 1450")]
        [CustomValidation(typeof(Ksiazka), nameof(SprawdzRok))]
        private int? rokWydania;


        [ObservableProperty] private int kategoriaId;


        [ObservableProperty] private bool przeczytana;


        [ObservableProperty] private string kategoriaNazwa = "";

        public static ValidationResult? SprawdzRok(int? rok, ValidationContext context)
        {
            //if (rok == null) return ValidationResult.Success;
            if (rok > DateTime.Now.Year)
                return new ValidationResult("Rok nie moze byc z przyszlosci");
            return ValidationResult.Success; // null chyba OK?
        }
        //ValidateAllProperties jest protected, wiec VM wola go przez ta metode (4.3)
        public void Waliduj() => ValidateAllProperties();
    }
}
