using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Blog.WebUI
{
    public interface ISecurityManager
    {
        bool Login(string userName, string password);
        bool LoginAsAdmin(string userName, string password);
        void Logout();
        bool IsAuthenticated { get; }
        IPrincipal CurrentUser { get; }
        User GetAuthUser(); 
        void RefreshPrincipal();
    }
}
