using System;
using System.Collections.Generic;
using System.Linq;
using ArticlesAPI.Models;

namespace ArticlesAPI.Services.ArticleServices
{
    public class PostgresArticlesRepo : IArticleServices
    {
        private readonly ArticleContext _articleContext;
        public PostgresArticlesRepo(ArticleContext context)
        {
            _articleContext = context;
        }
        public Article AddArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            _articleContext.Articles.Add(article);
            _articleContext.SaveChanges();
            return article;
        }

        public List<Article> DeleteArticle(int id)
        {
            _articleContext.Articles.Remove(_articleContext.Articles.FirstOrDefault(a => a.Id == id));
            _articleContext.SaveChanges();
            return _articleContext.Articles.ToList();
        }

        public Article GetArticleById(int id)
        {
            return _articleContext.Articles.FirstOrDefault(a => a.Id == id);
        }

        public List<Article> GetArticles()
        {
            return _articleContext.Articles.ToList();
        }

        public void UpdateArticle(Article article)
        {
            //_articleContext.Articles.Update(article);
            _articleContext.SaveChanges();
        }
    }
}