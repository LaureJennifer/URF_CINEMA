using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Account;
using URF_Cinema.Application.DataTransferObjects.Account.Request;
using URF_Cinema.Application.DataTransferObjects.User;
using URF_Cinema.Application.Interfaces.Login;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Response;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static URF_Cinema.Application.ValueObjects.Common.LocalizationString;
using URF_Cinema.Infrastructure.Database.AppDbContext;

namespace URF_Cinema.Infrastructure.Implements.Repositories.Login
{
    public class LoginService : ILoginService
    {
        private readonly AppReadOnlyDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        private readonly ICurrentUser _currentUser;

        public LoginService(AppReadOnlyDbContext dbContext, IMapper mapper, ILocalizationService localizationService, ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _localizationService = localizationService;
            _currentUser = currentUser;
        }

        public async Task<RequestResult<ViewLoginInput>> LoginCustomer(LoginInputRequest request)
        {
            try
            {
                var result = _dbContext.CustomerEntities.AsNoTracking().Where(x => x.Email == request.Email && x.PassWord == request.Password)
                 .ProjectTo<ViewLoginInput>(_mapper.ConfigurationProvider).FirstOrDefault();
                return RequestResult<ViewLoginInput>.Succeed(result);

            }
            catch (Exception e)
            {
                return RequestResult<ViewLoginInput>.Fail(_localizationService["Login fail"], new[]
               {
                    new ErrorItem
                    {
                        Error = e.Message,
                    }
});
            }
        }

        public async Task<UserDto> FindByEmailAsync(string email)
        {
            var result = (await GetListActiveAsync()).FirstOrDefault(c => c.Email == email);

            return result;
        }
        public async Task<IQueryable<UserDto>> GetListActiveAsync()
        {
            var result = (await GetListAsync()).Where(c => !c.Deleted).AsQueryable();
            return result;
        }

        private async Task<List<UserDto>> GetListAsync()
        {
            var result = await (from r in _dbContext.RoleEntities
                                join u in _dbContext.UserEntities on r.Id equals u.RoleId
                                select new UserDto
                                {
                                    RoleId = r.Id,
                                    Role = r.Code,
                                    Id = u.Id,
                                    Email = u.Email,
                                    PassWord = u.PassWord,
                                    Name = u.Name,
                                }).ToListAsync();
            return result;
        }

        public async Task<RequestResult<ViewLoginInput>> SignIn(LoginInputRequest request)
        {
            try
            {
                var user = await FindByEmailAsync(request.Email) ?? throw new Exception("Tài khoản không tồn tại!");

                var userName = await _dbContext.UserEntities.FirstOrDefaultAsync(x => x.Name.ToLower() == user.Name.ToLower());
                var Email = await _dbContext.UserEntities.FirstOrDefaultAsync(x => x.Email.ToLower() == user.Email.ToLower());
                var password = await _dbContext.UserEntities.FirstOrDefaultAsync(x => x.PassWord.ToLower() == user.PassWord.ToLower());
                var userId = await _dbContext.UserEntities.FirstOrDefaultAsync(x => x.Id == user.Id);
                var claims = new List<Claim>();
                if (userId != null)
                    claims.Add(new Claim(AppRole.Id, userId.ToString()));

                if (userName != null)
                    claims.Add(new Claim(ClaimTypes.Name, userName.ToString()));

                if (Email != null)
                    claims.Add(new Claim(ClaimTypes.Email, Email.ToString()));

                if (password != null)
                    claims.Add(new Claim("Password", password.ToString()));

                var roles = await _dbContext.RoleEntities.FirstOrDefaultAsync(x => x.Id == user.RoleId);
                if (roles != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.Code));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var token = TokenEncoding.GenerateToken(claimsIdentity);

                var loginResult = new ViewLoginInput
                {
                    Id = user.Id,
                    UserName = user.Email,
                    Password = user.PassWord,
                    Email = user.Email,
                    Name = user.Name,
                    RoleId = user.RoleId,
                    Code = user.Role
                };

                return RequestResult<ViewLoginInput>.Succeed(loginResult);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Có lỗi xảy ra vui lòng thử lại! {ex.Message}";
                var errorResult = RequestResult<ViewLoginInput>.Fail(errorMessage, new[]
                {
        new ErrorItem
        {
            Error = ex.Message
        }
    });
                return errorResult;
            }
        }

        public async Task<RequestResult<ViewLoginInput>> Login(LoginInputRequest request, CancellationToken cancellation)
        {
            try
            {
                var result = _dbContext.UserEntities.AsNoTracking().Where(x => x.Email.ToLower() == request.Email.ToLower() && x.PassWord == request.Password && !x.Deleted)
                 .ProjectTo<ViewLoginInput>(_mapper.ConfigurationProvider).FirstOrDefault();
                return RequestResult<ViewLoginInput>.Succeed(result);

            }
            catch (Exception e)
            {
                return RequestResult<ViewLoginInput>.Fail(_localizationService["Login fail"], new[]
               {
                    new ErrorItem
                    {
                        Error = e.Message,
                    }
});
            }
        }
    }
    
}
