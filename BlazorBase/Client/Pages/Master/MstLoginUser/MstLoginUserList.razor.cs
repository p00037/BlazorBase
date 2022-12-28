using BlazorBase.Client.Enums;
using BlazorBase.Client.HttpClients;
using BlazorBase.Shared.ViewModels.MstLoginUser;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace BlazorBase.Client.Pages.Master.MstLoginUser
{
    public partial class MstLoginUserList : ComponentBase
    {
        [Inject]
        NavigationManager NavManager { get; set; }

        [Inject]
        MstLoginUserClient MstLoginUserClient { get; set; }

        private MstLoginUserSearchViewEntity searchEntity = new MstLoginUserSearchViewEntity();
        private IEnumerable<M_ログインユーザーViewEntity>? searchResultEntities = new List<M_ログインユーザーViewEntity>();
        private RadzenDataGrid<M_ログインユーザーViewEntity> grid;

        protected override async Task OnInitializedAsync()
        {
            searchResultEntities = await MstLoginUserClient.GetList(searchEntity);
        }

        private async Task SearchAsync()
        {
            searchResultEntities = await MstLoginUserClient.GetList(searchEntity);
            grid.Reset(true);
        }

        private void CreateNew()
        {
            NavManager.NavigateTo($"MstLoginUser");
        }

        private string GetUpdateURL(string? userName)
        {
            return $"MstLoginUser/{userName}";
        }
    }
}
