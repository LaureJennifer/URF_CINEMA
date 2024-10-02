using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Role.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.ViewModels.Role
{
    public class RoleUpdateViewModel : ViewModelBase<RoleUpdateRequest>
    {
        private readonly IRoleReadWriteRepository _roleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoleUpdateViewModel(IRoleReadWriteRepository roleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roleReadWriteRepository = roleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        public async override Task HandleAsync(RoleUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleReadWriteRepository.UpdateRoleAsync(_mapper.Map<RoleEntity>(request), cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the role"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToUpdate, "role")
                    }
                };
            }
        }
    }
}
