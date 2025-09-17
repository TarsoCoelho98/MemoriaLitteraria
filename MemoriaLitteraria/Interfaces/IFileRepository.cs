namespace MemoriaLitteraria.Interfaces
{
    public interface IFileRepository
    {
        public Task<Models.File> GetFileAsync(int id);
    }
}
