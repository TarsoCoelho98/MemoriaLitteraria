using MemoriaLitteraria.Models;

namespace MemoriaLitteraria.Interfaces
{
    public interface ISectionRepository
    {
        public Task<List<Section>> GetSectionsAsync(string search);
    }
}
