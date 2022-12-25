using BlazorBase.Client.Service;
using BlazorBase.Shared.Entities;

namespace BlazorBase.Client.HttpClients
{
    public class AccountClient
    {
        private readonly IAPIService _apiService;

        public AccountClient(HttpClient httpClient)
        {
            HttpClient allowAnonymousHttpClient = new HttpClient() { BaseAddress = httpClient.BaseAddress };
            _apiService = new APIService(allowAnonymousHttpClient);
        }

        public async Task<RequestResult> Register()
        {
            return await _apiService.GetRequest<RequestResult>($"api/account/register");
        }

        public async Task<RequestResult> Delete()
        {
            return await _apiService.GetRequest<RequestResult>($"api/account/delete");
        }

        public async Task<RequestResult> UpdatePassword()
        {
            return await _apiService.GetRequest<RequestResult>($"api/account/updatepassword");
        }
    }
}
