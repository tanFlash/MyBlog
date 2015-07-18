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
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        public HomeController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyBlogEntities"].ConnectionString;
            this._articleRepository = new EFArticleRepository(connectionString);
        }
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            var articles = this._articleRepository.GetPublished();
            ViewBag.Articles = articles;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateArticleModel article)
        {
            
            if (ModelState.IsValid)
            {
                Article _article = new Article();
                _article.Title = article.Title;
                _article.CreationTime = DateTime.Now;
                _article.AuthorId = 1;
                this._articleRepository.AddArticle(_article);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UsersArticles()
        {
            var articles = this._articleRepository.GetUsersArticle(1);
            ViewBag.UsersArticles= articles;
            return View();
        }

        [HttpGet]
        public ActionResult EditArticle(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult SaveFormattedText(string formattedText, int id)
        {
            var decodedText = Server.UrlDecode(formattedText);
            _articleRepository.EditArticle(id, decodedText);

            //string fileName = this.GetFileName();

            //System.IO.File.WriteAllText(fileName, decodedText);

            return Json(new { id });
        }

        
    }
}
