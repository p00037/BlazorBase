using BlazorBase.Client.Service;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.MstLoginUser;

namespace BlazorBase.Client.HttpClients
{
    public class MstLoginUserClient
    {
        private readonly IAPIService _apiService;

        public MstLoginUserClient(HttpClient httpClient)
        {
            HttpClient allowAnonymousHttpClient = new HttpClient() { BaseAddress = httpClient.BaseAddress };
            _apiService = new APIService(allowAnonymousHttpClient);
        }

        public async Task<MstLoginUserViewModel> GetViewModel(string userName)
        {
            return await _apiService.GetRequest<MstLoginUserViewModel>($"api/MstLoginUser?userName={userName}");
        }

        public async Task<List<M_ログインユーザーViewEntity>> GetList(MstLoginUserSearchViewEntity search)
        {
            return await _apiService.PostRequest<List<M_ログインユーザーViewEntity>>("api/MstLoginUserList", search);
        }

        public async Task<RequestResult> Register(M_ログインユーザーViewEntity entity)
        {
            return await _apiService.PutRequest<RequestResult>("api/MstLoginUser", entity);
        }

        public async Task<RequestResult> Update(M_ログインユーザーViewEntity entity)
        {
            return await _apiService.PostRequest<RequestResult>("api/MstLoginUser", entity);
        }

        public async Task<RequestResult> Delete(M_ログインユーザーViewEntity entity)
        {
            return await _apiService.DeleteRequest<RequestResult>("api/MstLoginUser", entity);
        }
    }
}
