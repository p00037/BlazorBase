using BlazorBase.Domain.Models;

namespace BlazorBase.Domain.Services
{
    public class M_ログインユーザーService
    {
        readonly IM_ログインユーザーRepository repository;

        public M_ログインユーザーService(IM_ログインユーザーRepository repository)
        {
            this.repository = repository;
        }

        public string ExistsMessage => "ユーザー名が重複しています。";

        public bool Exists(M_ログインユーザーEntity entity)
        {
            M_ログインユーザーEntity duplicationEntity = repository.Get(entity.UserName);
            return duplicationEntity != null;
        }
    }
}