using MemoriaLitteraria.Models;
using MemoriaLitteraria.Repositories;

namespace MemoriaLitteraria.Services
{
    public class SectionService
    {
        private readonly SectionRepository _repository;

        public SectionService(SectionRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Section>> GetSectionsAsync(string search) => _repository.GetSectionsAsync(search);
    }
}
