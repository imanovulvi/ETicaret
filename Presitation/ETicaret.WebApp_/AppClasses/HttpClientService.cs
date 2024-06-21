
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ETicaret.WebApp_.AppClasses
{


    public class HttpClientService
    {
        private string url;

        public HttpClientService(RequestParametrs requestParametrs)
        {

            if (requestParametrs.FullEndPoint is null)
                url = $"{requestParametrs.BaseUrl}/{requestParametrs.Controller}{(requestParametrs.Action is not null ? "/" + requestParametrs.Action : "")}";
            else
                url = requestParametrs.FullEndPoint;
        }
        public async Task<T?> GetAsync<T>(int page, int size, string token = null) where T : class
        {
            using HttpClient httpClient = new HttpClient();



            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url + $"?page={page}&&size={size}");
            if (token is not null)
                httpRequestMessage.Headers.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);

            }
            else
                return null;



        }



        public async Task<T> GetByIdAsync<T>(string Id, string token = null) where T : class
        {
            using HttpClient httpClient = new HttpClient();


            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url + "/" + Id);
            if (token is not null)
                httpRequestMessage.Headers.Add("Authorization", $"Bearer {token}");
            HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(json);

            }
            else
                return null;

        }


        public async Task<TResult> PostAsync<T, TResult>(T Entity, string token = null) where TResult : class
        {
            using HttpClient httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(Entity), Encoding.UTF8, "application/json");

            if (token is not null)
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(responseContent);
            }

            return null;

        }






        public async Task<bool> PutAsync<T>(T Entity, string token = null)
        {
            using HttpClient httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(Entity), Encoding.UTF8, "application/json");

            if (token is not null)
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage responseMessage = await httpClient.PutAsync(url, content);
            return responseMessage.IsSuccessStatusCode;


        }

        public async Task<bool> DeleteAsync(string Id, string token = null)
        {
            using HttpClient httpClient = new HttpClient();

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, url + "?Id=" + Id);

            if (token is not null)
                httpRequestMessage.Headers.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage responseMessage = await httpClient.SendAsync(httpRequestMessage);


            return responseMessage.IsSuccessStatusCode;

        }


        public async Task<bool> PostImageAsync(IFormFileCollection formFiles, string Id, string token = null)
        {
            using var httpClient = new HttpClient();

            var content = new MultipartFormDataContent();

            foreach (var file in formFiles)
            {

                var fileStream = file.OpenReadStream();

                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                content.Add(fileContent, "file", file.FileName);
            }
            if (token is not null)
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await httpClient.PostAsync(url + "/Upload?ProductId=" + Id, content);

            return response.IsSuccessStatusCode;


        }



        public async Task<List<T>> GetFileAsync<T>(string Id, string token = null) where T : class
        {
            using HttpClient httpClient = new HttpClient();


            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response = await httpClient.GetAsync(url + $"/GetFile/{Id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var aa = JsonConvert.DeserializeObject<List<T>>(json);
                return JsonConvert.DeserializeObject<List<T>>(json);

            }
            else
                return null;

        }


        public async Task<bool> GetFileRemoveAsync(string productid, string fileid, string token = null)
        {
            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response = await httpClient.GetAsync(url + $"/GetFileRemove/{productid}/{fileid}");
            return response.IsSuccessStatusCode;


        }




    }
}
