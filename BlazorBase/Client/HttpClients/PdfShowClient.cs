using BlazorBase.Client.Service;
using BlazorBase.Shared.Entities;

namespace BlazorBase.Client.HttpClients
{
    public class PdfShowClient
    {
        private readonly IAPIService _apiService;

        public PdfShowClient(IAPIService apiService)
        {
            _apiService = apiService;
        }

        public async Task<PrintResult> Get()
        {
            return await _apiService.GetRequest<PrintResult>($"api/pdfshow");
        }
    }
}
