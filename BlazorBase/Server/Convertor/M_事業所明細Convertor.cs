using BlazorBase.Domain.Models;
using BlazorBase.Shared.ViewModels.MstOffice;

namespace BlazorBase.Server.Converter
{
    public class M_事業所明細Convertor
    {
        public static M_事業所明細ViewEntity ConvertView(M_事業所明細Entity domainEntity)
        {
            return new M_事業所明細ViewEntity()
            {
                事業所番号 = domainEntity.事業所番号,
                連番 = domainEntity.連番,
                施設名 = domainEntity.施設名,
                種類コード = domainEntity.種類コード,
                サービス提供単位番号 = domainEntity.サービス提供単位番号,
                定員 = domainEntity.定員,
                多機能型用件 = domainEntity.多機能型用件,
                単位数単価 = domainEntity.単位数単価,
                種類区分 = domainEntity.種類区分,
            };
        }

        public static List<M_事業所明細ViewEntity> ConvertView(IEnumerable<M_事業所明細Entity> domainEntities)
        {
            return domainEntities.Select(m => ConvertView(m)).ToList();
        }

        public static M_事業所明細Entity ConvertDomain(M_事業所明細ViewEntity viewEntity)
        {
            return new M_事業所明細Entity()
            {
                事業所番号 = viewEntity.事業所番号,
                連番 = viewEntity.連番,
                施設名 = viewEntity.施設名,
                種類コード = viewEntity.種類コード,
                サービス提供単位番号 = viewEntity.サービス提供単位番号,
                定員 = viewEntity.定員,
                多機能型用件 = viewEntity.多機能型用件,
                単位数単価 = viewEntity.単位数単価,
                種類区分 = viewEntity.種類区分,
            };
        }

        public static List<M_事業所明細Entity> ConvertDomain(IEnumerable<M_事業所明細ViewEntity> viewEntities)
        {
            return viewEntities.Select(m => ConvertDomain(m)).ToList();
        }
    }
}
