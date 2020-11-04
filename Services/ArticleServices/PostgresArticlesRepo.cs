using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<Article> AddArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            await _articleContext.Articles.AddAsync(article);
            await _articleContext.SaveChangesAsync();
            return article;
        }

        public async Task<List<Article>> DeleteArticle(int id)
        {
            _articleContext.Articles.Remove(_articleContext.Articles.FirstOrDefault(a => a.Id == id));
            await _articleContext.SaveChangesAsync();
            return _articleContext.Articles.ToList();
        }

        public async Task<Article> GetArticleById(int id)
        {
            var article = await _articleContext.Articles.FindAsync(id);
            return article;
        }

        public async Task<List<Article>> GetArticles()
        {
            return _articleContext.Articles.ToList();
        }

        public async Task UpdateArticle(Article article)
        {
            //_articleContext.Articles.Update(article);
            await _articleContext.SaveChangesAsync();
        }
    }
}