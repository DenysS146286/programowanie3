using Biblioteka.Models;

namespace Biblioteka.Services
{
    public class InMemoryKsiazkaRepository
    {
        private readonly List<Ksiazka> ksiazki = DaneStartowe.Ksiazki();
        private readonly List<Kategoria> katrgorie = DaneStartowe.Kategorie();

        /*
        zadanie 2.5 odczyt zwraca kopie
        gdy zwracalem referencje, zmiana tytlu w formularzu  od razu zmieniala obiekt
        w liscie repo. Po Odswiez zmiana nadal byla widoczna chocziaz nic nie zapisalem 
        "repozytorium" nie bylo odizolowane
        baza tak soe nie zachowa , wiec w pamieci tez tak nie moze
        */

        private Ksiazka Kopia(Ksiazka k) {
            return new Ksiazka
            {
                Id = k.Id,
                Tytul = k.Tytul,
                Autor = k.Autor,
                RokWydania = k.RokWydania,
                KategoriaId = k.KategoriaId,
                Przeczytana = k.Przeczytana
            };
        }
        public Task<IReadOnlyList<Ksiazka>> GetAllAsync() {
            IReadOnlyList<Ksiazka> wynik = ksiazki.Select(Kopia).ToList();
            return Task.FromResult(wynik);
        }
        public Task<Ksiazka?> GetByIdAsync(int id) {
            var k = ksiazki.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(k == null ? null : Kopia(k));
        }
        public Task UpdateAsync(Ksiazka k) {
            int index = ksiazki.FindIndex(x => x.Id == k.id);
            if (index >= 0) {
                ksiazki[index] = Kopia(k);
            }
            return Task.CompletedTask;
        }
        public Task DeleteAsync(int id) {
            return Task.CompletedTask;
        }
    }
}