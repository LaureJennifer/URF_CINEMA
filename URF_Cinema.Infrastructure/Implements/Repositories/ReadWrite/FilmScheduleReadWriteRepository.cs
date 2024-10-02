using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadWrite
{
    public class FilmScheduleReadWriteRepository : IFilmScheduleReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public FilmScheduleReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddFilmScheduleAsync(FilmScheduleEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.FilmScheduleEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create film schedule"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "film schedule"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteFilmScheduleAsync(FilmScheduleDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var filmSchedule_ = await GetFilmScheduleByIdAsync(request.Id, cancellationToken);

                filmSchedule_!.Deleted = true;
                filmSchedule_.DeletedBy = request.DeletedBy;
                filmSchedule_.DeletedTime = DateTimeOffset.UtcNow;
                filmSchedule_.Status = EntityStatus.Deleted;

                _dbContext.FilmScheduleEntities.Update(filmSchedule_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete film schedule"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "film schedule"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateFilmScheduleAsync(FilmScheduleEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var filmSchedule_ = await GetFilmScheduleByIdAsync(entity.Id, cancellationToken);

                filmSchedule_!.ShowTime = entity.ShowTime;
                filmSchedule_.ShowDate = entity.ShowDate;
                filmSchedule_.ModifiedBy = entity.ModifiedBy;
                filmSchedule_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.FilmScheduleEntities.Update(filmSchedule_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update film schedule"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "film schedule"
                    }
                });
            }
        }
        private async Task<FilmScheduleEntity?> GetFilmScheduleByIdAsync(Guid idFilmSchedule, CancellationToken cancellationToken)
        {
            var filmSchedule_ = await _dbContext.FilmScheduleEntities.FirstOrDefaultAsync(c => c.Id == idFilmSchedule && !c.Deleted, cancellationToken);

            return filmSchedule_;
        }
    }
}
