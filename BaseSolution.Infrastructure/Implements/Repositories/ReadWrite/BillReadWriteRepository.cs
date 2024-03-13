using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadWrite
{
    public class BillReadWriteRepository : IBillReadWriteRepository
    {
        private readonly ILocalizationService _localizationService;
        private readonly AppReadWriteDbContext _dbContext;

        public BillReadWriteRepository(ILocalizationService localizationService, AppReadWriteDbContext dbContext)
        {
            _localizationService = localizationService;
            _dbContext = dbContext;
        }
        public Task<RequestResult<Guid>> AddBillAsync(BillEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<bool>> DeleteBillAsync(BillDeleteRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<bool>> UpdateBillAsync(BillEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        private async Task<BillEntity?> GetBillByIdAsync(Guid idBill, CancellationToken cancellationToken)
        {
            var example = await _dbContext.BillEntities.FirstOrDefaultAsync(c => c.Id == idBill && !c.Deleted, cancellationToken);

            return example;
        }
    }
}
