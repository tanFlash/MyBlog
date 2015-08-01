using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class EFCommentRepository : ICommentRepository 
    {
        private readonly string _connectionString;

        public EFCommentRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

       
        public void AddComment(string content, int authorId, int articleId)
        {
            Comment comment = new Comment();
            comment.ArticleId = articleId;
            comment.AuthorId = authorId;
            comment.Content = content;
            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                var comments = context.CreateObjectSet<Comment>();
                comments.AddObject(comment);
                context.SaveChanges();

            }
        }

        public List<Comment> GetArticleComments(int articleId)
        {

            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                return context.CreateObjectSet<Comment>()
                    .Where(c => c.ArticleId == articleId)
                    .ToList();
            }
        }
    }
}
