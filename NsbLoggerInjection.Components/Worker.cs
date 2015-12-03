using System.Reflection;
using System.Threading;
using Castle.Core.Logging;

namespace NsbLoggerInjection.Components
{
  public class Worker : IWorker
  {
    public ILogger Logger { get; set; }

    public Worker()
    {
      Logger = NullLogger.Instance;
    }

    public void Run()
    {
      Logger.InfoFormat("Just entered {0}...", MethodBase.GetCurrentMethod().Name);
      Thread.Sleep(100);
      Logger.InfoFormat("About to live {0}...", MethodBase.GetCurrentMethod().Name);
    }
  }
}
