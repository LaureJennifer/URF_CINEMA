using URF_Cinema.Application.DataTransferObjects.FilmSchedule;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Manage.Data;
using URF_Cinema.Manage.Data.ValueObjects.Response;

namespace URF_Cinema.Manage.Repositories.Interfaces
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
