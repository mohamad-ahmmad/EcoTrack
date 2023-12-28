namespace Report_Processor_Service.Models
{
    public class RabbitMqConfiguration
    {
        public string IpAddress { get; set; } = string.Empty;
        public string ExchangeName { get; set; } = string.Empty;
        public string RoutingKey { get; set; } = string.Empty;
    }
}
