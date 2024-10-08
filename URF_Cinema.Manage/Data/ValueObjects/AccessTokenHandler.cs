﻿using URF_Cinema.Application.ValueObjects.Common;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace URF_Cinema.Manage.Data.ValueObjects
{
    public class AccessTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccessTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpContext context = _httpContextAccessor.HttpContext;
            // Xác thực và lấy thông tin người dùng
            ClaimsIdentity claimsIdentity = context.User.Identities.First();

            string accessToken = TokenEncoding.GenerateToken(claimsIdentity);
            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
