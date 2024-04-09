using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using BaseSolution.Application.ValueObjects.Response;

namespace BaseSolution.BlazorServer.Repositories.Implements
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
        public async Task<ViewLoginInput> Login(LoginInputRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.PostAsJsonAsync("/api/Logins", request);
            var content = await result.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<ViewLoginInput>(content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            if (result == null)
            {
                return loginResponse;
            }
            await _localStorage.SetItemAsync("authToken", loginResponse.Token);
            await _authenticationStateProvider.GetAuthenticationStateAsync();
            //((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            return loginResponse;
        }

        public async Task Logout()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
