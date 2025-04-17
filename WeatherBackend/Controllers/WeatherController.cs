using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherBotApi.Models;
using WeatherBotApi.Services;

namespace WeatherBotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly WeatherDbContext _context;

        public WeatherController(IWeatherService weatherService, WeatherDbContext context)
        {
            _weatherService = weatherService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DialogflowWebhookRequest request)
        {
            var city = request.queryResult.parameters.geo_city;
            var date = request.queryResult.parameters.date ?? DateTime.UtcNow.ToString("yyyy-MM-dd");
            var weatherData = await _weatherService.GetWeatherAsync(city, date);

            var log = new WeatherLog
            {
                City = city,
                DateRequested = DateTime.Parse(date),
                Response = weatherData
            };
            _context.WeatherLogs.Add(log);
            await _context.SaveChangesAsync();

            return Ok(new DialogflowWebhookResponse { fulfillmentText = $"Here's the weather data for {city} on {date}:{ weatherData }" });
        }
    }
}
