using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;
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
    public class DepartmentFilmReadWriteRepository : IDepartmentFilmReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public DepartmentFilmReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public async Task<RequestResult<Guid>> AddDepartmentFilmAsync(DepartmentFilmEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.DepartmentFilmEntities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return RequestResult<Guid>.Succeed(entity.Id);
            }
            catch (Exception e)
            {
                return RequestResult<Guid>.Fail(_localizationService["Unable to create department film"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToCreate + "department film"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> DeleteDepartmentFilmAsync(DepartmentFilmDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentFilm_ = await GetDepartmentFilmByIdAsync(request.Id, cancellationToken);

                departmentFilm_!.Status = EntityStatus.Deleted;

                _dbContext.DepartmentFilmEntities.Update(departmentFilm_);
                await _dbContext.SaveChangesAsync();

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to delete department film"], new[]
                {
                    new ErrorItem {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToDelete + "department film"
                    }
                });
            }
        }

        public async Task<RequestResult<int>> UpdateDepartmentFilmAsync(DepartmentFilmEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var departmentFilm_ = await GetDepartmentFilmByIdAsync(entity.Id, cancellationToken);

                departmentFilm_!.FilmId = entity.FilmId;
                departmentFilm_.DepartmentId = entity.DepartmentId;
                departmentFilm_.Status = entity.Status;

                _dbContext.DepartmentFilmEntities.Update(departmentFilm_);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return RequestResult<int>.Succeed(1);
            }
            catch (Exception e)
            {
                return RequestResult<int>.Fail(_localizationService["Unable to update department film"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToUpdate + "department film"
                    }
                });
            }
        }
        private async Task<DepartmentFilmEntity?> GetDepartmentFilmByIdAsync(Guid idDepartmentFilm_, CancellationToken cancellationToken)
        {
            var departmentFilm_ = await _dbContext.DepartmentFilmEntities.FirstOrDefaultAsync(c => c.Id == idDepartmentFilm_, cancellationToken);

            return departmentFilm_;
        }
    }
}
