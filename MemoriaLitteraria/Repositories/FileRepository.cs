using MongoDB.Driver;
using MemoriaLitteraria.Models;

namespace MemoriaLitteraria.Repositories
{
    public class FileRepository
    {
        private readonly IMongoCollection<Models.File> _files;

        public FileRepository(IMongoDatabase database)
        {
            _files = database.GetCollection<Models.File>("files");
        }

        public async Task<Models.File> GetFileAsync(int id)
        {
            var filter = Builders<Models.File>.Filter.Eq(a => a.FileId, id);
            var file = await _files.Find(filter).FirstOrDefaultAsync();
            return file;
        }
    }
}
