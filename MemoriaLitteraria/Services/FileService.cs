using MemoriaLitteraria.Interfaces;

namespace MemoriaLitteraria.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _repository;

        public FileService(IFileRepository repository) {
            _repository = repository;
        }

        public async Task<Models.File> GetFileAsync(int id) => await _repository.GetFileAsync(id);
    }
}
