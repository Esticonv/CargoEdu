namespace R7P.OrderService.Infrastructure.Options;

public class RabbitMqSettings
{
    public string Host {  get; set; }

    public string VHost { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }
}
