using MemoriaLitteraria.Repositories;

namespace MemoriaLitteraria.Services
{
    public class FileService
    {
        private readonly FileRepository _repository;

        public FileService(FileRepository repository) {
            _repository = repository;
        }

        public Task<Models.File> GetFileAsync(int id) => _repository.GetFileAsync(id);
    }
}
