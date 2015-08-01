using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities;

namespace Blog.Repository
{
    public interface ICommentRepository
    {
        List<Comment> GetArticleComments(int ArticleId);
        void AddComment(string content, int authorId, int articleId);
    }
}
