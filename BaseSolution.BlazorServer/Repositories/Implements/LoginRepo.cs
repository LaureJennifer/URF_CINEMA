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
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(request.UserName);
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
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(request.UserName);
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

        public async Task<ViewLoginInput> SignIn(LoginInputRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            var result = await client.PostAsJsonAsync("api/Logins/SignInPassword", request);
            var token = await result.Content.ReadAsStringAsync();
            Console.WriteLine(token);
            await _localStorage.SetItemAsync("Token", token);
            await _authenticationStateProvider.GetAuthenticationStateAsync();
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(request.UserName);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var loginResult = new ViewLoginInput
            {
                Token = token
            };
            return loginResult;
        }
    }
}
