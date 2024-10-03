using BaseSolution.BlazorServer.Data;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Application.DataTransferObjects.Film;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IFilmRepo
    {
        public Task<FilmListWithPaginationViewModel> GetAll();
        public Task<string> AddAsync(FilmCreateRequest request);
        public Task<RequestResult<FilmDeleteRequest>> RemoveAsync(FilmDeleteRequest request);
        public Task<bool> UpdateAsync(FilmUpdateRequest request);
        public Task<RequestResult<FilmDto>> GetByIdAsync(Guid id);
        public Task<FilmListWithPaginationViewModel> GetAllActive(ViewFilmWithPaginationRequest request);
    }
}
