using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadWrite
{
    public class FilmScheduleRoomReadWriteRepository : IFilmScheduleRoomReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public FilmScheduleRoomReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public Task<RequestResult<Guid>> AddFilmScheduleRoomAsync(FilmScheduleRoomEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> DeleteFilmScheduleRoomAsync(FilmSheduleRoomDeleteRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> UpdateFilmScheduleRoomAsync(FilmScheduleRoomEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
