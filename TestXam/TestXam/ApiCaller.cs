using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TestXam
{
    using Entities;
    public class ApiCaller:IDisposable
    {
        private HttpClient client;
        public ApiCaller()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<GetPostResult>> GetPosts(string Url)
        {
            using (var response = await client.GetAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<GetPostResult>>(json);
                }
                return new List<GetPostResult>();
            }
        }
        public async Task<GetPostResult> GetPost(string Url,int id = 0)
        {
            if (id != 0)
            {
                Url = $"{Url}/{id}";
            }
            using(var response =await client.GetAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json =await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetPostResult>(json);
                }
                throw new Exception(response.ReasonPhrase);
            }
        }
        public void Dispose()
        {
            client.Dispose();
        }
    }
}
