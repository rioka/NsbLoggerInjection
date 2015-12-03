﻿using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace NsbLoggerInjection.Server.IoC.Installers
{
 public class LoggingInstaller : IWindsorInstaller
  {
   /// <summary>
   /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
   /// </summary>
   /// <param name="container">The container.</param><param name="store">The configuration store.</param>
   public void Install(IWindsorContainer container, IConfigurationStore store)
   {
     container.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
   }
  }
}
