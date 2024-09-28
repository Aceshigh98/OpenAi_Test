
namespace OpenAiService
{
    public class OpenAiSrervice
    {
        private readonly HttpClient _httpClient;
        private readonly string _apikey;

        public OpenAiSrervice(HttpClient httpClient, string apikey)
        {
            _httpClient = httpClient;
            _apikey = apikey;
        }


    }
}