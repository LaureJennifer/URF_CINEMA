using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public List<string> RoleCodes => GetRoleClaim(ClaimTypes.Role);
        string ICurrentUser.Name => GetClaimValue<string>(ClaimTypes.Name);
        string ICurrentUser.Email => GetClaimValue<string>(ClaimTypes.Email);
        string ICurrentUser.UserName => GetClaimValue<string>(AppRole.UserName);
        string ICurrentUser.Localhost => GetClaimValue<string>(AppRole.Localhost);

        List<string> ICurrentUser.RoleNames => GetRoleClaim(AppRole.RoleNames);
        public Guid? Id
        {
            get
            {
                string id = GetClaimValue<string>(AppRole.Id);
                if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _))
                {
                    return null;
                }
                return Guid.Parse(id);
            }
        }

        private List<string> GetRoleClaim(string claimType)
        {
            try
            {
                var claim = _httpContextAccessor.HttpContext?.User.FindAll(claimType);
                if (claim == null)
                {
                    return default;
                }
                var claims = new List<string>();
                foreach (var claimValue in claim)
                {
                    claims.Add(claimValue.Value);
                }
                return claims;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private T GetClaimValue<T>(string claimType)
        {
            try
            {
                var claim = _httpContextAccessor.HttpContext?.User.FindFirstValue(claimType);
                if (claim == null)
                {
                    return default;
                }

                return (T)Convert.ChangeType(claim, typeof(T));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
