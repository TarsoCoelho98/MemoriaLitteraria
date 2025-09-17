using MemoriaLitteraria.Models;

namespace MemoriaLitteraria.Interfaces
{
    public interface IAuthorService
    {
        public Task<Author> GetAuthorAsync(int id);
    }
}
