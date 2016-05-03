using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using FlatPlanet.Service.Interfaces;
using FlatPlanet.Service.Concrete;
using FlatPlanet.Data.Interfaces;
using FlatPlanet.Data;
using FlatPlanet.Data.Concrete;

namespace FlatPlanet
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICounterService, CounterService>();
            container.RegisterType<IRepository<Counter>, Repository<Counter>>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}