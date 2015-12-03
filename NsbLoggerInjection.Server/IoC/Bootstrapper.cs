using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace NsbLoggerInjection.Server.IoC
{
  /// <summary>
  /// Bootstrapper 
  /// </summary>
  public static class Bootstrapper
  {
    /// <summary>
    /// Bootstrap the IoC
    /// </summary>
    /// <returns>Returns a configured IoC</returns>
    public static IWindsorContainer Boot()
    {
      return new WindsorContainer().Install(FromAssembly.InThisApplication());
    }

    /// <summary>
    /// Bootstrap the IoC
    /// </summary>
    /// <param name="folder">Folder into which installers are searched</param>
    /// <returns>Returns a configured IoC</returns>
    public static IWindsorContainer Boot(string folder)
    {
      var container = new WindsorContainer().Install(FromAssembly.InDirectory(new AssemblyFilter(folder)));
#if DEBUG
      container.Kernel.ComponentRegistered += (k, h) =>
        Console.WriteLine("Registered {0} - {1}/{2}",
                          k, h.ComponentModel.ComponentName.Name, h.ComponentModel.Implementation.FullName);
#endif
      return container;
    }
  }
}
