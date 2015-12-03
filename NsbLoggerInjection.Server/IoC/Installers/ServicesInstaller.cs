using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NsbLoggerInjection.Components;

namespace NsbLoggerInjection.Server.IoC.Installers
{
  public class ServicesInstaller : IWindsorInstaller
  {
    /// <summary>
    /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
    /// </summary>
    /// <param name="container">The container.</param><param name="store">The configuration store.</param>
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(
        Component.For<IWorker>()
                 .ImplementedBy<Worker>()
                 .LifestyleTransient());
    }
  }
}
