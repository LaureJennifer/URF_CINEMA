using URF_Cinema.Application.DataTransferObjects.FilmDetail;
using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Client.Data;

namespace URF_Cinema.Client.Repositories.Interfaces
{
    public interface IFilmDetailRepo
    {
        public Task<bool> AddAsync(FilmDetailCreateRequest request);
        public Task<RequestResult<FilmDetailDeleteRequest>> RemoveAsync(FilmDetailDeleteRequest request);
        public Task<bool> UpdateAsync(FilmDetailUpdateRequest request);
        public Task<RequestResult<FilmDetailDto>> GetByIdAsync(Guid id);
        public Task<FilmDetailListWithPaginationViewModel> GetAllActive(ViewFilmDetailWithPaginationRequest request);
        public Task<FilmDetailListWithPaginationViewModel> GetFilmScheduleByFilm(ViewFilmDetailWithPaginationRequest request);
    }
}
