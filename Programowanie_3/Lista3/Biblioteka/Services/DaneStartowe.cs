using Biblioteka.Models;
using Biblioteka.Services;

namespace Biblioteka.Services
{
    public static class DaneStartowe
    {
        public static List<Kategoria> Kategorie() {
            new Kategoria { Id = 1, Nazwa = "Fantastyka" };
            new Kategoria { Id = 2, Nazwa = "Kryminal" };
            new Kategoria { Id = 3, Nazwa = "IT" };
            new Kategoria { Id = 4, Nazwa = "Historia" };
        }
        public static List<Ksiazka> Ksiazki() {
            new Ksiazka { Id = 1, Tytul = "Wiedzmin", Autor = "Andrzej S.", RokWydania = 1990, KategoriaId = 1, Przeczytana = true };
            new Ksiazka { Id = 2, Tytul = "X", Autor = "W S.", RokWydania = 1937, KategoriaId = 1, Przeczytana = true };
            new Ksiazka { Id = 3, Tytul = "Y", Autor = "E S.", RokWydania = 1965, KategoriaId = 1, Przeczytana = false };
            new Ksiazka { Id = 4, Tytul = "Z", Autor = "Q S.", RokWydania = 1934, KategoriaId = 2, Przeczytana = false };
            new Ksiazka { Id = 5, Tytul = "C", Autor = "R S.", RokWydania = 1902, KategoriaId = 2, Przeczytana = true };
            new Ksiazka { Id = 6, Tytul = "B", Autor = "T S.", RokWydania = null, KategoriaId = 2, Przeczytana = false };
            new Ksiazka { Id = 7, Tytul = "N", Autor = "Y S.", RokWydania = 2008, KategoriaId = 3, Przeczytana = false };
            new Ksiazka { Id = 8, Tytul = "A", Autor = "U S.", RokWydania = 1990, KategoriaId = 3, Przeczytana = true };
            new Ksiazka { Id = 9, Tytul = "S", Autor = "I S.", RokWydania = null, KategoriaId = 3, Przeczytana = false };
            new Ksiazka { Id = 10, Tytul = "D", Autor = "H S.", RokWydania = 1981, KategoriaId = 4, Przeczytana = false };
            new Ksiazka { Id = 11, Tytul = "F", Autor = "G S.", RokWydania = null, KategoriaId = 4, Przeczytana = false };
        }
    }
}