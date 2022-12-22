using BlazorBase.Client.Service;
using BlazorBase.Shared.Entities;

namespace BlazorBase.Client.HttpClients
{
    public class PdfShowClient
    {
        private readonly IAPIService _apiService;

        public PdfShowClient(HttpClient httpClient)
        {
            HttpClient allowAnonymousHttpClient = new HttpClient() { BaseAddress = httpClient.BaseAddress};
            _apiService = new APIService(allowAnonymousHttpClient);
        }

        public async Task<PrintResult> Get()
        {
            return await _apiService.GetRequest<PrintResult>($"api/pdfshow");
        }
    }
}
