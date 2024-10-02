using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.User.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.User
{
    public class UserUpdateViewModel: ViewModelBase<UserUpdateRequest>
    {
        private readonly IUserReadWriteRepository _userReadWriteRespository;       
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;
        public UserUpdateViewModel(IUserReadWriteRepository userReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _userReadWriteRespository = userReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;

        }
        public async override Task HandleAsync(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userReadWriteRespository.UpdateUserAsync(_mapper.Map<UserEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the user"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "user")
                    }
                };
            }
        }
    }
}
