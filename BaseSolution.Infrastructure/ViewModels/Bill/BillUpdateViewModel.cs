using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Room.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Bill
{
    public class BillUpdateViewModel:ViewModelBase<BillUpdateRequest>
    {
        private readonly IBillReadWriteRepository _billReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        public BillUpdateViewModel(IBillReadWriteRepository billReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _billReadWriteRepository = billReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(BillUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _billReadWriteRepository.UpdateBillAsync(_mapper.Map<BillEntity>(request), cancellationToken);

                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while updating the bill"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "bill")
                    }
                };
            }
        }
    }
}
