using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Objects;

namespace Blog.Repository
{
    public class EFUserRepository : IUserRepository
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public EFUserRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public EFUserRepository()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["MyBlogEntities"].ConnectionString;
        }
        #endregion


        public User GetUser(string login, string password)
        {
            using (ObjectContext context = new ObjectContext(this._connectionString))
            {
                return context.CreateObjectSet<User>().Single(u => u.Login == login && u.Password == password);
            }
        }

        public List<User> GetUsers()
        {
            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                return context.CreateObjectSet<User>().ToList();
            }
            
        }

        public void UpdateUser(int Id, bool IsEnable)
        { 
            using ( ObjectContext context = new ObjectContext(_connectionString))
            {
                User user = context.CreateObjectSet<User>().First(u=>u.Id==Id);
                user.IsEnable = IsEnable;
                context.SaveChanges();
            }
        }


        public void AddUser(User user)
        {
            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                var users = context.CreateObjectSet<User>();
                users.AddObject(user);

                context.SaveChanges();
            }
            
        }


        public User GetUser(string login)
        {
            using (ObjectContext context = new ObjectContext(this._connectionString))
            {
                return context.CreateObjectSet<User>().Single(u => u.Login == login);
            }
        }
    }
}
