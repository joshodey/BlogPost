using BlogBlazor.entities;
using Newtonsoft.Json;

namespace BlogBlazor.Services
{
    public class BlogService
    {
        private List<data> BlogItems;

        private BlogService(List<data> items)
        {
            BlogItems = items;
        }

        public static async Task<BlogService> CreateAsync()
        {
            var items = await ThirdPartyBlog();
            return new BlogService(items);
        }

        public static async Task<List<data>> ThirdPartyBlog()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://mocki.io/v1/d33691f7-1eb5-45aa-9642-8d538f6c5ebd");
                response.EnsureSuccessStatusCode();

                string body = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(body);

                var res = apiResponse.Data;

                return res;
            }
        }
    }



}

