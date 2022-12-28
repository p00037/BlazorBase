using BlazorBase.Domain.Models;
using BlazorBase.Shared.ViewModels.MstOffice;

namespace BlazorBase.Server.Converter
{
    public class M_事業所Convertor
    {
        public static M_事業所ViewEntity ConvertView(M_事業所Entity domainEntity)
        {
            return new M_事業所ViewEntity()
            {
                事業所番号 = domainEntity.事業所番号,
                事業所名 = domainEntity.事業所名,
                事業所名カナ = domainEntity.事業所名カナ,
                郵便番号 = domainEntity.郵便番号,
                住所 = domainEntity.住所,
                電話番号 = domainEntity.電話番号,
                定員規模 = domainEntity.定員規模,
                就労継続A型減免有無 = domainEntity.就労継続A型減免有無,
                登録日 = domainEntity.登録日,
                M_事業所明細Entities = M_事業所明細Convertor.ConvertView(domainEntity.M_事業所明細Entities)
            };
        }

        public static List<M_事業所ViewEntity> ConvertView(IEnumerable<M_事業所Entity> domainEntities)
        {
            return domainEntities.Select(m => ConvertView(m)).ToList();
        }

        public static M_事業所Entity ConvertDomain(M_事業所ViewEntity viewEntity)
        {
            return new M_事業所Entity()
            {
                事業所番号 = viewEntity.事業所番号,
                事業所名 = viewEntity.事業所名,
                事業所名カナ = viewEntity.事業所名カナ,
                郵便番号 = viewEntity.郵便番号?.Replace("-", ""),
                住所 = viewEntity.住所,
                電話番号 = viewEntity.電話番号,
                定員規模 = viewEntity.定員規模,
                就労継続A型減免有無 = viewEntity.就労継続A型減免有無,
                登録日 = viewEntity.登録日,
                M_事業所明細Entities = M_事業所明細Convertor.ConvertDomain(viewEntity.M_事業所明細Entities)
            };
        }

        public static List<M_事業所Entity> ConvertDomain(IEnumerable<M_事業所ViewEntity> viewEntities)
        {
            return viewEntities.Select(m => ConvertDomain(m)).ToList();
        }
    }
}
