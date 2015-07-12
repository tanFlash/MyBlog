using Blog.Entities;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Frontend.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        private readonly IUserRepository _userRepository;

        public RegisterController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyBlogEntities"].ConnectionString;
            this._userRepository = new EFUserRepository(connectionString);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            
            
                this._userRepository.AddUser(user);
                return RedirectToAction("Index", "Home");
            
            
           //return View();
        }
    }
}
