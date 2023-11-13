using BooksUI.Models.DTO.AuthorDto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace BooksUI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BooksController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Get all books from api

            List<AuthorDto> authors = new List<AuthorDto>();

            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7158/api/Author");

                httpResponseMessage.EnsureSuccessStatusCode();
            
                
                authors.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<AuthorDto>>());

            }
            catch (Exception e)
            {

                throw;
            }


            return View(authors);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GeneralAuthorDto model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7158/api/Author"),
                Content = new StringContent(JsonSerializer.Serialize(model),Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();


            var author = await response.Content.ReadFromJsonAsync<AuthorDto>();

            return author is not null ? RedirectToAction("Index", "Books") : View();

            
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var client = httpClientFactory.CreateClient();

            var authorHttpResponse = await client.GetFromJsonAsync<AuthorDto>($"https://localhost:7158/api/Author/{Id}");

            return authorHttpResponse is not null ? View(authorHttpResponse) : View(null);

            
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AuthorDto authorDto)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7158/api/Author/{authorDto.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(authorDto), Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(httpRequestMessage);

            response.EnsureSuccessStatusCode();

            var author = await response.Content.ReadFromJsonAsync<AuthorDto>();

            return author is not null ? RedirectToAction("Edit", "Books") : View();

        }


        [HttpPost]
        public async Task<IActionResult> Delete(AuthorDto authorDto)
        {
            var client = httpClientFactory.CreateClient();

            var responseDelete = await client.DeleteAsync($"https://localhost:7158/api/Author/{authorDto.Id}");

            responseDelete.EnsureSuccessStatusCode();

            return responseDelete is not null ? RedirectToAction("Index", "Books") : View();
        }

    }
}
