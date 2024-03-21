using AutoMapper;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.User
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
