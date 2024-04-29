namespace PlayerRegistration.Settings;

public class RabbitMQSettings
{
    public const string Section = "RabbitMQSettings";
    public string Hostname { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string ExchangeName { get; set; } = "";
    public string RoutingKey { get; set; } = "";
}
