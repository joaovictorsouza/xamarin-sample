using ExemploVortice.Service.DTOs;
using ExemploVortice.Service.Infra;
using ExemploVortice.Service.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExemploVortice.Service
{
    public static class APIHelper
    {
        private static string baseAddress = "https://jsonplaceholder.typicode.com";
        #region Infra
        private static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private static async Task<TResponse> GetResponseAsync<TResponse, TObject>(HttpResponseMessage httpResponseMessage) where TResponse : APIResponseBase<TObject>, new() where TObject : new()
        {
            try
            {
                if (httpResponseMessage.IsSuccessStatusCode == false)
                {
                    if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new TResponse()
                        {
                            Response = new TObject()
                        };
                    }

                    if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException();
                    }

                    return new TResponse
                    {
                        Error = await httpResponseMessage.Content.ReadAsAsync<Error>()
                    };

                }
                else
                {
                    return new TResponse
                    {
                        Response = await httpResponseMessage.Content.ReadAsAsync<TObject>(),
                    };
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException();
            }
            catch (Exception ex)
            {
                var response = new TResponse
                {
                    Error = new Error { Description = ex.Message }
                };
                return response;
            }
        }

        private static TResponse GetErrorResponse<TResponse, TObject>(Exception ex) where TResponse : APIResponseBase<TObject>, new() where TObject : new()
        {
            if (ex.Message.ToLower().Contains("network is unreachable") || ex.Message.ToLower().Contains("nameresolution"))
            {
                return new TResponse
                {
                    Error = new Error { Description = "Por favor, verifique sua conexão com a internet." }
                };
            }
            return new TResponse
            {
                Error = new Error { Description = ex.Message }
            };
        }

        #endregion

        public async static Task<TodoItemResponse> GetTodosAsync()
        {
            using(var client = CreateClient())
            {
                var uri = "/todos";
                var response = await client.GetAsync(uri);
                return await GetResponseAsync<TodoItemResponse, List<TodoItem>>(response);
            }
        }

    }
}
