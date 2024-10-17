using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URF_Cinema.Application.DataTransferObjects.Department.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Film
{
    public class FilmsWithDepartmentViewModel : ViewModelBase<ViewDepartmentWithPaginationRequest>
    {
        private readonly IFilmReadOnlyRepository _filmReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmsWithDepartmentViewModel(IFilmReadOnlyRepository filmReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmReadOnlyRepository = filmReadOnlyRepository;
            _localizationService = localizationService;
        }
        public async override Task HandleAsync(ViewDepartmentWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmReadOnlyRepository.GetFilmsWithDepartmentPaginationAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of film"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of film")
                    }
                };
            }
        }
    }
}
