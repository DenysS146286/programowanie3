using Biblioteka.Models;
using Biblioteka.Services;

namespace Biblioteka.Services
{
    public static class DaneStartowe
    {
        public static List<Kategoria> Kategorie() {
            return new List<Kategoria>
            {
                new Kategoria { Id = 1, Nazwa = "Fantastyka" },
                new Kategoria { Id = 2, Nazwa = "Kryminal" },
                new Kategoria { Id = 3, Nazwa = "IT" },
                new Kategoria { Id = 4, Nazwa = "Historia" }
            };
        }
        public static List<Ksiazka> Ksiazki()
        {
            // ksiazki bez RokWydania maja null (zadanie 2.3)
            return new List<Ksiazka>
            {
                new Ksiazka { Id = 1,  Tytul = "Wiedzmin", Autor = "Sapkowski", RokWydania = 1990, KategoriaId = 1, Przeczytana = true },
                new Ksiazka { Id = 2,  Tytul = "Hobbit",   Autor = "Tolkien",   RokWydania = 1937, KategoriaId = 1, Przeczytana = true },
                new Ksiazka { Id = 3,  Tytul = "Solaris",  Autor = "Lem",       RokWydania = 1961, KategoriaId = 1 },
                new Ksiazka { Id = 4,  Tytul = "Morderstwo w Orient Expressie", Autor = "Christie", RokWydania = 1934, KategoriaId = 2 },
                new Ksiazka { Id = 5,  Tytul = "Pies Baskerville'ow", Autor = "Doyle", RokWydania = 1902, KategoriaId = 2, Przeczytana = true },
                new Ksiazka { Id = 6,  Tytul = "Kryminal bez daty", Autor = "Nieznany", KategoriaId = 2 },
                new Ksiazka { Id = 7,  Tytul = "Czysty kod", Autor = "Martin", RokWydania = 2008, KategoriaId = 3 },
                new Ksiazka { Id = 8,  Tytul = "C# w pigulce", Autor = "Albahari", KategoriaId = 3 },
                new Ksiazka { Id = 9,  Tytul = "Pragmatyczny programista", Autor = "Hunt", RokWydania = 1999, KategoriaId = 3, Przeczytana = true },
                new Ksiazka { Id = 10, Tytul = "Historia Polski", Autor = "Davies", RokWydania = 1981, KategoriaId = 4 },
                new Ksiazka { Id = 11, Tytul = "Notatki z historii", Autor = "Anonim", KategoriaId = 4 }
            };
        }
    }
}