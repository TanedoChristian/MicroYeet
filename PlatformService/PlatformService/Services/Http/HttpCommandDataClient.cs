using PlatformService.Dto;
using System.Text;
using System.Text.Json;

namespace PlatformService.Services.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private HttpClient _httpClient;
        private IConfiguration _config;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task SendPlatformToCommand(PlatformDto platformRead)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platformRead),
                Encoding.UTF8,
                "application/json"
                );


            var response = await _httpClient.PostAsync($"{_config["CommandService"]}/api/c/platform", httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync Post Command Service was Ok");
            } else
            {
                Console.WriteLine("Not okay");
            }


        }
    }
}
