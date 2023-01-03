using BlazorBase.Client;
using BlazorBase.Client.HttpClients;
using BlazorBase.Client.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorBase.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorBase.ServerAPI"));

builder.Services.AddApiAuthorization();

builder.Services.AddScoped<IAPIService, APIService>();
builder.Services.AddScoped<MstOfficeClient>();
builder.Services.AddScoped<DownloadTestClient>();
builder.Services.AddScoped<PdfShowClient>();
builder.Services.AddScoped<MstLoginUserClient>();
builder.Services.AddScoped<UploadTestClient>();

builder.Services.AddScoped<NotificationService>();
builder.Services.AddSingleton<DialogService>();

await builder.Build().RunAsync();
