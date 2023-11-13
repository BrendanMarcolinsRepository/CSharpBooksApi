using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Text.Json;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;

namespace BooksUIBlazor.Data
{
    public class UserLoginService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UserLoginService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<UserLogin> Login(UserLogin userLogin) 
        {

            if (userLogin == null) return null;

            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7158/api/Login/"),
                Content = new StringContent(JsonSerializer.Serialize(userLogin), Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();

            var user = await response.Content.ReadFromJsonAsync<UserLogin>();


            var output = user is not null ? $"User  exist !!  - {user}" : "User doesnt exist !!";

            Debug.WriteLine(output);

            return user is not null ? user : null;
        }
    }
}
