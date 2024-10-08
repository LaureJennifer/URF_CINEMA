﻿using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadWrite
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
                await _dbContext.FilmDetailEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(entity.Id);
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
                var filmDetail_ = await GetFilmDetailByIdAsync(request.Id, cancellationToken);

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

        public async Task<RequestResult<int>> UpdateFilmDetailAsync(FilmDetailEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var filmDetail_ = await GetFilmDetailByIdAsync(entity.Id,cancellationToken);

                filmDetail_!.FilmId = entity.FilmId;
                filmDetail_.FilmScheduleId = entity.FilmScheduleId;

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
        private async Task<FilmDetailEntity?> GetFilmDetailByIdAsync(Guid idFilmDetail, CancellationToken cancellationToken)
        {
            var filmDetail_ = await _dbContext.FilmDetailEntities.FirstOrDefaultAsync(c => c.Id == idFilmDetail, cancellationToken);

            return filmDetail_;
        }
    }
}
