using BlazorBase.Client.Enums;
using BlazorBase.Client.HttpClients;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.MstLoginUser;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BlazorBase.Client.Pages.Master.MstLoginUser
{
    public partial class MstLoginUser : ComponentBase
    {
        [Parameter]
        public string UserName { get; set; } = "";

        [Inject]
        NavigationManager NavManager { get; set; }

        [Inject]
        NotificationService NotificationService { get; set; }

        [Inject]
        DialogService DialogService { get; set; }

        [Inject]
        MstLoginUserClient MstLoginUserClient { get; set; }

        private EditMode editMode;
        private MstLoginUserDisabled disabled = new MstLoginUserDisabled(EditMode.新規);
        private M_ログインユーザーViewEntity editData = new M_ログインユーザーViewEntity();
        private ErrorMessage errorMessage = ErrorMessage.CreateNoError();

        protected override async Task OnInitializedAsync()
        {
            var viewModel = await MstLoginUserClient.GetViewModel(UserName);
            var editMode = string.IsNullOrEmpty(UserName) ? EditMode.新規 : EditMode.修正;
            this.editMode = editMode;
            editData = viewModel.Data;
            disabled = new MstLoginUserDisabled(editMode);
        }

        private async Task Save()
        {
            RequestResult requestResult = await SaveResult();
            if (!requestResult.IsSuccessful)
            {
                List<string> messages = requestResult.ErrorMessage.Split(Environment.NewLine).ToList();
                this.errorMessage = ErrorMessage.Create(messages);
                return;
            }

            this.errorMessage = ErrorMessage.CreateNoError();

            var notificationMessage = new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "登録しました。", Detail = "", Duration = 4000 };
            NotificationService.Notify(notificationMessage);

            this.editMode = EditMode.修正;
            this.disabled = new MstLoginUserDisabled(this.editMode);
        }

        private async Task Delete()
        {
            var result = await DialogService.Confirm("削除してよろしいですか？", "確認メッセージ", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });
            if (!result.HasValue || !result.Value)
            {
                return;
            }

            RequestResult requestResult = await MstLoginUserClient.Delete(this.editData);
            if (!requestResult.IsSuccessful)
            {
                List<string> messages = requestResult.ErrorMessage.Split(Environment.NewLine).ToList();
                this.errorMessage = ErrorMessage.Create(messages);
                return;
            }

            Cancel();
        }

        private async Task<RequestResult> SaveResult()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return await MstLoginUserClient.Register(this.editData);
            }

            return await MstLoginUserClient.Update(this.editData);
        }

        private void Cancel()
        {
            NavManager.NavigateTo("MstLoginUserList");
        }
    }
}
