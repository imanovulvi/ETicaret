﻿
using Newtonsoft.Json;
using System.Text;

namespace ETicaret.WebApp_.AppClasses
{
    

    public class HttpClientService
    {
        private string url;
        public HttpClientService(RequestParametrs requestParametrs)
        {
            if (requestParametrs.FullEndPoint is null)
                url = $"{requestParametrs.BaseUrl}/{requestParametrs.Controller}{(requestParametrs.Action is not null ? "/"+requestParametrs.Action : "")}";
            else
                url = requestParametrs.FullEndPoint; 
        }
        public async Task<T> GetAsync<T>(int page,int size) where T : class
        {
            using (HttpClient httpClient=new HttpClient())
            {
               
                HttpResponseMessage response = await httpClient.GetAsync(url+$"?page={page}&&size={size}");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);

                }
                else
                    return null;
                

            }
        }

        public async Task<T> GetByIdAsync<T>(string Id)where T : class 
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url+"/"+Id);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(json);
               
                }
                else
                    return null;
            }
        }


        public async Task<bool> PostAsync<T>(T Entity)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(Entity), Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(url, content);
                return responseMessage.IsSuccessStatusCode;
                

            }
        }
        public async Task<bool> PutAsync<T>(T Entity)
        {
            using (HttpClient httpClient=new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(Entity), Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage=await httpClient.PutAsync(url, content);
                return responseMessage.IsSuccessStatusCode;
            }
             
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            using (HttpClient httpClient=new HttpClient())
            {
               HttpResponseMessage responseMessage= await httpClient.DeleteAsync(url+"?Id="+Id);
               return responseMessage.IsSuccessStatusCode;
            }
        }

    }
}