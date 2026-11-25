using Biblioteka.Models;

namespace Biblioteka.Services
{
    public class InMemoryKsiazkaRepository : IKsiazkaRepository
    {
        private readonly List<Ksiazka> ksiazki = DaneStartowe.Ksiazki();
        private readonly List<Kategoria> kategorie = DaneStartowe.Kategorie();
        // 4.7 - tryb tesstowy: AddSync rzuca wyjatek, zeby sprawdzic try/catch w MainVM
        public bool SymulacjaBlad { get; set; }

        /*
        zadanie 2.5 odczyt zwraca kopie
        gdy zwracalem referencje, zmiana tytulu w formularzu od razu zmieniala obiekt
        w liscie repo. Po Odswiez zmiana nadal byla widoczna chociaz nic nie zapisalem,
        "repozytorium" nie bylo odizolowane.
        Baza tak sie nie zachowa, wiec w pamieci tez tak nie moze.
        */

        private Ksiazka Kopia(Ksiazka k)
        {
            return new Ksiazka
            {
                Id = k.Id,
                Tytul = k.Tytul,
                Autor = k.Autor,
                RokWydania = k.RokWydania,
                KategoriaId = k.KategoriaId,
                Przeczytana = k.Przeczytana,
                // tak jak pozniej JOIN w SQL - nazwa kategorii do wyswietlenia
                KategoriaNazwa = kategorie.FirstOrDefault(x => x.Id == k.KategoriaId)?.Nazwa ?? ""
            };
        }

        public Task<IReadOnlyList<Ksiazka>> GetAllAsync()
        {
            if (SymulacjaBlad)
                throw new InvalidOperationException("Symulacja blad warstwy danych");
            IReadOnlyList<Ksiazka> wynik = ksiazki.Select(Kopia).ToList();
            return Task.FromResult(wynik);
        }

        public Task<Ksiazka?> GetByIdAsync(int id)
        {
            var k = ksiazki.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(k == null ? null : Kopia(k));
        }

        // zadanie 2.4 - nowe Id = najwieksze + 1, tak jak IDENTITY w bazie
        public Task<int> AddAsync(Ksiazka k)
        {
            int noweId = ksiazki.Count == 0 ? 1 : ksiazki.Max(x => x.Id) + 1;
            k.Id = noweId;
            ksiazki.Add(Kopia(k));
            return Task.FromResult(noweId);
        }

        public Task UpdateAsync(Ksiazka k)
        {
            int index = ksiazki.FindIndex(x => x.Id == k.Id);
            if (index >= 0)
            {
                ksiazki[index] = Kopia(k);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            ksiazki.RemoveAll(x => x.Id == id);
            return Task.CompletedTask;
        }
    }
}