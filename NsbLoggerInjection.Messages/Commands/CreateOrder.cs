using System;

namespace NsbLoggerInjection.Messages.Commands
{
  public class CreateOrder
  {
    public string CustomerCode { get; set; }
    public DateTimeOffset Date { get; set; }
  }
}
