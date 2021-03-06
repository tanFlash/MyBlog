﻿using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public interface IArticleRepository
    {
        List <Article> GetPublished();
        void AddArticle(Article article);
        List<Article> GetUsersArticle(int id);
        void EditArticle(int id, string content);
        Article GetArticleById(int id);
        void PublishArticle(int id);
    }
}
