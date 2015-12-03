using System;
using NsbLoggerInjection.Client.NsbLoggerInjection.Client;
using NsbLoggerInjection.Messages.Commands;

namespace NsbLoggerInjection.Client
{
  class Program
  {
    private const string Trigger = "S";

    static void Main(string[] args)
    {
      ServiceBus.Init();
      var rgn = new Random();
      var bus = ServiceBus.Bus;

      while (true)
      {
        Console.WriteLine("Enter '{0}' to start an order", Trigger);
        Console.WriteLine("Press any other key to exit");

        var input = (Console.ReadLine() ?? "").ToUpper();

        if (input != Trigger)
        {
          break;
        }

        var id = Guid.NewGuid();
        bus.Send<CreateOrder>("NsbLoggerInjection.Server", m => {
          m.CustomerCode = Guid.NewGuid().ToString();
          m.Date = DateTime.Now;
        });

        Console.WriteLine("request '{0}' sent", id);
      }

      bus.Dispose();
    }
  }
}
