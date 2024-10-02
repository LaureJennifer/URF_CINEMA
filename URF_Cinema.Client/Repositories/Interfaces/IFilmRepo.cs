using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Client.Data;

namespace URF_Cinema.Client.Repositories.Interfaces
{
    public interface IFilmRepo
    {
        public Task<FilmListWithPaginationViewModel> GetAll();
        public Task<bool> AddAsync(FilmCreateRequest request);
        public Task<RequestResult<FilmDeleteRequest>> RemoveAsync(FilmDeleteRequest request);
        public Task<bool> UpdateAsync(FilmUpdateRequest request);
        public Task<RequestResult<FilmDto>> GetByIdAsync(Guid id);
        public Task<FilmListWithPaginationViewModel> GetAllActive(ViewFilmWithPaginationRequest request);
    }
}
