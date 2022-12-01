using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBase.Client.Service
{
    public interface IAPIService
    {
        //GET Method(Search Services)
        Task<T> GetRequest<T>(string requestUri);

        //POST Method
        Task<T> PostRequest<T>(string serviceName, object postObject);

        Task PostRequest(string serviceName, object postObject);

        Task<T> PutRequest<T>(string serviceName, object postObject);

        Task PutRequest(string serviceName, object postObject);

        Task<T> DeleteRequest<T>(string serviceName, object postObject);

        Task DeleteRequest(string serviceName, object postObject);

        Task<Stream> DownloadFile(string requestUri);
    }
}
