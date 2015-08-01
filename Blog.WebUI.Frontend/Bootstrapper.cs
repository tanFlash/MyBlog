using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using System.Configuration;
using Blog.Repository;

namespace Blog.WebUI.Frontend
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

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyBlogEntities"].ConnectionString;
        container.RegisterType<IArticleRepository, EFArticleRepository>(new InjectionConstructor(connectionString));
        container.RegisterType<IUserRepository, EFUserRepository>(new InjectionConstructor(connectionString));
        container.RegisterType<ICommentRepository, EFCommentRepository>(new InjectionConstructor(connectionString));
        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
  }
}