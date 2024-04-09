using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.Seat
{
    public class SeatCreateRangeViewModel : ViewModelBase<List<SeatCreateRangeRequest>>
    {
        private readonly ISeatReadWriteRepository _seatReadWriteRepository;
        private readonly ISeatReadOnlyRepository _seatReadOnlyRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public SeatCreateRangeViewModel(ISeatReadWriteRepository seatReadWriteRepository, ISeatReadOnlyRepository seatReadOnlyRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _seatReadWriteRepository = seatReadWriteRepository;
            _seatReadOnlyRepository = seatReadOnlyRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public override async Task HandleAsync(List<SeatCreateRangeRequest> data, CancellationToken cancellationToken)
        {
            try
            {
                var resultCreate = await _seatReadWriteRepository.CreateRangeSeatAsync(_mapper.Map<List<SeatEntity>>(data), cancellationToken);
                if (resultCreate.Success)
                {
                    var result = await _seatReadOnlyRepository.GetListSeatByIdAsync(resultCreate.Data, cancellationToken);
                    Data = result.Data!;
                    Success = result.Success;
                    ErrorItems = result.Errors;
                    Message = result.Message;
                    return;
                }
                Success = resultCreate.Success;
                ErrorItems = resultCreate.Errors;
                Message = resultCreate.Message;
            }
            catch (Exception)
            {
                Success = false;
                ErrorItems = new[]
                    {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the seat"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "seat")
                    }
                };
            }
        }
    }
}
