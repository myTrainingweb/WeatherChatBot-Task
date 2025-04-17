using Microsoft.EntityFrameworkCore;

namespace WeatherBotApi.Models
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }

        public DbSet<WeatherLog> WeatherLogs { get; set; }
    }
}
