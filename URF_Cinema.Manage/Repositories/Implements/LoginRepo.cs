using URF_Cinema.Manage.Repositories.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using URF_Cinema.Application.DataTransferObjects.Account.Request;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Manage.Repositories.Implements
{
    public class LoginRepo : ILoginRepo
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public LoginRepo(ILocalStorageService localStorage,AuthenticationStateProvider authenticationStateProvider)
        {
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<string> Login(LoginInputRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.PostAsJsonAsync("api/Logins", request);
            var token = await result.Content.ReadAsStringAsync();
            //var loginResponse = JsonSerializer.Deserialize<LoginResponse>(token,
            //    new JsonSerializerOptions()
            //    {
            //        PropertyNameCaseInsensitive = true
            //    });
            //if (!result.IsSuccessStatusCode)
            //{
            //    return loginResponse;
            //}
            await _localStorage.SetItemAsync("token", token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(request.Email);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return token;
            //return loginResponse;
            //await _localStorage.SetItemAsync("token", token);
            //await _authenticationStateProvider.GetAuthenticationStateAsync();
            ////((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(request.UserName);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<string> LoginCustomer(LoginInputRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.PostAsJsonAsync("api/Logins/Customer", request);
            var token = await result.Content.ReadAsStringAsync();
            //var loginResponse = JsonSerializer.Deserialize<LoginResponse>(token,
            //    new JsonSerializerOptions()
            //    {
            //        PropertyNameCaseInsensitive = true
            //    });
            //if (!result.IsSuccessStatusCode)
            //{
            //    return loginResponse;
            //}
            await _localStorage.SetItemAsync("token", token);
            await _authenticationStateProvider.GetAuthenticationStateAsync();
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(request.Email);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return token;
            //return loginResponse;
            //await _localStorage.SetItemAsync("token", token);
            //await _authenticationStateProvider.GetAuthenticationStateAsync();
            ////((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(request.UserName);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task Logout()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            await _localStorage.RemoveItemAsync("token");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RefreshToken> SignIn(LoginInputRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var response = await client.PostAsJsonAsync("api/Logins/Login", request);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response content: {token}");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Bỏ qua phân biệt chữ hoa chữ thường
                };

                var apiResponse = JsonSerializer.Deserialize<APIResponse>(token, options);

                if (apiResponse != null && apiResponse.Token != null)
                {
                    var refreshToken = apiResponse.Token;

                    if (!string.IsNullOrEmpty(refreshToken.Token))
                    {
                        // Giải mã token để kiểm tra vai trò
                        var handler = new JwtSecurityTokenHandler();
                        var jwtToken = handler.ReadJwtToken(refreshToken.Token);

                        foreach (var claim in jwtToken.Claims)
                        {
                            Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
                        }

                        var roles = jwtToken.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();

                        Console.WriteLine("Roles in token: " + string.Join(", ", roles));

                        await _localStorage.SetItemAsync("token", refreshToken.Token);
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", refreshToken.Token);
                        return refreshToken;
                    }
                    else
                    {
                        Console.WriteLine("Token is null or empty");
                    }
                }
                else
                {
                    Console.WriteLine("API response is null or invalid");
                }
            }
            return null!;
        }
    }
}
