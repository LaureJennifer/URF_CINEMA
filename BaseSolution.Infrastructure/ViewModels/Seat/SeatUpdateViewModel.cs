using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Example.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Seat
{
    public class SeatUpdateViewModel : ViewModelBase<SeatUpdateRequest>
    {
        private readonly ISeatReadWriteRepository _seatReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public SeatUpdateViewModel(ISeatReadWriteRepository SeatReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _seatReadWriteRepository = SeatReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public override async Task HandleAsync(SeatUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _seatReadWriteRepository.UpdateSeatAsync(_mapper.Map<SeatEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the Seat"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "Seat")
                    }
                };
            }
        }
    }
}
