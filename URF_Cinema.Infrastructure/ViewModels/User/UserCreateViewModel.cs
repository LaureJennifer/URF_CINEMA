using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.User.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.User
{
    public class UserCreateViewModel : ViewModelBase<UserCreateRequest>
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserReadWriteRepository _userReadWriteRespository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        
        public UserCreateViewModel(IUserReadOnlyRepository userReadOnlyRepository, IUserReadWriteRepository userReadWriteRepository,
             ILocalizationService localizationService, IMapper mapper)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userReadWriteRespository = userReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
            
        }
        public async override Task HandleAsync(UserCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createResult = await _userReadWriteRespository.AddUserAsync(_mapper.Map<UserEntity>(request), cancellationToken);
                if (createResult.Success)
                {
                    var result = await _userReadOnlyRepository.GetUserByIdAsync(createResult.Data, cancellationToken);

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
