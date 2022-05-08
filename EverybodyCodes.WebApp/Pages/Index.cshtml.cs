using EverybodyCodes.Data.Models;
using EverybodyCodes.WebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace EverybodyCodes.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public IndexCameraModel IndexCameraModel { get; private set; }
        public readonly string MapBoxAccessToken;

        public IndexModel(IHttpClientFactory httpClientFactory, 
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            MapBoxAccessToken = GetAccessToken();
        }

        public async Task OnGet()
        {
            var webApiBaseUrl = _configuration.GetValue<string>("EverybodyCodes.WebAPI:baseUrl");
            var webApiGetCameraListUrl = _configuration.GetValue<string>("EverybodyCodes.WebAPI:getCameraListUrl");
            var url = $"{webApiBaseUrl}{webApiGetCameraListUrl}";

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
                {
                    { HeaderNames.Accept, "text/plain" },
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var cameraDetails = await JsonSerializer.DeserializeAsync<IEnumerable<CameraDetailsDto>>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                IndexCameraModel = cameraDetails != null ? new IndexCameraModel(cameraDetails) : new IndexCameraModel();
            }
        }

        private string GetAccessToken()
        {
            return _configuration.GetValue<string>("MapBox:accessToken");
        }
    }
}