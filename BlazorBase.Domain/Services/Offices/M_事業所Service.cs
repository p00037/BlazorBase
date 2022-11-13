using BlazorBase.Domain.Models;

namespace BlazorBase.Domain.Services
{
    public class M_事業所Service
    {
        readonly IM_事業所Repository repository;

        public M_事業所Service(IM_事業所Repository repository)
        {
            this.repository = repository;
        }

        public string ExistsMessage => "事業所番号が重複しています。";

        public bool Exists(M_事業所Entity entity)
        {
            M_事業所Entity tmpEntity = repository.Get(entity.事業所番号);
            return tmpEntity != null;
        }
    }
}