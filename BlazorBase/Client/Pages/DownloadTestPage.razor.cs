using BlazorBase.Client.HttpClients;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorBase.Client.Pages
{
    public partial class DownloadTestPage : ComponentBase
    {
        [Inject]
        IJSRuntime? JS { get; set; }

        [Inject]
        DownloadTestClient DownloadTestClient { get; set; }

        private async Task DownloadFileFromStream()
        {
            var fileStream = await DownloadTestClient.Download();
            var fileName = "text1.txt";

            using var streamRef = new DotNetStreamReference(stream: fileStream);

            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }
    }
}
