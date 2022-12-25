using BlazorBase.Client.HttpClients;
using BlazorBase.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorBase.Client.Pages.Master.MstLoginUser
{
    public partial class MstLoginUser
    {
        [Inject]
        AccountClient AccountRegisterClient { get; set; }

        private async Task Register()
        {
            RequestResult? requestResult = await AccountRegisterClient.Register();
        }

        private async Task Delete()
        {
            RequestResult? requestResult = await AccountRegisterClient.Delete();
        }

        private async Task UpdatePassword()
        {
            RequestResult? requestResult = await AccountRegisterClient.UpdatePassword();
        }
    }
}
