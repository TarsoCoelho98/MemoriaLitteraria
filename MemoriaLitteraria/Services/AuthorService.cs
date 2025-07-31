using MemoriaLitteraria.Models;
using MemoriaLitteraria.Repositories;

namespace MemoriaLitteraria.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _repository;

        public AuthorService(AuthorRepository repository)
        {
            _repository = repository;
        }

        public Task<Author> GetAuthorAsync(int id) => _repository.GetAuthorAsync(id);
    }
}
