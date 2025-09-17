using MemoriaLitteraria.Interfaces;
using MemoriaLitteraria.Models;
using MongoDB.Driver;

namespace MemoriaLitteraria.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMongoCollection<Author> _authors;

        public AuthorRepository(IMongoDatabase database)
        {
            _authors = database.GetCollection<Author>("authors");
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            var filter = Builders<Author>.Filter.Eq(a => a.AuthorId, id);
            var author = await _authors.Find(filter).FirstOrDefaultAsync();
            return author;
        }
    }
}
