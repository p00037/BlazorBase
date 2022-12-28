using BlazorBase.Domain.Models;
using BlazorBase.Shared.ViewModels.MstOffice;

namespace BlazorBase.Server.Converter
{
    class MstOfficeSearchConvertor
    {
        public static MstOfficeSearchEntity ConvertDomain(MstOfficeSearchViewEntity viewEntity)
        {
            return new MstOfficeSearchEntity()
            {
                事業所番号 = viewEntity.事業所番号,
                事業所名 = viewEntity.事業所名,
                事業所名カナ = viewEntity.事業所名カナ,
                定員規模開始 = viewEntity.定員規模開始,
                定員規模終了 = viewEntity.定員規模終了,
            };
        }
    }
}
