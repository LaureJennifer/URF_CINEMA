using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.Interfaces.Login;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Services;
using Google.Apis.Util;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static BaseSolution.Application.ValueObjects.Common.LocalizationString;

namespace BaseSolution.Infrastructure.Implements.Repositories.Login
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
        public async Task<string> Login(string tokenLogin, CancellationToken cancellationToken)
        {
            try
            {
                var principal = TokenDecoding.DecodeToken(tokenLogin);

                var userName = principal.Claims.FirstOrDefault(c => c.Type == "username")?.Value ?? throw new Exception("UserName không được để trống!");

                var email = principal.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? throw new Exception("Email không được để trống!");
                var localhost = (principal.Claims.FirstOrDefault(c => c.Type == "localhost")?.Value) ?? throw new Exception("Địa chỉ Localhost không được để trống!");
                var role1 = principal.Claims.FirstOrDefault(c => c.Type == "roleNames")?.Value ?? throw new Exception("Quyền không được để trống!");

                var user = await FindByUserNameAsync(userName) ?? throw new Exception("Tài khoản không tồn tại!");

                //var role = await _dbContext.RoleEntities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Guid.Parse(role1));

                var roles = await _dbContext.RoleEntities.FirstOrDefaultAsync(x => x.Id == user.RoleId);
                //if (user.Password != loginVM.Password)
                //{
                //    throw new Exception("Mật khẩu không đúng!");
                //}
                var claims = new List<Claim>()
                            {
                                new(AppRole.Id, user.Id.ToString()),
                                new(ClaimTypes.Name, user.UserName),
                                new(ClaimTypes.Email, user.Email)
                            };
                if (roles != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.Code));
                }
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                return TokenEncoding.GenerateToken(claimsIdentity);
            }
            catch (Exception ex)
            {
                return new($"Có lỗi xảy ra vui lòng thử lại! {ex.Message}");

            }
        }

        public async Task<RequestResult<ViewLoginInput>> LoginCustomer(LoginInputRequest request)
        {
            try
            {
                var result = _dbContext.CustomerEntities.AsNoTracking().Where(x => x.UserName == request.UserName && x.PassWord == request.Password)
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

        public async Task<UserDto> FindByUserNameAsync(string username)
        {
            var result = (await GetListActiveAsync()).FirstOrDefault(c => c.UserName == username);

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
                                    UserName = u.UserName,
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
                var user = await FindByUserNameAsync(request.UserName) ?? throw new Exception("Tài khoản không tồn tại!");

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

                if (!string.IsNullOrEmpty(user.UserName))
                    claims.Add(new Claim("UserName", user.UserName));

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
                    UserName = user.UserName,
                    Password = user.PassWord,
                    Email = user.Email,
                    Name = user.UserName,
                    RoleId = user.RoleId,
                    Code = user.Role,
                    Token = token
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
    }
    
}
