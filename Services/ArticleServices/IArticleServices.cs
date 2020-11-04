using ArticlesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticlesAPI.Services.ArticleServices
{
    public interface IArticleServices
    {
        Task<List<Article>> GetArticles();
        Task<Article> GetArticleById(int id);
        Task<Article> AddArticle(Article article);
        Task UpdateArticle(Article article);
        Task<List<Article>> DeleteArticle(int id);

    }
}