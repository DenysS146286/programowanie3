using Biblioteka.Models;

namespace Biblioteka.Services
{
    internal interface IKategoriaRepository
    {
        Task<IReadOnlyList<Kategoria>> GetAllAsync();
    }
}