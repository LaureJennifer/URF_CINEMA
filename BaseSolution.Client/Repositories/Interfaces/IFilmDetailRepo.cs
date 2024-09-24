using BaseSolution.Application.DataTransferObjects.FilmDetail;
using BaseSolution.Application.DataTransferObjects.FilmDetail.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Client.Data;

namespace BaseSolution.Client.Repositories.Interfaces
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
