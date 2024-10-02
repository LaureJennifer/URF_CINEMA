using URF_Cinema.Application.DataTransferObjects.User.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.User
{
    public class UserListWithPaginationViewModel: ViewModelBase<ViewUserWithPaginationRequest>
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public UserListWithPaginationViewModel(IUserReadOnlyRepository userReadOnlyRepository, ILocalizationService localizationService)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _localizationService = localizationService;
        }
        public async override Task HandleAsync(ViewUserWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userReadOnlyRepository.GetUserWithPaginationByAdminAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while getting the list of user"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of user")
                    }
                };
            }
        }
    }
}
