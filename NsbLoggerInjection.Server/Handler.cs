using Castle.Core.Logging;
using NsbLoggerInjection.Components;
using NsbLoggerInjection.Messages.Commands;
using NServiceBus;

namespace NsbLoggerInjection.Server
{
  public class Handler : IHandleMessages<CreateOrder>
  {
    private readonly IWorker _worker;
    private readonly ILogger _logger;

    public Handler(IWorker worker, ILogger logger)
    {
      _worker = worker;
      _logger = logger;
    }

    public void Handle(CreateOrder message)
    {
      _logger.InfoFormat("Creating order for customer '{0}'", message.CustomerCode);
      _worker.Run();
      _logger.InfoFormat("Order for customer '{0}' created", message.CustomerCode);
    }
  }
}
