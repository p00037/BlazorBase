using BlazorBase.Client.Service;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.ViewModels.MstOffice;

namespace BlazorBase.Client.HttpClients
{
    public class MstOfficeClient
    {
        private readonly IAPIService _apiService;

        public MstOfficeClient(IAPIService apiService)
        {
            _apiService = apiService;
        }

        public async Task<MstOfficeViewModel> GetViewModel(string officeNo)
        {
            return await _apiService.GetRequest<MstOfficeViewModel>($"api/MstOffice?officeNo={officeNo}");
        }

        public async Task<List<M_事業所ViewEntity>> GetList(MstOfficeSearchViewEntity search)
        {
            return await _apiService.PostRequest<List<M_事業所ViewEntity>>("api/MstOfficeList", search);
        }

        public async Task<RequestResult> Register(M_事業所ViewEntity entity)
        {
            return await _apiService.PutRequest<RequestResult>("api/MstOffice", entity);
        }

        public async Task<RequestResult> Update(M_事業所ViewEntity entity)
        {
            return await _apiService.PostRequest<RequestResult>("api/MstOffice", entity);
        }

        public async Task<RequestResult> Delete(M_事業所ViewEntity entity)
        {
            return await _apiService.DeleteRequest<RequestResult>("api/MstOffice", entity);
        }
    }
}
