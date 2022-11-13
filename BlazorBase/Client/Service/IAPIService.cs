using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBase.Client.Service
{
    public interface IAPIService
    {
        //GET Method(Search Services)
        public Task<T> GetRequest<T>(string requestUri);

        //POST Method
        public Task<T> PostRequest<T>(string serviceName, object postObject);

        public Task PostRequest(string serviceName, object postObject);

        public Task<T> PutRequest<T>(string serviceName, object postObject);

        public Task PutRequest(string serviceName, object postObject);

        public Task<T> DeleteRequest<T>(string serviceName, object postObject);

        public Task DeleteRequest(string serviceName, object postObject);
    }
}
