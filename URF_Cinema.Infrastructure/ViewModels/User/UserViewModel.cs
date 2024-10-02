using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.User
{
    public class UserViewModel : ViewModelBase<Guid>
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRespository;
        private readonly ILocalizationService _localizationService;
        public UserViewModel(IUserReadOnlyRepository userReadOnlyRepository, ILocalizationService localizationService)
        {
            _userReadOnlyRespository = userReadOnlyRepository;
            _localizationService = localizationService;
        }
        public async override Task HandleAsync(Guid idUser, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userReadOnlyRespository.GetUserByIdAsync(idUser, cancellationToken);
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
                        Error = _localizationService["Error occurred while getting the user"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "user")
                    }
                };
            }
        }
    }
}
