using System.Threading.Tasks;

namespace WeatherBotApi.Services
{
    public interface IWeatherService
    {
        Task<string> GetWeatherAsync(string city, string date);
    }
}
