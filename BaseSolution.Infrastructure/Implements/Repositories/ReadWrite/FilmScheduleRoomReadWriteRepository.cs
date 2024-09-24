using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
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

        public async Task<RequestResult<Guid>> AddFilmScheduleRoomAsync(FilmScheduleRoomEntity entity, CancellationToken cancellationToken)
        {
            try
            {

                await _dbContext.FilmScheduleRoomEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create film schedule room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "film schedule room"
                    }
                });
            }
        }

        public async Task<RequestResult<List<Guid>>> CreateRangeFilmScheduleRoomAsync(List<FilmScheduleRoomEntity> requests, CancellationToken cancellationToken)
        {
            try
            {
                //foreach (var entity in requests)
                //{
                //    entity.CreatedTime = DateTimeOffset.UtcNow;
                //}

                await _dbContext.FilmScheduleRoomEntities.AddRangeAsync(requests);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<List<Guid>>.Succeed(requests.Select(x => x.Id).ToList());
            }
            catch (Exception e)
            {
                return RequestResult<List<Guid>>.Fail(_localizationService["Unable to create range film schedule room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "range film schedule room"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteFilmScheduleRoomAsync(FilmScheduleRoomDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var filmScheduleRoom_ = await GetFilmScheduleRoomByIdAsync(request.Id, cancellationToken);

                //filmScheduleRoom_!.Deleted = true;
                //filmScheduleRoom_.DeletedBy = request.DeletedBy;
                //filmScheduleRoom_.DeletedTime = DateTimeOffset.UtcNow;
                filmScheduleRoom_.Status = EntityStatus.Deleted;

                _dbContext.FilmScheduleRoomEntities.Update(filmScheduleRoom_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete film schedule room"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "film schedule room"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateFilmScheduleRoomAsync(FilmScheduleRoomEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var filmScheduleRoom_ = await GetFilmScheduleRoomByIdAsync(entity.Id, cancellationToken);

                filmScheduleRoom_!.FilmScheduleId = entity.FilmScheduleId;
                filmScheduleRoom_.RoomId = entity.RoomId;
                filmScheduleRoom_.Status = entity.Status;

                _dbContext.FilmScheduleRoomEntities.Update(filmScheduleRoom_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update film schedule room"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "film schedule room"
                    }
                });
            }
        }
        private async Task<FilmScheduleRoomEntity?> GetFilmScheduleRoomByIdAsync(Guid idFilmScheduleRoom, CancellationToken cancellationToken)
        {
            var filmScheduleRoom_ = await _dbContext.FilmScheduleRoomEntities.FirstOrDefaultAsync(c => c.Id == idFilmScheduleRoom, cancellationToken);

            return filmScheduleRoom_;
        }
    }
}
