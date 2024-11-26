using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace THNDotNetCore.HttpClientConsoleApp
{
    public class HttpClientExample
    {
        private readonly HttpClient _client;
        private readonly string _postEndpoint = "https://jsonplaceholder.typicode.com/posts";

        public HttpClientExample()
        {
            _client = new HttpClient();
        }

        public async Task Read()
        {
            var response = await _client.GetAsync(_postEndpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }

        public async Task Edit(int id)
        {
            var response = await _client.GetAsync($"{_postEndpoint}/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Not found.");
                return;
            }
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }

        public async Task Create(int userId, string title, string body)
        {
            PostModel request = new PostModel()
            {
                title = title,
                userId = userId,
                body = body
            };

            var jsonStr = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_postEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Update(int id,  int  userId, string title, string body)
        {
            PostModel request = new PostModel()
            {
                id = id,
                title = title,
                userId = userId,
                body = body
            };

            var jsonStr = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_postEndpoint}/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"{_postEndpoint}/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Not found.");
                return;
            }
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }
    }

    public class PostModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

}
