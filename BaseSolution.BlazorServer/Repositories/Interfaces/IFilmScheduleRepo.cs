using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.BlazorServer.Data;
using BaseSolution.BlazorServer.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IFilmScheduleRepo
    {
        public Task<RequestResult<FilmScheduleDto>> GetFilmScheduleByIdAsync(Guid id);

        public Task<FilmScheduleListWithPaginationViewModel> GetAllActive(ViewFilmScheduleWithPaginationRequest request);
        public Task<FilmScheduleListWithPaginationViewModel> GetByShowDateTime(ViewFilmScheduleWithPaginationRequest request);
        public Task<bool> AddAsync(FilmScheduleCreateRequest request);
        
        public Task<bool> UpdateAsync(FilmScheduleUpdateRequest request);
        public Task<bool> DeleteAsync(FilmScheduleDeleteRequest request);
    }
}
