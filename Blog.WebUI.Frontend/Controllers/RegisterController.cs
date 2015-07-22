using Blog.Entities;
using Blog.Repository;
using Blog.WebUI.Frontend.Models;
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

        public RegisterController(IUserRepository userRepository)
        {
            
            this._userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegisterUserModel user)
        {
            if (ModelState.IsValid)
            {
                User _user = new User();
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.Login = user.Login;
                _user.Password = user.Password;
                this._userRepository.AddUser(_user);
                return RedirectToAction("Index", "Home");

            }
           return View();
        }
    }
}
