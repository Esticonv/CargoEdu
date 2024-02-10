namespace OrderManager
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting {nameof(Worker)}");
            try {
                //Действия при старте сервиса. Например, запуск реббита 
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error during start bus");
            }
            cancellationToken.Register(() => _logger.LogInformation($"{nameof(Worker)} task is stopping."));
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) {
                if (_logger.IsEnabled(LogLevel.Information)) {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }       

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //Действия при останове сервиса 
            return base.StopAsync(cancellationToken);
        }
    }
}
