using BlazorBase.Domain.Models;
using BlazorBase.Shared.ViewModels.MstLoginUser;

namespace BlazorBase.Server.Convertor
{
    public class MstLoginUserSearchConvertor
    {
        public static MstLoginUserSearchEntity ConvertDomain(MstLoginUserSearchViewEntity viewEntity)
        {
            return new MstLoginUserSearchEntity()
            {
                UserName = viewEntity.UserName,
                DisplayName = viewEntity.DisplayName,
            };
        }
    }
}
