using System.Threading.Tasks;
using MassTransit;
using MassTransiteContracts;
using Microsoft.Extensions.Logging;

namespace MassTransitWorker
{
    public class ContractConsumer : IConsumer<IContrato>
    {
        private readonly ILogger<ContractConsumer> logger;

        public ContractConsumer(ILogger<ContractConsumer> logger)
        {
            this.logger = logger;
        }
        public Task Consume(ConsumeContext<IContrato> context)
        {
            logger.LogInformation($"Mensagem recebida. Nome: {context.Message.Nome}");

            return Task.CompletedTask;
        }
    }
}
