using BlazorBase.Client.Service;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.UploadTest;

namespace BlazorBase.Client.HttpClients
{
    public class UploadTestClient
    {
        private readonly IAPIService apiService;

        public UploadTestClient(HttpClient httpClient)
        {
            HttpClient allowAnonymousHttpClient = new HttpClient() { BaseAddress = httpClient.BaseAddress };
            this.apiService = new APIService(allowAnonymousHttpClient);
        }

        public async Task<RequestResult> CheckFile(UploadEntity entity)
        {
            return await this.apiService.PostRequest<RequestResult>($"api/upload/filecheck", entity);
        }
    }
}
