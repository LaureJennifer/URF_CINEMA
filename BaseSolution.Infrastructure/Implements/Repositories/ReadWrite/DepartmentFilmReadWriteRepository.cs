using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;
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
    public class DepartmentFilmReadWriteRepository : IDepartmentFilmReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public DepartmentFilmReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }

        public Task<RequestResult<Guid>> AddDepartmentFilmAsync(DepartmentFilmEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> DeleteDepartmentFilmAsync(DepartmentFilmDeleteRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> UpdateDepartmentFilmAsync(DepartmentFilmEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
