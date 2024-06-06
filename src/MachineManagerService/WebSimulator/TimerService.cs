namespace R7P.MachineManagerService.WebSimulator
{
    public class TimerService(NotifierService notifier,
        ILogger<TimerService> logger) : IDisposable
    {
        private int elapsedCount;
        private readonly static TimeSpan tickRate = TimeSpan.FromSeconds(5);
        private PeriodicTimer? timer;

        public async Task Start()
        {
            if (timer is null) {
                timer = new(tickRate);
                logger.LogInformation("Started");

                using (timer) {
                    while (await timer.WaitForNextTickAsync()) {
                        elapsedCount += 1;
                        await notifier.Update("elapsedCount", elapsedCount);
                        logger.LogInformation("ElapsedCount {Count}", elapsedCount);
                    }
                }
            }
        }

        public void Dispose()
        {
            timer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
