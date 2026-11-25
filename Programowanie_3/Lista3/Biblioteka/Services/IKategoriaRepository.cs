using Biblioteka.Models;

namespace Biblioteka.Services
{
    public interface IKategoriaRepository
    {
        Task<IReadOnlyList<Kategoria>> GetAllAsync();
    }
}