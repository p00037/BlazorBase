using BlazorBase.Domain.Models;
using BlazorBase.Shared.ViewModels.MstLoginUser;

namespace BlazorBase.Server.Convertor
{
    public class M_ログインユーザーConvertor
    {
        public static M_ログインユーザーViewEntity ConvertView(M_ログインユーザーEntity domainEntity)
        {
            return new M_ログインユーザーViewEntity()
            {
                UserName = domainEntity.UserName,
                DisplayName = domainEntity.DisplayName,
            };
        }

        public static List<M_ログインユーザーViewEntity> ConvertView(IEnumerable<M_ログインユーザーEntity> domainEntities)
        {
            return domainEntities.Select(m => ConvertView(m)).ToList();
        }

        public static M_ログインユーザーEntity ConvertDomain(M_ログインユーザーViewEntity viewEntity)
        {
            return new M_ログインユーザーEntity()
            {
                UserName = viewEntity.UserName,
                DisplayName = viewEntity.DisplayName,
            };
        }

        public static List<M_ログインユーザーEntity> ConvertDomain(IEnumerable<M_ログインユーザーViewEntity> viewEntities)
        {
            return viewEntities.Select(m => ConvertDomain(m)).ToList();
        }
    }
}
