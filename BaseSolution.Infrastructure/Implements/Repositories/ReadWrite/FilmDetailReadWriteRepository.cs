using Azure.Core;
using BaseSolution.Application.DataTransferObjects.FilmDetail.Request;
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
    public class FilmDetailReadWriteRepository : IFilmDetailReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public FilmDetailReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddFilmDetailAsync(FilmDetailEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var filmDetail_ = await GetFilmDetailByIdAsync(entity.FilmId, entity.FilmScheduleId, cancellationToken);
                if (filmDetail_ != null)
                {
                    var idRoomDetail = entity..Select(x => x.RoomDetailId).FirstOrDefault();
                    if (idRoomDetail != null)
                    {
                        var roomRetail = _appReadWriteDbContext.RoomDetails.Find(idRoomDetail);
                        if (roomRetail != null)
                        {
                            roomRetail.Status = RoomStatus.Reserved;
                            _appReadWriteDbContext.Update(roomRetail);
                            await _appReadWriteDbContext.SaveChangesAsync(cancellationToken);
                        }
                    }
                }
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.FilmDetailEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(filmDetail_.FilmId);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create film detail"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "film detail"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteFilmDetailAsync(FilmDetailDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var filmDetail_ = await GetFilmDetailByIdAsync(request.FilmId,request.FilmScheduleId, cancellationToken);

                filmDetail_!.Deleted = true;
                filmDetail_.DeletedTime = DateTimeOffset.UtcNow;
                filmDetail_.Status = EntityStatus.Deleted;

                _dbContext.FilmDetailEntities.Update(filmDetail_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete film detail"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "film detail"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateFilmDetailByIdAsync(FilmDetailEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var filmDetail_ = await GetFilmDetailByIdAsync(entity.FilmId,entity.FilmScheduleId, cancellationToken);

                filmDetail_!.FilmId = entity.FilmId;
                filmDetail_.FilmScheduleId = entity.FilmScheduleId;
                filmDetail_.Status = entity.Status;
                filmDetail_.ModifiedBy = entity.ModifiedBy;
                filmDetail_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.FilmDetailEntities.Update(filmDetail_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update film detail"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "film detail"
                    }
                });
            }
        }
        private async Task<FilmDetailEntity?> GetFilmDetailByIdAsync(Guid idFilm, Guid idFilmSchedule, CancellationToken cancellationToken)
        {
            var film_ = await _dbContext.FilmDetailEntities.FirstOrDefaultAsync(c => c.FilmId == idFilm && c.FilmScheduleId == idFilmSchedule && !c.Deleted, cancellationToken);

            return film_;
        }
    }
}
