using ArticlesAPI.Models;
using System.Collections.Generic;
namespace ArticlesAPI.Services.ArticleServices
{
    public interface IArticleServices
    {
        List<Article> GetArticles();
        Article GetArticleById(int id);
        Article AddArticle(Article article);
        void UpdateArticle(Article article);
        List<Article> DeleteArticle(int id);

    }
}