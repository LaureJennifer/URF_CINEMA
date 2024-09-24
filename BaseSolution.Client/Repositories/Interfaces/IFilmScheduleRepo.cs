using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
using BaseSolution.Client.Data;
using BaseSolution.Client.ValueObjects.Response;

namespace BaseSolution.Client.Repositories.Interfaces
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
