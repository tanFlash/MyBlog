using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using NLog;
using Blog.Repository;
using System.Configuration;

namespace Blog.WebUI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyBlogEntities"].ConnectionString;
            IUserRepository userRepository = new EFUserRepository(connectionString);
            ISecurityManager securityManager = new SecurityManager(userRepository);

            securityManager.RefreshPrincipal();

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                if (Server.GetLastError() != null)
                {
                    Exception ex = Server.GetLastError().GetBaseException();
                    if (ex is HttpException == false)
                    {
                        Logger logger = LogManager.GetCurrentClassLogger();
                        logger.Log(LogLevel.Error, ex);
                    }
                    Server.Transfer("~/Error.aspx");
                }
            }
            catch { }

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}