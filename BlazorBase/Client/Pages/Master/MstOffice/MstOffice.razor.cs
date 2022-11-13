using System;
using System.Linq.Expressions;
using BlazorBase.Client.Enums;
using BlazorBase.Client.HttpClients;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.MstOffice;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace BlazorBase.Client.Pages.Master.MstOffice
{
    public partial class MstOffice : ComponentBase
    {
        [Parameter]
        public EditMode EditMode { get; set; }

        [Parameter]
        public string OfficeNo { get; set; } = "";

        [Inject]
        NavigationManager NavManager { get; set; }

        [Inject]
        NotificationService NotificationService { get; set; }

        [Inject]
        MstOfficeClient MstOfficeClient { get; set; }

        private List<ComboEntity> combo多機能要件;
        private M_事業所ViewEntity editData = new M_事業所ViewEntity();
        private string message;
        private RadzenDataGrid<M_事業所明細ViewEntity> grid;

        protected override async Task OnInitializedAsync()
        {
            var viewModel = await MstOfficeClient.GetViewModel(OfficeNo);
            editData = viewModel.Data;
            combo多機能要件 = viewModel.Combo多機能要件;
        }

        private void AddRow()
        {
            this.editData.M_事業所明細Entities.Add(new M_事業所明細ViewEntity());
            grid.Reset(true); 
        }

        private void DeleteRow(M_事業所明細ViewEntity entity)
        {
            this.editData.M_事業所明細Entities.Remove(entity);
            grid.Reset(true);
        }

        private async Task Save()
        {
            RequestResult requestResult = await SaveResult();
            if (!requestResult.IsSuccessful)
            {
                this.message = requestResult.ErrorMessage;
                return;
            }

            var notificationMessage = new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "登録しました。", Detail = "", Duration = 4000 };
            NotificationService.Notify(notificationMessage);
        }

        private async Task Delete()
        {
            RequestResult requestResult = await MstOfficeClient.Delete(this.editData);
            if (!requestResult.IsSuccessful)
            {
                this.message = requestResult.ErrorMessage;
                return;
            }

            Cancel();
        }

        private async Task<RequestResult> SaveResult()
        {
            return EditMode switch
            {
                EditMode.新規 => await MstOfficeClient.Register(this.editData),
                EditMode.修正 => await MstOfficeClient.Update(this.editData),
                EditMode.削除 => await MstOfficeClient.Delete(this.editData),
                _ => throw new NotImplementedException(),
            };
        }

        private void Cancel()
        {
            NavManager.NavigateTo("MstOfficeListPage");
        }
    }
}
