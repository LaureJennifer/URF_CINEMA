using AutoMapper;
using BaseSolution.Application.DataTransferObjects.PaymentMethod;
using BaseSolution.Application.DataTransferObjects.PaymentMethod.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class PaymentMethodReadOnlyRepository : IPaymentMethodReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public PaymentMethodReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public Task<RequestResult<PaymentMethodDto?>> GetPaymentMethodByIdAsync(Guid idPaymentMethod, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PaginationResponse<PaymentMethodDto>>> GetPaymentMethodWithPaginationByAdminAsync(ViewPaymentMethodWithPaginationRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
