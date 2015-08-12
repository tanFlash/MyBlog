using Blog.Entities;
using Blog.Repository;
using Blog.WebUI.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.WebUI;

namespace Blog.WebUI.Frontend.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private ISecurityManager _securityManager;
        public HomeController(IArticleRepository articleRepository, ICommentRepository commentRepository, IUserRepository userRepository)
        {
           
            this._articleRepository = articleRepository;
            this._commentRepository = commentRepository;
            this._userRepository = userRepository;
            this._securityManager= new SecurityManager(this._userRepository);
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
        
        //Creates a new blog topic
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
        
        //shows articles of a certain user
        public ActionResult UsersArticles()
        {
            User user = _securityManager.GetAuthUser();
            var articles = this._articleRepository.GetUsersArticle(1);
            ViewBag.UsersArticles= articles;
            ViewBag.User = user;
            return View();
        }

        //GET for editing an article
        [HttpGet]
        public ActionResult EditArticle(int? id, string title)
        {
            ViewBag.Id = id;
            ViewBag.Title = title;
            return View();
        }
        
        //saves a formatted text of the article
        [HttpPost]
        public ActionResult SaveFormattedText(string formattedText, int id)
        {
            if (formattedText != string.Empty)
            {
                var decodedText = Server.UrlDecode(formattedText);
                _articleRepository.EditArticle(id, decodedText);
                //return RedirectToAction("Index", "Home");
            }


            return Json(new { id });
        }
        
        //shows the selected article
        [HttpGet]
        public ActionResult ShowArticle(int id, string title)
        {
            ViewBag.ArticleId = id;
            ViewBag.ArticleTitle = title;
            var comments = this._commentRepository.GetArticleComments(id);
            ViewBag.ArticlesComments = comments;
            ViewBag.Users = _userRepository.GetUsers();
            return View();
        }
        
        //loads a text that already exists into the editting field 
        [HttpPost]
        public JsonResult LoadFormattedText(int id)
        {
            string formattedText = _articleRepository.GetArticleById(id).Content;
            string encodedText = Server.UrlEncode(formattedText);
            return Json(new {formattedText = encodedText });
        }

        //Publishes an article
        public ActionResult PublishArticle(int id)
        {
            _articleRepository.PublishArticle(id);
            return RedirectToAction("UsersArticles", "Home");
        }
       
    }
}
