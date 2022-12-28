using BlazorBase.Client.Enums;

namespace BlazorBase.Client.Pages.Master.MstLoginUser
{
    public class MstLoginUserDisabled
    {
        public MstLoginUserDisabled(EditMode editMode)
        {
            if (editMode == EditMode.新規)
            {
                this.PrimaryKey = false;
                this.BtnDelete = true;
                return;
            }

            this.PrimaryKey = true;
            this.BtnDelete = false;
        }

        public bool PrimaryKey { get; set; }

        public bool BtnDelete { get; set; }
    }
}
