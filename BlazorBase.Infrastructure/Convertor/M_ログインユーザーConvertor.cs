using BlazorBase.Domain.Models;
using BlazorBase.Infrastructure.Entities;

namespace BlazorBase.Infrastructure.Convertor
{
    internal class M_ログインユーザーConvertor
    {
        public static M_ログインユーザーEntity ConvertDomain(M_ログインユーザーDbEntity dbEntity)
        {
            return dbEntity == null
                ? null
                : new M_ログインユーザーEntity()
                {
                    UserName = dbEntity.UserName,
                    DisplayName = dbEntity.DisplayName,
                };
        }

        public static M_ログインユーザーDbEntity ConvertDb(M_ログインユーザーEntity entity)
        {
            return new M_ログインユーザーDbEntity()
            {
                UserName = entity.UserName,
                DisplayName = entity.DisplayName,
            };
        }
    }
}