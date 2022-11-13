using System.Text;
using BlazorBase.Client.Exceptions;
using BlazorBase.Shared.Enums;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;

namespace BlazorBase.Client.Service
{
    public class APIService : IAPIService
    {
        private readonly HttpClient httpClient;

        public APIService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //GET Method(Search Services)
        public async Task<T> GetRequest<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri);
            return await CheckException<T>(response);
        }

        // POST Method
        public async Task<T> PostRequest<T>(string serviceName, object postObject)
        {
            string jsonString = JsonConvert.SerializeObject(postObject);
            var requestUri = $"{httpClient.BaseAddress.ToString()}{serviceName}";
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(requestUri),
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
            };
            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);
            var response = await httpClient.SendAsync(requestMessage);

            return await CheckException<T>(response);
        }

        public async Task PostRequest(string serviceName, object postObject)
        {
            string jsonString = JsonConvert.SerializeObject(postObject);
            var requestUri = $"{httpClient.BaseAddress}{serviceName}";
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(requestUri),
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);
            var response = await httpClient.SendAsync(requestMessage);
        }

        public async Task<T> PutRequest<T>(string serviceName, object postObject)
        {
            string jsonString = JsonConvert.SerializeObject(postObject);
            var requestUri = $"{httpClient.BaseAddress.ToString()}{serviceName}";
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("PUT"),
                RequestUri = new Uri(requestUri),
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
            };
            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);
            var response = await httpClient.SendAsync(requestMessage);

            return await CheckException<T>(response);
        }

        public async Task PutRequest(string serviceName, object postObject)
        {
            string jsonString = JsonConvert.SerializeObject(postObject);
            var requestUri = $"{httpClient.BaseAddress}{serviceName}";
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("PUT"),
                RequestUri = new Uri(requestUri),
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);
            var response = await httpClient.SendAsync(requestMessage);
            await CheckException(response);
        }

        public async Task<T> DeleteRequest<T>(string serviceName, object postObject)
        {
            string jsonString = JsonConvert.SerializeObject(postObject);
            var requestUri = $"{httpClient.BaseAddress.ToString()}{serviceName}";
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("DELETE"),
                RequestUri = new Uri(requestUri),
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
            };
            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);
            var response = await httpClient.SendAsync(requestMessage);

            return await CheckException<T>(response);
        }

        public async Task DeleteRequest(string serviceName, object postObject)
        {
            string jsonString = JsonConvert.SerializeObject(postObject);
            var requestUri = $"{httpClient.BaseAddress}{serviceName}";
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("DELETE"),
                RequestUri = new Uri(requestUri),
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);
            var response = await httpClient.SendAsync(requestMessage);
        }

        private async Task<T> CheckException<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                throw new ServerException(content);
            }
            
            return JsonConvert.DeserializeObject<T>(content);
        }

        private async Task CheckException(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                throw new ServerException(content);
            }
        }
    }
}
