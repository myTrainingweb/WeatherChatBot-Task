using Newtonsoft.Json.Linq;

namespace WeatherBotApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public WeatherService(IConfiguration config)
        {
            _config = config;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetWeatherAsync(string city, string date)
        {
            try
            {
                var apiKey = _config["OpenWeather:ApiKey"];
                var forecastUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

                var response = await _httpClient.GetAsync(forecastUrl);
                //return parsed.ToString();
                response.EnsureSuccessStatusCode(); // This line throws for errors
                var data = await response.Content.ReadAsStringAsync();
                var parsed = JObject.Parse(data);

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ API ERROR: " + ex.Message);
                return "Error: " + ex.Message;
            }

           
        }
    }
}
