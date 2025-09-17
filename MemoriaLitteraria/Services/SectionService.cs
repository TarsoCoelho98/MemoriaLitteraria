using MemoriaLitteraria.Interfaces;
using MemoriaLitteraria.Models;

namespace MemoriaLitteraria.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _repository;

        public SectionService(ISectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Section>> GetSectionsAsync(string search) => await _repository.GetSectionsAsync(search);
    }
}
