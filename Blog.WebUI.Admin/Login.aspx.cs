using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyBlogEntities"].ConnectionString;
            IUserRepository userRepository = new EFUserRepository(connectionString);
            ISecurityManager securityManager = new SecurityManager(userRepository);
            string userName = Login1.UserName;
            string password = Login1.Password;
            if (securityManager.LoginAsAdmin(userName, password) == true)
            {
                
            }
            else
            {
                Panel1.Visible = true;
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}