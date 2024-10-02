using URF_Cinema.Infrastructure.ViewModels;

namespace URF_Cinema.Application.Interfaces.Services
{
    public interface IJsonStorageService<T> where T : class
    {
        Task<Guid> CreateAsync(CreateJsonStorage<T> importFailDto);
        Task<JsonStorageVM<T>> GetByIdEntityJsonAsync(Guid Id);
        Task<bool> DeleteAsync(Guid Id);
    }
}
