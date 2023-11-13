namespace BooksUIBlazor.Data
{
    public class AuthorService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AuthorService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            List<Author> authors = new List<Author>();

            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7158/api/Author");

                httpResponseMessage.EnsureSuccessStatusCode();

                authors.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<Author>>());
                
                return authors;

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}