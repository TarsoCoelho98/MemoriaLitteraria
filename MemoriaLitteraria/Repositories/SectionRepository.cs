using MemoriaLitteraria.Models;
using MongoDB.Driver;

namespace MemoriaLitteraria.Repositories
{
    public class SectionRepository
    {
        private readonly IMongoCollection<Section> _sections;
        const int MaxSectionCount = 10;

        public SectionRepository(IMongoDatabase database)
        {
            _sections = database.GetCollection<Section>("sections");
        }

        public async Task<List<Section>> GetSectionsAsync(string search)
        {
            var filter = Builders<Section>.Filter.Text(search);
            List<Section> sections = await _sections.Find(filter).Limit(MaxSectionCount).ToListAsync();
            return sections;
        }
    }
}
