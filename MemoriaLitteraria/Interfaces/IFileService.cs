namespace MemoriaLitteraria.Interfaces
{
    public interface IFileService
    {
        public Task<Models.File> GetFileAsync(int id);
    }
}
