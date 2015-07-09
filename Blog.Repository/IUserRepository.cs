using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities;

namespace Blog.Repository
{
     public interface IUserRepository
    {
        User GetUser(string login, string password);
        List<User> GetUsers();
       // void UpdateUser();
        void AddUser(User user);
    }
}
