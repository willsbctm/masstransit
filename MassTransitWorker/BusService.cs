using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MassTransitWorker
{
    public class BusService : IHostedService
    {
        private readonly ILogger<BusService> logger;
        private readonly IBusControl busControl;

        public BusService(ILogger<BusService> logger, IBusControl busControl)
        {
            this.logger = logger;
            this.busControl = busControl;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Bus inciado às {DateTimeOffset.Now}");
            return busControl.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Bus parado às {DateTimeOffset.Now}");
            return busControl.StopAsync(cancellationToken);
        }
    }
}
