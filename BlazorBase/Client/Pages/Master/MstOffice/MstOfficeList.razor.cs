using BlazorBase.Client.Enums;
using BlazorBase.Client.HttpClients;
using BlazorBase.Shared.ViewModels.MstOffice;
using Microsoft.AspNetCore.Components;

namespace BlazorBase.Client.Pages.Master.MstOffice
{
    public partial class MstOfficeList : ComponentBase
    {
        [Inject]
        NavigationManager NavManager { get; set; }

        [Inject]
        MstOfficeClient MstOfficeClient { get; set; }

        private IEnumerable<M_事業所ViewEntity> searchResultEntities;

        protected override async Task OnInitializedAsync()
        {
            searchResultEntities = await MstOfficeClient.GetList(new MstOfficeSearchViewEntity());
        }

        private void CreateNew()
        {
            NavManager.NavigateTo($"MstOfficePage/{(int)EditMode.新規}");
        }
    }
}
