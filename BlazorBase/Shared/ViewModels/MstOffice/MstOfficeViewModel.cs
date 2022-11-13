using BlazorBase.Shared.Entities;

namespace BlazorBase.Shared.ViewModels.MstOffice
{
    public class MstOfficeViewModel
    {
        public M_事業所ViewEntity Data { get; init; }

        public List<ComboEntity> Combo多機能要件 { get; init; } = new List<ComboEntity>();
    }
}
