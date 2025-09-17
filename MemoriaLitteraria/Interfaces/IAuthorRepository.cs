using MemoriaLitteraria.Models;

namespace MemoriaLitteraria.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<Author> GetAuthorAsync(int id);
    }
}
