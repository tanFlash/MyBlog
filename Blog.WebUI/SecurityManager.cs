using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using Blog.Entities;
using System.Web.Security;


namespace Blog.WebUI
{
    public class SecurityManager: ISecurityManager
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructors
        public SecurityManager(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        #endregion

        #region ISecurityManager
        public bool Login(string userName, string password)
        {
            User user = this._userRepository.GetUser(userName, password);

            if (user == null)
            {
                return false;
            }

            this.RefreshPrincipal();

            FormsAuthentication.SetAuthCookie(userName, false);
            
            return true;
        }

        public bool LoginAsAdmin(string userName, string password)
        {
            User user = this._userRepository.GetUser(userName, password);

            if (user == null || user.IsAdmin==false)
            {
                return false;
            }

            this.RefreshPrincipal();

            FormsAuthentication.SetAuthCookie(userName, false);

            return true;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User != null
                    && HttpContext.Current.User.Identity != null
                    && HttpContext.Current.User.Identity.IsAuthenticated == true;
            }
        }

        public IPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User;
            }
        }

        public void RefreshPrincipal()
        {
            IPrincipal incomingPrincipal = HttpContext.Current.User;
            //if (this.IsAuthenticated == true)
            //{
                User user = this._userRepository.GetUser(incomingPrincipal.Identity.Name);
                HttpContext.Current.User = this.CreatePrincipal(user);
            //}
        }

        public User GetAuthUser()
        {
            IPrincipal incomingPrincipal = HttpContext.Current.User;
           
                User user = this._userRepository.GetUser(incomingPrincipal.Identity.Name);
                return user;
            
            
        }
        #endregion

        private ClaimsPrincipal CreatePrincipal(User user)
        {
            string userName = user.Login;
            List<string> roles = new List<string>();
            roles.Add("user");
            if (user.IsAdmin)
            {
                roles.Add("admin");
            }
            GenericIdentity identity = new GenericIdentity(user.Login);
            GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());

            return principal;
        }





       
    }
}
