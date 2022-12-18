using BlazorBase.Client.HttpClients;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorBase.Client.Pages
{
    public partial class PdfTestPage : ComponentBase
    {
        [Inject]
        IJSRuntime? JS { get; set; }

        [Inject]
        PdfShowClient PdfShowClient { get; set; }

        private async Task ShowPdf()
        {
            var printResult = await PdfShowClient.Get();
            await JS.InvokeVoidAsync("pdfShow", printResult.Filename);
        }
    }
}
