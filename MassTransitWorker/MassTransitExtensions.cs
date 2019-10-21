using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using MassTransiteContracts;
using System;
using Microsoft.Extensions.Logging;

namespace MassTransitWorker
{
    public static class MassTransitExtensions
    {
        public static void AddMassTransitAzureServiceBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(masstransit => 
            {
                masstransit.AddConsumer<ContractConsumer>();

                masstransit.AddBus(provider => AzureBusFactory.CreateUsingServiceBus(cfg => 
                {
                    cfg.UseExtensionsLogging(provider.GetRequiredService<ILoggerFactory>());

                    cfg.Message<IContrato>(m => m.SetEntityName(configuration.GetValue<string>("Bus:Topic")));

                    var host = cfg.Host(configuration.GetValue<string>("Bus:ConnectionString"), h => 
                    {
                        h.RetryLimit = 3;
                        h.OperationTimeout = TimeSpan.FromSeconds(30);
                    });

                    cfg.ReceiveEndpoint("masstransitreceiver", c => {
                        c.Consumer<ContractConsumer>(provider);
                    });
                }));
            });
        }
    }
}
