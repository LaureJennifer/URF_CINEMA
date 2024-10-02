using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Role.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.Role
{
    public class RoleDeleteViewModel : ViewModelBase<RoleDeleteRequest>
    {
        public readonly IRoleReadWriteRepository _roleReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public RoleDeleteViewModel(IRoleReadWriteRepository roleReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _roleReadWriteRepository = roleReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public async override Task HandleAsync(RoleDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleReadWriteRepository.DeleteRoleAsync(request, cancellationToken);

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
                        Error = _localizationService["Error occurred while updating the role"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToDelete, "role")
                    }
                };
            }
        }
    }
}
