using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.User;
using URF_Cinema.Application.DataTransferObjects.User.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class UserReadOnlyRepository : IUserReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public UserReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<UserDto?>> GetUserByIdAsync(Guid idUser, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _appReadOnlyDbContext.UserEntities.AsNoTracking().Where(x => x.Id == idUser).ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<UserDto?>.Succeed(user);

            }
            catch (Exception e)
            {

                return RequestResult<UserDto?>.Fail(_localizationService["User is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "user"
                    }
                });
            }
        }

        public async Task<RequestResult<UserDto>> GetUserByUserNameAsync(string email, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _appReadOnlyDbContext.UserEntities.AsNoTracking().Where(x => x.Email == email).ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
                return RequestResult<UserDto>.Succeed(user);

            }
            catch (Exception e)
            {

                return RequestResult<UserDto>.Fail(_localizationService["User is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "user"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<UserDto>>> GetUserWithPaginationByAdminAsync(ViewUserWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var users = _appReadOnlyDbContext.UserEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<UserDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    users = users.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
                }
                if (request.RoleId != null)
                {
                    users = users.Where(x => x.RoleId == request.RoleId);
                }
                var result = await users.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<UserDto>>.Succeed(new PaginationResponse<UserDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<UserDto>>.Fail(_localizationService["List of user are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of user"
                    }
                });
            }
        }
    }
}
