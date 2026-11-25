using Biblioteka.Models;

namespace Biblioteka.Services
{
    public class InMemoryKategoriaRepository :IKategoriaRepository
    {
        private readonly List<Kategoria> kategorie = DaneStartowe.Kategorie();

        public Task<IReadOnlyList<Kategoria>> GetAllAsync() {
            IReadOnlyList<Kategoria> wynik = kategorie.Select(k => new Kategoria { Id = k.Id, Nazwa = k.Nazwa }).ToList();
            return Task.FromResult(wynik);
        }
    }
}
