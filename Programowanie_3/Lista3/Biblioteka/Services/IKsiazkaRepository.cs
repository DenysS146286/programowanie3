using Biblioteka.Models;

namespace Biblioteka.Services
{
    public interface IKsiazkaRepository
    {
        Task<IReadOnlyList<Ksiazka>> GetAllAsync();
        Task<Ksiazka?> GetByIdAsync(int id);
        Task<int> AddAsync(Ksiazka k);
        Task UpdateAsync(Ksiazka k);
        Task DeleteAsync(int id);
    }
}
