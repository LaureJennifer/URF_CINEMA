using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;
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

        public async Task<RequestResult<bool>> DeleteFilmScheduleAsync(FilmScheduleDeleteRequest request, CancellationToken cancellationToken)
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

                return RequestResult<bool>.Succeed(true);
            }
            catch (Exception e)
            {
                return RequestResult<bool>.Fail(_localizationService["Unable to delete film schedule"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "film schedule"
                    }
                });
            }
        }

        public async Task<RequestResult<bool>> UpdateFilmScheduleAsync(FilmScheduleEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var filmSchedule_ = await GetFilmScheduleByIdAsync(entity.Id, cancellationToken);

                filmSchedule_.ShowTime = entity.ShowTime;
                filmSchedule_.ShowDate = entity.ShowDate;
                filmSchedule_.ModifiedBy = entity.ModifiedBy;
                filmSchedule_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.FilmScheduleEntities.Update(filmSchedule_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<bool>.Succeed(true);
            }
            catch (Exception e)
            {
                return RequestResult<bool>.Fail(_localizationService["Unable to update film schedule"], new[]
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
            var example = await _dbContext.FilmScheduleEntities.FirstOrDefaultAsync(c => c.Id == idFilmSchedule && !c.Deleted, cancellationToken);

            return example;
        }
    }
}
