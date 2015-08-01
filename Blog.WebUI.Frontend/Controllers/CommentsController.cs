using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Repository;
namespace Blog.WebUI.Frontend.Controllers
{
    public class CommentsController : Controller
    {
        //
        // GET: /Comments/
        private readonly ICommentRepository _commentRepository;
        public CommentsController(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;

        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LeaveCommment(string formattedText, int id)
        {
            if (formattedText != string.Empty)
            {
                var decodedComment = Server.UrlDecode(formattedText);

                _commentRepository.AddComment(decodedComment, 1, id);
            }
            return Json(new { ok = true, url = Url.Action("ShowArticle", "Home", new { id = @id }) });
        }
    }
}
