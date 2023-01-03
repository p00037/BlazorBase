using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using ExtensionsLibrary;
using BlazorBase.Client.HttpClients;
using BlazorBase.Shared.ViewModels.UploadTest;

namespace BlazorBase.Client.Pages
{
    public partial class UploadTestPage : ComponentBase
    {
        [Inject]
        UploadTestClient UploadTestClient { get; set; }

        string uploadId = "";

        string resultText = "";

        RadzenUpload upload;

        void OnProgress(UploadProgressArgs args, string name)
        {
            Console.WriteLine($"{args.Progress}% '{name}' / {args.Loaded} of {args.Total} bytes.");

            if (args.Progress == 100)
            {
                foreach (Radzen.FileInfo? file in args.Files)
                {
                    Console.WriteLine($"Uploaded: {file.Name} / {file.Size} bytes");
                }
            }
        }

        async void Click()
        {
            if (!upload.HasValue)
            {
                resultText = "ファイルが選択されていません。";
                return;
            }

            this.uploadId = Guid.NewGuid().ToString();
            upload.Url = $"upload/multiple/{this.uploadId}";
            await upload.Upload();
        }

        async void ClickError()
        {
            this.uploadId = "";

            if (!upload.HasValue)
            {
                resultText = "ファイルが選択されていません。";
                return;
            }

            var uploadId = Guid.NewGuid().ToString();
            upload.Url = $"upload/multiple/{uploadId}";
            await upload.Upload();
        }

        async void OnComplete(UploadCompleteEventArgs args)
        {
            var uploadEntity = new UploadEntity() { id = uploadId, name = "test" };
            var checkfile = await UploadTestClient.CheckFile(uploadEntity);
            if (checkfile.IsSuccessful)
            {
                resultText = "アップロード成功";
            }
            else 
            {
                resultText = checkfile.ErrorMessage;
            }

            StateHasChanged();
        }
    }
}
