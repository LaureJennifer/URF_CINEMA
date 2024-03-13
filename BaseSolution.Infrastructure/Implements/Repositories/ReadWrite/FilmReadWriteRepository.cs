using BaseSolution.Application.DataTransferObjects.Film.Request;
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
    internal class FilmReadWriteRepository : IFilmReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public FilmReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddFilmAsync(FilmEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedTime = DateTimeOffset.UtcNow;

                await _dbContext.FilmEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create film"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "film"
                    }
                });
            }
        }

        public async Task<RequestResult<bool>> DeleteFilmAsync(FilmDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var film_ = await GetFilmByIdAsync(request.Id, cancellationToken);

                film_!.Deleted = true;
                film_.DeletedBy = request.DeletedBy;
                film_.DeletedTime = DateTimeOffset.UtcNow;
                film_.Status = EntityStatus.Deleted;

                _dbContext.FilmEntities.Update(film_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<bool>.Succeed(true);
            }
            catch (Exception e)
            {
                return RequestResult<bool>.Fail(_localizationService["Unable to delete film"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "film"
                    }
                });
            }
        }

        public async Task<RequestResult<bool>> UpdateFilmAsync(FilmEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var film_ = await GetFilmByIdAsync(entity.Id, cancellationToken);

                film_!.Title = string.IsNullOrWhiteSpace(entity.Title) ? film_.Title : entity.Title;
                film_.UrlImage = string.IsNullOrWhiteSpace(entity.UrlImage) ? film_.UrlImage : entity.UrlImage;
                film_.Status = entity.Status;
                film_.ModifiedBy = entity.ModifiedBy;
                film_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.FilmEntities.Update(film_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<bool>.Succeed(true);
            }
            catch (Exception e)
            {
                return RequestResult<bool>.Fail(_localizationService["Unable to update film"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "film"
                    }
                });
            }
        }
        private async Task<FilmEntity?> GetFilmByIdAsync(Guid idFilm, CancellationToken cancellationToken)
        {
            var example = await _dbContext.FilmEntities.FirstOrDefaultAsync(c => c.Id == idFilm && !c.Deleted, cancellationToken);

            return example;
        }
    }
}
