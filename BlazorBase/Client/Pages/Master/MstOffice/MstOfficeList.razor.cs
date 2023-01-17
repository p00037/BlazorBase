using BlazorBase.Client.Enums;
using BlazorBase.Client.HttpClients;
using BlazorBase.Shared.ViewModels.MstOffice;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace BlazorBase.Client.Pages.Master.MstOffice
{
    public partial class MstOfficeList : ComponentBase
    {
        [Inject]
        NavigationManager NavManager { get; set; }

        [Inject]
        MstOfficeClient MstOfficeClient { get; set; }

        private MstOfficeSearchViewEntity searchEntity = new MstOfficeSearchViewEntity();
        private IEnumerable<M_事業所ViewEntity> searchResultEntities = new List<M_事業所ViewEntity>();
        private RadzenDataGrid<M_事業所ViewEntity> grid;

        protected override async Task OnInitializedAsync()
        {
            searchResultEntities = await MstOfficeClient.GetList(searchEntity);
        }

        private async Task Search()
        {
            searchResultEntities = await MstOfficeClient.GetList(searchEntity);
            grid.Reset(true);
        }

        private void CreateNew()
        {
            NavManager.NavigateTo($"MstOffice");
        }

        private string GetUpdateURL(string officeNo)
        {
            return $"MstOffice/{officeNo}";
        }
    }
}
