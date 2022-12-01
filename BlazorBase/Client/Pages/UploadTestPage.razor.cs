using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace BlazorBase.Client.Pages
{
    public partial class UploadTestPage : ComponentBase
    {
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
    }
}
