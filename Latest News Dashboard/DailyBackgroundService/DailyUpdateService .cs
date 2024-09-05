using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Latest_News_Dashboard.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace Latest_News_Dashboard.DailyBackgroundService
{
    public class DailyUpdateService : BackgroundService
    {
        private readonly ILogger<DailyUpdateService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DailyUpdateService(ILogger<DailyUpdateService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var interval = TimeSpan.FromDays(1);
            _logger.LogInformation("DailyUpdateService is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var newsAPIService = scope.ServiceProvider.GetRequiredService<INewsAPIService>();
                        await newsAPIService.UpdateYesterdayNews("Apple");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,"Error");
                }
                await Task.Delay(interval, stoppingToken);
            }
        }

    }
}