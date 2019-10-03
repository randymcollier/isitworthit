using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsItWorthIt.Tests.Api
{
    public class ApiTestClient : IDisposable
    {
        private readonly HttpClient _client;

        public ApiTestClient(HttpClient client)
        {
            _client = client;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        public Task<ApiTestResponse<T>> GetAsync<T>(string uri)
        {
            return InvokeAsync<T>(
                client => client.GetAsync(uri),
                async response =>
                {
                    return new ApiTestResponse<T> { ResponseMessage = response, Data =  await response.Content.ReadAsAsync<T>()};
                });
        }

        public Task<ApiTestResponse<T>> PostAsJsonAsync<T>(object data, string uri)
        {
            return InvokeAsync<T>(
                client => client.PostAsJsonAsync(uri, data),
                async response =>
                {
                    return new ApiTestResponse<T> { ResponseMessage = response, Data =  await response.Content.ReadAsAsync<T>()};
                });
        }

        public Task<ApiTestResponse> PostAsJsonAsync(object data, string uri)
        {
            return InvokeAsync(
                client => client.PostAsJsonAsync(uri, data),
                response =>
                {
                    return Task.FromResult(new ApiTestResponse { ResponseMessage = response });
                });
        }

        public Task<ApiTestResponse> PutAsJsonAsync(object data, string uri)
        {
            return InvokeAsync(
                client => client.PutAsJsonAsync(uri, data),
                response =>
                {
                    return Task.FromResult(new ApiTestResponse { ResponseMessage = response });
                });
        }

        public Task<ApiTestResponse<T>> PutAsJsonAsync<T>(object data, string uri)
        {
            return InvokeAsync<T>(
                client => client.PutAsJsonAsync(uri, data),
                async response =>
                {
                    return new ApiTestResponse<T> { ResponseMessage = response, Data =  await response.Content.ReadAsAsync<T>()};
                });
        }

        private async Task<ApiTestResponse<T>> InvokeAsync<T>(
            Func<HttpClient, Task<HttpResponseMessage>> operation,
            Func<HttpResponseMessage, Task<ApiTestResponse<T>>> actionOnResponse)
        {
            if(operation == null) throw new ArgumentNullException(nameof(operation));

            HttpResponseMessage response = await operation(_client).ConfigureAwait(false);

            if(!response.IsSuccessStatusCode)
            {
                var exception = new Exception($"Resource server returned an error. StatusCode : {response.StatusCode}");
                exception.Data.Add("StatusCode", response.StatusCode);
                throw exception;
            }
            return await actionOnResponse(response).ConfigureAwait(false);
        }

        private async Task<ApiTestResponse> InvokeAsync(
            Func<HttpClient, Task<HttpResponseMessage>> operation,
            Func<HttpResponseMessage, Task<ApiTestResponse>> actionOnResponse)
        {
            if(operation == null) throw new ArgumentNullException(nameof(operation));

            HttpResponseMessage response = await operation(_client).ConfigureAwait(false);

            if(!response.IsSuccessStatusCode)
            {
                var exception = new Exception($"Resource server returned an error. StatusCode : {response.StatusCode}");
                exception.Data.Add("StatusCode", response.StatusCode);
                throw exception;
            }
            return await actionOnResponse(response).ConfigureAwait(false);
        }
    }

    public class ApiTestResponse
    {
        public HttpResponseMessage ResponseMessage { get; set; }
    }

    public class ApiTestResponse<T> : ApiTestResponse
    {
        public T Data { get; set; }
    }
}