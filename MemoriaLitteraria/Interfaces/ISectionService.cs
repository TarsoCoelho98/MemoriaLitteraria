using MemoriaLitteraria.Models;

namespace MemoriaLitteraria.Interfaces
{
    public interface ISectionService
    {
        public Task<List<Section>> GetSectionsAsync(string search);
    }
}
