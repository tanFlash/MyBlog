using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using NLog;
using Blog.WebUI.Frontend.Controllers;
namespace Blog.WebUI.Frontend
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Initialise();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //var viewResult = new ViewResult();
            try
            {
                if (Server.GetLastError() != null)
                {
                    HttpContext ctx = HttpContext.Current;
                    Exception ex = ctx.Server.GetLastError();
                    ctx.Response.Clear();
                    RequestContext rc = ((MvcHandler)ctx.CurrentHandler).RequestContext;
                    IController controller = new ErrorController(); // Тут можно использовать любой контроллер, например тот что используется в качестве базового типа
                    var context = new ControllerContext(rc, (ControllerBase)controller);
                    var viewResult = new ViewResult();
                    var httpException = ex as HttpException;
                    if (httpException!=null)
                    {
                        switch (httpException.GetHttpCode())
                        {
                            case 404:
                                viewResult.ViewName = "Error404";
                                break;
                            case 500:
                                viewResult.ViewName = "Error500";
                                break;
                            default:
                                viewResult.ViewName = "Error";
                                break;
                        }
                    }
                    else
                    {
                        Logger logger = LogManager.GetCurrentClassLogger();
                        logger.Log(LogLevel.Error, ex);
                        viewResult.ViewName = "Error";
                    }
                    viewResult.ViewData.Model = new HandleErrorInfo(ex, context.RouteData.GetRequiredString("controller"), context.RouteData.GetRequiredString("action"));
                    viewResult.ExecuteResult(context);
                    ctx.Server.ClearError();
                }
            }
            catch { }

        }
    }
}