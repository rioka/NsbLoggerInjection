
using System;
using NsbLoggerInjection.Server.IoC;

namespace NsbLoggerInjection.Server
{
  using NServiceBus;

  public class EndpointConfig : IConfigureThisEndpoint
  {
    public void Customize(BusConfiguration configuration)
    {
      configuration.EndpointName(GetType().Namespace);
      configuration.UseTransport<MsmqTransport>();
      configuration.UsePersistence<InMemoryPersistence>();
      configuration.EnableInstallers();
      configuration.UseSerialization<JsonSerializer>();

      configuration.Conventions()
                   .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages"))
                   .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Commands"))
                   .DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Events"));

      configuration.UseContainer<WindsorBuilder>(c => c.ExistingContainer(Bootstrapper.Boot(AppDomain.CurrentDomain.BaseDirectory)));
    }
  }
}
