using AutoMapper;
using Azure.Core;
using BaseSolution.Application.DataTransferObjects.Example.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Seat
{
    public class SeatCreateViewModel : ViewModelBase<SeatCreateRequest>
    {
        private readonly ISeatReadOnlyRepository _seatReadOnlyRepository;
        private readonly ISeatReadWriteRepository _seatReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public SeatCreateViewModel(ISeatReadOnlyRepository SeatReadOnlyRepository, ISeatReadWriteRepository SeatReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _seatReadOnlyRepository = SeatReadOnlyRepository;
            _seatReadWriteRepository = SeatReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(SeatCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _seatReadWriteRepository.AddSeatAsync(_mapper.Map<SeatEntity>(request), cancellationToken);

                if (createResult.Success)
                {
                    var result = await _seatReadOnlyRepository.GetSeatByIdAsync(createResult.Data, cancellationToken);

                    Data = result.Data!;
                    Success = result.Success;
                    ErrorItems = result.Errors;
                    Message = result.Message;
                    return;
                }

                Success = createResult.Success;
                ErrorItems = createResult.Errors;
                Message = createResult.Message;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the Seat"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "Seat")
                    }
                };
            }
        }
    }
}
