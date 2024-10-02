using URF_Cinema.Application.DataTransferObjects.Film.Request;
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
    public class FilmReadWriteRepository : IFilmReadWriteRepository
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

        public async Task<RequestResult<int>> DeleteFilmAsync(FilmDeleteRequest request, CancellationToken cancellationToken)
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

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete film"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "film"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateFilmAsync(FilmEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var film_ = await GetFilmByIdAsync(entity.Id, cancellationToken);

                film_!.Title = string.IsNullOrWhiteSpace(entity.Title) ? film_.Title : entity.Title;
                film_!.Code = string.IsNullOrWhiteSpace(entity.Code) ? film_.Code : entity.Code;
                film_.TrailerURL = string.IsNullOrWhiteSpace(entity.TrailerURL) ? film_.TrailerURL : entity.TrailerURL;
                film_.PosterURL = string.IsNullOrWhiteSpace(entity.PosterURL) ? film_.PosterURL : entity.PosterURL;
                film_.AgeRating = string.IsNullOrWhiteSpace(entity.AgeRating) ? film_.AgeRating : entity.AgeRating;
                film_.UrlImage = string.IsNullOrWhiteSpace(entity.UrlImage) ? film_.UrlImage : entity.UrlImage;
                film_.Status = entity.Status;
                film_.ModifiedBy = entity.ModifiedBy;
                film_.ModifiedTime = DateTimeOffset.UtcNow;

                _dbContext.FilmEntities.Update(film_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update film"], new[]
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
            var film_ = await _dbContext.FilmEntities.FirstOrDefaultAsync(c => c.Id == idFilm && !c.Deleted, cancellationToken);

            return film_;
        }
    }
}
