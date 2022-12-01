using BlazorBase.Client.Service;

namespace BlazorBase.Client.HttpClients
{
    public class DownloadTestClient
    {
        private readonly IAPIService apiService;

        public DownloadTestClient(IAPIService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<Stream> Download()
        {
            return await this.apiService.DownloadFile($"download/test");
        }
    }
}
