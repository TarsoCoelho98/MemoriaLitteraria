using MemoriaLitteraria.Interfaces;
using MemoriaLitteraria.Models;
using MemoriaLitteraria.Repositories;

namespace MemoriaLitteraria.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Author> GetAuthorAsync(int id) => await _repository.GetAuthorAsync(id);
    }
}
