namespace WeatherBotApi.Models
{
    public class DialogflowWebhookRequest
    {
        public QueryResult queryResult { get; set; }
    }

    public class QueryResult
    {
        public Parameters parameters { get; set; }
    }

    public class Parameters
    {
        public string geo_city { get; set; }
        public string date { get; set; }
    }
}
