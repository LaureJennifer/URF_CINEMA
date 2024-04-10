using BaseSolution.Application.DataTransferObjects;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.Interfaces.Login;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace BaseSolution.Infrastructure.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase<LoginInputRequest>
    {
        private readonly ILoginService _loginService;
        private readonly ILocalizationService _localizationService;
        private readonly Appsetting _appSetting;
        public LoginViewModel(ILoginService loginService, ILocalizationService localizationService,IOptionsMonitor<Appsetting> monitor)
        {
            _loginService = loginService;
            _localizationService = localizationService;
            _appSetting = monitor.CurrentValue;
        }
        public async override Task HandleAsync(LoginInputRequest data, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _loginService.Login(data);
                Data = GenerateToken(result.Data);
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
                        Error = _localizationService["Login Fail"],
                    }
                };
            }
        }
        private TokenModel GenerateToken(ViewLoginInput userEntity)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);

            var roles = GetRoleById(userEntity.RoleId);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userEntity.Name),
                    new Claim(ClaimTypes.Email,userEntity.Email),
                    new Claim("UserName",userEntity.UserName),
                    new Claim("Id",userEntity.Id.ToString()),

                    new Claim(ClaimTypes.Role,roles),
                }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = jwtTokenHandler.CreateToken(tokenDescription);

            var accessToken = jwtTokenHandler.WriteToken(token);

            return new TokenModel
            {
                AccessToken = accessToken
            };
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using ( var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }

        public string GetRoleById(Guid roleId)
        {
            using (var _dbcontext = new AppReadOnlyDbContext())
            {
                var role = _dbcontext.RoleEntities.FirstOrDefault(x => x.Id == roleId);
                if (role != null)
                {
                    return role.Code;
                }
                throw new Exception("Quyền không tồn tại!");
            }
        }
    }
}
