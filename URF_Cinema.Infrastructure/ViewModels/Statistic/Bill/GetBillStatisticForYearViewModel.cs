﻿using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Statistic.Bill
{
    public class GetBillStatisticForYearViewModel : ViewModelBase<BillStatisticRequest>
    {
        private readonly IBillStatisticReadOnlyRespository _billStatisticReadOnly;
        private readonly ILocalizationService _localizationService;

        public GetBillStatisticForYearViewModel(IBillStatisticReadOnlyRespository billStatisticReadOnly, ILocalizationService localizationService)
        {
            _billStatisticReadOnly = billStatisticReadOnly;
            _localizationService = localizationService;
        }
        public async override Task HandleAsync(BillStatisticRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _billStatisticReadOnly.GetBillStasticForYearAsync(request, cancellationToken);

                Data = result.Data!;
                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch
            {
                Success = false;
                ErrorItems = new[]
                {
                new ErrorItem
                {
                    Error = _localizationService["Error occurred while getting the list of bill statistic for year"],
                    FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of bill statistic for year")
                }
            };
            }
        }
    }
}
