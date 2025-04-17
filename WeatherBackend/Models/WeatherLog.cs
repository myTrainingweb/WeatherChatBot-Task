using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherBotApi.Models
{
    public class WeatherLog
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime DateRequested { get; set; }
        public string Response { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    }
}
