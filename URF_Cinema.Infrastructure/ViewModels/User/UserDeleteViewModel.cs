using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.User.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.User
{
    public class UserDeleteViewModel: ViewModelBase<UserDeleteRequest>
    {
        public readonly IUserReadWriteRepository _userReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        public UserDeleteViewModel(IUserReadWriteRepository userReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _userReadWriteRepository = userReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public async override Task HandleAsync(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userReadWriteRepository.DeleteUserAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the user"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "user")
                    }
                };
            }
        }
    }
}
